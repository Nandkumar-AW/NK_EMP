﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NK_EMPWeb.Models.EmployeeManagement
{
    public class Emp_GovernmentDocumentsModels
    {
        public int ID { get; set; }
        public string PANNumber { get; set; }
        public string PassportNumber { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string AadhaarCardNumber { get; set; }
        public string EmpCode { get; set; }
    }
}