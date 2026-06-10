namespace CartsysControlPanel.Views
{
    partial class FirebirdPortForm
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
            label7 = new Label();
            tbAuxPort = new TextBox();
            label6 = new Label();
            tbPort = new TextBox();
            btnCancel = new Button();
            btnCustom = new Button();
            btnDefault = new Button();
            SuspendLayout();
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(226, 232, 240);
            label7.Location = new Point(176, 9);
            label7.Name = "label7";
            label7.Size = new Size(148, 23);
            label7.TabIndex = 18;
            label7.Text = "Porta Auxiliar";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbAuxPort
            // 
            tbAuxPort.BackColor = Color.FromArgb(30, 42, 56);
            tbAuxPort.BorderStyle = BorderStyle.FixedSingle;
            tbAuxPort.ForeColor = Color.FromArgb(226, 232, 240);
            tbAuxPort.Location = new Point(176, 34);
            tbAuxPort.Name = "tbAuxPort";
            tbAuxPort.PlaceholderText = "Porta Padrão = 3051";
            tbAuxPort.Size = new Size(136, 23);
            tbAuxPort.TabIndex = 17;
            tbAuxPort.KeyPress += tbAuxPort_KeyPress;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(226, 232, 240);
            label6.Location = new Point(12, 9);
            label6.Name = "label6";
            label6.Size = new Size(148, 23);
            label6.TabIndex = 16;
            label6.Text = "Porta de serviço";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbPort
            // 
            tbPort.BackColor = Color.FromArgb(30, 42, 56);
            tbPort.BorderStyle = BorderStyle.FixedSingle;
            tbPort.ForeColor = Color.FromArgb(226, 232, 240);
            tbPort.Location = new Point(12, 34);
            tbPort.Name = "tbPort";
            tbPort.PlaceholderText = "Porta Padrão = 3050";
            tbPort.Size = new Size(136, 23);
            tbPort.TabIndex = 15;
            tbPort.KeyPress += tbPort_KeyPress;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(100, 116, 139);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.FromArgb(226, 232, 240);
            btnCancel.Location = new Point(109, 152);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 38);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCustom
            // 
            btnCustom.BackColor = Color.FromArgb(30, 58, 95);
            btnCustom.FlatAppearance.BorderSize = 0;
            btnCustom.FlatStyle = FlatStyle.Flat;
            btnCustom.ForeColor = Color.FromArgb(226, 232, 240);
            btnCustom.Location = new Point(176, 99);
            btnCustom.Name = "btnCustom";
            btnCustom.Size = new Size(119, 38);
            btnCustom.TabIndex = 20;
            btnCustom.Text = "Usar Portas Personalizadas";
            btnCustom.UseVisualStyleBackColor = false;
            btnCustom.Click += btnCustom_Click;
            // 
            // btnDefault
            // 
            btnDefault.BackColor = Color.FromArgb(20, 83, 45);
            btnDefault.FlatAppearance.BorderSize = 0;
            btnDefault.FlatStyle = FlatStyle.Flat;
            btnDefault.ForeColor = Color.FromArgb(226, 232, 240);
            btnDefault.Location = new Point(40, 99);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new Size(119, 38);
            btnDefault.TabIndex = 21;
            btnDefault.Text = "Usar Portas Padrões (3050 e 3051)";
            btnDefault.UseVisualStyleBackColor = false;
            btnDefault.Click += btnDefault_Click;
            // 
            // FirebirdPortForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(800, 450);
            Controls.Add(btnDefault);
            Controls.Add(btnCustom);
            Controls.Add(btnCancel);
            Controls.Add(label7);
            Controls.Add(tbAuxPort);
            Controls.Add(label6);
            Controls.Add(tbPort);
            ForeColor = Color.FromArgb(226, 232, 240);
            Name = "FirebirdPortForm";
            Text = "FirebirdPortForm";
            Load += FirebirdPortForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private TextBox tbAuxPort;
        private Label label6;
        private TextBox tbPort;
        private Button btnCancel;
        private Button btnCustom;
        private Button btnDefault;
    }
}