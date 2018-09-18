using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Security
{
    public class ApplicationHierarchyBE
    {
        [Key]
        public int ApplicationHierarchyId { get; set; }
        public int ApplicationHierarchyTypeId { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string Form { get; set; }
        public string Code { get; set; }
        public int ParentId { get; set; }
        public int ScopeId { get; set; }
        public int TypeFormId { get; set; }
        public int ExternalUserFunctionalityTypeId { get; set; }
        public int IsDeleted { get; set; }
    }
}
