using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudOperation.Models
{
    public class EmployeeDetailsModel
    {
        public int EmpID { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Feedback { get; set; }
        public List<GetDetailsModel> EmpList { get; set; }   

    }
}