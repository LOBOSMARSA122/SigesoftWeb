using SigesoftWeb.Controllers.Security;
using SigesoftWeb.Models;
using SigesoftWeb.Models.MedicalAssistance;
using SigesoftWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWeb.Controllers.MedicalAssistance
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
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
                //{ "StartDate",data.StartDate == null ? "" :data.StartDate.Value.ToString("yyyy/MM/dd")},
                //{ "EndDate", data.EndDate== null ? "" :data.EndDate.Value.ToString("yyyy/MM/dd")},
                { "Index", data.Index.ToString()},
                { "Take", data.Take.ToString()}
            };

            return await Task.Run(() =>
            {
                ViewBag.Services = API.Post<BoardPatient>("PatientsAssistance/GetAllPatientsAssistance", arg);
                ViewBag.PendingReview = API.Post<int?>("PatientsAssistance/GetPendingReview",arg);

                return PartialView("_BoardPatientsAssistancePartial");
            });

        }

        [GeneralSecurity(Rol = "PatientsAssistance-MedicalConsultation")]
        public async Task<ActionResult> MedicalConsultation(string id)
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "pacientId",id}               
            };

            return await Task.Run(() =>
            {
                ViewBag.Indicators = API.Get<Indicators>("PatientsAssistance/IndicatorByPacient", arg);

                return View();
            });
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

        public async Task<JsonResult> MonthlyControls()
        {
            Api API = new Api();
            string url = "PatientsAssistance/MonthlyControls";
            var result = API.Get<MonthlyControls>(url);
            return await Task.Run(() =>
            {
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            });

        }

        public async Task<ActionResult> GetAntecedent(string patientId)
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "patientId", patientId},
            };

            return await Task.Run(() =>
            {
                ViewBag.Antecedent = API.Get<List<PersonMedicalHistoryList>>("PatientsAssistance/GetAntecedentConsolidateForService", arg);
                ViewBag.Reviews = API.Get<List<ReviewEMO>>("PatientsAssistance/ReviewsEMOs", arg);
                return PartialView("_ReviewEMOPartial");
            });
        }

        public JsonResult DownloadFile(string patientId)
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "patientId", patientId },
            };

            byte[] ms = API.PostDownloadStream("PatientsAssistance/DownloadFile", arg);

            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=FileName.pdf");
            Response.BinaryWrite(ms);
            Response.End();

            return Json(Response);
        }

        public JsonResult Test()
        {
            #region ...
            //Api API = new Api();
            //int response = 0;

            //return await Task.Run(() =>
            //{
            //    response = API.Get<int>("PatientsAssistance/GetTest");
            //    return Json(response);
            //});

            //var httpClient = new HttpClient();
            //var response = await httpClient.GetAsync("http://localhost:1932/PatientsAssistance/GetTest");
            //response.EnsureSuccessStatusCode();
            //string content = await response.Content.ReadAsStringAsync();

            //return await Task.Run(() =>
            //{
            //    return new JsonResult { Data = content, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //});

            //string url = "http://localhost:1932/PatientsAssistance/GetTest";
            //using (var result = await _httpClient.GetAsync($"{url}"))
            //{
            //    string content = await result.Content.ReadAsStringAsync();
            //    return new JsonResult { Data = content, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; 
            //}


            //var httpClient = new HttpClient();
            //HttpResponseMessage response;
            //response = await Task.Run(() =>
            //{
            //    return httpClient.GetAsync("http://localhost:1932/PatientsAssistance/GetTest");
            //});

            ////response = await httpClient.GetAsync("http://localhost:1932/PatientsAssistance/GetTest2");
            //response.EnsureSuccessStatusCode();
            //string content = await Task.Run(() => {
            //    return response.Content.ReadAsStringAsync();
            //});
            ////string content = await response.Content.ReadAsStringAsync();

            //return new JsonResult { Data = "100", JsonRequestBehavior = JsonRequestBehavior.AllowGet };


            //return await Task.Run(() =>
            //{
            //    //return httpClient.GetAsync("http://localhost:1932/PatientsAssistance/GetTest");           
            //    Thread.Sleep(20000);
            //    return new JsonResult { Data = "100", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //});
            #endregion

            Api API = new Api();
            string url = "PatientsAssistance/GetTest";
            var result = API.Get<int>(url);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult Test2()
        {
            #region ...
            //Api API = new Api();
            //int response = 0;

            //return await Task.Run(() =>
            //{
            //    response = API.Get<int>("PatientsAssistance/GetTest2");
            //    return Json(response);
            //});

            //var httpClient = new HttpClient();
            //HttpResponseMessage response;
            //await Task.Run(() =>
            //{
            //    //return httpClient.GetAsync("http://localhost:1932/PatientsAssistance/GetTest2");           
            //    Thread.Sleep(1000);
            //});

            //response = await httpClient.GetAsync("http://localhost:1932/PatientsAssistance/GetTest2");
            //response.EnsureSuccessStatusCode();

            //string content = await Task.Run(() => {
            //   return response.Content.ReadAsStringAsync();
            //});
            //string content = await response.Content.ReadAsStringAsync();

            //return new JsonResult { Data = "200", JsonRequestBehavior = JsonRequestBehavior.AllowGet };


            //string url = "http://localhost:1932/PatientsAssistance/GetTest2";
            //using (var result = await _httpClient.GetAsync($"{url}"))
            //{
            //    string content = await result.Content.ReadAsStringAsync();
            //    return new JsonResult { Data = content, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //}

            //return await Task.Run(() =>
            //{
            //    //return httpClient.GetAsync("http://localhost:1932/PatientsAssistance/GetTest2");           
            //    Thread.Sleep(1000);
            //    return new JsonResult { Data = "100", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //});
            #endregion
            Api API = new Api();
            string url = "PatientsAssistance/GetTest2";
            var result = API.Get<int>(url);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #region ...
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
        #endregion

        #region ...
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
        #endregion

    }
}