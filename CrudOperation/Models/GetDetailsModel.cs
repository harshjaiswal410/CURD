using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Models
{
    public class GetDetailsModel
    {
        public int EmpID { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Feedback { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
        public List<GetDetailsModel> EmpList { get; set; }
        public List<GetDetailsModel> StateList{ get; set; }


    }
}