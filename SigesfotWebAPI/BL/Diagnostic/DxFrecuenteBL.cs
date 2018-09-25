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
    public class DxFrecuenteBL
    {
        public DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public DxFrecuenteBE GetDxFrecuente(string dxFrecuenteId)
        {
            try
            {
                var objEntity = (from a in ctx.DxFrecuente
                                 where a.DxFrecuenteId == dxFrecuenteId
                                 select a).FirstOrDefault();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DxFrecuenteBE> GetAllDxFrecuente()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.DxFrecuente
                                 where a.IsDeleted == isDelete
                                 select new DxFrecuenteBE()
                                 {
                                     DxFrecuenteId = a.DxFrecuenteId,
                                     DiseasesId = a.DiseasesId,
                                     CIE10Id = a.CIE10Id,
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

        public bool AddDxFrecuente(DxFrecuenteBE dxFrecuente, int systemUserId)
        {
            try
            {
                DxFrecuenteBE oDxFrecuenteBE = new DxFrecuenteBE()
                {
                    DxFrecuenteId =  new Common.PersonBL().GetPrimaryKey(1, 301, "HG"),
                    DiseasesId = dxFrecuente.DiseasesId,
                    CIE10Id = dxFrecuente.CIE10Id,
                    
                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };
                ctx.DxFrecuente.Add(oDxFrecuenteBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDxFrecuente(DxFrecuenteBE dxFrecuente, int systemUserId)
        {
            try
            {
                var oDxFrecuente = (from a in ctx.DxFrecuente
                                    where a.DxFrecuenteId == dxFrecuente.DxFrecuenteId
                                    select a).FirstOrDefault();
                if (oDxFrecuente == null)
                    return false;
                oDxFrecuente.DiseasesId = dxFrecuente.DiseasesId;
                oDxFrecuente.CIE10Id = dxFrecuente.CIE10Id;


                //Auditoria
                oDxFrecuente.UpdateDate = DateTime.UtcNow;
                oDxFrecuente.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDxFrecuente(string dxFrecuenteId, int systemUserId)
        {
            try
            {
                var oDxFrecuente = (from a in ctx.DxFrecuente
                                 where a.DxFrecuenteId == dxFrecuenteId
                                    select a).FirstOrDefault();

                if (oDxFrecuente == null)
                    return false;

                oDxFrecuente.UpdateUserId = systemUserId;
                oDxFrecuente.UpdateDate = DateTime.UtcNow;
                oDxFrecuente.IsDeleted = (int)Enumeratores.SiNo.Si;

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
