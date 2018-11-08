using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class ShtrafMod
    {
       
        public int Kod_shtraf { get; set; }

        public int Kod_driver_FK { get; set; }
       
        public string opisanie { get; set; }

        public int cost { get; set; }

        public bool discount { get; set; }

        //public virtual Driver Driver { get; set; }
    }
}
