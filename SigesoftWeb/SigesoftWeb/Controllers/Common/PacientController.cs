﻿using SigesoftWeb.Models;
using SigesoftWeb.Models.Common;
using System.Collections.Generic;
using SigesoftWeb.Controllers.Security;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using SigesoftWeb.Utils;

namespace SigesoftWeb.Controllers.Common
{
    public class PacientController : Controller
    {
        // GET: Pacient
        public ActionResult Index()
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "grupoId" , ((int)Enums.DataHierarchy.DocType).ToString() }
            };

            ViewBag.DocType = Utils.Utils.LoadDropDownList(API.Get<List<Dropdownlist>>("DataHierarchy/GetDataHierarchyByGrupoId", arg), Constants.Select);
            return View();
        }

        //[GeneralSecurity(Rol = "Administracion-Proveedores")]
        public ActionResult FilterPacient(BoardPacient data)
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "Pacient",data.Pacient},
                { "DocTypeId", data.DocTypeId.ToString()},
                { "DocNumber", data.DocNumber},
                { "Index", data.Index.ToString()},
                { "Take", data.Take.ToString()}
            };
            ViewBag.Pacients = API.Post<BoardPacient>("Pacient/GetBordPacients", arg);
            return PartialView("_BoardPacientsPartial");
        }
    }

  
}