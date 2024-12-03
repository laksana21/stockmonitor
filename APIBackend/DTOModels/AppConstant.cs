namespace APIBackend.DTOModels
{
    public class AppConstant
    {
        public static readonly int index = 0;
        public static readonly int timespan = 6;
        public static readonly string first = "1";
        public static readonly int extSessionHours = 3;

        public static readonly List<string> TransactStatus = new List<string>(new string[] { "Draft", "Success", "Rejected" });
    }

    public class MessageConstants
    {
        public const string S_RESPONSE_STATUS_CODE_OK = "200";
        public const string S_RESPONSE_STATUS_CODE_NOT_FOUND = "404";
        public const string S_RESPONSE_STATUS_CODE_INTERNAL_SERVER_ERROR = "500";

        public const string S_NOT_AUTHORIZE = "Unauthorized";
        public const string S_REQUEST_INVALID = "The Request is invalid";

        public const string S_DATA_NOT_FOUND = "Data Not found!";
        public const string S_UNEXPECTED_ERROR_OCCURRED = "Unexpected Error Occurred!";
        public const string S_SUCCESSFULLY = "Successfully!";
        public const string S_SOMETHING_ERROR = "Something error!";
        public const string S_LOGIN_ERROR = "Login error!";
        public const string S_LOGOUT_ERROR = "Logout Failed!";
        public const string S_TOKEN_NOT_CORRECT = "Token key is incorrect!";
        public const string S_REQUIRED_FIELD_NOT_FOUND = "Field not found!";
        public const string S_FILE_SUCCESS_IMPORT = ", files success to import.";
        public const string S_OUT_OF_STOCK = "Out of stock!";

        public const string S_FAILED_GET_ITEM = "{0} has not found.";
        public const string S_SUCCESS_DELETE = "{0} has been delete successfully.";
    }

    public enum HTTPCode
    {
        Continue = 100,
        Switching_Protocols = 101,
        Processing = 102,
        Early_Hints = 103,
        OK = 200,
        Created = 201,
        Accepted = 202,
        Non_Authoritative_Information = 203,
        No_Content = 204,
        Bad_Request = 400,
        Unauthorized = 401,
        Payment_Required = 402,
        Forbidden = 403,
        Not_Found = 404,
        Method_Not_Allowed = 405,
        Not_Acceptable = 406
    }

    public enum TransactionStatus
    {
        Draft = 0,
        Success,
        Rejected
    }
}
