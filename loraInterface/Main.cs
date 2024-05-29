using System;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using loraInterface.src.Admin;

namespace loraInterface
{
    public partial class Main : Form
    {
        private CommandPort commandPort;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            commandPort = new CommandPort();
            commandPort.OpenPort();
            Task.Run(() => ReadDataFromPort());
        }

        private void ReadDataFromPort()
        {
            while (true)
            {
                commandPort.ReadData();
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
            PageCommands page_commands = new PageCommands(commandPort);
            AddUserControl(page_commands);
        }
    }
}