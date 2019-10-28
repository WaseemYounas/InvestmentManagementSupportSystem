using InvestmentManagementSystem.BL;
using InvestmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestmentManagementSystem.Controllers
{
    public class IncubatorController : Controller
    {
        // GET: Incubator
        public JsonResult sendRequest(Request obj)
        {
            obj.createdAt = DateTime.Now;
            Idea _idea = new UserBL().getIdeaById(obj.ideaId);
            obj.incubatorId = _idea.incubatorId;
            bool temp = new UserBL().AddRequest(obj);
           
            return Json(temp, JsonRequestBehavior.AllowGet);
        }
        public ActionResult listOfRequests()
        {
            int incId = Convert.ToInt16(Session["userId"]);
            List<Request> list = new UserBL().getRequestList().Where(x=>x.incubatorId==incId).ToList();
            return View(list);
        }
        public ActionResult Requestdetails(int ideaId,int senderId)
        {
            Idea obj = new UserBL().getIdeaById(ideaId);
            ViewBag.sender = new UserBL().getUserById(senderId);
            return View(obj);
        }
        public ActionResult CreateAppointment(int ideaId=0,int senderId=0,string msg="")
        {
            ViewBag.ideaId = ideaId;
            ViewBag.senderId = senderId;
            return View();
        }
        [HttpPost]
        public int PostAppointment(Appointment apt)
        {
            Appointment obj = new UserBL().getAppointmentList().Where(x => x.ideaId == apt.ideaId && x.senderId == apt.senderId).FirstOrDefault();
            if (obj==null)
            {
                apt.createdAt = DateTime.Now;
new UserBL().AddAppointment(apt);
                return 1;
            }
            else 
            {
                return -1;
            }
        }
        public ActionResult listOfAppointments()
        {
            int incId = Convert.ToInt16(Session["userId"]);
            List<Appointment> list = new UserBL().getAppointmentList().Where(x => x.Idea.incubatorId == incId).ToList();
            return View(list);
        }
    }
}