using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreTable
{
    public partial class Form1 : Form
    {
        public string tekst { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public List<PlayerEntry> ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
            return GetResult(output);
        }

        public List<PlayerEntry> GetResult(string batchresult)
        {
            var input = File.ReadAllText("D:\\sorted_scores.json");
            var result = JsonConvert.DeserializeObject<List<PlayerEntry>>(input);
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// SortTypeOne
            /// SortTypeTwo
            /// SortTypeThree
            /// these 3 .bat files exist already
            try
            {
                var result = ExecuteCommand(@"..\bashfiles\SortTypeOne.bat"); // iets maken dat input "sorteer type" pakt en dan andere donothing.bat uitvoert
                dataGridView1.DataSource = result;
                button1.Text = "Loaded";
            }
            catch(FileNotFoundException)
            {
                button1.Text = "Failed1";
            }
            catch (FileLoadException)
            {
                button1.Text = "Failed2";
            }
        }
    }
}
