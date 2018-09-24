using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigesoftWeb.Models.Common
{
    
        public class Boards
        {
            public int TotalRecords { get; set; }
            public int Index { get; set; }
            public int Take { get; set; }
        }

        public class BoardPacient : Boards
        {
            public string PacientId { get; set; }
            public string Pacient { get; set; }
            public int DocTypeId { get; set; }
            public string DocNumber { get; set; }

            public List<Pacients> List { get; set; }
        }

        public class Pacients
        {
            public string PacientId { get; set; }
            public string PacientFullName { get; set; }
            public string DocType { get; set; }
            public string DocNumber { get; set; }
            public string TelephoneNumber { get; set; }
        }
}