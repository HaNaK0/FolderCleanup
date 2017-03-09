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
    public partial class MergeResolvePrompt : Form
    {
        public MergeResolvePrompt()
        {
            InitializeComponent();
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void OverwriteButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void DiscardButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
