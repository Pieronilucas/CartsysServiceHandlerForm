namespace CartsysControlPanel.Views
{
    public partial class LoginForm : Form
    {
        private string _password = DateTime.Now.ToString("yyyyMMddHH");
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidatePassword();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                ValidatePassword();

            }
        }

        private void ValidatePassword()
        {
            if (tbPassword.Text == _password)
            {
                MenuSelecaoForm menuSelecaoForm = new MenuSelecaoForm();
                menuSelecaoForm.FormClosed += (s, args) => this.Close();
                menuSelecaoForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Senha incorreta. Tente novamente.");
                tbPassword.Clear();
                tbPassword.Focus();
            }

        }
    }
}
