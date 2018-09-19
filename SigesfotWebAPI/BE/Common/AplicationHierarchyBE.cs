using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class AplicationHierarchyBE
    {
        [Key]
        public int? ApplicationHierarchyId {get; set;}
        public int? ApplicationHierarchyTypeId {get; set;}
        public int? Level {get; set;}
        public string Description {get; set;}
        public string Form {get; set;}
        public string Code {get; set;}
        public int? ParentId {get; set;}
        public int? ScopeId {get; set;}
        public int? TypeFormId {get; set;}
        public int? ExternalUserFunctionalityTypeId {get; set;}
        public int? IsDeleted {get; set;}
        public int? InsertUserId {get; set;}
        public DateTime? InsertDate {get; set;}
        public int? UpdateUserId {get; set;}
        public DateTime? UpdateDate {get; set;}
    }
}
