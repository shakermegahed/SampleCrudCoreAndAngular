using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Training.Domain.Enums;
using Training.Domain.ViewModel;
using Training.DTO.Localization;
using Training.Service.Interface;

namespace Training.Api.Filters
{
    public class SetLanguage : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
                var ThisLang = Enum.Parse(typeof(Lang), context.HttpContext.Request.Headers["Lang"].FirstOrDefault());

                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
  
        }
    }
}
