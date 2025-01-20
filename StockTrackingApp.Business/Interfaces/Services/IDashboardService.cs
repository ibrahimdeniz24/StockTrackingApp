using StockTrackingApp.Dtos.Dashboards;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IDashboardService
    {/// <summary>
     /// GetDashboardOverview is an asynchronous method that retrieves an overview of the dashboard.
     /// It counts the number of students, trainers, and exams from their respective repositories and assigns these counts to the DashboardOverviewDTO object.
     /// It fetches all student exams from the _studentExamRepository, calculates the average score, and assigns this average to the SuccessRate property of the DashboardOverviewDTO object.
     /// </summary>
     /// <returns>The method returns a SuccessDataResult object containing the DashboardOverviewDTO object and a success message.</returns>
        Task<IDataResult<DashboardOverviewDTO>> GetDashboardOverview();
        /// <summary>
        /// GetEventsAsync is an asynchronous method that retrieves a list of DashboardEventDto objects.
        /// If a year and month are provided, it fetches the events for that specific month of the year.
        /// If no year and month are provided, it fetches the events for the current month of the current year.
        /// </summary>
        /// <returns>The method returns a SuccessDataResult object containing the list of DashboardEventDto objects and a success message.</returns>
        Task<IDataResult<List<DashboardEventDto>>> GetEventsAsync(int? year, int? month);
      

        Task<IDataResult<List<DashboardNoteDto>>> GetNotesAsync(int? year, int? month);
    }
}
