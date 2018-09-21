using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class NodeServiceProfileBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public NodeServiceProfileBE GetNodeServiceProfile(string nodeServiceProfileId)
        {
            try
            {
                var objEntity = (from a in ctx.NodeServiceProfile
                                 where a.NodeServiceProfileId == nodeServiceProfileId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<NodeServiceProfileBE> GetAllNodeServiceProfile()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.NodeServiceProfile
                                 where a.IsDeleted == isDelete
                                 select new NodeServiceProfileBE()
                                 {
                                     NodeServiceProfileId = a.NodeServiceProfileId,
                                     NodeId = a.NodeId,
                                     ServiceTypeId = a.ServiceTypeId,
                                     MasterServiceId = a.MasterServiceId,
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

        public bool AddNodeServiceProfile(NodeServiceProfileBE nodeServiceProfile, int systemUserId)
        {
            try
            {
                NodeServiceProfileBE oNodeServiceProfileBE = new NodeServiceProfileBE()
                {
                    NodeServiceProfileId = BE.Utils.GetPrimaryKey(1, 25, "NS"),
                    NodeId = nodeServiceProfile.NodeId,
                    ServiceTypeId = nodeServiceProfile.ServiceTypeId,
                    MasterServiceId = nodeServiceProfile.MasterServiceId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.NodeServiceProfile.Add(oNodeServiceProfileBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateNodeServiceProfile(NodeServiceProfileBE nodeServiceProfile, int systemUserId)
        {
            try
            {
                var oNodeServiceProfile = (from a in ctx.NodeServiceProfile
                            where a.NodeServiceProfileId == nodeServiceProfile.NodeServiceProfileId
                                           select a).FirstOrDefault();

                if (oNodeServiceProfile == null)
                    return false;

                oNodeServiceProfile.NodeId = nodeServiceProfile.NodeId;
                oNodeServiceProfile.ServiceTypeId = nodeServiceProfile.ServiceTypeId;
                oNodeServiceProfile.MasterServiceId = nodeServiceProfile.MasterServiceId;

                //Auditoria

                oNodeServiceProfile.UpdateDate = DateTime.UtcNow;
                oNodeServiceProfile.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteNodeServiceProfile(string nodeServiceProfileId, int systemUserId)
        {
            try
            {
                var oNodeServiceProfile = (from a in ctx.NodeServiceProfile
                                           where a.NodeServiceProfileId == nodeServiceProfileId
                                           select a).FirstOrDefault();

                if (oNodeServiceProfile == null)
                    return false;

                oNodeServiceProfile.UpdateUserId = systemUserId;
                oNodeServiceProfile.UpdateDate = DateTime.UtcNow;
                oNodeServiceProfile.IsDeleted = (int)Enumeratores.SiNo.Si;

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
