using BE.Common;
using BE.Warehouse;
using BL.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SigesoftWebAPI.Controllers.Warehouse
{   
    public class InputOutputController : ApiController
    {
        private MovementDetailBL oMovementBL = new MovementDetailBL();
        public IHttpActionResult GetSupplier()
        {
            List<KeyValueDTO> result = oMovementBL.Supplier();
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetProductName(string value)
        {
            List<string> result = oMovementBL.GetProductsString(value);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult GetDataProduct(string data)
        {

            var result = oMovementBL.GetDataProducts( data);
            return Ok(result);
        }
    }
}
