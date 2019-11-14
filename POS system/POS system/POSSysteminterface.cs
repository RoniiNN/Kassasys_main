using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Data.SQLite;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace POS_system
{
    public partial class POSSysteminterface : Form
    {

        public List<product> products = new List<product>();
        public List<product> productList = new List<product>();
        public List<string> categoryButton = new List<string>();
        receiptGenerator generator = new receiptGenerator();

        /// <summary>
        /// Calculate the total price of all products
        /// </summary>
        private void totalPrice()
        {
            price.Text = products.Sum(total => total.Price).ToString() + "kr";
        }

        /// <summary>
        /// Adds products to the shopping cart
        /// </summary>
        private void addProduct(string item, int price, int vat, int Red, int green, int blue, string category)
        {

            product scContent = new product(item, price, vat, Red, green, blue, category);

            int totalLength = 27;
            int scContent_Item_length = scContent.Item.Length;
            string Dottedspaces = "...";
            int Max_product_name_space = 19;
            int Minimum_product_name_space = 18;
            int partialpriceLength = scContent.Price.ToString().Length;
            int priceLength = partialpriceLength + 2;

            /// <summary>
            /// If the Item length is longer than the max allowed length
            /// Removes end of string, adds dottedspaces
            /// merge Product Item Name, Avaible space, Product Price
            /// </summary>
            if (scContent_Item_length >= Max_product_name_space)
            {

                scContent.Item = scContent.Item.Substring(0, 15);
                scContent.Item = scContent.Item + Dottedspaces;

                totalLength = totalLength - scContent.Item.Length;
                totalLength = totalLength - priceLength;

                string spacing = new string(' ', totalLength);
                ShoppingCart.Items.Add(scContent.Item + spacing + scContent.Price + "kr");
            };

            /// <summary>
            /// If the Item length is shorter than the max allowed length
            /// merge Product Item Name, Avaible space, Product Price
            /// </summary>
            if (scContent_Item_length <= Minimum_product_name_space)
            {

                totalLength = totalLength - scContent.Item.Length;
                totalLength = totalLength - priceLength;
                string spacing = new string(' ', totalLength);
                ShoppingCart.Items.Add(scContent.Item + spacing + scContent.Price + "kr");
            };

            products.Add(scContent);
        }

        private void addProductFunction(string item, int price, int vat, int Red, int green, int blue, string category)
        {
            addProduct(item, price, vat, Red, green, blue, category);
            totalPrice();
        }

        public POSSysteminterface()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadProducts();
            categoryList();
            dynamicCategoryButtons();
            totalPrice();
        }
        /// <summary>
        /// Cancel button 
        /// </summary>
        private void cancel_Click(object sender, EventArgs e)
        {
            ShoppingCart.Items.Clear();
            products.Clear();
            totalPrice();
        }
        /// <summary>
        /// Purchase button Card
        /// </summary>
        private void PaymentCard_Click(object sender, EventArgs e)
        {
            generator.receiptGeneratorfunction(DateTime.Now, products, this);
            saveReceipt();
            ShoppingCart.Items.Clear();
            products.Clear();
            totalPrice();
        }

        /// <summary>
        /// Purchase button Cash
        /// </summary>
        private void PaymentCash_Click(object sender, EventArgs e)
        {
            generator.receiptGeneratorfunction(DateTime.Now, products, this);
            saveReceipt();
            ShoppingCart.Items.Clear();
            products.Clear();
            totalPrice();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// function for adding buttons dynamicly
        /// </summary>
        private void dynamicProductButtons(string s)
        {
            List<product> tst = categorySort(s);

            /// <summary>
            /// Loop for making the  buttons
            /// </summary>
            for (int i = 0; i < tst.Count; i++)
            {
                Button button = new Button();
                button.Name = tst[i].Item.ToString();
                button.Text = tst[i].Item.ToString();
                button.Tag = tst[i];
                button.Anchor = AnchorStyles.Left;
                button.AutoSize = true;
                button.Width = 500;
                button.Height = 500;
                button.Dock = DockStyle.Fill;
                button.Font = new System.Drawing.Font("Microsoft Sans Serif", 21);
                button.BackColor = Color.FromArgb(productList[i].ColorRed, productList[i].ColorGreen, productList[i].ColorBlue);
                button.MouseDown += button_click;

                /// <summary>
                /// Adding the onclick function for each button
                /// </summary>
                void button_click(object sender, MouseEventArgs e)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        Button butt;
                        if (sender is Button)
                        {
                            butt = sender as Button;
                            product productButton;

                            if (butt.Tag is product)
                            {
                                productButton = butt.Tag as product;
                                string item = productButton.Item;
                                int price = productButton.Price;
                                int vat = productButton.Vat;
                                int colorRed = productButton.ColorRed;
                                int colorGreen = productButton.ColorGreen;
                                int colorBlue = productButton.ColorBlue;
                                string category = productButton.Category;

                                addProductFunction(item, price, vat, colorRed, colorGreen, colorBlue, category);
                            }
                        }
                    }

                    if (e.Button == MouseButtons.Right)
                    {
                        ColorDialog color = new ColorDialog();
                        color.ShowDialog();
                        button.BackColor = color.Color;
                    }

                }
                buttontable.Controls.Add(button);

            }
        }

        /// <summary>
        /// Function for extracting all products from our database 
        /// </summary>
        public void loadProducts()
        {
            /// <summary>
            /// Creates connection with SQLdatabase, initiates datareader and reads from select path product_table
            /// </summary>
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=../../../Productdatabase.sqlite;Version=3;");
            sqlite_conn.Open();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM product_table";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            /// <summary>
            /// Gets infomation from database
            /// </summary>
            while (sqlite_datareader.Read())
            {

                string productReader = sqlite_datareader.GetString(0);
                int priceReader = sqlite_datareader.GetInt16(1);
                int vatReader = sqlite_datareader.GetInt16(2);
                int redReader = sqlite_datareader.GetInt16(3);
                int greenReader = sqlite_datareader.GetInt16(4);
                int blueReader = sqlite_datareader.GetInt16(5);
                string categoryReader = sqlite_datareader.GetString(6);

                product DbProduct = new product(productReader, priceReader, vatReader, redReader, greenReader, blueReader, categoryReader);
                productList.Add(DbProduct);

            }

            sqlite_conn.Close();
        }

        List<product> categorySort(string newCategory)

        /// <summary>
        /// Moves every product to its assigned category
        /// </summary>
        {

            List<product> listan = new List<product>();
            foreach (product p in productList)
            {
                
                string productCategory = p.Category;
                if (productCategory == newCategory)
                {
                    listan.Add(p);
                }
                else
                {

                }
            }
            return listan;

        }

        /// <summary>
        /// Creates the Category lists
        /// </summary>
        public void categoryList()
        {
            foreach (product p in productList)
            {
                string productCategory = p.Category.ToString();
                if (!categoryButton.Contains(productCategory))
                {
                    categoryButton.Add(productCategory);
                }
                else
                {

                }

            }
        }

        private void dynamicCategoryButtons()
        {
            /// <summary>
            /// Loop for making the category buttons
            /// </summary>
            for (int i = 0; i < categoryButton.Count; i++)
            {
                Button button = new Button();
                button.Name = categoryButton[i];
                button.Text = categoryButton[i];
                button.Tag = categoryButton[i];
                button.Anchor = AnchorStyles.Left;
                button.AutoSize = true;
                button.Width = 500;
                button.Height = 500;
                button.Dock = DockStyle.Fill;
                button.Font = new System.Drawing.Font("Microsoft Sans Serif", 21);
                button.BackColor = Color.FromArgb(productList[i].ColorRed, productList[i].ColorGreen, productList[i].ColorBlue);
                button.MouseDown += button_click;

                /// <summary>
                /// Adding the onclick function for each button
                /// </summary>
                void button_click(object sender, MouseEventArgs e)
                {
                    if(e.Button== MouseButtons.Left)
                    {
                        foreach (string s in categoryButton)
                        {
                            buttontable.Controls.RemoveByKey(s.ToString());
                        }
                        dynamicProductButtons(button.Tag.ToString());
                    }
                   if (e.Button == MouseButtons.Right)
                    {
                        ColorDialog color = new ColorDialog();
                        color.ShowDialog();
                        button.BackColor = color.Color;
                    }
                }
                buttontable.Controls.Add(button);

            }
        }

        /// <summary>
        /// Takes user back to homepage
        /// </summary>
        private void home_Click(object sender, EventArgs e)
        {
            buttontable.Controls.Clear();
            dynamicCategoryButtons();
        }

        /// <summary>
        /// Removes selected product in listbox
        /// </summary>
        private void removeProduct()
        {
            if (ShoppingCart.SelectedIndex == -1)
            {
                MessageBox.Show("Välj en vara att ta bort");
            }
            else
            {
                products.RemoveAt(ShoppingCart.SelectedIndex);
                ShoppingCart.Items.Remove(ShoppingCart.SelectedItem);
                totalPrice();
            }
        }
        private void remove_Click(object sender, EventArgs e)
        {
            removeProduct();
        }

        /// <summary>
        /// Method for saving receipt information to database
        /// </summary>
        public void saveReceipt()
        {

            /// <summary>    
            /// Opens a SQLite connection and makes a prepared statement.
            /// </summary>
            SQLiteConnection sqlCon = new SQLiteConnection("Data Source=../../../Productdatabase.sqlite;Version=3;");
            sqlCon.Open();
            SQLiteCommand sqlCmd = sqlCon.CreateCommand();
            sqlCmd.CommandText = "INSERT INTO receipt (Time, Seller, TotalPrice, Products)" +
                " VALUES (@time, @seller, @totalprice, @products)";

            /// <summary>
            /// Adds the prepared statements to the SQLite code
            /// </summary>
            SQLiteParameter paramTime = new SQLiteParameter("@time");
            SQLiteParameter paramSeller = new SQLiteParameter("@seller");
            SQLiteParameter paramPrice = new SQLiteParameter("@totalprice");
            SQLiteParameter paramproduct = new SQLiteParameter("@products");

            sqlCmd.Parameters.Add(paramTime);
            sqlCmd.Parameters.Add(paramSeller);
            sqlCmd.Parameters.Add(paramPrice);
            sqlCmd.Parameters.Add(paramproduct);

            sqlCmd.Prepare();

            /// <summary>
            /// Changes the prepared statements to the real data
            /// </summary>
            sqlCmd.Parameters[0].Value = DateTime.Now.ToString();
            sqlCmd.Parameters[1].Value = "Peter";
            sqlCmd.Parameters[2].Value = products.Sum(total => total.Price);
            sqlCmd.Parameters[3].Value = ObjectToByteArray(products);
            sqlCmd.ExecuteNonQuery();

            sqlCon.Close();
        }

        /// </summary>
        /// Method for converting object to bytearray to save the object into the database
        /// </summary>
        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }


    }
}

        

  

