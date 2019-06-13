namespace VocTreeGUI
{
    partial class UCAnalyze
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAnalyze));
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.imageBox5 = new Emgu.CV.UI.ImageBox();
            this.imageBox6 = new Emgu.CV.UI.ImageBox();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("imageBox1.InitialImage")));
            this.imageBox1.Location = new System.Drawing.Point(410, 14);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(489, 334);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageBox2.Location = new System.Drawing.Point(332, 579);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(209, 135);
            this.imageBox2.TabIndex = 3;
            this.imageBox2.TabStop = false;
            // 
            // imageBox3
            // 
            this.imageBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageBox3.Location = new System.Drawing.Point(549, 579);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(209, 135);
            this.imageBox3.TabIndex = 4;
            this.imageBox3.TabStop = false;
            // 
            // imageBox4
            // 
            this.imageBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageBox4.Location = new System.Drawing.Point(767, 579);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(209, 135);
            this.imageBox4.TabIndex = 5;
            this.imageBox4.TabStop = false;
            // 
            // imageBox5
            // 
            this.imageBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageBox5.Location = new System.Drawing.Point(332, 369);
            this.imageBox5.Name = "imageBox5";
            this.imageBox5.Size = new System.Drawing.Size(319, 204);
            this.imageBox5.TabIndex = 6;
            this.imageBox5.TabStop = false;
            // 
            // imageBox6
            // 
            this.imageBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageBox6.Location = new System.Drawing.Point(657, 369);
            this.imageBox6.Name = "imageBox6";
            this.imageBox6.Size = new System.Drawing.Size(319, 204);
            this.imageBox6.TabIndex = 7;
            this.imageBox6.TabStop = false;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 24;
            this.metroComboBox1.Items.AddRange(new object[] {
            "FAST",
            "HYBRID",
            "BEST"});
            this.metroComboBox1.Location = new System.Drawing.Point(962, 97);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.PromptText = "HYBIRD";
            this.metroComboBox1.Size = new System.Drawing.Size(121, 30);
            this.metroComboBox1.TabIndex = 8;
            this.metroComboBox1.UseSelectable = true;
            // 
            // UCAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.imageBox6);
            this.Controls.Add(this.imageBox5);
            this.Controls.Add(this.imageBox4);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Name = "UCAnalyze";
            this.Size = new System.Drawing.Size(1327, 759);
            this.Load += new System.EventHandler(this.UCAnalyze_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Emgu.CV.UI.ImageBox imageBox3;
        private Emgu.CV.UI.ImageBox imageBox4;
        private Emgu.CV.UI.ImageBox imageBox5;
        private Emgu.CV.UI.ImageBox imageBox6;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
    }
}
