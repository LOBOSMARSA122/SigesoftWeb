using BE.Organization;
using BL.Common;
using BL.Organization;
using Newtonsoft.Json;
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
        public async Task<IHttpActionResult> GetBoardCompany(BoardCompany data)
        {
            var result = oOrganizationBL.GetAllCompanies(data);
            return await Task.Run(() =>
            {
                return Ok(result);
            });
            
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetCompanyById(string organizationId)
        {
            var result = oOrganizationBL.GetCompanyById(organizationId);
            return await Task.Run(() =>
            {
                return Ok(result);
            });
        }

        [HttpPost]
        public async Task<IHttpActionResult> EditCompany(MultiDataModel data)
        {
            Company company = JsonConvert.DeserializeObject<Company>(data.String1);
            bool result = oOrganizationBL.EditCompany(company, data.Int1);
            return await Task.Run(() =>
            {
                return Ok(result);
            });
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddCompany(MultiDataModel data)
        {
            Company company = JsonConvert.DeserializeObject<Company>(data.String1);
            bool result = oOrganizationBL.AddCompany(company, data.Int1);
            return await Task.Run(() =>
            {
                return Ok(result);
            });
        }
        
    }
}
