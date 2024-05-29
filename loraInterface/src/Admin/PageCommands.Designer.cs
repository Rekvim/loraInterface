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
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // buttonComandOff
            // 
            buttonComandOff.BackColor = Color.FromArgb(255, 255, 255);
            buttonComandOff.Font = new Font("Microsoft Sans Serif", 10F);
            buttonComandOff.ForeColor = Color.Black;
            buttonComandOff.Location = new Point(20, 0);
            buttonComandOff.Name = "buttonComandOff";
            buttonComandOff.Size = new Size(723, 54);
            buttonComandOff.TabIndex = 0;
            buttonComandOff.Text = "buttonComandOff";
            // 
            // buttonComandOn
            // 
            buttonComandOn.BackColor = Color.FromArgb(255, 255, 255);
            buttonComandOn.Font = new Font("Microsoft Sans Serif", 10F);
            buttonComandOn.ForeColor = Color.Black;
            buttonComandOn.Location = new Point(20, 54);
            buttonComandOn.Name = "buttonComandOn";
            buttonComandOn.Size = new Size(723, 54);
            buttonComandOn.TabIndex = 1;
            buttonComandOn.Text = "buttonComandOn";
            // 
            // buttonComandTurn
            // 
            buttonComandTurn.BackColor = Color.FromArgb(255, 255, 255);
            buttonComandTurn.Font = new Font("Microsoft Sans Serif", 10F);
            buttonComandTurn.ForeColor = Color.Black;
            buttonComandTurn.Location = new Point(20, 108);
            buttonComandTurn.Name = "buttonComandTurn";
            buttonComandTurn.Size = new Size(723, 54);
            buttonComandTurn.TabIndex = 2;
            buttonComandTurn.Text = "buttonComandTurn";
            // 
            // buttonComandReset
            // 
            buttonComandReset.BackColor = Color.FromArgb(255, 255, 255);
            buttonComandReset.Font = new Font("Microsoft Sans Serif", 10F);
            buttonComandReset.ForeColor = Color.Black;
            buttonComandReset.Location = new Point(20, 217);
            buttonComandReset.Name = "buttonComandReset";
            buttonComandReset.Size = new Size(723, 54);
            buttonComandReset.TabIndex = 3;
            buttonComandReset.Text = "buttonComandReset";
            // 
            // buttonComand5
            // 
            buttonComand5.BackColor = Color.FromArgb(255, 255, 255);
            buttonComand5.Font = new Font("Microsoft Sans Serif", 10F);
            buttonComand5.ForeColor = Color.Black;
            buttonComand5.Location = new Point(20, 271);
            buttonComand5.Name = "buttonComand5";
            buttonComand5.Size = new Size(723, 54);
            buttonComand5.TabIndex = 4;
            buttonComand5.Text = "buttonComand5";
            // 
            // turnTrackBar1
            // 
            turnTrackBar1.Location = new Point(20, 162);
            turnTrackBar1.Maximum = 2000;
            turnTrackBar1.Minimum = 0;
            turnTrackBar1.Name = "turnTrackBar1";
            turnTrackBar1.Size = new Size(723, 55);
            turnTrackBar1.TabIndex = 5;
            turnTrackBar1.Text = "turnTrackBar1";
            turnTrackBar1.Value = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 403);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 6;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 445);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 7;
            label2.Text = "label2";
            // 
            // PageCommands
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(turnTrackBar1);
            Controls.Add(buttonComand5);
            Controls.Add(buttonComandReset);
            Controls.Add(buttonComandTurn);
            Controls.Add(buttonComandOn);
            Controls.Add(buttonComandOff);
            Margin = new Padding(0);
            Name = "PageCommands";
            Size = new Size(762, 563);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.ButtonComand buttonComandOff;
        private Controls.ButtonComand buttonComandOn;
        private Controls.ButtonComand buttonComandTurn;
        private Controls.ButtonComand buttonComandReset;
        private Controls.ButtonComand buttonComand5;
        private Controls.TurnTrackBar turnTrackBar1;
        private Label label1;
        private Label label2;
    }
}
