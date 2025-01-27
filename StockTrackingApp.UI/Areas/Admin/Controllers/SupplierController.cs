using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class SupplierController : AdminBaseController
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }











    }
}
