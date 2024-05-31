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
            panelMain.SuspendLayout();
            panelBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelBar);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(3, 2, 3, 2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(859, 422);
            panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(192, 0);
            panelContent.Margin = new Padding(3, 2, 3, 2);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(667, 422);
            panelContent.TabIndex = 1;
            // 
            // panelBar
            // 
            panelBar.Controls.Add(buttonNavTurnChart);
            panelBar.Controls.Add(buttonNavComands);
            panelBar.Controls.Add(buttonNavTurnInfo);
            panelBar.Dock = DockStyle.Left;
            panelBar.Location = new Point(0, 0);
            panelBar.Margin = new Padding(3, 2, 3, 2);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(192, 422);
            panelBar.TabIndex = 0;
            // 
            // buttonNavTurnChart
            // 
            buttonNavTurnChart.BackColor = Color.FromArgb(255, 255, 255);
            buttonNavTurnChart.Dock = DockStyle.Top;
            buttonNavTurnChart.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonNavTurnChart.ForeColor = Color.Black;
            buttonNavTurnChart.Location = new Point(0, 80);
            buttonNavTurnChart.Margin = new Padding(0);
            buttonNavTurnChart.Name = "buttonNavTurnChart";
            buttonNavTurnChart.Size = new Size(192, 40);
            buttonNavTurnChart.TabIndex = 1;
            buttonNavTurnChart.Text = "График Актульных оборотов";
            buttonNavTurnChart.Click += buttonNavTurnChart_Click;
            // 
            // buttonNavComands
            // 
            buttonNavComands.BackColor = Color.FromArgb(255, 255, 255);
            buttonNavComands.Dock = DockStyle.Top;
            buttonNavComands.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonNavComands.ForeColor = Color.Black;
            buttonNavComands.Location = new Point(0, 40);
            buttonNavComands.Margin = new Padding(0);
            buttonNavComands.Name = "buttonNavComands";
            buttonNavComands.Size = new Size(192, 40);
            buttonNavComands.TabIndex = 2;
            buttonNavComands.Text = "Команды GPS";
            buttonNavComands.Click += buttonNavComands_Click;
            // 
            // buttonNavTurnInfo
            // 
            buttonNavTurnInfo.BackColor = Color.FromArgb(255, 255, 255);
            buttonNavTurnInfo.Dock = DockStyle.Top;
            buttonNavTurnInfo.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonNavTurnInfo.ForeColor = Color.Black;
            buttonNavTurnInfo.Location = new Point(0, 0);
            buttonNavTurnInfo.Margin = new Padding(0);
            buttonNavTurnInfo.Name = "buttonNavTurnInfo";
            buttonNavTurnInfo.Size = new Size(192, 40);
            buttonNavTurnInfo.TabIndex = 0;
            buttonNavTurnInfo.Text = "Информация о турбине";
            buttonNavTurnInfo.Click += buttonNavTurnInfo_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(859, 422);
            Controls.Add(panelMain);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Main";
            Text = "loraInterface";
            Load += Main_Load;
            panelMain.ResumeLayout(false);
            panelBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelContent;
        private Panel panelBar;
        private src.Controls.ButtonNav buttonNavTurnInfo;
        private src.Controls.ButtonNav buttonNavTurnChart;
        private src.Controls.ButtonNav buttonNavComands;
    }
}
