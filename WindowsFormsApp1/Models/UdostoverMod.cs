using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
   public class UdostoverMod
    {
        public int Number_udostover { get; set; }

        public int Kod_driver_FK { get; set; }

        public string Kategori { get; set; }

        public DateTime Date_v { get; set; }

        //public virtual Driver Driver { get; set; }
    }
}
