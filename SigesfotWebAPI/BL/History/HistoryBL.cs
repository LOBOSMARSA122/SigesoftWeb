using BE.Common;
using BE.History;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.History
{
    public class HistoryBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public HistoryBE GetHistory(string historyId)
        {
            try
            {
                var objEntity = (from a in ctx.History
                                 where a.HistoryId == historyId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<HistoryBE> GetAllHistory()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.History
                                 where a.IsDeleted == isDelete
                                 select new HistoryBE()
                                 {
                                    HistoryId = a.HistoryId,
                                    PersonId = a.PersonId,
                                    StartDate = a.StartDate,
                                    EndDate = a.EndDate,
                                    Organization = a.Organization,
                                    TypeActivity = a.TypeActivity,
                                    GeografixcaHeight = a.GeografixcaHeight,
                                    workstation = a.workstation,
                                    RubricImage = a.RubricImage,
                                    FingerPrintImage = a.FingerPrintImage,
                                    RubricImageText = a.RubricImageText,
                                    IsDeleted = a.IsDeleted,
                                    InsertUserId = a.InsertUserId,
                                    InsertDate = a.InsertDate,
                                    UpdateUserId = a.UpdateUserId,
                                    UpdateDate = a.UpdateDate,
                                    TypeOperationId = a.TypeOperationId,
                                    TrabajoActual = a.TrabajoActual,
                                    FechaUltimaMamo = a.FechaUltimaMamo,
                                    FechaUltimoPAP = a.FechaUltimoPAP,
                                    ResultadoMamo = a.ResultadoMamo,
                                    ResultadosPAP = a.ResultadosPAP,
                                    SoloAnio = a.SoloAnio,
                                    ActividadEmpresa = a.ActividadEmpresa
                                 }).ToList();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddHistory(HistoryBE history, int systemUserId)
        {
            try
            {
                HistoryBE oHistoryBE = new HistoryBE()
                {
                    HistoryId = BE.Utils.GetPrimaryKey(1, 37, "HH"),
                    PersonId = history.PersonId,
                    StartDate = history.StartDate,
                    EndDate = history.EndDate,
                    Organization = history.Organization,
                    TypeActivity = history.TypeActivity,
                    GeografixcaHeight = history.GeografixcaHeight,
                    workstation = history.workstation,
                    RubricImage = history.RubricImage,
                    FingerPrintImage = history.FingerPrintImage,
                    RubricImageText = history.RubricImageText,
                    TypeOperationId = history.TypeOperationId,
                    TrabajoActual = history.TrabajoActual,
                    FechaUltimaMamo = history.FechaUltimaMamo,
                    FechaUltimoPAP = history.FechaUltimoPAP,
                    ResultadoMamo = history.ResultadoMamo,
                    ResultadosPAP = history.ResultadosPAP,
                    SoloAnio = history.SoloAnio,
                    ActividadEmpresa = history.ActividadEmpresa,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.History.Add(oHistoryBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateHistory(HistoryBE history, int systemUserId)
        {
            try
            {
                var oHistory = (from a in ctx.History
                                where a.HistoryId == history.HistoryId
                                select a).FirstOrDefault();

                if (oHistory == null)
                    return false;

                oHistory.PersonId = history.PersonId;
                oHistory.StartDate = history.StartDate;
                oHistory.EndDate = history.EndDate;
                oHistory.Organization = history.Organization;
                oHistory.TypeActivity = history.TypeActivity;
                oHistory.GeografixcaHeight = history.GeografixcaHeight;
                oHistory.workstation = history.workstation;
                oHistory.RubricImage = history.RubricImage;
                oHistory.FingerPrintImage = history.FingerPrintImage;
                oHistory.RubricImageText = history.RubricImageText;
                oHistory.TypeOperationId = history.TypeOperationId;
                oHistory.TrabajoActual = history.TrabajoActual;
                oHistory.FechaUltimaMamo = history.FechaUltimaMamo;
                oHistory.FechaUltimoPAP = history.FechaUltimoPAP;
                oHistory.ResultadoMamo = history.ResultadoMamo;
                oHistory.ResultadosPAP = history.ResultadosPAP;
                oHistory.SoloAnio = history.SoloAnio;
                oHistory.ActividadEmpresa = history.ActividadEmpresa;

                //Auditoria

                oHistory.UpdateDate = DateTime.UtcNow;
                oHistory.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteHistory(string historyId, int systemUserId)
        {
            try
            {
                var oHistory = (from a in ctx.History
                                where a.HistoryId == historyId
                                select a).FirstOrDefault();

                if (oHistory == null)
                    return false;

                oHistory.UpdateUserId = systemUserId;
                oHistory.UpdateDate = DateTime.UtcNow;
                oHistory.IsDeleted = (int)Enumeratores.SiNo.Si;

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
