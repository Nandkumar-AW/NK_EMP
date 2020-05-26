using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NK_EMPWeb.Models.EmployeeManagement
{
    public class Emp_VisaInformationModels
    {
        public int ID { get; set; }
        public string VisaType { get; set; }
        public string ValidUntil { get; set; }
        public string Country { get; set; }
        public string EmpCode { get; set; }
    }
}