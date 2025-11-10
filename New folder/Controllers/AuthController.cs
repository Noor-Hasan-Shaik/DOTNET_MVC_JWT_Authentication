using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using System.Web.Http;

namespace MvcDemo.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            ViewBag.Title = "Nxtwave Login";
            ViewBag.description = "Hello, THis is a Login Page.";
            return View();
        }

        public ActionResult LoginV2(LoginData loginData)
        {
    

            return Json(loginData);
        }
    }
}