using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
   public class AmountOfPenalty: IAmountOfPenalty
    {
        IRepositories db;     
        public AmountOfPenalty(IRepositories db)
        {
            this.db = db;
        }
        public bool ApplyDiscount(ShtrafMod shtraf)//добавить
        {
            if (shtraf.discount == false)
            {
                shtraf.cost = shtraf.cost / 2;
                shtraf.discount = true;
                db.Save();
                return true;
            }
            else return false;
        }
        public bool RemoveDiscount(ShtrafMod shtraf)
        {
            if (shtraf.discount == true)
            {
                shtraf.cost = shtraf.cost * 2;
                shtraf.discount = false;
                db.Save();
                return true;
            }
            else return false;
        }
        public int Sum(List<int> shtrafs)
        {
            int sum=0;
            foreach(var p in shtrafs)
            {
                sum +=  db.Shtraf.Search(p).cost;
            }
            return sum;
        }
    }
}
