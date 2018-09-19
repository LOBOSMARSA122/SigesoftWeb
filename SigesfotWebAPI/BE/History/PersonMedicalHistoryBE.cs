using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.History
{
    public class PersonMedicalHistoryBE
    {
        public string PersonMedicalHistoryId { get; set; }
        public string PersonId { get; set; }
        public string DiseasesId { get; set; }
        public int TypeDiagnosticId { get; set; }
        public DateTime StartDate { get; set; }
        public string DiagnosticDetail { get; set; }
        public string TreatmentSite { get; set; }
        public int AnswerId { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int SoloAnio { get; set; }
        public string NombreHospital { get; set; }
        public string Complicaciones { get; set; }
    }
}
