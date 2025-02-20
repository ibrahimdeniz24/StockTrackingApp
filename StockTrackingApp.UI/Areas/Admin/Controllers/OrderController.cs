using AutoMapper;
using StockTrackingApp.Dtos.OrderDetails;
using StockTrackingApp.Dtos.Orders;
using StockTrackingApp.UI.Areas.Admin.Models.OrderDetailVMs;
using StockTrackingApp.UI.Areas.Admin.Models.OrderVMs;
using System.Text;
using X.PagedList.Extensions;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IStockService _stockService;

        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService, IMapper mapper, ICustomerService customerService, IStockService stockService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _mapper = mapper;
            _customerService = customerService;
            _stockService = stockService;
        }

        public async Task<IActionResult> Index(int? page, int pageSize = 10)
        {
            int pageNumber = page ?? 1;
            var orderGetResult = await _orderDetailService.GetAllAsync();
            var orderList = _mapper.Map<List<AdminOrderListVM>>(orderGetResult.Data).OrderBy(o => o.OrderDate).ToList();


            var pagedList = orderList.ToPagedList(pageNumber, pageSize);

            ViewBag.PageSize = pageSize;

            return View(pagedList);
        }


        public async Task<List<AdminOrderListVM>> Search(string order)
        {
            var ordersGetResult = await _orderDetailService.GetAllAsync();
            var orderList = _mapper.Map<List<AdminOrderListVM>>(ordersGetResult.Data);

            var searchList = orderList
                .Where(s => s.CustomerName.IndexOf(order, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(o => o.CustomerName)
                .ToList();

            return searchList;
        }


        public async Task<IActionResult> Create(AdminOrderCreateVM model)
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

            var orderDto = _mapper.Map<OrderCreateDto>(model);
            var addResult = await _orderService.AddAsync(orderDto);

            if (!addResult.IsSuccess)
            {
                NotifyErrorLocalized(addResult.Message);
                return RedirectToAction(nameof(Index));
            }

            NotifySuccessLocalized(addResult.Message);
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Update(AdminOrderUpdateVM model)
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
            var orderDto = _mapper.Map<OrderUpdateDto>(model);
            var updateResult = await _orderService.UpdateAsync(orderDto);
            if (!updateResult.IsSuccess)
            {
                NotifyErrorLocalized(updateResult.Message);
                return RedirectToAction(nameof(Index));
            }
            NotifySuccessLocalized(updateResult.Message);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _orderService.DeleteAsync(id);
            if (!deleteResult.IsSuccess)
            {
                NotifyErrorLocalized(deleteResult.Message);
                return RedirectToAction(nameof(Index));
            }
            NotifySuccessLocalized(deleteResult.Message);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var getOrder = await _orderService.GetDetailsByIdAsync(id);
            if (!getOrder.IsSuccess)
            {
                NotifyErrorLocalized(getOrder.Message);
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<AdminOrderDetailsVM>(getOrder.Data));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Json(new List<object>());
            }

            var customers = await _customerService.GetAllAsync(); // Tüm müşterileri getir
            var filteredCustomers = customers.Data
                .Where(c => c.
                CompanyName.Contains(term, StringComparison.OrdinalIgnoreCase)) // İçerenleri filtrele
                .Select(c => new { id = c.Id, text = c.CompanyName }) // JSON formatına çevir
                .ToList();

            return Json(filteredCustomers);
        }


        [HttpGet]
        public async Task<IActionResult> GetStocks(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Json(new List<object>());
            }

            var stocks = await _stockService.GetAllAsync(); // Tüm Stokları getir
            var filteredStocks = stocks.Data
                .Where(c => c.
                ProductName.Contains(term, StringComparison.OrdinalIgnoreCase)) // İçerenleri filtrele
                .Select(c => new { id = c.Id, text = c.ProductName }) // JSON formatına çevir
                .ToList();

            return Json(filteredStocks);
        }



    }
}
