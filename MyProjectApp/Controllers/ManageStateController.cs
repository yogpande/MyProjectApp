using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProjectApp.Models;

namespace MyProjectApp.Controllers
{
    public class ManageStateController : Controller
    {
        StateModel sm = new StateModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddState(string sname)
        {
            return Json(sm.AddNewState(sname), JsonRequestBehavior.AllowGet);
        }
    }
}