namespace ECommerce.Common
{
    public class ConstMessage
    {

    }
    public class CommonMessage
    {
        public const string RegistrationSuccess = "Registered Successfully";
        public const string RegisterationFailed = "Register Failed";

        public const string LoginSuccess = "Login Success";
        public const string LoginFailed = "Login Failed";

        public const string LogoutSuccess = "Login Success";
        public const string LogoutFailed = "Logout Failed";


        public const string CreateOperationSuccess = "Record Created Successfully";
        public const string UpdateOperationSuccess = "Record Updated Successfully";
        public const string DeleteOperationSuccess = "Record Deleted Successfully";

        public const string CreateOperationFailed = "Created Operation Failed";
        public const string UpdateOperationFailed = "Updated Operation failed";
        public const string DeleteOperationFailed = "Delete Operation Failed";

        public const string RecordNotFound = "Record Not Found";
        public const string SystemError = "Something Went Wrong";

        public static string System { get; set; }
    }
}
