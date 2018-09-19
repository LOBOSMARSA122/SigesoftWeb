using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class LogBE
    {
        public string LogId { get; set; }
        public int NodeLogId { get; set; }
        public int EventTypeId { get; set; }
        public string OrganizationId { get; set; }
        public DateTime Date { get; set; }
        public int SystemUserId { get; set; }
        public string ProcessEntity { get; set; }
        public string ElementItem { get; set; }
        public int Success { get; set; }
        public string ErrorException { get; set; }
    }
}
