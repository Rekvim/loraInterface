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
            cellParamsInfo1 = new Controls.CellParamsInfo();
            cellParamsInfo3 = new Controls.CellParamsInfo();
            cellParamsInfo2 = new Controls.CellParamsInfo();
            SuspendLayout();
            // 
            // cellParamsInfo1
            // 
            cellParamsInfo1.Anchor = AnchorStyles.Top;
            cellParamsInfo1.labelParamText = "Состояние:";
            cellParamsInfo1.labelValueText = "value";
            cellParamsInfo1.Location = new Point(20, 0);
            cellParamsInfo1.Name = "cellParamsInfo1";
            cellParamsInfo1.Size = new Size(723, 54);
            cellParamsInfo1.TabIndex = 1;
            cellParamsInfo1.Text = "cellParamsInfoState";
            // 
            // cellParamsInfo3
            // 
            cellParamsInfo3.labelParamText = "Актуальные обороты:";
            cellParamsInfo3.labelValueText = "value";
            cellParamsInfo3.Location = new Point(20, 108);
            cellParamsInfo3.Name = "cellParamsInfo3";
            cellParamsInfo3.Size = new Size(723, 54);
            cellParamsInfo3.TabIndex = 3;
            cellParamsInfo3.Text = "cellParamsInfoActualTurn";
            // 
            // cellParamsInfo2
            // 
            cellParamsInfo2.Anchor = AnchorStyles.Top;
            cellParamsInfo2.labelParamText = "Заданные обороты:";
            cellParamsInfo2.labelValueText = "value";
            cellParamsInfo2.Location = new Point(20, 54);
            cellParamsInfo2.Name = "cellParamsInfo2";
            cellParamsInfo2.Size = new Size(723, 54);
            cellParamsInfo2.TabIndex = 2;
            cellParamsInfo2.Text = "cellParamsInfoTurn";
            // 
            // TurnInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(cellParamsInfo3);
            Controls.Add(cellParamsInfo2);
            Controls.Add(cellParamsInfo1);
            Name = "TurnInfo";
            Size = new Size(762, 563);
            ResumeLayout(false);
        }

        #endregion
        private Controls.CellParamsInfo cellParamsInfo1;
        private Controls.CellParamsInfo cellParamsInfo3;
        private Controls.CellParamsInfo cellParamsInfo2;
    }
}
