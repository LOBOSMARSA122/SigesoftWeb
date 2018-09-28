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
    public class OccupationBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public OccupationBE GetGes(string occupationId)
        {
            try
            {
                var objEntity = (from a in ctx.Occupation
                                 where a.OccupationId == occupationId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<OccupationBE> GetAllOccupation()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Occupation
                                 where a.IsDeleted == isDelete
                                 select new OccupationBE()
                                 {
                                     OccupationId = a.OccupationId,
                                     GesId = a.GesId,
                                     GroupOccupationId = a.GroupOccupationId,
                                     Name = a.Name,
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

        public bool AddOccupation(OccupationBE occupation, int systemUserId)
        {
            try
            {
                OccupationBE oOccupationBE = new OccupationBE()
                {
                    OccupationId =  new Utils().GetPrimaryKey(1, 12, "OE"),
                    GesId = occupation.GesId,
                    GroupOccupationId = occupation.GroupOccupationId,
                    Name = occupation.Name,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.Occupation.Add(oOccupationBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateOccupation(OccupationBE occupation, int systemUserId)
        {
            try
            {
                var oOccupation = (from a in ctx.Occupation
                                   where a.OccupationId == occupation.OccupationId
                                   select a).FirstOrDefault();

                if (oOccupation == null)
                    return false;

                oOccupation.GesId = occupation.GesId;
                oOccupation.GroupOccupationId = occupation.GroupOccupationId;
                oOccupation.Name = occupation.Name;

                //Auditoria

                oOccupation.UpdateDate = DateTime.UtcNow;
                oOccupation.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteOccupation(string occupationId, int systemUserId)
        {
            try
            {
                var oOccupation = (from a in ctx.Occupation
                                   where a.OccupationId == occupationId
                                   select a).FirstOrDefault();

                if (oOccupation == null)
                    return false;

                oOccupation.UpdateUserId = systemUserId;
                oOccupation.UpdateDate = DateTime.UtcNow;
                oOccupation.IsDeleted = (int)Enumeratores.SiNo.Si;

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
