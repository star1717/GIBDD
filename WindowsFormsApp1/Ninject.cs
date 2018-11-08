using DAL.Interface;
using DAL.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Ninject : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositories>().To<UnitOfWork>();
        }
    }
}
