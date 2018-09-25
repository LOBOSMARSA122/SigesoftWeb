using BE.Common;
using BE.Organization;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Organization
{
    public class GroupOccupationBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public GroupOccupationBE GetGroupOccupation(string groupOccupationId)
        {
            try
            {
                var objEntity = (from a in ctx.GroupOccupation
                                 where a.GroupOccupationId == groupOccupationId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GroupOccupationBE> GetAllGroupOccupation()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.GroupOccupation
                                 where a.IsDeleted == isDelete
                                 select new GroupOccupationBE()
                                 {
                                     GroupOccupationId = a.GroupOccupationId,
                                     LocationId = a.LocationId,
                                     Name = a.Name,
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

        public bool AddGroupOccupation(GroupOccupationBE groupOccupation, int systemUserId)
        {
            try
            {
                GroupOccupationBE oGroupOccupationBE = new GroupOccupationBE()
                {
                    GroupOccupationId =  new Common.PersonBL().GetPrimaryKey(1, 13, "OG"),
                    LocationId = groupOccupation.LocationId,
                    Name = groupOccupation.Name,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.GroupOccupation.Add(oGroupOccupationBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateGroupOccupation(GroupOccupationBE groupOccupation, int systemUserId)
        {
            try
            {
                var oGroupOccupation = (from a in ctx.GroupOccupation
                                        where a.GroupOccupationId == groupOccupation.GroupOccupationId
                                        select a).FirstOrDefault();

                if (oGroupOccupation == null)
                    return false;

                oGroupOccupation.LocationId = groupOccupation.LocationId;
                oGroupOccupation.Name = groupOccupation.Name;

                //Auditoria

                oGroupOccupation.UpdateDate = DateTime.UtcNow;
                oGroupOccupation.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteGroupOccupation(string groupOccupationId, int systemUserId)
        {
            try
            {
                var oGroupOccupation = (from a in ctx.GroupOccupation
                                        where a.GroupOccupationId == groupOccupationId
                                        select a).FirstOrDefault();

                if (oGroupOccupation == null)
                    return false;

                oGroupOccupation.UpdateUserId = systemUserId;
                oGroupOccupation.UpdateDate = DateTime.UtcNow;
                oGroupOccupation.IsDeleted = (int)Enumeratores.SiNo.Si;

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
