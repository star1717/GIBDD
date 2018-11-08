using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class UdostoverRepository : IUdostRepository
    {
        Model1 db;
        public UdostoverRepository(Model1 db)
        {
            this.db = db;
            db.Udostovers.Load();
        }
       
        public void Add(Udostover obj)
        {
            db.Udostovers.Add(obj);
        }

        public BindingList<Udostover> GetItems()
        {
            var udostovers = db.Udostovers.Local.ToBindingList();
            return udostovers;
        }

        public void Remove(int id)
        {
            db.Udostovers.Remove(db.Udostovers.Find(id));
        }
        public void Update(Udostover obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public Udostover Search(int id)
        {
            return db.Udostovers.Find(id);
        }
        public string Raw(SqlParameter param)
        {
            return db.Database.SqlQuery<int>("SELECT COUNT(*) FROM Udostover where Date_v>@time", param).FirstOrDefault().ToString();
        }
    }
}
