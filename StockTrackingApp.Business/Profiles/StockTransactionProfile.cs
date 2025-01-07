

using StockTrackingApp.Dtos.StockTransactions;

namespace StockTrackingApp.Business.Profiles
{
    public class StockTransactionProfile :Profile
    {
        public StockTransactionProfile()
        {
            CreateMap<StockTransaction,StockTransactionCreateDto>();
            CreateMap<StockTransaction,StockTransactionListDto>();
            CreateMap<StockTransaction,StockTransactionDto>();
        }
    }
}
