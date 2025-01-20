using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApp.Dtos.ApiUsers;
using StockTrackingApp.Dtos.Attributes;
using StockTrackingApp.UI.Areas.Admin.Models.ApiUserVMs;
using X.PagedList.Extensions;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    [BreadcrumbName("ApiUsers")]
    public class ApiUserController : AdminBaseController
    {
        private readonly IApiUserService _apiUserService;
        private readonly IMapper _mapper;

        public ApiUserController(IApiUserService apiUserService, IMapper mapper)
        {
            _apiUserService = apiUserService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index(string typeOfApiUser, int? page, int pageSize = 10)
        {
            int pageNumber = page ?? 1;
            var apiUserResult = await _apiUserService.GetAllAsync();
            var apiUserList = _mapper.Map<List<AdminApiUserListVM>>(apiUserResult.Data).OrderBy(x => x.FirstName).ToList();

            if (!string.IsNullOrEmpty(typeOfApiUser))
                apiUserList = await Search(typeOfApiUser);

            var pagedList = apiUserList.ToPagedList(pageNumber, pageSize);

            ViewBag.PageSize = pageSize;
            ViewBag.typeOfApiUser = typeOfApiUser;

            return View(pagedList);

        }



        public async Task<List<AdminApiUserListVM>> Search(string typeOfApiUser)
        {
            var apiUserResult = await _apiUserService.GetAllAsync();
            var apiUserList = _mapper.Map<List<AdminApiUserListVM>>(apiUserResult.Data);

            var searchList = apiUserList
                .Where(s =>
                    string.Equals(s.FirstName, typeOfApiUser, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(s.LastName, typeOfApiUser, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals($"{s.FirstName} {s.LastName}", typeOfApiUser, StringComparison.OrdinalIgnoreCase))
                .OrderBy(o => o.FirstName)
                .ToList();

            return searchList;
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminApiUserCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var createApiUserDto = _mapper.Map<ApiUserCreateDto>(model);
            var result = await _apiUserService.AddAsync(createApiUserDto);

            if (!result.IsSuccess)
            {
                NotifyErrorLocalized(result.Message);
                return View(model);
            }

            NotifySuccess($"{model.FirstName} {model.LastName} başarıyla eklendi.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _apiUserService.GetByIdAsync(id);

            if (!result.IsSuccess)
            {
                NotifyErrorLocalized(result.Message);
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<AdminApiUserUpdateVM>(result.Data);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminApiUserUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var updateApiUserDto = _mapper.Map<ApiUserUpdateDto>(model);


            var result = await _apiUserService.UpdateAsync(updateApiUserDto);

            if (!result.IsSuccess)
            {
                NotifyErrorLocalized(result.Message);
            }
            else
            {
                NotifySuccessLocalized(result.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var apiUserDeleteResponse = await _apiUserService.DeleteAsync(id);

            if (apiUserDeleteResponse.IsSuccess)
                NotifySuccessLocalized(apiUserDeleteResponse.Message);
            else
                NotifyErrorLocalized(apiUserDeleteResponse.Message);
            return Json(apiUserDeleteResponse);
        }
        [BreadcrumbName("ApiUser_Details")]
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _apiUserService.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                var apiUsersDetailsVM = _mapper.Map<AdminApiUserDetailsVM>(result.Data);
                return View(apiUsersDetailsVM);
            }

            NotifyError(result.Message);
            return RedirectToAction(nameof(Index));
        }
        public async Task<AdminApiUserUpdateVM> GetApiUser(Guid apiUserId)
        {
            var getApiUserResult = await _apiUserService.GetByIdAsync(apiUserId);
            var apiUserDto = getApiUserResult.Data;
            var apiUserUpdateVM = _mapper.Map<AdminApiUserUpdateVM>(apiUserDto);
            return apiUserUpdateVM;
        }
    }
}
