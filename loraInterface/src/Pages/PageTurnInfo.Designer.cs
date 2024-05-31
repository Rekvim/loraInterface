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
            cellParamsInfoState.Anchor = AnchorStyles.Top;
            cellParamsInfoState.labelParamText = "Состояние:";
            cellParamsInfoState.labelValueText = "value";
            cellParamsInfoState.Location = new Point(18, 0);
            cellParamsInfoState.Margin = new Padding(3, 2, 3, 2);
            cellParamsInfoState.Name = "cellParamsInfoState";
            cellParamsInfoState.Size = new Size(633, 40);
            cellParamsInfoState.TabIndex = 1;
            cellParamsInfoState.Text = "cellParamsInfoState";
            // 
            // cellParamsInfoActualTurn
            // 
            cellParamsInfoActualTurn.labelParamText = "Актуальные обороты:";
            cellParamsInfoActualTurn.labelValueText = "value";
            cellParamsInfoActualTurn.Location = new Point(18, 81);
            cellParamsInfoActualTurn.Margin = new Padding(3, 2, 3, 2);
            cellParamsInfoActualTurn.Name = "cellParamsInfoActualTurn";
            cellParamsInfoActualTurn.Size = new Size(633, 40);
            cellParamsInfoActualTurn.TabIndex = 3;
            cellParamsInfoActualTurn.Text = "cellParamsInfoActualTurn";
            // 
            // cellParamsInfoTurn
            // 
            cellParamsInfoTurn.Anchor = AnchorStyles.Top;
            cellParamsInfoTurn.labelParamText = "Заданные обороты:";
            cellParamsInfoTurn.labelValueText = "value";
            cellParamsInfoTurn.Location = new Point(18, 40);
            cellParamsInfoTurn.Margin = new Padding(3, 2, 3, 2);
            cellParamsInfoTurn.Name = "cellParamsInfoTurn";
            cellParamsInfoTurn.Size = new Size(633, 40);
            cellParamsInfoTurn.TabIndex = 2;
            cellParamsInfoTurn.Text = "cellParamsInfoTurn";
            // 
            // PageTurnInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(cellParamsInfoActualTurn);
            Controls.Add(cellParamsInfoTurn);
            Controls.Add(cellParamsInfoState);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PageTurnInfo";
            Size = new Size(667, 422);
            Load += PageTurnInfo_Load;
            ResumeLayout(false);
        }

        #endregion
        private Controls.CellParamsInfo cellParamsInfoState;
        private Controls.CellParamsInfo cellParamsInfoActualTurn;
        private Controls.CellParamsInfo cellParamsInfoTurn;
    }
}
