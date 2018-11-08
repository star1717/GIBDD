using Ninject.Modules;
using WindowsFormsApp1;

namespace lab3_DatabaseFirst
{
    internal class NinjectRegistrations: NinjectModule
    {
        public override void Load()
        {
            Bind<IAmountOfPenalty>().To<AmountOfPenalty>();
            Bind<IOperations>().To<Operation>();
        }
    }
}