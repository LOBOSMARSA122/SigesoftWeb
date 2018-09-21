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
    public class ServiceBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public ServiceBE ServiceGes(string serviceId)
        {
            try
            {
                var objEntity = (from a in ctx.Service
                                 where a.ServiceId == serviceId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ServiceBE> GetAllService()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Service
                                 where a.IsDeleted == isDelete
                                 select new ServiceBE()
                                 {
                                     ServiceId = a.ServiceId,
                                     ProtocolId = a.ProtocolId,
                                     PersonId = a.PersonId,
                                     MasterServiceId = a.MasterServiceId,
                                     ServiceStatusId = a.ServiceStatusId,
                                     Motive = a.Motive,
                                     AptitudeStatusId = a.AptitudeStatusId,
                                     ServiceDate = a.ServiceDate,
                                     GlobalExpirationDate = a.GlobalExpirationDate,
                                     ObsExpirationDate = a.ObsExpirationDate,
                                     FlagAgentId = a.FlagAgentId,
                                     OrganizationId = a.OrganizationId,
                                     LocationId = a.LocationId,
                                     MainSymptom = a.MainSymptom,
                                     TimeOfDisease = a.TimeOfDisease,
                                     TimeOfDiseaseTypeId = a.TimeOfDiseaseTypeId,
                                     Story = a.Story,
                                     DreamId = a.DreamId,
                                     UrineId = a.UrineId,
                                     DepositionId = a.DepositionId,
                                     AppetiteId = a.AppetiteId,
                                     ThirstId = a.ThirstId,
                                     Fur = a.Fur,
                                     CatemenialRegime = a.CatemenialRegime,
                                     MacId = a.MacId,
                                     IsNewControl = a.IsNewControl,
                                     HasMedicalBreakId = a.HasMedicalBreakId,
                                     MedicalBreakStartDate = a.MedicalBreakStartDate,
                                     MedicalBreakEndDate = a.MedicalBreakEndDate,
                                     GeneralRecomendations = a.GeneralRecomendations,
                                     DestinationMedicationId = a.DestinationMedicationId,
                                     TransportMedicationId = a.TransportMedicationId,
                                     StartDateRestriction = a.StartDateRestriction,
                                     EndDateRestriction = a.EndDateRestriction,
                                     HasRestrictionId = a.HasRestrictionId,
                                     HasSymptomId = a.HasSymptomId,

                                     NextAppointment = a.NextAppointment,

                                     SendToTracking = a.SendToTracking,
                                     InsertUserMedicalAnalystId = a.InsertUserMedicalAnalystId,
                                     UpdateUserMedicalAnalystId = a.UpdateUserMedicalAnalystId,
                                     InsertDateMedicalAnalyst = a.InsertDateMedicalAnalyst,
                                     UpdateDateMedicalAnalyst = a.UpdateDateMedicalAnalyst,
                                     InsertUserOccupationalMedicalId = a.InsertUserOccupationalMedicalId,
                                     UpdateUserOccupationalMedicaltId = a.UpdateUserOccupationalMedicaltId,
                                     InsertDateOccupationalMedical = a.InsertDateOccupationalMedical,
                                     UpdateDateOccupationalMedical = a.UpdateDateOccupationalMedical,
                                     HazinterconsultationId = a.HazinterconsultationId,
                                     Gestapara = a.Gestapara,
                                     Menarquia = a.Menarquia,
                                     PAP = a.PAP,
                                     Mamografia = a.Mamografia,
                                     CiruGine = a.CiruGine,
                                     Findings = a.Findings,
                                     StatusLiquidation = a.StatusLiquidation,
                                     ServiceTypeOfInsurance = a.ServiceTypeOfInsurance,
                                     ModalityOfInsurance = a.ModalityOfInsurance,
                                     IsFac = a.IsFac,
                                     InicioEnf = a.InicioEnf,
                                     CursoEnf = a.CursoEnf,
                                     Evolucion = a.Evolucion,
                                     ExaAuxResult = a.ExaAuxResult,
                                     ObsStatusService = a.ObsStatusService,
                                     FechaEntrega = a.FechaEntrega,
                                     AreaId = a.AreaId,
                                     FechaUltimoPAP = a.FechaUltimoPAP,
                                     ResultadosPAP = a.ResultadosPAP,
                                     FechaUltimaMamo = a.FechaUltimaMamo,
                                     ResultadoMamo = a.ResultadoMamo,
                                     Costo = a.Costo,
                                     EnvioCertificado = a.EnvioCertificado,
                                     EnvioHistoria = a.EnvioHistoria,
                                     IdVentaCliente = a.IdVentaCliente,
                                     IdVentaAseguradora = a.IdVentaAseguradora,
                                     InicioVidaSexaul = a.InicioVidaSexaul,
                                     NroParejasActuales = a.NroParejasActuales,
                                     NroAbortos = a.NroAbortos,
                                     PrecisarCausas = a.PrecisarCausas,
                                     MedicoTratanteId = a.MedicoTratanteId,
                                     IsFacMedico = a.IsFacMedico,
                                     centrocosto = a.centrocosto,
                                     NroLiquidacion = a.NroLiquidacion,

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

        public bool AddService(ServiceBE service, int systemUserId)
        {
            try
            {
                ServiceBE oServiceBE = new ServiceBE()
                {
                    ServiceId = BE.Utils.GetPrimaryKey(1, 23, "SR"),
                    ProtocolId = service.ProtocolId,
                    PersonId = service.PersonId,
                    MasterServiceId = service.MasterServiceId,
                    ServiceStatusId = service.ServiceStatusId,
                    Motive = service.Motive,
                    AptitudeStatusId = service.AptitudeStatusId,
                    ServiceDate = service.ServiceDate,
                    GlobalExpirationDate = service.GlobalExpirationDate,
                    ObsExpirationDate = service.ObsExpirationDate,
                    FlagAgentId = service.FlagAgentId,
                    OrganizationId = service.OrganizationId,
                    LocationId = service.LocationId,
                    MainSymptom = service.MainSymptom,
                    TimeOfDisease = service.TimeOfDisease,
                    TimeOfDiseaseTypeId = service.TimeOfDiseaseTypeId,
                    Story = service.Story,
                    DreamId = service.DreamId,
                    UrineId = service.UrineId,
                    DepositionId = service.DepositionId,
                    AppetiteId = service.AppetiteId,
                    ThirstId = service.ThirstId,
                    Fur = service.Fur,
                    CatemenialRegime = service.CatemenialRegime,
                    MacId = service.MacId,
                    IsNewControl = service.IsNewControl,
                    HasMedicalBreakId = service.HasMedicalBreakId,
                    MedicalBreakStartDate = service.MedicalBreakStartDate,
                    MedicalBreakEndDate = service.MedicalBreakEndDate,
                    GeneralRecomendations = service.GeneralRecomendations,
                    DestinationMedicationId = service.DestinationMedicationId,
                    TransportMedicationId = service.TransportMedicationId,
                    StartDateRestriction = service.StartDateRestriction,
                    EndDateRestriction = service.EndDateRestriction,
                    HasRestrictionId = service.HasRestrictionId,
                    HasSymptomId = service.HasSymptomId,

                    NextAppointment = service.NextAppointment,

                    SendToTracking = service.SendToTracking,
                    InsertUserMedicalAnalystId = service.InsertUserMedicalAnalystId,
                    UpdateUserMedicalAnalystId = service.UpdateUserMedicalAnalystId,
                    InsertDateMedicalAnalyst = service.InsertDateMedicalAnalyst,
                    UpdateDateMedicalAnalyst = service.UpdateDateMedicalAnalyst,
                    InsertUserOccupationalMedicalId = service.InsertUserOccupationalMedicalId,
                    UpdateUserOccupationalMedicaltId = service.UpdateUserOccupationalMedicaltId,
                    InsertDateOccupationalMedical = service.InsertDateOccupationalMedical,
                    UpdateDateOccupationalMedical = service.UpdateDateOccupationalMedical,
                    HazinterconsultationId = service.HazinterconsultationId,
                    Gestapara = service.Gestapara,
                    Menarquia = service.Menarquia,
                    PAP = service.PAP,
                    Mamografia = service.Mamografia,
                    CiruGine = service.CiruGine,
                    Findings = service.Findings,
                    StatusLiquidation = service.StatusLiquidation,
                    ServiceTypeOfInsurance = service.ServiceTypeOfInsurance,
                    ModalityOfInsurance = service.ModalityOfInsurance,
                    IsFac = service.IsFac,
                    InicioEnf = service.InicioEnf,
                    CursoEnf = service.CursoEnf,
                    Evolucion = service.Evolucion,
                    ExaAuxResult = service.ExaAuxResult,
                    ObsStatusService = service.ObsStatusService,
                    FechaEntrega = service.FechaEntrega,
                    AreaId = service.AreaId,
                    FechaUltimoPAP = service.FechaUltimoPAP,
                    ResultadosPAP = service.ResultadosPAP,
                    FechaUltimaMamo = service.FechaUltimaMamo,
                    ResultadoMamo = service.ResultadoMamo,
                    Costo = service.Costo,
                    EnvioCertificado = service.EnvioCertificado,
                    EnvioHistoria = service.EnvioHistoria,
                    IdVentaCliente = service.IdVentaCliente,
                    IdVentaAseguradora = service.IdVentaAseguradora,
                    InicioVidaSexaul = service.InicioVidaSexaul,
                    NroParejasActuales = service.NroParejasActuales,
                    NroAbortos = service.NroAbortos,
                    PrecisarCausas = service.PrecisarCausas,
                    MedicoTratanteId = service.MedicoTratanteId,
                    IsFacMedico = service.IsFacMedico,
                    centrocosto = service.centrocosto,
                    NroLiquidacion = service.NroLiquidacion,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.Service.Add(oServiceBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateService(ServiceBE service, int systemUserId)
        {
            try
            {
                var oService = (from a in ctx.Service
                            where a.ServiceId == service.ServiceId
                            select a).FirstOrDefault();

                if (oService == null)
                    return false;

                oService.ProtocolId = service.ProtocolId;
                oService.PersonId = service.PersonId;
                oService.MasterServiceId = service.MasterServiceId;
                oService.ServiceStatusId = service.ServiceStatusId;
                oService.Motive = service.Motive;
                oService.AptitudeStatusId = service.AptitudeStatusId;
                oService.ServiceDate = service.ServiceDate;
                oService.GlobalExpirationDate = service.GlobalExpirationDate;
                oService.ObsExpirationDate = service.ObsExpirationDate;
                oService.FlagAgentId = service.FlagAgentId;
                oService.OrganizationId = service.OrganizationId;
                oService.LocationId = service.LocationId;
                oService.MainSymptom = service.MainSymptom;
                oService.TimeOfDisease = service.TimeOfDisease;
                oService.TimeOfDiseaseTypeId = service.TimeOfDiseaseTypeId;
                oService.Story = service.Story;
                oService.DreamId = service.DreamId;
                oService.UrineId = service.UrineId;
                oService.DepositionId = service.DepositionId;
                oService.AppetiteId = service.AppetiteId;
                oService.ThirstId = service.ThirstId;
                oService.Fur = service.Fur;
                oService.CatemenialRegime = service.CatemenialRegime;
                oService.MacId = service.MacId;
                oService.IsNewControl = service.IsNewControl;
                oService.HasMedicalBreakId = service.HasMedicalBreakId;
                oService.MedicalBreakStartDate = service.MedicalBreakStartDate;
                oService.MedicalBreakEndDate = service.MedicalBreakEndDate;
                oService.GeneralRecomendations = service.GeneralRecomendations;
                oService.DestinationMedicationId = service.DestinationMedicationId;
                oService.TransportMedicationId = service.TransportMedicationId;
                oService.StartDateRestriction = service.StartDateRestriction;
                oService.EndDateRestriction = service.EndDateRestriction;
                oService.HasRestrictionId = service.HasRestrictionId;
                oService.HasSymptomId = service.HasSymptomId;

                oService.NextAppointment = service.NextAppointment;

                oService.SendToTracking = service.SendToTracking;
                oService.InsertUserMedicalAnalystId = service.InsertUserMedicalAnalystId;
                oService.UpdateUserMedicalAnalystId = service.UpdateUserMedicalAnalystId;
                oService.InsertDateMedicalAnalyst = service.InsertDateMedicalAnalyst;
                oService.UpdateDateMedicalAnalyst = service.UpdateDateMedicalAnalyst;
                oService.InsertUserOccupationalMedicalId = service.InsertUserOccupationalMedicalId;
                oService.UpdateUserOccupationalMedicaltId = service.UpdateUserOccupationalMedicaltId;
                oService.InsertDateOccupationalMedical = service.InsertDateOccupationalMedical;
                oService.UpdateDateOccupationalMedical = service.UpdateDateOccupationalMedical;
                oService.HazinterconsultationId = service.HazinterconsultationId;
                oService.Gestapara = service.Gestapara;
                oService.Menarquia = service.Menarquia;
                oService.PAP = service.PAP;
                oService.Mamografia = service.Mamografia;
                oService.CiruGine = service.CiruGine;
                oService.Findings = service.Findings;
                oService.StatusLiquidation = service.StatusLiquidation;
                oService.ServiceTypeOfInsurance = service.ServiceTypeOfInsurance;
                oService.ModalityOfInsurance = service.ModalityOfInsurance;
                oService.IsFac = service.IsFac;
                oService.InicioEnf = service.InicioEnf;
                oService.CursoEnf = service.CursoEnf;
                oService.Evolucion = service.Evolucion;
                oService.ExaAuxResult = service.ExaAuxResult;
                oService.ObsStatusService = service.ObsStatusService;
                oService.FechaEntrega = service.FechaEntrega;
                oService.AreaId = service.AreaId;
                oService.FechaUltimoPAP = service.FechaUltimoPAP;
                oService.ResultadosPAP = service.ResultadosPAP;
                oService.FechaUltimaMamo = service.FechaUltimaMamo;
                oService.ResultadoMamo = service.ResultadoMamo;
                oService.Costo = service.Costo;
                oService.EnvioCertificado = service.EnvioCertificado;
                oService.EnvioHistoria = service.EnvioHistoria;
                oService.IdVentaCliente = service.IdVentaCliente;
                oService.IdVentaAseguradora = service.IdVentaAseguradora;
                oService.InicioVidaSexaul = service.InicioVidaSexaul;
                oService.NroParejasActuales = service.NroParejasActuales;
                oService.NroAbortos = service.NroAbortos;
                oService.PrecisarCausas = service.PrecisarCausas;
                oService.MedicoTratanteId = service.MedicoTratanteId;
                oService.IsFacMedico = service.IsFacMedico;
                oService.centrocosto = service.centrocosto;
                oService.NroLiquidacion = service.NroLiquidacion;

                //Auditoria

                oService.UpdateDate = DateTime.UtcNow;
                oService.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Service(string serviceId, int systemUserId)
        {
            try
            {
                var oService = (from a in ctx.Service
                            where a.ServiceId == serviceId
                            select a).FirstOrDefault();

                if (oService == null)
                    return false;

                oService.UpdateUserId = systemUserId;
                oService.UpdateDate = DateTime.UtcNow;
                oService.IsDeleted = (int)Enumeratores.SiNo.Si;

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
