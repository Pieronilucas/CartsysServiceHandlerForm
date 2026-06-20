using System.ComponentModel.DataAnnotations;

namespace CartsysControlPanel.Views
{
    public partial class CredentialForm : Form
    {
        public string Username { get; private set; } = "teste";
        public string Password { get; private set; } = "teste";
        public CredentialForm()
        {
            InitializeComponent();
        }

        private void CredentialForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUser.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Por favor, preencha ambos os campos de usuário e senha.", "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Username = tbUser.Text.ToString();
            Password = tbPassword.Text.ToString();
            DialogResult = DialogResult.OK;
            tbPassword.Clear();
            Close();
        }

        private void CredentialForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnContinue_Click(btnContinue, EventArgs.Empty); 
            }
        }
    }
}
