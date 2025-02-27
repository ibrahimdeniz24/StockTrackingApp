﻿
using Hangfire.Dashboard;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace StockTrackingApp.BackgroundJobs
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            return userRole == "Admin";
        }
    }
}
