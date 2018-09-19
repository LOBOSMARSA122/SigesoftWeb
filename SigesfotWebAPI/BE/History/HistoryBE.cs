using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.History
{
    public class HistoryBE
    {
        [Key]
        public string HistoryId { get; set; } 

        public string PersonId { get; set; } 
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; } 
        public string Organization { get; set; } 
        public string TypeActivity { get; set; } 
        public int? GeografixcaHeight { get; set; } 
        public string workstation { get; set; } 
        public byte [] RubricImage { get; set; } 
        public byte [] FingerPrintImage { get; set; } 
        public string RubricImageText { get; set; } 
        public int? IsDeleted { get; set; } 
        public int? InsertUserId { get; set; } 
        public DateTime? InsertDate { get; set; } 
        public int? UpdateUserId { get; set; } 
        public DateTime? UpdateDate { get; set; } 
        public int? TypeOperationId { get; set; } 
        public int? TrabajoActual { get; set; } 
        public string FechaUltimaMamo { get; set; } 
        public string FechaUltimoPAP { get; set; } 
        public string ResultadoMamo { get; set; } 
        public string ResultadosPAP { get; set; } 
        public int? SoloAnio { get; set; } 
        public string ActividadEmpresa { get; set; } 
    }
}
