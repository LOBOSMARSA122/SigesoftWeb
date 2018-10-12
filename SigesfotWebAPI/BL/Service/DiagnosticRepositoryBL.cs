using BE.Common;
using BE.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service
{
    public class DiagnosticRepositoryBL
    {
        public DatabaseContext ctx = new DatabaseContext();
        #region CRUD
        //public DiagnosticRepositoryBE GetDiagnosticRepository(string diagnosticRepositoryId)
        //{
        //    try
        //    {
        //        var objEntity = (from a in ctx.DiagnosticRepository
        //                         where a.DiagnosticRepositoryId == diagnosticRepositoryId
        //                         select a).FirstOrDefault();
        //        return objEntity;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public List<DiagnosticRepositoryBE> GetAllDiagnosticRepository()
        //{
        //    try
        //    {
        //        var isDelete = (int)Enumeratores.SiNo.No;
        //        var objEntity = (from a in ctx.DiagnosticRepository
        //                         where a.IsDeleted == isDelete
        //                         select new DiagnosticRepositoryBE()
        //                         {
        //                                DiagnosticRepositoryId = a.DiagnosticRepositoryId,
        //                                ServiceId = a.ServiceId,
        //                                DiseasesId = a.DiseasesId,
        //                                ComponentId = a.ComponentId,
        //                                ComponentFieldId = a.ComponentFieldId,
        //                                AutoManualId = a.AutoManualId,
        //                                PreQualificationId = a.PreQualificationId,
        //                                FinalQualificationId = a.FinalQualificationId,
        //                                DiagnosticTypeId = a.DiagnosticTypeId,
        //                                IsSentToAntecedent = a.IsSentToAntecedent,
        //                                ExpirationDateDiagnostic = a.ExpirationDateDiagnostic,
        //                                GenerateMedicalBreak = a.GenerateMedicalBreak,
        //                                Recomendations = a.Recomendations,
        //                                DiagnosticSourceId = a.DiagnosticSourceId,
        //                                ShapeAccidentId = a.ShapeAccidentId,
        //                                BodyPartId = a.BodyPartId,
        //                                ClassificationOfWorkAccidentId = a.ClassificationOfWorkAccidentId,
        //                                RiskFactorId = a.RiskFactorId,
        //                                ClassificationOfWorkdiseaseId = a.ClassificationOfWorkdiseaseId,
        //                                SendTointerconsultationId = a.SendTointerconsultationId,
        //                                interconsultationDestinationintId = a.interconsultationDestinationintId,
        //                                IsDeleted = a.IsDeleted,
        //                                InsertUserId = a.InsertUserId,
        //                                InsertDate = a.InsertDate,
        //                                UpdateUserId = a.UpdateUserId,
        //                                UpdateDate = a.UpdateDate,
        //                                interconsultationDestinationId = a.interconsultationDestinationId

        //                         }).ToList();
        //        return objEntity;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public bool AddDiagnosticRepository(DiagnosticRepositoryBE diagnosticRepository, int systemUserId)
        //{
        //    try
        //    {
        //        DiagnosticRepositoryBE oDiagnosticRepositoryBE = new DiagnosticRepositoryBE()
        //        {
        //            DiagnosticRepositoryId =  new Utils().GetPrimaryKey(1, 29, "DR"),
        //            ServiceId = diagnosticRepository.ServiceId,
        //            DiseasesId = diagnosticRepository.DiseasesId,
        //            ComponentId = diagnosticRepository.ComponentId,
        //            ComponentFieldId = diagnosticRepository.ComponentFieldId,
        //            AutoManualId = diagnosticRepository.AutoManualId,
        //            PreQualificationId = diagnosticRepository.PreQualificationId,
        //            FinalQualificationId = diagnosticRepository.FinalQualificationId,
        //            DiagnosticTypeId = diagnosticRepository.DiagnosticTypeId,
        //            IsSentToAntecedent = diagnosticRepository.IsSentToAntecedent,
        //            ExpirationDateDiagnostic = diagnosticRepository.ExpirationDateDiagnostic,
        //            GenerateMedicalBreak = diagnosticRepository.GenerateMedicalBreak,
        //            Recomendations = diagnosticRepository.Recomendations,
        //            DiagnosticSourceId = diagnosticRepository.DiagnosticSourceId,
        //            ShapeAccidentId = diagnosticRepository.ShapeAccidentId,
        //            BodyPartId = diagnosticRepository.BodyPartId,
        //            ClassificationOfWorkAccidentId = diagnosticRepository.ClassificationOfWorkAccidentId,
        //            RiskFactorId = diagnosticRepository.RiskFactorId,
        //            ClassificationOfWorkdiseaseId = diagnosticRepository.ClassificationOfWorkdiseaseId,
        //            SendTointerconsultationId = diagnosticRepository.SendTointerconsultationId,
        //            interconsultationDestinationintId = diagnosticRepository.interconsultationDestinationintId,
        //            interconsultationDestinationId = diagnosticRepository.interconsultationDestinationId,

        //            //Auditoria
        //            IsDeleted = (int)Enumeratores.SiNo.No,
        //            InsertDate = DateTime.UtcNow,
        //            InsertUserId = systemUserId
        //        };
        //        ctx.DiagnosticRepository.Add(oDiagnosticRepositoryBE);

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateDiagnosticRepository(DiagnosticRepositoryBE diagnosticRepository, int systemUserId)
        //{
        //    try
        //    {
        //        var oDiagnosticRepository = (from a in ctx.DiagnosticRepository
        //                                     where a.DiagnosticRepositoryId == diagnosticRepository.DiagnosticRepositoryId
        //                                     select a).FirstOrDefault();
        //        if (oDiagnosticRepository == null)
        //            return false;

        //        oDiagnosticRepository.ServiceId = diagnosticRepository.ServiceId;
        //        oDiagnosticRepository.DiseasesId = diagnosticRepository.DiseasesId;
        //        oDiagnosticRepository.ComponentId = diagnosticRepository.ComponentId;
        //        oDiagnosticRepository.ComponentFieldId = diagnosticRepository.ComponentFieldId;
        //        oDiagnosticRepository.AutoManualId = diagnosticRepository.AutoManualId;
        //        oDiagnosticRepository.PreQualificationId = diagnosticRepository.PreQualificationId;
        //        oDiagnosticRepository.FinalQualificationId = diagnosticRepository.FinalQualificationId;
        //        oDiagnosticRepository.DiagnosticTypeId = diagnosticRepository.DiagnosticTypeId;
        //        oDiagnosticRepository.IsSentToAntecedent = diagnosticRepository.IsSentToAntecedent;
        //        oDiagnosticRepository.ExpirationDateDiagnostic = diagnosticRepository.ExpirationDateDiagnostic;
        //        oDiagnosticRepository.GenerateMedicalBreak = diagnosticRepository.GenerateMedicalBreak;
        //        oDiagnosticRepository.Recomendations = diagnosticRepository.Recomendations;
        //        oDiagnosticRepository.DiagnosticSourceId = diagnosticRepository.DiagnosticSourceId; 
        //        oDiagnosticRepository.ShapeAccidentId = diagnosticRepository.ShapeAccidentId;
        //        oDiagnosticRepository.BodyPartId = diagnosticRepository.BodyPartId;
        //        oDiagnosticRepository.ClassificationOfWorkAccidentId = diagnosticRepository.ClassificationOfWorkAccidentId;
        //        oDiagnosticRepository.RiskFactorId = diagnosticRepository.RiskFactorId;
        //        oDiagnosticRepository.ClassificationOfWorkdiseaseId = diagnosticRepository.ClassificationOfWorkdiseaseId;
        //        oDiagnosticRepository.SendTointerconsultationId = diagnosticRepository.SendTointerconsultationId;
        //        oDiagnosticRepository.interconsultationDestinationintId = diagnosticRepository.interconsultationDestinationintId;
        //        oDiagnosticRepository.interconsultationDestinationId = diagnosticRepository.interconsultationDestinationId;

        //        //Auditoria
        //        oDiagnosticRepository.UpdateDate = DateTime.UtcNow;
        //        oDiagnosticRepository.UpdateUserId = systemUserId;

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool DeleteDiagnosticRepository(string diagnosticRepositoryId, int systemUserId)
        //{
        //    try
        //    {
        //        var oDiagnosticRepository = (from a in ctx.DiagnosticRepository
        //                                     where a.DiagnosticRepositoryId == diagnosticRepositoryId
        //                                     select a).FirstOrDefault();

        //        if (oDiagnosticRepository == null)
        //            return false;

        //        oDiagnosticRepository.UpdateUserId = systemUserId;
        //        oDiagnosticRepository.UpdateDate = DateTime.UtcNow;
        //        oDiagnosticRepository.IsDeleted = (int)Enumeratores.SiNo.Si;

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        #endregion
    }
}
