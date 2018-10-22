using BE.MedicalAssistance;
using BL.MedicalAssistance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SigesoftWebAPI.Controllers.MedicalAssistance
{
    public class PatientsAssistanceController : ApiController
    {
        PatientsAssistanceBL oPatientsAssistanceBL = new PatientsAssistanceBL();

        [HttpGet]
        public async Task<IHttpActionResult> GetTest()
        {
            var result = 0;
            return  await Task.Run(() => {
                result = oPatientsAssistanceBL.Test();
                return Ok(result);
            });            
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTest2()
        {
            var result = 0;
            return await Task.Run(() => {
                result = oPatientsAssistanceBL.Test2();
                return Ok(result);
            });
        }


        [HttpPost]
        public async Task<IHttpActionResult> GetAllPatientsAssistance(BoardPatient data)
        {
            BoardPatient result = null;
           return  await Task.Run(() =>
            {
                result = oPatientsAssistanceBL.GetAllPatientsAssistance(data);
                return Ok(result);
            });            
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetSchedule()
        {
            return await Task.Run(() => {
               var result = oPatientsAssistanceBL.GetSchedule();
               return Ok(result);
            });
        }

        [HttpGet]
        public async Task<IHttpActionResult> TopDiagnostic()
        {
            return await Task.Run(() => {
                var result = oPatientsAssistanceBL.TopDiagnostic();
                return Ok(result);
            });
        }

        [HttpGet]
        public async Task<IHttpActionResult> IndicatorByPacient(string pacientId)
        {
            return await Task.Run(() => {
                var result = oPatientsAssistanceBL.IndicatorByPacient(pacientId);
                return Ok(result);
            });
        }

        [HttpGet]
        public async Task<IHttpActionResult> MonthlyControls()
        {
            return await Task.Run(() => {
                var result = oPatientsAssistanceBL.MonthlyControls();
                return Ok(result);
            });
        }

        [HttpGet]
        public async Task<IHttpActionResult> ReviewsEMOs(string patientId)
        {
            return await Task.Run(() => {
                var result = oPatientsAssistanceBL.ReviewsEMOs(patientId);
                return Ok(result);
            });
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAntecedentConsolidateForService(string patientId)
        {
            return await Task.Run(() => {
                var result = oPatientsAssistanceBL.GetAntecedentConsolidateForService(patientId);
                return Ok(result);
            });
        }
        [HttpPost]
        public IHttpActionResult DownloadFile(Patients patientId)
        {
            string directorioESO = string.Format("{0}{1}\\", System.Web.Hosting.HostingEnvironment.MapPath("~/"), System.Configuration.ConfigurationManager.AppSettings["directorioESO"].ToString());

            MemoryStream response = oPatientsAssistanceBL.DownloadFile(patientId.PatientId, directorioESO);
            return Ok(response);
        }
    }
}
