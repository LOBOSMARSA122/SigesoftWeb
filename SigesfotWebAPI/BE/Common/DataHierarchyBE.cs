using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class DataHierarchyBE
    {
        [Key,Column(Order = 1)]
        public int? GroupId { get; set; }
        [Key, Column(Order = 2)]
        public int? ItemId { get; set; } 
        public string Value1 { get; set; } 
        public string Value2 { get; set; } 
        public string Field { get; set; } 
        public int? ParentItemId { get; set; } 
        public int? Sort { get; set; } 
        public int? IsDeleted { get; set; } 
        public int? InsertUserId { get; set; } 
        public DateTime? InsertDate { get; set; } 
        public int? UpdateUserId { get; set; } 
        public DateTime? UpdateDate { get; set; } 
    }
}
