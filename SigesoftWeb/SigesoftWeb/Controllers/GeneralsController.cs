using SigesoftWeb.Models;
using SigesoftWeb.Models.Security;
using SigesoftWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWeb.Controllers
{
    public class GeneralsController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToRoute("General_login");
        }

        //[GeneralSecurity(Rol = "")]
        public ActionResult Home()
        {
            return View("~/Views/Generals/Index.cshtml", ViewBag.MENU);
        }

        public ActionResult Login()
        {
            if (TempData["MESSAGE"] != null)
            {
                ViewBag.MESSAGE = TempData["MESSAGE"];
            }
            return View("~/Views/Generals/Login.cshtml");
        }

        public ActionResult Logout()
        {
            Session.Remove("AutBackoffice");
            Session.RemoveAll();
            return RedirectToRoute("General_login");
        }

        public ActionResult Login_authentication(FormCollection collection)
        {
            if (TempData["FormCollection"] != null)
                collection = (FormCollection)TempData["FormCollection"];

            if (ValidateEmptyFields(collection))
            {
                if (ValidateSystemUser(collection))
                    return RedirectToRoute("SigesoftWeb");
                else
                    return RedirectToRoute("General_Login");
            }
            else
            {
                TempData["MESSAGE"] = "Debe ingresar el usuario y/o la contraseña";
                return RedirectToRoute("General_Login");
            }

        }

        private bool ValidateSystemUser(FormCollection collection)
        {
            TempData["FormCollection"] = null;

            Api API = new Api();
            var systemUser = API.Get<UserLogin>(relativePath: "Authorization/ValidateSystemUser", args: Arguments(collection));
            if (systemUser != null)
            {
                Session.Add("AutBackoffice", PopulateClientSession(systemUser));
                return true;
            }
            else
            {
                TempData["MESSAGE"] = "Usuario o contraseña incorrectos";
                return false;
            }
        }

        private bool ValidateEmptyFields(FormCollection collection)
        {
            if (string.IsNullOrWhiteSpace(collection.Get("userName").Trim()) || string.IsNullOrWhiteSpace(collection.Get("password").Trim()))
                return false;

            return true;
        }

        private ClientSession PopulateClientSession(dynamic usuario)
        {
            ViewBag.USUARIO = usuario;
            ClientSession oclientSession = new ClientSession
            {
                SystemUserId = ViewBag.USUARIO.SystemUserId,
                PersonId = ViewBag.USUARIO.PersonId,
                FullName = ViewBag.USUARIO.FullName,
                PersonImage = ViewBag.USUARIO.PersonImage
                //Authorizations = ViewBag.USUARIO.Permissions
            };
            return oclientSession;
        }

        private Dictionary<string, string> Arguments(FormCollection collection)
        {
            Dictionary<string, string> accessUser = new Dictionary<string, string>
            {
                { "nodeId", "1" },
                { "userName", collection.Get("userName").Trim() },
                { "password", Utils.Utils.Encrypt(collection.Get("password").Trim()) }
            };

            return accessUser;
        }

        public ActionResult SessionExpired()
        {
            Session.Remove("AutBackoffice");
            Session.RemoveAll();
            return RedirectToRoute("General_login");
        }
    }
}