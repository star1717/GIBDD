using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
   public interface IOperations
   {
        BindingList<DriverMod> GetDrivers();
        BindingList<ShtrafMod> GetShtraf();
        BindingList<UdostoverMod> GetUdostovers();
        void Add<T>(T obj);
        void AddShtraf(ShtrafMod obj);   
        void Save();
        UdostoverMod Search(int id); 
        ShtrafMod SearchShtraf(int id);     
        void RemoveUdost(int obj);    
        void RemoveShtraf(int obj);    
        string Raw(SqlParameter param);  
        DriverMod SearchDriv(int id);    
        void RemoveDriv(int obj);
        void UpdateShtraf(ShtrafMod p);
        void UpdateUdost(UdostoverMod p);
        void UpdateDriv(DriverMod p);
   }
}
