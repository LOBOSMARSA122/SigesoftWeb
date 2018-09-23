using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Warehouse
{
    public class ProductWarehouseBE
    {
        [Key, Column(Order = 1)]
        public string WarehouseId { get; set; }
        [Key, Column(Order = 2)]
        public string ProductId { get; set; }

        public float StockMin { get; set; }
        public float StockMax { get; set; }
        public float StockActual { get; set; }

        #region Creado
        public int? IsDeleted { get; set; }
        #endregion
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
