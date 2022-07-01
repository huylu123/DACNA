using ClassLibrary_RepositoryDLL.Services;
using ClassLibrary_RepositoryDLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary_RepositoryDLL.Services.Admin;

namespace BookEccommerce_Admin
{
    public partial class FormAddAdmin : Form
    {
        public AccountManagementService accountManagement = new AccountManagementService();
        public FormAddAdmin()
        {
            InitializeComponent();
            txt_password.PasswordChar = '•';
            txt_confirmPasssword.PasswordChar = '•';
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            CancelEventArgs oc = new CancelEventArgs();
            oc.Cancel = true;
            if (string.IsNullOrEmpty(txt_username.Text))
            {
                errorProvider1.SetError(txt_username, "Your username is left blank");
            }
            else if (string.IsNullOrEmpty(txt_password.Text))
            {
                errorProvider1.SetError(txt_password, "Your password is left blank");
            }
            else if (txt_password.Text.Trim().Length < 8)
            {
                errorProvider1.SetError(txt_password, "Password must be at least 8 characters");
            }
            else if (string.IsNullOrEmpty(txt_phone.Text))
            {
                errorProvider1.SetError(txt_phone, "Your phone is left blank");
            }
            else if (txt_phone.Text.Trim().Length < 10)
            {
                errorProvider1.SetError(txt_phone, "Phone must be at least 10 characters");
            }
            else if (string.IsNullOrEmpty(txt_name.Text))
            {
                errorProvider1.SetError(txt_name, "Your name is left blank");
            }
            else if (string.IsNullOrEmpty(txt_address.Text))
            {
                errorProvider1.SetError(txt_address, "Your address is left blank");
            }
            else if (accountManagement.isExistUserName(txt_username.Text))
            {
                errorProvider1.SetError(txt_username, "Username is existed");
            }
            else
            {
                errorProvider1.SetError(txt_username, null);
                errorProvider1.SetError(txt_password, null);
                errorProvider1.SetError(txt_phone, null);
                errorProvider1.SetError(txt_name, null);
                errorProvider1.SetError(txt_address, null);
                oc.Cancel = false;

                if (txt_confirmPasssword.Text == txt_password.Text)
                {
                    Account newAccount = new Account()
                    {
                        Username = txt_username.Text.Trim(),
                        Password = txt_password.Text.Trim(),
                        Fullname = txt_name.Text.Trim(),
                        Address = txt_address.Text.Trim(),
                        Phone = txt_phone.Text.Trim()
                    };
                    accountManagement.AddAccount(newAccount);
                    MessageBox.Show("ADD SUCCESS");
                    FrmDashboard frmAdmin = new FrmDashboard();
                    frmAdmin.Show();
                    this.Close();
                }
                else { MessageBox.Show("Password isn't match"); }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmDashboard frmAdmin = new FrmDashboard();
            frmAdmin.Show();
            this.Close();
        }
    }
}
