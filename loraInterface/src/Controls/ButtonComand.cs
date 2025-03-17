﻿
using System.Drawing.Drawing2D;
using Font = System.Drawing.Font;


namespace loraInterface.src.Controls
{
    internal class ButtonComand : Control
    {
        private StringFormat SF = new StringFormat();
        // Collors
        public Color BorderColor = Color.Black;
        public Color backColorEnter = Color.FromArgb(219, 219, 219);
        public Color backColorLeave = Color.FromArgb(245, 245, 245);
        public Color backColorDown = Color.FromArgb(125, 125, 125);
        // variables
        public int BorderSize = 1;
        private bool _active;

        public ButtonComand()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Font = new Font("Montserrat", 10, FontStyle.Regular);

            BackColor = Color.FromArgb(245, 245, 245);
            Size = new Size(633, 40);

            SF.Alignment = StringAlignment.Near;
            SF.LineAlignment = StringAlignment.Center;

            ForeColor = Color.Black;

            Cursor = Cursors.Hand; // курсор
        }

        protected override void OnMouseEnter(EventArgs e) // При навидении
        {
            base.OnMouseEnter(e);
            if (!_active)
                BackColor = backColorEnter;
        }

        protected override void OnMouseLeave(EventArgs e) // При отвидении
        {
            base.OnMouseLeave(e);
            if (!_active)
                BackColor = backColorLeave;
        }

        protected override void OnMouseDown(MouseEventArgs e) // При нажатии
        {
            base.OnMouseDown(e);
            if (!_active)
                BackColor = backColorDown;
        }

        public void SetStateActive()
        {
            _active = true;
            BackColor = backColorDown;
        }

        public void SetStateNormal()
        {
            _active = false;
            BackColor = Color.FromArgb(245, 245, 245);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen DrawPen = new Pen(BorderColor);
            GraphicsPath gfxPath_mod = new GraphicsPath();
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle(20, 0, Width - 1, Height - 1);
            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rect, SF);
            using (SolidBrush brush = new SolidBrush(BorderColor))
            {
                e.Graphics.FillRectangle(brush, 0, Height - BorderSize, Width, BorderSize);
            }
        }
    }
}
