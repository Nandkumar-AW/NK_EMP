using NK_EMPWeb.BAL.EmployeeManagement;
using NK_EMPWeb.Models.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NK_EMPWeb.Controllers.EmployeeManagement
{
    public class ClientMasterController : Controller
    {
        // GET: ClientMaster
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ClientDashboard()
        {
            List<Emp_ClientMasterDetailsModels> emp_ClientMasterDetails = new List<Emp_ClientMasterDetailsModels>();
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                ClientMasterBAL clientMaster = new ClientMasterBAL();

                emp_ClientMasterDetails = clientMaster.GetAllClient(clientContext);

            }
            ViewBag.ClientList = emp_ClientMasterDetails;
            return View();
        }

        public ActionResult ClientDetails(int? id)
        {
            int ID = Convert.ToInt32(id);
            List<Emp_ClientMasterDetailsModels> emp_ClientMasterDetails = new List<Emp_ClientMasterDetailsModels>();
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                ClientMasterBAL clientMaster = new ClientMasterBAL();

                emp_ClientMasterDetails = clientMaster.GetClientById(clientContext, id.ToString());

            }
            return View(emp_ClientMasterDetails);
        }

        [HttpGet]
        public ActionResult CreateNewClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNewClient(Emp_ClientMasterDetailsModels _ClientMasterDetailsModels)
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                ClientMasterBAL clientMaster = new ClientMasterBAL();
                string items = "'ClientName':" + _ClientMasterDetailsModels.ClientName;
                       //items += ",'ClientAddress':" + _ClientMasterDetailsModels.ClientAddress;
                       //items += ",'ClientContact':" + _ClientMasterDetailsModels.ClientContact;
                       //items += ",'ClientMailID':" + _ClientMasterDetailsModels.ClientMailID;
                       //items += ",'ClientDesignation':" + _ClientMasterDetailsModels.ClientDesignation;
                       //items += ",'ClientGSTNO':" + _ClientMasterDetailsModels.ClientGSTNO;
                       //items += ",'ClientPanCardNo':" + _ClientMasterDetailsModels.ClientPanCardNo;
                       //items += ",'ClientState':" + _ClientMasterDetailsModels.ClientState;
                       //items += ",'ClientCity':" + _ClientMasterDetailsModels.ClientCity;
                       //items += ",'ClientRemark':" + _ClientMasterDetailsModels.ClientRemark;
                //items += ",'ClientCountry':" + _ClientMasterDetailsModels.ClientCountry;
                clientMaster.SaveClient(clientContext, items);
            }
            return View();
        }
    }
}