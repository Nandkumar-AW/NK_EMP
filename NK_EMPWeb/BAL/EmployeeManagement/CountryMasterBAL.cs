using Microsoft.SharePoint.Client;
using Newtonsoft.Json.Linq;
using NK_EMPWeb.DAL;
using NK_EMPWeb.Models;
using NK_EMPWeb.Models.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NK_EMPWeb.BAL.EmployeeManagement
{
    public class CountryMasterBAL
    {
        public List<Emp_CountryModels> GetAllCountries(ClientContext clientContext)
        {
            List<Emp_CountryModels> emp_Countries = new List<Emp_CountryModels>();

            JArray jArray = RESTGet(clientContext, null);

            foreach (JObject j in jArray)
            {
                emp_Countries.Add(new Emp_CountryModels
                {
                    ID = Convert.ToInt32(j["ID"]),
                    CountryName = j["CountryName"].ToString(),
                });
            }


            return emp_Countries;

        }

        private JArray RESTGet(ClientContext clientContext, string filter)
        {
            RestService restService = new RestService();
            JArray jArray = new JArray();
            RESTOption rESTOption = new RESTOption();

            rESTOption.filter = filter;
            rESTOption.select = "ID,CountryName";
            rESTOption.top = "5000";
            jArray = restService.GetAllItemFromList(clientContext, "Emp_Country", rESTOption);

            return jArray;
        }
    }
}