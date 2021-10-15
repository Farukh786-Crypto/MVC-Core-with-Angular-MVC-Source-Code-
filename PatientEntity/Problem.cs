using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientEntity
{
    public class Problem
    {
        public int id { get; set; }
        public string description { get; set; }
        public bool genetic { get; set; }
        public List<Medication> medications { get; set; }
    }
}
