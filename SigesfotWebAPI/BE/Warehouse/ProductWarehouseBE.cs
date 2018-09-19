using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Warehouse
{
    public class ProductWarehouseBE
    {
        public string WarehouseId { get; set; }
        public string ProductId { get; set; }
        public float StockMin { get; set; }
        public float StockMax { get; set; }
        public float StockActual { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
