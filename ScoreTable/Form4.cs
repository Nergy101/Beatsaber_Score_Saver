using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreTable
{
    public partial class Form4 : Form
    {
        public string tekst { get; set; }
        
        public Form4()
        {
            InitializeComponent();
            //dataGridView1.BackgroundColor = Color.Transparent;
            pictureBox1.ImageLocation = @"C:\Users\chris\Downloads\Beatsaber_background_Clear.png";
            GoFullscreen(true);

        }

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                //this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        string jsonstring = "";

        private void run_cmd(string sortType, string loadPath)       // path from within solution: ..\\..\\..\\ScoreSorter\\                 path below is from within Release folder
        {
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe", "/c " + "dist\\battlesorter.exe " + sortType + " " + loadPath);
            start.CreateNoWindow = true;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    jsonstring = (result);
                }
            }
        }



        private async Task load()
        {
            string inputSortType = ErrorBox.Text;
            string loadPath = LoadPathBox.Text;
            try
            {
                run_cmd(inputSortType, loadPath); // fills jsonstring
                //var input = File.ReadAllText("D:\\sorted_scores.json");
                var result = JsonConvert.DeserializeObject<List<PlayerEntry>>(jsonstring);

                List<int> scores = new List<int>();
                dataGridView1.DataSource = result;
                result.ForEach(pe => scores.Add(pe._score));
                scores.Sort();
                scores.Reverse();
                textBox1.Text = scores[0].ToString();
                textBox2.Text = scores[1].ToString();
                textBox3.Text = scores[2].ToString();
            }
            catch (FileNotFoundException)
            {
                ErrorBox.Visible = true;
                ErrorBox.Text = "FileNotFoundEx";
                //"Failed1";
            }
            catch (FileLoadException)
            {
                // "Failed2";

                ErrorBox.Visible = true;
                ErrorBox.Text = "FileLoadEx";
            }
            await Task.Delay(180000);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await load();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void label1_Click(object sender, EventArgs e)
        {
            label2.BackColor = Color.Gray;
            label1.BackColor = Color.Green;
            ErrorBox.Text = "1";
            await load();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private async void label2_Click_1(object sender, EventArgs e)
        {
            label1.BackColor = Color.Gray;
            label2.BackColor = Color.Green;
            ErrorBox.Text = "2";
            await load();
        }

        bool refresh = false;
        private async void button1_Click_2(object sender, EventArgs e)
        {
            refresh = (refresh == false) ? refresh = true : refresh = false;
            if (refresh)
            {
                button1.BackColor = Color.Green;
                while (refresh)
                {   
                   await load();
                }
            }
            button1.BackColor = Color.Red;
        }
    }
}
