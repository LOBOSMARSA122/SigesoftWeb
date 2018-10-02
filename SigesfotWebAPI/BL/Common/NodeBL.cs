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
                                 where a.i_NodeId == nodeId
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
                                 where a.i_IsDeleted == isDelete
                                 select new NodeBE()
                                 {
                                     i_NodeId = a.i_NodeId,
                                     v_Description = a.v_Description,
                                     v_GeografyLocationId = a.v_GeografyLocationId,
                                     v_GeografyLocationDescription = a.v_GeografyLocationDescription,
                                     i_NodeTypeId = a.i_NodeTypeId,
                                     d_BeginDate = a.d_BeginDate,
                                     d_EndDate = a.d_EndDate,
                                     v_PharmacyWarehouseId = a.v_PharmacyWarehouseId,
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

        public bool AddNode(NodeBE node, int systemUserId)
        {
            try
            {
                NodeBE oNodeBE = new NodeBE()
                {
                    //NodeId =  new Utils().GetPrimaryKey(no usa),
                    v_Description = node.v_Description,
                    v_GeografyLocationId = node.v_GeografyLocationId,
                    v_GeografyLocationDescription = node.v_GeografyLocationDescription,
                    i_NodeTypeId = node.i_NodeTypeId,
                    d_BeginDate = node.d_BeginDate,
                    d_EndDate = node.d_EndDate,
                    v_PharmacyWarehouseId = node.v_PharmacyWarehouseId,

                    //Auditoria
                    i_IsDeleted = (int)Enumeratores.SiNo.No,
                    d_InsertDate = DateTime.UtcNow,
                    i_InsertUserId = systemUserId,
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
                            where a.i_NodeId == node.i_NodeId
                             select a).FirstOrDefault();

                if (oNode == null)
                    return false;

                oNode.v_Description = node.v_Description;
                oNode.v_GeografyLocationId = node.v_GeografyLocationId;
                oNode.v_GeografyLocationDescription = node.v_GeografyLocationDescription;
                oNode.i_NodeTypeId = node.i_NodeTypeId;
                oNode.d_BeginDate = node.d_BeginDate;
                oNode.d_EndDate = node.d_EndDate;
                oNode.v_PharmacyWarehouseId = node.v_PharmacyWarehouseId;

                //Auditoria

                oNode.d_UpdateDate = DateTime.UtcNow;
                oNode.i_UpdateUserId = systemUserId;

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
                            where a.i_NodeId == nodeId
                            select a).FirstOrDefault();

                if (oNode == null)
                    return false;

                oNode.i_UpdateUserId = systemUserId;
                oNode.d_UpdateDate = DateTime.UtcNow;
                oNode.i_IsDeleted = (int)Enumeratores.SiNo.Si;

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
