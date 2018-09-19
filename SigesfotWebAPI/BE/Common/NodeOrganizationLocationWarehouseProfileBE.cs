using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class NodeOrganizationLocationWarehouseProfileBE
    {
        [Key]
        public int? NodeId { get; set; }

        [Key]
        public string OrganizationId { get; set; }

        [Key]
        public string LocationId { get; set; }

        [Key]
        public string WarehouseId { get; set; }

        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
