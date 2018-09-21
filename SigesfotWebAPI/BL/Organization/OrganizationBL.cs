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

        #region CRUD
        public OrganizationBE GetOrganization(string organizationId)
        {
            try
            {
                var objEntity = (from a in ctx.Organization
                                 where a.OrganizationId == organizationId
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
                                 where a.IsDeleted == isDelete
                                 select new OrganizationBE()
                                 {
                                     OrganizationId = a.OrganizationId,
                                     OrganizationTypeId = a.OrganizationTypeId,
                                     SectorTypeId = a.SectorTypeId,
                                     SectorName = a.SectorName,
                                     SectorCodigo = a.SectorCodigo,
                                     IdentificationNumber = a.IdentificationNumber,
                                     Name = a.Name,
                                     Address = a.Address,
                                     PhoneNumber = a.PhoneNumber,
                                     Mail = a.Mail,
                                     ContacName = a.ContacName,
                                     Contacto = a.Contacto,
                                     EmailContacto = a.EmailContacto,
                                     Observation = a.Observation,
                                     NumberQuotasOrganization = a.NumberQuotasOrganization,
                                     NumberQuotasMen = a.NumberQuotasMen,
                                     NumberQuotasWomen = a.NumberQuotasWomen,
                                     DepartmentId = a.DepartmentId,
                                     ProvinceId = a.ProvinceId,
                                     DistrictId = a.DistrictId,
                                     Image = a.Image,
                                     ContactoMedico = a.ContactoMedico,
                                     EmailMedico = a.EmailMedico,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateDate = a.UpdateDate,
                                     UpdateUserId = a.UpdateUserId
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
                    OrganizationId = BE.Utils.GetPrimaryKey(1, 5, "OO"),
                    OrganizationTypeId = organization.OrganizationTypeId,
                    SectorTypeId = organization.SectorTypeId,
                    SectorName = organization.SectorName,
                    SectorCodigo = organization.SectorCodigo,
                    IdentificationNumber = organization.IdentificationNumber,
                    Name = organization.Name,
                    Address = organization.Address,
                    PhoneNumber = organization.PhoneNumber,
                    Mail = organization.Mail,
                    ContacName = organization.ContacName,
                    Contacto = organization.Contacto,
                    EmailContacto = organization.EmailContacto,
                    Observation = organization.Observation,
                    NumberQuotasOrganization = organization.NumberQuotasOrganization,
                    NumberQuotasMen = organization.NumberQuotasMen,
                    NumberQuotasWomen = organization.NumberQuotasWomen,
                    DepartmentId = organization.DepartmentId,
                    ProvinceId = organization.ProvinceId,
                    DistrictId = organization.DistrictId,
                    Image = organization.Image,
                    ContactoMedico = organization.ContactoMedico,
                    EmailMedico = organization.EmailMedico,
                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
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
                            where a.OrganizationId == organization.OrganizationId
                            select a).FirstOrDefault();

                if (oOrganization == null)
                    return false;

                oOrganization.OrganizationTypeId = organization.OrganizationTypeId;
                oOrganization.SectorTypeId = organization.SectorTypeId;
                oOrganization.SectorName = organization.SectorName;
                oOrganization.SectorCodigo = organization.SectorCodigo;
                oOrganization.IdentificationNumber = organization.IdentificationNumber;
                oOrganization.Name = organization.Name;
                oOrganization.Address = organization.Address;
                oOrganization.PhoneNumber = organization.PhoneNumber;
                oOrganization.Mail = organization.Mail;
                oOrganization.ContacName = organization.ContacName;
                oOrganization.Contacto = organization.Contacto;
                oOrganization.EmailContacto = organization.EmailContacto;
                oOrganization.Observation = organization.Observation;
                oOrganization.NumberQuotasOrganization = organization.NumberQuotasOrganization;
                oOrganization.NumberQuotasMen = organization.NumberQuotasMen;
                oOrganization.NumberQuotasWomen = organization.NumberQuotasWomen;
                oOrganization.DepartmentId = organization.DepartmentId;
                oOrganization.ProvinceId = organization.ProvinceId;
                oOrganization.DistrictId = organization.DistrictId;
                oOrganization.Image = organization.Image;
                oOrganization.ContactoMedico = organization.ContactoMedico;
                oOrganization.EmailMedico = organization.EmailMedico;

                //Auditoria

                oOrganization.UpdateDate = DateTime.UtcNow;
                oOrganization.UpdateUserId = systemUserId;

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
                                     where a.OrganizationId == organizationId
                                     select a).FirstOrDefault();

                if (oOrganization == null)
                    return false;

                oOrganization.UpdateUserId = systemUserId;
                oOrganization.UpdateDate = DateTime.UtcNow;
                oOrganization.IsDeleted = (int)Enumeratores.SiNo.Si;

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
