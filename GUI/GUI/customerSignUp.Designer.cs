using System.Drawing.Drawing2D;

namespace GUI
{
    partial class customerSignUp
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
            this.Paint += new PaintEventHandler(adminLogin_Paint);
            button2 = new Button();
            button1 = new Button();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox9 = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(280, 296);
            button2.Name = "button2";
            button2.Size = new Size(86, 30);
            button2.TabIndex = 55;
            button2.Text = "Back";
            button2.BackColor = Color.Red;
            button2.ForeColor = Color.Red;

            this.button2.Click += new System.EventHandler(this.button2_Click);
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(148, 296);
            button1.Name = "button1";
            button1.Size = new Size(88, 30);
            button1.TabIndex = 54;
            button1.Text = "Register";
            button1.BackColor = Color.Green;
            button1.ForeColor = Color.Green;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(109, 191);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 23);
            textBox8.TabIndex = 53;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(318, 144);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 52;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 199);
            label8.Name = "label8";
            label8.Size = new Size(71, 15);
            label8.TabIndex = 50;
            label8.Text = "Day Of Birth";
            label8.BackColor = Color.Transparent;

            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(215, 152);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 49;
            label7.Text = "Age";
            label7.BackColor = Color.Transparent;

            // 
            // textBox6
            // 
            textBox6.Location = new Point(109, 144);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 48;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 152);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 47;
            label6.Text = "Gender";
            label6.BackColor = Color.Transparent;

            // 
            // textBox5
            // 
            textBox5.Location = new Point(318, 107);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 46;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(215, 115);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 45;
            label5.Text = "Phone Number";
            label5.BackColor = Color.Transparent;

            // 
            // textBox4
            // 
            textBox4.Location = new Point(109, 112);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 44;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 112);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 43;
            label4.Text = "E-mail";
            label4.BackColor = Color.Transparent;

            // 
            // textBox2
            // 
            textBox2.Location = new Point(318, 56);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(215, 64);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 39;
            label2.BackColor = Color.Transparent;

            label2.Text = "Last Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(109, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 64);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 37;
            label1.Text = "First Name";
            label1.BackColor = Color.Transparent;

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(423, 64);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 41; 
            label3.BackColor = Color.Transparent;

            label3.Text = "User Name";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(494, 56);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 42;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(318, 196);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(155, 23);
            textBox9.TabIndex = 57;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(213, 199);
            label9.Name = "label9";
            label9.Size = new Size(99, 15);
            label9.TabIndex = 56;
            label9.BackColor = Color.Transparent;

            label9.Text = "Passport Number";
            // 
            // customerSignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox9);
            Controls.Add(label9);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "customerSignUp";
            Text = "customerSignUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private TextBox textBox8;
        private TextBox textBox7;
        private Label label8;
        private Label label7;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox9;
        private Label label9;
        private void adminLogin_Paint(object sender, PaintEventArgs e)
        {
            // Create a linear gradient brush for the background
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCoral, LinearGradientMode.Vertical);

            // Fill the form's background with the gradient brush
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }
    }
}