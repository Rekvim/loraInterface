using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace loraInterface.src.Admin
{
    public partial class PageCommands : UserControl
    {
        private CommandPort commandPort;

        public PageCommands(CommandPort commandPort)
        {
            InitializeComponent();
            this.commandPort = commandPort;

            UpdateCommandStatus();
        }

        private void UpdateCommandStatus()
        {
            label1.Text = commandPort.command;
            label2.Text = commandPort.sendData.ToString();
        }

        private void buttonComandOff_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/RATATION/OFF/\r");
            UpdateCommandStatus();
        }

        private void buttonComandOn_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/RATATION/ON/\r");
            UpdateCommandStatus();
        }

        private void buttonComandTurn_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand($"/CMD/SET/TURN/{turnTrackBar1.Value}/\r");
            UpdateCommandStatus();
        }

        private void buttonComandReset_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/RESET/\r");
            UpdateCommandStatus();
        }

        private void buttonComand5_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/REPORTRERUN/\r");
            UpdateCommandStatus();
        }
    }
}