using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWeb.Controllers.Common
{
    public class PacientController : Controller
    {
        // GET: Pacient
        public ActionResult Index()
        {
            ViewBag.DocType = Utils.Utils.LoadDropDownList(API.Get<List<Dropdownlist>>("Empresa/GetTipoEmpresa"), Constantes.Select);
            return View();
        }
    }
}