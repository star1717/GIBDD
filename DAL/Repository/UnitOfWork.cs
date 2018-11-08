using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UnitOfWork:IRepositories
    {
        private Model1 db;
        private IRepository<Driver> drivers;
        private IRepository<Shtraf> shtraf;
        private IUdostRepository udostovers;
        public UnitOfWork()
        {
            db = new Model1();
        }
        public IRepository<Driver> Drivers
        {
            get
            {
                if (drivers == null)
                    drivers = new DriverRepository(db);
                return drivers;
            }
        }
        public IRepository<Shtraf> Shtraf
        {
            get
            {
                if (shtraf == null)
                    shtraf = new ShtrafRepository(db);
                return shtraf;
            }
        }
        public IUdostRepository Udostovers
        {
            get
            {
                if (udostovers == null)
                    udostovers = new UdostoverRepository(db);
                return udostovers;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
