﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NK_EMPWeb.Models.EmployeeManagement
{
    public class Emp_FamilyDetailsModels
    {
        public int ID { get; set; }
        public string PersonName { get; set; }
        public string Relationship { get; set; }
        public string BirthDate { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string MediclaimCovered { get; set; }
        public string BirthPlace { get; set; }
        public string ContactNumber { get; set; }
        public string EmpCode { get; set; }
    }
}