namespace VocTreeGUI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLoadSet = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboDetect = new System.Windows.Forms.ComboBox();
            this.labTimer = new System.Windows.Forms.Label();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.comboExtract = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numBranch = new System.Windows.Forms.NumericUpDown();
            this.numPCA = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkReuse = new System.Windows.Forms.CheckBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.labBuildTime = new System.Windows.Forms.Label();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPCA)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadSet
            // 
            this.btnLoadSet.Location = new System.Drawing.Point(581, 12);
            this.btnLoadSet.Name = "btnLoadSet";
            this.btnLoadSet.Size = new System.Drawing.Size(41, 29);
            this.btnLoadSet.TabIndex = 0;
            this.btnLoadSet.Text = "...";
            this.btnLoadSet.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadSet.UseVisualStyleBackColor = true;
            this.btnLoadSet.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(462, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "C:\\Users\\David\\Desktop\\VocTreeDatasets\\Dataset8";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(111, 47);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(79, 87);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start Server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(196, 47);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(79, 87);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop Server";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(42, 518);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(244, 518);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(196, 154);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(446, 518);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(196, 154);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(648, 518);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(196, 154);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(850, 518);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(196, 154);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMain.Image")));
            this.pictureBoxMain.Location = new System.Drawing.Point(350, 56);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(370, 273);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMain.TabIndex = 10;
            this.pictureBoxMain.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(622, 22);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "C:\\Users\\David\\Desktop\\VocTreeDatasets\\Dataset512\\input\\GOPR2584_189_f1320.jpg";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(642, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 25);
            this.button2.TabIndex = 12;
            this.button2.Text = "Browse Image";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 66);
            this.button3.TabIndex = 14;
            this.button3.Text = "Perform Query(s)!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 675);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 675);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 675);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(726, 675);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(927, 675);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 19;
            // 
            // comboDetect
            // 
            this.comboDetect.FormattingEnabled = true;
            this.comboDetect.Items.AddRange(new object[] {
            "SIFT",
            "ORB",
            "SURF",
            "FAST",
            "STAR",
            "BRISK",
            "MSER",
            "GFTT",
            "HARRIS",
            "Dense",
            "SimpleBlob"});
            this.comboDetect.Location = new System.Drawing.Point(0, 20);
            this.comboDetect.Name = "comboDetect";
            this.comboDetect.Size = new System.Drawing.Size(86, 24);
            this.comboDetect.TabIndex = 20;
            this.comboDetect.Text = "SIFT";
            this.comboDetect.SelectedIndexChanged += new System.EventHandler(this.comboDetect_SelectedIndexChanged);
            // 
            // labTimer
            // 
            this.labTimer.AutoSize = true;
            this.labTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labTimer.Font = new System.Drawing.Font("Consolas", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTimer.Location = new System.Drawing.Point(800, 286);
            this.labTimer.Name = "labTimer";
            this.labTimer.Size = new System.Drawing.Size(192, 53);
            this.labTimer.TabIndex = 22;
            this.labTimer.Text = "0000 ms";
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.Enabled = false;
            this.circularProgressBar1.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBar1.InnerColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(6, 21);
            this.circularProgressBar1.MarqueeAnimationSpeed = 5000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.Gainsboro;
            this.circularProgressBar1.OuterMargin = -7;
            this.circularProgressBar1.OuterWidth = 5;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.ProgressWidth = 10;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar1.Size = new System.Drawing.Size(91, 86);
            this.circularProgressBar1.StartAngle = 0;
            this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 24;
            this.circularProgressBar1.Text = "Stopped";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(0);
            this.circularProgressBar1.Value = 50;
            // 
            // comboExtract
            // 
            this.comboExtract.FormattingEnabled = true;
            this.comboExtract.Items.AddRange(new object[] {
            "SIFT",
            "ORB",
            "SURF",
            "BRIEF",
            "BRISK",
            "FREAK"});
            this.comboExtract.Location = new System.Drawing.Point(92, 20);
            this.comboExtract.Name = "comboExtract";
            this.comboExtract.Size = new System.Drawing.Size(86, 24);
            this.comboExtract.TabIndex = 25;
            this.comboExtract.Text = "SIFT";
            this.comboExtract.SelectedIndexChanged += new System.EventHandler(this.comboExtract_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Detection";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(98, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Extraction";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboDetect);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboExtract);
            this.groupBox1.Location = new System.Drawing.Point(378, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 91);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Feature Method";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numHeight);
            this.groupBox2.Controls.Add(this.numBranch);
            this.groupBox2.Location = new System.Drawing.Point(584, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 87);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "VT-Parameter";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(98, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 34);
            this.label11.TabIndex = 28;
            this.label11.Text = "Max\r\nHeight";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 34);
            this.label8.TabIndex = 27;
            this.label8.Text = "Branch\r\nFactror\r\n";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(101, 21);
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(53, 22);
            this.numHeight.TabIndex = 1;
            this.numHeight.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.numHeight_ValueChanged);
            // 
            // numBranch
            // 
            this.numBranch.Location = new System.Drawing.Point(18, 21);
            this.numBranch.Name = "numBranch";
            this.numBranch.Size = new System.Drawing.Size(58, 22);
            this.numBranch.TabIndex = 0;
            this.numBranch.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBranch.ValueChanged += new System.EventHandler(this.numBranch_ValueChanged);
            // 
            // numPCA
            // 
            this.numPCA.Location = new System.Drawing.Point(766, 88);
            this.numPCA.Name = "numPCA";
            this.numPCA.Size = new System.Drawing.Size(53, 22);
            this.numPCA.TabIndex = 30;
            this.toolTip1.SetToolTip(this.numPCA, "Principal Component Analysis\r\nis applied over the extracted descriptors.\r\nDimensi" +
        "ons are reduced to N.");
            this.numPCA.ValueChanged += new System.EventHandler(this.numPCA_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(770, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 17);
            this.label12.TabIndex = 31;
            this.label12.Text = "PCA";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.label12, "Principal Component Analysis\r\nis applied over the extracted descriptors.\r\nDimensi" +
        "ons are reduced to N.");
            // 
            // checkReuse
            // 
            this.checkReuse.AutoSize = true;
            this.checkReuse.Location = new System.Drawing.Point(766, 60);
            this.checkReuse.Name = "checkReuse";
            this.checkReuse.Size = new System.Drawing.Size(79, 21);
            this.checkReuse.TabIndex = 32;
            this.checkReuse.Text = "Reuse?";
            this.toolTip1.SetToolTip(this.checkReuse, "reuses features\r\nif not specified features will be extracted from input files");
            this.checkReuse.UseVisualStyleBackColor = true;
            this.checkReuse.CheckedChanged += new System.EventHandler(this.checkReuse_CheckedChanged);
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(281, 47);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(79, 87);
            this.btnBuild.TabIndex = 33;
            this.btnBuild.Text = "Build VT";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // labBuildTime
            // 
            this.labBuildTime.AutoSize = true;
            this.labBuildTime.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labBuildTime.Location = new System.Drawing.Point(10, 111);
            this.labBuildTime.Name = "labBuildTime";
            this.labBuildTime.Size = new System.Drawing.Size(80, 18);
            this.labBuildTime.TabIndex = 34;
            this.labBuildTime.Text = "0,000 sec";
            this.labBuildTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textOutput
            // 
            this.textOutput.BackColor = System.Drawing.SystemColors.MenuText;
            this.textOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textOutput.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOutput.ForeColor = System.Drawing.Color.Lime;
            this.textOutput.Location = new System.Drawing.Point(1057, -1);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOutput.Size = new System.Drawing.Size(375, 716);
            this.textOutput.TabIndex = 35;
            this.textOutput.Text = "Output";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(784, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 25);
            this.button4.TabIndex = 36;
            this.button4.Text = "Browse Directory";
            this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(740, 66);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(294, 212);
            this.listBox1.TabIndex = 37;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.circularProgressBar1);
            this.groupBox3.Controls.Add(this.btnLoadSet);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.labBuildTime);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Controls.Add(this.btnBuild);
            this.groupBox3.Controls.Add(this.btnStop);
            this.groupBox3.Controls.Add(this.checkReuse);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.numPCA);
            this.groupBox3.Location = new System.Drawing.Point(12, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1039, 142);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Controls.Add(this.labTimer);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.pictureBoxMain);
            this.groupBox4.Location = new System.Drawing.Point(12, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1039, 355);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Query";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 717);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPCA)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadSet;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboDetect;
        private System.Windows.Forms.Label labTimer;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.ComboBox comboExtract;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numBranch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numPCA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkReuse;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label labBuildTime;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

