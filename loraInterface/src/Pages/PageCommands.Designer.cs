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
            buttonComandReset = new Controls.ButtonComand();
            buttonComand5 = new Controls.ButtonComand();
            turnTrackBar1 = new Controls.TurnTrackBar();
            SuspendLayout();
            // 
            // buttonComandOff
            // 
            buttonComandOff.BackColor = Color.FromArgb(255, 255, 255);
            buttonComandOff.Font = new Font("Microsoft Sans Serif", 10F);
            buttonComandOff.ForeColor = Color.Black;
            buttonComandOff.Location = new Point(18, 0);
            buttonComandOff.Margin = new Padding(3, 2, 3, 2);
            buttonComandOff.Name = "buttonComandOff";
            buttonComandOff.Size = new Size(633, 40);
            buttonComandOff.TabIndex = 0;
            buttonComandOff.Text = "выключить турбину";
            buttonComandOff.Click += buttonComandOff_Click;
            // 
            // buttonComandOn
            // 
            buttonComandOn.BackColor = Color.FromArgb(255, 255, 255);
            buttonComandOn.Font = new Font("Microsoft Sans Serif", 10F);
            buttonComandOn.ForeColor = Color.Black;
            buttonComandOn.Location = new Point(18, 40);
            buttonComandOn.Margin = new Padding(3, 2, 3, 2);
            buttonComandOn.Name = "buttonComandOn";
            buttonComandOn.Size = new Size(633, 40);
            buttonComandOn.TabIndex = 1;
            buttonComandOn.Text = "Включить турбину";
            buttonComandOn.Click += buttonComandOn_Click;
            // 
            // buttonComandTurn
            // 
            buttonComandTurn.BackColor = Color.FromArgb(255, 255, 255);
            buttonComandTurn.Font = new Font("Microsoft Sans Serif", 10F);
            buttonComandTurn.ForeColor = Color.Black;
            buttonComandTurn.Location = new Point(18, 81);
            buttonComandTurn.Margin = new Padding(3, 2, 3, 2);
            buttonComandTurn.Name = "buttonComandTurn";
            buttonComandTurn.Size = new Size(633, 40);
            buttonComandTurn.TabIndex = 2;
            buttonComandTurn.Text = "Задать обороты";
            buttonComandTurn.Click += buttonComandTurn_Click;
            // 
            // buttonComandReset
            // 
            buttonComandReset.BackColor = Color.FromArgb(255, 255, 255);
            buttonComandReset.Font = new Font("Microsoft Sans Serif", 10F);
            buttonComandReset.ForeColor = Color.Black;
            buttonComandReset.Location = new Point(18, 163);
            buttonComandReset.Margin = new Padding(3, 2, 3, 2);
            buttonComandReset.Name = "buttonComandReset";
            buttonComandReset.Size = new Size(633, 40);
            buttonComandReset.TabIndex = 3;
            buttonComandReset.Text = "Перезагрузка";
            buttonComandReset.Click += buttonComandReset_Click;
            // 
            // buttonComand5
            // 
            buttonComand5.BackColor = Color.FromArgb(255, 255, 255);
            buttonComand5.Font = new Font("Microsoft Sans Serif", 10F);
            buttonComand5.ForeColor = Color.Black;
            buttonComand5.Location = new Point(18, 203);
            buttonComand5.Margin = new Padding(3, 2, 3, 2);
            buttonComand5.Name = "buttonComand5";
            buttonComand5.Size = new Size(633, 40);
            buttonComand5.TabIndex = 4;
            buttonComand5.Text = "повторный запуск отчета";
            buttonComand5.Click += buttonComand5_Click;
            // 
            // turnTrackBar1
            // 
            turnTrackBar1.Location = new Point(18, 122);
            turnTrackBar1.Margin = new Padding(3, 2, 3, 2);
            turnTrackBar1.Maximum = 2000;
            turnTrackBar1.Minimum = 0;
            turnTrackBar1.Name = "turnTrackBar1";
            turnTrackBar1.Size = new Size(633, 41);
            turnTrackBar1.TabIndex = 5;
            turnTrackBar1.Text = "turnTrackBar1";
            turnTrackBar1.Value = 0;
            // 
            // PageCommands
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(turnTrackBar1);
            Controls.Add(buttonComand5);
            Controls.Add(buttonComandReset);
            Controls.Add(buttonComandTurn);
            Controls.Add(buttonComandOn);
            Controls.Add(buttonComandOff);
            Margin = new Padding(0);
            Name = "PageCommands";
            Size = new Size(667, 422);
            ResumeLayout(false);
        }

        #endregion

        private Controls.ButtonComand buttonComandOff;
        private Controls.ButtonComand buttonComandOn;
        private Controls.ButtonComand buttonComandTurn;
        private Controls.ButtonComand buttonComandReset;
        private Controls.ButtonComand buttonComand5;
        private Controls.TurnTrackBar turnTrackBar1;
    }
}
