﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.History
{
    public class NoxiousHabitsBE
    {
        [Key]
        public string NoxiousHabitsId { get; set; }

        public string PersonId { get; set; }
        public int? TypeHabitsId { get; set; }
        public string Frequency { get; set; }
        public string Comment { get; set; }
        public string DescriptionHabit { get; set; }
        public string DescriptionQuantity { get; set; }
        public int? IsDeleted { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}