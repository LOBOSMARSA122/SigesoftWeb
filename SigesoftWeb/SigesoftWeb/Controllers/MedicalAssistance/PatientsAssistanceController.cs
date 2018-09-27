using SigesoftWeb.Controllers.Security;
using SigesoftWeb.Models;
using SigesoftWeb.Models.MedicalAssistance;
using SigesoftWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWeb.Controllers.MedicalAssistance
{
    public class PatientsAssistanceController : Controller
    {
        [GeneralSecurity(Rol = "PatientsAssistance-BoardPatientsAssistance")]
        public ActionResult Index()
        {
            Api API = new Api();
            return View();
        }

        [GeneralSecurity(Rol = "PatientsAssistance-BoardPatientsAssistance")]
        public ActionResult FilterPacient(BoardPatient data)
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "Patient",data.Patient},
                { "Index", data.Index.ToString()},
                { "Take", data.Take.ToString()}
            };
            ViewBag.Pacients = API.Post<BoardPatient>("PatientsAssistance/GetAllPatientsAssistance", arg);
            return PartialView("_BoardPatientsAssistancePartial");
        }
    }
}