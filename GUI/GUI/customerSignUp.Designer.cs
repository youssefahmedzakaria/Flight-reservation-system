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
            button2 = new Button();
            button1 = new Button();
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
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.ForeColor = Color.Red;
            button2.Location = new Point(320, 395);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(98, 40);
            button2.TabIndex = 55;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Green;
            button1.ForeColor = Color.Green;
            button1.Location = new Point(169, 395);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(101, 40);
            button1.TabIndex = 54;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(363, 192);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(114, 27);
            textBox7.TabIndex = 52;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(22, 265);
            label8.Name = "label8";
            label8.Size = new Size(90, 20);
            label8.TabIndex = 50;
            label8.Text = "Day Of Birth";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(246, 203);
            label7.Name = "label7";
            label7.Size = new Size(36, 20);
            label7.TabIndex = 49;
            label7.Text = "Age";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(125, 192);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(114, 27);
            textBox6.TabIndex = 48;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(22, 203);
            label6.Name = "label6";
            label6.Size = new Size(57, 20);
            label6.TabIndex = 47;
            label6.Text = "Gender";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(363, 143);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(114, 27);
            textBox5.TabIndex = 46;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(246, 153);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 45;
            label5.Text = "Phone Number";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(125, 149);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(114, 27);
            textBox4.TabIndex = 44;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(22, 149);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 43;
            label4.Text = "E-mail";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(363, 75);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(114, 27);
            textBox2.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(246, 85);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 39;
            label2.Text = "Last Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(125, 75);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(114, 27);
            textBox1.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(22, 85);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 37;
            label1.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(483, 85);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 41;
            label3.Text = "User Name";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(565, 75);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(114, 27);
            textBox3.TabIndex = 42;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(533, 265);
            textBox9.Margin = new Padding(3, 4, 3, 4);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(177, 27);
            textBox9.TabIndex = 57;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Location = new Point(396, 268);
            label9.Name = "label9";
            label9.Size = new Size(122, 20);
            label9.TabIndex = 56;
            label9.Text = "Passport Number";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(125, 265);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 58;
            // 
            // customerSignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox9);
            Controls.Add(label9);
            Controls.Add(button2);
            Controls.Add(button1);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "customerSignUp";
            Text = "customerSignUp";
            Paint += adminLogin_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
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

        private DateTimePicker dateTimePicker1;
    }
}