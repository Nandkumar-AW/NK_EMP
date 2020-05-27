using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NK_EMPWeb.Models.EmployeeManagement
{
    public class Emp_ClientMasterDetailsModels
    {
        public int ID { get; set; }
        //[DisplayName="Client Name "]
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientContact { get; set; }
        public string ClientMailID { get; set; }
        public string ClientDesignation { get; set; }
        public string ClientGSTNO { get; set; }
        public string ClientPanCardNo { get; set; }
        public string ClientState { get; set; }
        public string ClientCity { get; set; }
        public string ClientRemark { get; set; }
        public string ClientCountry { get; set; }
    }
}