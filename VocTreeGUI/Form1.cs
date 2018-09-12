using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VocTreeGUI
{
    public partial class Form1 : Form
    {
        string path = "C:\\Users\\David\\Desktop\\VocTreeDatasets\\Dataset8", qpath = "C:\\Users\\David\\Desktop\\VocTreeDatasets\\Dataset512\\input\\GOPR2584_189_f1320.jpg";
        Process qProcess,sProcess;
        System.Threading.Thread queryThread, startThread;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.SelectedPath;
                textBox1.Text = path;
                string[] filesInDir = Directory.GetFiles(path); // should get config file
                string[] dirsInDir = Directory.GetDirectories(path); // should get the dirs 
                List<string> dirList = new List<string>(); 
                List<string> fileList = new List<string>();

                foreach (string s in filesInDir)
                {
                    string[] stmp = s.Split('\\');
                    fileList.Add(stmp[stmp.Length - 1]);
                }
                if (!fileList.Contains("config.txt"))
                {
                    MessageBox.Show("Config File Missing");
                }

                foreach (string s in dirsInDir)
                {
                    string[] stmp = s.Split('\\');
                    dirList.Add(stmp[stmp.Length - 1]);
                }
                if (!(dirList.Contains("data") && dirList.Contains("input") && dirList.Contains("results") && dirList.Contains("vocabulary")))
                {
                    DialogResult dr = MessageBox.Show("Database have to be created. Build it now?",
                      "No Database", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            if (dirList.Contains("vocabulary") && dirList.Contains("input") && fileList.Contains("config.txt"))
                            {
                                System.Threading.Thread startThread = new System.Threading.Thread(new System.Threading.ThreadStart(createDatabase));
                                startThread.Start();
                            }
                            else
                            {
                                MessageBox.Show("Something is missing...");
                            }
                                break;
                        case DialogResult.No:
                            break;
                    }
                }

            }

        }
        private static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        private void createDatabase()
        {
            //Starting voctree as new Process
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.FileName = "engine.exe";
                myProcess.StartInfo.Arguments = "-build " + path;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
                //start Process
                myProcess.Start();
                myProcess.BeginErrorReadLine();
                string output = myProcess.StandardOutput.ReadToEnd();
                myProcess.WaitForExit();
                MessageBox.Show(getBetween(output, "storing info", "voctree delete"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void startServ()
        {
            if (sProcess != null)
            {
                sProcess.Close();
                sProcess.Kill();
            }
            //Starting voctreeServer as new Process
            sProcess = new Process();
            try
            {
                sProcess.StartInfo.FileName = "engine.exe";
                sProcess.StartInfo.Arguments = "-start " + path;
                sProcess.StartInfo.UseShellExecute = false;
                sProcess.StartInfo.CreateNoWindow = true;
                sProcess.StartInfo.RedirectStandardOutput = true;
                sProcess.StartInfo.RedirectStandardError = true;
                sProcess.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
                //start Process
                sProcess.Start();
                MessageBox.Show("Server Started");
                sProcess.BeginErrorReadLine();
                string output = sProcess.StandardOutput.ReadToEnd();
                sProcess.WaitForExit();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void stopServ()
        {
            if (sProcess != null)
            {
                startThread.Abort();
                sProcess.Kill();
            }
                
        }

        private void queryImage()
        {
            if (qProcess != null)
            {
                qProcess.Close();
                qProcess.Kill();
            }
            //Starting voctreeQuery as new Process
            qProcess = new Process();
            try
            {
                qProcess.StartInfo.FileName = "engine.exe";
                qProcess.StartInfo.Arguments = "-query " + path + " " + qpath;
                qProcess.StartInfo.UseShellExecute = false;
                qProcess.StartInfo.CreateNoWindow = true;
                qProcess.StartInfo.RedirectStandardOutput = true;
                qProcess.StartInfo.RedirectStandardError = true;
                qProcess.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
                //start Process
                qProcess.Start();
                qProcess.BeginErrorReadLine();
                string output = qProcess.StandardOutput.ReadToEnd();
                qProcess.WaitForExit();

                //Format the Output to extract the Images
                String[] matches = output.Split('\n').Skip(4).ToArray();
                String[] scores = new string[5];
                Label[] lableVek = new Label[5];
                PictureBox[] PicVek = new PictureBox[5];
                lableVek[0] = label3;
                lableVek[1] = label4;
                lableVek[2] = label5;
                lableVek[3] = label6;
                lableVek[4] = label7;
                PicVek[0] = pictureBox1;
                PicVek[1] = pictureBox2;
                PicVek[2] = pictureBox3;
                PicVek[3] = pictureBox4;
                PicVek[4] = pictureBox5;

                for (int i = 0; matches[i] != "\r" && matches[i] != ""; i++){
                    string[] temp = matches[i].Split(',');
                    scores[i] = temp[0];
                    matches[i] = temp[2].Remove(0,1).Replace('/','\\');
                    //Show first 5 Image Results
                    PicVek[i].Image = new Bitmap(path + matches[i]);
                    //And top weights
                    lableVek[i].Text = scores[i];
                }


                

                
                
                MessageBox.Show(path + matches[0]);

                qProcess.Close();
                qProcess.Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Sollte mit Hreads geläst werden, da sonst neuer prozess hauptprogramm blockiert?
            startThread = new System.Threading.Thread(new System.Threading.ThreadStart(startServ));
            startThread.Start();
        }

        static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!string.IsNullOrWhiteSpace(outLine.Data)){
                MessageBox.Show(outLine.Data);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            startThread = new System.Threading.Thread(new System.Threading.ThreadStart(stopServ));
            startThread.Start();
            MessageBox.Show("Server Stopped!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Threading.Thread queryThread = new System.Threading.Thread(new System.Threading.ThreadStart(queryImage));
            queryThread.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            path = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            qpath = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                qpath = ofd.FileName;
                textBox2.Text = qpath;
                pictureBoxMain.Image = new Bitmap(qpath);
            }
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            // EventHandler for the X closing of the Form, trying to get rid of the voctree background process
            stopServ();
            Environment.Exit(Environment.ExitCode);
        }
    }
}
