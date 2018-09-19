using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Service
{
    public class ServiceComponentFieldValuesBE
    {
        public string ServiceComponentFieldValuesId { get; set; }
        public string ComponentFieldValuesId { get; set; }
        public string ServiceComponentFieldsId { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public int Index { get; set; }
        public int ValueInt1 { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
