
namespace thalbhet
{
    partial class addminitform
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
            this.Nimit = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addnimitbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Nimit
            // 
            this.Nimit.AutoSize = true;
            this.Nimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nimit.Location = new System.Drawing.Point(126, 38);
            this.Nimit.Name = "Nimit";
            this.Nimit.Size = new System.Drawing.Size(52, 24);
            this.Nimit.TabIndex = 0;
            this.Nimit.Text = "Nimit";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(184, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 29);
            this.textBox1.TabIndex = 1;
            // 
            // addnimitbutton
            // 
            this.addnimitbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnimitbutton.Location = new System.Drawing.Point(512, 35);
            this.addnimitbutton.Name = "addnimitbutton";
            this.addnimitbutton.Size = new System.Drawing.Size(75, 29);
            this.addnimitbutton.TabIndex = 2;
            this.addnimitbutton.Text = "add";
            this.addnimitbutton.UseVisualStyleBackColor = true;
            // 
            // addminitform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 89);
            this.Controls.Add(this.addnimitbutton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Nimit);
            this.Name = "addminitform";
            this.Text = "Add Nimit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel Nimit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addnimitbutton;
    }
}