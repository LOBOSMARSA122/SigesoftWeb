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

namespace SigesoftWeb.Controllers.Report
{
    public class ReportController : Controller
    {
        // GET: ProductOutput
        [GeneralSecurity(Rol = "ProductOutput-BoardProduct")]
        public ActionResult ProductOutput()
        {
            Api API = new Api();
            Dictionary<string, string> argCategoryProd = new Dictionary<string, string>()
            {
                { "grupoId" , ((int)Enums.DataHierarchy.CategoryProd).ToString() },
            };
            ViewBag.CategoryProd = Utils.Utils.LoadDropDownList(API.Get<List<Dropdownlist>>("DataHierarchy/GetDataHierarchyByGrupoId", argCategoryProd), Constants.Select);
            return View();
        }
        public ActionResult FilterReportProduct(BoardProduct data)
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "CategoryId", data.CategoryId.ToString()},
                { "ProductCode",data.ProductCode},
                { "Name", data.Name},
                { "Index", data.Index.ToString()},
                { "Take", data.Take.ToString()}
            };

            ViewBag.REGISTROSPROD = API.Post<BoardProduct>("Product/BandejaReporteProducto", arg);
            return PartialView("_ReportProductPartial");
        }
    }
}