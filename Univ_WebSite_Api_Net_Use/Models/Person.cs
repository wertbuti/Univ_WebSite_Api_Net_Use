using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Univ_WebSite_Api_Net_Use.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public DateTime BirthDate { get; set; }


        public bool Sex { get; set; }

        public string Picture { get; set; }
    }
}