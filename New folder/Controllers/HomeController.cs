using MvcDemo.Models;
using MvcDemo.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Register(RegisterData user)
        //{
        //    //return RedirectToAction("About");
        //    Response.StatusCode = 200;
        //    return Json(new { success = true, message = "Registration successful!" });
        //}
        [HttpPost]
        public ActionResult Register(RegisterData user)
        {
            // Normally you’d save user to DB here...

            // Generate JWT token
            var token = JwtManager.GenerateToken(user.username);

            return Json(new { success = true, message = "Registration successful!", token = token });
        }

        [HttpGet]
        public ActionResult ProtectedData()
        {
            // Check Authorization Header
            var authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length);
                var principal = JwtManager.GetPrincipal(token);

                if (principal != null)
                {
                    var username = principal.Identity.Name;
                    return Json(new { success = true, message = $"Hello {username}, this is protected data!" }, JsonRequestBehavior.AllowGet);
                }
            }

            Response.StatusCode = 401;
            return Json(new { success = false, message = "Unauthorized" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [JwtAuthorize] // 👈 Protected by JWT
        public ActionResult ProtectedData2()
        {
            var username = User.Identity.Name;
            return Json(new { success = true, message = $"Welcome {username}!" }, JsonRequestBehavior.AllowGet);
        }
    }

}