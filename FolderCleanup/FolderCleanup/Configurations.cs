using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderCleanup
{
    public class Configurations
    {
        public class Configuration
        {
            public string configurationName;
            public List<string> deletions = new List<string>();
            public List<string> ignores = new List<string>();

            private static string startConfig = "#config";
            private static string startDelete = "#delete";
            private static string endDelete = "#enddelete";
            private static string startIgnore = "#ignore";
            private static string endIgnore = "#endignore";
            private static string endConfig = "#endconfig";
            public static string EndConfig {
                get { return endConfig;}
            }

            public static string StartConfig { get {return startConfig;} }

            public Configuration(string configurationName)
            {
                this.configurationName = configurationName;
            }

            public Configuration(Configuration configuration)
            {
                configurationName = configuration.configurationName;
                deletions = new List<string>(configuration.deletions);
                ignores = new List<string>(configuration.ignores);
            }

            public Configuration(string[] lines)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];

                    if (line.Contains(startConfig) == true)
                    {
                        int nameStart = 0;
                        for (int j = startConfig.Length; j < line.Length; ++j)
                        {
                            if (line[j] != ' ')
                            {
                                nameStart = j;
                                break;
                            }
                        }

                        configurationName = line.Substring(nameStart, line.Length - nameStart);
                    }
                    else if (line.Contains(startDelete) == true)
                    {
                        string lineString = "";
                        for (int j = i + 1; j < lines.Length; ++j)
                        {
                            line = lines[j];
                            if (line.Contains(endDelete) == false)
                            {
                                lineString += line + '\n';
                            }
                            else
                            {
                                break;
                            }

                            ParseDeletions(lineString);
                        }
                    }
                    else if (line.Contains(startIgnore) == true)
                    {
                        string lineString = "";
                        for (int j = i + 1; j < lines.Length; ++j)
                        {
                            line = lines[j];
                            if (line.Contains(endIgnore) == false)
                            {
                                lineString += line + '\n';
                            }
                            else
                            {
                                break;
                            }

                            ParseIgnores(lineString);
                        }
                    }
                }
            }

            public override string ToString()
            {
                string result = startConfig + " " + configurationName + "\n";

                result += startDelete + "\n";

                result += DeletitonsString();

                result += endDelete + "\n" + startIgnore + "\n";

                result += IgnoresString();

                result += endIgnore + "\n";
                result += endConfig + "\n\n";

                return result;
            }

            public string DeletitonsString()
            {
                string result = "";
                foreach (string deletion in deletions)
                {
                    result += deletion + "\n";
                }

                return result;
            }

            public string IgnoresString()
            {
                string result = "";
                foreach (string ignore in ignores)
                {
                    result += ignore + "\n";
                }

                return result;
            }

            public void ParseDeletions(string textBoxText)
            {
                deletions = new List<string>();
                string[] lines = textBoxText.Split('\n');

                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        deletions.Add(line);
                    }
                }
            }

            public void ParseIgnores(string textBoxText)
            {
                ignores = new List<string>();
                string[] lines = textBoxText.Split('\n');

                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        ignores.Add(line);
                    }
                }
            }
        }

        public Configurations()
        {

        }

        public Configurations(string dataStream)
        {
            string[] streams = dataStream.Split(new string[] {Configuration.EndConfig}, StringSplitOptions.None);

            foreach (string stream in streams)
            {
                if(stream.Contains(Configuration.StartConfig))
                configurations.Add(new Configuration(stream.Split('\n')));
            }
        }

        public Configurations(Configurations configurations)
        {
            foreach (Configuration configuration in configurations.configurations)
            {
                this.configurations.Add(new Configuration(configuration));
            }
        }

        public override string ToString()
        {
            string result = "";

            foreach (Configuration configuration in configurations)
            {
                result += configuration.ToString();
            }

            return result;
        }

        public List<Configuration> configurations = new List<Configuration>();
    }
}
