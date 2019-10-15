using InvestmentManagementSystem.BL;
using InvestmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestmentManagementSystem.Controllers
{
    public class IdeaController : Controller
    {
        // GET: Idea
        public ActionResult AddIdea()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var incubators = new UserBL().getUserList().Where(x=>x.roleId==3).ToList();
            return View(incubators);
        }
        [HttpPost]
        public ActionResult postIdea(Idea obj)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            int id = Convert.ToInt16(Session["userId"]);
            obj.userId = id;
            obj.createdAt = DateTime.Now;
            bool temp = new UserBL().AddIdea(obj);
            return RedirectToAction("ListOfIdeas");
        }
        public ActionResult ListOfIdeas()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            int id = Convert.ToInt16(Session["userId"]);
            var list = new UserBL().getIdeaList().Where(x=>x.userId==id).ToList();
            return View(list);
        }
        public ActionResult updateIdea(int Id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var idea = new UserBL().getIdeaById(Id);
            ViewBag.incubators = new UserBL().getUserList().Where(x=>x.roleId==3);
            return View(idea);
        }
        [HttpPost]
        public ActionResult postUpdateIdea(Idea obj)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var idea = new UserBL().UpdateIdea(obj);
            return RedirectToAction("ListOfIdeas");
        }
        public ActionResult deleteIdea(int Id)
        {
            //Idea idea = new UserBL().getIdeaById(Id);
            bool temp = new UserBL().DeleteIdea(Id);
            return RedirectToAction("ListOfIdeas");
        }
        public ActionResult showIdeas()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var list = new UserBL().getIdeaList();
            return View(list);
        }
        public ActionResult checkDetails(int ideaId)
        {
            Idea obj = new UserBL().getIdeaById(ideaId);
            ViewBag.ideaList = new UserBL().getIdeaList().Where(x=>x.userId==obj.userId).ToList();
            return View(obj);
        }
    }
}