namespace CartsysControlPanel.Views
{
    partial class RegeditForm
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
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(30, 42, 56);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.ForeColor = Color.FromArgb(226, 232, 240);
            textBox1.Location = new Point(21, 67);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Caminho pasta cartório";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(315, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(30, 42, 56);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.ForeColor = Color.FromArgb(226, 232, 240);
            textBox2.Location = new Point(21, 144);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Caminho banco de dados";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(315, 23);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // btnCreateRegistry
            // 
            btnCreateRegistry.BackColor = Color.FromArgb(100, 116, 139);
            btnCreateRegistry.FlatAppearance.BorderSize = 0;
            btnCreateRegistry.FlatStyle = FlatStyle.Flat;
            btnCreateRegistry.ForeColor = Color.FromArgb(226, 232, 240);
            btnCreateRegistry.Location = new Point(21, 197);
            btnCreateRegistry.Name = "btnCreateRegistry";
            btnCreateRegistry.Size = new Size(115, 23);
            btnCreateRegistry.TabIndex = 2;
            btnCreateRegistry.Text = "Criar registro";
            btnCreateRegistry.UseVisualStyleBackColor = false;
            btnCreateRegistry.Click += button1_Click;
            // 
            // btnFbdCartorio
            // 
            btnFbdCartorio.BackColor = Color.FromArgb(30, 42, 56);
            btnFbdCartorio.BackgroundImageLayout = ImageLayout.None;
            btnFbdCartorio.FlatAppearance.BorderSize = 0;
            btnFbdCartorio.FlatStyle = FlatStyle.Flat;
            btnFbdCartorio.ForeColor = Color.FromArgb(226, 232, 240);
            btnFbdCartorio.Location = new Point(332, 67);
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
            btnFbdDb.Location = new Point(332, 144);
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
            label1.Location = new Point(21, 41);
            label1.Name = "label1";
            label1.Size = new Size(247, 23);
            label1.TabIndex = 5;
            label1.Text = "Selecione o caminho da pasta cartório";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(226, 232, 240);
            label2.Location = new Point(21, 118);
            label2.Name = "label2";
            label2.Size = new Size(272, 23);
            label2.TabIndex = 6;
            label2.Text = "Selecione o caminho do banco cartorio.fdb";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RegeditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnFbdDb);
            Controls.Add(btnFbdCartorio);
            Controls.Add(btnCreateRegistry);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "RegeditForm";
            Text = "RegeditForm";
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
    }
}