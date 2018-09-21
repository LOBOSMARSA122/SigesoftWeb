using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class RoleNodeComponentProfileBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public RoleNodeComponentProfileBE GetRoleNodeComponentProfile(string roleNodeComponentProfileId)
        {
            try
            {
                var objEntity = (from a in ctx.RoleNodeComponentProfile
                                 where a.RoleNodeComponentId == roleNodeComponentProfileId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<RoleNodeComponentProfileBE> GetAllRoleNodeComponentProfile()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.RoleNodeComponentProfile
                                 where a.IsDeleted == isDelete
                                 select new RoleNodeComponentProfileBE()
                                 {
                                     RoleNodeComponentId = a.RoleNodeComponentId,
                                     NodeId = a.NodeId,
                                     RoleId = a.RoleId,
                                     ComponentId = a.ComponentId,
                                     Read = a.Read,
                                     Write = a.Write,
                                     Dx = a.Dx,
                                     Approved = a.Approved,
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

        public bool AddRoleNodeComponentProfile(RoleNodeComponentProfileBE roleNodeComponentProfile, int systemUserId)
        {
            try
            {
                RoleNodeComponentProfileBE oRoleNodeComponentProfileBE = new RoleNodeComponentProfileBE()
                {
                    RoleNodeComponentId = BE.Utils.GetPrimaryKey(1, 26, "RC"),
                    NodeId = roleNodeComponentProfile.NodeId,
                    RoleId = roleNodeComponentProfile.RoleId,
                    ComponentId = roleNodeComponentProfile.ComponentId,
                    Read = roleNodeComponentProfile.Read,
                    Write = roleNodeComponentProfile.Write,
                    Dx = roleNodeComponentProfile.Dx,
                    Approved = roleNodeComponentProfile.Approved,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.RoleNodeComponentProfile.Add(oRoleNodeComponentProfileBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRoleNodeComponentProfile(RoleNodeComponentProfileBE roleNodeComponentProfile, int systemUserId)
        {
            try
            {
                var oRoleNodeComponentProfile = (from a in ctx.RoleNodeComponentProfile
                                                 where a.RoleNodeComponentId == roleNodeComponentProfile.RoleNodeComponentId
                                                 select a).FirstOrDefault();

                if (oRoleNodeComponentProfile == null)
                    return false;

                oRoleNodeComponentProfile.NodeId = roleNodeComponentProfile.NodeId;
                oRoleNodeComponentProfile.RoleId = roleNodeComponentProfile.RoleId;
                oRoleNodeComponentProfile.ComponentId = roleNodeComponentProfile.ComponentId;
                oRoleNodeComponentProfile.Read = roleNodeComponentProfile.Read;
                oRoleNodeComponentProfile.Write = roleNodeComponentProfile.Write;
                oRoleNodeComponentProfile.Dx = roleNodeComponentProfile.Dx;
                oRoleNodeComponentProfile.Approved = roleNodeComponentProfile.Approved;

                //Auditoria

                oRoleNodeComponentProfile.UpdateDate = DateTime.UtcNow;
                oRoleNodeComponentProfile.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRoleNodeComponentProfile(string roleNodeComponentProfileId, int systemUserId)
        {
            try
            {
                var oRoleNodeComponentProfile = (from a in ctx.RoleNodeComponentProfile
                                                 where a.RoleNodeComponentId == roleNodeComponentProfileId
                                                 select a).FirstOrDefault();

                if (oRoleNodeComponentProfile == null)
                    return false;

                oRoleNodeComponentProfile.UpdateUserId = systemUserId;
                oRoleNodeComponentProfile.UpdateDate = DateTime.UtcNow;
                oRoleNodeComponentProfile.IsDeleted = (int)Enumeratores.SiNo.Si;

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
