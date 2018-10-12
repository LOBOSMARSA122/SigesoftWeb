using BE.Common;
using BE.Warehouse;
using BL.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SigesoftWebAPI.Controllers.Report
{
    public class ReportProductController : ApiController
    {
        private ProductWarehouseBL oProductWarehouseBL = new ProductWarehouseBL();

        [HttpPost]
        public IHttpActionResult GetAllProductWarehouse(BoardProductWarehouse data)
        {
            var result = oProductWarehouseBL.GetAllProductsWarehouse(data);
            return Ok(result);
        }

        //[HttpPost]
        //public IHttpActionResult GetProductWarehouseById(string productId)
        //{
        //    var result = oProductWarehouseBL.GetProductWarehouseById(productId);
        //    return Ok(result);
        //}

        public IHttpActionResult GetJoinOrganizationAndLocationNotInRestricted(int nodeId)
        {
            List<KeyValueDTO> result = oProductWarehouseBL.GetJoinOrganizationAndLocationNotInRestricted(nodeId);
            return Ok(result);
        }

        public IHttpActionResult GetWarehouseNotInRestricted(int nodeId, string OrganizationId, string LocationId)
        {
            List<KeyValueDTO> result = oProductWarehouseBL.GetWarehouseNotInRestricted(nodeId, OrganizationId, LocationId);
            return Ok(result);
        }
    }
}
