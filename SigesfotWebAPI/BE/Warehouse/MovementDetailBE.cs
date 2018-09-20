﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Warehouse
{
    public class MovementDetailBE
    {
        [Key]
        public string MovementId { get; set; }
        [Key]
        public string ProductId { get; set; }
        [Key]
        public string WarehouseId { get; set; }

        public float StockMax { get; set; }
        public float StockMin { get; set; }
        public int? MovementTypeId { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public float SubTotal { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}