using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary_RepositoryDLL.Services;
using ClassLibrary_RepositoryDLL.Entities;
using Microsoft.Data.SqlClient;
using ClassLibrary_RepositoryDLL.Services.Admin;

namespace BookEccommerce_Admin
{
    public partial class BookAdmin : Form
    {
        public BookManagementService bookManagement = new BookManagementService();
        public BookAdmin()                            
        {
            InitializeComponent();
        }

        private void BookAdmin_Load(object sender, EventArgs e)
        {
            List<Book> books = bookManagement.viewAllBook();
            dataGridView2.DataSource = books;
            List<Author> reader = bookManagement.viewAllAuthor();
            cbx_author.DisplayMember = "Authorname";
            cbx_author.ValueMember = "Id";
            cbx_author.SelectedIndex = -1;
            cbx_author.DataSource = reader;

            List<Publisher> pub = bookManagement.viewAllPub();
            cbx_publisher.DisplayMember = "Publishname";
            cbx_publisher.ValueMember = "Id";
            cbx_publisher.SelectedIndex = -1;
            cbx_publisher.DataSource = pub;

            List<Category> cate = bookManagement.viewAllCategory();
            cbx_category.DisplayMember = "Categoryname";
            cbx_category.ValueMember = "Id";
            cbx_category.SelectedIndex = -1;
            cbx_category.DataSource = cate;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book newBook = new Book()
            {
                Bookname = txt_bookname.Text.Trim(),
                AuthorId = int.Parse(cbx_author.SelectedValue.ToString()),
                PublisherId = int.Parse(cbx_publisher.SelectedValue.ToString()),
                CategoryId = int.Parse(cbx_category.SelectedValue.ToString()),
                Price = double.Parse(txt_price.Text.Trim()),
                StorageQuantity = int.Parse(txt_quantity.Text.Trim()),
                Description = txt_description.Text.Trim(),
                Image = txt_picture.Text.Trim(),
            };
            bookManagement.addBook(newBook);
            List<Book> books = bookManagement.viewAllBook();
            dataGridView2.DataSource = books;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count > 0)
            {
                int bookId = int.Parse(dataGridView2.SelectedRows[0].Cells["Id"].Value.ToString());
                Book book = bookManagement.viewDetailBook(bookId);
                Author author = bookManagement.viewAuthor(book.AuthorId);
                Category category = bookManagement.viewCategory(book.CategoryId);
                Publisher publisher = bookManagement.viewPublisher(book.PublisherId);
                if (book != null)
                {
                    txt_id.Text = book.Id.ToString();
                    txt_bookname.Text = book.Bookname;
                    cbx_author.Text = author.Authorname;
                    cbx_publisher.Text = publisher.Publishname;
                    cbx_category.Text = category.Categoryname;
                    txt_price.Text = book.Price.ToString();
                    txt_description.Text = book.Description;
                    pictureBox1.ImageLocation = @"../../../upload/" + book.Image;
                    txt_picture.Text = book.Image;
                    txt_quantity.Text = book.StorageQuantity.ToString();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmDashboard frmAdmin = new FrmDashboard();
            frmAdmin.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE U SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                int Id = int.Parse(txt_id.Text);
                bool result = bookManagement.delBook(Id);
                if (result)
                {
                    List<Book> books = bookManagement.viewAllBook();
                    dataGridView2.DataSource = books;
                }
                else { MessageBox.Show("SORRY BAE"); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Book newBook = new Book()
            {
                Id = int.Parse(txt_id.Text.Trim()),
                Bookname = txt_bookname.Text.Trim(),
                AuthorId = int.Parse(cbx_author.SelectedValue.ToString()),
                PublisherId = int.Parse(cbx_publisher.SelectedValue.ToString()),
                CategoryId = int.Parse(cbx_category.SelectedValue.ToString()),
                Price = double.Parse(txt_price.Text.Trim()),
                StorageQuantity = int.Parse(txt_quantity.Text.Trim()),
                Description = txt_description.Text.Trim(),
                Image = txt_picture.Text.Trim()
            };
            bool result = bookManagement.updateBook(newBook);
            if (result)
            {
                List<Book> books = bookManagement.viewAllBook();
                dataGridView2.DataSource = books;
                MessageBox.Show("SUCCESS");
            }
            else { MessageBox.Show("SORRY BAE"); }
        }
        /**
         * 
        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.OpenFile());
                txt_picture.Text = openFileDialog1.SafeFileName;
            }
            try
            {
                Book newBook = new Book()
                {
                    Id = int.Parse(txt_id.Text.Trim())
                };
                string fileName = openFileDialog1.SafeFileName;
                string rootPath = @"../../../upload";
                newBook.Image = fileName;
                File.Copy(openFileDialog1.FileName, rootPath + "/" + fileName, true);
                bool result = bookManagement.UpdateImage(newBook);
                if (result)
                {
                    MessageBox.Show("You have saved your picture");

                }
                else
                {
                    MessageBox.Show("Your didn't change your picture");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your didn't change your picture");
            }

        }
         * **/

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            String keyword = txtSearch.Text.Trim();
            List<Book> books = bookManagement.SelectByKeyword(keyword);
            dataGridView2.DataSource = books;
        }

        private void cbx_author_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = 1;
            if (cbx_author.SelectedIndex > 0)
            {
                value = Convert.ToInt32(cbx_author.SelectedValue.ToString());
                List<Book> books = bookManagement.GetDetailsByAuthorId(value);
                dataGridView2.DataSource = books;
            }
            else
            {
                List<Book> books = bookManagement.viewAllBook();
                dataGridView2.DataSource = books;
            }
        }

        private void cbx_publisher_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = 1;
            if (cbx_publisher.SelectedIndex > 0)
            {
                value = Convert.ToInt32(cbx_publisher.SelectedValue.ToString());
                List<Book> books = bookManagement.GetDetailsByPubId(value);
                dataGridView2.DataSource = books;
            }
            else
            {
                List<Book> books = bookManagement.viewAllBook();
                dataGridView2.DataSource = books;
            }
        }

        private void cbx_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = 1;
            if (cbx_category.SelectedIndex > 0)
            {
                value = Convert.ToInt32(cbx_category.SelectedValue.ToString());
                List<Book> books = bookManagement.GetDetailsByCateId(value);
                dataGridView2.DataSource = books;
            }
            else
            {
                List<Book> books = bookManagement.viewAllBook();
                dataGridView2.DataSource = books;
            }
        }
    }
}
