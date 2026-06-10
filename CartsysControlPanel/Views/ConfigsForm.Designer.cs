namespace CartsysControlPanel.Views
{
    partial class ConfigsForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnCreateRegistry = new Button();
            btnFbdCartorio = new Button();
            btnFbdDb = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnFirewall = new Button();
            tbPort = new TextBox();
            label6 = new Label();
            label7 = new Label();
            tbAuxPort = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(30, 42, 56);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.ForeColor = Color.FromArgb(226, 232, 240);
            textBox1.Location = new Point(12, 146);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Caminho pasta cartório";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(378, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(30, 42, 56);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.ForeColor = Color.FromArgb(226, 232, 240);
            textBox2.Location = new Point(12, 214);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Caminho banco de dados";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(378, 23);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // btnCreateRegistry
            // 
            btnCreateRegistry.BackColor = Color.FromArgb(100, 116, 139);
            btnCreateRegistry.FlatAppearance.BorderSize = 0;
            btnCreateRegistry.FlatStyle = FlatStyle.Flat;
            btnCreateRegistry.ForeColor = Color.FromArgb(226, 232, 240);
            btnCreateRegistry.Location = new Point(12, 267);
            btnCreateRegistry.Name = "btnCreateRegistry";
            btnCreateRegistry.Size = new Size(119, 38);
            btnCreateRegistry.TabIndex = 2;
            btnCreateRegistry.Text = "Criar registro";
            btnCreateRegistry.UseVisualStyleBackColor = false;
            btnCreateRegistry.Click += btnCreateRegistry_Click;
            // 
            // btnFbdCartorio
            // 
            btnFbdCartorio.BackColor = Color.FromArgb(30, 42, 56);
            btnFbdCartorio.BackgroundImageLayout = ImageLayout.None;
            btnFbdCartorio.FlatAppearance.BorderSize = 0;
            btnFbdCartorio.FlatStyle = FlatStyle.Flat;
            btnFbdCartorio.ForeColor = Color.FromArgb(226, 232, 240);
            btnFbdCartorio.Location = new Point(380, 146);
            btnFbdCartorio.Name = "btnFbdCartorio";
            btnFbdCartorio.Size = new Size(28, 23);
            btnFbdCartorio.TabIndex = 3;
            btnFbdCartorio.Text = "...";
            btnFbdCartorio.UseVisualStyleBackColor = false;
            btnFbdCartorio.Click += btnFbdCartorio_Click;
            // 
            // btnFbdDb
            // 
            btnFbdDb.BackColor = Color.FromArgb(30, 42, 56);
            btnFbdDb.FlatAppearance.BorderSize = 0;
            btnFbdDb.FlatStyle = FlatStyle.Flat;
            btnFbdDb.ForeColor = Color.FromArgb(226, 232, 240);
            btnFbdDb.Location = new Point(380, 214);
            btnFbdDb.Name = "btnFbdDb";
            btnFbdDb.Size = new Size(28, 23);
            btnFbdDb.TabIndex = 4;
            btnFbdDb.Text = "...";
            btnFbdDb.UseVisualStyleBackColor = false;
            btnFbdDb.Click += btnFbdDb_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(226, 232, 240);
            label1.Location = new Point(12, 120);
            label1.Name = "label1";
            label1.Size = new Size(247, 23);
            label1.TabIndex = 5;
            label1.Text = "Selecione o caminho da pasta cartório";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(226, 232, 240);
            label2.Location = new Point(12, 188);
            label2.Name = "label2";
            label2.Size = new Size(272, 23);
            label2.TabIndex = 6;
            label2.Text = "Selecione o caminho do banco cartorio.fdb";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(226, 232, 240);
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(336, 25);
            label3.TabIndex = 7;
            label3.Text = "CONFIGURAÇÕES GERAIS DO SISTEMA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(226, 232, 240);
            label4.Location = new Point(12, 87);
            label4.Name = "label4";
            label4.Size = new Size(153, 20);
            label4.TabIndex = 8;
            label4.Text = "EDITOR DE REGISTRO";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(226, 232, 240);
            label5.Location = new Point(12, 340);
            label5.Name = "label5";
            label5.Size = new Size(136, 20);
            label5.TabIndex = 9;
            label5.Text = "AJUSTES FIREWALL";
            // 
            // btnFirewall
            // 
            btnFirewall.BackColor = Color.FromArgb(100, 116, 139);
            btnFirewall.FlatAppearance.BorderSize = 0;
            btnFirewall.FlatStyle = FlatStyle.Flat;
            btnFirewall.ForeColor = Color.FromArgb(226, 232, 240);
            btnFirewall.Location = new Point(12, 494);
            btnFirewall.Name = "btnFirewall";
            btnFirewall.Size = new Size(119, 38);
            btnFirewall.TabIndex = 10;
            btnFirewall.Text = "Liberar portas";
            btnFirewall.UseVisualStyleBackColor = false;
            btnFirewall.Click += btnFirewall_Click_1;
            // 
            // tbPort
            // 
            tbPort.BackColor = Color.FromArgb(30, 42, 56);
            tbPort.BorderStyle = BorderStyle.FixedSingle;
            tbPort.ForeColor = Color.FromArgb(226, 232, 240);
            tbPort.Location = new Point(12, 396);
            tbPort.Name = "tbPort";
            tbPort.PlaceholderText = "Porta Padrão = 3050";
            tbPort.Size = new Size(136, 23);
            tbPort.TabIndex = 11;
            tbPort.KeyPress += tbPort_KeyPress;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(226, 232, 240);
            label6.Location = new Point(12, 371);
            label6.Name = "label6";
            label6.Size = new Size(148, 23);
            label6.TabIndex = 12;
            label6.Text = "Porta de serviço";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(226, 232, 240);
            label7.Location = new Point(12, 422);
            label7.Name = "label7";
            label7.Size = new Size(148, 23);
            label7.TabIndex = 14;
            label7.Text = "Porta Auxiliar";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbAuxPort
            // 
            tbAuxPort.BackColor = Color.FromArgb(30, 42, 56);
            tbAuxPort.BorderStyle = BorderStyle.FixedSingle;
            tbAuxPort.ForeColor = Color.FromArgb(226, 232, 240);
            tbAuxPort.Location = new Point(12, 447);
            tbAuxPort.Name = "tbAuxPort";
            tbAuxPort.PlaceholderText = "Porta Padrão = 3051";
            tbAuxPort.Size = new Size(136, 23);
            tbAuxPort.TabIndex = 13;
            tbAuxPort.KeyPress += tbAuxPort_KeyPress;
            // 
            // ConfigsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(991, 626);
            Controls.Add(label7);
            Controls.Add(tbAuxPort);
            Controls.Add(label6);
            Controls.Add(tbPort);
            Controls.Add(btnFbdCartorio);
            Controls.Add(textBox1);
            Controls.Add(btnFirewall);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnFbdDb);
            Controls.Add(btnCreateRegistry);
            Controls.Add(textBox2);
            Name = "ConfigsForm";
            Text = "RegeditForm";
            Load += ConfigsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnCreateRegistry;
        private Button btnFbdCartorio;
        private Button btnFbdDb;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnFirewall;
        private TextBox tbPort;
        private Label label6;
        private Label label7;
        private TextBox tbAuxPort;
    }
}