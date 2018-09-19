using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
    public class DataHierarchyBE
    {
        public int GroupId { get; set; } 
        public int ItemId { get; set; } 
        public string Value1 { get; set; } 
        public string Value2 { get; set; } 
        public string Field { get; set; } 
        public int ParentItemId { get; set; } 
        public int Sort { get; set; } 
        public int IsDeleted { get; set; } 
        public int InsertUserId { get; set; } 
        public DateTime InsertDate { get; set; } 
        public int UpdateUserId { get; set; } 
        public DateTime UpdateDate { get; set; } 
    }
}
