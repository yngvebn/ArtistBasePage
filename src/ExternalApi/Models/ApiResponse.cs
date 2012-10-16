using System;

namespace ExternalApi.Models
{
    public class ApiResponse<T>
    {
        public ApiResponseStatus Status { get; private set; }
        public T Data { get; private set; }
        public Exception Exception { get; private set; }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T>()
                {
                    Status = ApiResponseStatus.Success,
                    Data = data
                };
        }

        public static ApiResponse<T> Fail(Exception ex)
        {
            return new ApiResponse<T>()
                {
                    Exception  =ex,
                    Data = default(T),
                    Status = ApiResponseStatus.Failed
                };
        } 
    }

    public enum ApiResponseStatus
    {
        Success,
        Failed
    }
}