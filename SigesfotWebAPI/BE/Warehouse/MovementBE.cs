using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Warehouse
{
    public class MovementBE
    {
        [Key]
        public string MovementId { get; set; }
        public string WarehouseId { get; set; }
        public string SupplierId { get; set; }
        public int? ProcessTypeId { get; set; }
        public string ParentMovementId { get; set; }
        public string Motive { get; set; }
        public int? MotiveTypeId { get; set; }
        public DateTime? Date { get; set; }
        public float TotalQuantity { get; set; }
        public int? MovementTypeId { get; set; }
        public int? RequireRemoteProcess { get; set; }
        public string RemoteWarehouseId { get; set; }
        public int? CurrencyId { get; set; }
        public float ExchangeRate { get; set; }
        public string ReferenceDocument { get; set; }
        public int? CostCenterId { get; set; }
        public string Observations { get; set; }
        public int? IsLocallyProcessed { get; set; }
        public int? IsRemoteProcessed { get; set; }

        public int? InsertUserId { get; set; }
        public int? IsDeleted { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNodeId { get; set; }
    }
}
