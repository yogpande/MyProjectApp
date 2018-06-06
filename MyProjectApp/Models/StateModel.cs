using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProjectApp.EF;

namespace MyProjectApp.Models
{
    public class StateModel
    {
        private DBEntities db = new DBEntities();

        public int sid { get; set; }
        public string sname { get; set; }

        public bool AddNewState(string statename)
        {
            bool status = false;
            if (statename.Length>0)
            {
                try
                {
                    tblState state = new tblState();
                    state.statename = statename;
                    db.tblStates.Add(state);
                    db.SaveChanges();
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }

                return status;
            }
            else
            {
                return status;
            }
        }

    }

    public class CityModel
    {
        public int cid { get; set; }
        public string cname { get; set; }
        public StateModel state { get; set; }
    }
}