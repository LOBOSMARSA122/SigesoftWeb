using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.History
{
    public class FamilyMedicalAntecedentsBE
    {
        public string FamilyMedicalAntecedentsId { get; set; }
        public string PersonId { get; set; }
        public string DiseasesId { get; set; }
        public int TypeFamilyId { get; set; }
        public string Comment { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
