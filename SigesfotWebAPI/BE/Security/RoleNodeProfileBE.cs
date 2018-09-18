using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Security
{
    public class RoleNodeProfileBE
    {
        [Key]
        public int NodeId { get; set; }
        public int RoleId { get; set; }
        public int ApplicationHierarchyId { get; set; }
        public int IsDeleted { get; set; }
    }
}
