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

    }

    public class CityModel
    {
        public int cid { get; set; }
        public string cname { get; set; }
        public StateModel state { get; set; }
    }
}