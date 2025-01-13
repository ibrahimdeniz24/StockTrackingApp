
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Categories;

namespace StockTrackingApp.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryCreateDto categoryCreateDto)
        {
            var hasCategory = await _categoryRepository.AnyAsync(x => x.CategoryName.ToLower() == categoryCreateDto.CategoryName.ToLower());
            if (hasCategory)
            {
                return new ErrorDataResult<CategoryDto>(Messages.AddFailAlreadyExists);
            }

            var category = _mapper.Map<Category>(categoryCreateDto);

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(category), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }
                await _categoryRepository.DeleteAsync(category);
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<CategoryListDto>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return new SuccessDataResult<List<CategoryListDto>>(categories.Adapt<List<CategoryListDto>>(), Messages.ListedSuccess);
        }

        public async Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(category), Messages.FoundSuccess);
            }

            return new ErrorDataResult<CategoryDto>(Messages.FoundFail);
        }

        public async Task<IDataResult<CategoryDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return new ErrorDataResult<CategoryDetailsDto>(Messages.ListNotFound);
            }

            return new SuccessDataResult<CategoryDetailsDto>(_mapper.Map<CategoryDetailsDto>(category), Messages.ListedSuccess);
        }

        public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryUpdateDto.Id);
            if (category == null)
            {
                return new ErrorDataResult<CategoryDto>(Messages.FoundFail);
            }

            var updatedCategory = _mapper.Map(categoryUpdateDto, category);

            await _categoryRepository.UpdateAsync(updatedCategory);
            await _categoryRepository.SaveChangesAsync();

            return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(updatedCategory),Messages.UpdateSuccess);
        }
    }
}
