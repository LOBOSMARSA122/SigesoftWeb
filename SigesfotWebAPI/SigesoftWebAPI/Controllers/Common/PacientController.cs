using BE.Common;
using BL.Common;
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
    }
}
