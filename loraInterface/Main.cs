using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using loraInterface.src.Admin;
using loraInterface.src.Controls;
using loraInterface.src.Pages;

namespace loraInterface
{
    public partial class Main : Form
    {
        private CommandPort commandPort;

        public Main()
        {
            InitializeComponent();
            commandPort = new CommandPort(); // Instantiate the commandPort object
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Запускаем обработку COM порта при загрузке формы
            if (commandPort != null)
            {
                commandPort.OpenPort();
                Task.Run(() => ReadDataFromPort());
            }
            else
            {
                MessageBox.Show("commandPort is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadDataFromPort()
        {
            while (true)
            {
                commandPort?.ReadData(); // Using null-conditional operator to avoid NullReferenceException
                // Делаем задержку в 1 секунду
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
            // Переключаемся на страницу с информацией о поворотах
            PageTurnInfo turn_info = new PageTurnInfo();
            AddUserControl(turn_info);
        }

        private void buttonNavComands_Click(object sender, EventArgs e)
        {
            PageCommands page_commands = new PageCommands(commandPort);
            AddUserControl(page_commands);
        }

        private void buttonNavTurnChart_Click(object sender, EventArgs e)
        {
            TurnChart turn_chart = new TurnChart();
            AddUserControl(turn_chart);
        }
    }
}
