using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProjectApp.Models;

namespace MyProjectApp.Controllers
{
    public class ManageUserController : Controller
    {
        StateModel sm = new StateModel();
        CityModel cm = new CityModel();
        
        public ActionResult Create()
        {
            ViewBag.states = sm.GetStates();
            return View();
        }

        [HttpGet]
        public JsonResult GetCityByState(int id)
        {
            return Json(cm.GetCityByState(id), JsonRequestBehavior.AllowGet);
        }
    }
}