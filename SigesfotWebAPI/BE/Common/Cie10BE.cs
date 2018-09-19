using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class Cie10BE
    {
        public string CIE10Id { get; set; }
        public string CIE10Description1 { get; set; }
        public string CIE10Description2 { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
