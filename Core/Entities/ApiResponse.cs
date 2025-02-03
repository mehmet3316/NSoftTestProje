using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Data { get; set; }

        public ApiResponse(int statusCode, string message, string data = null)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public static ApiResponse<T> Success(string data, string message = "İşlem Başarılı") =>
            new ApiResponse<T>(200, message, data);

        public static ApiResponse<T> Fail(int statusCode, string message) =>
            new ApiResponse<T>(statusCode, message);
    }
}
