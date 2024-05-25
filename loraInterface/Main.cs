using loraInterface.src.Admin;

namespace loraInterface
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void buttonNavTurnInfo_Click(object sender, EventArgs e)
        {
            PageTurnInfo turn_info = new PageTurnInfo();
            AddUserControl(turn_info);
        }

        private void buttonNavComands_Click(object sender, EventArgs e)
        {
            PageCommands page_commands = new PageCommands();
            AddUserControl(page_commands);
        }
    }
}
