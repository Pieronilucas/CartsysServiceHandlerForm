using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartsysControlPanel.Views
{
    public partial class FirebirdPortForm : Form
    {
        public int ServicePort { get; private set; } = 3050;
        public int AuxPort { get; private set; } = 3051;
        public FirebirdPortForm()
        {
            InitializeComponent();
        }

        private void FirebirdPortForm_Load(object sender, EventArgs e)
        {

        }

        private void tbAuxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            tbAuxPort.MaxLength = 5;
        }

        private void tbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            tbPort.MaxLength = 5;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            ServicePort = (int)ServicePort;
            AuxPort = (int)AuxPort;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbPort.Text, out int servicePort) || servicePort < 1 || servicePort > 65535)
            {
                MessageBox.Show("Por favor, insira um número válido para a porta de serviço.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(tbAuxPort.Text, out int auxPort) || auxPort < 1 || auxPort > 65535)
            {
                var result = MessageBox.Show("Porta auxiliar informada é inválida. Deseja utilizar a porta remota auxiliar padrão? (3051)", "Entrada Inválida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
                AuxPort = 3051;
            }
            if (servicePort == auxPort)
            {
                MessageBox.Show("As portas de serviço e auxiliar não podem ser iguais.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ServicePort = servicePort;
            AuxPort = auxPort;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
