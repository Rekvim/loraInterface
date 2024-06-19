using loraInterface.src.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace loraInterface.src.Admin
{
    public partial class PageCommands : UserControl
    {
        private CommandPort commandPort;
        private System.Windows.Forms.Timer updateTimer;
        private List<TurnData> turnDataList;


        public PageCommands(CommandPort commandPort)
        {
            InitializeComponent();
            this.commandPort = commandPort;
            labelStateCommand.Text = "";

            updateTimer = new Timer();
            updateTimer.Interval = 5000; // 5 секунд
            updateTimer.Tick += new EventHandler(UpdateLabelStateCommand);

            updateTimer.Start();

            LoadData(); // Загрузка данных при инициализации
        }

        private void LoadData()
        {
            turnDataList = TurnData.ReadTurnDataFromFile();
            if (turnDataList.Count > 0)
            {
                TurnData lastTurnData = turnDataList[turnDataList.Count - 1];
                turnTrackBar1.Value = lastTurnData.TurnValue; // Установка начального значения
            }
        }

        private void UpdateLabelStateCommand(object sender, EventArgs e)
        {

                TurnData lastTurnData = turnDataList[turnDataList.Count - 1];

                labelStateCommand.Text = commandPort.sendDataState;
                turnTrackBar1.Value = lastTurnData.TurnValue; // Обновление значения TurnTrackBar
            
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
