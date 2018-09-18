using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Security
{
    public class SystemUserGobalProfileBE
    {
        [Key]
        public int SystemUserId { get; set; }
        [Key]
        public int ApplicationHierarchyId { get; set; }
        public int IsDeleted { get; set; }
    }
}
