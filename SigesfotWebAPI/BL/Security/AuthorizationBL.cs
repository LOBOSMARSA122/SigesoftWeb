using BE.Common;
using BE.Security;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE.Common.Enumeratores;

namespace BL.Security
{
   public class AuthorizationBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        public AuthorizationModel ValidateSystemUser(int nodeId, string userName, string password)
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var user = (from sys in ctx.SystemUser
                                join per in ctx.Person on sys.PersonId equals per.PersonId
                                join pro in ctx.Professional on per.PersonId equals pro.PersonId
                                where sys.UserName == userName &&
                                   sys.Password == password &&
                                   sys.IsDeleted == isDeleted
                                select new AuthorizationModel
                                {
                                    PersonId = sys.PersonId,
                                    FullName = per.FirstName + " " + per.FirstLastName,
                                    PersonImage = per.PersonImage,
                                    UserName = sys.UserName,
                                    SystemUserId = sys.SystemUserId.Value

                                }).FirstOrDefault();
                if (user != null)
                {
                    var permissions = GetPermissions(nodeId, user.SystemUserId);
                    user.Permissions = permissions;
                }
                else
                {
                    return null;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Permission> GetPermissions(int nodeId, int systemUserId)
        {
            var isDeleted = (int)Enumeratores.SiNo.No;
            var query = (from rnp in ctx.RoleNodeProfile
                         join rn in ctx.RoleNode on new { a = rnp.NodeId, b = rnp.RoleId }
                                                 equals new { a = rn.NodeId, b = rn.RoleId } into rn_join
                         from rnj in rn_join.DefaultIfEmpty()

                         join surn in ctx.SystemUserRoleNode on new { a = rnp.NodeId, b = rnp.RoleId }
                                                equals new { a = surn.NodeId, b = surn.RoleId } into surn_join
                         from surnj in surn_join.DefaultIfEmpty()

                         join ah in ctx.ApplicationHierarchy on rnp.ApplicationHierarchyId equals ah.ApplicationHierarchyId

                         join fff in ctx.SystemParameter on new { a = surnj.RoleId.Value, b = 115 } // ROLES DEL SISTEMA
                                                               equals new { a = fff.i_ParameterId.Value, b = fff.i_GroupId.Value } into J5_join
                         from fff in J5_join.DefaultIfEmpty()

                         where (surnj.NodeId == nodeId) &&
                               (surnj.SystemUserId == systemUserId) &&
                               (ah.ApplicationHierarchyTypeId == 2 || ah.ApplicationHierarchyTypeId == 1) &&
                               (surnj.IsDeleted == isDeleted) && (rnp.IsDeleted == isDeleted) &&
                               (ah.TypeFormId == (int)TypeForm.Windows) && (ah.IsDeleted == 0)
                         select new Permission
                         {
                             ApplicationHierarchyId = rnp.ApplicationHierarchyId.Value,
                             ApplicationHierarchyTypeId = ah.ApplicationHierarchyTypeId.Value,
                             Description = ah.Description,
                             ParentId = ah.ParentId.Value,
                             Form = ah.Form == null ? string.Empty : ah.Form,
                             RoleName = fff.v_Value1,
                             RoleId = fff.i_ParameterId.Value
                         }
                          ).Concat(from a in ctx.SystemUserGobalProfile
                                   join b in ctx.ApplicationHierarchy on a.ApplicationHierarchyId equals b.ApplicationHierarchyId
                                   where (a.SystemUserId == systemUserId) &&
                                         (b.ApplicationHierarchyTypeId == 1 || b.ApplicationHierarchyTypeId == 2) &&
                                         (b.IsDeleted == 0) && (a.IsDeleted == 0) &&
                                         (b.TypeFormId == (int)TypeForm.Windows)
                                   select new Permission
                                   {
                                       ApplicationHierarchyId = a.ApplicationHierarchyId.Value,
                                       ApplicationHierarchyTypeId = b.ApplicationHierarchyTypeId.Value,
                                       Description = b.Description,
                                       ParentId = b.ParentId.Value,
                                       Form = b.Form == null ? string.Empty : b.Form,
                                       RoleName = "",
                                       //RoleId = null
                                   });

            List<Permission> objAutorizationList = query.AsEnumerable()
                                                          .OrderBy(p => p.ApplicationHierarchyId)
                                                          .GroupBy(x => x.ApplicationHierarchyId)
                                                          .Select(group => group.First())
                                                          .ToList();

            return objAutorizationList;

        }
    }
}
