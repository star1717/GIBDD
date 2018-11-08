using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public interface IAmountOfPenalty
    {
        bool ApplyDiscount(ShtrafMod shtraf);
        bool RemoveDiscount(ShtrafMod shtraf);
        int Sum(List<int> shtrafs);
    }
}
