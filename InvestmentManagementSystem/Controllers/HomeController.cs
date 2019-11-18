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
            List<EventDTO> events=new List<EventDTO>();
            int userId = Convert.ToInt32(Session["userId"]);
            List<Appointment> appList = new UserBL().getAppointmentList().Where(x=>x.senderId==userId).ToList();
            if (appList!=null)
            {
                foreach (var item in appList)
                {
                    EventDTO obj = new EventDTO() {
                        title = "Appointment with " + new UserBL().getIdeaById(item.ideaId).User.name,
                        description = "Your meeting point is " + item.address + " " + item.city + " " + item.country,
                        start = item.createdAt.ToString("yyyy-MM-dd"),
                        className = (item.createdAt - DateTime.Now).TotalMinutes > 0 ? "m-fc-event--light m-fc-event--solid-success" : "m-fc-event--light m-fc-event--solid-danger"
                };
                    events.Add(obj);
                }
            }
            ViewBag.events=events;
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
            Session["username"] = obj.name;
            Session["userId"] = obj.userId;
            Session["roleId"] = obj.roleId;
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
        protected override void OnException(ExceptionContext filterContext)
        {
            
        }
    }
}