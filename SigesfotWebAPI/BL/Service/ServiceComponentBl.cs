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
    public class ServiceComponentBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        //public ServiceComponentBE GetServiceComponent(string serviceComponentId)
        //{
        //    try
        //    {
        //        var objEntity = (from a in ctx.ServiceComponent
        //                         where a.ServiceComponentId == serviceComponentId
        //                         select a).FirstOrDefault();

        //        return objEntity;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public List<ServiceComponentBE> GetAllServiceComponent()
        //{
        //    try
        //    {
        //        var isDelete = (int)Enumeratores.SiNo.No;
        //        var objEntity = (from a in ctx.ServiceComponent
        //                         where a.IsDeleted == isDelete
        //                         select new ServiceComponentBE()
        //                         {
        //                             ServiceComponentId = a.ServiceComponentId,
        //                             ServiceId = a.ServiceId,
        //                             ComponentId = a.ComponentId,
        //                             ServiceComponentStatusId = a.ServiceComponentStatusId,
        //                             ExternalinternalId = a.ExternalinternalId,
        //                             ServiceComponentTypeId = a.ServiceComponentTypeId,
        //                             IsVisibleId = a.IsVisibleId,
        //                             IsInheritedId = a.IsInheritedId,
        //                             CalledDate = a.CalledDate,
        //                             StartDate = a.StartDate,
        //                             EndDate = a.EndDate,
        //                             index = a.index,
        //                             Price = a.Price,
        //                             IsInvoicedId = a.IsInvoicedId,
        //                             IsRequiredId = a.IsRequiredId,
        //                             IsManuallyAddedId = a.IsManuallyAddedId,
        //                             QueueStatusId = a.QueueStatusId,
        //                             NameOfice = a.NameOfice,
        //                             Comment = a.Comment,
        //                             Iscalling = a.Iscalling,
        //                             IsApprovedId = a.IsApprovedId,

        //                             ApprovedInsertUserId = a.ApprovedInsertUserId,
        //                             ApprovedUpdateUserId = a.ApprovedUpdateUserId,
        //                             ApprovedInsertDate = a.ApprovedInsertDate,
        //                             ApprovedUpdateDate = a.ApprovedUpdateDate,
        //                             InsertUserMedicalAnalystId = a.InsertUserMedicalAnalystId,
        //                             UpdateUserMedicalAnalystId = a.UpdateUserMedicalAnalystId,
        //                             InsertDateMedicalAnalyst = a.InsertDateMedicalAnalyst,
        //                             UpdateDateMedicalAnalyst = a.UpdateDateMedicalAnalyst,
        //                             InsertUserTechnicalDataRegisterId = a.InsertUserTechnicalDataRegisterId,
        //                             UpdateUserTechnicalDataRegisterId = a.UpdateUserTechnicalDataRegisterId,
        //                             InsertDateTechnicalDataRegister = a.InsertDateTechnicalDataRegister,
        //                             UpdateDateTechnicalDataRegister = a.UpdateDateTechnicalDataRegister,
        //                             Iscalling_1 = a.Iscalling_1,
        //                             AuditorInsertUserId = a.AuditorInsertUserId,
        //                             AuditorInsertUser = a.AuditorInsertUser,
        //                             AuditorUpdateUserId = a.AuditorUpdateUserId,
        //                             AuditorUpdateUser = a.AuditorUpdateUser,
        //                             IdUnidadProductiva = a.IdUnidadProductiva,
        //                             SaldoPaciente = a.SaldoPaciente,
        //                             SaldoAseguradora = a.SaldoAseguradora,
        //                             MedicoTratanteId = a.MedicoTratanteId,
        //                             SystemUserEspecialistaId = a.SystemUserEspecialistaId,

        //                             IsDeleted = a.IsDeleted,
        //                             InsertUserId = a.InsertUserId,
        //                             InsertDate = a.InsertDate,
        //                             UpdateDate = a.UpdateDate,
        //                             UpdateUserId = a.UpdateUserId
        //                         }).ToList();

        //        return objEntity;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public bool AddServiceComponent(ServiceComponentBE serviceComponent, int systemUserId)
        //{
        //    try
        //    {
        //        ServiceComponentBE oServiceComponentBE = new ServiceComponentBE()
        //        {
        //            ServiceComponentId =  new Utils().GetPrimaryKey(1, 24, "SC"),
        //            ServiceId = serviceComponent.ServiceId,
        //            ComponentId = serviceComponent.ComponentId,
        //            ServiceComponentStatusId = serviceComponent.ServiceComponentStatusId,
        //            ExternalinternalId = serviceComponent.ExternalinternalId,
        //            ServiceComponentTypeId = serviceComponent.ServiceComponentTypeId,
        //            IsVisibleId = serviceComponent.IsVisibleId,
        //            IsInheritedId = serviceComponent.IsInheritedId,
        //            CalledDate = serviceComponent.CalledDate,
        //            StartDate = serviceComponent.StartDate,
        //            EndDate = serviceComponent.EndDate,
        //            index = serviceComponent.index,
        //            Price = serviceComponent.Price,
        //            IsInvoicedId = serviceComponent.IsInvoicedId,
        //            IsRequiredId = serviceComponent.IsRequiredId,
        //            IsManuallyAddedId = serviceComponent.IsManuallyAddedId,
        //            QueueStatusId = serviceComponent.QueueStatusId,
        //            NameOfice = serviceComponent.NameOfice,
        //            Comment = serviceComponent.Comment,
        //            Iscalling = serviceComponent.Iscalling,
        //            IsApprovedId = serviceComponent.IsApprovedId,

        //            ApprovedInsertUserId = serviceComponent.ApprovedInsertUserId,
        //            ApprovedUpdateUserId = serviceComponent.ApprovedUpdateUserId,
        //            ApprovedInsertDate = serviceComponent.ApprovedInsertDate,
        //            ApprovedUpdateDate = serviceComponent.ApprovedUpdateDate,
        //            InsertUserMedicalAnalystId = serviceComponent.InsertUserMedicalAnalystId,
        //            UpdateUserMedicalAnalystId = serviceComponent.UpdateUserMedicalAnalystId,
        //            InsertDateMedicalAnalyst = serviceComponent.InsertDateMedicalAnalyst,
        //            UpdateDateMedicalAnalyst = serviceComponent.UpdateDateMedicalAnalyst,
        //            InsertUserTechnicalDataRegisterId = serviceComponent.InsertUserTechnicalDataRegisterId,
        //            UpdateUserTechnicalDataRegisterId = serviceComponent.UpdateUserTechnicalDataRegisterId,
        //            InsertDateTechnicalDataRegister = serviceComponent.InsertDateTechnicalDataRegister,
        //            UpdateDateTechnicalDataRegister = serviceComponent.UpdateDateTechnicalDataRegister,
        //            Iscalling_1 = serviceComponent.Iscalling_1,
        //            AuditorInsertUserId = serviceComponent.AuditorInsertUserId,
        //            AuditorInsertUser = serviceComponent.AuditorInsertUser,
        //            AuditorUpdateUserId = serviceComponent.AuditorUpdateUserId,
        //            AuditorUpdateUser = serviceComponent.AuditorUpdateUser,
        //            IdUnidadProductiva = serviceComponent.IdUnidadProductiva,
        //            SaldoPaciente = serviceComponent.SaldoPaciente,
        //            SaldoAseguradora = serviceComponent.SaldoAseguradora,
        //            MedicoTratanteId = serviceComponent.MedicoTratanteId,
        //            SystemUserEspecialistaId = serviceComponent.SystemUserEspecialistaId,

        //            //Auditoria
        //            IsDeleted = (int)Enumeratores.SiNo.No,
        //            InsertDate = DateTime.UtcNow,
        //            InsertUserId = systemUserId,
        //        };

        //        ctx.ServiceComponent.Add(oServiceComponentBE);

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateServiceComponent(ServiceComponentBE serviceComponent, int systemUserId)
        //{
        //    try
        //    {
        //        var oServiceComponent = (from a in ctx.ServiceComponent
        //                    where a.ServiceComponentId == serviceComponent.ServiceComponentId
        //                                 select a).FirstOrDefault();

        //        if (oServiceComponent == null)
        //            return false;

        //        oServiceComponent.ServiceId = serviceComponent.ServiceId;
        //        oServiceComponent.ComponentId = serviceComponent.ComponentId;
        //        oServiceComponent.ServiceComponentStatusId = serviceComponent.ServiceComponentStatusId;
        //        oServiceComponent.ExternalinternalId = serviceComponent.ExternalinternalId;
        //        oServiceComponent.ServiceComponentTypeId = serviceComponent.ServiceComponentTypeId;
        //        oServiceComponent.IsVisibleId = serviceComponent.IsVisibleId;
        //        oServiceComponent.IsInheritedId = serviceComponent.IsInheritedId;
        //        oServiceComponent.CalledDate = serviceComponent.CalledDate;
        //        oServiceComponent.StartDate = serviceComponent.StartDate;
        //        oServiceComponent.EndDate = serviceComponent.EndDate;
        //        oServiceComponent.index = serviceComponent.index;
        //        oServiceComponent.Price = serviceComponent.Price;
        //        oServiceComponent.IsInvoicedId = serviceComponent.IsInvoicedId;
        //        oServiceComponent.IsRequiredId = serviceComponent.IsRequiredId;
        //        oServiceComponent.IsManuallyAddedId = serviceComponent.IsManuallyAddedId;
        //        oServiceComponent.QueueStatusId = serviceComponent.QueueStatusId;
        //        oServiceComponent.NameOfice = serviceComponent.NameOfice;
        //        oServiceComponent.Comment = serviceComponent.Comment;
        //        oServiceComponent.Iscalling = serviceComponent.Iscalling;
        //        oServiceComponent.IsApprovedId = serviceComponent.IsApprovedId;

        //        oServiceComponent.ApprovedInsertUserId = serviceComponent.ApprovedInsertUserId;
        //        oServiceComponent.ApprovedUpdateUserId = serviceComponent.ApprovedUpdateUserId;
        //        oServiceComponent.ApprovedInsertDate = serviceComponent.ApprovedInsertDate;
        //        oServiceComponent.ApprovedUpdateDate = serviceComponent.ApprovedUpdateDate;
        //        oServiceComponent.InsertUserMedicalAnalystId = serviceComponent.InsertUserMedicalAnalystId;
        //        oServiceComponent.UpdateUserMedicalAnalystId = serviceComponent.UpdateUserMedicalAnalystId;
        //        oServiceComponent.InsertDateMedicalAnalyst = serviceComponent.InsertDateMedicalAnalyst;
        //        oServiceComponent.UpdateDateMedicalAnalyst = serviceComponent.UpdateDateMedicalAnalyst;
        //        oServiceComponent.InsertUserTechnicalDataRegisterId = serviceComponent.InsertUserTechnicalDataRegisterId;
        //        oServiceComponent.UpdateUserTechnicalDataRegisterId = serviceComponent.UpdateUserTechnicalDataRegisterId;
        //        oServiceComponent.InsertDateTechnicalDataRegister = serviceComponent.InsertDateTechnicalDataRegister;
        //        oServiceComponent.UpdateDateTechnicalDataRegister = serviceComponent.UpdateDateTechnicalDataRegister;
        //        oServiceComponent.Iscalling_1 = serviceComponent.Iscalling_1;
        //        oServiceComponent.AuditorInsertUserId = serviceComponent.AuditorInsertUserId;
        //        oServiceComponent.AuditorInsertUser = serviceComponent.AuditorInsertUser;
        //        oServiceComponent.AuditorUpdateUserId = serviceComponent.AuditorUpdateUserId;
        //        oServiceComponent.AuditorUpdateUser = serviceComponent.AuditorUpdateUser;
        //        oServiceComponent.IdUnidadProductiva = serviceComponent.IdUnidadProductiva;
        //        oServiceComponent.SaldoPaciente = serviceComponent.SaldoPaciente;
        //        oServiceComponent.SaldoAseguradora = serviceComponent.SaldoAseguradora;
        //        oServiceComponent.MedicoTratanteId = serviceComponent.MedicoTratanteId;
        //        oServiceComponent.SystemUserEspecialistaId = serviceComponent.SystemUserEspecialistaId;

        //        //Auditoria

        //        oServiceComponent.UpdateDate = DateTime.UtcNow;
        //        oServiceComponent.UpdateUserId = systemUserId;

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool DeleteServiceComponent(string serviceComponentId, int systemUserId)
        //{
        //    try
        //    {
        //        var oServiceComponent = (from a in ctx.ServiceComponent
        //                    where a.ServiceComponentId == serviceComponentId
        //                    select a).FirstOrDefault();

        //        if (oServiceComponent == null)
        //            return false;

        //        oServiceComponent.UpdateUserId = systemUserId;
        //        oServiceComponent.UpdateDate = DateTime.UtcNow;
        //        oServiceComponent.IsDeleted = (int)Enumeratores.SiNo.Si;

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        #endregion
    }
}
