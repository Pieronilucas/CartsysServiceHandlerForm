namespace CartsysControlPanel.Views
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pictureBox1 = new PictureBox();
            tbPassword = new TextBox();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.cartsysLogo;
            pictureBox1.Location = new Point(300, 89);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.FromArgb(30, 42, 56);
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.ForeColor = Color.FromArgb(226, 232, 240);
            tbPassword.Location = new Point(300, 323);
            tbPassword.MaxLength = 15;
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(200, 23);
            tbPassword.TabIndex = 1;
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.TextChanged += tbPassword_TextChanged;
            tbPassword.KeyPress += tbPassword_KeyPress;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(226, 232, 240);
            label1.Location = new Point(300, 292);
            label1.Name = "label1";
            label1.Size = new Size(200, 23);
            label1.TabIndex = 2;
            label1.Text = "SENHA DE ACESSO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(100, 116, 139);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(226, 232, 240);
            button1.Location = new Point(300, 354);
            button1.Name = "button1";
            button1.Size = new Size(200, 37);
            button1.TabIndex = 3;
            button1.Text = "ENTRAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(784, 561);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(tbPassword);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1280, 600);
            MinimizeBox = false;
            MinimumSize = new Size(800, 600);
            Name = "LoginForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Suporte Cartsys";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox tbPassword;
        private Label label1;
        private Button button1;
    }
}