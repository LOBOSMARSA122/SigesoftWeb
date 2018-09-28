using BE.Common;
using BE.Diagnostic;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Diagnostic
{
    public class DxFrecuenteDetalleBL
    {
        public DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public DxFrecuenteDetalleBE GetDxFrecuenteDetalle(string dxFrecuenteDetalleId)
        {
            try
            {
                var objEntity = (from a in ctx.DxFrecuenteDetalle
                                 where a.DxFrecuenteDetalleId == dxFrecuenteDetalleId
                                 select a).FirstOrDefault();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DxFrecuenteDetalleBE> GetAllDxFrecuenteDetalle()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.DxFrecuenteDetalle
                                 where a.IsDeleted == isDelete
                                 select new DxFrecuenteDetalleBE()
                                 {
                                     DxFrecuenteDetalleId = a.DxFrecuenteDetalleId,
                                     DxFrecuenteId = a.DxFrecuenteId,
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

        public bool AddDxFrecuenteDetalle(DxFrecuenteDetalleBE dxFrecuenteDetalle, int systemUserId)
        {
            try
            {
                DxFrecuenteDetalleBE oDxFrecuenteDetalleBE = new DxFrecuenteDetalleBE()
                {
                    DxFrecuenteDetalleId =  new Utils().GetPrimaryKey(1, 302, "HZ"),
                    DxFrecuenteId = dxFrecuenteDetalle.DxFrecuenteId,
                    MasterRecommendationRestricctionId = dxFrecuenteDetalle.MasterRecommendationRestricctionId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };
                ctx.DxFrecuenteDetalle.Add(oDxFrecuenteDetalleBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDxFrecuenteDetalle(DxFrecuenteDetalleBE dxFrecuenteDetalle, int systemUserId)
        {
            try
            {
                var oDxFrecuenteDetalle = (from a in ctx.DxFrecuenteDetalle
                                 where a.DxFrecuenteDetalleId == dxFrecuenteDetalle.DxFrecuenteDetalleId
                                 select a).FirstOrDefault();
                if (oDxFrecuenteDetalle == null)
                    return false;

                oDxFrecuenteDetalle.DxFrecuenteId = dxFrecuenteDetalle.DxFrecuenteId;
                oDxFrecuenteDetalle.MasterRecommendationRestricctionId = dxFrecuenteDetalle.MasterRecommendationRestricctionId;

                //Auditoria
                oDxFrecuenteDetalle.UpdateDate = DateTime.UtcNow;
                oDxFrecuenteDetalle.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDxFrecuenteDetalle(string dxFrecuenteDetalleId, int systemUserId)
        {
            try
            {
                var oDxFrecuenteDetalle = (from a in ctx.DxFrecuenteDetalle
                                 where a.DxFrecuenteDetalleId == dxFrecuenteDetalleId
                                 select a).FirstOrDefault();

                if (oDxFrecuenteDetalle == null)
                    return false;

                oDxFrecuenteDetalle.UpdateUserId = systemUserId;
                oDxFrecuenteDetalle.UpdateDate = DateTime.UtcNow;
                oDxFrecuenteDetalle.IsDeleted = (int)Enumeratores.SiNo.Si;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
