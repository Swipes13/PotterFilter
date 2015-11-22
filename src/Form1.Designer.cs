namespace PotterFilter
{
  partial class mmusForm
  {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mmusForm));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.spCntMain = new System.Windows.Forms.SplitContainer();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnGen = new System.Windows.Forms.Button();
      this.panel6 = new System.Windows.Forms.Panel();
      this.chbX1 = new System.Windows.Forms.CheckBox();
      this.panel5 = new System.Windows.Forms.Panel();
      this.tbxB = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.tbxP = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.tbxQ = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tbxR = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.panel4 = new System.Windows.Forms.Panel();
      this.tbxX0Y = new System.Windows.Forms.TextBox();
      this.tbxX0X = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.tbxA = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.chbDistU = new System.Windows.Forms.CheckBox();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuX = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuYtrue = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuYgen = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuYfilter = new System.Windows.Forms.ToolStripMenuItem();
      this.plotMain = new PotterFilter.src.gui.Plot();
      this.drtbYFilter = new PotterFilter.src.gui.DataRtb();
      this.drtbYGen = new PotterFilter.src.gui.DataRtb();
      this.drtbYTrue = new PotterFilter.src.gui.DataRtb();
      this.drtbX = new PotterFilter.src.gui.DataRtb();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.spCntMain)).BeginInit();
      this.spCntMain.Panel1.SuspendLayout();
      this.spCntMain.Panel2.SuspendLayout();
      this.spCntMain.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel6.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.plotMain)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(897, 24);
      this.menuStrip1.TabIndex = 4;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // generateToolStripMenuItem
      // 
      this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
      this.generateToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
      this.generateToolStripMenuItem.Text = "Generate";
      this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
      // 
      // spCntMain
      // 
      this.spCntMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spCntMain.Location = new System.Drawing.Point(0, 24);
      this.spCntMain.Name = "spCntMain";
      // 
      // spCntMain.Panel1
      // 
      this.spCntMain.Panel1.Controls.Add(this.panel1);
      // 
      // spCntMain.Panel2
      // 
      this.spCntMain.Panel2.Controls.Add(this.plotMain);
      this.spCntMain.Panel2.Controls.Add(this.drtbYFilter);
      this.spCntMain.Panel2.Controls.Add(this.drtbYGen);
      this.spCntMain.Panel2.Controls.Add(this.drtbYTrue);
      this.spCntMain.Panel2.Controls.Add(this.drtbX);
      this.spCntMain.Panel2.Padding = new System.Windows.Forms.Padding(2);
      this.spCntMain.Panel2.SizeChanged += new System.EventHandler(this.spCntMain_Panel2_SizeChanged);
      this.spCntMain.Size = new System.Drawing.Size(897, 445);
      this.spCntMain.SplitterDistance = 175;
      this.spCntMain.TabIndex = 5;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnGen);
      this.panel1.Controls.Add(this.panel6);
      this.panel1.Controls.Add(this.panel5);
      this.panel1.Controls.Add(this.panel4);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(175, 235);
      this.panel1.TabIndex = 0;
      // 
      // btnGen
      // 
      this.btnGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnGen.Location = new System.Drawing.Point(60, 209);
      this.btnGen.Name = "btnGen";
      this.btnGen.Size = new System.Drawing.Size(106, 23);
      this.btnGen.TabIndex = 5;
      this.btnGen.Text = "Generate";
      this.btnGen.UseVisualStyleBackColor = true;
      this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
      // 
      // panel6
      // 
      this.panel6.Controls.Add(this.chbX1);
      this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel6.Location = new System.Drawing.Point(0, 177);
      this.panel6.Name = "panel6";
      this.panel6.Size = new System.Drawing.Size(175, 28);
      this.panel6.TabIndex = 4;
      // 
      // chbX1
      // 
      this.chbX1.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.chbX1.AutoSize = true;
      this.chbX1.Checked = true;
      this.chbX1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chbX1.Location = new System.Drawing.Point(47, 6);
      this.chbX1.Name = "chbX1";
      this.chbX1.Size = new System.Drawing.Size(78, 17);
      this.chbX1.TabIndex = 0;
      this.chbX1.Text = "observe x1";
      this.chbX1.UseVisualStyleBackColor = true;
      // 
      // panel5
      // 
      this.panel5.Controls.Add(this.tbxB);
      this.panel5.Controls.Add(this.label6);
      this.panel5.Controls.Add(this.tbxP);
      this.panel5.Controls.Add(this.label5);
      this.panel5.Controls.Add(this.tbxQ);
      this.panel5.Controls.Add(this.label4);
      this.panel5.Controls.Add(this.tbxR);
      this.panel5.Controls.Add(this.label3);
      this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel5.Location = new System.Drawing.Point(0, 84);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(175, 93);
      this.panel5.TabIndex = 3;
      // 
      // tbxB
      // 
      this.tbxB.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.tbxB.Location = new System.Drawing.Point(75, 67);
      this.tbxB.Name = "tbxB";
      this.tbxB.Size = new System.Drawing.Size(48, 20);
      this.tbxB.TabIndex = 7;
      this.tbxB.Text = "0.001";
      // 
      // label6
      // 
      this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(56, 70);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(16, 13);
      this.label6.TabIndex = 6;
      this.label6.Text = "b:";
      // 
      // tbxP
      // 
      this.tbxP.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.tbxP.Location = new System.Drawing.Point(75, 46);
      this.tbxP.Name = "tbxP";
      this.tbxP.Size = new System.Drawing.Size(48, 20);
      this.tbxP.TabIndex = 5;
      this.tbxP.Text = "0.001";
      // 
      // label5
      // 
      this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(56, 49);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(16, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "p:";
      // 
      // tbxQ
      // 
      this.tbxQ.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.tbxQ.Location = new System.Drawing.Point(75, 25);
      this.tbxQ.Name = "tbxQ";
      this.tbxQ.Size = new System.Drawing.Size(48, 20);
      this.tbxQ.TabIndex = 3;
      this.tbxQ.Text = "0.001";
      // 
      // label4
      // 
      this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(56, 28);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(16, 13);
      this.label4.TabIndex = 2;
      this.label4.Text = "q:";
      // 
      // tbxR
      // 
      this.tbxR.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.tbxR.Location = new System.Drawing.Point(75, 4);
      this.tbxR.Name = "tbxR";
      this.tbxR.Size = new System.Drawing.Size(48, 20);
      this.tbxR.TabIndex = 1;
      this.tbxR.Text = "0.001";
      // 
      // label3
      // 
      this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(56, 7);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(13, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "r:";
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.tbxX0Y);
      this.panel4.Controls.Add(this.tbxX0X);
      this.panel4.Controls.Add(this.label2);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel4.Location = new System.Drawing.Point(0, 56);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(175, 28);
      this.panel4.TabIndex = 2;
      // 
      // tbxX0Y
      // 
      this.tbxX0Y.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.tbxX0Y.Location = new System.Drawing.Point(109, 4);
      this.tbxX0Y.Name = "tbxX0Y";
      this.tbxX0Y.Size = new System.Drawing.Size(48, 20);
      this.tbxX0Y.TabIndex = 1;
      this.tbxX0Y.Text = "0";
      // 
      // tbxX0X
      // 
      this.tbxX0X.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.tbxX0X.Location = new System.Drawing.Point(60, 4);
      this.tbxX0X.Name = "tbxX0X";
      this.tbxX0X.Size = new System.Drawing.Size(48, 20);
      this.tbxX0X.TabIndex = 1;
      this.tbxX0X.Text = "0";
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(35, 7);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(21, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "x0:";
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.tbxA);
      this.panel3.Controls.Add(this.label1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 28);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(175, 28);
      this.panel3.TabIndex = 1;
      // 
      // tbxA
      // 
      this.tbxA.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.tbxA.Location = new System.Drawing.Point(75, 4);
      this.tbxA.Name = "tbxA";
      this.tbxA.Size = new System.Drawing.Size(91, 20);
      this.tbxA.TabIndex = 1;
      this.tbxA.Text = "5";
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Amplitude:";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.chbDistU);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(175, 28);
      this.panel2.TabIndex = 0;
      // 
      // chbDistU
      // 
      this.chbDistU.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.chbDistU.AutoSize = true;
      this.chbDistU.Location = new System.Drawing.Point(47, 6);
      this.chbDistU.Name = "chbDistU";
      this.chbDistU.Size = new System.Drawing.Size(79, 17);
      this.chbDistU.TabIndex = 0;
      this.chbDistU.Text = "distribute U";
      this.chbDistU.UseVisualStyleBackColor = true;
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuX,
            this.mnuYtrue,
            this.mnuYgen,
            this.mnuYfilter});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // mnuX
      // 
      this.mnuX.Checked = true;
      this.mnuX.CheckState = System.Windows.Forms.CheckState.Checked;
      this.mnuX.Name = "mnuX";
      this.mnuX.Size = new System.Drawing.Size(152, 22);
      this.mnuX.Text = "X";
      this.mnuX.Click += new System.EventHandler(this.mnuX_Click);
      // 
      // mnuYtrue
      // 
      this.mnuYtrue.Checked = true;
      this.mnuYtrue.CheckState = System.Windows.Forms.CheckState.Checked;
      this.mnuYtrue.Name = "mnuYtrue";
      this.mnuYtrue.Size = new System.Drawing.Size(152, 22);
      this.mnuYtrue.Text = "Y true";
      this.mnuYtrue.Click += new System.EventHandler(this.mnuX_Click);
      // 
      // mnuYgen
      // 
      this.mnuYgen.Checked = true;
      this.mnuYgen.CheckState = System.Windows.Forms.CheckState.Checked;
      this.mnuYgen.Name = "mnuYgen";
      this.mnuYgen.Size = new System.Drawing.Size(152, 22);
      this.mnuYgen.Text = "Y gen";
      this.mnuYgen.Click += new System.EventHandler(this.mnuX_Click);
      // 
      // mnuYfilter
      // 
      this.mnuYfilter.Checked = true;
      this.mnuYfilter.CheckState = System.Windows.Forms.CheckState.Checked;
      this.mnuYfilter.Name = "mnuYfilter";
      this.mnuYfilter.Size = new System.Drawing.Size(152, 22);
      this.mnuYfilter.Text = "Y filter";
      this.mnuYfilter.Click += new System.EventHandler(this.mnuX_Click);
      // 
      // plotMain
      // 
      this.plotMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.plotMain.Image = ((System.Drawing.Image)(resources.GetObject("plotMain.Image")));
      this.plotMain.Location = new System.Drawing.Point(367, 2);
      this.plotMain.Name = "plotMain";
      this.plotMain.Size = new System.Drawing.Size(349, 441);
      this.plotMain.TabIndex = 4;
      this.plotMain.TabStop = false;
      // 
      // drtbYFilter
      // 
      this.drtbYFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.drtbYFilter.Dock = System.Windows.Forms.DockStyle.Left;
      this.drtbYFilter.Location = new System.Drawing.Point(292, 2);
      this.drtbYFilter.Name = "drtbYFilter";
      this.drtbYFilter.Size = new System.Drawing.Size(75, 441);
      this.drtbYFilter.TabIndex = 3;
      this.drtbYFilter.Text = "";
      // 
      // drtbYGen
      // 
      this.drtbYGen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.drtbYGen.Dock = System.Windows.Forms.DockStyle.Left;
      this.drtbYGen.Location = new System.Drawing.Point(217, 2);
      this.drtbYGen.Name = "drtbYGen";
      this.drtbYGen.Size = new System.Drawing.Size(75, 441);
      this.drtbYGen.TabIndex = 2;
      this.drtbYGen.Text = "";
      // 
      // drtbYTrue
      // 
      this.drtbYTrue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.drtbYTrue.Dock = System.Windows.Forms.DockStyle.Left;
      this.drtbYTrue.Location = new System.Drawing.Point(142, 2);
      this.drtbYTrue.Name = "drtbYTrue";
      this.drtbYTrue.Size = new System.Drawing.Size(75, 441);
      this.drtbYTrue.TabIndex = 1;
      this.drtbYTrue.Text = "";
      // 
      // drtbX
      // 
      this.drtbX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.drtbX.Dock = System.Windows.Forms.DockStyle.Left;
      this.drtbX.Location = new System.Drawing.Point(2, 2);
      this.drtbX.Name = "drtbX";
      this.drtbX.Size = new System.Drawing.Size(140, 441);
      this.drtbX.TabIndex = 0;
      this.drtbX.Text = "";
      // 
      // mmusForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(897, 469);
      this.Controls.Add(this.spCntMain);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "mmusForm";
      this.ShowIcon = false;
      this.Text = "Potter Filter";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.spCntMain.Panel1.ResumeLayout(false);
      this.spCntMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.spCntMain)).EndInit();
      this.spCntMain.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.plotMain)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
    private System.Windows.Forms.SplitContainer spCntMain;
    private src.gui.DataRtb drtbYGen;
    private src.gui.DataRtb drtbYTrue;
    private src.gui.DataRtb drtbX;
    private src.gui.DataRtb drtbYFilter;
    private src.gui.Plot plotMain;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.CheckBox chbDistU;
    private System.Windows.Forms.TextBox tbxA;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.TextBox tbxX0Y;
    private System.Windows.Forms.TextBox tbxX0X;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.TextBox tbxP;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbxQ;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbxR;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbxB;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel6;
    private System.Windows.Forms.CheckBox chbX1;
    private System.Windows.Forms.Button btnGen;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mnuX;
    private System.Windows.Forms.ToolStripMenuItem mnuYtrue;
    private System.Windows.Forms.ToolStripMenuItem mnuYgen;
    private System.Windows.Forms.ToolStripMenuItem mnuYfilter;
  }
}

