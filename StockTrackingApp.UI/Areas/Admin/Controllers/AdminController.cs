
using AutoMapper;
using Hangfire;
using Microsoft.Extensions.Localization;
using StockTrackingApp.Dtos.Admins;
using StockTrackingApp.Dtos.Attributes;
using StockTrackingApp.Dtos.Emails;
using StockTrackingApp.Dtos.SendMails;
using StockTrackingApp.UI.Areas.Admin.Models.AdminVMs;
using StockTrackingApp.UI.Extantions;
using X.PagedList.Extensions;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    [BreadcrumbName("Admins")]
    public class AdminController :AdminBaseController
    {
        private readonly IAdminService _adminService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly ISendMailService _sendMailService;
        private readonly IStringLocalizer<SharedModelResource> _stringLocalizer;

        public AdminController(IAdminService adminService, IEmailService emailService, IMapper mapper, ISendMailService sendMailService, IStringLocalizer<SharedModelResource> stringLocalizer)
        {
            _adminService = adminService;
            _emailService = emailService;
            _mapper = mapper;
            _sendMailService = sendMailService;
            _stringLocalizer = stringLocalizer;
        }


        /// <summary> 
        /// Bu yöntem, admin listesini filtreleme ve sayfalama işlemlerini gerçekleştirir. 
        /// Tüm adminleri alır, verilen filtreleme kriterlerine (firstName, lastName, email) göre filtreler 
        /// ve sayfalara bölünmüş bir admin listesi döndürür. Filtreleme kriterleri ve sayfalama detayları, 
        /// ViewBag kullanılarak view'e aktarılır. 
        /// </summary>

        public async Task<IActionResult> Index(string firstName, string lastName, string email, int? page, int pageSize = 10)
        {

            int pageNumber = page ?? 1;
            //int pageSize = 10;

            var result = await _adminService.GetAllAsync();
            var adminList = _mapper.Map<List<AdminAdminListVM>>(result.Data).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            if (!string.IsNullOrEmpty(firstName))
            {
                firstName = firstName.Trim();
                adminList = adminList.Where(a => a.FirstName.Contains(firstName, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                lastName = lastName.Trim();
                adminList = adminList.Where(a => a.LastName.Contains(lastName, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(email))
            {
                email = email.Trim();
                adminList = adminList.Where(a => a.Email.Contains(email, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            var paginatedList = adminList.ToPagedList(pageNumber, pageSize);

            ViewBag.PageSize = pageSize;
            ViewBag.CurrentPage = pageNumber;
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.Email = email;

            return View(paginatedList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new AdminAdminCreateVM()
            {
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminAdminCreateVM model, IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    var errorMessage = error.ErrorMessage;
                    //var propertyName = error.PropertyName;
                }
                return RedirectToAction(nameof(Index));
            }

            var adminDto = _mapper.Map<AdminCreateDto>(model);

            adminDto.FirstName = StringExtensions.TitleFormat(model.FirstName);
            adminDto.LastName = StringExtensions.TitleFormat(model.LastName);

            var addAdminResult = await _adminService.AddAsync(adminDto);
            if (!addAdminResult.IsSuccess)
            {
                NotifyErrorLocalized(_stringLocalizer["Turkish_Characters_Not_Allowed"]);
                return RedirectToAction(nameof(Index));
            }

            var adminOtherEmailList = new List<EmailCreateDto>();
            var otherEmailsList = collection["otherEmails"].ToList();
            var identityId = addAdminResult.Data.IdentityId;

            foreach (var adminOtherEmail in otherEmailsList)
            {
                adminOtherEmailList.Add(new EmailCreateDto() { EmailAddress = adminOtherEmail, IdentityId = identityId });
            }

            var addEmailResult = await _emailService.AddRangeAsync(adminOtherEmailList);
            if (!addEmailResult.IsSuccess)
            {
                NotifyErrorLocalized(addEmailResult.Message);
                return RedirectToAction(nameof(Index));
            }

            string link = Url.Action("index", "login", new { Area = "" }, Request.Scheme);

            var newUserMailDto = new NewUserMailDto { Email = addAdminResult.Data.Email, Url = link };

            // Use Hangfire to enqueue the email sending task
            BackgroundJob.Enqueue(() => _sendMailService.SendEmailNewAdmin(newUserMailDto));


            NotifySuccess($"{model.FirstName} {model.LastName}" + _stringLocalizer["the_person_was_successfully_added,_and_an_email_was_sent_to_their_email_address."]);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var adminDeleteResponse = await _adminService.DeleteAsync(id);

            if (adminDeleteResponse.IsSuccess)
                NotifySuccessLocalized(adminDeleteResponse.Message);
            else
                NotifySuccessLocalized(adminDeleteResponse.Message);
            return Json(adminDeleteResponse);
        }

        [BreadcrumbName("Admin_Details")]
        public async Task<IActionResult> Details(Guid Id)
        {

            var getAdmin = await _adminService.GetDetailsByIdAsync(Id);
            if (getAdmin.IsSuccess)
            {
                var adminDetailsVM = _mapper.Map<AdminAdminDetailsVM>(getAdmin.Data);
                adminDetailsVM.OtherEmails = (await _emailService.GetEmailAddressesByIdentityIdAsync(getAdmin.Data.IdentityId)).Data;
                return View(adminDetailsVM);
            }

            NotifyError(getAdmin.Message);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var getAdminResult = await _adminService.GetByIdAsync(id);
            if (!getAdminResult.IsSuccess)
            {
                NotifyErrorLocalized(getAdminResult.Message);
                return RedirectToAction(nameof(Index));
            }

            var adminDto = getAdminResult.Data;
            var adminUpdateVM = _mapper.Map<AdminAdminUpdateVM>(adminDto);
            adminUpdateVM.OtherEmails = (await _emailService.GetEmailAddressesByIdentityIdAsync(getAdminResult.Data.IdentityId)).Data;
            return View(adminUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminAdminUpdateVM model, IFormCollection collection)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var updateAdmin = _mapper.Map<AdminUpdateDto>(model);

            updateAdmin.FirstName = StringExtensions.TitleFormat(model.FirstName);
            updateAdmin.LastName = StringExtensions.TitleFormat(model.LastName);

            var updateAdminResult = await _adminService.UpdateAsync(updateAdmin);
            if (!updateAdminResult.IsSuccess)
            {
                NotifyErrorLocalized(updateAdminResult.Message);
                return View(model);
            }

            var otherEmailsList = collection["otherEmails"].ToList();
            var adminOtherEmailList = new List<EmailCreateDto>();
            var identityId = updateAdminResult.Data.IdentityId;

            foreach (var adminOtherEmail in otherEmailsList)
            {
                adminOtherEmailList.Add(new EmailCreateDto() { EmailAddress = adminOtherEmail, IdentityId = identityId });
            }
            var addEmailResult = await _emailService.UpdateRangeAsync(adminOtherEmailList, identityId);

            NotifySuccessLocalized(updateAdminResult.Message);
            return RedirectToAction(nameof(Index));
        }
    }
}
