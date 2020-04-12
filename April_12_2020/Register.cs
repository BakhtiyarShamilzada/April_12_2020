using April_12_2020.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace April_12_2020
{
    public partial class Register : Form
    {
        private readonly Form _login;
        private readonly P507Entities1 _db;
        public Register(Form login)
        {
            _login = login;
            _db = new P507Entities1();
            InitializeComponent();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtRepeatPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtRepeatPassword.UseSystemPasswordChar = true;
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string fullname = txtFullname.Text.Trim();
            string password = txtPassword.Text.Trim();
            string repeatPassword = txtRepeatPassword.Text.Trim();

            if(!IsValid(email, fullname, password, repeatPassword))
            {
                return;
            }

            Users user = new Users
            {
                Email = email,
                Fullname = fullname,
                Password = password
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            MessageBox.Show("Successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        bool IsValid(string email, string fullname, string password, string repeatPassword)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(fullname) || 
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatPassword))
            {
                MessageBox.Show("Fill all input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(!email.IsEmail())
            {
                MessageBox.Show("Invalid email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool hasEmail = _db.Users.Any(u => u.Email == email);

            if(hasEmail)
            {
                MessageBox.Show("Email must be unique", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(password != repeatPassword)
            {
                MessageBox.Show("Invalid repeat password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

    }
}
