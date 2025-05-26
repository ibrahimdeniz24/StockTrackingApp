using AspNetCoreHero.ToastNotification.Extensions;
using Hangfire;
using Microsoft.AspNetCore.Localization;
using OfficeOpenXml;
using StockTrackingApp.BackgroundJobs;
using StockTrackingApp.Business.Extantions;
using StockTrackingApp.DataAccess.Contexts;
using StockTrackingApp.DataAccess.EFCore.Extantions;
using StockTrackingApp.DataAccess.Extantions;
using StockTrackingApp.Dtos.SendMails;
using StockTrackingApp.UI.Extantions;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDataAccessServices(builder.Configuration)
    .AddEFCoreServices(builder.Configuration)
    .AddBusinessServices()
    .AddMvcServices()
    .AddHangfire(builder.Configuration)
    .Configure<EmailConfigurationDto>(builder.Configuration.GetSection("EmailConfiguration"))
    .AddHangfireServer();

GlobalConfiguration.Configuration
    .UseSqlServerStorage(builder.Configuration.GetConnectionString(StockAppDbContext.ConnectionName));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error/");
    app.UseHsts();
}


// ?? BU KISMI EKLEDÝK
var cultureInfo = new CultureInfo("tr-TR");
cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
app.UseStatusCodePagesWithReExecute("/ErrorPage/ErrorIndex", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.UseHangfireDashboard("/hangfire", new DashboardOptions
//{
//    DashboardTitle = "Examm App HangFire Dashboard",
//    Authorization = new[] { new HangfireAuthorizationFilter() }
//});

var cultures = new List<CultureInfo>
{
    new CultureInfo("tr")
};

app.UseRequestLocalization(options =>
{
    var supportedCultures = new[] { "en", "tr" };
    options.DefaultRequestCulture = new RequestCulture("tr");
    options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();

    options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
});


app.UseNotyf();
app.UseSession();
app.MapControllerRoute(name: "default",
                       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();

app.Run();
