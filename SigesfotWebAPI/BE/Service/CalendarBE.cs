using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Service
{
    public class CalendarBE
    {
        public string CalendarId { get; set; }
        public string PersonId { get; set; }
        public string ServiceId { get; set; }
        public DateTime DateTimeCalendar { get; set; }
        public DateTime CircuitStartDate { get; set; }
        public DateTime EntryTimeCM { get; set; }
        public int ServiceTypeId { get; set; }
        public int CalendarStatusId { get; set; }
        public int ServiceIntId { get; set; }
        public string ProtocolId { get; set; }
        public int NewContinuationId { get; set; }
        public int LineStatusId { get; set; }
        public int IsVipId { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime SalidaCM { get; set; }
    }
}
