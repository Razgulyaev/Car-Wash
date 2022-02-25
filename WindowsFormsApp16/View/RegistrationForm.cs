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
    public partial class RegistrationForm : Form
    {
        AutorizationForm _autorizationForm;
        EntryUser _entryUser = new EntryUser();
        public RegistrationForm(AutorizationForm autorizationForm)
        {
            InitializeComponent();
            this._autorizationForm = autorizationForm;
            this._autorizationForm.Visible = false;
            this.FormClosed += Exit;
        }
        private void Exit(object o, EventArgs e)
        {
            _autorizationForm.Visible = true;
        }

        private async void ButtonRegistration_Click(object sender, EventArgs e)
        {
            ButtonRegistration.Enabled = false;
            LoginBox.BackColor = Color.White;
            PasswordBox.BackColor = Color.White;
            PasswordBoxAgain.BackColor = Color.White;
            FIOBox.BackColor = Color.White;
            maskedTextBox1.BackColor = Color.White;

            if(maskedTextBox1.Text.Length < 10) {
                maskedTextBox1.BackColor = Color.Red;
                ButtonRegistration.Enabled = true;
                return;
            }
            if (LoginBox.Text == "") {
                LoginBox.BackColor = Color.Red;
                ButtonRegistration.Enabled = true;
                return;
            }
            if (PasswordBox.Text == "") {
                PasswordBox.BackColor = Color.Red;
                ButtonRegistration.Enabled = true;
                return;
            }
            if (PasswordBoxAgain.Text == "") {
                PasswordBoxAgain.BackColor = Color.Red;
                ButtonRegistration.Enabled = true;
                return;
            }

            int year = DateTime.Now.Year;
            year -= 18;
            if (year < dateTimePicker1.Value.Year) return;
            if (PasswordBox.Text != PasswordBoxAgain.Text)
            {
                PasswordBox.BackColor = Color.Red;
                PasswordBoxAgain.BackColor = Color.Red; 
                ButtonRegistration.Enabled = true;
                return;
            }

            var profile = new Profile();
            _entryUser.Login = LoginBox.Text;
            _entryUser.Password = PasswordBox.Text;
            profile.FIO = FIOBox.Text;
            profile.Phone = long.Parse(maskedTextBox1.Text);
            profile.Total = 0;
            profile.BDay = dateTimePicker1.Value;

            bool result = await _entryUser.CreateNewUser(profile);
            if(result == true)
            {
                _autorizationForm.Visible = true;
                _autorizationForm.Autorization(_entryUser.Login, _entryUser.Password, this);
            }
            ButtonRegistration.Enabled = true;
        }
    }
}
