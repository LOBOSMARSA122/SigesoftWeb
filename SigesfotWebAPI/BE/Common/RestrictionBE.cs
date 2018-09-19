using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class RestrictionBE
    {
        [Key]
        public string RestrictionId { get; set; }

        public string DiagnosticRepositoryId { get; set; }
        public string ServiceId { get; set; }
        public string ComponentId { get; set; }
        public string MasterRestrictionId { get; set; }
        public DateTime? StartDateRestriction { get; set; }
        public DateTime? EndDateRestriction { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
    }
}
