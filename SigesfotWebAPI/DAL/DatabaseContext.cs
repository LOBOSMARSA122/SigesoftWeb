using System.Data.Entity;
using BE.Security;
using BE.Common;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=BDSigesoft") { }
        public DbSet<SystemUserBE> SystemUser { get; set; }
        public DbSet<PersonBE> Person { get; set; }
        public DbSet<ProfessionalBE> Professional { get; set; }

        public DbSet<RoleNodeProfileBE> RoleNodeProfile { get; set; }
        public DbSet<RoleNodeBE> RoleNode { get; set; }
        public DbSet<SystemUserRoleNodeBE> SystemUserRoleNode { get; set; }
        public DbSet<ApplicationHierarchyBE> ApplicationHierarchy { get; set; }
        public DbSet<SystemParameterBE> SystemParameter { get; set; }
        public DbSet<SystemUserGobalProfileBE> SystemUserGobalProfile { get; set; }

    }
}
