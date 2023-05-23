using System.Drawing.Drawing2D;

namespace GUI
{
    partial class customer
    {
        private Button button1;
        private Button button2;
        private Button button3;

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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightCoral;
            this.button3.Location = new System.Drawing.Point(210, 177);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 40);
            this.button3.TabIndex = 5;
            this.button3.Text = "Back";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGreen;
            this.button2.Location = new System.Drawing.Point(210, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 40);
            this.button2.TabIndex = 4;
            this.button2.Text = "Sign Up";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageKey = "(none)";
            this.button1.Location = new System.Drawing.Point(210, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Login";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.UseVisualStyleBackColor = false;
            // 
            // customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 331);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "customer";
            this.Text = "Customer";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.customer_Paint);
            this.ResumeLayout(false);

        }

        private void customer_Paint(object sender, PaintEventArgs e)
        {
            // Create a linear gradient brush
            System.Drawing.Drawing2D.LinearGradientBrush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                System.Drawing.Color.LightSkyBlue,   // Starting color
                System.Drawing.Color.LightPink,      // Ending color
                System.Drawing.Drawing2D.LinearGradientMode.Vertical);

            // Fill the background with the gradient brush
            e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
        }

        private void OnFormPaint(object sender, PaintEventArgs e)
        {
            DrawGradientBackground(e.Graphics);
        }

        private void DrawGradientBackground(Graphics g)
        {
            Color color1 = Color.LightSkyBlue;
            Color color2 = Color.LightCyan;
            Rectangle rect = this.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rect);
            }
        }

        #endregion
    }
}
