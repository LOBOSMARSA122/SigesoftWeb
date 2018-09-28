using BE.Common;
using BE.Component;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Component
{
    public class ComponentFieldValuesRecommendationBL
    {
        private DatabaseContext ctx = new DatabaseContext();
        #region CRUD
        public ComponentFieldValuesRecommendationBE GetComponentFieldValuesRecommendation(string componentFieldValuesRecommendationId)
        {
            try
            {
                var objEntity = (from a in ctx.ComponentFieldValuesRecommendation
                                 where a.ComponentFieldValuesRecommendationId == componentFieldValuesRecommendationId
                                 select a).FirstOrDefault();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ComponentFieldValuesRecommendationBE> GetAllComponentFieldValuesRecommendation()
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.ComponentFieldValuesRecommendation
                                 where a.IsDeleted == isDeleted
                                 select new ComponentFieldValuesRecommendationBE()
                                 {
                                    ComponentFieldValuesRecommendationId = a.ComponentFieldValuesRecommendationId,
                                    ComponentFieldValuesId = a.ComponentFieldValuesId,
                                    MasterRecommendationRestricctionId = a.MasterRecommendationRestricctionId,
                                    IsDeleted = a.IsDeleted,
                                    InsertUserId = a.InsertUserId,
                                    InsertDate = a.InsertDate,
                                    UpdateUserId = a.UpdateUserId,
                                    UpdateDate = a.UpdateDate
    }).ToList();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddComponentFieldValuesRecommendation(ComponentFieldValuesRecommendationBE componentFieldValuesRecommendation, int systemUserId)
        {
            try
            {
                ComponentFieldValuesRecommendationBE oComponentFieldValuesRecommendationBE = new ComponentFieldValuesRecommendationBE()
                {
                    ComponentFieldValuesRecommendationId =  new Utils().GetPrimaryKey(1, 31, "VC"),
                    ComponentFieldValuesId = componentFieldValuesRecommendation.ComponentFieldValuesId,
                    MasterRecommendationRestricctionId = componentFieldValuesRecommendation.MasterRecommendationRestricctionId,


                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };

                ctx.ComponentFieldValuesRecommendation.Add(oComponentFieldValuesRecommendationBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateComponentFieldValuesRecommendation(ComponentFieldValuesRecommendationBE componentFieldValuesRecommendation, int systemUserId)
        {
            try
            {
                var oComponentFieldValuesRecommendation = (from a in ctx.ComponentFieldValuesRecommendation where a.ComponentFieldValuesRecommendationId == componentFieldValuesRecommendation.ComponentFieldValuesRecommendationId select a).FirstOrDefault();

                if (oComponentFieldValuesRecommendation == null)
                    return false;

                oComponentFieldValuesRecommendation.ComponentFieldValuesId = componentFieldValuesRecommendation.ComponentFieldValuesId;
                oComponentFieldValuesRecommendation.MasterRecommendationRestricctionId = componentFieldValuesRecommendation.MasterRecommendationRestricctionId;

                //Auditoria
                oComponentFieldValuesRecommendation.UpdateDate = DateTime.UtcNow;
                oComponentFieldValuesRecommendation.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool DeleteComponentFieldValuesRecommendation(string componentFieldValuesRecommendationId, int systemUserId)
        {
            try
            {
                var oComponentFieldValuesRecommendation = (from a in ctx.ComponentFieldValuesRecommendation
                                                           where a.ComponentFieldValuesRecommendationId == componentFieldValuesRecommendationId
                                                           select a).FirstOrDefault();

                if (oComponentFieldValuesRecommendation == null)
                    return false;

                oComponentFieldValuesRecommendation.UpdateUserId = systemUserId;
                oComponentFieldValuesRecommendation.UpdateDate = DateTime.UtcNow;
                oComponentFieldValuesRecommendation.IsDeleted = (int)Enumeratores.SiNo.Si;

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
