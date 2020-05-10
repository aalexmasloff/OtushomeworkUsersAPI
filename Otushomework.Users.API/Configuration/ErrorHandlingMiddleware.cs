using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Otushomework.Users.API.Configuration
{
    //public class ErrorHandlingMiddleware
    //{
    //    // this non-standart HTTP code was introduced by NGINX for the case
    //    // when a client closes the connection while server is processing the request.
    //    private const int ClosedByClientHttpCode = 499;

    //    internal static void Action(IApplicationBuilder appBuilder)
    //    {
    //        var logger = appBuilder.ApplicationServices.GetService<ILogger<ErrorHandlingMiddleware>>();
    //        var environment = appBuilder.ApplicationServices.GetService<IHostingEnvironment>();
    //        appBuilder.Run(async context => {
    //            var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
    //            var exception = errorFeature.Error;

    //            var errorId = Guid.NewGuid();
    //            var exceptionDetail = environment.IsProduction()
    //                ? "An error occured while processing your request."
    //                : exception.ToString();
    //            var problemDetails = new ProblemDetails
    //            {
    //                Instance = $"urn:oncoshot.com:error:{errorId}"
    //            };

    //            // handle an issue when a CancellationToken is triggered after aborting an ajax request
    //            if (exception is OperationCanceledException)
    //            {
    //                // return non-standart HTTP code 499. 
    //                problemDetails.Status = ClosedByClientHttpCode;
    //                problemDetails.Detail = "Connection was closed by a client";
    //                logger.LogInformation($"AbortedRequestId:{errorId}. Connection was closed by a client.");
    //            }
    //            // handle low-server-level issues with HTTP request, e.g. too large headers or too large payload
    //            else if (exception is BadHttpRequestException badHttpRequestException)
    //            {
    //                problemDetails.Title = "Invalid request";
    //                problemDetails.Status = (int)typeof(BadHttpRequestException).GetProperty("StatusCode",
    //                    BindingFlags.NonPublic | BindingFlags.Instance).GetValue(badHttpRequestException);
    //                problemDetails.Detail = badHttpRequestException.Message;
    //            }
    //            // handle model validation issues
    //            //else if (exception is ModelValidationException validationException)
    //            //{
    //            //    var errors = new Dictionary<string, string[]>();
    //            //    foreach (var error in validationException.ValidationErrors)
    //            //    {
    //            //        if (error.MemberNames?.Any() == true)
    //            //        {
    //            //            foreach (var fieldName in error.MemberNames)
    //            //            {
    //            //                if (!errors.ContainsKey(fieldName))
    //            //                    errors.Add(fieldName, new string[] { error.ErrorMessage });
    //            //                else
    //            //                    errors[fieldName] = errors[fieldName].Concat(new string[] { error.ErrorMessage }).ToArray();
    //            //            }
    //            //        }
    //            //        else
    //            //        {
    //            //            if (!errors.ContainsKey(string.Empty))
    //            //                errors.Add(string.Empty, new string[] { error.ErrorMessage });
    //            //            else
    //            //                errors[string.Empty] = errors[string.Empty].Concat(new string[] { error.ErrorMessage }).ToArray();
    //            //        }
    //            //    }

    //            //    problemDetails = new ValidationProblemDetails(errors)
    //            //    {
    //            //        Status = (int)HttpStatusCode.UnprocessableEntity,
    //            //        Title = "Request Validation Error",
    //            //        Instance = $"urn:oncoshot.com:badrequest:{errorId}",
    //            //        Detail = "See ValidationErrors for details"
    //            //    };
    //            //}
    //            else
    //            {
    //                problemDetails.Title = "An unexpected error occurred!";
    //                problemDetails.Status = 500;
    //                problemDetails.Detail = exceptionDetail;
    //            }

    //            if (problemDetails.Status.Value == (int)HttpStatusCode.InternalServerError)
    //                logger.LogError($"ErrorId:{errorId}. Exception:{exception.ToString()}");
    //            else
    //            {
    //                var strErrors = Newtonsoft.Json.JsonConvert.SerializeObject(problemDetails);
    //                logger.LogInformation($"BadRequestId:{errorId}. Exception:{strErrors}");
    //            }

    //            context.Response.StatusCode = problemDetails.Status.Value;
    //            await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(problemDetails));
    //        });
    //    }
    //}
}