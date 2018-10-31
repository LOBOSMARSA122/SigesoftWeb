using SigesoftWeb.Controllers.Security;
using SigesoftWeb.Models;
using SigesoftWeb.Models.Common;
using SigesoftWeb.Models.Organization;
using SigesoftWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWeb.Controllers.Organization
{
    public class OrganizationController : Controller
    {

        [GeneralSecurity(Rol = "Organization-BoardOrganization")]
        public ActionResult Index()
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "grupoId" , ((int)Enums.SystemParameter.OrgType).ToString() }
            };

            ViewBag.OrgType = Utils.Utils.LoadDropDownList(API.Get<List<Dropdownlist>>("SystemParameter/GetParametroByGrupoId", arg), Constants.All);
            return View();
        }

        public async Task<ActionResult> FilterProvider(BoardProvider data)
        {
            Api API = new Api();
            Dictionary<string, string> arg = new Dictionary<string, string>()
            {
                { "OrganizationTypeId", data.OrganizationTypeId.ToString() },
                { "IdentificationNumber", data.IdentificationNumber},
                { "Name", data.Name},

                { "Index", data.Index.ToString()},
                { "Take", data.Take.ToString()}
            };

            return await Task.Run(() =>
            {
                ViewBag.Providers = API.Post<BoardProvider>("Organization/GetBoardProvider", arg);
                return PartialView("_BoardProviderPartial");
            });
            
        }
    }
}