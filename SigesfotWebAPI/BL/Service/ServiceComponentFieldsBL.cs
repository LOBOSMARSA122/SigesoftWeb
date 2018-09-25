using BE.Common;
using BE.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service
{
    public class ServiceComponentFieldsBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public ServiceComponentFieldsBE GetServiceComponentFields(string serviceComponentFieldsId)
        {
            try
            {
                var objEntity = (from a in ctx.ServiceComponentFields
                                 where a.ServiceComponentFieldsId == serviceComponentFieldsId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ServiceComponentFieldsBE> GetAllServiceComponentFields()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.ServiceComponentFields
                                 where a.IsDeleted == isDelete
                                 select new ServiceComponentFieldsBE()
                                 {
                                     ServiceComponentFieldsId = a.ServiceComponentFieldsId,
                                     ServiceComponentId = a.ServiceComponentId,
                                     ComponentId = a.ComponentId,
                                     ComponentFieldId = a.ComponentFieldId,
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

        public bool AddServiceComponentFields(ServiceComponentFieldsBE serviceComponentFields, int systemUserId)
        {
            try
            {
                ServiceComponentFieldsBE oServiceComponentFieldsBE = new ServiceComponentFieldsBE()
                {
                    ServiceComponentFieldsId =  new Common.PersonBL().GetPrimaryKey(1, 35, "CF"),
                    ServiceComponentId = serviceComponentFields.ServiceComponentId,
                    ComponentId = serviceComponentFields.ComponentId,
                    ComponentFieldId = serviceComponentFields.ComponentFieldId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.ServiceComponentFields.Add(oServiceComponentFieldsBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateServiceComponentFields(ServiceComponentFieldsBE serviceComponentFields, int systemUserId)
        {
            try
            {
                var oServiceComponentFields = (from a in ctx.ServiceComponentFields
                                               where a.ServiceComponentFieldsId == serviceComponentFields.ServiceComponentFieldsId
                                               select a).FirstOrDefault();

                if (oServiceComponentFields == null)
                    return false;

                oServiceComponentFields.ServiceComponentId = serviceComponentFields.ServiceComponentId;
                oServiceComponentFields.ComponentId = serviceComponentFields.ComponentId;
                oServiceComponentFields.ComponentFieldId = serviceComponentFields.ComponentFieldId;

                //Auditoria

                oServiceComponentFields.UpdateDate = DateTime.UtcNow;
                oServiceComponentFields.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteServiceComponentFields(string serviceComponentFieldsId, int systemUserId)
        {
            try
            {
                var oServiceComponentFields = (from a in ctx.ServiceComponentFields
                                               where a.ServiceComponentFieldsId == serviceComponentFieldsId
                                               select a).FirstOrDefault();

                if (oServiceComponentFields == null)
                    return false;

                oServiceComponentFields.UpdateUserId = systemUserId;
                oServiceComponentFields.UpdateDate = DateTime.UtcNow;
                oServiceComponentFields.IsDeleted = (int)Enumeratores.SiNo.Si;

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
