using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn_RD.Controllers
{
    public class TestController : Controller
    {
        public class ButtonNameActionAttribute : ActionNameSelectorAttribute
        {
            public override bool IsValidName(ControllerContext controllerContext, ﻿string actionName, MethodInfo methodInfo)
            {
                if (actionName.Equals(methodInfo.Name,
                        StringComparison.InvariantCultureIgnoreCase))
                    return true;

                var request = controllerContext.RequestContext.HttpContext.Request;
                return request[methodInfo.Name] != null;
            }
        }

        // GET: Test

        [ButtonNameAction]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ButtonNameAction]
        public ActionResult Index2(LinkedIn_RD.Services.Person model)
        {
            return View();
        }

        [HttpPost]
        [ButtonNameAction]
        public ActionResult Index1()
        {
            return View();
        }
    }
}