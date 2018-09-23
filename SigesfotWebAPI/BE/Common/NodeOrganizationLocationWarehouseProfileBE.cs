using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class NodeOrganizationLocationWarehouseProfileBE
    {
        [Key, Column(Order = 1)]
        public int? NodeId { get; set; }

        [Key, Column(Order = 2)]
        public string OrganizationId { get; set; }

        [Key, Column(Order = 3)]
        public string LocationId { get; set; }

        [Key, Column(Order = 4)]
        public string WarehouseId { get; set; }

        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
