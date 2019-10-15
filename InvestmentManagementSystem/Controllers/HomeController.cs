using InvestmentManagementSystem.BL;
using InvestmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestmentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if (Session["roleId"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        public ActionResult createProfile()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.roles = new UserBL().getRoleList();
            int userId = Convert.ToInt32(Session["userId"]);
            User user = new UserBL().getUserById(userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult postProfile(User obj)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            string filepath = "";
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/ProfilePictures/"), fileName);
                    file.SaveAs(path);
                    filepath = "~/ProfilePictures/" + fileName;
                }
            }
            obj.createdAt = DateTime.Now;
            obj.path = filepath;
            obj.firstLogin = 1;
            bool temp = new UserBL().UpdateUser(obj);
            return RedirectToAction("Index","Home");
        }

        public ActionResult updatUserProfile()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            int id = Convert.ToInt32(Session["userId"]);
            User _user = new UserBL().getUserById(id);
            return View(_user);
        }
        
    }
}