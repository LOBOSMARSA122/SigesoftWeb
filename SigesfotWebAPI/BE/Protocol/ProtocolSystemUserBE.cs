using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Protocol
{
    public class ProtocolSystemUserBE
    {
        [Key]
        public string ProtocolSystemUserId { get; set; }

        public int? SystemUserId { get; set; }
        public string ProtocolId { get; set; }
        public int? ApplicationHierarchyId { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
