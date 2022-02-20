using BL;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApartmentBrokerage
{

    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        public IRatingBL ratingBL;
        private readonly RequestDelegate _next;
        ILogger<RatingMiddleware> _logger;


        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<RatingMiddleware> logger, IRatingBL ratingBL)
        {
            this.ratingBL = ratingBL;
            _logger = logger;

            Rating rating = new Rating
            {
                Host = httpContext.Request.Host.Host,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                Referer = httpContext.Request.Headers["Referer"].ToString(),
                UserAgent = httpContext.Request.Headers["User-Agent"].ToString(),
                RecordDate = DateTime.Now
            };

            await ratingBL.PostRating(rating);
            await _next(httpContext);
        }
            
}
       
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
