using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Protocol
{
    public class SecuentialBE
    {
        [Key, Column(Order = 1)]
        public int? NodeId { get; set; }

        [Key, Column(Order = 2)]
        public int? TableId { get; set; }

        public int? SecuentialId { get; set; }
    }
}
