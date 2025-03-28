using AutoMapper;
using StockTrackingApp.Dtos.Categories;
using StockTrackingApp.Dtos.Customers;
using StockTrackingApp.Entities.Enums;
using StockTrackingApp.UI.Areas.Admin.Models.CategoryVMs;
using StockTrackingApp.UI.Areas.Admin.Models.CustomerVMs;
using System.Text;
using X.PagedList;
using X.PagedList.Extensions;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class CustomerController : AdminBaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page, int pageSize = 10,string searchTerm=null)
        {
            int pageNumber = page ?? 1;
            var customerPagedResult = await _customerService.GetPagedOrdersAsync(pageNumber,pageSize,searchTerm);



            var customerList = _mapper.Map<List<AdminCustomerListVM>>(customerPagedResult.Items);

            var pagedList = new StaticPagedList<AdminCustomerListVM>(customerList, pageNumber, pageSize, customerPagedResult.TotalCount);

            // Sayfa boyutunu ViewBag'e gönderme
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;

            // Enum değerlerini View'e gönderme (VAT oranları)
            var vatRates = Enum.GetValues(typeof(VatRate))
                .Cast<VatRate>()
                .Select(v => new { Id = (int)v, Name = v.GetDisplayName() })
                .ToList();

            ViewBag.VatRates = vatRates;

            return View(pagedList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCustomerCreateVM model)
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
            var customerDto = _mapper.Map<CustomerCreateDto>(model);

            var addResult = await _customerService.AddAsync(customerDto);
            if (!addResult.IsSuccess)
            {
                NotifyErrorLocalized(addResult.Message);
                return RedirectToAction(nameof(Index));
            }

            NotifySuccessLocalized(addResult.Message);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var getGroupType = await _customerService.GetDetailsByIdAsync(id);

            if (!getGroupType.IsSuccess)
            {
                NotifyErrorLocalized(getGroupType.Message);
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<AdminCustomerDetailsVM>(getGroupType.Data));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _customerService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                NotifySuccessLocalized(result.Message);
            }
            else
            {
                NotifyErrorLocalized(result.Message);
            }

            return Json(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(AdminCustomerUpdateVM customerUpdateVM)
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

            var customerUpdateDto = _mapper.Map<CustomerUpdateDto>(customerUpdateVM);
            var customerUpdateResponse = await _customerService.UpdateAsync(customerUpdateDto);
            if (!customerUpdateResponse.IsSuccess)
            {
                NotifyErrorLocalized(customerUpdateResponse.Message);
                return View(nameof(Index));
            }
            else
            {
                NotifySuccessLocalized(customerUpdateResponse.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
