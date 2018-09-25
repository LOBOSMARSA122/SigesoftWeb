using BE.Common;
using BE.Component;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Component
{
    public class ComponentFieldsBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public ComponentFieldsBE GetComponentFields(string componentId, string componentFieldsId)
        {
            try
            {
                var objEntity = (from a in ctx.ComponentFields
                                 where a.ComponentId == componentId && a.ComponentFieldId == componentFieldsId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ComponentFieldsBE> GetAllComponentFields()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.ComponentFields
                                 where a.IsDeleted == isDelete
                                 select new ComponentFieldsBE()
                                 {
                                     ComponentId = a.ComponentId,
                                     ComponentFieldId = a.ComponentFieldId,
                                     Group = a.Group,
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

        public bool AddComponentFields(ComponentFieldsBE componentFields, int systemUserId)
        {
            try
            {
                ComponentFieldsBE oComponentFieldsBE = new ComponentFieldsBE()
                {
                    //ComponentId =  new Common.PersonBL().GetPrimaryKey(no usa),
                    //ComponentFieldId = componentFields.ComponentFieldId (llave compuesta),
                    Group = componentFields.Group,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.ComponentFields.Add(oComponentFieldsBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateComponentFields(ComponentFieldsBE  componentFields, int systemUserId)
        {
            try
            {
                var oComponentFields = (from a in ctx.ComponentFields
                                        where a.ComponentId == componentFields.ComponentId && a.ComponentFieldId == componentFields.ComponentFieldId
                                        select a).FirstOrDefault();

                if (oComponentFields == null)
                    return false;

                oComponentFields.Group = componentFields.Group;

                //Auditoria

                oComponentFields.UpdateDate = DateTime.UtcNow;
                oComponentFields.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteComponentFields(string componentId, string componentFieldsId, int systemUserId)
        {
            try
            {
                var oComponentFields = (from a in ctx.ComponentFields
                                        where a.ComponentId == componentId && a.ComponentFieldId == componentFieldsId
                                        select a).FirstOrDefault();

                if (oComponentFields == null)
                    return false;

                oComponentFields.UpdateUserId = systemUserId;
                oComponentFields.UpdateDate = DateTime.UtcNow;
                oComponentFields.IsDeleted = (int)Enumeratores.SiNo.Si;

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
