using BE.Common;
using BL.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SigesoftWebAPI.Controllers.Common
{
    public class PacientController : ApiController
    {
        private PacientBL oPacientBL = new PacientBL();

        [HttpPost]
        public IHttpActionResult GetBordPacients(BoardPacient data)
        {
            var result = oPacientBL.GetAllPacients(data);
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetPacientById (string pacientId)
        {
            var result = oPacientBL.GetPacientById(pacientId);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult AddPacient(MultiDataModel data)
        {
            Pacients pacient = JsonConvert.DeserializeObject<Pacients>(data.String1);
            bool result = oPacientBL.AddPacient(pacient, data.Int1);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult EditPacient(MultiDataModel data)
        {
            Pacients pacient = JsonConvert.DeserializeObject<Pacients>(data.String1);
            bool result = oPacientBL.EditPacient(pacient, data.Int1);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult DeletePacient(MultiDataModel data)
        {
            bool result = oPacientBL.DeletePacient(data.String1, data.Int2);
            return Ok(result);
        }


    }
}
