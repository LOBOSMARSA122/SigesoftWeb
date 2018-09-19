using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Protocol
{
    public class SecuentialBE
    {
        [Key]
        public int? NodeId { get; set; }

        [Key]
        public int? TableId { get; set; }

        public int? SecuentialId { get; set; }
    }
}
