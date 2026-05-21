using FontAwesome.Sharp;

namespace CartsysControlPanel.Views
{
    public partial class MenuSelecaoForm : Form
    {
        private IconButton _currentBtn;
        private Panel _leftBorderBtn;
        private Form _currentChildForm;
        private bool _isOpenMenu = false;
        private const int _widthClosed = 60;
        private const int _widthOpen = 220;

        public MenuSelecaoForm()
        {
            InitializeComponent();
            _leftBorderBtn = new Panel();
            _leftBorderBtn.Size = new Size(7, 60);
            menuPanel.Controls.Add(_leftBorderBtn);


            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.AutoSize = false;


            UpdateMenu();
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
                _currentChildForm.Close();
            }
            _currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            _currentChildForm?.Close();
            Reset();
        }

        private void servicesHandler_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new ServiceForm());
        }

        private void networkHandler_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void firebirdHqbird_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void hqBirdCalculator_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnIcon_Click(object sender, EventArgs e)
        {
            _isOpenMenu = !_isOpenMenu;

            UpdateMenu();
        }

        private void UpdateMenu()
        {
            menuPanel.Width = _isOpenMenu ? _widthOpen : _widthClosed;
            btnIcon.Image = _isOpenMenu ? Properties.Resources.cartsysLogo : Properties.Resources.cartsysIco;
            btnHome.Text = _isOpenMenu ? "Menu Iniciar" : "";
            servicesHandlerBtn.Text = _isOpenMenu ? "Serviços" : "";
            networkHandlerBtn.Text = _isOpenMenu ? "Rede" : "";
            firebirdHqbirdBtn.Text = _isOpenMenu ? "Firebird/HQbird" : "";
            hqBirdCalculatorBtn.Text = _isOpenMenu ? "Calculadora HQbird" : "";
            regeditBtn.Text = _isOpenMenu ? "Editor de Registro" : "";


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
            OpenChildForm(new RegeditForm());
        }
    }
}
