using loraInterface.src.Admin;
using loraInterface.src.Pages;
using Timer = System.Windows.Forms.Timer;

namespace loraInterface
{
    public partial class Main : Form
    {
        private PortManagement portManagement;
        private Timer updateTimer;

        public Main()
        {
            InitializeComponent();

            updateTimer = new Timer
            {
                Interval = 1000 // 1 секунда
            };
            updateTimer.Tick += UpdateLabelStateCommand;
            updateTimer.Start();

            portManagement = new PortManagement();
            portManagement.OpenPorts();

            UpdateStatusBar();
        }

        private void UpdateLabelStateCommand(object sender, EventArgs e)
        {
            portManagement.TryReconnectPorts();
            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            // Обновляем состояние портов
            var statuses = portManagement.portStatuses;
            if (statuses.Count > 0)
            {
                var statusText = string.Join(", ", statuses.Select(s => $"{s.Key}: {s.Value}"));
                statusBar1.com_first_port_connection_value_text = statusText;
            }
            else
            {
                statusBar1.com_first_port_connection_value_text = "Нет подключённых портов";
            }

            statusBar1.status_command_value_text = portManagement.sendDataState;
            statusBar1.status_command_text = !string.IsNullOrEmpty(portManagement.sendDataState)
                ? "Состояние команды:"
                : "";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (portManagement != null)
            {
                Task.Run(() => ReadDataFromPort());
            }
            else
            {
                MessageBox.Show("PortManagement не инициализирован.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src");
            string pathFile = Path.GetFullPath(relativePath);

            // Создаём директорию, если она не существует
            string directoryPath = Path.GetDirectoryName(pathFile);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private void ReadDataFromPort()
        {
            while (true)
            {
                portManagement?.ReadData();
                Thread.Sleep(1000);
            }
        }

        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void buttonNavTurnInfo_Click(object sender, EventArgs e)
        {
            PageTurnInfo turn_info = new PageTurnInfo();
            AddUserControl(turn_info);
        }

        private void buttonNavComands_Click(object sender, EventArgs e)
        {
            PageCommands page_commands = new PageCommands(portManagement);
            AddUserControl(page_commands);
        }

        private void buttonNavTurnChart_Click(object sender, EventArgs e)
        {
            TurnChart turn_chart = new TurnChart();
            AddUserControl(turn_chart);
        }
    }
}
