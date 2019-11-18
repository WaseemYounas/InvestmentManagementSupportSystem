using InvestmentManagementSystem.BL;
using InvestmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InvestmentManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login(string err)
        {
            ViewBag.error = err;
            List<Role> roles = new UserBL().getRoleList();
            return View(roles);
        }
        [HttpPost]
        public JsonResult postLogin(string email, string password)
        {
            User obj = new UserBL().getUserList().Where(x => x.email ==email && x.password == password).FirstOrDefault();

            if (obj!=null)
            {
                Session["userId"] = obj.userId;
                Session["username"] = obj.name;
                Session["roleId"] = obj.roleId;
                Session["email"] = obj.email;
                Session["path"] = obj.path;
                if (obj.firstLogin == 1)
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(-1, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(0, JsonRequestBehavior.AllowGet); 
        }

        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();
        //    Session.Abandon(); // it will clear the session at the end of request
        //    return RedirectToAction("Index", "Home");
        //}

        //public ActionResult ChangePassword(string err = "")
        //{
        //    if (sessiondto.getName() == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.err = err;
        //        return View();
        //    }
        //}

        //[HttpPost]
        //public ActionResult ChangePassword(string OldPassword, string NewPassword, string ConfirmPassword)
        //{
        //    if (sessiondto.getName() == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        User u = new UserBL().getUserById(sessiondto.getId());

        //        if (u.Password == OldPassword)
        //        {
        //            if (NewPassword == ConfirmPassword)
        //            {
        //                User user = new Models.User()
        //                {
        //                    Id = u.Id,
        //                    FirstName = u.FirstName,
        //                    LabourCategoryId = u.LabourCategoryId,
        //                    LastName = u.LastName,
        //                    Phone = u.Phone,
        //                    Email = u.Email,
        //                    Password = NewPassword,
        //                    Is_Authorize = u.Is_Authorize,
        //                    Role = u.Role,
        //                    User_Id = u.User_Id,
        //                    PhoneMail = u.PhoneMail
        //                };

        //                new UserBL().UpdateUser(user);

        //                return RedirectToAction("ChangePassword", "Auth", new { err = "Password updated successfully." });

        //            }
        //            else
        //            {
        //                return RedirectToAction("ChangePassword", "Auth", new { err = "New password and confirm password doesn't match." });
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("ChangePassword", "Auth", new { err = "You have entered wrong old password." });

        //        }
        //    }
        //}
        public ActionResult signUp(string error)
        {
            ViewBag.error = error;
            
            return View();
        }
        [HttpPost]
        public JsonResult postSignUp(User obj)
        {
            User _emailVerify = new UserBL().getUserList().Where(x => x.email == obj.email).FirstOrDefault();
            if (_emailVerify!=null)
            {
                return Json("emailExist");
            }
            obj.createdAt = DateTime.Now;
            obj.roleId = null;
            bool temp = new UserBL().AddUser(obj);
            if (temp)
            {
                Session["userId"] = obj.userId;
                Session["username"] = obj.name;
                Session["roleId"] = obj.roleId;
                return Json(true);
            }

            return Json(false);
        }
        public ActionResult Logout() {
            Session.Abandon();
            Session["userId"] = "";
            Session["username"] = "";
            Session["roleId"] ="";
            return RedirectToAction("Login","Auth");
        }
    }
}