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
        public BoardProvider GetAllProviders(BoardProvider data)
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
                            select new Provider
                            {
                                OrganizationId = a.v_OrganizationId,
                                OrganizationTypeId = b.i_ParameterId,
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
                                IsDeleted = a.i_IsDeleted,
                                InsertUserId = a.i_InsertUserId,
                                InsertDate = a.d_InsertDate,
                                UpdateDate = a.d_UpdateDate,
                                UpdateUserId = a.i_UpdateUserId
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

        #endregion

        #region CRUD
        public OrganizationBE GetOrganization(string organizationId)
        {
            try
            {
                var objEntity = (from a in ctx.Organization
                                 where a.v_OrganizationId == organizationId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<OrganizationBE> GetAllOrganization()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Organization
                                 where a.i_IsDeleted == isDelete
                                 select new OrganizationBE()
                                 {
                                     v_OrganizationId = a.v_OrganizationId,
                                     i_OrganizationTypeId = a.i_OrganizationTypeId,
                                     i_SectorTypeId = a.i_SectorTypeId,
                                     v_SectorName = a.v_SectorName,
                                     v_SectorCodigo = a.v_SectorCodigo,
                                     v_IdentificationNumber = a.v_IdentificationNumber,
                                     v_Name = a.v_Name,
                                     v_Address = a.v_Address,
                                     v_PhoneNumber = a.v_PhoneNumber,
                                     v_Mail = a.v_Mail,
                                     v_ContacName = a.v_ContacName,
                                     v_Contacto = a.v_Contacto,
                                     v_EmailContacto = a.v_EmailContacto,
                                     v_Observation = a.v_Observation,
                                     i_NumberQuotasOrganization = a.i_NumberQuotasOrganization,
                                     i_NumberQuotasMen = a.i_NumberQuotasMen,
                                     i_NumberQuotasWomen = a.i_NumberQuotasWomen,
                                     i_DepartmentId = a.i_DepartmentId,
                                     i_ProvinceId = a.i_ProvinceId,
                                     i_DistrictId = a.i_DistrictId,
                                     b_Image = a.b_Image,
                                     v_ContactoMedico = a.v_ContactoMedico,
                                     v_EmailMedico = a.v_EmailMedico,
                                     i_IsDeleted = a.i_IsDeleted,
                                     i_InsertUserId = a.i_InsertUserId,
                                     d_InsertDate = a.d_InsertDate,
                                     d_UpdateDate = a.d_UpdateDate,
                                     i_UpdateUserId = a.i_UpdateUserId
                                 }).ToList();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddOrganization(OrganizationBE organization, int systemUserId)
        {
            try
            {
                OrganizationBE oOrganizationBE = new OrganizationBE()
                {
                    v_OrganizationId =  new Utils().GetPrimaryKey(1, 5, "OO"),
                    i_OrganizationTypeId = organization.i_OrganizationTypeId,
                    i_SectorTypeId = organization.i_SectorTypeId,
                    v_SectorName = organization.v_SectorName,
                    v_SectorCodigo = organization.v_SectorCodigo,
                    v_IdentificationNumber = organization.v_IdentificationNumber,
                    v_Name = organization.v_Name,
                    v_Address = organization.v_Address,
                    v_PhoneNumber = organization.v_PhoneNumber,
                    v_Mail = organization.v_Mail,
                    v_ContacName = organization.v_ContacName,
                    v_Contacto = organization.v_Contacto,
                    v_EmailContacto = organization.v_EmailContacto,
                    v_Observation = organization.v_Observation,
                    i_NumberQuotasOrganization = organization.i_NumberQuotasOrganization,
                    i_NumberQuotasMen = organization.i_NumberQuotasMen,
                    i_NumberQuotasWomen = organization.i_NumberQuotasWomen,
                    i_DepartmentId = organization.i_DepartmentId,
                    i_ProvinceId = organization.i_ProvinceId,
                    i_DistrictId = organization.i_DistrictId,
                    b_Image = organization.b_Image,
                    v_ContactoMedico = organization.v_ContactoMedico,
                    v_EmailMedico = organization.v_EmailMedico,
                    //Auditoria
                    i_IsDeleted = (int)Enumeratores.SiNo.No,
                    d_InsertDate = DateTime.UtcNow,
                    i_InsertUserId = systemUserId,
                };

                ctx.Organization.Add(oOrganizationBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateOrganization(OrganizationBE organization, int systemUserId)
        {
            try
            {
                var oOrganization = (from a in ctx.Organization
                            where a.v_OrganizationId == organization.v_OrganizationId
                            select a).FirstOrDefault();

                if (oOrganization == null)
                    return false;

                oOrganization.i_OrganizationTypeId = organization.i_OrganizationTypeId;
                oOrganization.i_SectorTypeId = organization.i_SectorTypeId;
                oOrganization.v_SectorName = organization.v_SectorName;
                oOrganization.v_SectorCodigo = organization.v_SectorCodigo;
                oOrganization.v_IdentificationNumber = organization.v_IdentificationNumber;
                oOrganization.v_Name = organization.v_Name;
                oOrganization.v_Address = organization.v_Address;
                oOrganization.v_PhoneNumber = organization.v_PhoneNumber;
                oOrganization.v_Mail = organization.v_Mail;
                oOrganization.v_ContacName = organization.v_ContacName;
                oOrganization.v_Contacto = organization.v_Contacto;
                oOrganization.v_EmailContacto = organization.v_EmailContacto;
                oOrganization.v_Observation = organization.v_Observation;
                oOrganization.i_NumberQuotasOrganization = organization.i_NumberQuotasOrganization;
                oOrganization.i_NumberQuotasMen = organization.i_NumberQuotasMen;
                oOrganization.i_NumberQuotasWomen = organization.i_NumberQuotasWomen;
                oOrganization.i_DepartmentId = organization.i_DepartmentId;
                oOrganization.i_ProvinceId = organization.i_ProvinceId;
                oOrganization.i_DistrictId = organization.i_DistrictId;
                oOrganization.b_Image = organization.b_Image;
                oOrganization.v_ContactoMedico = organization.v_ContactoMedico;
                oOrganization.v_EmailMedico = organization.v_EmailMedico;

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

        public bool DeleteOrganization(string organizationId, int systemUserId)
        {
            try
            {
                var oOrganization = (from a in ctx.Organization
                                     where a.v_OrganizationId == organizationId
                                     select a).FirstOrDefault();

                if (oOrganization == null)
                    return false;

                oOrganization.i_UpdateUserId = systemUserId;
                oOrganization.d_UpdateDate = DateTime.UtcNow;
                oOrganization.i_IsDeleted = (int)Enumeratores.SiNo.Si;

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
