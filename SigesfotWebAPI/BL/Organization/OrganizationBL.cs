using BE.Common;
using BE.Organization;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Organization
{
    public class OrganizationBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region Bussines 
        public BoardCompany GetAllCompanies(BoardCompany data)
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                int groupOrganization = (int)Enumeratores.Parameters.OrgType;
                int skip = (data.Index - 1) * data.Take;

                string filterProviderIdentification = string.IsNullOrWhiteSpace(data.IdentificationNumber) ? "" : data.IdentificationNumber;
                string filterProviderName = string.IsNullOrWhiteSpace(data.Name) ? "" : data.Name;

                var list = (from a in ctx.Organization
                            join b in ctx.SystemParameter on new { a = a.i_OrganizationTypeId.Value, b = groupOrganization } equals new { a = b.i_ParameterId, b = b.i_GroupId }
                            where a.i_IsDeleted == isDeleted
                                    && (a.v_IdentificationNumber.Contains(filterProviderIdentification))
                                    && (a.v_Name.Contains(filterProviderName)
                                    && (data.OrganizationTypeId == -1 || a.i_OrganizationTypeId == data.OrganizationTypeId))
                            select new Company
                            {
                                OrganizationId = a.v_OrganizationId,
                                OrganizationType = b.v_Value1,
                                SectorTypeId = a.i_SectorTypeId,
                                SectorName = a.v_SectorName,
                                SectorCodigo = a.v_SectorCodigo,
                                IdentificationNumber = a.v_IdentificationNumber,
                                Name = a.v_Name,
                                Address = a.v_Address,
                                PhoneNumber = a.v_PhoneNumber,
                                Mail = a.v_Mail,
                                ContacName = a.v_ContacName,
                                Contacto = a.v_Contacto,
                                EmailContacto = a.v_EmailContacto,
                                Observation = a.v_Observation,
                                NumberQuotasOrganization = a.i_NumberQuotasOrganization,
                                NumberQuotasMen = a.i_NumberQuotasMen,
                                NumberQuotasWomen = a.i_NumberQuotasWomen,
                                DepartmentId = a.i_DepartmentId,
                                ProvinceId = a.i_ProvinceId,
                                DistrictId = a.i_DistrictId,
                                Image = a.b_Image,
                                ContactoMedico = a.v_ContactoMedico,
                                EmailMedico = a.v_EmailMedico,

                            }).ToList();

                int totalRecords = list.Count;

                if (data.Take > 0)
                    list = list.Skip(skip).Take(data.Take).ToList();

                data.TotalRecords = totalRecords;
                data.List = list;
                return data;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public Company GetCompanyById(string organizationId)
        {
            try
            {
                var data = (from a in ctx.Organization
                            where a.v_OrganizationId == organizationId
                            select new Company()
                            {
                                OrganizationId = a.v_OrganizationId,
                                OrganizationTypeId = a.i_OrganizationTypeId,
                                SectorCodigo = a.v_SectorCodigo,
                                IdentificationNumber = a.v_IdentificationNumber,
                                SectorName = a.v_SectorName,
                                Name = a.v_Name,
                                ContacName = a.v_ContacName,
                                EmailContacto = a.v_EmailContacto,
                                Contacto = a.v_Contacto,
                                Mail = a.v_Mail,
                                ContactoMedico = a.v_ContactoMedico,
                                Address = a.v_Address,
                                Observation = a.v_Observation,
                                PhoneNumber = a.v_PhoneNumber,
                                EmailMedico = a.v_EmailMedico,
                            }).FirstOrDefault();
                return data;
            }

            catch (Exception ex)
            {
                return null;
            }
            
        }

        public bool EditCompany(Company company, int systemUserId)
        {
            OrganizationBL oOrganizationBL = new OrganizationBL();
            try
            {
                var oOrganization = (from a in ctx.Organization where a.v_OrganizationId == company.OrganizationId select a).FirstOrDefault();
                if (oOrganization == null)
                    return false;
                oOrganization.v_OrganizationId = company.OrganizationId;
                oOrganization.i_OrganizationTypeId = company.OrganizationTypeId;
                oOrganization.v_SectorCodigo = company.SectorCodigo;
                oOrganization.v_IdentificationNumber = company.IdentificationNumber;
                oOrganization.v_SectorName = company.SectorName;
                oOrganization.v_Name = company.Name;
                oOrganization.v_ContacName = company.ContacName;
                oOrganization.v_EmailContacto = company.EmailContacto;
                oOrganization.v_Contacto = company.Contacto;
                oOrganization.v_Mail = company.Mail;
                oOrganization.v_ContactoMedico = company.ContactoMedico;
                oOrganization.v_Address = company.Address;
                oOrganization.v_Observation = company.Observation;
                oOrganization.v_PhoneNumber = company.PhoneNumber;
                oOrganization.v_EmailMedico = company.EmailMedico;

                return oOrganizationBL.UpdateCompany(oOrganization, systemUserId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddCompany(Company company, int systemUserId)
        {
            OrganizationBL oOrganizationBL = new OrganizationBL();
            try
            {
                var oOrganizationBE = new OrganizationBE
                {

                    v_OrganizationId = new Utils().GetPrimaryKey(1, 5, "OO"),
                    i_OrganizationTypeId = company.OrganizationTypeId,
                    i_SectorTypeId = company.SectorTypeId,
                    v_SectorName = company.SectorName,
                    v_SectorCodigo = company.SectorCodigo,
                    v_IdentificationNumber = company.IdentificationNumber,
                    v_Name = company.Name,
                    v_Address = company.Address,
                    v_PhoneNumber = company.PhoneNumber,
                    v_Mail = company.Mail,
                    v_ContacName = company.ContacName,
                    v_Contacto = company.Contacto,
                    v_EmailContacto = company.EmailContacto,
                    v_Observation = company.Observation,
                    i_NumberQuotasOrganization = company.NumberQuotasOrganization,
                    i_NumberQuotasMen = company.NumberQuotasMen,
                    i_NumberQuotasWomen = company.NumberQuotasWomen,
                    i_DepartmentId = company.DepartmentId,
                    i_ProvinceId = company.ProvinceId,
                    i_DistrictId = company.DistrictId,
                    b_Image = company.Image,
                    v_ContactoMedico = company.ContactoMedico,
                    v_EmailMedico = company.EmailMedico,
                    //Auditoria
                    i_IsDeleted = (int)Enumeratores.SiNo.No,
                    d_InsertDate = DateTime.UtcNow,
                    i_InsertUserId = systemUserId,
                };

                ctx.Organization.Add(oOrganizationBE);

                int rows = ctx.SaveChanges();
                if (rows > 0)
                    return true;

                return false;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }

        #endregion

        #region CRUD
        

       

      

        public bool UpdateCompany(OrganizationBE company, int systemUserId)
        {
            try
            {
                var oOrganization = (from a in ctx.Organization
                            where a.v_OrganizationId == company.v_OrganizationId
                            select a).FirstOrDefault();

                if (oOrganization == null)
                    return false;

                oOrganization.i_OrganizationTypeId = company.i_OrganizationTypeId;
                oOrganization.i_SectorTypeId = company.i_SectorTypeId;
                oOrganization.v_SectorName = company.v_SectorName;
                oOrganization.v_SectorCodigo = company.v_SectorCodigo;
                oOrganization.v_IdentificationNumber = company.v_IdentificationNumber;
                oOrganization.v_Name = company.v_Name;
                oOrganization.v_Address = company.v_Address;
                oOrganization.v_PhoneNumber = company.v_PhoneNumber;
                oOrganization.v_Mail = company.v_Mail;
                oOrganization.v_ContacName = company.v_ContacName;
                oOrganization.v_Contacto = company.v_Contacto;
                oOrganization.v_EmailContacto = company.v_EmailContacto;
                oOrganization.v_Observation = company.v_Observation;
                oOrganization.i_NumberQuotasOrganization = company.i_NumberQuotasOrganization;
                oOrganization.i_NumberQuotasMen = company.i_NumberQuotasMen;
                oOrganization.i_NumberQuotasWomen = company.i_NumberQuotasWomen;
                oOrganization.i_DepartmentId = company.i_DepartmentId;
                oOrganization.i_ProvinceId = company.i_ProvinceId;
                oOrganization.i_DistrictId = company.i_DistrictId;
                oOrganization.b_Image = company.b_Image;
                oOrganization.v_ContactoMedico = company.v_ContactoMedico;
                oOrganization.v_EmailMedico = company.v_EmailMedico;

                //Auditoria

                oOrganization.d_UpdateDate = DateTime.UtcNow;
                oOrganization.i_UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
        #endregion
    }
}
