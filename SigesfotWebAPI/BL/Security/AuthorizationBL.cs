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
                                join per in ctx.Person on sys.v_PersonId equals per.v_PersonId
                                join pro in ctx.Professional on per.v_PersonId equals pro.v_PersonId
                            where sys.v_UserName == userName &&
                                   sys.v_Password == password &&
                                   sys.i_IsDeleted == isDeleted
                                select new AuthorizationModel
                                {
                                    PersonId = sys.v_PersonId,
                                    FullName = per.v_FirstName + " " + per.v_FirstLastName,
                                    PersonImage = per.b_PersonImage,
                                    UserName = sys.v_UserName,
                                    SystemUserId = sys.i_SystemUserId.Value

                                }).FirstOrDefault();
                if (user != null)
                {
                    var permissions = GetPermissions(1, user.SystemUserId);
                    user.Permissions = permissions;
                }
                else
                {
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Permission> GetPermissions(int nodeId, int systemUserId)
        {
            var isDeleted = (int)Enumeratores.SiNo.No;
            try
            {
                var query = (from rnp in ctx.RoleNodeProfile
                             join rn in ctx.RoleNode on new { a = rnp.i_NodeId, b = rnp.i_RoleId }
                                                     equals new { a = rn.i_NodeId, b = rn.i_RoleId } into rn_join
                             from rnj in rn_join.DefaultIfEmpty()

                             join surn in ctx.SystemUserRoleNode on new { a = rnp.i_NodeId, b = rnp.i_RoleId }
                                                    equals new { a = surn.i_NodeId, b = surn.i_RoleId } into surn_join
                             from surnj in surn_join.DefaultIfEmpty()

                             join ah in ctx.ApplicationHierarchy on rnp.i_ApplicationHierarchyId equals ah.i_ApplicationHierarchyId

                             join fff in ctx.SystemParameter on new { a = surnj.i_RoleId.Value, b = 115 } // ROLES DEL SISTEMA
                                                                   equals new { a = fff.i_ParameterId, b = fff.i_GroupId } into J5_join
                             from fff in J5_join.DefaultIfEmpty()

                             where (surnj.i_NodeId == nodeId) &&
                                   (surnj.i_SystemUserId == systemUserId) &&
                                   (ah.i_ApplicationHierarchyTypeId == 2 || ah.i_ApplicationHierarchyTypeId == 1) &&
                                   (surnj.i_IsDeleted == isDeleted) && (rnp.i_IsDeleted == isDeleted) &&
                                   (ah.i_TypeFormId == (int)TypeForm.Web) && (ah.i_IsDeleted == 0)
                             select new Permission
                             {
                                 ApplicationHierarchyId = rnp.i_ApplicationHierarchyId.Value,
                                 ApplicationHierarchyTypeId = ah.i_ApplicationHierarchyTypeId.Value,
                                 Description = ah.v_Description,
                                 ParentId = ah.i_ParentId.Value,
                                 Form = ah.v_Form == null ? string.Empty : ah.v_Form,
                                 RoleName = fff.v_Value1,
                                 RoleId = fff.i_ParameterId
                             }
                          )
                  .Concat(from a in ctx.SystemUserGobalProfile
                          join b in ctx.ApplicationHierarchy on a.i_ApplicationHierarchyId equals b.i_ApplicationHierarchyId
                          where (a.i_SystemUserId == systemUserId) &&
                                (b.i_ApplicationHierarchyTypeId == 1 || b.i_ApplicationHierarchyTypeId == 2) &&
                                (b.i_IsDeleted == 0) && (a.i_IsDeleted == 0) &&
                                (b.i_TypeFormId == (int)TypeForm.Web)
                          select new Permission
                          {
                              ApplicationHierarchyId = a.i_ApplicationHierarchyId.Value,
                              ApplicationHierarchyTypeId = b.i_ApplicationHierarchyTypeId.Value,
                              Description = b.v_Description,
                              ParentId = b.i_ParentId.Value,
                              Form = b.v_Form == null ? string.Empty : b.v_Form,
                              RoleName = "",
                              RoleId = 0
                          }).ToList();

                List<Permission> objAutorizationList = query.AsEnumerable()
                                                              .OrderBy(p => p.ApplicationHierarchyId)
                                                              .GroupBy(x => x.ApplicationHierarchyId)
                                                              .Select(group => group.First())
                                                              .ToList();

                var parents = objAutorizationList.FindAll(p => p.ParentId == -1);

                var result = new List<Permission>();
               
                foreach (var parent in parents)
                {
                    var oPermission = new Permission();
                    oPermission.ApplicationHierarchyId = parent.ApplicationHierarchyId;
                    oPermission.ApplicationHierarchyTypeId = parent.ApplicationHierarchyTypeId;
                    oPermission.Description = parent.Description;
                    oPermission.ParentId = parent.ParentId;
                    oPermission.Form = parent.Form;
                    oPermission.RoleName = parent.RoleName;
                    oPermission.RoleId = parent.RoleId;
                    
                    LoadTreeSubMenuPermission(ref oPermission, query, parent.ApplicationHierarchyId); 

                    result.Add(oPermission);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LoadTreeSubMenuPermission(ref Permission parentNode, List<Permission> permissions, int parentId)
        {
            var submenus = permissions.FindAll(p => p.ParentId == parentId);

            //var subMenus = new List<Permission>();
            foreach (var submenu in submenus)
            {
                var subMenu = new Permission();

                subMenu.Description = submenu.Description;
                subMenu.Form = submenu.Form;
                if (parentNode.SubMenus == null)
                {
                    parentNode.SubMenus = new List<Permission>();
                }
                parentNode.SubMenus.Add(subMenu);

                LoadTreeSubMenuPermission(ref subMenu, permissions, submenu.ApplicationHierarchyId);
            }
            //return subMenus;
        }
    }
}
