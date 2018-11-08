using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepository<T> where T:class
    {
        BindingList<T> GetItems();

        void Add(T obj);

        T Search(int id);

        void Remove(int obj);
        void Update(T obj);
    }
}
