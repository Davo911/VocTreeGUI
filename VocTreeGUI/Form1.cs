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
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;

namespace VocTreeGUI
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        picBoxForm picBox;
        PictureBox[] PicVek;
        Label[] lableVek;
        string path;
        List<Process> qProcess;
        Process sProcess, bProcess;
        string TreeParam, reuse, extractor, detector, vtpK, vtpH, pca, ondisk;
        Stopwatch buildTimer;
        List<string> dirList, fileList, files_chk,lstOutput;
        List<int[]> reslist;
        bool isFile, Serv_running,cam;
        List<string[]> pic_result, score_result;
        List<long> times_result = new List<long>();
        Emgu.CV.VideoCapture capture;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
            /*
            foreach (var process in Process.GetProcessesByName("engine")) //Kills Background voctree
            {
                process.Kill();
            }
            */
            setDefaults();


        }

        //extract string between 2 strings
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
        private void setDefaults()
        {

            if (Process.GetProcessesByName("engine").Count() > 0)
            {
                mBtnKill.BackColor = Color.LightCoral;
                mBtnKill.Enabled = true;
            }

            //Default Values
            extractor = "SIFT";
            detector = "SIFT";
            reuse = "";
            pca = "";
            vtpH = "6";
            vtpK = "10";
            Serv_running = false;
            isFile = true;
            labDone.Visible = false;
            cam = false;
            reslist = new List<int[]>();

            //Lists
            dirList = new List<string>();
            fileList = new List<string>();
            files_chk = new List<string>();
            qProcess = new List<Process>();
            pic_result = new List<string[]>();
            score_result = new List<string[]>();
            times_result = new List<long>();
            lstOutput = new List<string>();

            //Lables&PicBoxes
            PicVek = new PictureBox[5];
            lableVek = new Label[5];
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

        }
        private void resetAll()
        {
            labDone.Text = "";
            labAVG.Visible = false;
            labQTime.Visible = false;
            progressBar1.Value = 0;
            fileList.Clear();
            
            files_chk.Clear();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            tableLayoutPanel1.BackColor = Color.White;
            reslist.Clear();

            qProcess.Clear();
            score_result.Clear();
            pic_result.Clear();
            times_result.Clear();
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
            foreach (var minipic in PicVek)
            {
                minipic.Image = null;
            }

        }
        /*
        private void CamLiveView(object sender, EventArgs arg)
        {
            resetAll();
            try
            {
                //Image<Bgr, Byte> img = new Image<Bgr, Byte>(capture.QueryFrame().Bitmap);
                pictureBoxMain.Image = capture.QuerySmallFrame().Bitmap;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }
        */
        private void controlBar(string zustand)
        {
            switch (zustand)
            {
                case "start":
                    circularProgressBar1.InnerColor = Color.FromArgb(0, 186, 31, 31);
                    circularProgressBar1.Value = 65;
                    circularProgressBar1.ProgressColor = Color.FromArgb(255, 66, 244, 83);
                    circularProgressBar1.Text = "Running";
                    circularProgressBar1.Refresh();
                    break;
                case "build":
                    circularProgressBar1.Text = "Building";
                    circularProgressBar1.ProgressColor = Color.FromArgb(0, 66, 244, 83);
                    circularProgressBar1.InnerColor = Color.FromArgb(255, 186, 31, 31);
                    circularProgressBar1.Value = 100;
                    circularProgressBar1.Refresh();
                    break;
                case "stop":
                    circularProgressBar1.InnerColor = Color.FromArgb(0, 186, 31, 31);
                    circularProgressBar1.ProgressColor = Color.FromArgb(0, 255, 128, 0);
                    circularProgressBar1.Text = "Stopped";
                    circularProgressBar1.Refresh();
                    break;
            }
        }
        private void LoadDir(string dpath)
        {
            dirList.Clear();
            stopServ();
            resetAll();
            path = dpath;
            textBox1.Text = path;
            string[] filesInDir = Directory.GetFiles(path); // should get config file
            string[] dirsInDir = Directory.GetDirectories(path); // should get the dirs 

            foreach (string s in dirsInDir)
            {
                string[] stmp = s.Split('\\');
                dirList.Add(stmp[stmp.Length - 1]);
            }
            if (!(dirList.Contains("input")  && dirList.Contains("vocabulary")))
            {
                DialogResult dr = MessageBox.Show("Wrong Folder-structure!\nNeed 'vocabulary'&'input' folder", "No Database");
                textOutput.Text = "No Vocabulary Tree";
                return;
            }
            foreach (string s in filesInDir)
            {
                string[] stmp = s.Split('\\');
                files_chk.Add(stmp[stmp.Length - 1]);
            }
            if (!files_chk.Contains("config.txt"))
            {
                if (MessageBox.Show("Config File Missing\r\nCreate it?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.WriteAllText(path + "\\config.txt", "# settings for database\r\nport=" + numPort.Value);
                }
                else
                {
                    return;
                }
            }
            if (File.Exists(path + "\\data\\voctree_info.xml"))//Folderstructure OK, load Treee Data
            {
                textOutput.Text = LoadVocTreeInfoxml();
                string[] arrLine = File.ReadAllLines(path + "\\config.txt");
                int port = 64003;
                if (Int32.TryParse(arrLine[1].Split('=')[1], out port))
                {
                    numPort.Value = port;
                }

            }
            else
            {
                textOutput.Text = "No Vocabulary Tree\r\nBuild one!";
            }
        }
        private string LoadVocTreeInfoxml()
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

                TreeParam = "Tree Info:\r\n" + temp[8] + "\r\n"
                    + "MAX Height(H)        : " + temp[1] + "\r\n"
                    + "Children by Node(K) : " + temp[0] + "\r\n"
                    + "DB file count            : " + temp[3] + "\r\n"
                    + "Total Nodes             : " + temp[5] + "\r\n"
                    + "Total Leaves             : " + temp[6] + "\r\n"
                    + "Total Descriptors      : " + temp[7] + "\r\n";

                return TreeParam;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Tree Info XML\nError: " + ex.Message);
                return ex.Message;
            }
        }
        private void LoadImage(string path)
        {
            isFile = true;
            resetAll();
            textBox2.Text = path;
            fileList.Add(path);
            pictureBoxMain.Image = new Bitmap(path);
            listBox1.Items.Add(path.Split('\\').Last());
        }
        private void LoadImageFolder(string path)
        {
            isFile = false;
            resetAll();
            textBox2.Text = path;
            fileList = new List<string>(Directory.GetFiles(textBox2.Text, "*", SearchOption.AllDirectories));
            List<string> filenames = new List<string>();//Just FileNames

            var matchingvalues = fileList.Where(stringToCheck => stringToCheck.EndsWith(".jpg")
                                                                || stringToCheck.EndsWith(".JPG")
                                                                || stringToCheck.EndsWith(".jpeg")
                                                                || stringToCheck.EndsWith(".JPEG")
                                                                || stringToCheck.EndsWith(".png")
                                                                || stringToCheck.EndsWith(".PNG")
                                                                || stringToCheck.EndsWith(".bmp")
                                                                || stringToCheck.EndsWith(".BMP"));
            fileList = matchingvalues.ToList<string>();
            filenames = fileList.ToList();
            for (int i = 0; i < filenames.Count; i++)
            {
                filenames[i] = filenames[i].Split('\\').Last();
            }
            labCount.Text = "0/" + filenames.Count.ToString();

            listBox1.DisplayMember = "File";
            listBox1.ValueMember = "Location";
            listBox1.DataSource = filenames;
        }
        private void ProcessOutput(string input)
        {
            try
            {
                //Format the Output to extract the Images
                if (input.Contains("failed"))
                {
                    MessageBox.Show(input.Split('\n')[2]);
                    return;
                }
                String[] matches = new string[5];
                String[] scores = new string[5];
                String[] all_matches = input.Split('\n').Skip(4).ToArray();
                
              
                int time = Int16.Parse(input.Split(':').Last().TrimEnd('\r').TrimEnd('\n'));
                for (int i = 0; all_matches[i] != "\r" && all_matches[i] != "" && i < 5; i++)
                {
                    if (all_matches[0].Split('|').First() == "0")  //NUR FÜR MESSUNG####
                    {
                        string[] temp = all_matches[i+1].Split('|');
                        scores[i] = temp[0];
                        matches[i] = "\\" + temp[2].Remove(0, 1).Replace('/', '\\').TrimEnd('\r');
                    }
                    else
                    {
                        string[] temp = all_matches[i].Split('|');
                        scores[i] = temp[0];
                        matches[i] = "\\" + temp[2].Remove(0, 1).Replace('/', '\\').TrimEnd('\r');
                    }


                }
                //save output
                lstOutput.Add(string.Join("\n", input.Split('\n').Skip(3).ToArray()).Substring(17));


                //Add results to Collection
                score_result.Add(scores);
                pic_result.Add(matches);
                times_result.Add(time);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at ProcessOutput:\n" + ex.Message);
            }
        }
        private void WriteResults()
        {
            //construct QueryInfo
            string QueryInfo = path.Split('\\').Last() + "\r\n\r\n" //Database Name
                                + LoadVocTreeInfoxml() + "\r\n\r\n";//TreeInfo
            if (labAVG.Visible)//Times
            {
                QueryInfo += "\r\n" + "Average Time: " + labAVG.Text + "\r\nTotal Time: " + labQTime.Text + "\r\n";
            }

            //add all results
            foreach (string query in lstOutput)
            {
                QueryInfo += "\r\n" + query + "\r\n#####################################";
            }
            string RDdir = path + "\\results\\ResultsData\\";

            //make ResultsData dir
            if (!Directory.Exists(RDdir))
            {
                Directory.CreateDirectory(RDdir);
            }
            //Write File
            for (int i = 1, j = 1; j == 1; i++)
            {
                if (!File.Exists(RDdir + "query-" + i + ".txt"))
                {
                    File.WriteAllText(RDdir + "query-" + i + ".txt", QueryInfo);
                    j = 0;
                }
            }
        }
        private async void queryImage(string qpath)
        {
            //Starting voctreeQuery as new Process
            //qProcess.Add(new Process());
            Process qProcess = new Process();
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
                qProcess.WaitForExit(2000);
                ProcessOutput(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at queryImage:\n" + ex.Message);
            }
        }
        private async Task ShowResults(bool File)
        {
            try
            {
                metroButton5.Enabled = false;
                if (isFile)//Query File or Directory?
                {
                    times_result.Clear();
                    await Task.Run(() => queryImage(fileList[0]));
                }
                else
                {
                    List<string> output = new List<string>();
                    for (int i = 0; i < fileList.Count; i++)
                    {
                        await Task.Run(() => queryImage(fileList[i]));
                        progressBar1.Value = (100 * (i + 1)) / fileList.Count;
                        labDone.Text = (i + 1) + "/" + fileList.Count;
                    }
                    labQTime.Visible = true;
                    labQTime.Text = times_result.Sum() + "ms";
                    labAVG.Visible = true;
                    labAVG.Text = "Ø" + Math.Round(times_result.Average()) + "ms";

                    //Check and Calculate Prezision
                    for (int i = 0; i < fileList.Count; i++)
                    {
                        int[] res = CheckGroundTruthOx5k(fileList[i], i);
                        for (int j = 0; j < res.Length; j++)
                        {
                            lableVek[j].BackColor = res[j] == 1 ? Color.LightGreen : Color.LightCoral;
                        }
                        reslist.Add(res);
                    }
                    CalcPrecision(reslist);

                }
                //Display everything
                for (int i = 0; i < pic_result[0].Length && pic_result[0][i] != null; i++)
                {
                    //Show first 5 Image Results
                    toolTip1.SetToolTip(PicVek[i], pic_result[0][i]);
                    try
                    {
                        PicVek[i].Image = new Bitmap(path + pic_result[0][i]);
                    }
                    catch (Exception){ }
                    //And the labels
                    lableVek[i].Text = score_result[0][i];
                }
                progressBar1.Value = 100;
                listBox1.SelectedIndex = 0;
                labTimer.Text = times_result[0].ToString() + " ms";
                WriteResults();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error at Show Results:\n" + e.Message);
            }
            metroButton5.Enabled = true;
        }
        private int[] CheckGroundTruthOx5k(string queryfile, int index)
        {
            int[] res = { 0, 0, 0, 0, 0 };
            try
            {
                if (Directory.Exists(path + "\\_GROUNDTRUTH") && pic_result.Count > 0) //is it oxford5k?
                {
                    List<string> gtFiles = new List<string>(Directory.GetFiles(path + "\\_GROUNDTRUTH\\"));
                    List<string> setFiles = new List<string>();
                    string set = queryfile.Substring(0,queryfile.Length - 11).Split('\\').Last();
                    List<string> gts = new List<string>();
                    
                    //identify subset
                    foreach (string file in gtFiles)
                    {
                        if (file.Contains("query")) {
                            //Format: oxc1_all_souls_000013 136.5 34.1 648.5 955.7\n
                            string check = File.ReadAllText(file).Split(' ')[0].Substring(5);
                            // Should get: all_souls_000013
                            if (check == queryfile.Split('\\').Last().Split('.')[0])//Trying to find the set
                            {
                                string[] temp = file.Split('\\').Last().Split('.')[0].Split('_');
                                Array.Resize(ref temp, temp.Length - 1);
                                //this is the set
                                set = string.Join("_", temp);
                            }
                        }
                    }
                    for (int i = 0; i < gtFiles.Count; i++)
                    {
                        if (gtFiles[i].Contains(set) && !gtFiles[i].Contains("query"))
                        {
                            //read all corresponding GT Files
                            gts.AddRange(File.ReadAllText(gtFiles[i]).Split('\n'));
                        }
                    }
                    string s = pic_result[index][0].Split('\\').Last().Split('.')[0];


                    //TOP5
                    for (int i = 0; i < pic_result[index].Length; i++)
                    {
                        s = pic_result[index][i].Split('\\').Last().Split('.')[0];
                        if (gts.Contains(s))
                        {
                            res[i] = 1;
                        }
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at GT-Check: " + ex.Message);
                return null;
            }
        }
        private int[] CheckDAIGroundTruth(string qfile, int index)
        {
            int[] res = { 0, 0, 0, 0, 0 };
            string objID = qfile.Split('\\').Last().Split('_').Last().Split(',').First(); //....\\ASC-E-N0230_2114656,83.jpg
            try
            {
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at GT-Check: " + ex.Message);
                return null;
            }
        }
        private int createDatabase(string task)
        {
            //Starting voctree as new Process

            bProcess = new Process();
            try
            {
                bProcess.StartInfo.FileName = "engine.exe";
                if (task == "update")
                {
                    bProcess.StartInfo.Arguments = "-update " + path;
                }
                else
                {
                    bProcess.StartInfo.Arguments = "-build " + path + " "
                                        + reuse
                                        + "-method " + detector + ":" + extractor + " "
                                        + "-vtp " + vtpK + ":" + vtpH + " "
                                        + pca
                                        + ondisk;
                }
                bProcess.StartInfo.UseShellExecute = false;
                bProcess.StartInfo.RedirectStandardOutput = true;
                bProcess.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                bProcess.StartInfo.RedirectStandardError = true;
                bProcess.StartInfo.CreateNoWindow = true;
                //bProcess.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
                //start Timer
                buildTimer = Stopwatch.StartNew();
                //start Process
                bProcess.Start();
                //bProcess.BeginErrorReadLine();
                bProcess.BeginOutputReadLine();
                string err = bProcess.StandardError.ReadToEnd();
                if (err.Length > 0)
                {
                    throw new Exception(err);
                }
                
                //string output = bProcess.StandardOutput.ReadToEnd();
                bProcess.WaitForExit();
                buildTimer.Stop();
                //MessageBox.Show(getBetween(output, "storing info", "voctree delete"));
                //queryOutput = output;
                return 1;
            }
            catch (Exception ex)
            {
                buildTimer.Reset();
                MessageBox.Show("Error at Creating Database:\r\n" + ex.Message);
                return 0;
            }
        }
        private async void UpdateOrBuild(string task)
        {
            dirList = new List<string>(Directory.GetDirectories(textBox1.Text));
            files_chk = new List<string>(Directory.GetFiles(textBox1.Text));
            if (dirList.Contains(textBox1.Text+"\\vocabulary") && dirList.Contains(textBox1.Text+"\\input") && files_chk.Contains(textBox1.Text+"\\config.txt"))
            {
                controlBar(task);
                int ret = await Task.Run(() => createDatabase(task));
                controlBar("stop");
                
                var time = buildTimer.Elapsed;
                if (time.TotalSeconds > 100)
                {
                    labBuildTime.Text = time.Minutes + " m " + time.Seconds + " s";
                }
                else
                {
                    labBuildTime.Text += time.Seconds + "sec";
                }
                if (File.Exists(path + "\\data\\voctree_info.xml"))
                {
                    textOutput.AppendText("\r\n\r\n\r\n" + LoadVocTreeInfoxml());
                }
            }
            else
            {
                MessageBox.Show("Falsche Ordnerstruktur");
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
                controlBar("stop");
            }
            catch (Exception ex)
            {
                if (ex.Message != "Der Objektverweis wurde nicht auf eine Objektinstanz festgelegt.")
                {
                    MessageBox.Show("Error at startServer:\n" + ex.Message);
                }
            }
        }
        private void stopServ()
        {
            controlBar("stop");
            Serv_running = false;
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
        }
        private void SwitchToAnalyze()
        {
            UCAnalyze ua = new UCAnalyze();
            metroPanel1.Controls.Clear();
            metroPanel1.Controls.Add(ua);
        }
        private void CalcPrecision(List<int[]> reslist)
        {
            int top1 = 0, top5 = 0;
            for (int i = 0; i < reslist.Count; i++)
            {
                top1 += reslist[i][0];
                top5 += reslist[i].Sum() > 0 ? 1 : 0;
            }
            labAccuracy.Visible = true;
            labAccuracy.Text = ((top1 * 100) / reslist.Count) + " %";
            labTOP5.Visible = true;
            labTOP5.Text = ((top5 * 100) / reslist.Count) + " %";
        }

        /*EVENT HANDLER*/
        void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {

            if (!string.IsNullOrWhiteSpace(outLine.Data))
            {
                textOutput.AppendText(outLine.Data+"\r\n");
            }
        }
        private void button1_Click(object sender, EventArgs e)//Load Dataset
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            
            //Saves some time finding the Dataset folder
            string DataSetsFolderPath = "C:\\Users\\David\\Desktop\\Datasets_Bases\\";
            if (Directory.Exists(DataSetsFolderPath))
            {
                ofd.RootFolder = Environment.SpecialFolder.Desktop;
                ofd.SelectedPath = DataSetsFolderPath;
            }
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadDir(ofd.SelectedPath);
            }

        }
        private void btnBuild_Click(object sender, EventArgs e)
        {
            UpdateOrBuild("build");
        }
        private void button3_Click(object sender, EventArgs e)//Query Button
        {
            //Task.Run(() => ShowResults(isFile));

            if (Serv_running)
            {
                labDone.Visible = true;
                lstOutput.Clear();
                pic_result.Clear();
                times_result.Clear();
                score_result.Clear();
                ShowResults(isFile);
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Sollte mit Hreads geläst werden, da sonst neuer prozess hauptprogramm blockiert?
            if (sProcess != null)
            {
                stopServ();
            }
            if (File.Exists(path + "\\starting.lock") && MessageBox.Show("Database locked!\r\nUnlock it?", "Locked", MessageBoxButtons.YesNo) == DialogResult.Yes)
                File.Delete(path + "\\starting.lock");
            Task.Run(() => startServ());
            controlBar("start");
            Serv_running = true;

        }
        private void mBtnPort_Click(object sender, EventArgs e)
        {
            List<string> filesInDir = new List<string>(Directory.GetFiles(path)); // should get config file
            string config = path + "\\config.txt";

            if (filesInDir.Contains(config))
            {
                string[] arrLine = File.ReadAllLines(config);
                arrLine[1] = "port=" + numPort.Value;
                File.WriteAllLines(config, arrLine);
                textOutput.AppendText("\r\nNew Port : " + numPort.Value);
            }
            else
            {
                MessageBox.Show("Missing config.txt!");
            }
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            UpdateOrBuild("update");
        }
        private void metroButton6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Random rand = new Random();
                List<string> files = new List<string>(Directory.GetFiles(fbd.SelectedPath, "*", SearchOption.AllDirectories));
                int filescount = files.Count;
                int k = (int)numericUpDown1.Value;
                for (int i = 1; i <= k; i++)
                {
                    Directory.CreateDirectory(fbd.SelectedPath + "\\" + i);
                    int j = 0;
                    while (j != (filescount/k))
                    {
                        int rn = rand.Next(files.Count);
                        string newdest = fbd.SelectedPath + "\\" + i + "\\" + files[rn].Split('\\').Last();
                        File.Move(files[rn], newdest);
                        files.RemoveAt(rn);
                        j++;
                    }
                }
                
                
            }
        }

        private void ToggleCam_CheckedChanged(object sender, EventArgs e)
        {
            /*
            cam = true ? cam == false : false;

            if (cam)
            {
                capture = new VideoCapture();
                Application.Idle += CamLiveView;
            }
            else
            {
                capture.Dispose();
                capture = null;
                Application.Idle -= CamLiveView;
                pictureBoxMain.Image = null;
            }
            
            */
                
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            var ext = path.Split('.').Last();
            
            if (ext == "jpg"|| ext == "JPG" || ext == "jpeg" || ext == "JPEG" || ext == "png" || ext == "PNG" || ext == "bmp" || ext == "BMP")
            {
                LoadImage(path);
            }
            else if (Directory.Exists(ext))
            {
                LoadDir(path);
            }
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            var ext = path.Split('.').Last();
            if (ext == "jpg" || ext == "JPG" || ext == "jpeg" || ext == "JPEG" || ext == "png" || ext == "PNG" || ext == "bmp" || ext == "BMP")
            {
                e.Effect = DragDropEffects.Link;
            }
            else if (Directory.Exists(ext))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void numPCA_ValueChanged(object sender, EventArgs e) => pca = numPCA.Value == 0 ? "" : "-pca " + numPCA.Value + " ";
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

            if (Directory.Exists(path)){
                LoadImageFolder(path);
            }
        }
        private void numBranch_ValueChanged(object sender, EventArgs e) => vtpK = numBranch.Value.ToString();

        private void checkOnDisk_CheckedChanged(object sender, EventArgs e)
        {
            ondisk = checkOnDisk.Checked ? "-ondisk" : "";
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            LoadDir(@"C:\Users\David\Desktop\Datasets_Bases\oxbuild5k640x480");
            LoadImageFolder(@"C:\Users\David\Desktop\Datasets_Bases\oxbuild5k640x480\queries");
        }

        private void mBtnKill_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("engine")) //Kills Background voctree
            {
                process.Kill();
            }
            mBtnKill.BackColor = Color.LightGreen;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            picBox = new picBoxForm();
            PictureBox source = (PictureBox)sender;
            if (source.Image != null)
            {
                foreach (PictureBox c in picBox.Controls)
                {
                    if (c.Name == "pic1")
                    {
                        c.Image = source.Image;
                    }
                    else if (c.Name == "pic2")
                    {
                        c.Image = pictureBoxMain.Image;
                    }
                }
                picBox.Show(this);
            }
           

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox source = (PictureBox)sender;
            if (source.Image != null)
            {
                picBox.Close();
                picBox.Dispose();
                picBox = null;
            }
        }
        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            SwitchToAnalyze();

        }
        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            if (Directory.Exists(path))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void numHeight_ValueChanged(object sender, EventArgs e) => vtpH = numHeight.Value.ToString();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (fileList.Count > 0)
                {
                    int index = listBox1.SelectedIndex >= 0 ? listBox1.SelectedIndex : 0;
                    pictureBoxMain.Image = new Bitmap(fileList[index]);
                }

                if (pic_result.Count == fileList.Count && listBox1.SelectedIndex != -1)
                {
                    for (int i = 0; i < pic_result[listBox1.SelectedIndex].Length && pic_result[listBox1.SelectedIndex][i] != null; i++)
                    {
                        try
                        {
                            //Show first 5 Image Results
                            PicVek[i].Image = new Bitmap(path + pic_result[listBox1.SelectedIndex][i]);
                        }
                        catch (Exception) { }

                        //And the labels
                        lableVek[i].Text = score_result[listBox1.SelectedIndex][i];
                        //And the Tooltips
                        toolTip1.SetToolTip(PicVek[i], pic_result[listBox1.SelectedIndex][i]);
                    }
                    labTimer.Text = times_result[listBox1.SelectedIndex].ToString() + " ms";
                }
                labCount.Text = listBox1.SelectedIndex + "/" + fileList.Count;

                //check groundtruth
                if (reslist.Count > 0)
                {
                    for (int j = 0; j < reslist[listBox1.SelectedIndex].Length; j++)
                    {
                        lableVek[j].BackColor = reslist[listBox1.SelectedIndex][j] == 1 ? Color.LightGreen : Color.LightCoral;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at Listbox Index Change:"+ex.Message);
            }

        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            //Stop the Server
            stopServ();
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
        private void button2_Click(object sender, EventArgs e)//Browser File
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadImage(ofd.FileName);
            }
        }
        private void button4_Click(object sender, EventArgs e)//Browse Directory
        {
            
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //Saves some time finding the Dataset folder
            string DataSetsFolderPath = "C:\\Users\\David\\Desktop\\Datasets_Bases\\";
            if (Directory.Exists(DataSetsFolderPath))
            {
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                fbd.SelectedPath = DataSetsFolderPath;
            }
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadImageFolder(fbd.SelectedPath);
            }
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            // EventHandler for the X closing of the Form, trying to get rid of the voctree background process
            stopServ();
        }
    }
}
