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
    public class WorkStationDangersBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public WorkStationDangersBE GetWorkStationDangerss(string workStationDangersId)
        {
            try
            {
                var objEntity = (from a in ctx.WorkStationDangers
                                 where a.WorkstationDangersId == workStationDangersId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<WorkStationDangersBE> GetAllWorkStationDangers()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.WorkStationDangers
                                 where a.IsDeleted == isDelete
                                 select new WorkStationDangersBE()
                                 {
                                     WorkstationDangersId = a.WorkstationDangersId,
                                     HistoryId = a.HistoryId,
                                     DangerId = a.DangerId,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     NoiseSource = a.NoiseSource,
                                     NoiseLevel = a.NoiseLevel,
                                     TimeOfExposureToNoise = a.TimeOfExposureToNoise,
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

        public bool AddWorkStationDangers(WorkStationDangersBE workStationDangers, int systemUserId)
        {
            try
            {
                WorkStationDangersBE oWorkStationDangersBE = new WorkStationDangersBE()
                {
                    WorkstationDangersId =  new Utils().GetPrimaryKey(1, 39, "HW"),
                    HistoryId = workStationDangers.HistoryId,
                    DangerId = workStationDangers.DangerId,
                    NoiseSource = workStationDangers.NoiseSource,
                    NoiseLevel = workStationDangers.NoiseLevel,
                    TimeOfExposureToNoise = workStationDangers.TimeOfExposureToNoise,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.WorkStationDangers.Add(oWorkStationDangersBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateWorkStationDangers(WorkStationDangersBE workStationDangers, int systemUserId)
        {
            try
            {
                var oWorkStationDangers = (from a in ctx.WorkStationDangers
                                           where a.WorkstationDangersId == workStationDangers.WorkstationDangersId
                                           select a).FirstOrDefault();

                if (oWorkStationDangers == null)
                    return false;

                oWorkStationDangers.HistoryId = workStationDangers.HistoryId;
                oWorkStationDangers.DangerId = workStationDangers.DangerId;
                oWorkStationDangers.NoiseSource = workStationDangers.NoiseSource;
                oWorkStationDangers.NoiseLevel = workStationDangers.NoiseLevel;
                oWorkStationDangers.TimeOfExposureToNoise = workStationDangers.TimeOfExposureToNoise;

                //Auditoria

                oWorkStationDangers.UpdateDate = DateTime.UtcNow;
                oWorkStationDangers.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteWorkStationDangers(string workStationDangersId, int systemUserId)
        {
            try
            {
                var oWorkStationDangers = (from a in ctx.WorkStationDangers
                                           where a.WorkstationDangersId == workStationDangersId
                                           select a).FirstOrDefault();

                if (oWorkStationDangers == null)
                    return false;

                oWorkStationDangers.UpdateUserId = systemUserId;
                oWorkStationDangers.UpdateDate = DateTime.UtcNow;
                oWorkStationDangers.IsDeleted = (int)Enumeratores.SiNo.Si;

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
