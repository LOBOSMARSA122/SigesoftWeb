using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class NodeBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public NodeBE GetNode(int nodeId)
        {
            try
            {
                var objEntity = (from a in ctx.Node
                                 where a.NodeId == nodeId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<NodeBE> GetAllNode()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Node
                                 where a.IsDeleted == isDelete
                                 select new NodeBE()
                                 {
                                     NodeId = a.NodeId,
                                     Description = a.Description,
                                     GeografyLocationId = a.GeografyLocationId,
                                     GeografyLocationDescription = a.GeografyLocationDescription,
                                     NodeTypeId = a.NodeTypeId,
                                     BeginDate = a.BeginDate,
                                     EndDate = a.EndDate,
                                     PharmacyWarehouseId = a.PharmacyWarehouseId,
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

        public bool AddNode(NodeBE node, int systemUserId)
        {
            try
            {
                NodeBE oNodeBE = new NodeBE()
                {
                    //NodeId =  new Common.PersonBL().GetPrimaryKey(no usa),
                    Description = node.Description,
                    GeografyLocationId = node.GeografyLocationId,
                    GeografyLocationDescription = node.GeografyLocationDescription,
                    NodeTypeId = node.NodeTypeId,
                    BeginDate = node.BeginDate,
                    EndDate = node.EndDate,
                    PharmacyWarehouseId = node.PharmacyWarehouseId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.Node.Add(oNodeBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateNode(NodeBE node, int systemUserId)
        {
            try
            {
                var oNode = (from a in ctx.Node
                            where a.NodeId == node.NodeId
                             select a).FirstOrDefault();

                if (oNode == null)
                    return false;

                oNode.Description = node.Description;
                oNode.GeografyLocationId = node.GeografyLocationId;
                oNode.GeografyLocationDescription = node.GeografyLocationDescription;
                oNode.NodeTypeId = node.NodeTypeId;
                oNode.BeginDate = node.BeginDate;
                oNode.EndDate = node.EndDate;
                oNode.PharmacyWarehouseId = node.PharmacyWarehouseId;

                //Auditoria

                oNode.UpdateDate = DateTime.UtcNow;
                oNode.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteNode(int nodeId, int systemUserId)
        {
            try
            {
                var oNode = (from a in ctx.Node
                            where a.NodeId == nodeId
                            select a).FirstOrDefault();

                if (oNode == null)
                    return false;

                oNode.UpdateUserId = systemUserId;
                oNode.UpdateDate = DateTime.UtcNow;
                oNode.IsDeleted = (int)Enumeratores.SiNo.Si;

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
