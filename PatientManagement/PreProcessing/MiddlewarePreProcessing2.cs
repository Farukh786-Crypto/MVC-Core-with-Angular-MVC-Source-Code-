using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.PreProcessing
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewarePreProcessing2
    {
        private readonly RequestDelegate _next;

        public MiddlewarePreProcessing2(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewarePreProcessing2Extensions
    {
        public static IApplicationBuilder UseMiddlewarePreProcessing2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewarePreProcessing2>();
        }
    }
}
