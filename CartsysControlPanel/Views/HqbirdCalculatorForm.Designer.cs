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
            label6.Location = new Point(42, 291);
            label6.Name = "label6";
            label6.Size = new Size(137, 15);
            label6.TabIndex = 14;
            label6.Text = "INDISPONIBILIDADE.FDB";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(42, 262);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 13;
            label7.Text = "AUDITORIA.FDB";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(42, 233);
            label8.Name = "label8";
            label8.Size = new Size(88, 15);
            label8.TabIndex = 16;
            label8.Text = "ARQUIVOS.FDB";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(43, 204);
            label9.Name = "label9";
            label9.Size = new Size(87, 15);
            label9.TabIndex = 15;
            label9.Text = "CARTORIO.FDB";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(42, 320);
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
            tbIndisponibilidade.Location = new Point(186, 289);
            tbIndisponibilidade.Name = "tbIndisponibilidade";
            tbIndisponibilidade.ReadOnly = true;
            tbIndisponibilidade.Size = new Size(253, 23);
            tbIndisponibilidade.TabIndex = 18;
            // 
            // tbNotaFiscal
            // 
            tbNotaFiscal.BackColor = Color.FromArgb(30, 42, 56);
            tbNotaFiscal.BorderStyle = BorderStyle.FixedSingle;
            tbNotaFiscal.ForeColor = Color.FromArgb(226, 232, 240);
            tbNotaFiscal.Location = new Point(186, 318);
            tbNotaFiscal.Name = "tbNotaFiscal";
            tbNotaFiscal.ReadOnly = true;
            tbNotaFiscal.Size = new Size(253, 23);
            tbNotaFiscal.TabIndex = 19;
            // 
            // tbCartorio
            // 
            tbCartorio.BackColor = Color.FromArgb(30, 42, 56);
            tbCartorio.BorderStyle = BorderStyle.FixedSingle;
            tbCartorio.ForeColor = Color.FromArgb(226, 232, 240);
            tbCartorio.Location = new Point(186, 202);
            tbCartorio.Name = "tbCartorio";
            tbCartorio.ReadOnly = true;
            tbCartorio.Size = new Size(253, 23);
            tbCartorio.TabIndex = 20;
            // 
            // tbArquivos
            // 
            tbArquivos.BackColor = Color.FromArgb(30, 42, 56);
            tbArquivos.BorderStyle = BorderStyle.FixedSingle;
            tbArquivos.ForeColor = Color.FromArgb(226, 232, 240);
            tbArquivos.Location = new Point(186, 231);
            tbArquivos.Name = "tbArquivos";
            tbArquivos.ReadOnly = true;
            tbArquivos.Size = new Size(253, 23);
            tbArquivos.TabIndex = 21;
            // 
            // tbAuditoria
            // 
            tbAuditoria.BackColor = Color.FromArgb(30, 42, 56);
            tbAuditoria.BorderStyle = BorderStyle.FixedSingle;
            tbAuditoria.ForeColor = Color.FromArgb(226, 232, 240);
            tbAuditoria.Location = new Point(186, 260);
            tbAuditoria.Name = "tbAuditoria";
            tbAuditoria.ReadOnly = true;
            tbAuditoria.Size = new Size(253, 23);
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
            tbRamDisponivel.Size = new Size(253, 23);
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
            tbSafeLimit.Size = new Size(253, 23);
            tbSafeLimit.TabIndex = 24;
            // 
            // HqbirdCalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(1264, 681);
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
    }
}