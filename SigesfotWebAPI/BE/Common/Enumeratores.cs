using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Common
{
   public class Enumeratores
    {

        public enum TypeForm
        {
            Windows = 1,
            Web = 2,
            Asistencial = 3
        }

        public enum SiNo
        {
            No = 0,
            Si = 1
        }

        public enum Parameters
        {
            TypeDocument = 100
        }

        public enum DataHierarchy
        {
            TypeDoc = 106,
            CategoryProd = 103,
            MeasurementUnit = 150,
        }
    }
}
