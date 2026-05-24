using CartsysControlPanel.Infrastructure.Hardware;
using CartsysControlPanel.Infrastructure.Network;
using CartsysControlPanel.Infrastructure.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CartsysControlPanel.Views
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            tbSerialHd.Text = HardwareHandler.GetHdSerial();
            tbServer.Text = NetworkHandler.ServerName() ?? "Não foi possível determinar";
            tbHqbirdInstalled.Text = ServiceHandler.IsServiceInstalled("FirebirdServerHQBirdInstanceFB3") ? "Sim" : "Não";
            tbServicesInstalled.Text = $"{ServiceHandler.CartsysServicesInstalled().ToString()}/10";
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void tbSerialHd_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbServer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
