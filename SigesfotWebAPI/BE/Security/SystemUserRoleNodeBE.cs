using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Security
{
    public class SystemUserRoleNodeBE
    {
        [Key]
        public int SystemUserId { get; set; }
        [Key]
        public int NodeId { get; set; }
        public int RoleId { get; set; }
        public int IsDeleted { get; set; }
    }
}
