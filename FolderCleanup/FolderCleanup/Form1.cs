using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation.Runspaces;
using System.Security.AccessControl;

namespace FolderCleanup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigurationComboBox.SelectedIndex = 0;
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string target = dialog.SelectedPath;
                SelectedFolderText.Text = target;
            }
        }

        private void RunCleanupButton_Click(object sender, EventArgs e)
        {
            string target = SelectedFolderText.Text;

            if (target == "")
            {
                MessageBox.Show("Please choose a directory to clean.");
                return;
            }

            string patternRaw = CleanPatternText.Text;

            if (patternRaw == "")
            {
                MessageBox.Show("Please choose a pattern for cleaning.");
                return;
            }

            StartDelete(target, patternRaw);

            //using (PowerShell shellInstance = PowerShell.Create())
            //{
            //    shellInstance.AddScript("cd \"" + target + "\"");
            //    string formatedPattern = FormatPattern(patternRaw);
            //    string argument = "get-childitem -include " + formatedPattern + " -recurse | foreach($_) {remove-item " +
            //                      GetShouldForce() + "$_.fullname }";
            //    shellInstance.AddScript(argument);
            //    shellInstance.Invoke();

            //    if (shellInstance.Streams.Error.Count > 0)
            //    {
            //        string errors = "Error occured:\n";

            //        foreach (ErrorRecord errorRecord in shellInstance.Streams.Error)
            //        {
            //            errors += errorRecord.ToString() + "\n";
            //        }

            //        MessageBox.Show(errors);
            //    }
            //}


        }

        private void StartDelete(string target, string patternRaw)
        {
            string[] patternList = patternRaw.Split('\n');

            RecursiveDelete(target, patternList);
        }

        private void RecursiveDelete(string target, string[] patternList)
        {
            CheckDeleteFolders(target, patternList);
            CheckDeleteFiles(target, patternList);

            string[] dirs = Directory.GetDirectories(target);

            foreach (string dir in dirs)
            {
                RecursiveDelete(dir, patternList);
            }
        }

        private void CheckDeleteFiles(string target, string[] patternList)
        {
            foreach (string pattern in patternList)
            {
                string[] files = Directory.GetFiles(target, pattern, SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    if (ShouldIgnore(file) == false)
                    {
                        File.SetAttributes(file, FileAttributes.Normal);
                        File.Delete(file);
                    }
                   
                }
            }
        }

        private void CheckDeleteFolders(string target, string[] patternList)
        {
            foreach (string pattern in patternList)
            {
                string[] dirs = Directory.GetDirectories(target, pattern, SearchOption.AllDirectories);

                foreach (string dir in dirs)
                {
                    if (ShouldIgnore(dir) == false && (Directory.GetDirectories(dir).Length == 0 && Directory.GetFiles(dir).Length == 0 ||
                        ForceRecursiveCheckbox.Checked == true || 
                        MessageBox.Show("\"" + dir + "\"" + " is not an empty directory, do you really want to delete it?", "Confirm delete", MessageBoxButtons.OKCancel) == DialogResult.OK))
                    {
                        OpenFilePermissions(dir);
                        Directory.Delete(dir, true);
                    }
                }
            }
        }

        private bool ShouldIgnore(string path)
        {
            string[] ignoreList = IgnoreListTextBox.Text.Split('\n');

            foreach (string ignore in ignoreList)
            {
                int startPoint = SelectedFolderText.Text.Length + 1;
                string relativePath = path.Substring(startPoint, path.Length - (startPoint));
                if (CheckIgnore(relativePath, ignore) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckIgnore(string dir, string ignore)
        {
            ignore = ignore.Replace('/', '\\');
            string[] ignoreList = ignore.Split('*');
            dir = dir.Replace('/', '\\');
            int lastItemIndex = 0;
            foreach (string ignoreItem in ignoreList)
            {
                if (ignoreItem != "")
                {
                    int currentItemIndex = dir.IndexOf(ignoreItem, lastItemIndex);

                    if (currentItemIndex != -1 && currentItemIndex >= lastItemIndex)
                    {
                        lastItemIndex = currentItemIndex + ignoreItem.Length;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void OpenFilePermissions(string dir)
        {
            string[] files = Directory.GetFiles(dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
            }

            string[] dirs = Directory.GetDirectories(dir);

            foreach (string nextDir in dirs)
            {
                OpenFilePermissions(nextDir);
            }
        }

        private string GetShouldForce()
        {
            if (ForceRecursiveCheckbox.Checked == true)
            {
                return "-force ";
            }

            return "";
        }

        private string FormatPattern(string patternRaw)
        {
            string[] arguments = patternRaw.Split('\n');

            string result = "";

            foreach (string argument in arguments)
            {
                result += "\"" + argument + "\"" + ", ";
            }

            return result.Substring(0, result.Length - 2);
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConfigurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration_Manager manager = new Configuration_Manager();

            if (manager.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }

    class ConfirmDeleteFolder
    {
        
    }
}
