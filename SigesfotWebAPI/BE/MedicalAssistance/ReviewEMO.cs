using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.MedicalAssistance
{
    public class ReviewEMO
    {
        public string ServiceId { get; set; }
        public DateTime? ServiceDate { get; set; } //Fecha/Servicio
        public string Aptitude { get; set; } // Aptitud
        public int? IsRevisedHistoryId { get; set; }
        public int? MasterServiceId { get; set; }
    }
}
