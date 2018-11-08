using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using WindowsFormsApp1.Models;
using System.Collections.ObjectModel;

namespace WindowsFormsApp1
{
   public class Operation:IOperations
    {
        public IRepositories db;
       
        public Operation(IRepositories db)
        {
            this.db = db;
        }
        public BindingList<DriverMod> GetDrivers()
        {
            return new BindingList<DriverMod>(db.Drivers.GetItems().Select(i => ConvertInDriverMod(i)).ToList());   
        }
        public BindingList<ShtrafMod> GetShtraf()
        {
           return new BindingList<ShtrafMod>(db.Shtraf.GetItems().Select(i => ConvertInShtrafMod(i)).ToList());
        }
        public BindingList<UdostoverMod> GetUdostovers()
        {
           return new BindingList<UdostoverMod>(db.Udostovers.GetItems().Select(i=> ConvertInUdostoverMod(i)).ToList());             
        }
        public void Add<T>(T obj)
        {
            DriverMod driv = new DriverMod();            
            if (obj.GetType() == driv.GetType())
            {
                driv = obj as DriverMod;
               
                db.Drivers.Add(ConvertDriver(driv,new Driver()));
            }
           else
            {
                var udost = obj as UdostoverMod;
                db.Udostovers.Add(ConvertUdost(udost, new Udostover()));
            }
            db.Save();
        }
        public void AddShtraf(ShtrafMod obj)
        {
            db.Shtraf.Add(ConvertShtraf(obj, new Shtraf()));
        }
        public void Save()
        {
            db.Save();
        }
        public UdostoverMod Search(int id)
        {
            return ConvertInUdostoverMod(db.Udostovers.Search(id));
        }
        public ShtrafMod SearchShtraf(int id)
        {
            return ConvertInShtrafMod(db.Shtraf.Search(id));
        }
 
        public void RemoveUdost(int obj)
        {
            db.Udostovers.Remove(obj);
        }
        public void RemoveShtraf(int obj)
        {
            db.Shtraf.Remove(obj);
        }
        public string Raw(SqlParameter param)
        {
            return db.Udostovers.Raw(param);
        }
        public DriverMod SearchDriv(int id)
        {
            return ConvertInDriverMod(db.Drivers.Search(id));
        }
        public void RemoveDriv(int obj)
        {
            db.Drivers.Remove(obj);
        }
        public void UpdateDriv(DriverMod p)
        {
            Driver ph = db.Drivers.Search(p.Kod_driver);
            db.Drivers.Update(ConvertDriver(p, ph));
            db.Save();
        }
        public void UpdateUdost(UdostoverMod p)
        {
            Udostover ph = db.Udostovers.Search(p.Number_udostover);
            db.Udostovers.Update(ConvertUdost(p, ph));
            db.Save();
        }
        public void UpdateShtraf(ShtrafMod p)
        {
            Shtraf ph = db.Shtraf.Search(p.Kod_shtraf);
            db.Shtraf.Update(ConvertShtraf(p, ph));
            db.Save();
        }
        private DriverMod ConvertInDriverMod(Driver obj)
        {
            return new DriverMod()
            {
                Family_name = obj.Family_name,
                Kod_driver = obj.Kod_driver,
                Name = obj.Name,
                Last_name = obj.Last_name,
                shtraf = obj.Shtraf.Select(j => j.Kod_shtraf).ToList()


        };
        }
        private ShtrafMod ConvertInShtrafMod(Shtraf obj)
        {
            return new ShtrafMod()
            {
                Kod_shtraf = obj.Kod_shtraf,
                Kod_driver_FK = obj.Kod_driver_FK,
                opisanie = obj.opisanie,
                cost = obj.cost,
                discount = obj.discount,
              
            };
        }
        private UdostoverMod ConvertInUdostoverMod(Udostover obj)
        {
            return new UdostoverMod()
            {
                Kod_driver_FK = obj.Kod_driver_FK,
                Kategori = obj.Kategori,
                Date_v = obj.Date_v,
                Number_udostover = obj.Number_udostover
            };
        }
        private Driver ConvertDriver(DriverMod obj, Driver r)
        {
            r.Family_name = obj.Family_name;
            r.Kod_driver = obj.Kod_driver;
            r.Name = obj.Name;
            r.Last_name = obj.Last_name;
            return r;
        }
        private Shtraf ConvertShtraf(ShtrafMod obj, Shtraf r)
        {
            r.Kod_shtraf = obj.Kod_shtraf;
            r.Kod_driver_FK = obj.Kod_driver_FK;
            r.opisanie = obj.opisanie;
            r.cost = obj.cost;
            r.discount = obj.discount;
            return r;
        }
        private Udostover ConvertUdost(UdostoverMod obj,Udostover r)
        {
            r.Kod_driver_FK = obj.Kod_driver_FK;
            r.Kategori = obj.Kategori;
            r.Date_v = obj.Date_v;
            r.Number_udostover = obj.Number_udostover;
            return r;
        }
    }
}
