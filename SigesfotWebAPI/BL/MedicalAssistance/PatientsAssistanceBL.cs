using BE.Common;
using BE.MedicalAssistance;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL.MedicalAssistance
{
    public class PatientsAssistanceBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        public BoardPatient GetAllPatientsAssistance(BoardPatient data)
        {
            try
            {
                //Thread.Sleep(20000);
                var isDeleted = (int)Enumeratores.SiNo.No;
                int groupDocTypeId = (int)Enumeratores.DataHierarchy.TypeDoc;
                int genderId = (int)Enumeratores.Parameters.Gender;
                int skip = (data.Index - 1) * data.Take;

                string filterPacient = string.IsNullOrWhiteSpace(data.Patient) ? "" : data.Patient;
                var startDate = data.StartDate.ToString() == "" ? DateTime.Parse("01/01/2000") : data.StartDate;
                var endDate = data.EndDate.ToString() == "" ? DateTime.Parse("01/01/2020") : data.EndDate;

                var preList = (from a in ctx.Service
                            join b in ctx.Person on a.v_PersonId equals b.v_PersonId
                            join c in ctx.DataHierarchy on new { a = b.i_DocTypeId.Value, b = groupDocTypeId } equals new { a = c.i_ItemId, b = c.i_GroupId }
                            join d in ctx.SystemParameter on new { a = b.i_SexTypeId.Value, b = genderId } equals new { a = d.i_ParameterId, b = d.i_GroupId }
                            join e in ctx.Protocol on a.v_ProtocolId equals e.v_ProtocolId
                            join f in ctx.Organization on e.v_CustomerOrganizationId equals f.v_OrganizationId
                            join g in ctx.Location on e.v_CustomerLocationId equals g.v_LocationId
                            join h in ctx.GroupOccupation on e.v_GroupOccupationId equals h.v_GroupOccupationId
                            join i in ctx.SystemParameter on new { a = a.i_MasterServiceId.Value, b = 119 } equals new { a = i.i_ParameterId, b = i.i_GroupId }
                            where a.i_IsDeleted == isDeleted
                                    && (b.v_FirstName.Contains(filterPacient) || b.v_FirstLastName.Contains(filterPacient) || b.v_SecondLastName.Contains(filterPacient) || b.v_DocNumber.Contains(filterPacient))
                                      && (startDate < a.d_ServiceDate && endDate > a.d_ServiceDate)
                            select new Patients
                            {
                                ServiceId = a.v_ServiceId,
                                PatientId = a.v_PersonId,
                                PatientFullName = b.v_FirstName + " " + b.v_FirstLastName + " " + b.v_SecondLastName,
                                DocumentType = c.v_Value1,
                                DocumentNumber = b.v_DocNumber,
                                ServiceDate = a.d_ServiceDate.Value,
                                Occupation = b.v_CurrentOccupation,
                                Birthdate = b.d_Birthdate.Value,
                                Gender = d.v_Value1,
                                ProtocolName = e.v_Name,
                                OrganizationLocation = f.v_Name + " " + g.v_Name,
                                Geso = h.v_Name,
                                MasterServiceId = a.i_MasterServiceId.Value,
                                MasterService = i.v_Value1
                            }).ToList();

                var list = (from a in preList
                            select new Patients
                            {
                                ServiceId = a.ServiceId,
                                PatientId = a.PatientId,
                                PatientFullName = a.PatientFullName,
                                DocumentType = a.DocumentType,
                                DocumentNumber = a.DocumentNumber,
                                ServiceDate = a.ServiceDate,
                                Occupation = a.Occupation,
                                Birthdate = a.Birthdate,
                                Age = Utils.GetAge(a.Birthdate.Value),
                                Gender = a.Gender,
                                ProtocolName =a.ProtocolName,
                                OrganizationLocation = a.OrganizationLocation,
                                Geso = a.Geso,
                                MasterServiceId = a.MasterServiceId,
                                MasterService = a.MasterService
                            }).ToList();

                int totalRecords = list.Count;

                if (data.Take > 0)
                    list = list.Skip(skip).Take(data.Take).ToList();

                data.TotalRecords = totalRecords;
                data.List = list;

                return data;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public List<Schedule> GetSchedule()
        {
            try
            {
                int masterServiceId = (int)Enumeratores.masterService.Assistence;
                var isDeleted = (int)Enumeratores.SiNo.No;
                var list = (from a in ctx.Service
                               join b in ctx.Person on a.v_PersonId equals b.v_PersonId                               
                               where a.i_IsDeleted == isDeleted  
                                        && a.i_MasterServiceId == masterServiceId
                            select new Schedule
                               {
                                   PacientId = a.v_PersonId,
                                   Pacient = b.v_FirstName + " " + b.v_FirstLastName + " " + b.v_SecondLastName,                               
                                   ServiceDate = a.d_ServiceDate.Value                               
                               }).ToList();               

                return list;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<TopDiagnostic> TopDiagnostic()
        {
            try
            {
                //Thread.Sleep(5000);
                var isDeleted = (int)Enumeratores.SiNo.No;
                var list = (from a in ctx.DiagnosticRepository
                            join b in ctx.Diseases on a.v_DiseasesId equals b.v_DiseasesId
                            where a.i_IsDeleted == isDeleted
                            select new 
                            {
                                DiagnosticId = a.v_DiseasesId,
                                Diagnostic = b.v_Name,                               
                            }).ToList();

                var group = list
                            .GroupBy(n => n.Diagnostic)
                            .Select(n => new TopDiagnostic
                            {
                                name = n.Key,
                                y = n.Count()
                            }).OrderByDescending(n => n.y).Take(10);

                return group.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Indicators IndicatorByPacient(string pacientId)
        {
            try
            {
                var serviceComponentFieldValues = (from A in ctx.Service
                                                   join B in ctx.ServiceComponent on A.v_ServiceId equals B.v_ServiceId
                                                   join C in ctx.ServiceComponentFields on B.v_ServiceComponentId equals C.v_ServiceComponentId
                                                   join D in ctx.ServiceComponentFieldValues on C.v_ServiceComponentFieldsId equals D.v_ServiceComponentFieldsId

                                                   where A.v_PersonId == pacientId
                                                           && (C.v_ComponentFieldId == Constants.COLESTEROL_TOTAL_Colesterol_Total_Id || C.v_ComponentFieldId == Constants.PERFIL_LIPIDICO_Colesterol_Total_Id || C.v_ComponentFieldId == Constants.GLUCOSA_Glucosa_Id || C.v_ComponentFieldId == Constants.HEMOGLOBINA_Hemoglobina_Id || C.v_ComponentFieldId == Constants.HEMOGRAMA_Hemoglobina_Id || C.v_ComponentFieldId == Constants.FUNCIONES_VITALES_Presion_Sistolica_Id || C.v_ComponentFieldId == Constants.FUNCIONES_VITALES_Presion_Distolica_Id || C.v_ComponentFieldId == Constants.ANTROPOMETRIA_Peso_Id)
                                                           && B.i_IsDeleted == 0
                                                           && C.i_IsDeleted == 0

                                                   select new 
                                                   {
                                                       ServiceDate = A.d_ServiceDate,
                                                       ComponentFieldId = C.v_ComponentFieldId,
                                                       ServiceComponentFieldsId = C.v_ServiceComponentFieldsId,
                                                       Value1 = D.v_Value1,
                                                   }).ToList();
                Indicators oIndicators = new Indicators();
                oIndicators.PersonId = pacientId;


                #region Weights
                List<Weight> Weights = new List<Weight>();
                var ListWeights = serviceComponentFieldValues.FindAll(p => p.ComponentFieldId == Constants.ANTROPOMETRIA_Peso_Id);
                foreach (var item in ListWeights)
                {
                    var oWeight = new Weight();
                    oWeight.Date = item.ServiceDate.Value.ToString("dd-MM-yyyy");
                    oWeight.y = item.Value1;

                    Weights.Add(oWeight);
                }
                oIndicators.Weights = Weights;
                #endregion

                #region BloodPressureSis
                var BloodPressureSis = new List<BloodPressureSis>();
                var ListBloodPressureSis = serviceComponentFieldValues.FindAll(p => p.ComponentFieldId == Constants.FUNCIONES_VITALES_Presion_Sistolica_Id);
                foreach (var item in ListBloodPressureSis)
                {
                    var oBloodPressureSis = new BloodPressureSis();
                    oBloodPressureSis.Date = item.ServiceDate.Value.ToString("dd-MM-yyyy");
                    oBloodPressureSis.y = item.Value1;

                    BloodPressureSis.Add(oBloodPressureSis);
                }
                oIndicators.BloodPressureSis = BloodPressureSis;
                #endregion

                #region BloodPressureDia
                var BloodPressureDia = new List<BloodPressureDia>();
                var ListBloodPressureDia = serviceComponentFieldValues.FindAll(p => p.ComponentFieldId == Constants.FUNCIONES_VITALES_Presion_Distolica_Id);
                foreach (var item in ListBloodPressureDia)
                {
                    var oBloodPressureDia = new BloodPressureDia();
                    oBloodPressureDia.Date = item.ServiceDate.Value.ToString("dd-MM-yyyy");
                    oBloodPressureDia.y = item.Value1;

                    BloodPressureDia.Add(oBloodPressureDia);
                }
                oIndicators.BloodPressureDia = BloodPressureDia;
                #endregion

                #region Cholesterol
                var Cholesterol = new List<Cholesterol>();
                var ListCholesterol = serviceComponentFieldValues.FindAll(p => p.ComponentFieldId == Constants.COLESTEROL_TOTAL_Colesterol_Total_Id || p.ComponentFieldId == Constants.PERFIL_LIPIDICO_Colesterol_Total_Id);
                foreach (var item in ListCholesterol)
                {
                    var oCholesterol = new Cholesterol();
                    oCholesterol.Date = item.ServiceDate.Value.ToString("dd-MM-yyyy");
                    oCholesterol.y = item.Value1;

                    Cholesterol.Add(oCholesterol);
                }
                oIndicators.Cholesterols = Cholesterol;
                #endregion

                #region Glucoses
                var Glucoses = new List<Glucose>();
                var ListGlucoses = serviceComponentFieldValues.FindAll(p => p.ComponentFieldId == Constants.GLUCOSA_Glucosa_Id);
                foreach (var item in ListGlucoses)
                {
                    var oGlucoses = new Glucose();
                    oGlucoses.Date = item.ServiceDate.Value.ToString("dd-MM-yyyy");
                    oGlucoses.y = item.Value1;

                    Glucoses.Add(oGlucoses);
                }
                oIndicators.Glucoses = Glucoses;
                #endregion

                #region Haemoglobin
                var Haemoglobins = new List<Haemoglobin>();
                var ListHaemoglobins = serviceComponentFieldValues.FindAll(p => p.ComponentFieldId == Constants.HEMOGLOBINA_Hemoglobina_Id || p.ComponentFieldId == Constants.HEMOGRAMA_Hemoglobina_Id);
                foreach (var item in ListHaemoglobins)
                {
                    var oHaemoglobin = new Haemoglobin();
                    oHaemoglobin.Date = item.ServiceDate.Value.ToString("dd-MM-yyyy");
                    oHaemoglobin.y = item.Value1;

                    Haemoglobins.Add(oHaemoglobin);
                }
                oIndicators.Haemoglobins = Haemoglobins;
                #endregion

                return oIndicators;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public int Test()
        {
            try
            {
                int totalRecords = 0;
                for (int i = 0; i < 8000; i++)
                {
                    var preList = (from a in ctx.ServiceComponentFieldValues
                                   select new Patients
                                   {
                                       PatientId = a.v_ServiceComponentFieldValuesId,

                                   }).ToList();

                    totalRecords = preList.Count;
                }
                return totalRecords;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Test2()
        {
            try
            {
                int totalRecords = 0;
                for (int i = 0; i < 5; i++)
                {
                    var preList = (from a in ctx.Diseases
                                   select new Patients
                                   {
                                       PatientId = a.v_DiseasesId,

                                   }).ToList();

                    totalRecords = preList.Count;
                }
                return totalRecords;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
