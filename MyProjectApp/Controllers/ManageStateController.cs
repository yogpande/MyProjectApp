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

        [HttpGet]
        public JsonResult GetStates()
        {
            return Json(sm.GetStates(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetStatesByPageIndex(int pageIndex)
        {
            sm.PageIndex = pageIndex;
            sm.PageSize = 10;
            sm.RecordCount = sm.GetStates().Count;

            int startIndex = (pageIndex - 1) * sm.PageSize;

            var data = sm.GetStates().OrderBy(a => a.sid).Skip(startIndex).Take(sm.PageSize).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}