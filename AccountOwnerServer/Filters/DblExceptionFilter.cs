using System;
using System.Diagnostics;
using AccountOwnerServer.Data;
using AccountOwnerServer.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AccountOwnerServer.Filters
{
    public class DblExceptionFilter : ExceptionFilterAttribute
    {
        private readonly LogDbContext _context;
        public DblExceptionFilter(LogDbContext context)
        {
            _context = context;
        }

        public override void OnException(ExceptionContext context)
        {
            LogEntry log = new LogEntry
            {
                TimeStamp = DateTime.UtcNow,
                ActionDescriptor = context.ActionDescriptor.DisplayName,
                IpAddress = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                Message = context.Exception.Message,
                RequestId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier,
                RequestPath = context.HttpContext.Request.Path,
                Source = context.Exception.Source,
                StackTrace = context.Exception.StackTrace,
                Type = context.Exception.GetType().ToString(),
                User = context.HttpContext.User.Identity.Name
            };
            _context.LogEntries.Add(log);
            _context.SaveChanges();
        }
    }
}