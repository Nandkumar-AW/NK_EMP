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
    public class ClientMasterBAL
    {
        public List<Emp_ClientMasterDetailsModels> GetAllClient(ClientContext clientContext)
        {
            List<Emp_ClientMasterDetailsModels> emp_ClientMasterDetailsModels = new List<Emp_ClientMasterDetailsModels>();

            JArray jArray = RESTGet(clientContext, null);

            foreach (JObject j in jArray)
            {
                emp_ClientMasterDetailsModels.Add(new Emp_ClientMasterDetailsModels
                {
                    ID = Convert.ToInt32(j["ID"]),
                    ClientName = j["ClientName"].ToString(),
                    ClientAddress = j["ClientAddress"].ToString(),
                    ClientContact=j["ClientContact"].ToString(),
                    ClientMailID=j["ClientMailID"].ToString(),
                    ClientDesignation=j["ClientDesignation"].ToString(),
                    ClientGSTNO=j["ClientGSTNO"].ToString(),
                    ClientPanCardNo=j["ClientPanCardNo"].ToString(),
                    ClientState=j["ClientState"].ToString(),
                    ClientCity=j["ClientCity"].ToString(),
                    ClientRemark=j["ClientRemark"].ToString(),
                    ClientCountry=j["ClientCountry"].ToString()
                }); 
            }


            return emp_ClientMasterDetailsModels;

        }
        public List<Emp_ClientMasterDetailsModels> GetClientById(ClientContext clientContext,string id)
        {
            List<Emp_ClientMasterDetailsModels> emp_ClientMasterDetailsModels = new List<Emp_ClientMasterDetailsModels>();
            var filter = "ID eq " + id;
            JArray jArray = RESTGet(clientContext, filter);

            foreach (JObject j in jArray)
            {
                emp_ClientMasterDetailsModels.Add(new Emp_ClientMasterDetailsModels
                {
                    ID = Convert.ToInt32(j["ID"]),
                    ClientName = j["ClientName"].ToString(),
                    ClientAddress = j["ClientAddress"].ToString(),
                    ClientContact = j["ClientContact"].ToString(),
                    ClientMailID = j["ClientMailID"].ToString(),
                    ClientDesignation = j["ClientDesignation"].ToString(),
                    ClientGSTNO = j["ClientGSTNO"].ToString(),
                    ClientPanCardNo = j["ClientPanCardNo"].ToString(),
                    ClientState = j["ClientState"].ToString(),
                    ClientCity = j["ClientCity"].ToString(),
                    ClientRemark = j["ClientRemark"].ToString(),
                    ClientCountry = Convert.ToString(j["ClientCountry"]["CountryName"]).Trim(),
                });
            }


            return emp_ClientMasterDetailsModels;

        }
        public string SaveClient(ClientContext clientContext, string ItemData)
        {

            string response = RESTSave(clientContext, ItemData);

            return response;
        }

        private JArray RESTGet(ClientContext clientContext, string filter)
        {
            RestService restService = new RestService();
            JArray jArray = new JArray();
            RESTOption rESTOption = new RESTOption();

            rESTOption.filter = filter;
            rESTOption.select = "ID,ClientName,ClientAddress,ClientContact,ClientMailID,ClientDesignation,ClientGSTNO,ClientPanCardNo,ClientState,ClientCity,ClientRemark,ClientCountry/CountryName";
            rESTOption.expand = "ClientCountry";
            rESTOption.top = "5000";
            jArray = restService.GetAllItemFromList(clientContext, "Emp_ClientMasterDetails", rESTOption);

            return jArray;
        }

        private string RESTSave(ClientContext clientContext, string ItemData)
        {
            RestService restService = new RestService();

            return restService.SaveItem(clientContext, "Emp_ClientMasterDetails", ItemData);
        }
    }
}