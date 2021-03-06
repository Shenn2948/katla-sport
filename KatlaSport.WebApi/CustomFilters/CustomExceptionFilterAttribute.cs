﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

using KatlaSport.Services;

namespace KatlaSport.WebApi.CustomFilters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            // TODO Add logging here.
            if (context.Exception is RequestedResourceNotFoundException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else if (context.Exception is RequestedResourceHasConflictException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Conflict);
            }
            else if (context.Exception is Exception ex)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}