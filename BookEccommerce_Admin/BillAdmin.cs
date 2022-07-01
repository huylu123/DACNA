using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary_RepositoryDLL.Services;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Services.Admin;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Repository.Interface;
namespace BookEccommerce_Admin
{
 
    public partial class BillAdmin : Form
    {
        public BookManagementService CheckOutManagement = new BookManagementService();
        public BookManagementService Account = new BookManagementService();
        public BookManagementService Book = new BookManagementService();

        public BillAdmin()
        {
            InitializeComponent();
        }

        private void BillAdmin_Load(object sender, EventArgs e)  
        {
            dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            List<Checkout> Checkouts = CheckOutManagement.viewAllCheckOut();
            
            BillID.DisplayMember = "Id";
            BillID.ValueMember = "AccountId";
            BillID.DataSource = Checkouts;
        }
      

        private void dgvBill_SelectionChanged(object sender, EventArgs e)
            {
               
            if (dgvBill.SelectedRows.Count > 0)
                {
                    int CheckOutID = int.Parse(dgvBill.SelectedRows[0].Cells["Id"].Value.ToString());
                    Checkout checkout = CheckOutManagement.viewDetailCheckOut(CheckOutID);
                    Account account = Account.viewDetailAccount(CheckOutID);
                    Book book = Book.viewDetailBook(CheckOutID);
                
                if (checkout != null && account !=null)
                 {                                         
                    cbxCustomerID.Text = account.Id.ToString();
                    txtNameCustomer.Text = account.Username.ToString();
                    txtPhoneNumber.Text= account.Phone.ToString();
                    txtAddress.Text= account.Address.ToString();   
                    //txtTotal.Text=book.Bookname.ToString();
                    txtbuybook.Text = book.Bookname.ToString();
                   
                }
                }
                
            }

        private void billid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = 1;
            if (BillID.SelectedIndex > 0)
            {
                value = Convert.ToInt32(BillID.SelectedValue.ToString());
                List<Account> Accounts = Account.GetDetailsByAccountId(value);
                dgvBill.DataSource = Accounts;
               
            }
            else
            {
                
                List<Checkout> Checkouts = CheckOutManagement.viewAllCheckOut();
                dgvBill.DataSource = Checkouts;
              
            }

        }


      
       
         

        private void LoadInfoHoaDon()
        {
         
        }

    
    }
}
