using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Protocol
{
    public class ProtocolBE
    {
        [Key]
        public string ProtocolId { get; set; }

        public string Name { get; set; }
        public string EmployerOrganizationId { get; set; }
        public string EmployerLocationId { get; set; }
        public int? EsoTypeId { get; set; }
        public string GroupOccupationId { get; set; }
        public string CustomerOrganizationId { get; set; }
        public string CustomerLocationId { get; set; }
        public string NombreVendedor { get; set; }
        public string WorkingOrganizationId { get; set; }
        public string WorkingLocationId { get; set; }
        public string CostCenter { get; set; }
        public int? MasterServiceTypeId { get; set; }
        public int? MasterServiceId { get; set; }
        public int? HasVigency { get; set; }
        public int? ValidInDays { get; set; }
        public int? IsActive { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string AseguradoraOrganizationId { get; set; }
    }
}
