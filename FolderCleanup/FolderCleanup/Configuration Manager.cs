using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FolderCleanup
{
    public partial class Configuration_Manager : Form
    {
        public Configurations configurations;
        public Configuration_Manager(Configurations configurations)
        {
            InitializeComponent();
            this.configurations = configurations;

            UpdateConfigurationList();
        }

        private void UpdateConfigurationList()
        {
            ConfigurationList.Items.Clear();

            for (int i = 1; i < configurations.configurations.Count; i++)
            {
                Configurations.Configuration configuration = configurations.configurations[i];
                ConfigurationList.Items.Add(configuration.configurationName);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            List<string> takenNames = new List<string>();

            foreach (Configurations.Configuration configuration in configurations.configurations)
            {
                takenNames.Add(configuration.configurationName);
            } 

            AddConfig addConfig = new AddConfig(takenNames);

            if (addConfig.ShowDialog() == DialogResult.OK)
            {
                configurations.configurations.Add(new Configurations.Configuration(addConfig.name));
                UpdateConfigurationList();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (ConfigurationList.SelectedIndex >= 0 &&
                ConfigurationList.SelectedIndex < configurations.configurations.Count &&
                MessageBox.Show("Are you sure you want to permanently remove configuration \"" + 
                configurations.configurations[ConfigurationList.SelectedIndex + 1].configurationName + "\"?", "Are you sure?"
                , MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                configurations.configurations.RemoveAt(ConfigurationList.SelectedIndex + 1);
                UpdateConfigurationList();
            }

            
        }
    }
}
