using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientEntity
{
    public class Patient
    {
        public int id { get; set; }
        [ConcurrencyCheck]
        public string name { get; set; }
       /* public string address { get; set; }*/
        public List<Problem> problems { get; set; }
    }
}
