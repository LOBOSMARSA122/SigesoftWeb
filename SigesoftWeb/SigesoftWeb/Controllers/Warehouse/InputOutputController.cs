using Newtonsoft.Json;
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
    public class InputOutputController : Controller
    {
        // GET: Default
        [GeneralSecurity(Rol = "InputOutput-BoardMovementsDetail")]
        public ActionResult Index()
        {
            Api API = new Api();
            Dictionary<string, string> argMotiveMovement = new Dictionary<string, string>()
            {
                { "grupoId" , ((int)Enums.SystemParameter.MotiveMovement).ToString() },
            };
            ViewBag.MotiveMovement = Utils.Utils.LoadDropDownList(API.Get<List<Dropdownlist>>("DataHierarchy/GetDataHierarchyByGrupoId", argMotiveMovement), Constants.All);

            ViewBag.SupplierId = Utils.Utils.LoadDropDownList(API.Get<List<Dropdownlist>>("InputOutput/GetSupplier"), Constants.All);
            return View();
        }

        public JsonResult GetProductName(string value)
        {
            Api API = new Api();
            Dictionary<string, string> args = new Dictionary<string, string>
            {
                {"value", value }
            };
            List<string> Product = API.Get<List<string>>("InputOutput/GetProductName", args);
            return new JsonResult { Data = Product, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult GetDataProduct(string data)
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "ProductName", data },
            };

            var product = API.Get<Products>("InputOutput/GetDataProduct", arg);

            return new JsonResult { Data = product, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult SaveMovementProduct(string data)
        {
            Api API = new Api();
            BoardMovementDataProcess movProduct = JsonConvert.DeserializeObject<BoardMovementDataProcess>(data);

            Dictionary<string, string> args = new Dictionary<string, string>
            {
                { "String1", JsonConvert.SerializeObject(movProduct) },
            };
            bool saved = API.Post<bool>("/InputOutput/SaveMovementProducts", args);
            if (saved)
                return Json(saved);
            else
                return Json(null);
            
        }
    }
}