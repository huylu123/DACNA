
namespace BookEccommerce_Admin
{
    partial class FrmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_logout = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_order = new System.Windows.Forms.Button();
            this.btn_user = new System.Windows.Forms.Button();
            this.btn_category = new System.Windows.Forms.Button();
            this.btn_publisher = new System.Windows.Forms.Button();
            this.btn_author = new System.Windows.Forms.Button();
            this.btn_book = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(58, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(870, 252);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(971, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 163);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Red;
            this.btn_logout.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_logout.Image = ((System.Drawing.Image)(resources.GetObject("btn_logout.Image")));
            this.btn_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logout.Location = new System.Drawing.Point(971, 230);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(147, 50);
            this.btn_logout.TabIndex = 2;
            this.btn_logout.Text = "Log out";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.btn_order);
            this.groupBox1.Controls.Add(this.btn_user);
            this.groupBox1.Controls.Add(this.btn_category);
            this.groupBox1.Controls.Add(this.btn_publisher);
            this.groupBox1.Controls.Add(this.btn_author);
            this.groupBox1.Controls.Add(this.btn_book);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(48, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1070, 315);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Admin ";
            // 
            // btn_order
            // 
            this.btn_order.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn_order.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_order.Location = new System.Drawing.Point(404, 188);
            this.btn_order.Name = "btn_order";
            this.btn_order.Size = new System.Drawing.Size(208, 80);
            this.btn_order.TabIndex = 5;
            this.btn_order.Text = "Order";
            this.btn_order.UseVisualStyleBackColor = false;
            // 
            // btn_user
            // 
            this.btn_user.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_user.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_user.Location = new System.Drawing.Point(735, 188);
            this.btn_user.Name = "btn_user";
            this.btn_user.Size = new System.Drawing.Size(208, 80);
            this.btn_user.TabIndex = 4;
            this.btn_user.Text = "Add Admin";
            this.btn_user.UseVisualStyleBackColor = false;
            this.btn_user.Click += new System.EventHandler(this.btn_user_Click);
            // 
            // btn_category
            // 
            this.btn_category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_category.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_category.Location = new System.Drawing.Point(83, 188);
            this.btn_category.Name = "btn_category";
            this.btn_category.Size = new System.Drawing.Size(208, 80);
            this.btn_category.TabIndex = 3;
            this.btn_category.Text = "Category";
            this.btn_category.UseVisualStyleBackColor = false;
            this.btn_category.Click += new System.EventHandler(this.btn_category_Click);
            // 
            // btn_publisher
            // 
            this.btn_publisher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_publisher.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_publisher.Location = new System.Drawing.Point(735, 59);
            this.btn_publisher.Name = "btn_publisher";
            this.btn_publisher.Size = new System.Drawing.Size(208, 80);
            this.btn_publisher.TabIndex = 2;
            this.btn_publisher.Text = "Publisher";
            this.btn_publisher.UseVisualStyleBackColor = false;
            this.btn_publisher.Click += new System.EventHandler(this.btn_publisher_Click);
            // 
            // btn_author
            // 
            this.btn_author.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_author.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_author.Location = new System.Drawing.Point(404, 59);
            this.btn_author.Name = "btn_author";
            this.btn_author.Size = new System.Drawing.Size(208, 80);
            this.btn_author.TabIndex = 1;
            this.btn_author.Text = "Author";
            this.btn_author.UseVisualStyleBackColor = false;
            this.btn_author.Click += new System.EventHandler(this.btn_author_Click);
            // 
            // btn_book
            // 
            this.btn_book.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_book.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_book.Location = new System.Drawing.Point(83, 59);
            this.btn_book.Name = "btn_book";
            this.btn_book.Size = new System.Drawing.Size(208, 80);
            this.btn_book.TabIndex = 0;
            this.btn_book.Text = "Book";
            this.btn_book.UseVisualStyleBackColor = false;
            this.btn_book.Click += new System.EventHandler(this.btn_book_Click);
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 641);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmDashboard";
            this.Text = "FrmDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_order;
        private System.Windows.Forms.Button btn_user;
        private System.Windows.Forms.Button btn_category;
        private System.Windows.Forms.Button btn_publisher;
        private System.Windows.Forms.Button btn_author;
        private System.Windows.Forms.Button btn_book;
    }
}