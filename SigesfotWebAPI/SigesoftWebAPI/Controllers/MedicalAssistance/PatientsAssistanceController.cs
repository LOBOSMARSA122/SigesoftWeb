using BE.MedicalAssistance;
using BL.MedicalAssistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SigesoftWebAPI.Controllers.MedicalAssistance
{
    public class PatientsAssistanceController : ApiController
    {
        PatientsAssistanceBL oPatientsAssistanceBL = new PatientsAssistanceBL();
        [HttpPost]
        public IHttpActionResult GetAllPatientsAssistance(BoardPatient data)
        {
            var result = oPatientsAssistanceBL.GetAllPatientsAssistance(data);
            return Ok(result);
        }
    }
}
