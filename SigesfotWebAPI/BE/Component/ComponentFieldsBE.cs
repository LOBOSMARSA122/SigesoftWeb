using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Component
{
    public class ComponentFieldsBE
    {
        public string ComponentId { get; set; }
        public string ComponentFieldId { get; set; }
        public string Group { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
