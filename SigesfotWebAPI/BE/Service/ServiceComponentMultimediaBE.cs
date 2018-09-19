using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Service
{
    public class ServiceComponentMultimediaBE
    {
        public string ServiceComponentMultimediaId { get; set; }
        public string ServiceComponentId { get; set; }
        public string MultimediaFileId { get; set; }
        public string Comment { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
