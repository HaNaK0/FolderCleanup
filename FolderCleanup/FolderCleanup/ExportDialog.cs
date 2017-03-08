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
    public partial class ExportDialog : Form
    {
        private Configurations configurations;

        public ExportDialog(Configurations configurations)
        {
            InitializeComponent();
            this.configurations = configurations;
        }
    }
}
