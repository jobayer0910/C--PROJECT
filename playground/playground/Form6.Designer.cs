namespace playground
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            button5 = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 105);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(766, 190);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(308, 9);
            label1.Name = "label1";
            label1.Size = new Size(208, 28);
            label1.TabIndex = 1;
            label1.Text = "USER INFORMATION";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.WindowFrame;
            button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(660, 381);
            button2.Name = "button2";
            button2.Size = new Size(118, 47);
            button2.TabIndex = 6;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 192, 255);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(346, 318);
            button1.Name = "button1";
            button1.Size = new Size(94, 57);
            button1.TabIndex = 8;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(192, 192, 255);
            button5.ForeColor = Color.Red;
            button5.Location = new Point(684, 70);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 13;
            button5.Text = "Search";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(72, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(579, 27);
            textBox1.TabIndex = 14;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(button5);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form6";
            Text = "Form6";
            Load += Form6_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button2;
        private Button button1;
        private Button button5;
        private TextBox textBox1;
    }
}