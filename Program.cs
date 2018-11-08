using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace lab3_DatabaseFirst
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new WindowsFormsApp1.Ninject());

            IOperations o = kernel.Get<IOperations>();
            IAmountOfPenalty p = kernel.Get<IAmountOfPenalty>();
            //NinjectModule registrations = new NinjectRegistrations();
            //var kernel = new StandardKernel(registrations);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(o,p));
        }
    }
}
