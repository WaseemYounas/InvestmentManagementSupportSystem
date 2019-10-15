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
    public class AdminController : Controller
    {
        // GET: Admin
        #region Incubator
        public ActionResult AddIncubator(string msg)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.msg = msg;
            return View();
        }
        [HttpPost]
        public ActionResult postIncubator(User obj)
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
            obj.path = filepath;
            obj.firstLogin = 1;
            obj.createdAt = DateTime.Now;
            bool temp = new UserBL().AddUser(obj);
            if (!temp)
            {
                return RedirectToAction("AddIncubator", "Admin",new { msg="There is an error while creating incubator."});
            }
            return RedirectToAction("ListOfIncubator", "Admin");
        }

        public ActionResult ListOfIncubator()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            List<User> list = new UserBL().getUserList().Where(x=>x.roleId==3).ToList();
            return View(list);
        }
        public ActionResult ListOfEntrepreneurs()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            List<User> list = new UserBL().getUserList().Where(x => x.roleId == 2).ToList();
            return View(list);
        }
        public ActionResult ListOfInvestors()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            List<User> list = new UserBL().getUserList().Where(x => x.roleId == 4).ToList();
            return View(list);
        }
        public ActionResult updateIncubator(int Id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            User obj = new UserBL().getUserList().Where(x => x.userId == Id).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public ActionResult postUpdateIncubator(User obj)
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
            obj.path = filepath;
            obj.firstLogin = 1;
            obj.createdAt = DateTime.Now;
            bool temp = new UserBL().UpdateUser(obj);
            return RedirectToAction("ListOfIncubator", "Admin");
        }
        public ActionResult deleteIncubator(int Id,string role="")
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            //int id = Convert.ToInt32(Session["userId"]);
            User obj = new UserBL().getUserById(Id);
            bool temp = new UserBL().DeleteUser(obj);
            if (role=="incubator")
            {
                return RedirectToAction("ListOfIncubator", "Admin");
            }
            else if (role=="entrepreneur")
            {
                return RedirectToAction("ListOfEntrepreneurs", "Admin");
            }
            return RedirectToAction("ListOfInvestors", "Admin");
        }
        public ActionResult blockUser(int Id, string role = "")
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            //int id = Convert.ToInt32(Session["userId"]);
            User obj = new UserBL().getUserById(Id);
            User _user = new User() {
                userId=obj.userId,
                email=obj.email,
                address=obj.address,
                city=obj.city,
                country=obj.country,
                isActive=-1,
                createdAt=obj.createdAt,
                firstLogin=obj.firstLogin,
                gender=obj.gender,
                name=obj.name,
                password=obj.password,
                path=obj.path,
                phone=obj.phone,
                roleId=obj.roleId
            };
            bool temp = new UserBL().UpdateUser(_user);
            if (role == "incubator")
            {
                return RedirectToAction("ListOfIncubator", "Admin");
            }
            else if (role == "entrepreneur")
            {
                return RedirectToAction("ListOfEntrepreneurs", "Admin");
            }
            return RedirectToAction("ListOfInvestors", "Admin");
        }
        #endregion
    }
}