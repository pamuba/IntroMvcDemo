﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.ActionFilters
{

    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }

    public class ProfileActionAttribute : FilterAttribute, IActionFilter
    {
        private Stopwatch timer;
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            timer.Stop();
            if (filterContext.Exception == null)
            {
                filterContext.HttpContext.Response.Write(string.Format("<div>Action method elapsed time: {0:F6}</div>", timer.Elapsed.TotalSeconds));
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }
    }




}

//private Stopwatch timer;
//public void OnActionExecuted(ActionExecutedContext filterContext)
//{
//    timer.Stop();
//    if (filterContext.Exception == null)
//    {
//        filterContext.HttpContext.Response.Write(string.Format("<div>Action method elapsed time: {0:F6}</div>", timer.Elapsed.TotalSeconds));
//    }
//}

//public void OnActionExecuting(ActionExecutingContext filterContext)
//{
//    timer = Stopwatch.StartNew();
//}
