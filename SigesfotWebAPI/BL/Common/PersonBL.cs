using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class PersonBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public PersonBE GetPerson(string personId)
        {
            try
            {
                var objEntity = (from a in ctx.Person
                                 where a.PersonId == personId
                                 select a).FirstOrDefault();

                return objEntity;
            }
            catch (Exception ex)
            {               
                return null;
            }
        }

        public List<PersonBE> GetAllPerson()
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Person
                                 where a.IsDeleted == isDeleted
                                 select new PersonBE()
                                 {
                                    PersonId  = a.PersonId ,
                                    FirstName  = a.FirstName,
                                    FirstLastName  = a.FirstLastName,
                                    SecondLastName  = a.SecondLastName,
                                    DocTypeId  = a.DocTypeId,
                                    DocNumber  = a.DocNumber,
                                    Birthdate  = a.Birthdate,
                                    BirthPlace  = a.BirthPlace,
                                    SexTypeId  = a.SexTypeId,
                                    MaritalStatusId  = a.MaritalStatusId,
                                    LevelOfId  = a.LevelOfId,
                                    TelephoneNumber  = a.TelephoneNumber,
                                    AdressLocation  = a.AdressLocation,
                                    GeografyLocationId  = a.GeografyLocationId,
                                    ContactName  = a.ContactName,
                                    EmergencyPhone  = a.EmergencyPhone,
                                    PersonImage  = a.PersonImage,
                                    Mail  = a.Mail,
                                    BloodGroupId  = a.BloodGroupId,
                                    BloodFactorId  = a.BloodFactorId,
                                    FingerPrintTemplate  = a.FingerPrintTemplate,
                                    RubricImage  = a.RubricImage,
                                    FingerPrintImage  = a.FingerPrintImage,
                                    RubricImageText  = a.RubricImageText,
                                    CurrentOccupation  = a.CurrentOccupation,
                                    DepartmentId  = a.DepartmentId,
                                    ProvinceId  = a.ProvinceId,
                                    DistrictId  = a.DistrictId,
                                    ResidenceInWorkplaceId  = a.ResidenceInWorkplaceId,
                                    ResidenceTimeInWorkplace  = a.ResidenceTimeInWorkplace,
                                    TypeOfInsuranceId  = a.TypeOfInsuranceId,
                                    NumberLivingChildren  = a.NumberLivingChildren,
                                    NumberDependentChildren  = a.NumberDependentChildren,
                                    OccupationTypeId  = a.OccupationTypeId,
                                    OwnerName  = a.OwnerName,
                                    NumberLiveChildren  = a.NumberLiveChildren,
                                    NumberDeadChildren  = a.NumberDeadChildren,
                                    IsDeleted  = a.IsDeleted,
                                    InsertUserId  = a.InsertUserId,
                                    InsertDate  = a.InsertDate,
                                    UpdateUserId  = a.UpdateUserId,
                                    UpdateDate = a.UpdateDate
                                }).ToList();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddPerson(PersonBE person, int systemUserId)
        {
            try
            {
                PersonBE oPersonBE = new PersonBE()
                {
                    PersonId = BE.Utils.GetPrimaryKey(1,1),
                    FirstName = person.FirstName,
                    FirstLastName = person.FirstLastName,
                    SecondLastName = person.SecondLastName,
                    DocTypeId = person.DocTypeId,
                    DocNumber = person.DocNumber,
                    Birthdate = person.Birthdate,
                    BirthPlace = person.BirthPlace,
                    SexTypeId = person.SexTypeId,
                    MaritalStatusId = person.MaritalStatusId,
                    LevelOfId = person.LevelOfId,
                    TelephoneNumber = person.TelephoneNumber,
                    AdressLocation = person.AdressLocation,
                    GeografyLocationId = person.GeografyLocationId,
                    ContactName = person.ContactName,
                    EmergencyPhone = person.EmergencyPhone,
                    PersonImage = person.PersonImage,
                    Mail = person.Mail,
                    BloodGroupId = person.BloodGroupId,
                    BloodFactorId = person.BloodFactorId,
                    FingerPrintTemplate = person.FingerPrintTemplate,
                    RubricImage = person.RubricImage,
                    FingerPrintImage = person.FingerPrintImage,
                    RubricImageText = person.RubricImageText,
                    CurrentOccupation = person.CurrentOccupation,
                    DepartmentId = person.DepartmentId,
                    ProvinceId = person.ProvinceId,
                    DistrictId = person.DistrictId,
                    ResidenceInWorkplaceId = person.ResidenceInWorkplaceId,
                    ResidenceTimeInWorkplace = person.ResidenceTimeInWorkplace,
                    TypeOfInsuranceId = person.TypeOfInsuranceId,
                    NumberLivingChildren = person.NumberLivingChildren,
                    NumberDependentChildren = person.NumberDependentChildren,
                    OccupationTypeId = person.OccupationTypeId,
                    OwnerName = person.OwnerName,
                    NumberLiveChildren = person.NumberLiveChildren,
                    NumberDeadChildren = person.NumberDeadChildren,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };

                ctx.Person.Add(oPersonBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdatePerson(PersonBE person, int systemUserId)
        {
            try
            {
                var oPerson = (from a in ctx.Person where a.PersonId == person.PersonId select a).FirstOrDefault();

                if (oPerson == null)
                    return false;

                    oPerson.FirstName = person.FirstName;
                    oPerson.FirstLastName = person.FirstLastName;
                    oPerson.SecondLastName = person.SecondLastName;
                    oPerson.DocTypeId = person.DocTypeId;
                    oPerson.DocNumber = person.DocNumber;
                    oPerson.Birthdate = person.Birthdate;
                    oPerson.BirthPlace = person.BirthPlace;
                    oPerson.SexTypeId = person.SexTypeId;
                    oPerson.MaritalStatusId = person.MaritalStatusId;
                    oPerson.LevelOfId = person.LevelOfId;
                    oPerson.TelephoneNumber = person.TelephoneNumber;
                    oPerson.AdressLocation = person.AdressLocation;
                    oPerson.GeografyLocationId = person.GeografyLocationId;
                    oPerson.ContactName = person.ContactName;
                    oPerson.EmergencyPhone = person.EmergencyPhone;
                    oPerson.PersonImage = person.PersonImage;
                    oPerson.Mail = person.Mail;
                    oPerson.BloodGroupId = person.BloodGroupId;
                    oPerson.BloodFactorId = person.BloodFactorId;
                    oPerson.FingerPrintTemplate = person.FingerPrintTemplate;
                    oPerson.RubricImage = person.RubricImage;
                    oPerson.FingerPrintImage = person.FingerPrintImage;
                    oPerson.RubricImageText = person.RubricImageText;
                    oPerson.CurrentOccupation = person.CurrentOccupation;
                    oPerson.DepartmentId = person.DepartmentId;
                    oPerson.ProvinceId = person.ProvinceId;
                    oPerson.DistrictId = person.DistrictId;
                    oPerson.ResidenceInWorkplaceId = person.ResidenceInWorkplaceId;
                    oPerson.ResidenceTimeInWorkplace = person.ResidenceTimeInWorkplace;
                    oPerson.TypeOfInsuranceId = person.TypeOfInsuranceId;
                    oPerson.NumberLivingChildren = person.NumberLivingChildren;
                    oPerson.NumberDependentChildren = person.NumberDependentChildren;
                    oPerson.OccupationTypeId = person.OccupationTypeId;
                    oPerson.OwnerName = person.OwnerName;
                    oPerson.NumberLiveChildren = person.NumberLiveChildren;
                    oPerson.NumberDeadChildren = person.NumberDeadChildren;

                    //Auditoria
                    oPerson.UpdateDate = DateTime.UtcNow;
                    oPerson.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool DeletePerson(string personId, int systemUserId)
        {
            try
            {
                var oPerson = (from a in ctx.Person where a.PersonId == personId select a).FirstOrDefault();
                
                if (oPerson == null)
                    return false;

                oPerson.UpdateUserId = systemUserId;
                oPerson.UpdateDate = DateTime.UtcNow;
                oPerson.IsDeleted = (int)Enumeratores.SiNo.Si;

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
