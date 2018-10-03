using SigesoftWeb.Controllers.Security;
using SigesoftWeb.Models;
using SigesoftWeb.Models.Common;
using SigesoftWeb.Models.Warehouse;
using SigesoftWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWeb.Controllers.Warehouse
{
    public class MovementProductsController : Controller
    {
        [GeneralSecurity(Rol = "MovementProducts-BoardMovement")]
        public ActionResult Index()
        {
            Api API = new Api();
            Dictionary<string, string> argTypeMovement = new Dictionary<string, string>()
            {
                { "grupoId" , ((int)Enums.SystemParameter.TypeMovement).ToString() },
            };
            ViewBag.TypeMovement = Utils.Utils.LoadDropDownList(API.Get<List<Dropdownlist>>("SystemParameter/GetParametroByGrupoId", argTypeMovement), Constants.All);

            Dictionary<string, string> argOrgLoc = new Dictionary<string, string>()
            {
                { "nodeId" , "9" },
            };
            ViewBag.OrganizationIdLocationId = Utils.Utils.LoadDropDownList(API.Get<List<Dropdownlist>>("Movement/GetJoinOrganizationAndLocationNotInRestricted", argOrgLoc), Constants.All);

            Dictionary<string, string> argWarehouseMovement = new Dictionary<string, string>()
            {
                { "nodeId" , "9" },
                { "OrganizationId" , "" },
                { "LocationId" , "" },
            };
            ViewBag.WarehouseMovement = Utils.Utils.LoadDropDownList(API.Get<List<Dropdownlist>>("Movement/GetWarehouseNotInRestricted", argWarehouseMovement), Constants.All);

            return View();
        }

        public ActionResult FilterWarehouseMovement(BoardMovement data)
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {           
                { "OrganizationLocationId", data.OrganizationLocationId},
                { "WarehouseId",data.WarehouseId},
                { "MovementType", data.MovementType.ToString()},
                { "StartDate",data.StartDate.Value.ToString("yyyy/MM/dd")},
                { "EndDate", data.EndDate.Value.ToString("yyyy/MM/dd")},

                { "Index", data.Index.ToString()},
                { "Take", data.Take.ToString()}
            };
            ViewBag.Movement = API.Post<BoardMovement>("Movement/GetMovementsListByWarehouseId", arg);
            return PartialView("_BoardMovementPartial");
        }

        public JsonResult GetWarehouseNotInRestricted(string OrganizationId, string LocationId)
        {
            Api API = new Api();
            Dictionary<string, string> argWarehouseMovement = new Dictionary<string, string>()
            {
                { "nodeId" , "9" },
                { "OrganizationId" , OrganizationId },
                { "LocationId" , LocationId },
            };
            List<Dropdownlist> Warehouses = Utils.Utils.LoadDropDownList(API.Get<List<Dropdownlist>>("Movement/GetWarehouseNotInRestricted", argWarehouseMovement), Constants.Select);

            return new JsonResult { Data = Warehouses, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        }
}