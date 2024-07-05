namespace loraInterface.src.Admin
{
    partial class PageTurnInfo
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
            cellParamsInfoState = new Controls.CellParamsInfo();
            cellParamsInfoActualTurn = new Controls.CellParamsInfo();
            cellParamsInfoTurn = new Controls.CellParamsInfo();
            SuspendLayout();
            // 
            // cellParamsInfoState
            // 
            cellParamsInfoState.Dock = DockStyle.Top;
            cellParamsInfoState.Font = new Font("Montserrat", 10F);
            cellParamsInfoState.labelParamText = "Состояние:";
            cellParamsInfoState.labelValueText = "value";
            cellParamsInfoState.Location = new Point(0, 0);
            cellParamsInfoState.Margin = new Padding(4, 3, 4, 3);
            cellParamsInfoState.Name = "cellParamsInfoState";
            cellParamsInfoState.Size = new Size(953, 56);
            cellParamsInfoState.TabIndex = 1;
            cellParamsInfoState.Text = "cellParamsInfoState";
            // 
            // cellParamsInfoActualTurn
            // 
            cellParamsInfoActualTurn.Dock = DockStyle.Top;
            cellParamsInfoActualTurn.Font = new Font("Montserrat", 10F);
            cellParamsInfoActualTurn.labelParamText = "Актуальные обороты:";
            cellParamsInfoActualTurn.labelValueText = "value";
            cellParamsInfoActualTurn.Location = new Point(0, 112);
            cellParamsInfoActualTurn.Margin = new Padding(4, 3, 4, 3);
            cellParamsInfoActualTurn.Name = "cellParamsInfoActualTurn";
            cellParamsInfoActualTurn.Size = new Size(953, 56);
            cellParamsInfoActualTurn.TabIndex = 3;
            cellParamsInfoActualTurn.Text = "cellParamsInfoActualTurn";
            // 
            // cellParamsInfoTurn
            // 
            cellParamsInfoTurn.Dock = DockStyle.Top;
            cellParamsInfoTurn.Font = new Font("Montserrat", 10F);
            cellParamsInfoTurn.labelParamText = "Заданные обороты:";
            cellParamsInfoTurn.labelValueText = "value";
            cellParamsInfoTurn.Location = new Point(0, 56);
            cellParamsInfoTurn.Margin = new Padding(4, 3, 4, 3);
            cellParamsInfoTurn.Name = "cellParamsInfoTurn";
            cellParamsInfoTurn.Size = new Size(953, 56);
            cellParamsInfoTurn.TabIndex = 2;
            cellParamsInfoTurn.Text = "cellParamsInfoTurn";
            // 
            // PageTurnInfo
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(cellParamsInfoActualTurn);
            Controls.Add(cellParamsInfoTurn);
            Controls.Add(cellParamsInfoState);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PageTurnInfo";
            Size = new Size(953, 591);
            Load += PageTurnInfo_Load;
            ResumeLayout(false);
        }

        #endregion
        private Controls.CellParamsInfo cellParamsInfoState;
        private Controls.CellParamsInfo cellParamsInfoActualTurn;
        private Controls.CellParamsInfo cellParamsInfoTurn;
    }
}
