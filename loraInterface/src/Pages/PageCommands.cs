using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loraInterface.src.Admin
{
    public partial class PageCommands : UserControl
    {
        private CommandPort commandPort;

        public PageCommands()
        {
            InitializeComponent();

            commandPort = new CommandPort();

            label1.Text = commandPort.command;
            label2.Text = commandPort.sendData.ToString();
        }

        private void buttonComandOff_Click(object sender, EventArgs e)
        {
            commandPort.command = $"/CMD/SET/TURN/{turnTrackBar1.Value}/\r\n";
            commandPort.sendData = true;
            this.Refresh();
        }

        private void buttonComandOn_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/RATATION/ON/\r\n");
        }

        private void buttonComandTurn_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand($"/CMD/SET/TURN/{turnTrackBar1.Value}/\r\n");
        }

        private void buttonComandReset_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/RESET/\r\n");
        }

        private void buttonComand5_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/REPORTRERUN/\r\n");
        }
    }
}
