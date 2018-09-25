using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Security
{
    public class AuthorizationModel
    {
        public int SystemUserId { get; set; }
        public string PersonId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public byte[] PersonImage { get; set; }
        public List<Permission> Permissions { get; set; }
    }

    public class Permission
    {
        public int ApplicationHierarchyId { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public string Form { get; set; }
        public int ApplicationHierarchyTypeId { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public List<Permission> SubMenus { get; set; }
    }

    //public class SubMenu
    //{
    //    public int MenuId { get; set; }
    //    public string Description { get; set; }
    //    public int PadreId { get; set; }
    //    public string Icono { get; set; }
    //    public string Uri { get; set; }
    //}
}
