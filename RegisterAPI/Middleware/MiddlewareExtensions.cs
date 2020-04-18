using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAPI.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAppException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppExceptionMiddleware>();
        }

        public static IApplicationBuilder UseAppStatus(this IApplicationBuilder builder)
        {
            return builder.MapWhen(context => context.Request.Method=="GET" && context.Request.Path.Equals("register/service-status"), appBuilder =>
            {
                appBuilder.UseMiddleware<AppStatusMiddleware>();
            });
           
        }        
    }
}
