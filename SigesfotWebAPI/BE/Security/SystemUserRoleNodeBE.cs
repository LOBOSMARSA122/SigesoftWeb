using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Security
{
    public class SystemUserRoleNodeBE
    {
        [Key, Column(Order = 1)]
        public int? SystemUserId { get; set; }

        [Key, Column(Order = 2)]
        public int? NodeId { get; set; }

        [Key, Column(Order = 3)]
        public int? RoleId { get; set; }

        public int? IsDeleted { get; set; }
    }
}
