using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Service
{
    public class ServiceBE
    {
        [Key]
        public string ServiceId { get; set; }

        public string ProtocolId { get; set; }
        public string PersonId { get; set; }
        public int? MasterServiceId { get; set; }
        public int? ServiceStatusId { get; set; }
        public string Motive { get; set; }
        public int? AptitudeStatusId { get; set; }
        public DateTime? ServiceDate { get; set; }
        public DateTime? GlobalExpirationDate { get; set; }
        public DateTime? ObsExpirationDate { get; set; }
        public int? FlagAgentId { get; set; }
        public string OrganizationId { get; set; }
        public string LocationId { get; set; }
        public string MainSymptom { get; set; }
        public int? TimeOfDisease { get; set; }
        public int? TimeOfDiseaseTypeId { get; set; }
        public string Story { get; set; }
        public int? DreamId { get; set; }
        public int? UrineId { get; set; }
        public int? DepositionId { get; set; }
        public int? AppetiteId { get; set; }
        public int? ThirstId { get; set; }
        public DateTime? Fur { get; set; }
        public string CatemenialRegime { get; set; }
        public int? MacId { get; set; }
        public int? IsNewControl { get; set; }
        public int? HasMedicalBreakId { get; set; }
        public DateTime? MedicalBreakStartDate { get; set; }
        public DateTime? MedicalBreakEndDate { get; set; }
        public string GeneralRecomendations { get; set; }
        public int? DestinationMedicationId { get; set; }
        public int? TransportMedicationId { get; set; }
        public DateTime? StartDateRestriction { get; set; }
        public DateTime? EndDateRestriction { get; set; }
        public int? HasRestrictionId { get; set; }
        public int? HasSymptomId { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? NextAppointment { get; set; }

        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }

        public int? SendToTracking { get; set; }
        public int? InsertUserMedicalAnalystId { get; set; }
        public int? UpdateUserMedicalAnalystId { get; set; }
        public DateTime? InsertDateMedicalAnalyst { get; set; }
        public DateTime? UpdateDateMedicalAnalyst { get; set; }
        public int? InsertUserOccupationalMedicalId { get; set; }
        public int? UpdateUserOccupationalMedicaltId { get; set; }
        public DateTime? InsertDateOccupationalMedical { get; set; }
        public DateTime? UpdateDateOccupationalMedical { get; set; }
        public int? HazinterconsultationId { get; set; }
        public string Gestapara { get; set; }
        public string Menarquia { get; set; }
        public DateTime? PAP { get; set; }
        public DateTime? Mamografia { get; set; }
        public string CiruGine { get; set; }
        public string Findings { get; set; }
        public int? StatusLiquidation { get; set; }
        public int? ServiceTypeOfInsurance { get; set; }
        public int? ModalityOfInsurance { get; set; }
        public int? IsFac { get; set; }
        public int? InicioEnf { get; set; }
        public int? CursoEnf { get; set; }
        public int? Evolucion { get; set; }
        public string ExaAuxResult { get; set; }
        public string ObsStatusService { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string AreaId { get; set; }
        public string FechaUltimoPAP { get; set; }
        public string ResultadosPAP { get; set; }
        public string FechaUltimaMamo { get; set; }
        public string ResultadoMamo { get; set; }
        public float Costo { get; set; }
        public int? EnvioCertificado { get; set; }
        public int? EnvioHistoria { get; set; }
        public string IdVentaCliente { get; set; }
        public string IdVentaAseguradora { get; set; }
        public string InicioVidaSexaul { get; set; }
        public string NroParejasActuales { get; set; }
        public string NroAbortos { get; set; }
        public string PrecisarCausas { get; set; }
        public int? MedicoTratanteId { get; set; }
        public int? IsFacMedico { get; set; }
        public string centrocosto { get; set; }
        public string NroLiquidacion { get; set; }
    }
}
