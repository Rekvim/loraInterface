using System;
using System.Drawing;
using System.Windows.Forms;

namespace loraInterface.src.Controls
{
    internal class TurnTrackBar : Control
    {
        // Values
        private int _minimum = 0;
        private int _maximum = 2000;
        private int _value = 0;
        private bool _mouseDown = false;

        public event EventHandler ValueChanged;

        public int Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                Invalidate();
            }
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if (value < _minimum)
                    _value = _minimum;
                else if (value > _maximum)
                    _value = _maximum;
                else
                    _value = value;

                Invalidate();
                OnValueChanged(EventArgs.Empty);
            }
        }


        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
        public TurnTrackBar()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseDown = true;
            UpdateValueFromMousePosition(e.Location);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_mouseDown)
                UpdateValueFromMousePosition(e.Location);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseDown = false;
        }

        // Colors
        public Color BorderColor = Color.Black;
        public Color ColorTrack = Color.FromArgb(219, 219, 219);
        public Color BackColor = Color.FromArgb(255, 255, 255);
        public Color ColorThumb = Color.FromArgb(125, 125, 125);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle clientRectangle = ClientRectangle;

            // Background
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                g.FillRectangle(brush, clientRectangle);
            }

            // Дорожка
            int trackWidth = clientRectangle.Width - 20; // учитываем отступы слева и справа
            int trackHeight = 5;
            int trackTop = (clientRectangle.Height - trackHeight) / 2;
            int trackLeft = 10; // учитываем отступ слева
            Rectangle trackRectangle = new Rectangle(trackLeft, trackTop, trackWidth, trackHeight);

            using (SolidBrush brush = new SolidBrush(ColorTrack))
            {
                g.FillRectangle(brush, trackRectangle);
            }

            // Бегунок
            float thumbPosition = trackLeft + (float)(_value - _minimum) / (_maximum - _minimum) * trackWidth;
            int thumbSize = 15;
            Rectangle thumbRectangle = new Rectangle((int)thumbPosition - thumbSize / 2, trackTop - thumbSize / 2, thumbSize, thumbSize);
            using (SolidBrush brush = new SolidBrush(ColorThumb))
            {
                g.FillEllipse(brush, thumbRectangle);
            }

            // Отображаем значение бегунка
            string valueText = _value.ToString();
            SizeF textSize = g.MeasureString(valueText, Font);
            PointF textLocation = new PointF(thumbRectangle.X + (thumbRectangle.Width - textSize.Width) / 2, trackTop - textSize.Height - 5);

            // Проверка, чтобы текст не выходил за пределы элемента управления
            if (textLocation.X < 0)
                textLocation.X = 0;
            if (textLocation.X + textSize.Width > Width)
                textLocation.X = Width - textSize.Width;

            g.DrawString(valueText, Font, Brushes.Black, textLocation);
        }

        private void UpdateValueFromMousePosition(Point mousePosition)
        {
            float trackWidth = Width - 10;
            float normalizedPosition = (mousePosition.X - 5) / trackWidth;
            int newValue = (int)(normalizedPosition * (_maximum - _minimum)) + _minimum;

            // шаг в 10 едениц
            int remainder = newValue % 10;
            if (remainder >= 5)
                newValue += 10 - remainder;
            else
                newValue -= remainder;

            Value = newValue;
        }
    }
}
