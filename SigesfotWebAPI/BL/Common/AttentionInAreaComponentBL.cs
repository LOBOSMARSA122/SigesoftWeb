using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class AttentionInAreaComponentBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public AttentionInAreaComponentBE GetAttentionInAreaComponent (string attentionInAreaComponentId)
        {
            try
            {
                var objEntity = (from a in ctx.AttentionInAreaComponent
                                 where a.AttentioninAreaComponentId == attentionInAreaComponentId
                                 select a).FirstOrDefault();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AttentionInAreaComponentBE> GetAllAttentionInAreaComponent()
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.AttentionInAreaComponent
                                 where a.IsDeleted == isDeleted
                                 select new AttentionInAreaComponentBE()
                                 {
                                     AttentioninAreaComponentId = a.AttentioninAreaComponentId,
                                     AttentionInAreaId = a.AttentionInAreaId,
                                     ComponentId = a.ComponentId,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateUserId = a.UpdateUserId,
                                     UpdateDate = a.UpdateDate,
                                 }).ToList();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddAttentionInAreaComponent(AttentionInAreaComponentBE attentionInAreaComponent, int systemUserId)
        {
            try
            {
                AttentionInAreaComponentBE oAttentionInAreaComponentBE = new AttentionInAreaComponentBE()
                {
                    AttentioninAreaComponentId =   new Utils().GetPrimaryKey(1, 47, "AC"),
                    AttentionInAreaId = attentionInAreaComponent.AttentionInAreaId,
                    ComponentId = attentionInAreaComponent.ComponentId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };
                ctx.AttentionInAreaComponent.Add(oAttentionInAreaComponentBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateAttentionInareaComponent(AttentionInAreaComponentBE attentionInAreaComponent, int systemUserId)
        {
            try
            {
                var oAttentionInAreaComponent = (from a in ctx.AttentionInAreaComponent
                                                 where a.AttentioninAreaComponentId == attentionInAreaComponent.AttentionInAreaId
                                                 select a).FirstOrDefault();
                if (oAttentionInAreaComponent == null)
                    return false;

                oAttentionInAreaComponent.AttentionInAreaId = attentionInAreaComponent.AttentionInAreaId;
                oAttentionInAreaComponent.ComponentId = attentionInAreaComponent.ComponentId;
                //Auditoria
                oAttentionInAreaComponent.UpdateDate = DateTime.UtcNow;
                oAttentionInAreaComponent.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteAttentionInAreaComponent(string attentionInAreaComponentId, int systemUserId)
        {
            try
            {
                var oAttentionInAreaComponent = (from a in ctx.AttentionInAreaComponent
                                                 where a.AttentioninAreaComponentId == attentionInAreaComponentId
                                                 select a).FirstOrDefault();
                if (oAttentionInAreaComponent == null)
                    return false;

                oAttentionInAreaComponent.UpdateUserId = systemUserId;
                oAttentionInAreaComponent.UpdateDate = DateTime.UtcNow;
                oAttentionInAreaComponent.IsDeleted = (int)Enumeratores.SiNo.Si;

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
