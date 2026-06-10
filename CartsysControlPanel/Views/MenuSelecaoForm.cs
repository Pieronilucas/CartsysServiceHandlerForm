using CartsysControlPanel.Infrastructure.Network;
using CartsysControlPanel.Infrastructure.System;
using FontAwesome.Sharp;

namespace CartsysControlPanel.Views
{
    public partial class MenuSelecaoForm : Form
    {
        private IconButton _currentBtn;
        private Panel _leftBorderBtn;
        private Form _currentChildForm;
        private bool _isOpenMenu = true;
        private const int _widthClosed = 60;
        private const int _widthOpen = 220;
        private readonly Lazy<ServiceForm> _serviceForm = new Lazy<ServiceForm>(() => new ServiceForm());
        private readonly Lazy<FirebirdHqbirdForm> _firebirdForm = new Lazy<FirebirdHqbirdForm>(() => new FirebirdHqbirdForm());
        private readonly Lazy<HqbirdCalculatorForm> _calculatorForm = new Lazy<HqbirdCalculatorForm>(() => new HqbirdCalculatorForm());
        private readonly Lazy<ConfigsForm> _configForm = new Lazy<ConfigsForm>(() => new ConfigsForm());
        private readonly Lazy<MenuPrincipal> _menuPrincipalForm = new Lazy<MenuPrincipal>(() => new MenuPrincipal());

        public MenuSelecaoForm()
        {
            InitializeComponent();
            _leftBorderBtn = new Panel();
            _leftBorderBtn.Size = new Size(7, 60);
            menuPanel.Controls.Add(_leftBorderBtn);


            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.AutoSize = false;


            UpdateMenu();
            OpenChildForm(new MenuPrincipal());
        }


        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                _currentBtn = (IconButton)senderBtn;
                _currentBtn.BackColor = Color.FromArgb(30, 58, 95);
                _currentBtn.ForeColor = Color.FromArgb(226, 232, 240);
                _currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                _currentBtn.IconColor = Color.FromArgb(99, 179, 237); ;
                _currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                _currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                _leftBorderBtn.BackColor = Color.FromArgb(99, 179, 237);
                _leftBorderBtn.Location = new Point(0, _currentBtn.Location.Y);
                _leftBorderBtn.Visible = true;
                _leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (_currentBtn != null)
            {
                _currentBtn.BackColor = Color.FromArgb(30, 42, 56);
                _currentBtn.ForeColor = Color.FromArgb(226, 232, 240);
                _currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                _currentBtn.IconColor = Color.FromArgb(100, 116, 139);
                _currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                _currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }



        }

        private void OpenChildForm(Form childForm)
        {
            if (_currentChildForm != null)
            {
                _currentChildForm.Hide();
            }
            _currentChildForm = childForm;
            if (!panelDesktop.Controls.Contains(childForm))
            {
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelDesktop.Controls.Add(childForm);
                //panelDesktop.Tag = childForm;
            }
            childForm.Show();
            childForm.BringToFront();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            _currentChildForm?.Hide();
            _currentChildForm = null;
            Reset();
            OpenChildForm(_menuPrincipalForm.Value);
        }

        private void servicesHandlerBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            var form = new ServiceForm();
            form.ProcessingChanged += (s, e) =>
            {
                bool isProcessing = form.IsProcessing;
                servicesHandlerBtn.Enabled = !isProcessing;
                configsHandlerBtn.Enabled = !isProcessing;
                firebirdHqbirdBtn.Enabled = !isProcessing;
                hqBirdCalculatorBtn.Enabled = !isProcessing;
                btnHome.Enabled = !isProcessing;
            };
            OpenChildForm(form);
        }

        private void configsHandlerBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(_configForm.Value);
        }

        private void firebirdHqbirdBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(_firebirdForm.Value);
        }

        private void hqBirdCalculatorBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(_calculatorForm.Value);
        }

        private void btnIcon_Click(object sender, EventArgs e)
        {
            _isOpenMenu = !_isOpenMenu;

            UpdateMenu();
        }

        private void UpdateMenu()
        {
            menuPanel.Width = _isOpenMenu ? _widthOpen : _widthClosed;
            btnIcon.Image = _isOpenMenu ? Properties.Resources.cartsysLogo : Properties.Resources.cartsys;
            btnHome.Text = _isOpenMenu ? "Menu Iniciar" : "";
            servicesHandlerBtn.Text = _isOpenMenu ? "Serviços" : "";
            configsHandlerBtn.Text = _isOpenMenu ? "Configurações" : "";
            firebirdHqbirdBtn.Text = _isOpenMenu ? "Firebird/HQbird" : "";
            hqBirdCalculatorBtn.Text = _isOpenMenu ? "Calculadora HQbird" : "";


            btnIcon.Width = _isOpenMenu ? _widthOpen : _widthClosed;
            btnIcon.SizeMode = _isOpenMenu ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;

        }

        private void Reset()
        {
            _leftBorderBtn.Visible = false;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void regeditBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

        }
    }
}
