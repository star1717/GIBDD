using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class DriverMod
    {
        public int Kod_driver { get; set; }
  
        public string Family_name { get; set; }
       
        public string Name { get; set; }
       
        public string Last_name { get; set; }

        public List<int> shtraf { get; set; }


        //public virtual ICollection<Udostover> Udostover { get; set; }
    }
}
