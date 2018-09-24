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
        public int? i_ApplicationHierarchyId { get; set; }

        public int? i_ApplicationHierarchyTypeId { get; set; }
        public int? i_Level { get; set; }
        public string v_Description { get; set; }
        public string v_Form { get; set; }
        public string v_Code { get; set; }
        public int? i_ParentId { get; set; }
        public int? i_ScopeId { get; set; }
        public int? i_TypeFormId { get; set; }
        public int? i_ExternalUserFunctionalityTypeId { get; set; }
        public int? i_IsDeleted { get; set; }
    }
}
