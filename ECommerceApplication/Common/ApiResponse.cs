using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Common
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; } = false;

        public string DisplayMessage { get; set; } = "";

        public object Result { get; set; }

        public List<ApiErrors> Errors { get; set; } = new();

        public List<ApiWarnings> Warnings { get; set; } = new();

        public void AddErrors(string ErrorMessage)
        {
            ApiErrors apiErrors = new ApiErrors(description: ErrorMessage);
            Errors.Add(apiErrors);
        }

        public void AddWarnings(string WarnMessage)
        {
            ApiWarnings apiWarnings = new ApiWarnings(description: WarnMessage);
            Warnings.Add(apiWarnings);
        }

    }
}
