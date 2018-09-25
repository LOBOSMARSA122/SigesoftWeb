using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class RecommendationBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public RecommendationBE GetRecommendation(string recommendationId)
        {
            try
            {
                var objEntity = (from a in ctx.Recommendation
                                 where a.RecommendationId == recommendationId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<RecommendationBE> GetAllRecommendation()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Recommendation
                                 where a.IsDeleted == isDelete
                                 select new RecommendationBE()
                                 {
                                     RecommendationId = a.RecommendationId,
                                     ServiceId = a.ServiceId,
                                     DiagnosticRepositoryId = a.DiagnosticRepositoryId,
                                     ComponentId = a.ComponentId,
                                     MasterRecommendationId = a.MasterRecommendationId,
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

        public bool AddRecommendation(RecommendationBE recommendation, int systemUserId)
        {
            try
            {
                RecommendationBE oRecommendationBE = new RecommendationBE()
                {
                    RecommendationId =  new Common.PersonBL().GetPrimaryKey(1, 32, "RR"),
                    ServiceId = recommendation.ServiceId,
                    DiagnosticRepositoryId = recommendation.DiagnosticRepositoryId,
                    ComponentId = recommendation.ComponentId,
                    MasterRecommendationId = recommendation.MasterRecommendationId,
                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.Recommendation.Add(oRecommendationBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRecommendation(RecommendationBE recommendation, int systemUserId)
        {
            try
            {
                var oRecommendation = (from a in ctx.Recommendation
                                       where a.RecommendationId == recommendation.RecommendationId
                                       select a).FirstOrDefault();

                if (oRecommendation == null)
                    return false;

                oRecommendation.ServiceId = recommendation.ServiceId;
                oRecommendation.DiagnosticRepositoryId = recommendation.DiagnosticRepositoryId;
                oRecommendation.ComponentId = recommendation.ComponentId;
                oRecommendation.MasterRecommendationId = recommendation.MasterRecommendationId;

                //Auditoria

                oRecommendation.UpdateDate = DateTime.UtcNow;
                oRecommendation.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRecommendation(string recommendationId, int systemUserId)
        {
            try
            {
                var oRecommendation = (from a in ctx.Recommendation
                            where a.RecommendationId == recommendationId
                            select a).FirstOrDefault();

                if (oRecommendation == null)
                    return false;

                oRecommendation.UpdateUserId = systemUserId;
                oRecommendation.UpdateDate = DateTime.UtcNow;
                oRecommendation.IsDeleted = (int)Enumeratores.SiNo.Si;

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
