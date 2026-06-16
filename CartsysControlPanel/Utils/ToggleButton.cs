using System.Drawing.Drawing2D;

namespace CartsysControlPanel
{
    public class ToggleButton : CheckBox
    {
        private Color onBackColor = Color.FromArgb(59, 130, 246);
        private Color onToggleColor = Color.FromArgb(226, 232, 240);
        private Color offBackColor = Color.FromArgb(51, 65, 85);
        private Color offToggleColor = Color.FromArgb(148, 163, 184);

        public ToggleButton()
        {
            this.MinimumSize = new Size(25, 22);
            this.AutoSize = false;
            this.Size = new Size(50, 22);
            this.BackColor = Color.Transparent;
            this.SetStyle(ControlStyles.UserPaint 
                | ControlStyles.AllPaintingInWmPaint 
                | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.Clear(this.Parent.BackColor);
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (this.Checked)
            {
                pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else
            {
                pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }

    }



}
