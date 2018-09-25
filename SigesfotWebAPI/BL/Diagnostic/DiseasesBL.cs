using BE.Common;
using BE.Diagnostic;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Diagnostic
{
    public class DiseasesBL
    {
        public DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public DiseasesBE GetDiseases(string diseasesId)
        {
            try
            {
                var objEntity = (from a in ctx.Diseases
                                 where a.DiseasesId == diseasesId
                                 select a).FirstOrDefault();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DiseasesBE> GetAllDiseases()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Diseases
                                 where a.IsDeleted == isDelete
                                 select new DiseasesBE()
                                 {
                                     DiseasesId = a.DiseasesId,
                                     CIE10Id = a.CIE10Id,
                                     Name = a.Name,
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

        public bool AddDiseases(DiseasesBE diseases, int systemUserId)
        {
            try
            {
                DiseasesBE oDiseasesBE = new DiseasesBE()
                {
                    DiseasesId =  new Common.PersonBL().GetPrimaryKey(1, 27, "DD"),
                    CIE10Id = diseases.CIE10Id,
                    Name = diseases.Name,              

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };
                ctx.Diseases.Add(oDiseasesBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDiseases(DiseasesBE diseases, int systemUserId)
        {
            try
            {
                var oDiseases = (from a in ctx.Diseases
                                 where a.DiseasesId == diseases.DiseasesId
                                 select a).FirstOrDefault();
                if (oDiseases == null)
                    return false;

                oDiseases.CIE10Id = diseases.CIE10Id;
                oDiseases.Name = diseases.Name;

                //Auditoria
                oDiseases.UpdateDate = DateTime.UtcNow;
                oDiseases.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDiseases(string diseasesId, int systemUserId)
        {
            try
            {
                var oDiseases = (from a in ctx.Diseases
                                  where a.DiseasesId == diseasesId
                                  select a).FirstOrDefault();

                if (oDiseases == null)
                    return false;

                oDiseases.UpdateUserId = systemUserId;
                oDiseases.UpdateDate = DateTime.UtcNow;
                oDiseases.IsDeleted = (int)Enumeratores.SiNo.Si;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
