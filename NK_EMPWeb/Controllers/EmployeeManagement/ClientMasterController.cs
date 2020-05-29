using NK_EMPWeb.BAL.EmployeeManagement;
using NK_EMPWeb.Models.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NK_EMPWeb.Controllers.EmployeeManagement
{
    public class ClientMasterController : Controller
    {
        //Models References
        List<Emp_CountryModels> emp_Countries = new List<Emp_CountryModels>();
        List<Emp_ClientMasterDetailsModels> emp_ClientMasterDetails = new List<Emp_ClientMasterDetailsModels>();
        //BAL References
        ClientMasterBAL clientMaster = new ClientMasterBAL();
        CountryMasterBAL country = new CountryMasterBAL();


        // GET: ClientMaster
        public ActionResult Index()
        {
            return View();
        }

        [SharePointContextFilter]
        public ActionResult ClientDashboard()
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                emp_ClientMasterDetails = clientMaster.GetAllClient(clientContext);
            }
            ViewBag.ClientList = emp_ClientMasterDetails;
            return View();
        }

        [SharePointContextFilter]
        public ActionResult ClientDetails()
        {
            
            string id = Request.Cookies["ID"].Value.ToString(); 
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                emp_ClientMasterDetails = clientMaster.GetClientById(clientContext, id);
            }
            return View(emp_ClientMasterDetails);
        }

        [HttpGet]
        public ActionResult CreateNewClient()
        {
            
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                emp_Countries = country.GetAllCountries(clientContext);
                IEnumerable<Emp_CountryModels> countryModels = country.GetAllCountries(clientContext);
                var listToClient = countryModels.Select(p => new { p.CountryName, p.ID }).ToList();
                var items = listToClient.Select(i => new SelectListItem { Text = i.CountryName, Value = i.ID.ToString() });
                ViewBag.country = items;
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewClient(Emp_ClientMasterDetailsModels _ClientMasterDetailsModels)
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
            if (!ModelState.IsValid)
            {
                using (var clientContext = spContext.CreateUserClientContextForSPHost())
                {

                    emp_Countries = country.GetAllCountries(clientContext);
                    IEnumerable<Emp_CountryModels> countryModels = country.GetAllCountries(clientContext);
                    var listToClient = countryModels.Select(p => new { p.CountryName, p.ID }).ToList();
                    var items = listToClient.Select(i => new SelectListItem { Text = i.CountryName, Value = i.ID.ToString() });
                    ViewBag.country = items;
                }
            }
            else
            { 
                //var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
                using (var clientContext = spContext.CreateUserClientContextForSPHost())
                {

                    string items = "'ClientName' : '" + _ClientMasterDetailsModels.ClientName + "'";
                    items += ",'ClientAddress' : '" + _ClientMasterDetailsModels.ClientAddress + "'";
                    items += ",'ClientContact' : " + _ClientMasterDetailsModels.ClientContact;
                    items += ",'ClientMailID' : '" + _ClientMasterDetailsModels.ClientMailID + "'";
                    items += ",'ClientDesignation' : '" + _ClientMasterDetailsModels.ClientDesignation + "'";
                    items += ",'ClientGSTNO' : '" + _ClientMasterDetailsModels.ClientGSTNO + "'";
                    items += ",'ClientPanCardNo' : '" + _ClientMasterDetailsModels.ClientPanCardNo + "'";
                    items += ",'ClientState' : '" + _ClientMasterDetailsModels.ClientState + "'";
                    items += ",'ClientCity' : '" + _ClientMasterDetailsModels.ClientCity + "'";
                    items += ",'ClientRemark' : '" + _ClientMasterDetailsModels.ClientRemark + "'";
                    items += ",'ClientCountryId' : " + _ClientMasterDetailsModels.ClientCountry;
                    clientMaster.SaveClient(clientContext, items);
                }
                string path = "?SPHostUrl=" + spContext.SPHostUrl.ToString();
                return Redirect("ClientDashboard" + path);
            }
            return View();
        }
        [SharePointContextFilter]
        [HttpGet]
        public ActionResult ClientEdit()
        {
            string id = Request.Cookies["ID"].Value.ToString();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                emp_ClientMasterDetails = clientMaster.GetClientById(clientContext, id.ToString());

                emp_Countries = country.GetAllCountries(clientContext);
                IEnumerable<Emp_CountryModels> countryModels = country.GetAllCountries(clientContext);
                var listToClient = countryModels.Select(p => new { p.CountryName, p.ID }).ToList();
                var items = listToClient.Select(i => new SelectListItem { Text = i.CountryName, Value = i.ID.ToString() });
                ViewBag.country = items;
            }
            if (emp_ClientMasterDetails == null)
            {
                return HttpNotFound();
            }
            var client = emp_ClientMasterDetails.Where(s => s.ID == Convert.ToInt32(id)).FirstOrDefault();
            return View(client);
        }


        [SharePointContextFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientEdit(Emp_ClientMasterDetailsModels _ClientMasterDetailsModels)
        {
            string ID = Request.Cookies["ID"].Value.ToString();
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
            if (!ModelState.IsValid)
            {
                using (var clientContext = spContext.CreateUserClientContextForSPHost())
                {
                    emp_ClientMasterDetails = clientMaster.GetClientById(clientContext, ID);

                    emp_Countries = country.GetAllCountries(clientContext);
                    IEnumerable<Emp_CountryModels> countryModels = country.GetAllCountries(clientContext);
                    var listToClient = countryModels.Select(p => new { p.CountryName, p.ID }).ToList();
                    var items = listToClient.Select(i => new SelectListItem { Text = i.CountryName, Value = i.ID.ToString() });
                    ViewBag.country = items;
                }
            }
            else
            {
                using (var clientContext = spContext.CreateUserClientContextForSPHost())
                {

                    string items = "'ClientName' : '" + _ClientMasterDetailsModels.ClientName + "'";
                    items += ",'ClientAddress' : '" + _ClientMasterDetailsModels.ClientAddress + "'";
                    items += ",'ClientContact' : " + _ClientMasterDetailsModels.ClientContact;
                    items += ",'ClientMailID' : '" + _ClientMasterDetailsModels.ClientMailID + "'";
                    items += ",'ClientDesignation' : '" + _ClientMasterDetailsModels.ClientDesignation + "'";
                    items += ",'ClientGSTNO' : '" + _ClientMasterDetailsModels.ClientGSTNO + "'";
                    items += ",'ClientPanCardNo' : '" + _ClientMasterDetailsModels.ClientPanCardNo + "'";
                    items += ",'ClientState' : '" + _ClientMasterDetailsModels.ClientState + "'";
                    items += ",'ClientCity' : '" + _ClientMasterDetailsModels.ClientCity + "'";
                    items += ",'ClientRemark' : '" + _ClientMasterDetailsModels.ClientRemark + "'";
                    items += ",'ClientCountryId' : " + _ClientMasterDetailsModels.ClientCountry;
                    clientMaster.UpdateClient(clientContext, items, ID);
                }
                string path = "?SPHostUrl="+ spContext.SPHostUrl.ToString();
                return Redirect("ClientDashboard" + path);
            }
            return View(_ClientMasterDetailsModels);
        }
    }
}