using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class MasterRecommendationRestricctionBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public MasterRecommendationRestricctionBE GetMasterRecommendationRestricction(string masterRecommendationRestricctionId)
        {
            try
            {
                var objEntity = (from a in ctx.MasterRecommendationRestricction
                                 where a.MasterRecommendationRestricctionId == masterRecommendationRestricctionId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MasterRecommendationRestricctionBE> GetAllMasterRecommendationRestricctions()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.MasterRecommendationRestricction
                                 where a.IsDeleted == isDelete
                                 select new MasterRecommendationRestricctionBE()
                                 {
                                     MasterRecommendationRestricctionId = a.MasterRecommendationRestricctionId,
                                     Name = a.Name,
                                     TypifyingId = a.TypifyingId,
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

        public bool AddMasterRecommendationRestricction(MasterRecommendationRestricctionBE masterRecommendationRestricction, int systemUserId)
        {
            try
            {
                MasterRecommendationRestricctionBE oMasterRecommendationRestricctionBE = new MasterRecommendationRestricctionBE()
                {
                    MasterRecommendationRestricctionId =  new Utils().GetPrimaryKey(1, 43, "MR"),
                    Name = masterRecommendationRestricction.Name,
                    TypifyingId = masterRecommendationRestricction.TypifyingId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.MasterRecommendationRestricction.Add(oMasterRecommendationRestricctionBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateMasterRecommendationRestricction(MasterRecommendationRestricctionBE masterRecommendationRestricction, int systemUserId)
        {
            try
            {
                var oMasterRecommendationRestricction = (from a in ctx.MasterRecommendationRestricction
                            where a.MasterRecommendationRestricctionId == masterRecommendationRestricction.MasterRecommendationRestricctionId
                                                         select a).FirstOrDefault();

                if (oMasterRecommendationRestricction == null)
                    return false;

                oMasterRecommendationRestricction.Name = masterRecommendationRestricction.Name;
                oMasterRecommendationRestricction.TypifyingId = masterRecommendationRestricction.TypifyingId;

                //Auditoria

                oMasterRecommendationRestricction.UpdateDate = DateTime.UtcNow;
                oMasterRecommendationRestricction.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMasterRecommendationRestricction(string masterRecommendationRestricctionId, int systemUserId)
        {
            try
            {
                var oMasterRecommendationRestricction = (from a in ctx.MasterRecommendationRestricction
                                                         where a.MasterRecommendationRestricctionId == masterRecommendationRestricctionId
                                                         select a).FirstOrDefault();

                if (oMasterRecommendationRestricction == null)
                    return false;

                oMasterRecommendationRestricction.UpdateUserId = systemUserId;
                oMasterRecommendationRestricction.UpdateDate = DateTime.UtcNow;
                oMasterRecommendationRestricction.IsDeleted = (int)Enumeratores.SiNo.Si;

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
