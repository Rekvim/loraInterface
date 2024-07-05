namespace loraInterface
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMain = new Panel();
            panelContent = new Panel();
            panelBar = new Panel();
            buttonNavTurnChart = new src.Controls.ButtonNav();
            buttonNavComands = new src.Controls.ButtonNav();
            buttonNavTurnInfo = new src.Controls.ButtonNav();
            panelStatus = new Panel();
            statusBar1 = new src.Controls.StatusBar();
            panelMain.SuspendLayout();
            panelBar.SuspendLayout();
            panelStatus.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelBar);
            panelMain.Dock = DockStyle.Top;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(4, 3, 4, 3);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1227, 542);
            panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(274, 0);
            panelContent.Margin = new Padding(4, 3, 4, 3);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(20, 0, 20, 0);
            panelContent.Size = new Size(953, 542);
            panelContent.TabIndex = 1;
            // 
            // panelBar
            // 
            panelBar.Controls.Add(buttonNavTurnChart);
            panelBar.Controls.Add(buttonNavComands);
            panelBar.Controls.Add(buttonNavTurnInfo);
            panelBar.Dock = DockStyle.Left;
            panelBar.Location = new Point(0, 0);
            panelBar.Margin = new Padding(4, 3, 4, 3);
            panelBar.Name = "panelBar";
            panelBar.Padding = new Padding(20, 0, 20, 0);
            panelBar.Size = new Size(274, 542);
            panelBar.TabIndex = 0;
            // 
            // buttonNavTurnChart
            // 
            buttonNavTurnChart.BackColor = Color.WhiteSmoke;
            buttonNavTurnChart.Dock = DockStyle.Top;
            buttonNavTurnChart.Font = new Font("Montserrat", 10F);
            buttonNavTurnChart.ForeColor = Color.Black;
            buttonNavTurnChart.Location = new Point(20, 112);
            buttonNavTurnChart.Margin = new Padding(0);
            buttonNavTurnChart.Name = "buttonNavTurnChart";
            buttonNavTurnChart.Size = new Size(234, 56);
            buttonNavTurnChart.TabIndex = 1;
            buttonNavTurnChart.Text = "График Акт. оборотов";
            buttonNavTurnChart.Click += buttonNavTurnChart_Click;
            // 
            // buttonNavComands
            // 
            buttonNavComands.BackColor = Color.WhiteSmoke;
            buttonNavComands.Dock = DockStyle.Top;
            buttonNavComands.Font = new Font("Montserrat", 10F);
            buttonNavComands.ForeColor = Color.Black;
            buttonNavComands.Location = new Point(20, 56);
            buttonNavComands.Margin = new Padding(0);
            buttonNavComands.Name = "buttonNavComands";
            buttonNavComands.Size = new Size(234, 56);
            buttonNavComands.TabIndex = 2;
            buttonNavComands.Text = "Команды GPS";
            buttonNavComands.Click += buttonNavComands_Click;
            // 
            // buttonNavTurnInfo
            // 
            buttonNavTurnInfo.BackColor = Color.WhiteSmoke;
            buttonNavTurnInfo.Dock = DockStyle.Top;
            buttonNavTurnInfo.Font = new Font("Montserrat", 10F);
            buttonNavTurnInfo.ForeColor = Color.Black;
            buttonNavTurnInfo.Location = new Point(20, 0);
            buttonNavTurnInfo.Margin = new Padding(0);
            buttonNavTurnInfo.Name = "buttonNavTurnInfo";
            buttonNavTurnInfo.Size = new Size(234, 56);
            buttonNavTurnInfo.TabIndex = 0;
            buttonNavTurnInfo.Text = "Информация о турбине";
            buttonNavTurnInfo.Click += buttonNavTurnInfo_Click;
            // 
            // panelStatus
            // 
            panelStatus.Controls.Add(statusBar1);
            panelStatus.Dock = DockStyle.Bottom;
            panelStatus.Font = new Font("Montserrat", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            panelStatus.Location = new Point(0, 541);
            panelStatus.Margin = new Padding(4, 3, 4, 3);
            panelStatus.Name = "panelStatus";
            panelStatus.Size = new Size(1227, 50);
            panelStatus.TabIndex = 3;
            // 
            // statusBar1
            // 
            statusBar1.com_first_port_connection_value_text = "value";
            statusBar1.com_second_port_connection_value_text = "value";
            statusBar1.Dock = DockStyle.Fill;
            statusBar1.Location = new Point(0, 0);
            statusBar1.Name = "statusBar1";
            statusBar1.Size = new Size(1227, 50);
            statusBar1.status_command_value_text = "value";
            statusBar1.TabIndex = 0;
            statusBar1.Text = "statusBar1";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1227, 591);
            Controls.Add(panelStatus);
            Controls.Add(panelMain);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "loraInterface";
            Load += Main_Load;
            panelMain.ResumeLayout(false);
            panelBar.ResumeLayout(false);
            panelStatus.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelContent;
        private Panel panelBar;
        private src.Controls.ButtonNav buttonNavTurnInfo;
        private src.Controls.ButtonNav buttonNavTurnChart;
        private src.Controls.ButtonNav buttonNavComands;
        private Panel panelStatus;
        private src.Controls.StatusBar statusBar1;
    }
}
