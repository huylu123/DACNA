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
    public partial class AuthorAdmin : Form
    {
        public BookManagementService bookManagement = new BookManagementService();
        public AuthorAdmin()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void AuthorAdmin_Load(object sender, EventArgs e)
        {
            List<Author> authors =bookManagement.viewAllAuthor();
            dataGridView2.DataSource = authors;
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int authorId = int.Parse(dataGridView2.SelectedRows[0].Cells["Id"].Value.ToString());
                Author author =bookManagement.viewAuthor(authorId);
                if (author != null)
                {
                    textBox2.Text = author.Id.ToString();
                    textBox1.Text = author.Authorname;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Author newAuthor = new Author()
            {
                Authorname = textBox1.Text.Trim(),
            };
           bookManagement.addAuthor(newAuthor);
            List<Author> authors =bookManagement.viewAllAuthor();
            dataGridView2.DataSource = authors;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Author newAuthor = new Author()
            {
                Id = int.Parse(textBox2.Text.Trim()),
                Authorname = textBox1.Text.Trim()
            };
            bool result =bookManagement.updateAuthor(newAuthor);
            if (result)
            {
                List<Author> authors =bookManagement.viewAllAuthor();
                dataGridView2.DataSource = authors;
                MessageBox.Show("SUCCESS");
            }
            else { MessageBox.Show("SORRY BAE"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE U SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int Id = int.Parse(textBox2.Text);
                bool result =bookManagement.delAuthor(Id);
                if (result)
                {
                    List<Author> authors =bookManagement.viewAllAuthor();
                    dataGridView2.DataSource = authors;
                }
                else { MessageBox.Show("SORRY BAE"); }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmDashboard frmAdmin = new FrmDashboard();
            frmAdmin.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String keyword = textBox6.Text.Trim();
            List<Author> authors = bookManagement.SearchAuthor(keyword);
            dataGridView2.DataSource = authors;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
