using BE.Common;
using BE.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service
{
    public class CalendarBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public CalendarBE GetCalendar(string calendarId)
        {
            try
            {
                var objEntity = (from a in ctx.Calendar
                                 where a.CalendarId == calendarId
                                 select a).FirstOrDefault();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<CalendarBE> GetAllCalendar()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Calendar
                                 where a.IsDeleted == isDelete
                                 select new CalendarBE()
                                 {
                                     CalendarId = a.CalendarId,
                                     PersonId = a.PersonId,
                                     ServiceId = a.ServiceId,
                                     DateTimeCalendar = a.DateTimeCalendar,
                                     CircuitStartDate = a.CircuitStartDate,
                                     EntryTimeCM = a.EntryTimeCM,
                                     ServiceTypeId = a.ServiceTypeId,
                                     CalendarStatusId = a.CalendarStatusId,
                                     ServiceintId = a.ServiceintId,
                                     ProtocolId = a.ProtocolId,
                                     NewContinuationId = a.NewContinuationId,
                                     LineStatusId = a.LineStatusId,
                                     IsVipId = a.IsVipId,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateUserId = a.UpdateUserId,
                                     UpdateDate = a.UpdateDate,
                                     SalidaCM = a.SalidaCM,

                                 }).ToList();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddCalendar(CalendarBE calendar, int systemUserId)
        {
            try
            {
                CalendarBE oCalendarBE = new CalendarBE()
                {
                    CalendarId =  new Common.PersonBL().GetPrimaryKey(1, 22, "CA"),
                    PersonId = calendar.PersonId,
                    ServiceId = calendar.ServiceId,
                    DateTimeCalendar = calendar.DateTimeCalendar,
                    CircuitStartDate = calendar.CircuitStartDate,
                    EntryTimeCM = calendar.EntryTimeCM,
                    ServiceTypeId = calendar.ServiceTypeId,
                    CalendarStatusId = calendar.CalendarStatusId,
                    ServiceintId = calendar.ServiceintId,
                    ProtocolId = calendar.ProtocolId,
                    NewContinuationId = calendar.NewContinuationId,
                    LineStatusId = calendar.LineStatusId,
                    IsVipId = calendar.IsVipId,
                    SalidaCM = calendar.SalidaCM,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };
                ctx.Calendar.Add(oCalendarBE);
            int rows = ctx.SaveChanges();

            return rows > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCalendar(CalendarBE calendar, int systemUserId)
        {
            try
            {
                var oCalendar = (from a in ctx.Calendar
                                 where a.CalendarId == calendar.CalendarId
                                 select a).FirstOrDefault();

                if (oCalendar == null)
                    return false;

                oCalendar.PersonId = calendar.PersonId;
                oCalendar.ServiceId = calendar.ServiceId;
                oCalendar.DateTimeCalendar = calendar.DateTimeCalendar;
                oCalendar.CircuitStartDate = calendar.CircuitStartDate;
                oCalendar.EntryTimeCM = calendar.EntryTimeCM;
                oCalendar.ServiceTypeId = calendar.ServiceTypeId;
                oCalendar.CalendarStatusId = calendar.CalendarStatusId;
                oCalendar.ServiceintId = calendar.ServiceintId;
                oCalendar.ProtocolId = calendar.ProtocolId;
                oCalendar.NewContinuationId = calendar.NewContinuationId;
                oCalendar.LineStatusId = calendar.LineStatusId;
                oCalendar.IsVipId = calendar.IsVipId;
                oCalendar.SalidaCM = calendar.SalidaCM;

                //Auditoria
                oCalendar.UpdateDate = DateTime.UtcNow;
                oCalendar.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCalendar(string calendarId, int systemUserId)
        {
            try
            {
                var oCalendar = (from a in ctx.Calendar
                                 where a.CalendarId == calendarId
                                 select a).FirstOrDefault();

                if (oCalendar == null)
                    return false;

                oCalendar.UpdateUserId = systemUserId;
                oCalendar.UpdateDate = DateTime.UtcNow;
                oCalendar.IsDeleted = (int)Enumeratores.SiNo.Si;

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
