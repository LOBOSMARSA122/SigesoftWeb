using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.History
{
    public class WorkStationDangersBE
    {
        [Key]
        public string WorkstationDangersId { get; set; }

        public string HistoryId { get; set; }
        public int? DangerId { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? NoiseSource { get; set; }
        public int? NoiseLevel { get; set; }
        public string TimeOfExposureToNoise { get; set; }
    }
}
