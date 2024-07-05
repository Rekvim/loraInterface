namespace loraInterface.src.Controls
{
    internal class StatusBar : Control
    {
        private Label com_first_port_connection;
        private Label com_first_port_connection_value;

        private Label com_second_port_connection;
        private Label com_second_port_connection_value;

        private Label status_command;
        private Label status_command_value;

        public string com_first_port_connection_value_text
        {
            get { return com_first_port_connection_value.Text = "value"; }
            set { com_first_port_connection_value.Text = value; }
        }

        public string com_second_port_connection_value_text
        {
            get { return com_second_port_connection_value.Text = "value"; }
            set { com_second_port_connection_value.Text = value; }
        }

        public string status_command_text
        {
            get { return status_command.Text; }
            set { status_command.Text = value; }
        }

        public string status_command_value_text
        {
            get { return status_command_value.Text = "value"; }
            set { status_command_value.Text = value; }
        }
        public StatusBar()
        {
            // Инициализация label-ов
            com_first_port_connection = new Label
            {
                AutoSize = true,
                Text = "LoRa 1:",
                Font = new Font("Montserrat", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };

            com_first_port_connection_value = new Label
            {
                AutoSize = true,
                Font = new Font("Montserrat", 10, FontStyle.Regular),

                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };

            com_second_port_connection = new Label
            {
                AutoSize = true,
                Text = "LoRa 2:",
                Font = new Font("Montserrat", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };

            com_second_port_connection_value = new Label
            {
                AutoSize = true,
                Font = new Font("Montserrat", 10, FontStyle.Regular),

                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };

            status_command = new Label
            {
                AutoSize = true,
               
                Font = new Font("Montserrat", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };

            status_command_value = new Label
            {
                AutoSize = true,
                Font = new Font("Montserrat", 10, FontStyle.Regular),

                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };
            // Добавление label-а к элементу управления

            Controls.Add(com_first_port_connection);
            Controls.Add(com_first_port_connection_value);

            Controls.Add(com_second_port_connection);
            Controls.Add(com_second_port_connection_value);

            Controls.Add(status_command);
            Controls.Add(status_command_value);
            // Установка стилей управления

            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            Size = new Size(1227, 50);
            Resize += StatusBarInfo_Resize;
            Layout += StatusBarInfo_Layout;
        }

        private void StatusBarInfo_Resize(object sender, EventArgs e)
        {
            AdjustLabels();
        }

        private void StatusBarInfo_Layout(object sender, LayoutEventArgs e)
        {
            AdjustLabels();
        }

        private void AdjustLabels()
        {
            int offset = 20;
            int spacing = 5; // Растояние между лейблами
            int com_first_port_connection_total_width = com_first_port_connection.Width + spacing;
            int com_second_port_connection_total_width = com_second_port_connection.Width + spacing;
            int status_command_total_width = status_command.Width + spacing;
            if (com_first_port_connection_total_width > Width)
            {
                // Отрегулируйте ширину, если она превышает доступное пространство
                com_first_port_connection.Width = (Width - spacing) / 2;
                com_first_port_connection_value.Width = (Width - spacing) / 2;
            }
            if (com_second_port_connection_total_width > Width)
            {
                // Отрегулируйте ширину, если она превышает доступное пространство
                com_second_port_connection.Width = (Width - spacing) / 2;
                com_second_port_connection_value.Width = (Width - spacing) / 2;
            }
            if (status_command_total_width > Width)
            {
                // Отрегулируйте ширину, если она превышает доступное пространство
                status_command.Width = (Width - spacing) / 2;
                status_command_value.Width = (Width - spacing) / 2;
            }

            // Центрируйте надписи по вертикали
            com_first_port_connection.Location = new Point(offset, (Height - com_first_port_connection.Height) / 2);
            com_first_port_connection_value.Location = new Point(com_first_port_connection.Right + spacing, (Height - com_first_port_connection_value.Height) / 2);

            com_second_port_connection.Location = new Point(com_first_port_connection_value.Right, (Height - com_second_port_connection.Height) / 2);
            com_second_port_connection_value.Location = new Point(com_second_port_connection.Right + spacing, (Height - com_second_port_connection_value.Height) / 2);

            status_command.Location = new Point(com_second_port_connection_value.Right, (Height - status_command.Height) / 2);
            status_command_value.Location = new Point(status_command.Right + spacing, (Height - status_command_value.Height) / 2);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Parent?.BackColor ?? SystemColors.Control);
        }
    }
}
