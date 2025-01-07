namespace StockTrackingApp.Business.Constants
{
    public class Messages
    {
        public const string ListedSuccess = "Listed_Success";
        public const string ListNotFound = "List_Not_Found";
        public const string ListReceived = "List_Received";
        public const string ListNotReceived = "List_Not_Received";
        public const string InvalidParameter = "Invalid_Parameter";

        public const string EmailDuplicate = "Email_Duplicate";
        public const string UserNotFound = "User_Not_Found";
        public const string FoundSuccess = "Found_Successfully";
        public const string FoundFail = "Found_Fail";
        public const string RegisterCodeCreated = "Register_Code_Created_Success";

        public const string AddSuccess = "Add_Success";
        public const string AddError = "Add_Error";
        public const string AddFail = "Add_Fail";
        public const string AddUserFail = "Add_User_Fail";
        public const string AddUserRoleFail = "Add_User_Role_Fail";
        public const string AddFailAlreadyExists = "Add_Fail_Already_Exists";

        public const string UpdateSuccess = "Update_Success";
        public const string UpdateFail = "Update_Fail";


        public const string DeleteSuccess = "Delete_Success";
        public const string DeleteFail = "Delete_Fail";
        public const string DeleteSuccessRedirect = "Delete_Success_Redirect";

        public const string LoginSuccessful = "Login_Successful";
        public const string InvalidRegisterCode = "Invalid_Register_Code";

        // Email For Messages
        #region Email Messages
        public const string GetAllSuccess = "Gönderilen mailler başarıyla getirildi.";
        public const string GetListFail = "Gönderilen mailler getirilirken hata oluştu.";
        public const string EmailSendSuccess = "Email_Send_Success";
        public const string EmailSendNotFound = "Email_Send_Not_Found";
        public const string EmailSendError = "Email_Send_Error";
        public const string EmailNotFound = "Email_Not_Found";
        public const string EmailFoundSuccess = "Email_Found_Success";
        public const string SentEmailFoundSuccess = "Sent_Email_Found_Success";
        #endregion
    }
}
