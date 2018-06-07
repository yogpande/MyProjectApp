using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProjectApp.EF;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace MyProjectApp.Models
{
    public class StateModel
    {
        private DBEntities db = new DBEntities();

        public int sid { get; set; }
        public string sname { get; set; }
        

        public int AddNewState(string statename) //0 error , 1 success , 2 unique key/pk error
        {
            int status = 0;
            if (statename.Length > 0)
            {
                try
                {
                    tblState state = new tblState();
                    state.statename = statename;
                    db.tblStates.Add(state);
                    db.SaveChanges();
                    status = 1;
                }
                catch (Exception ex)
                {
                    var dbupdateException = ex as DbUpdateException;
                    var sqlException = dbupdateException.InnerException.InnerException as SqlException;
                   
                    if (sqlException.Number == 2627)
                    {
                        status = 2;
                    }
                    else
                    {
                        status = 0;
                    }
                }

                return status;
            }
            else
            {
                return status;
            }
        }

        public List<StateModel> GetStates()
        {
            List<StateModel> li = new List<StateModel>();

            foreach (var item in db.tblStates.ToList())
            {
                StateModel sm = new StateModel();
                sm.sid = item.stateid;
                sm.sname = item.statename;
                li.Add(sm);
            }

            return li;
        }

    }

    public class CityModel
    {

        DBEntities db = new DBEntities();


        public int cid { get; set; }
        public string cname { get; set; }
        public int stateid { get; set; }
        public string statename { get; set; }

        public int AddCity(string cityname,int stateid) //0 error , 1 success , 2 unique key/pk error
        {
            int status = 0;
            if (cityname.Length > 0 && stateid>0)
            {
                try
                {
                    tblCity city = new tblCity();
                    city.cityname = cityname;
                    city.stateid = stateid;
                    db.tblCities.Add(city);
                    db.SaveChanges();
                    status = 1;
                }
                catch (Exception ex)
                {
                    var dbupdateException = ex as DbUpdateException;
                    var sqlException = dbupdateException.InnerException.InnerException as SqlException;

                    if (sqlException.Number == 2627)
                    {
                        status = 2;
                    }
                    else
                    {
                        status = 0;
                    }
                }

                return status;
            }
            else
            {
                return status;
            }
        }

        public List<CityModel> GetCities()
        {
            List<CityModel> li = new List<CityModel>();

            var data = from a in db.tblCities join b in db.tblStates on a.stateid equals b.stateid select new {a.cityid,a.cityname,b.statename };
            foreach (var item in data)
            {
                CityModel cm = new CityModel();
                cm.cid = item.cityid;
                cm.cname = item.cityname;
                cm.statename = item.statename;
                li.Add(cm);
            }

            return li;
        }

        public List<CityModel> GetCityByState(int id)
        {
            List<CityModel> li = new List<CityModel>();

            foreach (var item in db.tblCities.Where(a => a.stateid == id).ToList())
            {
                CityModel cm = new CityModel();
                cm.cid = item.cityid;
                cm.cname = item.cityname;
                li.Add(cm);
            }

            return li;
        }
    }
}