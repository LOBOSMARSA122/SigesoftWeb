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
    public class ComponentBL
    {
        public DatabaseContext ctx = new DatabaseContext();
        #region CRUD
        public ComponentBE GetComponent(string componentId)
        {
            try
            {
                var objEntity = (from a in ctx.Component
                                 where a.ComponentId == componentId
                                 select a).FirstOrDefault();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ComponentBE> GetAllComponent()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Component
                                 where a.IsDeleted == isDelete
                                 select new ComponentBE()
                                 {
                                     ComponentId = a.ComponentId,
                                     Name = a.Name,
                                     CategoryId = a.CategoryId,
                                     BasePrice = a.BasePrice,
                                     DiagnosableId = a.DiagnosableId,
                                     IsApprovedId = a.IsApprovedId,
                                     ComponentTypeId = a.ComponentTypeId,
                                     UIIsVisibleId = a.UIIsVisibleId,
                                     UIIndex = a.UIIndex,
                                     ValidInDays = a.ValidInDays,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateUserId = a.UpdateUserId,
                                     UpdateDate = a.UpdateDate,
                                     IdUnidadProductiva = a.IdUnidadProductiva,
                                 }).ToList();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddComponent(ComponentBE component, int systemUserId)
        {
            try
            {
                ComponentBE oComponentBE = new ComponentBE()
                {
                    ComponentId = BE.Utils.GetPrimaryKey(1, 17, "ME"),
                    Name = component.Name,
                    CategoryId = component.CategoryId,
                    BasePrice = component.BasePrice,
                    DiagnosableId = component.DiagnosableId,
                    IsApprovedId = component.IsApprovedId,
                    ComponentTypeId = component.ComponentTypeId,
                    UIIsVisibleId = component.UIIsVisibleId,
                    UIIndex = component.UIIndex,
                    ValidInDays = component.ValidInDays,
                    IdUnidadProductiva = component.IdUnidadProductiva,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };
                ctx.Component.Add(oComponentBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateComponent(ComponentBE component, int systemUserId)
        {
            try
            {
                var oComponent = (from a in ctx.Component
                                  where a.ComponentId == component.ComponentId
                                  select a).FirstOrDefault();
                if (oComponent == null)
                    return false;
                oComponent.Name = component.Name;
                oComponent.CategoryId = component.CategoryId;
                oComponent.BasePrice = component.BasePrice;
                oComponent.DiagnosableId = component.DiagnosableId;
                oComponent.IsApprovedId = component.IsApprovedId;
                oComponent.ComponentTypeId = component.ComponentTypeId;
                oComponent.UIIsVisibleId = component.UIIsVisibleId;
                oComponent.UIIndex = component.UIIndex;
                oComponent.ValidInDays = component.ValidInDays;

                //Auditoria
                oComponent.UpdateDate = DateTime.UtcNow;
                oComponent.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteComponent(string componentId, int systemUserId)
        {
            try
            {
                var oComponent = (from a in ctx.Component
                                  where a.ComponentId == componentId
                                  select a).FirstOrDefault();

                if (oComponent == null)
                    return false;

                oComponent.UpdateUserId = systemUserId;
                oComponent.UpdateDate = DateTime.UtcNow;
                oComponent.IsDeleted = (int)Enumeratores.SiNo.Si;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

    }
}
