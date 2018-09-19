using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Service
{
    public class DiagnosticRepositoryBE
    {
        [Key]
        public string DiagnosticRepositoryId { get; set; } 

        public string ServiceId { get; set; } 
        public string DiseasesId { get; set; } 
        public string ComponentId { get; set; } 
        public string ComponentFieldId { get; set; } 
        public int? AutoManualId { get; set; } 
        public int? PreQualificationId { get; set; } 
        public int? FinalQualificationId { get; set; } 
        public int? DiagnosticTypeId { get; set; } 
        public int? IsSentToAntecedent { get; set; } 
        public DateTime? ExpirationDateDiagnostic { get; set; } 
        public int? GenerateMedicalBreak { get; set; } 
        public string Recomendations { get; set; } 
        public int? DiagnosticSourceId { get; set; } 
        public int? ShapeAccidentId { get; set; } 
        public int? BodyPartId { get; set; } 
        public int? ClassificationOfWorkAccidentId { get; set; } 
        public int? RiskFactorId { get; set; } 
        public int? ClassificationOfWorkdiseaseId { get; set; } 
        public int? SendTointerconsultationId { get; set; } 
        public int? interconsultationDestinationintId { get; set; } 
        public int? IsDeleted { get; set; } 
        public int? InsertUserId { get; set; } 
        public DateTime? InsertDate { get; set; } 
        public int? UpdateUserId { get; set; } 
        public DateTime? UpdateDate { get; set; } 
        public string interconsultationDestinationId { get; set; } 
    }
}
