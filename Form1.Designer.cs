namespace AALab_2
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            listBox1 = new ListBox();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 182);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 256);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(205, 12);
            button1.Name = "button1";
            button1.Size = new Size(107, 29);
            button1.TabIndex = 1;
            button1.Text = "Генерувати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(187, 164);
            listBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "граф";
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "граф", "орграф", "зважений граф", "зважений орграф" });
            comboBox1.Location = new Point(205, 113);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 28);
            comboBox1.TabIndex = 3;
            comboBox1.ValueMember = "орграф";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(205, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(107, 27);
            textBox1.TabIndex = 4;
            textBox1.Text = "5";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(205, 80);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(107, 27);
            textBox2.TabIndex = 5;
            textBox2.Text = "0,5";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private ListBox listBox1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
