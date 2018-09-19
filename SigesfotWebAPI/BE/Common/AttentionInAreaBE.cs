using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class AttentionInAreaBE
    {
        public string AttentionInAreaId { get; set; }
        public int NodeId { get; set; }
        public string Name { get; set; }
        public string OfficeNumber { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
