using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class PacientBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD



        #endregion

        #region Bussiness Logic
        public BoardPacient GetAllPacients(BoardPacient data)
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                int groupDocTypeId = (int)Enumeratores.DataHierarchy.TypeDoc;
                int skip = (data.Index - 1) * data.Take;

                //filters
                string filterPacient = string.IsNullOrWhiteSpace(data.Pacient) ? "" : data.Pacient;
                string filterDocNumber = string.IsNullOrWhiteSpace(data.DocNumber) ? "" : data.DocNumber;

                var list = (from a in ctx.Pacient
                            join b in ctx.Person on a.v_PersonId equals b.v_PersonId
                            join c in ctx.DataHierarchy on new { a = b.i_DocTypeId.Value, b = groupDocTypeId } equals new { a = c.i_ItemId, b = c.i_GroupId }
                            where a.i_IsDeleted == isDeleted 
                                    && (b.v_FirstName.Contains(filterPacient) || b.v_FirstLastName.Contains(filterPacient) || b.v_SecondLastName.Contains(filterPacient) )
                                    && (b.v_DocNumber.Contains(filterDocNumber))
                                    && (data.DocTypeId == -1 || b.i_DocTypeId == data.DocTypeId)
                            select new Pacients
                            {
                                PacientId = a.v_PersonId,
                                PacientFullName = b.v_FirstName + " " + b.v_FirstLastName + " " + b.v_SecondLastName,
                                DocType = c.v_Value1,
                                DocNumber = b.v_DocNumber,
                                TelephoneNumber = b.v_TelephoneNumber

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

        public Pacients GetPersonById(string pacientId)
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;

                var data = (from a in ctx.Person
                            where a.i_IsDeleted == isDeleted && a.v_PersonId == pacientId
                            select new Pacients()
                            {
                                PacientId = a.v_PersonId,
                                PacientFullName = a.v_FirstName + " " + a.v_FirstLastName + " " + a.v_SecondLastName,
                                DocTypeId = a.i_DocTypeId.Value,
                                //DocType = a.DocType,
                                //DocNumber = a.DocNumber,
                                //TelephoneNumber = a.TelephoneNumber,

                                //FirstName = a.v_PersonId,
                                //FirstLastName = a.v_PersonId,
                                //SecondLastName = a.v_PersonId,
                                //Birthdate = a.v_PersonId,
                                //BirthPlace = a.v_PersonId,
                                //SexTypeId = a.v_PersonId,
                                //MaritalStatusId = a.v_PersonId,
                                //LevelOfId = a.v_PersonId,
                                //AdressLocation = a.v_PersonId,
                                //GeografyLocationId = a.v_PersonId,
                                //ContactName = a.v_PersonId,
                                //EmergencyPhone = a.v_PersonId,
                                //PersonImage = a.v_PersonId,
                                //Mail = a.v_PersonId,
                                //BloodGroupId = a.v_PersonId,
                                //BloodFactorId = a.v_PersonId,
                                //FingerPrintTemplate = a.v_PersonId,
                                //RubricImage = a.v_PersonId,
                                // FingerPrintImage = a.v_PersonId,
                                //RubricImageText = a.v_PersonId,
                                //CurrentOccupation = a.v_PersonId,
                                //DepartmentId = a.v_PersonId,
                                //ProvinceId = a.v_PersonId,
                                //DistrictId = a.v_PersonId,
                                //ResidenceInWorkplaceId = a.v_PersonId,
                                //ResidenceTimeInWorkplace = a.v_PersonId,
                                //TypeOfInsuranceId = a.v_PersonId,
                                //NumberLivingChildren = a.v_PersonId,
                                //NumberDependentChildren = a.v_PersonId,
                                //OccupationTypeId = a.v_PersonId,
                                //OwnerName = a.v_PersonId,
                                //NumberLiveChildren = a.v_PersonId,
                                //NumberDeadChildren = a.v_PersonId,
                        }).FirstOrDefault();

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool AddPacient(Pacients pacient, int systemUserId)
        {
            PersonBL oPersonBL = new PersonBL();

            try
            {
                var oPersonBE = new PersonBE
                {
                    v_FirstName = pacient.FirstName,
                    v_FirstLastName = pacient.FirstLastName,
                    v_SecondLastName = pacient.SecondLastName,
                    i_DocTypeId = pacient.DocTypeId,
                    v_DocNumber = pacient.DocNumber,
                    d_Birthdate = pacient.Birthdate,
                    v_BirthPlace = pacient.BirthPlace,
                    i_SexTypeId = pacient.SexTypeId,
                    i_MaritalStatusId = pacient.MaritalStatusId,
                    i_LevelOfId = pacient.LevelOfId,
                    v_TelephoneNumber = pacient.TelephoneNumber,
                    v_AdressLocation = pacient.AdressLocation,
                    v_GeografyLocationId = pacient.GeografyLocationId,
                    v_ContactName = pacient.ContactName,
                    v_EmergencyPhone = pacient.EmergencyPhone,
                    b_PersonImage = pacient.PersonImage,
                    v_Mail = pacient.Mail,
                    i_BloodGroupId = pacient.BloodGroupId,
                    i_BloodFactorId = pacient.BloodFactorId,
                    v_FingerPrintTemplate = pacient.FingerPrintTemplate,
                    b_RubricImage = pacient.RubricImage,
                    b_FingerPrintImage = pacient.FingerPrintImage,
                    v_RubricImageText = pacient.RubricImageText,
                    v_CurrentOccupation = pacient.CurrentOccupation,
                    i_DepartmentId = pacient.DepartmentId,
                    i_ProvinceId = pacient.ProvinceId,
                    i_DistrictId = pacient.DistrictId,
                    i_ResidenceInWorkplaceId = pacient.ResidenceInWorkplaceId,
                    v_ResidenceTimeInWorkplace = pacient.ResidenceTimeInWorkplace,
                    i_TypeOfInsuranceId = pacient.TypeOfInsuranceId,
                    i_NumberLivingChildren = pacient.NumberLivingChildren,
                    i_NumberDependentChildren = pacient.NumberDependentChildren,
                    i_OccupationTypeId = pacient.OccupationTypeId,
                    v_OwnerName = pacient.OwnerName,
                    i_NumberLiveChildren = pacient.NumberLiveChildren,
                    i_NumberDeadChildren = pacient.NumberDeadChildren
                };

                var result = oPersonBL.AddPerson(oPersonBE, systemUserId);

                return result;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool EditPacient(Pacients pacient, int systemUserId)
        {
            PersonBL oPersonBL = new PersonBL();

            try
            {

                var opacient = (from a in ctx.Person where a.v_PersonId == pacient.PacientId select a).FirstOrDefault();

                if (opacient == null)
                    return false;

                    opacient.v_FirstName = pacient.FirstName;
                    opacient.v_FirstLastName = pacient.FirstLastName;
                    opacient.v_SecondLastName = pacient.SecondLastName;
                    opacient.i_DocTypeId = pacient.DocTypeId;
                    opacient.v_DocNumber = pacient.DocNumber;
                    opacient.d_Birthdate = pacient.Birthdate;
                    opacient.v_BirthPlace = pacient.BirthPlace;
                    opacient.i_SexTypeId = pacient.SexTypeId;
                    opacient.i_MaritalStatusId = pacient.MaritalStatusId;
                    opacient.i_LevelOfId = pacient.LevelOfId;
                    opacient.v_TelephoneNumber = pacient.TelephoneNumber;
                    opacient.v_AdressLocation = pacient.AdressLocation;
                    opacient.v_GeografyLocationId = pacient.GeografyLocationId;
                    opacient.v_ContactName = pacient.ContactName;
                    opacient.v_EmergencyPhone = pacient.EmergencyPhone;
                    opacient.b_PersonImage = pacient.PersonImage;
                    opacient.v_Mail = pacient.Mail;
                    opacient.i_BloodGroupId = pacient.BloodGroupId;
                    opacient.i_BloodFactorId = pacient.BloodFactorId;
                    opacient.v_FingerPrintTemplate = pacient.FingerPrintTemplate;
                    opacient.b_RubricImage = pacient.RubricImage;
                    opacient.b_FingerPrintImage = pacient.FingerPrintImage;
                    opacient.v_RubricImageText = pacient.RubricImageText;
                    opacient.v_CurrentOccupation = pacient.CurrentOccupation;
                    opacient.i_DepartmentId = pacient.DepartmentId;
                    opacient.i_ProvinceId = pacient.ProvinceId;
                    opacient.i_DistrictId = pacient.DistrictId;
                    opacient.i_ResidenceInWorkplaceId = pacient.ResidenceInWorkplaceId;
                    opacient.v_ResidenceTimeInWorkplace = pacient.ResidenceTimeInWorkplace;
                    opacient.i_TypeOfInsuranceId = pacient.TypeOfInsuranceId;
                    opacient.i_NumberLivingChildren = pacient.NumberLivingChildren;
                    opacient.i_NumberDependentChildren = pacient.NumberDependentChildren;
                    opacient.i_OccupationTypeId = pacient.OccupationTypeId;
                    opacient.v_OwnerName = pacient.OwnerName;
                    opacient.i_NumberLiveChildren = pacient.NumberLiveChildren;
                    opacient.i_NumberDeadChildren = pacient.NumberDeadChildren;
             
                return oPersonBL.UpdatePerson(opacient, systemUserId); ;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool DeletePacient(string pacientId, int systemUserId)
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var empresa = (from a in ctx.Pacient where a.v_PersonId == pacientId && a.i_IsDeleted == isDeleted select a).FirstOrDefault();

                empresa.i_UpdateUserId = systemUserId;
                empresa.d_UpdateDate = DateTime.UtcNow;
                empresa.i_IsDeleted = (int)Enumeratores.SiNo.Si;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion
    }
}
