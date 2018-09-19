using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class NodeServiceProfileBE
    {
        public string NodeServiceProfileId { get; set; }
        public int NodeId { get; set; }
        public int ServiceTypeId { get; set; }
        public int MasterServiceId { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
