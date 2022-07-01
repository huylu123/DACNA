using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookEccommerce_Admin
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            BookAdmin frmAdBook = new BookAdmin();
            frmAdBook.Show();
            this.Hide();
        }

        private void btn_author_Click(object sender, EventArgs e)
        {
            AuthorAdmin frmAdAuthor = new AuthorAdmin();
            frmAdAuthor.Show();
            this.Hide();
        }

        private void btn_category_Click(object sender, EventArgs e)
        {
            CateAdmin frmAdCate = new CateAdmin();
            frmAdCate.Show();
            this.Hide();
        }

        private void btn_publisher_Click(object sender, EventArgs e)
        {
            PublisherAdmin frmAdPub = new PublisherAdmin();
            frmAdPub.Show();
            this.Hide();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                //FormLogin f = new FormLogin();
                //f.ShowDialog();
            }
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            FormAddAdmin frmAdAdmin = new FormAddAdmin();
            frmAdAdmin.Show();
            this.Hide();
        }
    }
}
