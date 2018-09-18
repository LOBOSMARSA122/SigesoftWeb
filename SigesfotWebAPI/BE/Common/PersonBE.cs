using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class PersonBE
    {
        [Key]
        public string PersonId{get; set;}
        public string FirstName{get; set;}
        public string FirstLastName{get; set;}
        public string SecondLastName{get; set;}
        public int? DocTypeId {get; set;}
        public string DocNumber{get; set;}
        public DateTime? Birthdate{get; set;}
        public string BirthPlace{get; set;}
        public int? SexTypeId {get; set;}
        public int? MaritalStatusId {get; set;}
        public int? LevelOfId {get; set;}
        public string TelephoneNumber{get; set;}
        public string AdressLocation{get; set;}
        public string GeografyLocationId{get; set;}
        public string ContactName{get; set;}
        public string EmergencyPhone{get; set;}
        public byte[] PersonImage{get; set;}
        public string Mail{get; set;}
        public int? BloodGroupId{get; set;}
        public int? BloodFactorId{get; set;}
        public string FingerPrintTemplate{get; set;}
        public string RubricImage{get; set;}
        public string FingerPrintImage{get; set;}
        public string RubricImageText{get; set;}
        public string CurrentOccupation{get; set;}
        public int? DepartmentId{get; set;}
        public int? ProvinceId {get; set;}
        public int? DistrictId {get; set;}
        public int? ResidenceInWorkplaceId {get; set;}
        public string ResidenceTimeInWorkplace{get; set;}
        public int? TypeOfInsuranceId {get; set;}
        public string NumberLivingChildren{get; set;}
        public string NumberDependentChildren{get; set;}
        public int? OccupationTypeId {get; set;}
        public string OwnerName{get; set;}
        public string NumberLiveChildren{get; set;}
        public string NumberDeadChildren{get; set;}
        public int IsDeleted {get; set;}
        public int? InsertUserId {get; set;}
        public DateTime? InsertDate {get; set;}
        public int? UpdateUserId{get; set;}
        public DateTime? UpdateDate {get; set;}

    }
}
