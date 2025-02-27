using AutoMapper;
using StockTrackingApp.UI.Areas.Admin.Models.ProductVMs;

namespace StockTrackingApp.UI.Areas.Admin.ViewComponents
{
    public class _AdminCategoryDetailProductsViewComponentPartial :ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private IMapper _mapper;

        public _AdminCategoryDetailProductsViewComponentPartial(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {


            var result = await _categoryService.GetProductsByCategoryAsync(id);

            if(result ==null)
            {

                return View(new List<AdminProductListVM>());

            }
            var mappedData = _mapper.Map<List<AdminProductListVM>>(result);
            return View(mappedData);

        }
    }
}
