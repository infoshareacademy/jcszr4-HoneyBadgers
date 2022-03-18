using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using HoneyBadgers.Entity.Context;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace HoneyBadgers.Logic.Services
{
    public class UserActivityService : IActionFilter
    {
        private readonly IReportService _reportService;

        public UserActivityService(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            string actionArguments = null;

            foreach (var argument in context.ActionArguments)
            {
                actionArguments += JsonConvert.SerializeObject(argument.Value);
            }

            var httpRequestMethod = context.HttpContext.Request.HttpContext.Request.Method;

            var ipAddress = context.HttpContext.Connection.LocalIpAddress;
            var port = context.HttpContext.Connection.LocalPort;
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var url = $"{ipAddress}:{port}/{controllerName}/{actionName}";

            var userName = context.HttpContext.User.Identity?.Name;

            if (userName.IsNullOrEmpty())
            {
                userName = "Guest";
            }

            var userIpAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();

            var userActivity = new UserActivity()
            {
                HTTPMethod = httpRequestMethod,
                ActionArguments = actionArguments,
                Url = url,
                UserName = userName,
                UserIpAddress = userIpAddress
            };

            await _reportService.AddUserActivity(userActivity);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Wymagane ze względu na implementację IActionFilter
        }
    }
}
