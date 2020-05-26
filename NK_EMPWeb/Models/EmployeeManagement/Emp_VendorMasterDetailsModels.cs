using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NK_EMPWeb.Models.EmployeeManagement
{
    public class Emp_VendorMasterDetailsModels
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string LandlineNo { get; set; }
        public string EmailID { get; set; }
        public string Designation { get; set; }
        public string City { get; set; }
        public string GstNo { get; set; }
        public string PanCardNo { get; set; }
        public string Remark { get; set; }
        public string States { get; set; }
    }
}