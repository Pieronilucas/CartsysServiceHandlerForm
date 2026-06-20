namespace CartsysControlPanel.Views
{
    partial class CredentialForm
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
            btnContinue = new Button();
            btnCancel = new Button();
            tbUser = new TextBox();
            tbPassword = new TextBox();
            label6 = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnContinue
            // 
            btnContinue.BackColor = Color.FromArgb(30, 58, 95);
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.ForeColor = Color.FromArgb(226, 232, 240);
            btnContinue.Location = new Point(26, 187);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(119, 38);
            btnContinue.TabIndex = 22;
            btnContinue.Text = "Continuar";
            btnContinue.UseVisualStyleBackColor = false;
            btnContinue.Click += btnContinue_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(100, 116, 139);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.FromArgb(226, 232, 240);
            btnCancel.Location = new Point(26, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 38);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbUser
            // 
            tbUser.BackColor = Color.FromArgb(30, 42, 56);
            tbUser.BorderStyle = BorderStyle.FixedSingle;
            tbUser.ForeColor = Color.FromArgb(226, 232, 240);
            tbUser.Location = new Point(26, 84);
            tbUser.Name = "tbUser";
            tbUser.Size = new Size(136, 23);
            tbUser.TabIndex = 23;
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.FromArgb(30, 42, 56);
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.ForeColor = Color.FromArgb(226, 232, 240);
            tbPassword.Location = new Point(26, 136);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(136, 23);
            tbPassword.TabIndex = 24;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(226, 232, 240);
            label6.Location = new Point(26, 58);
            label6.Name = "label6";
            label6.Size = new Size(148, 23);
            label6.TabIndex = 25;
            label6.Text = "Usuário ";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(226, 232, 240);
            label1.Location = new Point(26, 110);
            label1.Name = "label1";
            label1.Size = new Size(148, 23);
            label1.TabIndex = 26;
            label1.Text = "Senha";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 15);
            label2.Name = "label2";
            label2.Size = new Size(305, 30);
            label2.TabIndex = 29;
            label2.Text = "Credenciais de acesso - Firebird";
            // 
            // CredentialForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(464, 311);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(tbPassword);
            Controls.Add(tbUser);
            Controls.Add(btnContinue);
            Controls.Add(btnCancel);
            ForeColor = Color.FromArgb(226, 232, 240);
            KeyPreview = true;
            MaximumSize = new Size(480, 350);
            Name = "CredentialForm";
            Text = "CredentialForm";
            Load += CredentialForm_Load;
            KeyDown += CredentialForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnContinue;
        private Button btnCancel;
        private TextBox tbUser;
        private TextBox tbPassword;
        private Label label6;
        private Label label1;
        private Label label2;
    }
}