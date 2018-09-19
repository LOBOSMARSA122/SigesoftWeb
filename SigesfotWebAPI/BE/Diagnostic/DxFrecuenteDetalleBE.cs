using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Diagnostic
{
    public class DxFrecuenteDetalleBE
    {
        public string DxFrecuenteDetalleId { get; set; }
        public string DxFrecuenteId { get; set; }
        public string MasterRecommendationRestricctionId { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
