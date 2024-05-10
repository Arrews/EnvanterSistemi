namespace EnvanterSistemi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            button6 = new Button();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button7 = new Button();
            button5 = new Button();
            label3 = new Label();
            comboBox1 = new ComboBox();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            tabPage2 = new TabPage();
            label12 = new Label();
            checkBox2 = new CheckBox();
            label11 = new Label();
            label10 = new Label();
            textBox4 = new TextBox();
            label9 = new Label();
            label8 = new Label();
            textBox3 = new TextBox();
            comboBox2 = new ComboBox();
            button10 = new Button();
            button9 = new Button();
            label7 = new Label();
            label6 = new Label();
            listBox1 = new ListBox();
            button8 = new Button();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            tabPage3 = new TabPage();
            groupBox2 = new GroupBox();
            label16 = new Label();
            label14 = new Label();
            label18 = new Label();
            dataGridView3 = new DataGridView();
            label13 = new Label();
            label15 = new Label();
            label17 = new Label();
            dataGridView2 = new DataGridView();
            label19 = new Label();
            button11 = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tabPage3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1193, 507);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(button3);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(325, 247);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Visible = false;
            // 
            // button6
            // 
            button6.Location = new Point(25, 212);
            button6.Name = "button6";
            button6.Size = new Size(160, 29);
            button6.TabIndex = 9;
            button6.Text = "Geri Dön";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(191, 149);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(101, 24);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.hidepw;
            pictureBox1.Location = new Point(191, 123);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 38);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 5;
            label1.Text = "Personel No";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 100);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 6;
            label2.Text = "Yönetici Şifresi";
            label2.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 61);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(160, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(25, 123);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(160, 27);
            textBox2.TabIndex = 3;
            textBox2.Visible = false;
            // 
            // button3
            // 
            button3.Location = new Point(25, 170);
            button3.Name = "button3";
            button3.Size = new Size(160, 29);
            button3.TabIndex = 4;
            button3.Text = "Giriş";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(452, 262);
            button2.Name = "button2";
            button2.Size = new Size(317, 40);
            button2.TabIndex = 1;
            button2.Text = "Yönetici Girişi";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(452, 188);
            button1.Name = "button1";
            button1.Size = new Size(317, 40);
            button1.TabIndex = 0;
            button1.Text = "Personel Girişi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(tabControl1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1193, 507);
            panel2.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1193, 507);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button7);
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1185, 474);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Stok Görüntüle";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(220, 60);
            button7.Name = "button7";
            button7.Size = new Size(208, 29);
            button7.TabIndex = 5;
            button7.Text = "Ürünü Envanterden Kaldır";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(47, 58);
            button5.Name = "button5";
            button5.Size = new Size(160, 29);
            button5.TabIndex = 4;
            button5.Text = "Güncelle";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(890, 20);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 3;
            label3.Text = "Store:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(956, 17);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 2;
            comboBox1.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
            // 
            // button4
            // 
            button4.Location = new Point(47, 16);
            button4.Name = "button4";
            button4.Size = new Size(111, 29);
            button4.TabIndex = 1;
            button4.Text = "Göster/Yenile";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(47, 99);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1060, 282);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(checkBox2);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(button10);
            tabPage2.Controls.Add(button9);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(listBox1);
            tabPage2.Controls.Add(button8);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(numericUpDown1);
            tabPage2.Controls.Add(label4);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1185, 474);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Satış";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Enter += tabPage2_Enter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(612, 99);
            label12.Name = "label12";
            label12.Size = new Size(64, 20);
            label12.TabIndex = 18;
            label12.Text = "İndirimli";
            label12.Visible = false;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(374, 67);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(163, 24);
            checkBox2.TabIndex = 17;
            checkBox2.Text = "İndirim Puanı Kullan";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(534, 37);
            label11.Name = "label11";
            label11.Size = new Size(17, 20);
            label11.TabIndex = 16;
            label11.Text = "0";
            label11.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(374, 37);
            label10.Name = "label10";
            label10.Size = new Size(149, 20);
            label10.TabIndex = 15;
            label10.Text = "Müşteri İndirim Puanı";
            label10.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(161, 22);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "0(5__)_______";
            textBox4.Size = new Size(156, 27);
            textBox4.TabIndex = 14;
            textBox4.Leave += textBox4_Leave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(42, 22);
            label9.Name = "label9";
            label9.Size = new Size(110, 20);
            label9.TabIndex = 13;
            label9.Text = "Müşteri İletişim";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(42, 67);
            label8.Name = "label8";
            label8.Size = new Size(85, 20);
            label8.TabIndex = 12;
            label8.Text = "Müşteri Adı";
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(161, 60);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(156, 27);
            textBox3.TabIndex = 11;
            textBox3.Leave += textBox3_Leave;
            // 
            // comboBox2
            // 
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(115, 135);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 10;
            comboBox2.Leave += comboBox2_Leave;
            // 
            // button10
            // 
            button10.Location = new Point(612, 209);
            button10.Name = "button10";
            button10.Size = new Size(126, 29);
            button10.TabIndex = 9;
            button10.Text = "Sepeti Boşalt";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.Location = new Point(612, 169);
            button9.Name = "button9";
            button9.Size = new Size(126, 29);
            button9.TabIndex = 8;
            button9.Text = "Satışı Tamamla";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(710, 132);
            label7.Name = "label7";
            label7.Size = new Size(17, 20);
            label7.TabIndex = 7;
            label7.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(612, 132);
            label6.Name = "label6";
            label6.Size = new Size(92, 20);
            label6.TabIndex = 6;
            label6.Text = "Sepet Tutarı:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(374, 122);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(173, 124);
            listBox1.TabIndex = 5;
            // 
            // button8
            // 
            button8.Location = new Point(33, 247);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 4;
            button8.Text = "Sepete Ekle";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 201);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 3;
            label5.Text = "Adet";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(115, 199);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(42, 27);
            numericUpDown1.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 138);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 1;
            label4.Text = "Ürün ID";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox2);
            tabPage3.Controls.Add(label19);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1185, 474);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Mağaza Bilgi";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button11);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(dataGridView3);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(dataGridView2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1185, 474);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(26, 74);
            label16.Name = "label16";
            label16.Size = new Size(137, 20);
            label16.TabIndex = 5;
            label16.Text = "Mağaza Anlık Satış:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(798, 127);
            label14.Name = "label14";
            label14.Size = new Size(113, 20);
            label14.TabIndex = 3;
            label14.Text = "Müşteri Bilgileri";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(186, 77);
            label18.Name = "label18";
            label18.Size = new Size(17, 20);
            label18.TabIndex = 7;
            label18.Text = "0";
            // 
            // dataGridView3
            // 
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(798, 165);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.RowTemplate.Height = 29;
            dataGridView3.Size = new Size(379, 188);
            dataGridView3.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(26, 118);
            label13.Name = "label13";
            label13.Size = new Size(119, 20);
            label13.TabIndex = 2;
            label13.Text = "Personel Bilgileri";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(26, 39);
            label15.Name = "label15";
            label15.Size = new Size(145, 20);
            label15.TabIndex = 4;
            label15.Text = "Mağaza Hedef Satış:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(186, 39);
            label17.Name = "label17";
            label17.Size = new Size(17, 20);
            label17.TabIndex = 6;
            label17.Text = "0";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(26, 165);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(739, 188);
            dataGridView2.TabIndex = 0;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(508, 216);
            label19.Name = "label19";
            label19.Size = new Size(265, 20);
            label19.TabIndex = 9;
            label19.Text = "Sadece Yöneticiler Bu sayfaya Erişebilir";
            // 
            // button11
            // 
            button11.Location = new Point(798, 26);
            button11.Name = "button11";
            button11.Size = new Size(127, 29);
            button11.TabIndex = 8;
            button11.Text = "Bilgileri Yenile";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1193, 507);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(200, 50);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button2;
        private Button button1;
        private Label label2;
        private Label label1;
        private Button button3;
        private TextBox textBox2;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private Button button4;
        private Label label3;
        private ComboBox comboBox1;
        private Button button5;
        private Button button6;
        private TabPage tabPage3;
        private Button button7;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private ComboBox comboBox2;
        private Button button10;
        private Button button9;
        private Label label7;
        private Label label6;
        private ListBox listBox1;
        private Button button8;
        private TextBox textBox4;
        private Label label9;
        private Label label8;
        private TextBox textBox3;
        private Label label11;
        private Label label10;
        private CheckBox checkBox2;
        private Label label12;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private DataGridView dataGridView3;
        private DataGridView dataGridView2;
        private Label label18;
        private Label label17;
        private GroupBox groupBox2;
        private Label label19;
        private Button button11;
    }
}