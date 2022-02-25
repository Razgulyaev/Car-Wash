using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp16.Model
{
    internal class Cart
    {
        enum Capacity { Box = 3}
        
        private List<Service> _services = new List<Service> ();
        public bool Saveorder(int id, DateTime time, DateTime date)
        {
            using(Connection connectionDB = new Connection())
            {
                DateTime searchTime = new DateTime(date.Year,date.Month,date.Day,time.Hour,time.Minute,time.Second);
                var freebox = (from row in connectionDB.Box
                              where row.Date_Time == searchTime
                              select row.Number_Box).ToList();
                if (freebox.Count == (int)Capacity.Box) return false;
                var box = new Box();
                box.Date_Time = searchTime;
                box.Number_Box = freebox.Count+1;
                box.Id_Customer = id;
                connectionDB.Box.Add(box);
                connectionDB.SaveChanges();

                foreach (var item in _services)
                {
                    history his = new history();
                    his.Number_Box = box.Number_Box;
                    his.Data_Time_Box = box.Date_Time;
                    his.FK_Service = item.Id;
                    connectionDB.history.Add(his);
                }
                connectionDB.SaveChanges();
                return true;
            }
        }
        public void AddOrder(string name)
        {
            Service service;
            using(Connection connection = new Connection())
            {
                service = (from row in connection.Service
                                  where row.Service_Name == name
                                  select row).FirstOrDefault();
            }

            _services.Add(service);
        }
        public List<Service> ShowOrders()
        {
            return _services;
        }
    }
}
