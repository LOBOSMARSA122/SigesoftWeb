using BE.Organization;
using BL.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SigesoftWebAPI.Controllers.Organization
{
    public class OrganizationController : ApiController
    {
        private OrganizationBL oOrganizationBL = new OrganizationBL();

        [HttpPost]
        public async Task<IHttpActionResult> GetBoardProvider(BoardProvider data)
        {
            var result = oOrganizationBL.GetAllProviders(data);
            return await Task.Run(() =>
            {
                return Ok(result);
            });
            
        }
    }
}
