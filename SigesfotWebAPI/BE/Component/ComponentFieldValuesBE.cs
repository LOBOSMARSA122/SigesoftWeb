using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Component
{
    public class ComponentFieldValuesBE
    {
        [Key]
        public string ComponentFieldValuesId { get; set; }

        public string Diseases { get; set; }
        public string ComponentFieldId { get; set; }
        public string AnalyzingValue1 { get; set; }
        public string AnalyzingValue2 { get; set; }
        public int? OperatorId { get; set; }
        public string LegalStandard { get; set; }
        public int? IsAnormal { get; set; }
        public int? ValidationMonths { get; set; }
        public int? GenderId { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
