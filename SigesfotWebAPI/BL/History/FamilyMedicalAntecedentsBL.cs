using BE.Common;
using BE.History;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.History
{
    public class FamilyMedicalAntecedentsBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD

        public FamilyMedicalAntecedentsBE GetFamilyMedicalAntecedents(string familyMedicalAntecedentsId)    
        {
            try
            {
                var objEntity = (from a in ctx.FamilyMedicalAntecedents
                                 where a.FamilyMedicalAntecedentsId == familyMedicalAntecedentsId
                                 select a).FirstOrDefault();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<FamilyMedicalAntecedentsBE> GetAllFamilyMedicalAntecedents()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.FamilyMedicalAntecedents
                                 where a.IsDeleted == isDelete
                                 select new FamilyMedicalAntecedentsBE()
                                 {
                                     FamilyMedicalAntecedentsId = a.FamilyMedicalAntecedentsId,
                                     PersonId = a.PersonId,
                                     DiseasesId = a.DiseasesId,
                                     TypeFamilyId = a.TypeFamilyId,
                                     Comment = a.Comment,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateUserId = a.UpdateUserId,
                                     UpdateDate = a.UpdateDate
                                 }).ToList();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public bool AddFamilyMedicalAntecedents(FamilyMedicalAntecedentsBE familyMedicalAntecedents, int systemUserId)
        {
            try
            {
                FamilyMedicalAntecedentsBE oFamilyMedicalAntecedentsBE = new FamilyMedicalAntecedentsBE()
                {
                    FamilyMedicalAntecedentsId =  new Utils().GetPrimaryKey(1, 42, "FA"),
                    PersonId = familyMedicalAntecedents.PersonId,
                    DiseasesId = familyMedicalAntecedents.DiseasesId,
                    TypeFamilyId = familyMedicalAntecedents.TypeFamilyId,
                    Comment = familyMedicalAntecedents.Comment,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.FamilyMedicalAntecedents.Add(oFamilyMedicalAntecedentsBE);

                var rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateFamilyMedicalAntecedents(FamilyMedicalAntecedentsBE familyMedicalAntecedents, int systemUserId)
        {
            try
            {
                var oFamilyMedicalAntecedents = (from a in ctx.FamilyMedicalAntecedents
                                                 where a.FamilyMedicalAntecedentsId == familyMedicalAntecedents.FamilyMedicalAntecedentsId
                                                 select a).FirstOrDefault();

                if(oFamilyMedicalAntecedents == null)
                    return false;

                oFamilyMedicalAntecedents.PersonId = familyMedicalAntecedents.PersonId;
                oFamilyMedicalAntecedents.DiseasesId = familyMedicalAntecedents.DiseasesId;
                oFamilyMedicalAntecedents.TypeFamilyId = familyMedicalAntecedents.TypeFamilyId;
                oFamilyMedicalAntecedents.Comment = familyMedicalAntecedents.Comment;

                //Auditoria
                oFamilyMedicalAntecedents.InsertDate = DateTime.UtcNow;
                oFamilyMedicalAntecedents.InsertUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteFamilyMedicalAntecedents (string familyMedicalAntecedentsId, int systemUserId)
        {
            try
            {
                var oFamilyMedicalAntecedents = (from a in ctx.FamilyMedicalAntecedents
                                                 where a.FamilyMedicalAntecedentsId == familyMedicalAntecedentsId
                                                 select a).FirstOrDefault();

                if (oFamilyMedicalAntecedents == null)
                    return false;

                oFamilyMedicalAntecedents.UpdateDate = DateTime.UtcNow;
                oFamilyMedicalAntecedents.UpdateUserId = systemUserId;
                oFamilyMedicalAntecedents.IsDeleted = (int)Enumeratores.SiNo.Si;

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
