using SigesoftWeb.Controllers.Security;
using SigesoftWeb.Models;
using SigesoftWeb.Models.MedicalAssistance;
using SigesoftWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<ActionResult> FilterPacient(BoardPatient data)
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

            return await Task.Run(() =>
            {
                ViewBag.Services = API.Post<BoardPatient>("PatientsAssistance/GetAllPatientsAssistance", arg);

                return PartialView("_BoardPatientsAssistancePartial");
            });

        }

        //[GeneralSecurity(Rol = "PatientsAssistance-BoardPatientsAssistance")]
        //public ActionResult FilterPacient(BoardPatient data)
        //{
        //    Api API = new Api();
        //    Dictionary<string, string> arg = new Dictionary<string, string>()
        //    {
        //        { "Patient",data.Patient},
        //        { "StartDate",data.StartDate == null ? "" :data.StartDate.Value.ToString("yyyy/MM/dd")},
        //        { "EndDate", data.EndDate== null ? "" :data.EndDate.Value.ToString("yyyy/MM/dd")},
        //        { "Index", data.Index.ToString()},
        //        { "Take", data.Take.ToString()}
        //    };
        //        ViewBag.Services = API.Post<BoardPatient>("PatientsAssistance/GetAllPatientsAssistance", arg);

        //        return PartialView("_BoardPatientsAssistancePartial");

        //}

        //[GeneralSecurity(Rol = "PatientsAssistance-Test1")]
        public async Task<JsonResult> Test()
        {
            //Api API = new Api();
            //int response = 0;

            //return await Task.Run(() =>
            //{
            //    response = API.Get<int>("PatientsAssistance/GetTest");
            //    return Json(response);
            //});
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:82/PatientsAssistance/GetTest");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            return await Task.Run(() =>
            {
                return new JsonResult { Data = content, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            });
        }

        //[GeneralSecurity(Rol = "PatientsAssistance-Test2")]
        public async Task<JsonResult> Test2()
        {
            //Api API = new Api();
            //int response = 0;

            //return await Task.Run(() =>
            //{
            //    response = API.Get<int>("PatientsAssistance/GetTest2");
            //    return Json(response);
            //});
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:82/PatientsAssistance/GetTest2");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            return await Task.Run(() =>
            {
                return new JsonResult { Data = content, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            });
        }


        [GeneralSecurity(Rol = "PatientsAssistance-MedicalConsultation")]
        public ActionResult MedicalConsultation(string id)
        {
            return View();
        }

        public JsonResult GetSchedule()
        {
            Api API = new Api();
            string url = "PatientsAssistance/GetSchedule";
            var result = API.Get<List<Schedule>>(url);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public async Task<JsonResult> TopDiagnostic()
        {
            Api API = new Api();
            string url = "PatientsAssistance/TopDiagnostic";
            var result = API.Get<List<TopDiagnostic>>(url);
            return await Task.Run(() =>
            {
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            });

        }

        //public async Task<JsonObject> GetAsync(string uri)
        //{
        //    var httpClient = new HttpClient();
        //    var response = await httpClient.GetAsync(uri);

        //    //will throw an exception if not successful
        //    response.EnsureSuccessStatusCode();

        //    string content = await response.Content.ReadAsStringAsync();
        //    return await Task.Run(() => JsonObject.Parse(content));
        //}

        //public JsonResult TopDiagnostic()
        //{
        //    Api API = new Api();
        //    string url = "PatientsAssistance/TopDiagnostic";
        //    var result = API.Get<List<TopDiagnostic>>(url);
        //    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}




        //[GeneralSecurity(Rol = "PatientsAssistance-TopDiagnostic")]
        //public ActionResult TopDiagnostic()
        //{
        //    Api API = new Api();
        //    ViewBag.TOPDX = API.Get<List<TopDiagnostic>>("PatientsAssistance/TopDiagnostic");
        //    return PartialView("_TopDiagnosticPartial");
        //}
    }
}