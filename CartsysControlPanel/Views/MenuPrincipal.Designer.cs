namespace CartsysControlPanel.Views
{
    partial class MenuPrincipal
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
            tbSerialHd = new TextBox();
            lbSerialHd = new Label();
            tbServer = new TextBox();
            tbHqbirdInstalled = new TextBox();
            tbServicesInstalled = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // tbSerialHd
            // 
            tbSerialHd.BackColor = Color.FromArgb(30, 42, 56);
            tbSerialHd.BorderStyle = BorderStyle.FixedSingle;
            tbSerialHd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSerialHd.ForeColor = Color.FromArgb(226, 232, 240);
            tbSerialHd.Location = new Point(25, 42);
            tbSerialHd.Multiline = true;
            tbSerialHd.Name = "tbSerialHd";
            tbSerialHd.ReadOnly = true;
            tbSerialHd.Size = new Size(102, 26);
            tbSerialHd.TabIndex = 0;
            tbSerialHd.TextAlign = HorizontalAlignment.Center;
            tbSerialHd.TextChanged += tbSerialHd_TextChanged;
            // 
            // lbSerialHd
            // 
            lbSerialHd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbSerialHd.Location = new Point(25, 19);
            lbSerialHd.Name = "lbSerialHd";
            lbSerialHd.Size = new Size(102, 23);
            lbSerialHd.TabIndex = 1;
            lbSerialHd.Text = "SERIAL HD";
            lbSerialHd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbServer
            // 
            tbServer.BackColor = Color.FromArgb(30, 42, 56);
            tbServer.BorderStyle = BorderStyle.FixedSingle;
            tbServer.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbServer.ForeColor = Color.FromArgb(226, 232, 240);
            tbServer.Location = new Point(25, 151);
            tbServer.Multiline = true;
            tbServer.Name = "tbServer";
            tbServer.ReadOnly = true;
            tbServer.Size = new Size(102, 26);
            tbServer.TabIndex = 3;
            tbServer.TextAlign = HorizontalAlignment.Center;
            tbServer.TextChanged += tbServer_TextChanged;
            // 
            // tbHqbirdInstalled
            // 
            tbHqbirdInstalled.BackColor = Color.FromArgb(30, 42, 56);
            tbHqbirdInstalled.BorderStyle = BorderStyle.FixedSingle;
            tbHqbirdInstalled.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbHqbirdInstalled.ForeColor = Color.FromArgb(226, 232, 240);
            tbHqbirdInstalled.Location = new Point(25, 256);
            tbHqbirdInstalled.Multiline = true;
            tbHqbirdInstalled.Name = "tbHqbirdInstalled";
            tbHqbirdInstalled.ReadOnly = true;
            tbHqbirdInstalled.Size = new Size(102, 26);
            tbHqbirdInstalled.TabIndex = 4;
            tbHqbirdInstalled.TextAlign = HorizontalAlignment.Center;
            // 
            // tbServicesInstalled
            // 
            tbServicesInstalled.BackColor = Color.FromArgb(30, 42, 56);
            tbServicesInstalled.BorderStyle = BorderStyle.FixedSingle;
            tbServicesInstalled.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbServicesInstalled.ForeColor = Color.FromArgb(226, 232, 240);
            tbServicesInstalled.Location = new Point(25, 360);
            tbServicesInstalled.Multiline = true;
            tbServicesInstalled.Name = "tbServicesInstalled";
            tbServicesInstalled.ReadOnly = true;
            tbServicesInstalled.Size = new Size(102, 26);
            tbServicesInstalled.TabIndex = 5;
            tbServicesInstalled.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 125);
            label1.Name = "label1";
            label1.Size = new Size(110, 23);
            label1.TabIndex = 6;
            label1.Text = "HOSTNAME/IP";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 230);
            label2.Name = "label2";
            label2.Size = new Size(191, 23);
            label2.TabIndex = 7;
            label2.Text = "HQBIRD ESTÁ INSTALADO?";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 334);
            label3.Name = "label3";
            label3.Size = new Size(234, 23);
            label3.TabIndex = 8;
            label3.Text = "SERVIÇOS CARTSYS INSTALADOS";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(1264, 681);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbServicesInstalled);
            Controls.Add(tbHqbirdInstalled);
            Controls.Add(tbServer);
            Controls.Add(lbSerialHd);
            Controls.Add(tbSerialHd);
            ForeColor = Color.FromArgb(226, 232, 240);
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuPrincipal";
            Load += MenuPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbSerialHd;
        private Label label1;
        private Label lbSerialHd;
        private TextBox tbServer;
        private TextBox tbHqbirdInstalled;
        private TextBox tbServicesInstalled;
        private Label label2;
        private Label label3;
    }
}