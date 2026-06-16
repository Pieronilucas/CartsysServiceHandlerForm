namespace CartsysControlPanel.Views
{
    partial class HqbirdCalculatorForm
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
            btnCalculate = new Button();
            btnApply = new Button();
            btnDbpath = new Button();
            tbDbPath = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            tbIndisponibilidade = new TextBox();
            tbNotaFiscal = new TextBox();
            tbCartorio = new TextBox();
            tbArquivos = new TextBox();
            tbAuditoria = new TextBox();
            tbRamDisponivel = new TextBox();
            tbSafeLimit = new TextBox();
            tbErroCaminhoBancos = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            tbSizeCartorio = new TextBox();
            tbSizeIndisponibilidade = new TextBox();
            tbSizeAuditoria = new TextBox();
            tbSizeArquivos = new TextBox();
            tbSizeNotaFiscal = new TextBox();
            cbCartorio = new ComboBox();
            label14 = new Label();
            cbNotaFiscal = new ComboBox();
            cbAuditoria = new ComboBox();
            cbArquivos = new ComboBox();
            cbIndisponibilidade = new ComboBox();
            SuspendLayout();
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.FromArgb(100, 116, 139);
            btnCalculate.FlatAppearance.BorderSize = 0;
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Location = new Point(43, 595);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(165, 33);
            btnCalculate.TabIndex = 0;
            btnCalculate.Text = "Calcular Paginação";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnApply
            // 
            btnApply.BackColor = Color.FromArgb(100, 116, 139);
            btnApply.FlatAppearance.BorderSize = 0;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.Location = new Point(274, 595);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(165, 33);
            btnApply.TabIndex = 1;
            btnApply.Text = "Aplicar Paginação";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // btnDbpath
            // 
            btnDbpath.BackColor = Color.FromArgb(30, 42, 56);
            btnDbpath.BackgroundImageLayout = ImageLayout.None;
            btnDbpath.FlatAppearance.BorderSize = 0;
            btnDbpath.FlatStyle = FlatStyle.Flat;
            btnDbpath.ForeColor = Color.FromArgb(226, 232, 240);
            btnDbpath.Location = new Point(411, 102);
            btnDbpath.Name = "btnDbpath";
            btnDbpath.Size = new Size(28, 23);
            btnDbpath.TabIndex = 7;
            btnDbpath.Text = "...";
            btnDbpath.UseVisualStyleBackColor = false;
            btnDbpath.Click += btnDbpath_Click;
            // 
            // tbDbPath
            // 
            tbDbPath.BackColor = Color.FromArgb(30, 42, 56);
            tbDbPath.BorderStyle = BorderStyle.FixedSingle;
            tbDbPath.ForeColor = Color.FromArgb(226, 232, 240);
            tbDbPath.Location = new Point(43, 102);
            tbDbPath.Name = "tbDbPath";
            tbDbPath.PlaceholderText = "Caminho bancos FDB";
            tbDbPath.ReadOnly = true;
            tbDbPath.Size = new Size(378, 23);
            tbDbPath.TabIndex = 6;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(226, 232, 240);
            label1.Location = new Point(43, 76);
            label1.Name = "label1";
            label1.Size = new Size(247, 23);
            label1.TabIndex = 8;
            label1.Text = "Selecione o caminho dos bancos";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(43, 24);
            label2.Name = "label2";
            label2.Size = new Size(242, 30);
            label2.TabIndex = 9;
            label2.Text = "CALCULADORA HQBIRD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 452);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 10;
            label3.Text = "RAM Disponível:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 481);
            label4.Name = "label4";
            label4.Size = new Size(116, 15);
            label4.TabIndex = 11;
            label4.Text = "Limite Seguro (25%):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(43, 161);
            label5.Name = "label5";
            label5.Size = new Size(112, 25);
            label5.TabIndex = 12;
            label5.Text = "RESULTADO";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 343);
            label6.Name = "label6";
            label6.Size = new Size(137, 15);
            label6.TabIndex = 14;
            label6.Text = "INDISPONIBILIDADE.FDB";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(43, 314);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 13;
            label7.Text = "AUDITORIA.FDB";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(43, 285);
            label8.Name = "label8";
            label8.Size = new Size(88, 15);
            label8.TabIndex = 16;
            label8.Text = "ARQUIVOS.FDB";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(44, 256);
            label9.Name = "label9";
            label9.Size = new Size(87, 15);
            label9.TabIndex = 15;
            label9.Text = "CARTORIO.FDB";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(43, 372);
            label10.Name = "label10";
            label10.Size = new Size(90, 15);
            label10.TabIndex = 17;
            label10.Text = "NOTAFISCALDB";
            // 
            // tbIndisponibilidade
            // 
            tbIndisponibilidade.BackColor = Color.FromArgb(30, 42, 56);
            tbIndisponibilidade.BorderStyle = BorderStyle.FixedSingle;
            tbIndisponibilidade.ForeColor = Color.FromArgb(226, 232, 240);
            tbIndisponibilidade.Location = new Point(187, 341);
            tbIndisponibilidade.Name = "tbIndisponibilidade";
            tbIndisponibilidade.ReadOnly = true;
            tbIndisponibilidade.Size = new Size(171, 23);
            tbIndisponibilidade.TabIndex = 18;
            // 
            // tbNotaFiscal
            // 
            tbNotaFiscal.BackColor = Color.FromArgb(30, 42, 56);
            tbNotaFiscal.BorderStyle = BorderStyle.FixedSingle;
            tbNotaFiscal.ForeColor = Color.FromArgb(226, 232, 240);
            tbNotaFiscal.Location = new Point(187, 370);
            tbNotaFiscal.Name = "tbNotaFiscal";
            tbNotaFiscal.ReadOnly = true;
            tbNotaFiscal.Size = new Size(171, 23);
            tbNotaFiscal.TabIndex = 19;
            // 
            // tbCartorio
            // 
            tbCartorio.BackColor = Color.FromArgb(30, 42, 56);
            tbCartorio.BorderStyle = BorderStyle.FixedSingle;
            tbCartorio.ForeColor = Color.FromArgb(226, 232, 240);
            tbCartorio.Location = new Point(187, 254);
            tbCartorio.Name = "tbCartorio";
            tbCartorio.ReadOnly = true;
            tbCartorio.Size = new Size(171, 23);
            tbCartorio.TabIndex = 20;
            // 
            // tbArquivos
            // 
            tbArquivos.BackColor = Color.FromArgb(30, 42, 56);
            tbArquivos.BorderStyle = BorderStyle.FixedSingle;
            tbArquivos.ForeColor = Color.FromArgb(226, 232, 240);
            tbArquivos.Location = new Point(187, 283);
            tbArquivos.Name = "tbArquivos";
            tbArquivos.ReadOnly = true;
            tbArquivos.Size = new Size(171, 23);
            tbArquivos.TabIndex = 21;
            // 
            // tbAuditoria
            // 
            tbAuditoria.BackColor = Color.FromArgb(30, 42, 56);
            tbAuditoria.BorderStyle = BorderStyle.FixedSingle;
            tbAuditoria.ForeColor = Color.FromArgb(226, 232, 240);
            tbAuditoria.Location = new Point(187, 312);
            tbAuditoria.Name = "tbAuditoria";
            tbAuditoria.ReadOnly = true;
            tbAuditoria.Size = new Size(171, 23);
            tbAuditoria.TabIndex = 22;
            // 
            // tbRamDisponivel
            // 
            tbRamDisponivel.BackColor = Color.FromArgb(30, 42, 56);
            tbRamDisponivel.BorderStyle = BorderStyle.FixedSingle;
            tbRamDisponivel.ForeColor = Color.FromArgb(226, 232, 240);
            tbRamDisponivel.Location = new Point(186, 450);
            tbRamDisponivel.Name = "tbRamDisponivel";
            tbRamDisponivel.ReadOnly = true;
            tbRamDisponivel.Size = new Size(172, 23);
            tbRamDisponivel.TabIndex = 23;
            // 
            // tbSafeLimit
            // 
            tbSafeLimit.BackColor = Color.FromArgb(30, 42, 56);
            tbSafeLimit.BorderStyle = BorderStyle.FixedSingle;
            tbSafeLimit.ForeColor = Color.FromArgb(226, 232, 240);
            tbSafeLimit.Location = new Point(186, 479);
            tbSafeLimit.Name = "tbSafeLimit";
            tbSafeLimit.ReadOnly = true;
            tbSafeLimit.Size = new Size(172, 23);
            tbSafeLimit.TabIndex = 24;
            // 
            // tbErroCaminhoBancos
            // 
            tbErroCaminhoBancos.BackColor = Color.FromArgb(17, 24, 39);
            tbErroCaminhoBancos.BorderStyle = BorderStyle.None;
            tbErroCaminhoBancos.ForeColor = Color.FromArgb(248, 113, 113);
            tbErroCaminhoBancos.Location = new Point(43, 131);
            tbErroCaminhoBancos.Name = "tbErroCaminhoBancos";
            tbErroCaminhoBancos.Size = new Size(396, 16);
            tbErroCaminhoBancos.TabIndex = 25;
            tbErroCaminhoBancos.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(44, 215);
            label11.Name = "label11";
            label11.Size = new Size(52, 21);
            label11.TabIndex = 26;
            label11.Text = "Banco";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(382, 215);
            label12.Name = "label12";
            label12.Size = new Size(73, 21);
            label12.TabIndex = 27;
            label12.Text = "Tamanho";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(187, 215);
            label13.Name = "label13";
            label13.Size = new Size(106, 21);
            label13.TabIndex = 28;
            label13.Text = "Default Cache";
            // 
            // tbSizeCartorio
            // 
            tbSizeCartorio.BackColor = Color.FromArgb(30, 42, 56);
            tbSizeCartorio.BorderStyle = BorderStyle.FixedSingle;
            tbSizeCartorio.ForeColor = Color.FromArgb(226, 232, 240);
            tbSizeCartorio.Location = new Point(382, 253);
            tbSizeCartorio.Name = "tbSizeCartorio";
            tbSizeCartorio.ReadOnly = true;
            tbSizeCartorio.Size = new Size(91, 23);
            tbSizeCartorio.TabIndex = 29;
            // 
            // tbSizeIndisponibilidade
            // 
            tbSizeIndisponibilidade.BackColor = Color.FromArgb(30, 42, 56);
            tbSizeIndisponibilidade.BorderStyle = BorderStyle.FixedSingle;
            tbSizeIndisponibilidade.ForeColor = Color.FromArgb(226, 232, 240);
            tbSizeIndisponibilidade.Location = new Point(382, 340);
            tbSizeIndisponibilidade.Name = "tbSizeIndisponibilidade";
            tbSizeIndisponibilidade.ReadOnly = true;
            tbSizeIndisponibilidade.Size = new Size(91, 23);
            tbSizeIndisponibilidade.TabIndex = 30;
            // 
            // tbSizeAuditoria
            // 
            tbSizeAuditoria.BackColor = Color.FromArgb(30, 42, 56);
            tbSizeAuditoria.BorderStyle = BorderStyle.FixedSingle;
            tbSizeAuditoria.ForeColor = Color.FromArgb(226, 232, 240);
            tbSizeAuditoria.Location = new Point(382, 311);
            tbSizeAuditoria.Name = "tbSizeAuditoria";
            tbSizeAuditoria.ReadOnly = true;
            tbSizeAuditoria.Size = new Size(91, 23);
            tbSizeAuditoria.TabIndex = 31;
            // 
            // tbSizeArquivos
            // 
            tbSizeArquivos.BackColor = Color.FromArgb(30, 42, 56);
            tbSizeArquivos.BorderStyle = BorderStyle.FixedSingle;
            tbSizeArquivos.ForeColor = Color.FromArgb(226, 232, 240);
            tbSizeArquivos.Location = new Point(382, 282);
            tbSizeArquivos.Name = "tbSizeArquivos";
            tbSizeArquivos.ReadOnly = true;
            tbSizeArquivos.Size = new Size(91, 23);
            tbSizeArquivos.TabIndex = 32;
            // 
            // tbSizeNotaFiscal
            // 
            tbSizeNotaFiscal.BackColor = Color.FromArgb(30, 42, 56);
            tbSizeNotaFiscal.BorderStyle = BorderStyle.FixedSingle;
            tbSizeNotaFiscal.ForeColor = Color.FromArgb(226, 232, 240);
            tbSizeNotaFiscal.Location = new Point(382, 369);
            tbSizeNotaFiscal.Name = "tbSizeNotaFiscal";
            tbSizeNotaFiscal.ReadOnly = true;
            tbSizeNotaFiscal.Size = new Size(91, 23);
            tbSizeNotaFiscal.TabIndex = 33;
            // 
            // cbCartorio
            // 
            cbCartorio.BackColor = Color.FromArgb(30, 42, 56);
            cbCartorio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCartorio.FlatStyle = FlatStyle.Flat;
            cbCartorio.ForeColor = Color.FromArgb(226, 232, 240);
            cbCartorio.FormattingEnabled = true;
            cbCartorio.Location = new Point(488, 253);
            cbCartorio.Name = "cbCartorio";
            cbCartorio.Size = new Size(96, 23);
            cbCartorio.TabIndex = 34;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(488, 215);
            label14.Name = "label14";
            label14.Size = new Size(80, 21);
            label14.TabIndex = 35;
            label14.Text = "Paginação";
            // 
            // cbNotaFiscal
            // 
            cbNotaFiscal.BackColor = Color.FromArgb(30, 42, 56);
            cbNotaFiscal.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNotaFiscal.FlatStyle = FlatStyle.Flat;
            cbNotaFiscal.ForeColor = Color.FromArgb(226, 232, 240);
            cbNotaFiscal.FormattingEnabled = true;
            cbNotaFiscal.Location = new Point(488, 370);
            cbNotaFiscal.Name = "cbNotaFiscal";
            cbNotaFiscal.Size = new Size(96, 23);
            cbNotaFiscal.TabIndex = 36;
            // 
            // cbAuditoria
            // 
            cbAuditoria.BackColor = Color.FromArgb(30, 42, 56);
            cbAuditoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAuditoria.FlatStyle = FlatStyle.Flat;
            cbAuditoria.ForeColor = Color.FromArgb(226, 232, 240);
            cbAuditoria.FormattingEnabled = true;
            cbAuditoria.Location = new Point(488, 312);
            cbAuditoria.Name = "cbAuditoria";
            cbAuditoria.Size = new Size(96, 23);
            cbAuditoria.TabIndex = 37;
            // 
            // cbArquivos
            // 
            cbArquivos.BackColor = Color.FromArgb(30, 42, 56);
            cbArquivos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbArquivos.FlatStyle = FlatStyle.Flat;
            cbArquivos.ForeColor = Color.FromArgb(226, 232, 240);
            cbArquivos.FormattingEnabled = true;
            cbArquivos.Location = new Point(488, 283);
            cbArquivos.Name = "cbArquivos";
            cbArquivos.Size = new Size(96, 23);
            cbArquivos.TabIndex = 38;
            // 
            // cbIndisponibilidade
            // 
            cbIndisponibilidade.BackColor = Color.FromArgb(30, 42, 56);
            cbIndisponibilidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIndisponibilidade.FlatStyle = FlatStyle.Flat;
            cbIndisponibilidade.ForeColor = Color.FromArgb(226, 232, 240);
            cbIndisponibilidade.FormattingEnabled = true;
            cbIndisponibilidade.Location = new Point(488, 341);
            cbIndisponibilidade.Name = "cbIndisponibilidade";
            cbIndisponibilidade.Size = new Size(96, 23);
            cbIndisponibilidade.TabIndex = 36;
            // 
            // HqbirdCalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(1264, 681);
            Controls.Add(cbArquivos);
            Controls.Add(cbAuditoria);
            Controls.Add(cbIndisponibilidade);
            Controls.Add(cbNotaFiscal);
            Controls.Add(label14);
            Controls.Add(cbCartorio);
            Controls.Add(tbSizeNotaFiscal);
            Controls.Add(tbSizeArquivos);
            Controls.Add(tbSizeAuditoria);
            Controls.Add(tbSizeIndisponibilidade);
            Controls.Add(tbSizeCartorio);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(tbErroCaminhoBancos);
            Controls.Add(tbSafeLimit);
            Controls.Add(tbRamDisponivel);
            Controls.Add(tbAuditoria);
            Controls.Add(tbArquivos);
            Controls.Add(tbCartorio);
            Controls.Add(tbNotaFiscal);
            Controls.Add(tbIndisponibilidade);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnDbpath);
            Controls.Add(tbDbPath);
            Controls.Add(label1);
            Controls.Add(btnApply);
            Controls.Add(btnCalculate);
            ForeColor = Color.FromArgb(226, 232, 240);
            Name = "HqbirdCalculatorForm";
            Text = "HqbirdCalculatorForm";
            Load += HqbirdCalculatorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalculate;
        private Button btnApply;
        private Button btnDbpath;
        private TextBox tbDbPath;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox tbIndisponibilidade;
        private TextBox tbNotaFiscal;
        private TextBox tbCartorio;
        private TextBox tbArquivos;
        private TextBox tbAuditoria;
        private TextBox tbRamDisponivel;
        private TextBox tbSafeLimit;
        private TextBox tbErroCaminhoBancos;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox tbSizeCartorio;
        private TextBox tbSizeIndisponibilidade;
        private TextBox tbSizeAuditoria;
        private TextBox tbSizeArquivos;
        private TextBox tbSizeNotaFiscal;
        private ComboBox comboBox1;
        private Label label14;
        public ComboBox cbNotaFiscal;
        public ComboBox cbAuditoria;
        public ComboBox cbArquivos;
        public ComboBox cbIndisponibilidade;
        public ComboBox cbCartorio;
    }
}