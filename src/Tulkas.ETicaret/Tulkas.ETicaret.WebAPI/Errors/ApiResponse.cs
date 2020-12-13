namespace Tulkas.ETicaret.WebAPI.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(in int statusCode)
        {
            string errorMessage = string.Empty;
            switch (statusCode)
            {
                case 400:
                    errorMessage = "A Bad Request";
                    break;
                case 401:
                    errorMessage = "Authorized Error";
                    break;
                case 404:
                    errorMessage = "Resource Not Found";
                    break;
                case 500:
                    errorMessage = "Server Found";
                    break;
            }

            return errorMessage;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
