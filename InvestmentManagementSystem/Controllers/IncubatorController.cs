using InvestmentManagementSystem.BL;
using InvestmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            Request exist = new UserBL().getRequestList().Where(x => x.ideaId == obj.ideaId && x.incubatorId == obj.incubatorId && x.senderId == obj.senderId).FirstOrDefault();
            bool temp = false;
            if (exist == null)
            {
                temp = new UserBL().AddRequest(obj);
            }
            return Json(temp, JsonRequestBehavior.AllowGet);
        }
        public ActionResult listOfRequests()
        {
            int incId = Convert.ToInt16(Session["userId"]);
            List<Request> list = new UserBL().getRequestList().Where(x => x.incubatorId == incId).ToList();
            return View(list);
        }
        public ActionResult Requestdetails(int ideaId, int senderId)
        {
            Idea obj = new UserBL().getIdeaById(ideaId);
            ViewBag.sender = new UserBL().getUserById(senderId);
            return View(obj);
        }
        public ActionResult CreateAppointment(int ideaId = 0, int senderId = 0, string msg = "")
        {
            ViewBag.ideaId = ideaId;
            ViewBag.senderId = senderId;
            return View();
        }
        [HttpPost]
        public int PostAppointment(Appointment apt)
        {
            try
            {
                Appointment obj = new UserBL().getAppointmentList().Where(x => x.ideaId == apt.ideaId && x.senderId == apt.senderId).FirstOrDefault();
                if (obj == null)
                {
                    apt.createdAt = DateTime.Now;
                    bool temp = new UserBL().AddAppointment(apt);
                    if (temp)
                    {
                        Appointment _apt = new UserBL().getAppointmentById(apt.appId);
                        User usr = new UserBL().getUserById(_apt.senderId);
                        User inc = new UserBL().getUserById(_apt.senderId);
                        string text = "<p><b>Dear " + usr.name + ",<b></p><br><p>Your appointment has been created successfully with " + _apt.Idea.User.name + " and incubator is " + inc.name + ".</p><br><p><b>Venue:</b></p><br><p>Your meeting point is " + _apt.address + " " + _apt.city + " " + _apt.country + " at " + _apt.appDate.ToShortDateString() + ".</p><br><p>Thank you.</p>";
                        //Sending email to investor
                        sendEmailAsync(usr.email, inc.email, text);
                        //Sending email to entrepreneur
                        text = "<p><b>Dear " + _apt.Idea.User.name + ",<b></p><br><p>Your appointment has been created successfully with " + usr.name + " and incubator is " + inc.name + ".</p><br><p><b>Venue:</b></p><br><p>Your meeting point is " + _apt.address + " " + _apt.city + " " + _apt.country + " at " + _apt.appDate.ToShortDateString() + ".</p><br><p>Thank you.</p>";

                        sendEmailAsync(_apt.Idea.User.email, inc.email, text);
                    }
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch(Exception ex)
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
        public void sendEmailAsync(string to,string from,string text)
        {
            var body = text;
            var message = new MailMessage();
            message.To.Add(new MailAddress(to));  // replace with valid value 
            message.From = new MailAddress(from);  // replace with valid value
            message.Subject = "Appointment Notice";
            message.Body = string.Format(body);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "aldrichdeveloper786@gmail.com",  // replace with valid value
                    Password = "aldrich123"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}