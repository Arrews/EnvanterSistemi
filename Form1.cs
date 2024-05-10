using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Math.Field;
using ZstdSharp.Unsafe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EnvanterSistemi
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.button4.Click += new EventHandler(button4_Click);
        }

        private MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost; database=envantersistemi; uid=root;";
            return new MySqlConnection(connectionString);
        }

        //global variables
        bool manager = false;
        bool employee = false;
        bool girisbasarili = false;
        int kullanicistore;
        int kullanici_id;
        Dictionary<int, decimal> productPrices = new Dictionary<int, decimal>();
        decimal totalPrice = 0;
        bool customerMevcut = true;
        decimal storePrimGoal = 0;
        decimal storePrimCurrent = 0;


        //Method for what buttons will be visible on the login page based on employee or manager login
        private void giris(int permission)
        {
            if (permission == 0) //default state
            {
                manager = false;
                employee = false;
                groupBox1.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                label2.Visible = false;
                pictureBox1.Visible = false;
                textBox2.Visible = false;
            }
            else if (permission == 1) // employee login
            {
                employee = true;
                groupBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
            }
            else if (permission == 2) //manager login
            {
                manager = true;
                groupBox1.Visible = true;
                label2.Visible = true;
                pictureBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
            }

        }

        //Method for changing the authorization for some functions based on employee or manager login
        private void gorunum()
        {
            comboBox1.SelectedValue = kullanicistore;
            LoadPersonelIntoDataGridView();
            LoadCustomersIntoDataGridView();
            if (manager)
            {
                button5.Enabled = true;
                button7.Enabled = true;
                dataGridView1.AllowUserToAddRows = true;
                groupBox2.Visible = true;
            }
            else if (employee)
            {
                button5.Enabled = false;
                button7.Enabled = false;
                dataGridView1.AllowUserToAddRows = false;
                groupBox2.Visible = false;
            }

            GetStorePrimInfo();
            label17.Text = storePrimGoal.ToString();
            label18.Text = storePrimCurrent.ToString();
        }

        //Employee Login Button
        private void button1_Click(object sender, EventArgs e)
        {
            giris(1);
        }

        //Manager Login Button
        private void button2_Click(object sender, EventArgs e)
        {
            giris(2);
        }

        //Login Button
        private void button3_Click(object sender, EventArgs e)
        {

            if (manager)
            {
                MySqlConnection connection = GetConnection();
                try
                {
                    connection.Open();

                    // SQL query to select login_id and login_password from the login table
                    string query = "SELECT login_id, login_pw FROM login;";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Execute the query and get the results
                    MySqlDataReader reader = command.ExecuteReader();

                    // Iterate through the results and display or process them
                    while (reader.Read())
                    {
                        int loginId = reader.GetInt32("login_id");
                        int password = reader.GetInt32("login_pw");

                        if (textBox1.Text == (Convert.ToString(loginId)) && (textBox2.Text == Convert.ToString(password)))
                        {
                            girisbasarili = true;
                            manager = true;
                        }

                    }

                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            else if (employee)
            {
                MySqlConnection connection = GetConnection();
                try
                {
                    connection.Open();

                    string query = "SELECT personel_id FROM personel;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int personelId = reader.GetInt32("personel_id");

                        if (textBox1.Text == Convert.ToString(personelId))
                        {
                            girisbasarili = true;
                            employee = true;
                        }

                    }

                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (girisbasarili)
            {
                kullanici_id = Convert.ToInt32(textBox1.Text);
                MySqlConnection connection = GetConnection();
                try
                {
                    connection.Open();
                    string query = "SELECT personel_store FROM personel WHERE personel_id =" + kullanici_id;
                    MySqlCommand command = new MySqlCommand(query, connection);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        kullanicistore = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Personel store not found for the given personel id.");
                    }
                    connection.Close();

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                panel2.BringToFront();
                gorunum();
                girisbasarili = false;
                string kullanici_magaza = Convert.ToString(comboBox1.Text);
                this.Text = kullanici_magaza + " - " + Convert.ToString(kullanici_id);



            }
            else { MessageBox.Show("Giriş bilgileri eksik veya yanlış."); }
        }

        //Show or Hide Password
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { checkBox1.Checked = false; }
            else { checkBox1.Checked = true; }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pictureBox1.Image = Properties.Resources.showpw;
                textBox2.PasswordChar = '\0';
            }
            else
            {
                pictureBox1.Image = Properties.Resources.hidepw;
                textBox2.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStoresIntoComboBox();
            panel1.BringToFront();
        }

        //Refresh Button
        private void button4_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        //Load data into Table method
        private void LoadDataIntoDataGridView()
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open(); // Open the connection to the database
                    string query = $@"SELECT p.*, i.inventory_amount 
                              FROM products p 
                              LEFT JOIN inventory i ON p.product_id = i.inventory_product
                              WHERE i.inventory_store = {comboBox1.SelectedValue}";
                    MySqlCommand cmd = new MySqlCommand(query, con); // Create a command object with the query and connection
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd); // Data adapter to manage data retrieval
                    DataTable dt = new DataTable(); // Create a DataTable to hold the data
                    da.Fill(dt); // Fill the DataTable with data returned by the query

                    dataGridView1.DataSource = dt; // Set the DataGridView's data source to the DataTable
                    dataGridView1.Columns["product_id"].HeaderText = "Product ID";
                    dataGridView1.Columns["product_name"].HeaderText = "Product Name";
                    dataGridView1.Columns["product_type"].HeaderText = "Product Type";
                    dataGridView1.Columns["product_size"].HeaderText = "Product Size";
                    dataGridView1.Columns["product_variant"].HeaderText = "Product Variant";
                    dataGridView1.Columns["product_price"].HeaderText = "Product Price";
                    dataGridView1.Columns["inventory_amount"].HeaderText = "Inventory Amount";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); // Show an error message if something goes wrong
                }
            }
        }

        //Load stores into ComboBox method
        private void LoadStoresIntoComboBox()
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string query = "SELECT store_id, store_name FROM store";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "store_name";
                    comboBox1.ValueMember = "store_id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //Load products ComboBox for sales
        private void LoadProductsIntoComboBox()
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    // Modified query to join products and inventory tables and filter by store ID
                    string query = @"SELECT p.product_id, p.product_name, p.product_price 
                             FROM products p 
                             INNER JOIN inventory i ON p.product_id = i.inventory_product
                             WHERE i.inventory_store = @storeId ";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@storeId", kullanicistore); // Assuming kullanicistore holds the user's store ID

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    productPrices.Clear();  // Clear existing entries
                    foreach (DataRow row in dt.Rows)
                    {
                        int productId = Convert.ToInt32(row["product_id"]);
                        decimal productPrice = Convert.ToDecimal(row["product_price"]);

                        // Add product id and price to the dictionary
                        productPrices[productId] = productPrice;
                    }

                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "product_id";
                    comboBox2.ValueMember = "product_name";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //Load personel info into table for manager to view
        private void LoadPersonelIntoDataGridView()
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open(); // Open the connection to the database
                    string query = "SELECT *  FROM personel WHERE personel_store = @kullanicistore";
                    MySqlCommand cmd = new MySqlCommand(query, con); // Create a command object with the query and connection
                    cmd.Parameters.AddWithValue("@kullanicistore", kullanicistore); // Assuming kullanicistore holds the user's store ID
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd); // Data adapter to manage data retrieval
                    DataTable dt = new DataTable(); // Create a DataTable to hold the data
                    da.Fill(dt); // Fill the DataTable with data returned by the query

                    dataGridView2.DataSource = dt; // Set the DataGridView's data source to the DataTable
                    dataGridView2.Columns["personel_id"].HeaderText = "Personel ID";
                    dataGridView2.Columns["personel_name"].HeaderText = "Name";
                    dataGridView2.Columns["personel_contact"].HeaderText = "Contact";
                    dataGridView2.Columns["personel_store"].HeaderText = "Store";
                    dataGridView2.Columns["personel_job"].HeaderText = "Job";
                    dataGridView2.Columns["personel_prim_goal"].HeaderText = "Prim Goal";
                    dataGridView2.Columns["personel_prim_current"].HeaderText = "Prim Current";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); // Show an error message if something goes wrong
                }
            }
        }

        //Load customer info into table for manager to view
        private void LoadCustomersIntoDataGridView()
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open(); // Open the connection to the database
                    string query = "SELECT *  FROM customers";
                    MySqlCommand cmd = new MySqlCommand(query, con); // Create a command object with the query and connection
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd); // Data adapter to manage data retrieval
                    DataTable dt = new DataTable(); // Create a DataTable to hold the data
                    da.Fill(dt); // Fill the DataTable with data returned by the query

                    dataGridView3.DataSource = dt; // Set the DataGridView's data source to the DataTable
                    dataGridView3.Columns["customer_phone"].HeaderText = "Customer Phone";
                    dataGridView3.Columns["customer_name"].HeaderText = "Name";
                    dataGridView3.Columns["customer_score"].HeaderText = "Score";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); // Show an error message if something goes wrong
                }
            }
        }

        //Update product and inventory info on database
        private void UpdateProductAndInventory(int productId, string newName, string newType, string newSize, string newVariant, decimal newPrice, int newAmount, int storeId)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                MySqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Update product information
                    string updateProductQuery = "UPDATE products SET product_name = @NewName, product_type = @NewType, product_size = @NewSize, product_variant = @NewVariant, product_price = @NewPrice WHERE product_id = @ProductId";
                    MySqlCommand updateProductCmd = new MySqlCommand(updateProductQuery, con, transaction);
                    updateProductCmd.Parameters.AddWithValue("@NewName", newName);
                    updateProductCmd.Parameters.AddWithValue("@NewType", newType);
                    updateProductCmd.Parameters.AddWithValue("@NewSize", newSize);
                    updateProductCmd.Parameters.AddWithValue("@NewVariant", newVariant);
                    updateProductCmd.Parameters.AddWithValue("@NewPrice", newPrice);
                    updateProductCmd.Parameters.AddWithValue("@ProductId", productId);
                    updateProductCmd.ExecuteNonQuery();

                    // Check if the product exists in the inventory
                    string checkInventoryQuery = "SELECT COUNT(*) FROM inventory WHERE inventory_product = @ProductId AND inventory_store = @StoreId";
                    MySqlCommand checkInventoryCmd = new MySqlCommand(checkInventoryQuery, con, transaction);
                    checkInventoryCmd.Parameters.AddWithValue("@ProductId", productId);
                    checkInventoryCmd.Parameters.AddWithValue("@StoreId", storeId);
                    int inventoryCount = Convert.ToInt32(checkInventoryCmd.ExecuteScalar());

                    if (inventoryCount > 0)
                    {
                        // If the product exists in the inventory, update its amount
                        string updateInventoryQuery = "UPDATE inventory SET inventory_amount = @NewAmount WHERE inventory_product = @ProductId AND inventory_store = @StoreId";
                        MySqlCommand updateInventoryCmd = new MySqlCommand(updateInventoryQuery, con, transaction);
                        updateInventoryCmd.Parameters.AddWithValue("@NewAmount", newAmount);
                        updateInventoryCmd.Parameters.AddWithValue("@ProductId", productId);
                        updateInventoryCmd.Parameters.AddWithValue("@StoreId", storeId);
                        updateInventoryCmd.ExecuteNonQuery();
                    }
                    // Commit transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error updating product and inventory: " + ex.Message);
                }
            }
        }

        //Add new product to database
        private void AddNewProduct(int newId, string newName, string newType, string newSize, string newVariant, decimal newPrice, int newAmount, int storeId)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    // Insert product information
                    string insertProductQuery = "INSERT INTO products (product_id, product_name, product_type, product_size, product_variant, product_price) VALUES (@NewId,@NewName, @NewType, @NewSize, @NewVariant, @NewPrice)";
                    MySqlCommand insertProductCmd = new MySqlCommand(insertProductQuery, con);
                    insertProductCmd.Parameters.AddWithValue("@NewId", newId);
                    insertProductCmd.Parameters.AddWithValue("@NewName", newName);
                    insertProductCmd.Parameters.AddWithValue("@NewType", newType);
                    insertProductCmd.Parameters.AddWithValue("@NewSize", newSize);
                    insertProductCmd.Parameters.AddWithValue("@NewVariant", newVariant);
                    insertProductCmd.Parameters.AddWithValue("@NewPrice", newPrice);
                    insertProductCmd.ExecuteNonQuery();

                    // Insert inventory information
                    int inventoryId = int.Parse($"{storeId:D2}{newId:D4}"); // Construct the inventory ID //inventory id ekle 2
                    InsertIntoInventory(inventoryId, newId, newAmount, storeId);

                    MessageBox.Show("New product and inventory added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding new product and inventory: " + ex.Message);
                }
            }
        }

        //Add new inventory of an existing product
        private void InsertIntoInventory(int inventoryId, int productId, int amount, int storeId)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    // Insert inventory information
                    string insertInventoryQuery = "INSERT INTO inventory (inventory_id, inventory_product, inventory_amount, inventory_store) VALUES (@InventoryId, @ProductId, @Amount, @StoreId)";
                    MySqlCommand insertInventoryCmd = new MySqlCommand(insertInventoryQuery, con);
                    insertInventoryCmd.Parameters.AddWithValue("@InventoryId", inventoryId);
                    insertInventoryCmd.Parameters.AddWithValue("@ProductId", productId);
                    insertInventoryCmd.Parameters.AddWithValue("@Amount", amount);
                    insertInventoryCmd.Parameters.AddWithValue("@StoreId", storeId);
                    insertInventoryCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding new inventory: " + ex.Message);
                }
            }
        }

        //Delete item from inventory
        private void DeleteFromInventory(int inventoryId)
        {
            string query = "DELETE FROM inventory WHERE inventory_id = @InventoryId";

            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@InventoryId", inventoryId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Row deleted from inventory.");
                    }
                    else
                    {
                        MessageBox.Show("No rows deleted from inventory.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting row from inventory: " + ex.Message);
                }
            }
        }

        //After Sale update the personel prim
        private void updatePersonelPrim(int personel_id, decimal amount)
        {
            string query = "UPDATE personel SET personel_prim_current = personel_prim_current + (@amount*0.1) WHERE personel_id = @personel_id";

            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);

                    // Execute the command to update the personel_prim_current
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("Personel prim updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No rows updated. Personel not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating personel prim: " + ex.Message);
                }
            }
        }

        //After Sale update the store prim
        private void updateStorePrim(int store_id, decimal amount)
        {
            String query = "UPDATE store SET store_prim_current = store_prim_current + @amount WHERE store_id = @store_id";

            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@store_id", store_id);

                    // Execute the command to update the personel_prim_current
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("Store prim updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No rows updated. Store not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating personel prim: " + ex.Message);
                }
            }
        }

        //Check inventory to see if the product is available
        private bool checkInventory(int productId, int amount, int storeId)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    // Check if there is enough inventory for the sale
                    string checkInventoryQuery = "SELECT inventory_amount FROM inventory WHERE inventory_product = @ProductId AND inventory_store = @StoreId";
                    MySqlCommand checkInventoryCmd = new MySqlCommand(checkInventoryQuery, con);
                    checkInventoryCmd.Parameters.AddWithValue("@ProductId", productId);
                    checkInventoryCmd.Parameters.AddWithValue("@StoreId", storeId);
                    int availableAmount = Convert.ToInt32(checkInventoryCmd.ExecuteScalar());

                    return availableAmount >= amount; // Return true if enough inventory is available, otherwise false
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking inventory: " + ex.Message);
                    return false;
                }
            }
        }

        //Sell the product from inventory
        private void sellFromInventory(int productId, int amount, int storeId)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    // Reduce the amount of products in the inventory
                    string updateInventoryQuery = "UPDATE inventory SET inventory_amount = inventory_amount - @Amount WHERE inventory_product = @ProductId AND inventory_store = @StoreId";
                    MySqlCommand updateInventoryCmd = new MySqlCommand(updateInventoryQuery, con);
                    updateInventoryCmd.Parameters.AddWithValue("@Amount", amount);
                    updateInventoryCmd.Parameters.AddWithValue("@ProductId", productId);
                    updateInventoryCmd.Parameters.AddWithValue("@StoreId", storeId);
                    int rowsAffected = updateInventoryCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("Sale completed successfully. Inventory updated.");
                    }
                    else
                    {
                        MessageBox.Show("Sale failed. Inventory not updated.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selling from inventory: " + ex.Message);
                }
            }
        }

        //Check if customer is on database
        private void checkCustomer(string customer_phone)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    string checkCustomerQuery = "SELECT COUNT(*) FROM customers WHERE customer_phone = @CustomerPhone";
                    MySqlCommand checkCustomerCmd = new MySqlCommand(checkCustomerQuery, con);
                    checkCustomerCmd.Parameters.AddWithValue("@CustomerPhone", customer_phone);
                    int customerCount = Convert.ToInt32(checkCustomerCmd.ExecuteScalar());

                    if (customerCount > 0)
                    {
                        customerMevcut = true;

                        // Retrieve customer score from the database
                        string getCustomerScoreQuery = "SELECT customer_score FROM customers WHERE customer_phone = @CustomerPhone";
                        MySqlCommand getCustomerScoreCmd = new MySqlCommand(getCustomerScoreQuery, con);
                        getCustomerScoreCmd.Parameters.AddWithValue("@CustomerPhone", customer_phone);
                        object customerScore = getCustomerScoreCmd.ExecuteScalar();

                        if (customerScore != null)
                        {
                            label11.Text = customerScore.ToString();
                        }
                    }
                    else
                    {
                        // Customer doesn't exist, trigger addCustomer method
                        customerMevcut = false;
                        //addCustomer(textBox3.Text, customer_phone); // Pass the customer name from textBox3
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking customer: " + ex.Message);
                }
            }
        }

        //Add new customer to database
        private void addCustomer(string customer_name, string customer_phone)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    string addCustomerQuery = "INSERT INTO customers (customer_name, customer_phone, customer_score) VALUES (@CustomerName, @CustomerPhone, 0)";
                    MySqlCommand addCustomerCmd = new MySqlCommand(addCustomerQuery, con);
                    addCustomerCmd.Parameters.AddWithValue("@CustomerName", customer_name);
                    addCustomerCmd.Parameters.AddWithValue("@CustomerPhone", customer_phone);
                    int rowsAffected = addCustomerCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("New customer added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new customer.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding customer: " + ex.Message);
                }
            }
        }

        //After sale, update the customer score
        private void updateCustomerScore(string customer_phone, decimal score_price)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    // Get the current customer score
                    string getScoreQuery = "SELECT customer_score FROM customers WHERE customer_phone = @CustomerPhone";
                    MySqlCommand getScoreCmd = new MySqlCommand(getScoreQuery, con);
                    getScoreCmd.Parameters.AddWithValue("@CustomerPhone", customer_phone);
                    object result = getScoreCmd.ExecuteScalar();

                    if (result != null)
                    {
                        // Calculate the new score
                        decimal currentScore = Convert.ToDecimal(result);
                        decimal newScore = currentScore + (score_price * 0.05m);

                        // Update the customer's score
                        string updateScoreQuery = "UPDATE customers SET customer_score = @NewScore WHERE customer_phone = @CustomerPhone";
                        MySqlCommand updateScoreCmd = new MySqlCommand(updateScoreQuery, con);
                        updateScoreCmd.Parameters.AddWithValue("@NewScore", newScore);
                        updateScoreCmd.Parameters.AddWithValue("@CustomerPhone", customer_phone);
                        int rowsAffected = updateScoreCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("Customer score updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update customer score.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating customer score: " + ex.Message);
                }
            }
        }

        //Get customer's name from DB
        private string GetCustomerName(string customer_phone)
        {
            string customerName = string.Empty;

            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string query = "SELECT customer_name FROM customers WHERE customer_phone = @phone";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@phone", customer_phone);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        customerName = Convert.ToString(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving customer name: " + ex.Message);
                }
            }

            return customerName;
        }

        //Get Store's prim info from DB
        private void GetStorePrimInfo()
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string query = "SELECT store_prim_goal, store_prim_current FROM store WHERE store_id = @StoreId";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StoreId", kullanicistore); // Assuming kullanicistore holds the user's store ID
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        storePrimGoal = reader.GetDecimal("store_prim_goal");
                        storePrimCurrent = reader.GetDecimal("store_prim_current");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving store primary information: " + ex.Message);
                }
            }
        }

        //Add a new receipt into DB
        private void AddReceipt(string customerPhone, decimal price)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    // Assuming receipt_id is auto-incremented, so it doesn't need to be provided

                    // Insert new row into the receipt table
                    string insertQuery = "INSERT INTO receipt (receipt_customer, receipt_price) VALUES (@CustomerPhone, @Price)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                    cmd.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("Receipt added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add receipt.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding receipt: " + ex.Message);
                }
            }
        }

        //Update button for inventory
        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Skip the new row at the end of the DataGridView
                {
                    int productId = Convert.ToInt32(row.Cells["product_id"].Value);

                    if (ProductExists(productId))
                    {
                        // If the product exists, update its information in the database
                        string newName = Convert.ToString(row.Cells["product_name"].Value);
                        string newType = Convert.ToString(row.Cells["product_type"].Value);
                        string newSize = Convert.ToString(row.Cells["product_size"].Value);
                        string newVariant = Convert.ToString(row.Cells["product_variant"].Value);
                        decimal newPrice = Convert.ToDecimal(row.Cells["product_price"].Value);
                        int newAmount = Convert.ToInt32(row.Cells["inventory_amount"].Value);
                        int storeId = Convert.ToInt32(comboBox1.SelectedValue);

                        UpdateProductAndInventory(productId, newName, newType, newSize, newVariant, newPrice, newAmount, storeId);

                        int inventoryId = int.Parse($"{storeId:D2}{productId:D4}");
                        if (!InventoryExists(inventoryId))
                        {
                            InsertIntoInventory(inventoryId, productId, newAmount, storeId);

                        }
                    }
                    else
                    {
                        // If the product doesn't exist, add it to the database
                        int newId = Convert.ToInt32(row.Cells["product_id"].Value);
                        string newName = Convert.ToString(row.Cells["product_name"].Value);
                        string newType = Convert.ToString(row.Cells["product_type"].Value);
                        string newSize = Convert.ToString(row.Cells["product_size"].Value);
                        string newVariant = Convert.ToString(row.Cells["product_variant"].Value);
                        decimal newPrice = Convert.ToDecimal(row.Cells["product_price"].Value);
                        int newAmount = Convert.ToInt32(row.Cells["inventory_amount"].Value);
                        int storeId = Convert.ToInt32(comboBox1.SelectedValue);

                        AddNewProduct(newId, newName, newType, newSize, newVariant, newPrice, newAmount, storeId);

                        // Construct the inventory ID by combining store ID and product ID
                        int inventoryId = int.Parse($"{storeId:D2}{productId:D4}");
                    }
                }
            }

            // Refresh the DataGridView to reflect any changes made to the database
            LoadDataIntoDataGridView();

            // Show a single success message after all updates are completed
            MessageBox.Show("All updates were successful.");
        }

        //Checks if the product exists in DB
        private bool ProductExists(int productId)
        {
            string query = "SELECT COUNT(*) FROM products WHERE product_id = @ProductId";

            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        //Checks if the inventory entry for the product exists
        private bool InventoryExists(int inventoryId)
        {
            string query = "SELECT COUNT(*) FROM inventory WHERE inventory_id = @InventoryId";

            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@InventoryId", inventoryId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        //Return button on login page
        private void button6_Click(object sender, EventArgs e)
        {
            giris(0);
        }

        //Delete from inventory
        private void button7_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Get the product ID and store ID from the selected row
                int productId = Convert.ToInt32(selectedRow.Cells["product_id"].Value);
                int storeId = Convert.ToInt32(comboBox1.SelectedValue);

                // Calculate the inventory ID
                int inventoryId = int.Parse($"{storeId:D2}{productId:D4}");

                // Call the method to delete from inventory
                DeleteFromInventory(inventoryId);

                LoadDataIntoDataGridView();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }

        }

        //Enable or disable update and delete buttons
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            if (manager && comboBox1.SelectedValue.Equals(kullanicistore))
            {
                button7.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                button7.Enabled = false;
                button5.Enabled = false;
            }
        }

        //Add product to cart
        private void button8_Click(object sender, EventArgs e)
        {
            string productName = comboBox2.SelectedValue.ToString(); // Retrieves the product name
            string productId = comboBox2.GetItemText(comboBox2.SelectedItem); // Retrieves the displayed product ID
            int amount = Convert.ToInt32(numericUpDown1.Value);

            decimal productsPrice = amount * productPrices[Convert.ToInt32(productId)];

            listBox1.Items.Add($"{productId} - {productName} x {amount} = {productsPrice} TL");

            totalPrice = totalPrice + productsPrice;
            label7.Text = Convert.ToString(totalPrice) + " TL";
        }

        //Enter customer phone
        private void comboBox2_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;
            string enteredValue = comboBox.Text;

            // Check if the entered value exists in the ComboBox's items
            bool valueExists = false;
            foreach (DataRowView item in comboBox.Items)
            {
                if (item.Row["product_id"].ToString() == enteredValue || item.Row["product_name"].ToString() == enteredValue)
                {
                    valueExists = true;
                    break;
                }
            }

            // If the entered value doesn't exist in the ComboBox's items, show an error message
            if (!valueExists)
            {
                MessageBox.Show("Please select an item from the list.");
                comboBox.Focus(); // Set focus back to the ComboBox
            }
        }

        //Empty Cart
        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            totalPrice = 0;
            label7.Text = "0 TL";
        }

        //Make Purchase
        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Sepete ürün ekleyin.");
            }
            else
            {
                bool inventoryCheckPassed = true;
                foreach (var item in listBox1.Items)
                {
                    string[] parts = item.ToString().Split(new string[] { " - ", " x ", " = " }, StringSplitOptions.None);
                    int productId = int.Parse(parts[0]);
                    int amount = int.Parse(parts[2]);
                    int storeId = kullanicistore; // Assuming kullanicistore holds the user's store ID

                    if (!checkInventory(productId, amount, storeId))
                    {
                        inventoryCheckPassed = false;
                        break;
                    }
                }

                if (inventoryCheckPassed)
                {
                    foreach (var item in listBox1.Items)
                    {
                        string[] parts = item.ToString().Split(new string[] { " - ", " x ", " = " }, StringSplitOptions.None);
                        int productId = int.Parse(parts[0]);
                        int amount = int.Parse(parts[2]);
                        int storeId = kullanicistore; // Assuming kullanicistore holds the user's store ID

                        sellFromInventory(productId, amount, storeId);

                    }
                    //kullanici_id ve kullanicistore var bunları kullanarak kullanıcıyıa ve store'a prim ekle
                    updatePersonelPrim(kullanici_id, totalPrice);
                    updateStorePrim(kullanicistore, totalPrice);
                    string customer_phone = textBox4.Text;
                    if (!checkBox2.Checked)
                    {
                        updateCustomerScore(customer_phone, totalPrice);
                    }

                    AddReceipt(customer_phone, totalPrice);

                }
                else
                {
                    MessageBox.Show("Not enough inventory for the sale.");
                }

                button10_Click(sender, e);
            }
        }

        //Load products into combobox
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            LoadProductsIntoComboBox();
        }

        //Modify the textbox3 visibility for adding a new customer or showing an existing customer
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                if (textBox4.Text.Length == 11)
                {
                    string customer_phone = textBox4.Text;
                    checkCustomer(customer_phone);
                    if (customerMevcut)
                    {
                        // Customer exists, so make label and checkbox visible
                        label10.Visible = true;
                        label11.Visible = true;
                        checkBox2.Visible = true;

                        string musteri = GetCustomerName(customer_phone);
                        textBox3.Text = musteri;
                        textBox3.Enabled = false;

                    }
                    else if (!customerMevcut)
                    {
                        textBox3.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Geçerli bir telefon numarası giriniz.");
                    textBox4.Focus();
                }
            }
        }

        //Prompt for making sure on adding a new customer
        private void textBox3_Leave(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yeni müşteri girişi için, girdiğiniz bilgilerin doğruluğunu kontrol ediniz."
                , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!customerMevcut)
                {
                    string musteri = textBox3.Text;
                    string customer_phone = textBox4.Text;
                    addCustomer(musteri, customer_phone);
                    textBox3.Enabled = false;
                    // Customer added, so make label and checkbox visible
                    label10.Visible = true;
                    label11.Visible = true;
                    checkBox2.Visible = true;

                    checkCustomer(customer_phone);     
                }
            }
            else
            {
                textBox3.Focus();
            }
        }

        //Use customer score for discount
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            decimal indirim = decimal.Parse(label11.Text);
            if (checkBox2.Checked)
            {
                label12.Visible = true;
                totalPrice = totalPrice - indirim;
                label7.Text = Convert.ToString(totalPrice);
            }
            else if (!checkBox2.Checked)
            {
                label12.Visible = false;
                totalPrice = totalPrice + indirim;
                label7.Text = Convert.ToString(totalPrice);
            }
        }

        //Refresh store view
        private void button11_Click(object sender, EventArgs e)
        {
            LoadCustomersIntoDataGridView();
            LoadPersonelIntoDataGridView();
            GetStorePrimInfo();
            label17.Text = Convert.ToString(storePrimGoal);
            label18.Text = Convert.ToString(storePrimCurrent); 
        }
    }
}