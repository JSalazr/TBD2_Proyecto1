namespace WindowsFormsApp1
{
    partial class Form2
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
            this.textconn = new System.Windows.Forms.TextBox();
            this.textserver = new System.Windows.Forms.TextBox();
            this.textdb = new System.Windows.Forms.TextBox();
            this.textport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textuser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textpass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textconn
            // 
            this.textconn.Location = new System.Drawing.Point(42, 55);
            this.textconn.Name = "textconn";
            this.textconn.Size = new System.Drawing.Size(192, 20);
            this.textconn.TabIndex = 0;
            // 
            // textserver
            // 
            this.textserver.Location = new System.Drawing.Point(42, 109);
            this.textserver.Name = "textserver";
            this.textserver.Size = new System.Drawing.Size(192, 20);
            this.textserver.TabIndex = 1;
            // 
            // textdb
            // 
            this.textdb.Location = new System.Drawing.Point(299, 55);
            this.textdb.Name = "textdb";
            this.textdb.Size = new System.Drawing.Size(192, 20);
            this.textdb.TabIndex = 2;
            // 
            // textport
            // 
            this.textport.Location = new System.Drawing.Point(299, 109);
            this.textport.Name = "textport";
            this.textport.Size = new System.Drawing.Size(192, 20);
            this.textport.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connection Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "User";
            // 
            // textuser
            // 
            this.textuser.Location = new System.Drawing.Point(42, 160);
            this.textuser.Name = "textuser";
            this.textuser.Size = new System.Drawing.Size(192, 20);
            this.textuser.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password";
            // 
            // textpass
            // 
            this.textpass.Location = new System.Drawing.Point(299, 160);
            this.textpass.Name = "textpass";
            this.textpass.Size = new System.Drawing.Size(192, 20);
            this.textpass.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Test Connection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(299, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textpass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textuser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textport);
            this.Controls.Add(this.textdb);
            this.Controls.Add(this.textserver);
            this.Controls.Add(this.textconn);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textconn;
        private System.Windows.Forms.TextBox textserver;
        private System.Windows.Forms.TextBox textdb;
        private System.Windows.Forms.TextBox textport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textuser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textpass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}