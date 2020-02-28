namespace PRG455_Project
{
    partial class Form3
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
            this.lblheader = new System.Windows.Forms.Label();
            this.lblfname = new System.Windows.Forms.Label();
            this.lbllname = new System.Windows.Forms.Label();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblatime = new System.Windows.Forms.Label();
            this.lbldtime = new System.Windows.Forms.Label();
            this.lblfcity = new System.Windows.Forms.Label();
            this.lbldcity = new System.Windows.Forms.Label();
            this.lblprice = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.lblclass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblheader
            // 
            this.lblheader.AutoSize = true;
            this.lblheader.Location = new System.Drawing.Point(302, 34);
            this.lblheader.Name = "lblheader";
            this.lblheader.Size = new System.Drawing.Size(51, 20);
            this.lblheader.TabIndex = 0;
            this.lblheader.Text = "Ticket";
            // 
            // lblfname
            // 
            this.lblfname.AutoSize = true;
            this.lblfname.Location = new System.Drawing.Point(84, 120);
            this.lblfname.Name = "lblfname";
            this.lblfname.Size = new System.Drawing.Size(90, 20);
            this.lblfname.TabIndex = 2;
            this.lblfname.Text = "First Name:";
            // 
            // lbllname
            // 
            this.lbllname.AutoSize = true;
            this.lbllname.Location = new System.Drawing.Point(84, 158);
            this.lbllname.Name = "lbllname";
            this.lbllname.Size = new System.Drawing.Size(90, 20);
            this.lbllname.TabIndex = 3;
            this.lbllname.Text = "Last Name:";
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(84, 197);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(148, 20);
            this.lblTelephone.TabIndex = 4;
            this.lblTelephone.Text = "Telephone Number:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(84, 235);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(72, 20);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address:";
            // 
            // lblatime
            // 
            this.lblatime.AutoSize = true;
            this.lblatime.Location = new System.Drawing.Point(423, 235);
            this.lblatime.Name = "lblatime";
            this.lblatime.Size = new System.Drawing.Size(90, 20);
            this.lblatime.TabIndex = 11;
            this.lblatime.Text = "Arrival time:";
            // 
            // lbldtime
            // 
            this.lbldtime.AutoSize = true;
            this.lbldtime.Location = new System.Drawing.Point(423, 197);
            this.lbldtime.Name = "lbldtime";
            this.lbldtime.Size = new System.Drawing.Size(119, 20);
            this.lbldtime.TabIndex = 10;
            this.lbldtime.Text = "Departure time:";
            // 
            // lblfcity
            // 
            this.lblfcity.AutoSize = true;
            this.lblfcity.Location = new System.Drawing.Point(423, 158);
            this.lblfcity.Name = "lblfcity";
            this.lblfcity.Size = new System.Drawing.Size(124, 20);
            this.lblfcity.TabIndex = 9;
            this.lblfcity.Text = "Destination City:";
            // 
            // lbldcity
            // 
            this.lbldcity.AutoSize = true;
            this.lbldcity.Location = new System.Drawing.Point(423, 120);
            this.lbldcity.Name = "lbldcity";
            this.lbldcity.Size = new System.Drawing.Size(115, 20);
            this.lbldcity.TabIndex = 8;
            this.lbldcity.Text = "Departure City:";
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Location = new System.Drawing.Point(423, 276);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(48, 20);
            this.lblprice.TabIndex = 12;
            this.lblprice.Text = "Price:";
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Gray;
            this.btnclose.Location = new System.Drawing.Point(512, 359);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(88, 38);
            this.btnclose.TabIndex = 14;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lblclass
            // 
            this.lblclass.AutoSize = true;
            this.lblclass.Location = new System.Drawing.Point(84, 276);
            this.lblclass.Name = "lblclass";
            this.lblclass.Size = new System.Drawing.Size(95, 20);
            this.lblclass.TabIndex = 15;
            this.lblclass.Text = "Flight Class:";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(728, 438);
            this.Controls.Add(this.lblclass);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.lblatime);
            this.Controls.Add(this.lbldtime);
            this.Controls.Add(this.lblfcity);
            this.Controls.Add(this.lbldcity);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblTelephone);
            this.Controls.Add(this.lbllname);
            this.Controls.Add(this.lblfname);
            this.Controls.Add(this.lblheader);
            this.Name = "Form3";
            this.Text = "Receipt";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblheader;
        private System.Windows.Forms.Label lblfname;
        private System.Windows.Forms.Label lbllname;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblatime;
        private System.Windows.Forms.Label lbldtime;
        private System.Windows.Forms.Label lblfcity;
        private System.Windows.Forms.Label lbldcity;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label lblclass;
    }
}