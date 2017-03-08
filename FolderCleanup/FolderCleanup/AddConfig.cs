using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderCleanup
{
    public partial class AddConfig : Form
    {
        private List<string> takenNames;
        public string name;
        public AddConfig(List<string> takenNames)
        {
            InitializeComponent();
            this.takenNames = takenNames;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ConfigNameBox.Text == "")
            {
                MessageBox.Show("Configuration name cannot be empty.");
                return;
            }
            foreach (string takenName in takenNames)
            {
                if (takenName == ConfigNameBox.Text)
                {
                    MessageBox.Show("Name \"" + ConfigNameBox.Text + "\" is already taken.");
                    return;
                }
            }

            name = ConfigNameBox.Text;

            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
