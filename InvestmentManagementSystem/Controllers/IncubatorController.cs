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
    }
}