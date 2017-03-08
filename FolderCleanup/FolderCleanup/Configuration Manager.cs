using System;
using System.Windows.Forms;

namespace FolderCleanup
{
    public partial class Configuration_Manager : Form
    {
        public Configuration_Manager()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
