using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class DriverRepository:IRepository<Driver>
    {
        public Model1 db;
  
        public DriverRepository(Model1 db)
        {
            if (db != null)
            {
            this.db = db;
            db.Drivers.Load();
            }
           
        }
        public BindingList<Driver> GetItems()
        {
            return db.Drivers.Local.ToBindingList();
            
        }
        public void Add(Driver obj)
        {
            db.Drivers.Add(obj);
        }
        public void Update(Driver obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public Driver Search(int id)
        {
            return db.Drivers.Find(id);
        }
        public void Remove(int id)
        {

            db.Drivers.Remove(db.Drivers.Find(id));
        }
    }
}
