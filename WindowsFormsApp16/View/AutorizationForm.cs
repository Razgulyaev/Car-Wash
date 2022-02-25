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
    public partial class AutorizationForm : Form
    {
        EntryUser _entryUser = new EntryUser();
        public AutorizationForm() 
        {
            InitializeComponent();
            label3.Visible = false;
        }
        
        private void button1_Click(object sender, EventArgs e) {
            RegistrationForm registrationForm = new RegistrationForm(this);
            registrationForm.ShowDialog();
        }

        public void Autorization(string login, string pass, Form formClose) {
            formClose.Close();
            _entryUser.Login = login;
            _entryUser.Password = pass;
            if(_entryUser.Enter()==true) {
                MyAccountForm myAccountForm = new MyAccountForm(this,_entryUser.Id.Value);
                myAccountForm.ShowDialog();
            }
        }
        private void EnterDown() {
            PasswordBox.BackColor = Color.White;
            LoginBox.BackColor = Color.White;
            label3.Visible = false;
            if (LoginBox.Text == "") {
                label3.Text = "Логин не введён!";
                label3.Visible = true;
                LoginBox.BackColor = Color.Red;
                return;
            }
            if (PasswordBox.Text == "") {
                label3.Text = "Пароль не введён!";
                label3.Visible = true;
                PasswordBox.BackColor = Color.Red;
                return;
            }

            _entryUser.Login = LoginBox.Text;
            _entryUser.Password = PasswordBox.Text;

            if (_entryUser.Enter() == true) {
                MyAccountForm myAccountForm = new MyAccountForm(this, _entryUser.Id.Value);
                myAccountForm.ShowDialog();
            }
            else {
                label3.Text = "Пароль указан не верно\nили такой пользователь не найден!";
                label3.Visible = true;
            }
        }
        private void ButtonEnter_Click(object sender, EventArgs e) {
            EnterDown();
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                EnterDown();
            }
        }

        private void LoginBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                EnterDown();
            }
        }
    }
}
