using FontAwesome.Sharp;

namespace CartsysControlPanel.Views
{
    public partial class MenuPrincipal : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public MenuPrincipal()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            menuPanel.Controls.Add(leftBorderBtn);

            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.AutoSize = false;
        }


        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = System.Drawing.Color.FromArgb(30, 58, 95);
                currentBtn.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = System.Drawing.Color.FromArgb(99, 179, 237); ;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = System.Drawing.Color.FromArgb(99, 179, 237);
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(30, 42, 56);
                currentBtn.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.FromArgb(100, 116, 139);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }



        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void regeditButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm?.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
