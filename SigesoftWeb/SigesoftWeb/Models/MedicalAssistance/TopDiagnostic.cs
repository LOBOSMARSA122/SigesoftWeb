using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigesoftWeb.Models.MedicalAssistance
{
    public class TopDiagnostic
    {
        //public string DiagnosticId { get; set; }
        //public string Diagnostic { get; set; }
        //public int TotalDiagnostic { get; set; }
        public string name { get; set; }
        public int y { get; set; }
    }

    public class Indicators
    {
        public string PersonId { get; set; }
        public List<Weight> Weights { get; set; }
        public List<BloodPressureSis> BloodPressureSis { get; set; }
        public List<BloodPressureDia> BloodPressureDia { get; set; }

    }

    public class Weight
    {
        public string Date { get; set; }
        public string y { get; set; }

    }

    public class BloodPressureSis
    {
        public string Date { get; set; }
        public string y { get; set; }

    }

    public class BloodPressureDia
    {
        public string Date { get; set; }
        public string y { get; set; }

    }
}