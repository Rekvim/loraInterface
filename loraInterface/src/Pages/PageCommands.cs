using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace loraInterface.src.Admin
{
    public partial class PageCommands : UserControl
    {
        private CommandPort commandPort;
        private Timer updateTimer;

        public PageCommands(CommandPort commandPort)
        {
            InitializeComponent();
            this.commandPort = commandPort;
            labelStateCommand.Text = "";

            updateTimer = new Timer();
            updateTimer.Interval = 5000; // 1 second
            updateTimer.Tick += new EventHandler(UpdateLabelStateCommand);
            updateTimer.Start();
        }

        private void UpdateLabelStateCommand(object sender, EventArgs e)
        {
            labelStateCommand.Text = commandPort.sendDataState;
        }
        private void buttonComandOff_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/RATATION/OFF/\r");
        }

        private void buttonComandOn_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/RATATION/ON/\r");
        }

        private void buttonComandTurn_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand($"/CMD/SET/TURN/{turnTrackBar1.Value}/\r");
        }

        private void buttonComandReset_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/RESET/\r");
        }

        private void buttonComand5_Click(object sender, EventArgs e)
        {
            commandPort.SetCommand("/CMD/SET/REPORTRERUN/\r");
        }
    }
}
