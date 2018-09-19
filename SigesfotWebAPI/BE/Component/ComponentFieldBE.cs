using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Component
{
    public class ComponentFieldBE
    {
        [Key]
        public string ComponentFieldId { get; set; }
        public string TextLabel { get; set; }
        public int? LabelWidth { get; set; }
        public string abbreviation { get; set; }
        public string DefaultText { get; set; }
        public int? ControlId { get; set; }
        public int? GroupId { get; set; }
        public int? ItemId { get; set; }
        public int? WidthControl { get; set; }
        public int? HeightControl { get; set; }
        public int? MaxLenght { get; set; }
        public int? IsRequired { get; set; }
        public int? IsCalculate { get; set; }
        public string Formula { get; set; }
        public int? Order { get; set; }
        public int? MeasurementUnitId { get; set; }
        public float ValidateValue1 { get; set; }
        public float ValidateValue2 { get; set; }
        public int? Column { get; set; }
        public int? defaultIndex { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? NroDecimales { get; set; }
        public int? ReadOnly { get; set; }
        public int? Enabled { get; set; }
    }
}
