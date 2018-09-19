using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Component
{
    public class ComponentBE
    {
        public string ComponentId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public float BasePrice { get; set; }
        public int DiagnosableId { get; set; }
        public int IsApprovedId { get; set; }
        public int ComponentTypeId { get; set; }
        public int UIIsVisibleId { get; set; }
        public int UIIndex { get; set; }
        public int ValidInDays { get; set; }
        public int IsDeleted { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string IdUnidadProductiva { get; set; }
    }
}
