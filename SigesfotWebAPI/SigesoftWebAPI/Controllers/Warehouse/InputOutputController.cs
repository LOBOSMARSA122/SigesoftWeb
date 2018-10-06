using BE.Common;
using BE.Warehouse;
using BL.Common;
using BL.Warehouse;
using Newtonsoft.Json;
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

        [HttpGet]
        public IHttpActionResult GetDataProduct(string ProductName)
        {

            var result = oMovementBL.GetDataProduct(ProductName);

            return Ok(result);
        }
        [HttpPost]
        public IHttpActionResult SaveMovementProducts (MultiDataModel data)
        {
            try
            {
                BoardMovementDataProcess movProduct = JsonConvert.DeserializeObject<BoardMovementDataProcess>(data.String1);
                return Ok(oMovementBL.MovementProductDataProcess(movProduct));
            }
            catch (Exception ex)
            {
                return BadRequest("Parámetros Incorrectos");
            }
        }
    }
}
