using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AttentionInAreaBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public AttentionInAreaBE GetAttentionInArea(string attentionInAreaId)
        {
            try
            {
                var objEntity = (from a in ctx.AttentionInArea
                                 where a.AttentionInAreaId == attentionInAreaId
                                 select a).FirstOrDefault();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AttentionInAreaBE> GetAllAttentionInArea()
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.AttentionInArea
                                 where a.IsDeleted == isDeleted
                                 select new AttentionInAreaBE()
                                 {
                                    AttentionInAreaId = a.AttentionInAreaId,
                                    NodeId = a.NodeId,
                                    Name = a.Name,
                                    OfficeNumber = a.OfficeNumber,
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

        public bool AddAttentionInArea(AttentionInAreaBE attentionInArea, int systemUserId)
        {
            try
            {
                AttentionInAreaBE oAttentionInAreaBE = new AttentionInAreaBE()
                {
                    //PK
                    AttentionInAreaId = BE.Utils.GetPrimaryKey(1, 26, "AA"),
                    NodeId = attentionInArea.NodeId,
                    Name = attentionInArea.Name,
                    OfficeNumber = attentionInArea.OfficeNumber,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };

                ctx.AttentionInArea.Add(oAttentionInAreaBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateAttentionInArea(AttentionInAreaBE attentionInArea, int systemUserId)
        {
            try
            {
                var oAttentionInArea = (from a in ctx.AttentionInArea where a.AttentionInAreaId == attentionInArea.AttentionInAreaId select a).FirstOrDefault();

                if (oAttentionInArea == null)
                    return false;

                oAttentionInArea.NodeId       = attentionInArea.NodeId;
                oAttentionInArea.Name         = attentionInArea.Name;
                oAttentionInArea.OfficeNumber = attentionInArea.OfficeNumber;

                //Auditoria
                oAttentionInArea.UpdateDate = DateTime.UtcNow;
                oAttentionInArea.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        public bool DeleteAttentionInArea(string attentionInAreaId, int systemUserId)
        {
            try
            {
                var oAttentionInArea = (from a in ctx.AttentionInArea where a.AttentionInAreaId == attentionInAreaId select a).FirstOrDefault();

                if (oAttentionInArea == null)
                    return false;

                oAttentionInArea.UpdateUserId = systemUserId;
                oAttentionInArea.UpdateDate = DateTime.UtcNow;
                oAttentionInArea.IsDeleted = (int)Enumeratores.SiNo.Si;

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
