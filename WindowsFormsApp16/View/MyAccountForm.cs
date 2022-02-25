using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp16.Model;

namespace WindowsFormsApp16.View
{
    public partial class MyAccountForm : Form
    {
        AutorizationForm mainform;
        int iduser;
        public MyAccountForm(AutorizationForm mainform, int iduser)
        {
            InitializeComponent();
            this.mainform = mainform;
            this.iduser = iduser;
            mainform.Visible = false;
            this.FormClosed += MyAccountForm_FormClosed;
            if(DateTime.Now.TimeOfDay <= new TimeSpan(12,00,00))
            {
                label1.Text = "Доброе утро, " + Environment.NewLine + Manager.GetName(iduser) + "! " + Environment.NewLine;
            }
            if (DateTime.Now.TimeOfDay <= new TimeSpan(18, 00, 00))
            {
                label1.Text = "Добрый день, " + Environment.NewLine + Manager.GetName(iduser) + "! " + Environment.NewLine;
            }
            if (DateTime.Now.TimeOfDay <= new TimeSpan(22, 00, 00))
            {
                label1.Text = "Добрый вечер, " + Environment.NewLine + Manager.GetName(iduser) + "! " + Environment.NewLine;
            }
            else
            {
                label1.Text = "Доброй ночи, " + Environment.NewLine + Manager.GetName(iduser) + "! " + Environment.NewLine;
            }
            label2.Text = "Потрачено " + Manager.GetMoney(iduser) + "!" + Environment.NewLine;

            foreach (var item in Manager.GetAllservices())
            {
                listBox1.Items.Add(item.Service_Name);
            }

            //using(Connection con = new Connection())
            //{
            //    Service service6 = new Service() { Service_Name = "Мойка", Price = 200 };
            //    Service service1 = new Service() { Service_Name = "Мойка химией", Price = 350 };
            //    Service service2 = new Service() { Service_Name = "Мойка с химией и протиркой", Price = 470 };
            //    Service service3 = new Service() { Service_Name = "Полировка", Price = 800 };
            //    Service service4 = new Service() { Service_Name = "Мойка салона", Price = 390 };
            //    Service service5 = new Service() { Service_Name = "Мойка двигателя", Price = 1000 };


            //    con.Service.Add(service1);
            //    con.Service.Add(service2);
            //    con.Service.Add(service3);
            //    con.Service.Add(service4);
            //    con.Service.Add(service5);
            //    con.Service.Add(service6);
            //    con.SaveChanges();
            //}

            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            monthCalendar1.MinDate = DateTime.Now;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime datetime = dateTimePicker1.Value;
            DateTime datenew = new DateTime(datetime.Year, datetime.Month, datetime.Day, datetime.Hour, 0, 0);
            dateTimePicker1.Value = datenew;
            this.Update();
        }

        private void MyAccountForm_FormClosed(object sender, FormClosedEventArgs e) {
            mainform.Visible = true;
        }
        Cart cart = new Cart();
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            if (true== cart.Saveorder(iduser, dateTimePicker1.Value, monthCalendar1.SelectionStart))
            {
                MessageBox.Show("!");
            }
            else
            {
                button1.BackColor = Color.Red;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cart.AddOrder(listBox1.SelectedItem.ToString());
            listBox2.Items.Clear();
            foreach (var item in cart.ShowOrders())
            {
                listBox2.Items.Add(item.Service_Name);
            }
        }
    }
}
