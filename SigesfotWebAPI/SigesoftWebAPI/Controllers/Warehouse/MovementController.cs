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
    public class MovementController : ApiController
    {
        private MovementBL oMovementBL = new MovementBL();

        [HttpPost]
        public IHttpActionResult GetMovementsListByWarehouseId(BoardMovement data)
        {
            var result = oMovementBL.GetMovementsListByWarehouseId(data);
            return Ok(result);
        }

        public IHttpActionResult GetJoinOrganizationAndLocationNotInRestricted(int nodeId)
        {
            List<KeyValueDTO> result = oMovementBL.GetJoinOrganizationAndLocationNotInRestricted(nodeId);
            return Ok(result);
        }

        public IHttpActionResult GetWarehouseNotInRestricted(int nodeId, string OrganizationId, string LocationId)
        {
            List<KeyValueDTO> result = oMovementBL.GetWarehouseNotInRestricted(nodeId, OrganizationId, LocationId);
            return Ok(result);
        }
    }
}
