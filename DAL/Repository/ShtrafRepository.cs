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
    class ShtrafRepository : IRepository<Shtraf>
    {
        public Model1 db;
        public ShtrafRepository(Model1 db)
        {
            this.db = db;
            db.Shtraf.Load();
        }

        public void Add(Shtraf obj)
        {
            db.Shtraf.Add(obj);
        }

        public BindingList<Shtraf> GetItems()
        {
            var shtrafs = db.Shtraf.Local.ToBindingList();
            return shtrafs;
        }

        public void Remove(int id)
        {
            
            db.Shtraf.Remove(db.Shtraf.Find(id));
        }
        public void Update(Shtraf obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public Shtraf Search(int id)
        {
            return db.Shtraf.Find(id);
        }
    }
}
