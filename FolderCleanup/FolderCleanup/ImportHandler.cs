using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderCleanup
{
    class ImportHandler
    {
        private string importPath;
        private Configurations configurations;

        public ImportHandler(string importPath, Configurations configurations)
        {
            this.importPath = importPath;
            this.configurations = configurations;
        }

        public void Run()
        {
            string importFileData = File.ReadAllText(importPath);
            Configurations importConfigurations = new Configurations(importFileData);

            Merge(importConfigurations);
        }

        private void Merge(Configurations importConfigurations)
        {
            foreach (Configurations.Configuration importConfiguration in importConfigurations.configurations)
            {
                TryMerge(importConfiguration);
            }
        }

        private void TryMerge(Configurations.Configuration importConfiguration)
        {
            
            foreach (Configurations.Configuration configuration in configurations.configurations)
            {
                if (configuration.configurationName == importConfiguration.configurationName)
                {
                    ResolveMerge(configuration, importConfiguration);
                }
            }

            configurations.configurations.Add(importConfiguration);
        }

        private void ResolveMerge(Configurations.Configuration configuration, Configurations.Configuration importConfiguration)
        {
            //TODO: Add code to ask about how to resolve the merge issue here
            MergeResolvePrompt mergeResolvePrompt = new MergeResolvePrompt();
            DialogResult result = mergeResolvePrompt.ShowDialog();
            if (result == DialogResult.OK)
            {
                
            }
            else if (result == DialogResult.Yes)
            {
                
            }
            else if (result == DialogResult.Abort)
            {
                
            }
            else if (result == DialogResult.Cancel)
            {
                
            }
        }
    }
}
