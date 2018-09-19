using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Service
{
    public class ServiceComponentBE
    {
        [Key]
        public string ServiceComponentId { get; set; }

        public string ServiceId { get; set; }
        public string ComponentId { get; set; }
        public int? ServiceComponentStatusId { get; set; }
        public int? ExternalinternalId { get; set; }
        public int? ServiceComponentTypeId { get; set; }
        public int? IsVisibleId { get; set; }
        public int? IsInheritedId { get; set; }
        public DateTime? CalledDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? index { get; set; }
        public float Price { get; set; }
        public int? IsInvoicedId { get; set; }
        public int? IsRequiredId { get; set; }
        public int? IsManuallyAddedId { get; set; }
        public int? QueueStatusId { get; set; }
        public string NameOfice { get; set; }
        public string Comment { get; set; }
        public int? Iscalling { get; set; }
        public int? IsApprovedId { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? ApprovedInsertUserId { get; set; }
        public int? ApprovedUpdateUserId { get; set; }
        public DateTime? ApprovedInsertDate { get; set; }
        public DateTime? ApprovedUpdateDate { get; set; }
        public int? InsertUserMedicalAnalystId { get; set; }
        public int? UpdateUserMedicalAnalystId { get; set; }
        public DateTime? InsertDateMedicalAnalyst { get; set; }
        public DateTime? UpdateDateMedicalAnalyst { get; set; }
        public int? InsertUserTechnicalDataRegisterId { get; set; }
        public int? UpdateUserTechnicalDataRegisterId { get; set; }
        public DateTime? InsertDateTechnicalDataRegister { get; set; }
        public DateTime? UpdateDateTechnicalDataRegister { get; set; }
        public int? Iscalling_1 { get; set; }
        public int? AuditorInsertUserId { get; set; }
        public DateTime? AuditorInsertUser { get; set; }
        public int? AuditorUpdateUserId { get; set; }
        public DateTime? AuditorUpdateUser { get; set; }
        public string IdUnidadProductiva { get; set; }
        public DateTime? SaldoPaciente { get; set; }
        public DateTime? SaldoAseguradora { get; set; }
        public int? MedicoTratanteId { get; set; }
        public int? SystemUserEspecialistaId { get; set; }
    }
}
