namespace POS_system
{
    partial class POSSysteminterface
    {
        /// <summary>
        /// Required designer variable
        /// </summary>

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used
        /// </summary>
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
            this.price = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.ShoppingCart = new System.Windows.Forms.ListBox();
            this.PaymentCash = new System.Windows.Forms.Button();
            this.PaymentCard = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.TableLayoutPanel();
            this.home = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.buttontable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.paymentTable = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.paymentTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Dock = System.Windows.Forms.DockStyle.Fill;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(184, 0);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(175, 80);
            this.price.TabIndex = 34;
            this.price.Text = " ";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.Location = new System.Drawing.Point(3, 0);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(175, 80);
            this.total.TabIndex = 33;
            this.total.Text = "Totalt:";
            // 
            // ShoppingCart
            // 
            this.ShoppingCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShoppingCart.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShoppingCart.FormattingEnabled = true;
            this.ShoppingCart.ItemHeight = 21;
            this.ShoppingCart.Location = new System.Drawing.Point(3, 3);
            this.ShoppingCart.Name = "ShoppingCart";
            this.ShoppingCart.Size = new System.Drawing.Size(362, 553);
            this.ShoppingCart.TabIndex = 32;
            this.ShoppingCart.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // PaymentCash
            // 
            this.PaymentCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(214)))), ((int)(((byte)(122)))));
            this.PaymentCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaymentCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentCash.Location = new System.Drawing.Point(4, 84);
            this.PaymentCash.Margin = new System.Windows.Forms.Padding(4);
            this.PaymentCash.Name = "PaymentCash";
            this.PaymentCash.Size = new System.Drawing.Size(173, 114);
            this.PaymentCash.TabIndex = 38;
            this.PaymentCash.Text = "Betala Kontant";
            this.PaymentCash.UseVisualStyleBackColor = false;
            this.PaymentCash.Click += new System.EventHandler(this.PaymentCash_Click);
            // 
            // PaymentCard
            // 
            this.PaymentCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(214)))), ((int)(((byte)(122)))));
            this.PaymentCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaymentCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentCard.Location = new System.Drawing.Point(185, 84);
            this.PaymentCard.Margin = new System.Windows.Forms.Padding(4);
            this.PaymentCard.Name = "PaymentCard";
            this.PaymentCard.Size = new System.Drawing.Size(173, 114);
            this.PaymentCard.TabIndex = 37;
            this.PaymentCard.Text = "Betala Kort";
            this.PaymentCard.UseVisualStyleBackColor = false;
            this.PaymentCard.Click += new System.EventHandler(this.PaymentCard_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancel.Location = new System.Drawing.Point(1070, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(176, 64);
            this.cancel.TabIndex = 39;
            this.cancel.Text = "Töm Varukorgen";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // topPanel
            // 
            this.topPanel.ColumnCount = 3;
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.topPanel.Controls.Add(this.cancel, 1, 0);
            this.topPanel.Controls.Add(this.home, 0, 0);
            this.topPanel.Controls.Add(this.remove, 2, 0);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.RowCount = 1;
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topPanel.Size = new System.Drawing.Size(1434, 70);
            this.topPanel.TabIndex = 40;
            // 
            // home
            // 
            this.home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(214)))), ((int)(((byte)(122)))));
            this.home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.home.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.home.Location = new System.Drawing.Point(3, 3);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(1061, 64);
            this.home.TabIndex = 40;
            this.home.Text = "Startsida";
            this.home.UseVisualStyleBackColor = false;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // remove
            // 
            this.remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.remove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remove.Location = new System.Drawing.Point(1252, 3);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(179, 64);
            this.remove.TabIndex = 41;
            this.remove.Text = "Ta bort vald";
            this.remove.UseVisualStyleBackColor = false;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // buttontable
            // 
            this.buttontable.ColumnCount = 5;
            this.buttontable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttontable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttontable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttontable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttontable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttontable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttontable.Location = new System.Drawing.Point(0, 70);
            this.buttontable.Name = "buttontable";
            this.buttontable.RowCount = 4;
            this.buttontable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttontable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttontable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttontable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttontable.Size = new System.Drawing.Size(1066, 767);
            this.buttontable.TabIndex = 41;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.paymentTable, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.ShoppingCart, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1066, 70);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.96954F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.03046F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(368, 767);
            this.tableLayoutPanel3.TabIndex = 42;
            // 
            // paymentTable
            // 
            this.paymentTable.ColumnCount = 2;
            this.paymentTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.paymentTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.paymentTable.Controls.Add(this.PaymentCard, 1, 1);
            this.paymentTable.Controls.Add(this.PaymentCash, 0, 1);
            this.paymentTable.Controls.Add(this.price, 1, 0);
            this.paymentTable.Controls.Add(this.total, 0, 0);
            this.paymentTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentTable.Location = new System.Drawing.Point(3, 562);
            this.paymentTable.Name = "paymentTable";
            this.paymentTable.RowCount = 2;
            this.paymentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.09662F));
            this.paymentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.90338F));
            this.paymentTable.Size = new System.Drawing.Size(362, 202);
            this.paymentTable.TabIndex = 0;
            // 
            // POSSysteminterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 837);
            this.Controls.Add(this.buttontable);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.topPanel);
            this.Name = "POSSysteminterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point of Sale System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.topPanel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.paymentTable.ResumeLayout(false);
            this.paymentTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Button PaymentCash;
        private System.Windows.Forms.Button PaymentCard;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TableLayoutPanel topPanel;
        private System.Windows.Forms.TableLayoutPanel buttontable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel paymentTable;
        public System.Windows.Forms.ListBox ShoppingCart;
        private System.Windows.Forms.Button home;
        private System.Windows.Forms.Button remove;
    }
}

