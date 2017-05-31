using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace FolderCleanup
{
    public partial class Form1 : Form
    {
        private string configurationFileName = "configurations.conf";
        private string lastExportPath;
        private Configurations configurations;
        private static string commentPrefix = "##";

        public Form1()
        {
            InitializeComponent();
            ConfigurationComboBox.SelectedIndex = 0;
            SelectedFolderText.Text = Properties.Settings.Default.DefaultPath;
            lastExportPath = Properties.Settings.Default.LastUsedExportPath;

            if (File.Exists(configurationFileName) == true)
            {
                string fileContent = File.ReadAllText(configurationFileName);
                configurations = new Configurations(fileContent);
                ParseConfigs();
            }
            else
            {
                MakeNew();
            }

            try
            {
                ConfigurationComboBox.SelectedIndex = Properties.Settings.Default.LastUsedComboIndex;
            }
            catch (Exception)
            {

                ConfigurationComboBox.SelectedIndex = 0;
            }
            
            ClampComboBox();
            FolderPathTip.SetToolTip(SelectedFolderText, SelectedFolderText.Text);
            ParseConfigs();
            IgnoreListTextBox.Text = "WIP";
        }

        private void ParseConfigs()
        {
            if (configurations != null)
            {
                int selectedIndex = ConfigurationComboBox.SelectedIndex;
                ConfigurationComboBox.Items.Clear();
                foreach (Configurations.Configuration configurationsConfiguration in configurations.configurations)
                {
                    ConfigurationComboBox.Items.Add(configurationsConfiguration.configurationName);
                }
                ConfigurationComboBox.SelectedIndex = selectedIndex;
                ClampComboBox();
                CleanPatternText.Text =
                    configurations.configurations[ConfigurationComboBox.SelectedIndex].DeletitonsString();
                IgnoreListTextBox.Text =
                    configurations.configurations[ConfigurationComboBox.SelectedIndex].IgnoresString();
            } 
        }

        private void SaveLocalConf()
        {
            if (File.Exists(configurationFileName) == true)
            {
                File.Delete(configurationFileName);
            }
            
            string conf = configurations.ToString();

            StreamWriter outstream = File.CreateText(configurationFileName);
            outstream.Write(conf);
            outstream.Close();
            //File.SetAttributes(configurationFileName, FileAttributes.Hidden);
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = SelectedFolderText.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string target = dialog.SelectedPath;
                SelectedFolderText.Text = target;
                FolderPathTip.SetToolTip(SelectedFolderText, SelectedFolderText.Text);
                Properties.Settings.Default.DefaultPath = target;
                Properties.Settings.Default.Save();
                
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

            if (MessageBox.Show("Are you sure you want to remove all items matching the pattern?", "Are you sure?",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                StartDelete(target, patternRaw);
            }
        }

        private void StartDelete(string target, string patternRaw)
        {
            string[] patternList = GetPatternList(patternRaw);

            RecursiveDelete(target, patternList);
        }

        private string[] GetPatternList(string patternRaw)
        {
            List<string> resultList = new List<string>(); 
            foreach (string line in patternRaw.Split('\n'))
            {
                if (line.Length > 1 && line.Substring(0,2) != commentPrefix)
                {
                    resultList.Add(line);
                }
            }
            return resultList.ToArray();
        }

        private void RecursiveDelete(string target, string[] patternList)
        {
            CheckDeleteFolders(target, patternList);
            CheckDeleteFiles(target, patternList);
        }

        private void CheckDeleteFiles(string target, string[] patternList)
        {

            string[] files = GetFiles(target, patternList);

            foreach (string file in files)
            {
                if (ShouldIgnore(file) == false)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
               
            }
            
        }

        private string[] GetFiles(string target, string[] patternList)
        {
            List<string> files = new List<string>();
            foreach (string pattern in patternList)
            {
                string[] localFiles = Directory.GetFiles(target, pattern, SearchOption.AllDirectories);
                files.AddRange(localFiles);
            }

            return files.ToArray();
        }

        private void CheckDeleteFolders(string target, string[] patternList)
        {

            string[] dirs = GetDirs(target,patternList);

            foreach (string dir in dirs)
            {
                if (ShouldIgnore(dir) == false && (Directory.GetDirectories(dir).Length == 0 && Directory.GetFiles(dir).Length == 0 ||
                    ForceRecursiveCheckbox.Checked == true || 
                    MessageBox.Show("\"" + dir + "\"" + " is not an empty directory, do you really want to delete it?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    OpenFilePermissions(dir);
                    Directory.Delete(dir, true);
                }
            }
        }

        private string[] GetDirs(string target, string[] patternList)
        {
            List<string> dirs = new List<string>();
            foreach (string pattern in patternList)
            {
                string[] localDirs = Directory.GetDirectories(target, pattern, SearchOption.AllDirectories);
                dirs.AddRange(localDirs);
            }

            return dirs.ToArray();
        }

        private bool ShouldIgnore(string path)
        {
            string[] ignoreList = IgnoreListTextBox.Text.Split('\n');

            foreach (string ignore in ignoreList)
            {
                if (ignore != "")
                {
                    int startPoint = SelectedFolderText.Text.Length + 1;
                    string relativePath = path.Substring(startPoint, path.Length - (startPoint));
                    if (CheckIgnore(relativePath, ignore) == true)
                    {
                        return true;
                    }
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

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConfigurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration_Manager manager = new Configuration_Manager(new Configurations(configurations));

            if (manager.ShowDialog() == DialogResult.OK)
            {
                configurations = manager.configurations;
                ClampComboBox();
                SaveLocalConf();
                ParseConfigs();
                
            }
        }

        private void ClampComboBox()
        {
            if (ConfigurationComboBox.SelectedIndex < 0)
            {
                ConfigurationComboBox.SelectedIndex = 0;
            }
            else if (ConfigurationComboBox.SelectedIndex > configurations.configurations.Count - 1)
            {
                ConfigurationComboBox.SelectedIndex = configurations.configurations.Count - 1;
            }
        }

        private void CleanPatternText_TextChanged(object sender, EventArgs e)
        {
            RichTextBox textBox = sender as RichTextBox;

            configurations.configurations[ConfigurationComboBox.SelectedIndex].ParseDeletions(textBox.Text);
            SaveLocalConf();
        }

        private void ConfigurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParseConfigs();
            Properties.Settings.Default.LastUsedComboIndex = ConfigurationComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void IgnoreListTextBox_TextChanged(object sender, EventArgs e)
        {
            RichTextBox textBox = sender as RichTextBox;

            configurations.configurations[ConfigurationComboBox.SelectedIndex].ParseIgnores(textBox.Text);
            SaveLocalConf();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    "Are you sure? This will erase all your settings and configurations.\nIf you want to make a new one but keep your old settings, export them first.",
                    "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MakeNew();
            }
        }

        private void MakeNew()
        {
            configurations = new Configurations();
            SaveLocalConf();
            ParseConfigs();
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportDialog dialog = new ExportDialog(configurations);

            dialog.ShowDialog();
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Configuration Files | *.conf";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImportHandler importHandler = new ImportHandler(dialog.FileName, configurations);
                importHandler.Run();
            }
            SaveLocalConf();
            ParseConfigs();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = lastExportPath;
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string target = dialog.SelectedPath;
                Properties.Settings.Default.LastUsedExportPath = target;
                lastExportPath = target;
                ExportTo(target);
                MessageBox.Show("Export finished!");
            }
        }

        private void ExportTo(string targetDir)
        {
            string target = SelectedFolderText.Text;

            if (target == "")
            {
                MessageBox.Show("Please choose a source directory.");
                return;
            }
            else if (Directory.Exists(target) == false)
            {
                MessageBox.Show("Source directory does not exist.");
                return;
            }

            if (Directory.Exists(targetDir) == false)
            {
                MessageBox.Show("Target directory does not exist.");
                return;
            }
            if (Directory.GetFiles(targetDir).Length != 0 || Directory.GetDirectories(targetDir).Length != 0)
            {
                MessageBox.Show("Target directory is not empty.");
                return;
            }

            string patternRaw = CleanPatternText.Text;

            if (patternRaw == "")
            {
                MessageBox.Show("Please choose a pattern for cleaning.");
                return;
            }

            string[] patternList = GetPatternList(patternRaw);

            string[] files = RecursiveGetFiles(target, patternList);

            CopyFiles(targetDir,target, files);
        }

        private void CopyFiles(string targetDir, string sourceDir, string[] files)
        {
            foreach (string file in files)
            {
                string newName = targetDir + file.Replace(sourceDir,"");
                (new FileInfo(newName)).Directory.Create();
                File.Copy(file,newName);
            }
        }

        private string[] RecursiveGetFiles(string target, string[] patternList)
        {
            List<string> ignoreFiles = new List<string>();
            List<string> ignoreDirs = new List<string>();

            foreach (string pattern in patternList)
            {
                ignoreFiles.AddRange(Directory.GetFiles(target,pattern));
                ignoreDirs.AddRange(Directory.GetDirectories(target,pattern));
            }

            string[] dirFiles = Directory.GetFiles(target);

            List<string> files = new List<string>();

            foreach (string dirFile in dirFiles)
            {
                if (ignoreFiles.Contains(dirFile) == false && ShouldIgnore(dirFile) == false)
                {
                    files.Add(dirFile);
                }
            }

            string[] dirDirs = Directory.GetDirectories(target);
            
            List<string> dirs = new List<string>();

            foreach (string dir in dirDirs)
            {
                if (ignoreDirs.Contains(dir) == false && ShouldIgnore(dir) == false)
                {
                    files.AddRange(RecursiveGetFiles(dir, patternList));
                }
            }

            return files.ToArray();
        }
    }

    class ConfirmDeleteFolder
    {
        
    }
}
