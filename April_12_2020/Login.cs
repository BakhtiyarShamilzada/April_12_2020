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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void chkbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register(this);
            register.Show();
            this.Hide();
        }
    }
}
