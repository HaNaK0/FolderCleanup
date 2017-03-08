using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            CreateCheckedList();
        }

        private void CreateCheckedList()
        {
            foreach (Configurations.Configuration configuration in configurations.configurations)
            {
                ExportItemList.Items.Add(configuration.configurationName);
            }
        }

        private void ExportPathButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Configuration Files | *.conf";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExportPathBox.Text = dialog.FileName;
            }

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ExportPathBox.Text.Length == 0)
            {
                MessageBox.Show("Please choose an export path.");
                return;
            }
            if (ExportItemList.CheckedIndices.Count == 0)
            {
                MessageBox.Show("No items selected for export.");
                return;
            }
            string exportPath = ExportPathBox.Text;

            ExportItems(exportPath, ExportItemList.CheckedIndices);
            DialogResult = DialogResult.OK;
        }

        private void ExportItems(string exportPath, CheckedListBox.CheckedIndexCollection checkedIndices)
        {
            string resultString = "";
            foreach (int checkedIndex in checkedIndices)
            {
                resultString += configurations.configurations[checkedIndex];
            }

            if (File.Exists(exportPath) == true)
            {
                File.Delete(exportPath);
            }

            StreamWriter output = File.CreateText(exportPath);
            output.Write(resultString);
            output.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
