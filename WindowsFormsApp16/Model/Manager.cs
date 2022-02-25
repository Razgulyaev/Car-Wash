using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp16.Model
{
    internal static class Manager
    {
        public static string GetName(int id)
        {
            using(Connection connectionDB = new Connection()) {
                string name = (from rowCustamer in connectionDB.Profile
                               where rowCustamer.Id == id
                               select rowCustamer.FIO).FirstOrDefault();
                return name;
            }
        }
        //public static async Task<decimal> GetMoneyAsync(id)
        //{

        //}
        public static decimal GetMoney(int id)
        {
            using(Connection connectionDB = new Connection())
            {
                decimal? price = (from rowProfile in connectionDB.Profile
                                where rowProfile.Id == id
                                select rowProfile.Total).FirstOrDefault();
                return price ?? 0;
            }
        }
        public static List<Service> GetAllservices()
        {
            var result = Task.Run(() => getAllservices());
            return result.Result;
        }
        private static List<Service> getAllservices()
        {
            using (Connection conn = new Connection())
            {
                var list = (from rowAllService in conn.Service
                            select rowAllService).ToList();
                return list;
            }
        }
    }
}
