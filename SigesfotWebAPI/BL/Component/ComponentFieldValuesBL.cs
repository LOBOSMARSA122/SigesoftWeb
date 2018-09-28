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
    public class ComponentFieldValuesBL
    {
        private DatabaseContext ctx = new DatabaseContext();
        #region CRUD
        public ComponentFieldValuesBE GetComponentFieldValues(string componentFieldValuesId)
        {
            try
            {
                var objEntity = (from a in ctx.ComponentFieldValues
                                 where a.ComponentFieldValuesId == componentFieldValuesId
                                 select a).FirstOrDefault();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ComponentFieldValuesBE> GetAllComponentFieldValues()
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.ComponentFieldValues
                                 where a.IsDeleted == isDeleted
                                 select new ComponentFieldValuesBE()
                                 {
                                     ComponentFieldValuesId = a.ComponentFieldValuesId,
                                     Diseases = a.Diseases,
                                     ComponentFieldId = a.ComponentFieldId,
                                     AnalyzingValue1 = a.AnalyzingValue1,
                                     AnalyzingValue2 = a.AnalyzingValue2,
                                     OperatorId = a.OperatorId,
                                     LegalStandard = a.LegalStandard,
                                     IsAnormal = a.IsAnormal,
                                     ValidationMonths = a.ValidationMonths,
                                     GenderId = a.GenderId,
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
        public bool AddComponentFieldValues(ComponentFieldValuesBE componentFieldValues, int systemUserId)
        {
            try
            {
                ComponentFieldValuesBE oComponentFieldValuesBE = new ComponentFieldValuesBE()
                {
                    ComponentFieldValuesId =  new Utils().GetPrimaryKey(1, 19, "MV"),
                    Diseases = componentFieldValues.Diseases,
                    ComponentFieldId = componentFieldValues.ComponentFieldId,
                    AnalyzingValue1 = componentFieldValues.AnalyzingValue1,
                    AnalyzingValue2 = componentFieldValues.AnalyzingValue2,
                    OperatorId = componentFieldValues.OperatorId,
                    LegalStandard = componentFieldValues.LegalStandard,
                    IsAnormal = componentFieldValues.IsAnormal,
                    ValidationMonths = componentFieldValues.ValidationMonths,
                    GenderId = componentFieldValues.GenderId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };

                ctx.ComponentFieldValues.Add(oComponentFieldValuesBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateComponentFieldValues(ComponentFieldValuesBE componentFieldValues, int systemUserId)
        {
            try
            {
                var oComponentFieldValues = (from a in ctx.ComponentFieldValues where a.ComponentFieldValuesId == componentFieldValues.ComponentFieldValuesId select a).FirstOrDefault();

                if (oComponentFieldValues == null)
                    return false;

                oComponentFieldValues.Diseases = componentFieldValues.Diseases;
                oComponentFieldValues.ComponentFieldId = componentFieldValues.ComponentFieldId;
                oComponentFieldValues.AnalyzingValue1 = componentFieldValues.AnalyzingValue1;
                oComponentFieldValues.AnalyzingValue2 = componentFieldValues.AnalyzingValue2;
                oComponentFieldValues.OperatorId = componentFieldValues.OperatorId;
                oComponentFieldValues.LegalStandard = componentFieldValues.LegalStandard;
                oComponentFieldValues.IsAnormal = componentFieldValues.IsAnormal;
                oComponentFieldValues.ValidationMonths = componentFieldValues.ValidationMonths;
                oComponentFieldValues.GenderId = componentFieldValues.GenderId;

        //Auditoria
                oComponentFieldValues.UpdateDate = DateTime.UtcNow;
                oComponentFieldValues.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool DeleteComponentFieldValues(string componentFieldValuesId, int systemUserId)
        {
            try
            {
                var oComponentFieldValues = (from a in ctx.ComponentFieldValues where a.ComponentFieldValuesId == componentFieldValuesId select a).FirstOrDefault();

                if (oComponentFieldValues == null)
                    return false;

                oComponentFieldValues.UpdateUserId = systemUserId;
                oComponentFieldValues.UpdateDate = DateTime.UtcNow;
                oComponentFieldValues.IsDeleted = (int)Enumeratores.SiNo.Si;

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
