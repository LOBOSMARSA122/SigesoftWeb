using BE.Common;
using BE.Protocol;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Protocol
{
    public class ProtocolSystemUserBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public ProtocolSystemUserBE GetProtocolSystemUser(string protocolSystemUserId)
        {
            try
            {
                var objEntity = (from a in ctx.ProtocolSystemUser
                                 where a.ProtocolSystemUserId == protocolSystemUserId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ProtocolSystemUserBE> GetAllProtocolSystemUser()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.ProtocolSystemUser
                                 where a.IsDeleted == isDelete
                                 select new ProtocolSystemUserBE()
                                 {
                                     ProtocolSystemUserId = a.ProtocolSystemUserId,
                                     SystemUserId = a.SystemUserId,
                                     ProtocolId = a.ProtocolId,
                                     ApplicationHierarchyId = a.ApplicationHierarchyId,
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

        public bool AddProtocolSystemUser(ProtocolSystemUserBE protocolSystemUser, int systemUserId)
        {
            try
            {
                ProtocolSystemUserBE oProtocolSystemUserBE = new ProtocolSystemUserBE()
                {
                    ProtocolSystemUserId =  new Utils().GetPrimaryKey(1, 44, "PU"),
                    SystemUserId = protocolSystemUser.SystemUserId,
                    ProtocolId = protocolSystemUser.ProtocolId,
                    ApplicationHierarchyId = protocolSystemUser.ApplicationHierarchyId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.ProtocolSystemUser.Add(oProtocolSystemUserBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateProtocolSystemUser(ProtocolSystemUserBE protocolSystemUser, int systemUserId)
        {
            try
            {
                var oProtocolSystemUser = (from a in ctx.ProtocolSystemUser
                            where a.ProtocolSystemUserId == protocolSystemUser.ProtocolSystemUserId
                            select a).FirstOrDefault();

                if (oProtocolSystemUser == null)
                    return false;

                oProtocolSystemUser.SystemUserId = protocolSystemUser.SystemUserId;
                oProtocolSystemUser.ProtocolId = protocolSystemUser.ProtocolId;
                oProtocolSystemUser.ApplicationHierarchyId = protocolSystemUser.ApplicationHierarchyId;
                //Auditoria

                oProtocolSystemUser.UpdateDate = DateTime.UtcNow;
                oProtocolSystemUser.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteProtocolSystemUser(string protocolSystemUserId, int systemUserId)
        {
            try
            {
                var oProtocolSystemUser = (from a in ctx.ProtocolSystemUser
                                           where a.ProtocolSystemUserId == protocolSystemUserId
                                           select a).FirstOrDefault();

                if (oProtocolSystemUser == null)
                    return false;

                oProtocolSystemUser.UpdateUserId = systemUserId;
                oProtocolSystemUser.UpdateDate = DateTime.UtcNow;
                oProtocolSystemUser.IsDeleted = (int)Enumeratores.SiNo.Si;

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
