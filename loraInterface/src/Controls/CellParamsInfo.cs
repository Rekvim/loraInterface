using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loraInterface.src.Controls
{
    public class CellParamsInfo : Control
    {

        private Label labelParam;
        private Label labelValue;

        

        public string labelParamText
        {
            get { return labelParam.Text; }
            set { labelParam.Text = value; }
        }

        public string labelValueText
        {
            get { return labelValue.Text; }
            set { labelValue.Text = value; }
        }

        public CellParamsInfo()
        {
            // Initialize labels
            labelParam = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };

            labelValue = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),

                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };

            // Add labels to the control
            Controls.Add(labelParam);
            Controls.Add(labelValue);

            // Set control styles
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            Size = new Size(500, 54);
            Resize += CellParamsInfo_Resize;
            Layout += CellParamsInfo_Layout;
        }

        private void CellParamsInfo_Resize(object sender, EventArgs e)
        {
            AdjustLabels();
        }

        private void CellParamsInfo_Layout(object sender, LayoutEventArgs e)
        {
            AdjustLabels();
        }

        private void AdjustLabels()
        {
            int offset = 20;
            int spacing = 10; // Растояние между лейблами
            int totalWidth = labelParam.Width + spacing;

            if (totalWidth > Width)
            {
                // Adjust the widths if they exceed the available space
                labelParam.Width = (Width - spacing) / 2;
                labelValue.Width = (Width - spacing) / 2;
            }

            // Center the labels vertically
            labelParam.Location = new Point(offset, (Height - labelParam.Height) / 2);
            labelValue.Location = new Point(labelParam.Right + spacing, (Height - labelValue.Height) / 2);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Parent?.BackColor ?? SystemColors.Control);
            int BorderSize = 1;
            Color BorderColor = Color.FromArgb(0, 0, 0);
            using (SolidBrush brush = new SolidBrush(BorderColor)) // border снизу
            {
                e.Graphics.FillRectangle(brush, 0, Height - BorderSize, Width, BorderSize);
            }
        }
    }
}
