using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.Security
{
    [Table("systemuser")]
    public class SystemUserBE
    {
        [Key]
        public int? SystemUserId { get; set; }
        public string PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }

        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? SystemUserTypeId { get; set; }
        public int? RolVentaId { get; set; }
    }  
}
