using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechInTheBurbs.Core;

namespace TechInTheBurbs.Web.Controllers
{
    public class NexusController : Controller
    {
        // GET: Nexus
        public ActionResult Index()
        {
            List<Models.VMListModel> vModel = new List<Models.VMListModel>();
            foreach (var kaark in AzureBridge.RetrieveVMList())
            {
                Models.VMListModel model = new Models.VMListModel();
                model.Name = kaark.Name;
                model.Status = kaark.Status;
                model.StatusCode = kaark.StatusCode;
                vModel.Add(model);
            }

            return View(vModel);
        }

        public ActionResult Start(string name)
        {
            AzureBridge.StartVM(name);

            return RedirectToAction("Index");
        }

        public ActionResult Stop(string name)
        {
            AzureBridge.StopVM(name);

            return RedirectToAction("Index");
        }

        public ActionResult Restart(string name)
        {
            AzureBridge.RestartVM(name);

            return RedirectToAction("Index");
        }
    }
}