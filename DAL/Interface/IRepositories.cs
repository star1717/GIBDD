using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepositories
    {

        IRepository<Driver> Drivers
        {
            get;
          
        }
        IRepository<Shtraf> Shtraf
        {
            get;
       
        }
         IUdostRepository Udostovers
        {
            get;
    
        }
        void Save();
    }
}
