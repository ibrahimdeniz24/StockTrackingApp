
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Core.Enums;
using StockTrackingApp.Core.Utilities.Results.Concrete;
using StockTrackingApp.Dtos.Admins;
using System.Security.Claims;

namespace StockTrackingApp.Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AdminService(IAdminRepository adminRepository, IAccountService accountService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _adminRepository = adminRepository;
            _accountService = accountService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult<AdminDto>> AddAsync(AdminCreateDto adminCreateDto)
        {
            if (await _accountService.AnyAsync(x => x.Email == adminCreateDto.Email))
            {
                return new ErrorDataResult<AdminDto>(Messages.EmailDuplicate);
            }

            IdentityUser identityUser = new()
            {
                Email = adminCreateDto.Email,
                UserName = adminCreateDto.Email,
                EmailConfirmed = true, // TODO: Email confirmation yapılırsa burası değiştirilmeli.
            };

            DataResult<AdminDto> result = new ErrorDataResult<AdminDto>();

            var strategy = await _adminRepository.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transactionScope = await _adminRepository.BeginTransactionAsync().ConfigureAwait(false);
                try
                {
                    var identityResult = await _accountService.CreateUserAsync(identityUser, Roles.Admin);
                    if (!identityResult.Succeeded)
                    {

                        result = new ErrorDataResult<AdminDto>(identityResult.ToString());

                        transactionScope.Rollback();
                        return;
                    }

                    Admin admin = _mapper.Map<Admin>(adminCreateDto);
                    admin.IdentityId = identityUser.Id;

                    await _adminRepository.AddAsync(admin);
                    await _adminRepository.SaveChangesAsync();

                    result = new SuccessDataResult<AdminDto>(_mapper.Map<AdminDto>(admin), Messages.AddSuccess);
                    transactionScope.Commit();
                }
                catch (Exception ex)
                {
                    result = new ErrorDataResult<AdminDto>($"{Messages.AddFail} - {ex.Message}");
                    transactionScope.Rollback();
                }
                finally
                {
                    transactionScope.Dispose();
                }
            });

            return result;
        }

        public async Task<Core.Utilities.Results.IResult> DeleteAsync(Guid id)
        {
            var admin = await _adminRepository.GetByIdAsync(id);

            if (admin == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            var deleteIdentityResult = await _accountService.DeleteUserAsync(admin.IdentityId!);

            if (!deleteIdentityResult.Succeeded)
            {
                return new ErrorResult(deleteIdentityResult.ToString());
            }

            await _adminRepository.DeleteAsync(admin);
            await _adminRepository.SaveChangesAsync();

            return new SuccessResult(Messages.DeleteSuccess);
        }

        public async Task<IDataResult<List<AdminListDto>>> GetAllAsync()
        {
            var admins = await _adminRepository.GetAllAsync();

            return new SuccessDataResult<List<AdminListDto>>(_mapper.Map<List<AdminListDto>>(admins), Messages.ListedSuccess);
        }

        public async Task<IDataResult<AdminDto>> GetByIdAsync(Guid id)
        {
            var admin = await _adminRepository.GetByIdAsync(id);

            if (admin is null)
            {
                return new ErrorDataResult<AdminDto>(Messages.UserNotFound);
            }

            return new SuccessDataResult<AdminDto>(_mapper.Map<AdminDto>(admin), Messages.ListedSuccess);
        }

        public async Task<IDataResult<AdminDto>> GetByIdentityIdAsync(string identityId)
        {
            var admin = await _adminRepository.GetByIdentityIdAsync(identityId);

            if (admin is null)
            {
                return new ErrorDataResult<AdminDto>(Messages.UserNotFound);
            }

            return new SuccessDataResult<AdminDto>(_mapper.Map<AdminDto>(admin), Messages.ListedSuccess);
        }

        public async Task<IDataResult<AdminDto>> GetCurrentAdminAsync()
        {
            var identityUserId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(identityUserId))
                return new ErrorDataResult<AdminDto>(Messages.UserNotFound);

            var admin = await _adminRepository.GetAsync(x => x.IdentityId == identityUserId);

            if (admin == null)
                return new ErrorDataResult<AdminDto>(Messages.UserNotFound);
            var adminDto = admin.Adapt<AdminDto>();

            return new SuccessDataResult<AdminDto>(adminDto, Messages.UserNotFound);
        }

        public async Task<IDataResult<AdminDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var admin = await _adminRepository.GetByIdAsync(id);

            if (admin is null)
            {
                return new ErrorDataResult<AdminDetailsDto>(Messages.UserNotFound);
            }

            return new SuccessDataResult<AdminDetailsDto>(_mapper.Map<AdminDetailsDto>(admin), Messages.FoundSuccess);
        }

        public Task<IDataResult<AdminDto>> RoleAddAsync(AdminCreateDto adminCreateDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<AdminDto>> UpdateAsync(AdminUpdateDto adminUpdateDto)
        {
            var admin = await _adminRepository.GetByIdAsync(adminUpdateDto.Id);

            if (admin is null)
            {
                return new ErrorDataResult<AdminDto>(Messages.UserNotFound);
            }

            var updatedAdmin = _mapper.Map(adminUpdateDto, admin);

            await _adminRepository.UpdateAsync(updatedAdmin);
            await _adminRepository.SaveChangesAsync();

            return new SuccessDataResult<AdminDto>(_mapper.Map<AdminDto>(updatedAdmin), Messages.UpdateSuccess);
        }
    }
}
