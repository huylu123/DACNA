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

namespace BookEccommerce_Admin
{
    public partial class PublisherAdmin : Form
    {
        public BookManagementService bookManagement = new BookManagementService();
        public PublisherAdmin()
        {
            InitializeComponent();
        }

        private void PublisherAdmin_Load(object sender, EventArgs e)
        {
            List<Publisher> publishers = bookManagement.viewAllPub();
            dataGridView2.DataSource = publishers;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmDashboard frmAdmin = new FrmDashboard();
            frmAdmin.Show();
            this.Close();
        }

        
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int pubId = int.Parse(dataGridView2.SelectedRows[0].Cells["Id"].Value.ToString());
                Publisher publisher = bookManagement.viewPublisher(pubId);
                if (publisher != null)
                {
                    textBox2.Text = publisher.Id.ToString();
                    textBox1.Text = publisher.Publishname;
                }
            }
        }
         

        private void button2_Click(object sender, EventArgs e)
        {
            Publisher newPub = new Publisher()
            {
                Publishname = textBox1.Text.Trim(),
            };
            bookManagement.addPublisher(newPub);
            List<Publisher> publishers = bookManagement.viewAllPub();
            dataGridView2.DataSource = publishers;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE U SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int Id = int.Parse(textBox2.Text);
                bool result = bookManagement.delPublisher(Id);
                if (result)
                {
                    List<Publisher> publishers = bookManagement.viewAllPub();
                    dataGridView2.DataSource = publishers;
                }
                else { MessageBox.Show("SORRY BAE"); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Publisher newPub = new Publisher()
            {
                Id = int.Parse(textBox2.Text.Trim()),
                Publishname = textBox1.Text.Trim()
            };
            bool result = bookManagement.updatePub(newPub);
            if (result)
            {
                List<Publisher> publishers = bookManagement.viewAllPub();
                dataGridView2.DataSource = publishers;
                MessageBox.Show("SUCCESS");
            }
            else { MessageBox.Show("SORRY BAE"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String keyword = textBox6.Text.Trim();
            List<Publisher> publishers = bookManagement.SearchPub(keyword);
            dataGridView2.DataSource = publishers;
        }
    }
}
