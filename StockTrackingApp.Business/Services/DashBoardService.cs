
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Dashboards;

namespace StockTrackingApp.Business.Services
{
    public class DashBoardService : IDashboardService
    {
        public Task<IDataResult<DashboardOverviewDTO>> GetDashboardOverview()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<DashboardEventDto>>> GetEventsAsync(int? year, int? month)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<DashboardNoteDto>>> GetNotesAsync(int? year, int? month)
        {
            throw new NotImplementedException();
        }
    }
}
