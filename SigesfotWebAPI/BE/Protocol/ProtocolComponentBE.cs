using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Protocol
{
    public class ProtocolComponentBE
    {
        [Key]
        public string ProtocolComponentId { get; set; }

        public string ProtocolId { get; set; }
        public string ComponentId { get; set; }
        public float Price { get; set; }
        public int? OperatorId { get; set; }
        public int? Age { get; set; }
        public int? GenderId { get; set; }
        public int? GrupoEtarioId { get; set; }
        public int? IsConditionalId { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsConditionalIMC { get; set; }
        public float Imc { get; set; }
        public int? IsAdditional { get; set; }
    }
}
