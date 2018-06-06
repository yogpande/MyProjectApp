using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProjectApp.Models
{
    public class UserModel
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string ugender { get; set; }
        public string uemail { get; set; }
        public string upass { get; set; }
        public Nullable<System.DateTime> udob { get; set; }
        public string uhby { get; set; }
        public Nullable<int> sid { get; set; }
        public Nullable<int> cid { get; set; }
        public string uphoto { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> regDate { get; set; }

        public virtual CityModel City { get; set; }
        public virtual StateModel State { get; set; }
    }
}