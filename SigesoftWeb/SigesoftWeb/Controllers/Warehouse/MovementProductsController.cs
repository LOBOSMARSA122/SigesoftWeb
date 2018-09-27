using SigesoftWeb.Controllers.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWeb.Controllers.Warehouse
{
    public class MovementProductsController : Controller
    {
        [GeneralSecurity(Rol = "MovementProducts-BoardMovementProducts")]
        public ActionResult Index()
        {
            return View();
        }
    }
}