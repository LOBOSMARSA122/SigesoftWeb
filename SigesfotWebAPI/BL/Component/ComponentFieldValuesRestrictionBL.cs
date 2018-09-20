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
    public class ComponentFieldValuesRestrictionBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public ComponentFieldValuesRestrictionBE GetComponentFieldValuesRestriction(string componentFieldValuesRestrictionId)
        {
            try
            {
                var objEntity = (from a in ctx.ComponentFieldValuesRestriction
                             where a.ComponentFieldValuesRestrictionId == componentFieldValuesRestrictionId
                             select a).FirstOrDefault();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ComponentFieldValuesRestrictionBE> GetAllComponentFieldValuesRestriction()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.ComponentFieldValuesRestriction
                                 where a.IsDeleted == isDelete
                                 select new ComponentFieldValuesRestrictionBE
                                 {
                                     ComponentFieldValuesRestrictionId = a.ComponentFieldValuesRestrictionId,
                                     ComponentFieldValuesId = a.ComponentFieldValuesId,
                                     MasterRecommendationRestricctionId = a.MasterRecommendationRestricctionId,
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

        public bool AddComponentFieldValuesRestriction(ComponentFieldValuesRestrictionBE componentFieldValuesRestriction, int systemUserId)
        {
            try
            {
                ComponentFieldValuesRestrictionBE oComponentFieldValuesRestriction = new ComponentFieldValuesRestrictionBE()
                {
                    ComponentFieldValuesRestrictionId = BE.Utils.GetPrimaryKey(1, 28, "VR"),
                    ComponentFieldValuesId = componentFieldValuesRestriction.ComponentFieldValuesId,
                    MasterRecommendationRestricctionId = componentFieldValuesRestriction.MasterRecommendationRestricctionId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };

                ctx.ComponentFieldValuesRestriction.Add(oComponentFieldValuesRestriction);

                int rows = ctx.SaveChanges();

                return rows > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateComponentFieldValuesRestriction(ComponentFieldValuesRestrictionBE componentFieldValuesRestriction, int systemUserId)
        {
            try
            {
                var oComponentFieldValuesRestriction = (from a in ctx.ComponentFieldValuesRestriction
                                                        where a.ComponentFieldValuesRestrictionId == componentFieldValuesRestriction.ComponentFieldValuesRestrictionId
                                                        select a).FirstOrDefault();

                if (oComponentFieldValuesRestriction == null)
                    return false;

                oComponentFieldValuesRestriction.ComponentFieldValuesId = componentFieldValuesRestriction.ComponentFieldValuesId;
                oComponentFieldValuesRestriction.MasterRecommendationRestricctionId = componentFieldValuesRestriction.MasterRecommendationRestricctionId;

                //Auditoria
                oComponentFieldValuesRestriction.UpdateDate = DateTime.UtcNow;
                oComponentFieldValuesRestriction.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteComponentFieldValuesRestriction(string componentFieldValuesRestrictionId, int systemUserId)
        {
            try
            {
                var oComponentFieldValuesRestriction = (from a in ctx.ComponentFieldValuesRestriction where a.ComponentFieldValuesRestrictionId == componentFieldValuesRestrictionId select a).FirstOrDefault();

                if (oComponentFieldValuesRestriction == null)
                    return false;

                oComponentFieldValuesRestriction.UpdateUserId = systemUserId;
                oComponentFieldValuesRestriction.UpdateDate = DateTime.UtcNow;
                oComponentFieldValuesRestriction.IsDeleted = (int)Enumeratores.SiNo.Si;

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
