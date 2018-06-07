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
        CityModel cm = new CityModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateCity()
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

        [HttpPost]
        public JsonResult AddCity(string cname,int sid)
        {
            return Json(cm.AddCity(cname,sid), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCities()
        {
            return Json(cm.GetCities(), JsonRequestBehavior.AllowGet);
        }


    }
}