using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp16.Model
{
    internal class EntryUser
    {
        private string _login;
        public string Login {
            get=> _login;
            set {
                _login = String.Empty;
                if (value.Length <= 20 && value.Length > 3)
                _login = value;
            }
        }
        private string _password;
        public string Password {
            get => _password;
            set {
                _password = String.Empty;
                if (value.Length <= 10 && value.Length > 3)
                    _password = value;
            }
        }
        public Int32? Id { get; private set; }
        public bool Enter() {
            if (_login == "" || _password == "") return false;
            using(Connection connectionBD = new Connection())
            {
                int? user = (from rowTableCustomer in connectionBD.Customer
                           where rowTableCustomer.Login == _login &&
                                 rowTableCustomer.Password == _password
                           select rowTableCustomer.Id).FirstOrDefault();
                if (user != null && user!=0) {
                    Id = user ?? 0;
                    return true;
                }
                else return false;
            }
        }
        public async Task<bool> CreateNewUser(Profile profile) {
            if (_login == "" || _password == "") return false;
            using(Connection connectionDB = new Connection())
            {
                var User = new Customer();
                User.Login = _login;
                User.Password = _password;
                connectionDB.Customer.Add(User);
                Int32 changeString = await connectionDB.SaveChangesAsync();
                
                if (changeString > 0) {
                    var id = (from user in connectionDB.Customer
                              where user.Login == _login && user.Password == _password
                              select user.Id).FirstOrDefault();
                    profile.Id = id;

                    connectionDB.Profile.Add(profile);
                    await connectionDB.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }
    }
}
