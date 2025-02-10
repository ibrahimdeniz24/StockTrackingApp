
using StockTrackingApp.Dtos.Warehouses;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IWarehouseService
    {
        Task<IDataResult<WarehouseDto>> GetByIdAsync(Guid id);
        Task<IDataResult<WarehouseDto>> AddAsync(WarehouseCreateDto warehouseCreateDto);

        Task<IDataResult<List<WarehouseListDto>>> GetAllAsync();
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<WarehouseDetailsDto>> GetDetailsByIdAsync(Guid id);

        Task<IDataResult<WarehouseDto>> UpdateAsync(WarehouseUpdateDto warehouseUpdateDto);
    }
}
