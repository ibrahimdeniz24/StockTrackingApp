using AutoMapper;
using StockTrackingApp.Dtos.Warehouses;
using StockTrackingApp.UI.Areas.Admin.Models.CategoryVMs;
using StockTrackingApp.UI.Areas.Admin.Models.WarehouseVMs;
using System.Text;
using X.PagedList.Extensions;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class WarehouseController : AdminBaseController
    {

        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;

        public WarehouseController(IWarehouseService warehouseService, IMapper mapper)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page, int pageSize = 10)
        {
            int pageNumber = page ?? 1;
            var warehousesGetResult = await _warehouseService.GetAllAsync();
            var categoryList = _mapper.Map<List<AdminWarehouseListVM>>(warehousesGetResult.Data).OrderBy(o => o.Name).ToList();


            var pagedList = categoryList.ToPagedList(pageNumber, pageSize);

            ViewBag.PageSize = pageSize;

            return View(pagedList);
        }


        public async Task<List<AdminWarehouseListVM>> Search(string warehouse)
        {
            var warehousesGetResult = await _warehouseService.GetAllAsync();
            var warehouseList = _mapper.Map<List<AdminWarehouseListVM>>(warehousesGetResult.Data);

            var searchList = warehouseList
                .Where(s => s.Name.IndexOf(warehouse, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(o => o.Name)
                .ToList();

            return searchList;
        }


        public async Task<IActionResult> Create(AdminWarehouseCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                var errorMessages = new StringBuilder();

                foreach (var error in errors)
                {
                    if (errorMessages.Length > 0)
                    {
                        errorMessages.Append(", ");

                        if (errorMessages.ToString().Contains(error.ErrorMessage))
                        {
                            continue;
                        }
                    }

                    errorMessages.Append(error.ErrorMessage);
                }

                NotifyError(errorMessages.ToString());
                return RedirectToAction(nameof(Index));
            }

            var warehouseDto = _mapper.Map<WarehouseCreateDto>(model);
            var addResult = await _warehouseService.AddAsync(warehouseDto);
            if (addResult.IsSuccess)
            {
                NotifySuccess(addResult.Message);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                NotifyError(addResult.Message);
                return RedirectToAction(nameof(Index));
            }

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _warehouseService.DeleteAsync(id);
            if (deleteResult.IsSuccess)
            {
                NotifySuccess(deleteResult.Message);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                NotifyError(deleteResult.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var getDetailsResult = await _warehouseService.GetDetailsByIdAsync(id);
            if (getDetailsResult.IsSuccess)
            {
                return View(_mapper.Map<AdminWarehouseDetailsVM>(getDetailsResult.Data));
            }
            else
            {
                NotifyError(getDetailsResult.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Update(AdminWarehouseUpdateVM warehouseUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                var errorMessages = new StringBuilder();

                foreach (var error in errors)
                {
                    if (errorMessages.Length > 0)
                    {
                        errorMessages.Append(", ");

                        if (errorMessages.ToString().Contains(error.ErrorMessage))
                        {
                            continue;
                        }
                    }

                    errorMessages.Append(error.ErrorMessage);
                }

                NotifyError(errorMessages.ToString());
                return RedirectToAction(nameof(Index));
            }

            var warehouseDto = _mapper.Map<WarehouseUpdateDto>(warehouseUpdateVM);
            var updateResult = await _warehouseService.UpdateAsync(warehouseDto);
            if (updateResult.IsSuccess)
            {
                NotifySuccess(updateResult.Message);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                NotifyError(updateResult.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
