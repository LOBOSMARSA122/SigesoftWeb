using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.MedicalAssistance
{
    public class Boards
    {
        public int TotalRecords { get; set; }
        public int Index { get; set; }
        public int Take { get; set; }
    }

    public class BoardPatient : Boards
    {
        public string Patient { get; set; }
        public List<Patients> List { get; set; }
    }

    public class Patients
    {
        public string PatientId { get; set; }
        public string PatientFullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public DateTime? ServiceDate { get; set; }
        public DateTime? Birthdate { get; set; }
        public string AptitudeStatus { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }

    }
}
