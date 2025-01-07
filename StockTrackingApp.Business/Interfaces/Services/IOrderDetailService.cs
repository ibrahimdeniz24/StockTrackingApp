using StockTrackingApp.Dtos.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IOrderDetailService
    {
        Task<IDataResult<OrderDetailDto>> GetByIdAsync(Guid id);
        Task<IDataResult<OrderDetailDto>> AddAsync(OrderDetailCreateDto orderCreateDto);

        
        Task<IDataResult<List<OrderDetailDto>>> GetAllAsync();
        Task<IDataResult<OrderDetailDto>> UpdateAsync(OrderDetailUpdateDto orderDetailUpdateDto);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<OrderDetailDto>> GetDetailsByIdAsync(Guid id);
    }
}
