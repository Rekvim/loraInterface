namespace loraInterface.src.Admin
{
    partial class PageCommands
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            buttonComandOff = new Controls.ButtonComand();
            buttonComandOn = new Controls.ButtonComand();
            buttonComandTurn = new Controls.ButtonComand();
            turnTrackBar1 = new Controls.TurnTrackBar();
            buttonComandReset = new Controls.ButtonComand();
            buttonComand5 = new Controls.ButtonComand();
            SuspendLayout();
            // 
            // buttonComandOff
            // 
            buttonComandOff.BackColor = Color.Transparent;
            buttonComandOff.Dock = DockStyle.Top;
            buttonComandOff.Font = new Font("Montserrat", 10F);
            buttonComandOff.ForeColor = Color.Black;
            buttonComandOff.Location = new Point(0, 0);
            buttonComandOff.Margin = new Padding(4, 3, 4, 3);
            buttonComandOff.Name = "buttonComandOff";
            buttonComandOff.Size = new Size(953, 56);
            buttonComandOff.TabIndex = 0;
            buttonComandOff.Text = "Выключить турбину";
            buttonComandOff.Click += buttonComandOff_Click;
            // 
            // buttonComandOn
            // 
            buttonComandOn.BackColor = Color.Transparent;
            buttonComandOn.Dock = DockStyle.Top;
            buttonComandOn.Font = new Font("Montserrat", 10F);
            buttonComandOn.ForeColor = Color.Black;
            buttonComandOn.Location = new Point(0, 56);
            buttonComandOn.Margin = new Padding(4, 3, 4, 3);
            buttonComandOn.Name = "buttonComandOn";
            buttonComandOn.Size = new Size(953, 56);
            buttonComandOn.TabIndex = 1;
            buttonComandOn.Text = "Включить турбину";
            buttonComandOn.Click += buttonComandOn_Click;
            // 
            // buttonComandTurn
            // 
            buttonComandTurn.BackColor = Color.WhiteSmoke;
            buttonComandTurn.Dock = DockStyle.Top;
            buttonComandTurn.Font = new Font("Montserrat", 10F);
            buttonComandTurn.ForeColor = Color.Black;
            buttonComandTurn.Location = new Point(0, 112);
            buttonComandTurn.Margin = new Padding(4, 3, 4, 3);
            buttonComandTurn.Name = "buttonComandTurn";
            buttonComandTurn.Size = new Size(953, 56);
            buttonComandTurn.TabIndex = 2;
            buttonComandTurn.Text = "Задать обороты";
            buttonComandTurn.Click += buttonComandTurn_Click;
            // 
            // turnTrackBar1
            // 
            turnTrackBar1.Dock = DockStyle.Top;
            turnTrackBar1.Font = new Font("Montserrat", 10F);
            turnTrackBar1.Location = new Point(0, 168);
            turnTrackBar1.Margin = new Padding(4, 3, 4, 3);
            turnTrackBar1.Maximum = 2000;
            turnTrackBar1.Minimum = 0;
            turnTrackBar1.Name = "turnTrackBar1";
            turnTrackBar1.Size = new Size(953, 70);
            turnTrackBar1.TabIndex = 3;
            turnTrackBar1.Text = "turnTrackBar1";
            turnTrackBar1.Value = 0;
            // 
            // buttonComandReset
            // 
            buttonComandReset.BackColor = Color.Transparent;
            buttonComandReset.Dock = DockStyle.Bottom;
            buttonComandReset.Font = new Font("Montserrat", 10F);
            buttonComandReset.ForeColor = Color.Black;
            buttonComandReset.Location = new Point(0, 535);
            buttonComandReset.Margin = new Padding(4, 3, 4, 3);
            buttonComandReset.Name = "buttonComandReset";
            buttonComandReset.Size = new Size(953, 56);
            buttonComandReset.TabIndex = 5;
            buttonComandReset.Text = "Перезагрузка";
            buttonComandReset.Click += buttonComandReset_Click;
            // 
            // buttonComand5
            // 
            buttonComand5.BackColor = Color.Transparent;
            buttonComand5.Dock = DockStyle.Bottom;
            buttonComand5.Font = new Font("Montserrat", 10F);
            buttonComand5.ForeColor = Color.Black;
            buttonComand5.Location = new Point(0, 479);
            buttonComand5.Margin = new Padding(4, 3, 4, 3);
            buttonComand5.Name = "buttonComand5";
            buttonComand5.Size = new Size(953, 56);
            buttonComand5.TabIndex = 4;
            buttonComand5.Text = "Повторный запуск отчета";
            buttonComand5.Click += buttonComand5_Click;
            // 
            // PageCommands
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(turnTrackBar1);
            Controls.Add(buttonComand5);
            Controls.Add(buttonComandReset);
            Controls.Add(buttonComandTurn);
            Controls.Add(buttonComandOn);
            Controls.Add(buttonComandOff);
            Margin = new Padding(0);
            Name = "PageCommands";
            Size = new Size(953, 591);
            ResumeLayout(false);
        }

        #endregion

        private Controls.ButtonComand buttonComandOff;
        private Controls.ButtonComand buttonComandOn;
        private Controls.ButtonComand buttonComandTurn;
        private Controls.TurnTrackBar turnTrackBar1;
        private Controls.ButtonComand buttonComandReset;
        private Controls.ButtonComand buttonComand5;

    }
}
