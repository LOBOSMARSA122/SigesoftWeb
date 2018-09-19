using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class ProfessionalBE
    {
        [Key]
        public string PersonId { get; set; }
        public int? ProfesionId { get; set; }
    }
}
