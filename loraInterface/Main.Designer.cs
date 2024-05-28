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
            buttonNav3 = new src.Controls.ButtonNav();
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
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(982, 563);
            panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(220, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(762, 563);
            panelContent.TabIndex = 1;
            // 
            // panelBar
            // 
            panelBar.Controls.Add(buttonNav3);
            panelBar.Controls.Add(buttonNavComands);
            panelBar.Controls.Add(buttonNavTurnInfo);
            panelBar.Dock = DockStyle.Left;
            panelBar.Location = new Point(0, 0);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(220, 563);
            panelBar.TabIndex = 0;
            // 
            // buttonNav3
            // 
            buttonNav3.BackColor = Color.FromArgb(255, 255, 255);
            buttonNav3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonNav3.ForeColor = Color.Black;
            buttonNav3.Location = new Point(0, 108);
            buttonNav3.Margin = new Padding(0);
            buttonNav3.Name = "buttonNav3";
            buttonNav3.Size = new Size(220, 54);
            buttonNav3.TabIndex = 2;
            buttonNav3.Text = "buttonNav3";
            // 
            // buttonNavComands
            // 
            buttonNavComands.BackColor = Color.FromArgb(255, 255, 255);
            buttonNavComands.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonNavComands.ForeColor = Color.Black;
            buttonNavComands.Location = new Point(0, 54);
            buttonNavComands.Margin = new Padding(0);
            buttonNavComands.Name = "buttonNavComands";
            buttonNavComands.Size = new Size(220, 54);
            buttonNavComands.TabIndex = 1;
            buttonNavComands.Text = "buttonNav2";
            buttonNavComands.Click += buttonNavComands_Click;
            // 
            // buttonNavTurnInfo
            // 
            buttonNavTurnInfo.BackColor = Color.FromArgb(255, 255, 255);
            buttonNavTurnInfo.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonNavTurnInfo.ForeColor = Color.Black;
            buttonNavTurnInfo.Location = new Point(0, 0);
            buttonNavTurnInfo.Margin = new Padding(0);
            buttonNavTurnInfo.Name = "buttonNavTurnInfo";
            buttonNavTurnInfo.Size = new Size(220, 54);
            buttonNavTurnInfo.TabIndex = 0;
            buttonNavTurnInfo.Text = "buttonNav1";
            buttonNavTurnInfo.Click += buttonNavTurnInfo_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 563);
            Controls.Add(panelMain);
            Name = "Main";
            Text = "loraInterface";
            panelMain.ResumeLayout(false);
            panelBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelContent;
        private Panel panelBar;
        private src.Controls.ButtonNav buttonNavTurnInfo;
        private src.Controls.ButtonNav buttonNav3;
        private src.Controls.ButtonNav buttonNavComands;
    }
}
