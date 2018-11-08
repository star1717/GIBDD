
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.Models;

namespace lab3_DatabaseFirst
{
    public partial class Form1 : Form
    {
        //public static Model1 db = new Model1();
        private static IOperations operation;
        BindingList<DriverMod> drivers;
        IAmountOfPenalty discont;
        public Form1(IOperations o, IAmountOfPenalty l)
        {
            operation = o;
            discont = l;
            InitializeComponent();
            drivers = operation.GetDrivers();
            dataGridView1.DataSource = drivers; 

            var udostovers = operation.GetUdostovers();
            dataGridView2.DataSource = udostovers;

            var shtrafs = operation.GetShtraf();
            dataGridView3.DataSource = shtrafs;
            Refresh("Column15", dataGridView3);
            Refresh("Column11", dataGridView2);

            comboBox1.DataSource = operation.GetDrivers();
            comboBox1.DisplayMember = "Family_name";
            comboBox1.ValueMember = "Kod_driver";

        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            AddDriver addDriver = new AddDriver();
            DialogResult dialog = addDriver.ShowDialog(this);
            if (dialog == DialogResult.OK)
            {
                try
                {
                    DriverMod driver = new DriverMod
                    {

                        Family_name = addDriver.textBox2.Text,
                        Name = addDriver.textBox3.Text,
                        Last_name = addDriver.textBox4.Text
                    };
                    //db.Drivers.Add(driver);
                    operation.Add(driver);
                    //db.SaveChanges();
                    operation.Save();
                    MessageBox.Show("Новый объект добавлен!");

                    drivers = operation.GetDrivers();
                    dataGridView1.DataSource = drivers;
                    dataGridView1.Refresh();

                    Refresh("Column11", dataGridView2);
                }
                catch
                {
                    MessageBox.Show("Объект не может быть добавлен!");
                }
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddUdostover udost = new AddUdostover();
            udost.comboBox1.DataSource = operation.GetDrivers();
            udost.comboBox1.DisplayMember = "Family_name";
            udost.comboBox1.ValueMember = "Kod_driver";
            DialogResult dialog = udost.ShowDialog(this);
            if (dialog == DialogResult.OK)
            {
                try
                {
                    UdostoverMod udostover = new UdostoverMod();


                   udostover.Kod_driver_FK = Convert.ToInt32(udost.comboBox1.SelectedValue);
                    udostover.Number_udostover = Convert.ToInt32(udost.textBox1.Text);
                    udostover.Date_v = udost.dateTimePicker1.Value;
                    udostover.Kategori = udost.textBox3.Text;

                    //Form1.db.Udostovers.Add(udostover);
                    //Form1.db.SaveChanges();
                    operation.Add(udostover);
                    operation.Save();
                    MessageBox.Show("Новый объект добавлен!");
                    dataGridView2.DataSource = operation.GetUdostovers();
                    dataGridView2.Refresh();
                }
                catch
                {
                  
                    MessageBox.Show("Объект не может быть добавлен!");
                }
            }
        }

  
        public void Refresh(string call,DataGridView dataGridView3)
        {
            ((DataGridViewComboBoxColumn)dataGridView3.Columns[call]).DataSource = operation.GetDrivers();
            ((DataGridViewComboBoxColumn)dataGridView3.Columns[call]).DisplayMember = "Family_name";
            ((DataGridViewComboBoxColumn)dataGridView3.Columns[call]).ValueMember = "Kod_driver";
        }
        public static int Index(DataGridView Grid)
        {
            int index = -1;
            if (Grid.SelectedRows.Count > 0 || Grid.SelectedCells.Count == 1)
            {
                if (Grid.SelectedRows.Count > 0)
                    index = Grid.SelectedRows[0].Index;
                else index = Grid.SelectedCells[0].RowIndex;
            }
            return index;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView2[1, Index(dataGridView2)].Value.ToString());
            UdostoverMod udostover = operation.Search(id);

            AddUdostover udost = new AddUdostover();

            udost.comboBox1.DataSource = operation.GetDrivers();
            udost.comboBox1.DisplayMember = "Family_name";
            udost.comboBox1.ValueMember = "Kod_driver";
            udost.comboBox1.SelectedValue = udostover.Kod_driver_FK;
            udost.textBox1.Text =Convert.ToString(udostover.Number_udostover);
            udost.dateTimePicker1.Value = udostover.Date_v;
            udost.textBox3.Text = udostover.Kategori;

            DialogResult dialog = udost.ShowDialog(this);
            if (dialog == DialogResult.OK)
            {
                try
                {

                    udostover.Kod_driver_FK = Convert.ToInt32(udost.comboBox1.SelectedValue);
                   
                    udostover.Number_udostover = Convert.ToInt32(udost.textBox1.Text);
                    udostover.Date_v = udost.dateTimePicker1.Value;
                    udostover.Kategori = udost.textBox3.Text;
                    operation.UpdateUdost(udostover);
                    
                    MessageBox.Show("Объект успешно изменен!");
                    dataGridView2.DataSource = operation.GetUdostovers();
                    
                    dataGridView2.Refresh();
                }
                catch
                {
                    MessageBox.Show("Объект не может быть изменен!");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView2[1, Index(dataGridView2)].Value.ToString());
                //UdostoverMod udostover = operation.Search(id);
                operation.RemoveUdost(id);
                operation.Save();
                MessageBox.Show("Объект удален!");
                dataGridView2.DataSource = operation.GetUdostovers();
                dataGridView2.Refresh();

            }
            catch
            {
                MessageBox.Show("Объект не может быть удален!");
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    SqlParameter param1 = new SqlParameter("@fam", textBox1.Text);
        //    var result = db.Database.SqlQuery<HP_Result>("exec HP @fam", new object[] { param1 }).ToList();
        //    dataGridView3.DataSource = result;
        //}
        public class HP_Result
        {         
            public int Kod_driver { get; set; }      
            public string Family_name { get; set; }           
            public string Name { get; set; }         
            public string Last_name { get; set; }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            
            DateTime time = dateTimePicker1.Value;
            SqlParameter param = new SqlParameter("@time", time);
            label1.Text = operation.Raw(param);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
  
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddDriver addDriver = new AddDriver();
            
            int id = Convert.ToInt32(dataGridView1[1, Index(dataGridView1)].Value.ToString());
            DriverMod driver = operation.SearchDriv(id);
            addDriver.textBox2.Text = driver.Family_name;
            addDriver.textBox3.Text = driver.Name;
            addDriver.textBox4.Text = driver.Last_name;
            DialogResult dialog = addDriver.ShowDialog(this);
            if (dialog == DialogResult.OK)
            {
          
                try
                {

                    driver.Name = addDriver.textBox3.Text;
                    driver.Family_name = addDriver.textBox2.Text;
                    driver.Last_name = addDriver.textBox4.Text;

                    operation.UpdateDriv(driver);
                    //Form1.dataGridView1.Refresh();
                    MessageBox.Show("Объект успешно изменен!");
                    drivers = operation.GetDrivers();
                    dataGridView1.DataSource = drivers;

                    dataGridView1.Refresh();

                }
                catch
                {
                    MessageBox.Show("Объект не может быть изменен!");
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {                                    
            int id = Convert.ToInt32(dataGridView1[1, Index(dataGridView1)].Value.ToString());
            DriverMod driver = operation.SearchDriv(id);
            try
            {

                operation.RemoveDriv(id);
                operation.Save();
                    MessageBox.Show("Объект удален!");
                drivers = operation.GetDrivers();


            }
            catch
            { MessageBox.Show("Объект не может быть удален!"); }
            dataGridView1.DataSource = drivers;
                dataGridView1.Refresh();
                Refresh("Column11", dataGridView2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddShtraf shtraf = new AddShtraf();
            shtraf.comboBox1.DataSource = operation.GetDrivers();
            shtraf.comboBox1.DisplayMember = "Family_name";
            shtraf.comboBox1.ValueMember = "Kod_driver";
            DialogResult dialog = shtraf.ShowDialog(this);
            if (dialog == DialogResult.OK)
            {
                try
                {
                    ShtrafMod shtraff = new ShtrafMod();
                    shtraff.Kod_driver_FK = Convert.ToInt32(shtraf.comboBox1.SelectedValue);
                    shtraff.cost = Convert.ToInt32(shtraf.textBox3.Text);                    
                    shtraff.opisanie = shtraf.textBox1.Text;
                    shtraff.discount = shtraf.checkBox1.Checked;
                    operation.AddShtraf(shtraff);
                    operation.Save();
                    MessageBox.Show("Новый объект добавлен!");
                    dataGridView3.DataSource = operation.GetShtraf();
                    dataGridView3.Refresh();
                }
                catch
                {
                    MessageBox.Show("Объект не может быть добавлен!");
                }
            }
        }
      
        private void button10_Click(object sender, EventArgs e)
        {
           
            int id = Convert.ToInt32(dataGridView3[1, Index(dataGridView3)].Value.ToString());
            //var shtraf = operation.SearchShtraf(id);
            try
            {
                operation.RemoveShtraf(id);
                operation.Save();
                MessageBox.Show("Штраф удален!");
                Refresh("Column15", dataGridView3);
                dataGridView3.DataSource = operation.GetShtraf();
                dataGridView3.Refresh();
            }
            catch
            { MessageBox.Show("Штраф не может быть удален!"); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView3[1, Index(dataGridView3)].Value.ToString());
            var shtraf = operation.SearchShtraf(id);
            var k=discont.ApplyDiscount(shtraf);
            if (k == true)
            {
                operation.UpdateShtraf(shtraf);
              MessageBox.Show("Cкидка применена к штрафу!");
                dataGridView3.DataSource = operation.GetShtraf();
                dataGridView3.Refresh();
            }
            else
            {
            MessageBox.Show("Cкидка не может быть применена к штрафу!");
            
            }
     
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView3[1, Index(dataGridView3)].Value.ToString());
            var shtraf = operation.SearchShtraf(id);
            var k=discont.RemoveDiscount(shtraf);
            if (k == true)
            {
                operation.UpdateShtraf(shtraf);
                MessageBox.Show("Скидка отменена!");
                dataGridView3.DataSource = operation.GetShtraf();
                dataGridView3.Refresh();

            }
            else MessageBox.Show("Скидка не была применена к штрафу!");
                dataGridView3.DataSource = operation.GetShtraf();
                dataGridView3.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(comboBox1.SelectedValue.ToString());
            var driver = operation.SearchDriv(id);
            var drivers=driver.shtraf;
           var shtrafs= new BindingList<ShtrafMod>();
            foreach(var p in drivers)
            {
               shtrafs.Add(operation.SearchShtraf(p));
            }
            label5.Text= "Сумма штрафов: "+discont.Sum(drivers).ToString();
            dataGridView4.DataSource = shtrafs;
            
        }
    }
}
