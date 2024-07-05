namespace loraInterface.src.Controls
{
    internal class CellParamsInfo : Control
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
            // Инициализация label-ов
            labelParam = new Label
            {
                AutoSize = true,
                Font = new Font("Montserrat", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };

            labelValue = new Label
            {
                AutoSize = true,
                Font = new Font("Montserrat", 10, FontStyle.Regular),

                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };

            // Добавление label-а к элементу управления
            Controls.Add(labelParam);
            Controls.Add(labelValue);

            // Установка стилей управления
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
                // Отрегулируйте ширину, если она превышает доступное пространство
                labelParam.Width = (Width - spacing) / 2;
                labelValue.Width = (Width - spacing) / 2;
            }

            // Центрируйте надписи по вертикали
            labelParam.Location = new Point(offset, (Height - labelParam.Height) / 2);
            labelValue.Location = new Point(labelParam.Right + spacing, (Height - labelValue.Height) / 2);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Parent?.BackColor ?? SystemColors.Control);
            int BorderSize = 1;

            using (SolidBrush brush = new SolidBrush(Color.Black)) // border снизу
            {
                e.Graphics.FillRectangle(brush, 0, Height - BorderSize, Width, BorderSize);
            }
        }
    }
}
