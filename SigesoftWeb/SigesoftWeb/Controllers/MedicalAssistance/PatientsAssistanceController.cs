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
                { "StartDate",data.StartDate == null ? "" :data.StartDate.Value.ToString("yyyy/MM/dd")},
                { "EndDate", data.EndDate== null ? "" :data.EndDate.Value.ToString("yyyy/MM/dd")},
                { "Index", data.Index.ToString()},
                { "Take", data.Take.ToString()}
            };
            ViewBag.Services = API.Post<BoardPatient>("PatientsAssistance/GetAllPatientsAssistance", arg);
            return PartialView("_BoardPatientsAssistancePartial");
        }

        [GeneralSecurity(Rol = "PatientsAssistance-MedicalConsultation")]
        public ActionResult MedicalConsultation(string id)
        {
            return View();
        }
    }
}