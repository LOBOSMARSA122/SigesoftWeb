using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class AplicationHierarchyBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public AplicationHierarchyBE GetAplicationHierarchy(int aplicationHierarchyId)
        {
            try
            {
                var objEntity = (from a in ctx.AplicationHierarchy
                                 where a.ApplicationHierarchyId == aplicationHierarchyId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AplicationHierarchyBE> GetAllAplicationHierarchy()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.AplicationHierarchy
                                 where a.IsDeleted == isDelete
                                 select new AplicationHierarchyBE()
                                 {
                                     ApplicationHierarchyId = a.ApplicationHierarchyId,
                                     ApplicationHierarchyTypeId = a.ApplicationHierarchyTypeId,
                                     Level = a.Level,
                                     Description = a.Description,
                                     Form = a.Form,
                                     Code = a.Code,
                                     ParentId = a.ParentId,
                                     ScopeId = a.ScopeId,
                                     TypeFormId = a.TypeFormId,
                                     ExternalUserFunctionalityTypeId = a.ExternalUserFunctionalityTypeId,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateDate = a.UpdateDate,
                                     UpdateUserId = a.UpdateUserId
                                 }).ToList();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddAplicationHierarchy(AplicationHierarchyBE aplicationHierarchy, int systemUserId)
        {
            try
            {
                AplicationHierarchyBE oAplicationHierarchyBE = new AplicationHierarchyBE()
                {
                    //AplicationHierarchyId =  new Common.PersonBL().GetPrimaryKey(1, 12, "OE"),

                    ApplicationHierarchyTypeId = aplicationHierarchy.ApplicationHierarchyTypeId,
                    Level = aplicationHierarchy.Level,
                    Description = aplicationHierarchy.Description,
                    Form = aplicationHierarchy.Form,
                    Code = aplicationHierarchy.Code,
                    ParentId = aplicationHierarchy.ParentId,
                    ScopeId = aplicationHierarchy.ScopeId,
                    TypeFormId = aplicationHierarchy.TypeFormId,
                    ExternalUserFunctionalityTypeId = aplicationHierarchy.ExternalUserFunctionalityTypeId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.AplicationHierarchy.Add(oAplicationHierarchyBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateAplicationHierarchy(AplicationHierarchyBE aplicationHierarchy, int systemUserId)
        {
            try
            {
                var oAplicationHierarchy = (from a in ctx.AplicationHierarchy
                                            where a.ApplicationHierarchyId == aplicationHierarchy.ApplicationHierarchyId
                                            select a).FirstOrDefault();

                if (oAplicationHierarchy == null)
                    return false;

                oAplicationHierarchy.ApplicationHierarchyTypeId = aplicationHierarchy.ApplicationHierarchyTypeId;
                oAplicationHierarchy.Level = aplicationHierarchy.Level;
                oAplicationHierarchy.Description = aplicationHierarchy.Description;
                oAplicationHierarchy.Form = aplicationHierarchy.Form;
                oAplicationHierarchy.Code = aplicationHierarchy.Code;
                oAplicationHierarchy.ParentId = aplicationHierarchy.ParentId;
                oAplicationHierarchy.ScopeId = aplicationHierarchy.ScopeId;
                oAplicationHierarchy.TypeFormId = aplicationHierarchy.TypeFormId;
                oAplicationHierarchy.ExternalUserFunctionalityTypeId = aplicationHierarchy.ExternalUserFunctionalityTypeId;

                //Auditoria

                oAplicationHierarchy.UpdateDate = DateTime.UtcNow;
                oAplicationHierarchy.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAplicationHierarchy(int aplicationHierarchyId, int systemUserId)
        {
            try
            {
                var oAplicationHierarchy = (from a in ctx.AplicationHierarchy
                                            where a.ApplicationHierarchyId == aplicationHierarchyId
                                            select a).FirstOrDefault();

                if (oAplicationHierarchy == null)
                    return false;

                oAplicationHierarchy.UpdateUserId = systemUserId;
                oAplicationHierarchy.UpdateDate = DateTime.UtcNow;
                oAplicationHierarchy.IsDeleted = (int)Enumeratores.SiNo.Si;

                int rows = ctx.SaveChanges();

                return rows > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
