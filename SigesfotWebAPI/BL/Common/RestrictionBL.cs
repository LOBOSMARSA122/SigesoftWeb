using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class RestrictionBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public RestrictionBE GetRestriction(string restrictionId)
        {
            try
            {
                var objEntity = (from a in ctx.Restriction
                                 where a.RestrictionId == restrictionId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<RestrictionBE> GetAllRestriction()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Restriction
                                 where a.IsDeleted == isDelete
                                 select new RestrictionBE()
                                 {
                                     RestrictionId = a.RestrictionId,
                                     DiagnosticRepositoryId = a.DiagnosticRepositoryId,
                                     ServiceId = a.ServiceId,
                                     ComponentId = a.ComponentId,
                                     MasterRestrictionId = a.MasterRestrictionId,
                                     StartDateRestriction = a.StartDateRestriction,
                                     EndDateRestriction = a.EndDateRestriction,
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

        public bool AddRestriction(RestrictionBE restriction, int systemUserId)
        {
            try
            {
                RestrictionBE oRestrictionBE = new RestrictionBE()
                {
                    RestrictionId = BE.Utils.GetPrimaryKey(1, 30, "RD"),
                    DiagnosticRepositoryId = restriction.DiagnosticRepositoryId,
                    ServiceId = restriction.ServiceId,
                    ComponentId = restriction.ComponentId,
                    MasterRestrictionId = restriction.MasterRestrictionId,
                    StartDateRestriction = restriction.StartDateRestriction,
                    EndDateRestriction = restriction.EndDateRestriction,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.Restriction.Add(oRestrictionBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRestriction(RestrictionBE restriction, int systemUserId)
        {
            try
            {
                var oRestriction = (from a in ctx.Restriction
                                    where a.RestrictionId == restriction.RestrictionId
                                    select a).FirstOrDefault();

                if (oRestriction == null)
                    return false;

                oRestriction.DiagnosticRepositoryId = restriction.DiagnosticRepositoryId;
                oRestriction.ServiceId = restriction.ServiceId;
                oRestriction.ComponentId = restriction.ComponentId;
                oRestriction.MasterRestrictionId = restriction.MasterRestrictionId;
                oRestriction.StartDateRestriction = restriction.StartDateRestriction;
                oRestriction.EndDateRestriction = restriction.EndDateRestriction;

                //Auditoria

                oRestriction.UpdateDate = DateTime.UtcNow;
                oRestriction.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRestriction(string restrictionId, int systemUserId)
        {
            try
            {
                var oRestriction = (from a in ctx.Restriction
                            where a.RestrictionId == restrictionId
                                    select a).FirstOrDefault();

                if (oRestriction == null)
                    return false;

                oRestriction.UpdateUserId = systemUserId;
                oRestriction.UpdateDate = DateTime.UtcNow;
                oRestriction.IsDeleted = (int)Enumeratores.SiNo.Si;

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
