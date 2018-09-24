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
using System.Xml;

namespace VocTreeGUI
{
    public partial class Form1 : Form
    {
        string path = "C:\\Users\\David\\Desktop\\VocTreeDatasets\\Dataset8";
        Process qProcess,sProcess, bProcess;
        Task startTask;
        string TreeParam, queryOutput, reuse, extractor, detector,vtpK,vtpH,pca;
        Stopwatch queryTimer, buildTimer;
        List<string> dirList, fileList,files_chk;
        bool isFile;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
            foreach (var process in Process.GetProcessesByName("engine"))
            {
                process.Kill();
            }
            //DEFAULTS
            extractor = "SIFT";
            detector = "SIFT";
            reuse = "";
            pca = "";
            vtpH = "6";
            vtpK = "10";
            dirList = new List<string>();
            fileList = new List<string>();
            files_chk = new List<string>();
        }
        private void button1_Click(object sender, EventArgs e)//Load Dataset
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.SelectedPath;
                textBox1.Text = path;
                string[] filesInDir = Directory.GetFiles(path); // should get config file
                string[] dirsInDir = Directory.GetDirectories(path); // should get the dirs 

                foreach (string s in filesInDir)
                {
                    string[] stmp = s.Split('\\');
                    files_chk.Add(stmp[stmp.Length - 1]);
                }
                if (!files_chk.Contains("config.txt"))
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
                    DialogResult dr = MessageBox.Show("Missing Database!\nIt have to be created.", "No Database");
                    textOutput.Text = "No Vocabulary Tree";
                }
                else if(File.Exists(path+ "\\data\\voctree_info.xml"))//Folderstructure OK, load Treee Data
                {
                    try
                    {
                        XmlDocument xdoc = new XmlDocument();
                        xdoc.Load(path + "\\data\\voctree_info.xml");
                        List<string> temp = new List<string>();
                        foreach (XmlNode node in xdoc.DocumentElement.ChildNodes)
                        {
                            temp.Add(node.InnerText);
                        }
                        using (StreamReader sr = new StreamReader(path + "\\data\\method.txt"))
                        {
                            temp.Add(sr.ReadToEnd());
                        }

                        TreeParam =  "Tree Info:\r\n" + temp[8] + "\r\n"
                            + "MAX Height(H)      : " + temp[1] + "\r\n"
                            + "Children by Node(K): " + temp[0] + "\r\n"
                            + "DB file count      : " + temp[3] + "\r\n"
                            + "Total Nodes        : " + temp[5] + "\r\n"
                            + "Total Leaves       : " + temp[6] + "\r\n"
                            + "Total Descriptors  : " + temp[7] + "\r\n";
                        textOutput.Text = TreeParam;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error Loading Tree Info XML\nError: " + ex.Message);
                    }
                }

            }

        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            
            if (dirList.Contains("vocabulary") && dirList.Contains("input") && files_chk.Contains("config.txt"))
            {
                controlBar("build");
                Task<int> buildTask = Task.Run( () => createDatabase());
                buildTask.Wait();
                buildTimer.Stop();
                controlBar("stop");
                textOutput.Text = queryOutput;
                labBuildTime.Text = Math.Round((((double)buildTimer.Elapsed.TotalMilliseconds) / 1000), 3) + "sec";
                
            }
            else
            {
                MessageBox.Show("Falsche Ordnerstruktur");
            }
        }
        private static string getBetween(string strSource, string strStart, string strEnd) //extract string between 2 strings
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

        private int createDatabase()
        {
            //Starting voctree as new Process
            
            bProcess = new Process();
            try
            {
                bProcess.StartInfo.FileName = "engine.exe";
                bProcess.StartInfo.Arguments = "-build " + path + " " 
                    + reuse 
                    + "-method " + detector + ":" + extractor + " " 
                    + "-vtp " + vtpK + ":" + vtpH + " "
                    + pca;
                //bProcess.StartInfo.UseShellExecute = false;
                //bProcess.StartInfo.RedirectStandardOutput = true;
                //bProcess.StartInfo.RedirectStandardError = true;
                //bProcess.StartInfo.CreateNoWindow = true;
                //bProcess.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
                //start Timer
                buildTimer = Stopwatch.StartNew();
                //start Process
                bProcess.Start();
                //bProcess.BeginErrorReadLine();
                //string output = bProcess.StandardOutput.ReadToEnd();
                bProcess.WaitForExit();
                //MessageBox.Show(getBetween(output, "storing info", "voctree delete"));
                //queryOutput = output;
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        private void controlBar(string zustand)
        {
            switch (zustand)
            {
                case "start":
                    circularProgressBar1.Value = 65;
                    circularProgressBar1.ProgressColor = Color.FromArgb(66, 244, 83);
                    circularProgressBar1.Text = "Running";
                    circularProgressBar1.Refresh();
                    break;
                case "build":
                    circularProgressBar1.Text = "Building";
                    circularProgressBar1.ProgressColor = Color.FromArgb(186, 31, 31);
                    circularProgressBar1.Value = 100;
                    circularProgressBar1.Refresh();
                    break;
                case "stop":
                    circularProgressBar1.ProgressColor = Color.FromArgb(0, 255, 128, 0);
                    circularProgressBar1.Text = "Stopped";
                    circularProgressBar1.Refresh();
                    break;
            }
        }
        private void startServ()
        {
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
                sProcess.BeginErrorReadLine();
                string output = sProcess.StandardOutput.ReadToEnd();
                sProcess.WaitForExit();
                queryOutput = output;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void stopServ()
        {
            controlBar("stop");
            if (sProcess != null && !sProcess.HasExited) 
            {
                sProcess.Kill();
                sProcess = null;
            }
            if (bProcess != null && !bProcess.HasExited)
            {
                bProcess.Kill();
                bProcess = null;
            }

            if (startTask != null)
            {
                startTask = null;
            }
            
                
        }
        private int queryImage(string qpath)
        {
            
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
                queryTimer = Stopwatch.StartNew();
                qProcess.Start();
                qProcess.BeginErrorReadLine();
                string output = qProcess.StandardOutput.ReadToEnd();
                qProcess.WaitForExit();
                queryTimer.Stop();
                queryOutput = output;
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        private void ShowResults()
        {
            try
            {
                //Format the Output to extract the Images
                String[] matches = queryOutput.Split('\n').Skip(4).ToArray();
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

                for (int i = 0; matches[i] != "\r" && matches[i] != "" && i < 5; i++)
                {
                    string[] temp = matches[i].Split(',');
                    scores[i] = temp[0];
                    matches[i] = temp[2].Remove(0, 1).Replace('/', '\\');
                    //Show first 5 Image Results
                    PicVek[i].Image = new Bitmap(path + matches[i]);
                    //And top weights
                    lableVek[i].Text = scores[i];
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Sollte mit Hreads geläst werden, da sonst neuer prozess hauptprogramm blockiert?
            if (startTask != null && sProcess != null) {
                stopServ();
            }
            startTask = new Task(startServ);
            startTask.Start();
            controlBar("start");

        }

        private void numPCA_ValueChanged(object sender, EventArgs e) => pca = numPCA.Value == 0 ? "" : "-pca " + numPCA.Value + " ";
        private void numBranch_ValueChanged(object sender, EventArgs e) => vtpK = numBranch.Value.ToString();
        private void numHeight_ValueChanged(object sender, EventArgs e) => vtpH = numHeight.Value.ToString();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxMain.Image = new Bitmap(fileList[listBox1.SelectedIndex]);
        }
        static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!string.IsNullOrWhiteSpace(outLine.Data)){
                MessageBox.Show(outLine.Data);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            //Stop the Server
            stopServ();
        }
        private void button3_Click(object sender, EventArgs e)
        { //Query Button
            if (isFile)//File or Directory loaded?
            {
                Task<int> queryTask = Task.Run(() => queryImage(textBox2.Text));
                queryTask.Wait();
                ShowResults();
                labTimer.Text = queryTimer.ElapsedMilliseconds.ToString() + " ms";
            }
            else
            {
                List<Task<int>> tasks = new List<Task<int>>();
                foreach (string f in fileList)
                {
                    tasks.Add(Task.Run(() => queryImage(f)));
                    Task<int> queryTask = Task.Run(() => queryImage(f));
                }

            }
        }
        private void comboDetect_SelectedIndexChanged(object sender, EventArgs e)
        {
            detector = comboDetect.Text;
        }
        private void comboExtract_SelectedIndexChanged(object sender, EventArgs e)
        {
            extractor = comboExtract.Text;
        }
        private void checkReuse_CheckedChanged(object sender, EventArgs e)
        {
            if (checkReuse.Checked == false)
            {
                reuse = "";
            }
            else
            {
                reuse = "-reuse ";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)//Browser File
        {
            isFile = true;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
                
                pictureBoxMain.Image = new Bitmap(textBox2.Text);
            }
        }
        private void button4_Click(object sender, EventArgs e)//Browse Directory
        {
            isFile = false;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
                fileList = new List<string>(Directory.GetFiles(textBox2.Text, "*", SearchOption.AllDirectories));
                List<string> filenames = new List<string>();//Just FileNames
                for(int i = 0; i < fileList.Count; i++)
                {
                    string ext = fileList[i].Split('.')[(fileList[i].Split('.').Length - 1)];
                    if (ext != "jpg" && ext != "jpeg" && ext != "png" && ext != "bmp")
                    {
                        fileList.RemoveAt(i);
                    }
                    else
                    {
                        filenames.Add(fileList[i].Split('\\').Last());
                    }
                }

                listBox1.DisplayMember = "File";
                listBox1.ValueMember = "Location";
                listBox1.DataSource = filenames;
            }
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            // EventHandler for the X closing of the Form, trying to get rid of the voctree background process
            stopServ();
        }
    }
}
