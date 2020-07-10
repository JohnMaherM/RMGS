using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SP_ASPNET_1.Controllers
{
    public class BaseController : Controller
    {
        public bool IsLoginedIn()
        {
            if (System.Web.HttpContext.Current.User != null)
                return true;
            else
                return false;
        }
      
        public string UserID()
        {
            
          return System.Web.HttpContext.Current.User.Identity.GetUserId();
        }
    }
}