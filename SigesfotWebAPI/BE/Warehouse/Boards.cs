using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Warehouse
{
    public class Boards
    {
        public int TotalRecords { get; set; }
        public int Index { get; set; }
        public int Take { get; set; }
    }

    public class BoardProduct : Boards
    {

        public int CategoryId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public List<Products> List { get; set; }
    }

    public class Products
    {
        public string ProductId { get; set; }
        public int? CategoryId { get; set; }

        public string Name { get; set; }

        public string GenericName { get; set; }
        public string BarCode { get; set; }

        public string ProductCode { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? MeasurementUnitId { get; set; }
        public float ReferentialCostPrice { get; set; }
        public float ReferentialSalesPrice { get; set; }

        public string Presentation { get; set; }
        public string AdditionalInformation { get; set; }
        public byte[] Image { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
