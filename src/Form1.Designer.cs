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
      this.pnlTrueData = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.pnlGenData = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.pnlFiltrData = new System.Windows.Forms.Panel();
      this.label3 = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTrueData = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuGenData = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFiltrData = new System.Windows.Forms.ToolStripMenuItem();
      this.pnlWork = new System.Windows.Forms.FlowLayoutPanel();
      this.drtbGen = new PotterFilter.src.gui.DataRtb();
      this.drtbFiltr = new PotterFilter.src.gui.DataRtb();
      this.drtbTrue = new PotterFilter.src.gui.DataRtb();
      this.pnlTrueData.SuspendLayout();
      this.pnlGenData.SuspendLayout();
      this.pnlFiltrData.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlTrueData
      // 
      this.pnlTrueData.Controls.Add(this.drtbTrue);
      this.pnlTrueData.Controls.Add(this.label1);
      this.pnlTrueData.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlTrueData.Location = new System.Drawing.Point(0, 24);
      this.pnlTrueData.Name = "pnlTrueData";
      this.pnlTrueData.Padding = new System.Windows.Forms.Padding(2);
      this.pnlTrueData.Size = new System.Drawing.Size(183, 445);
      this.pnlTrueData.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.Location = new System.Drawing.Point(2, 2);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(179, 29);
      this.label1.TabIndex = 1;
      this.label1.Text = "True data";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pnlGenData
      // 
      this.pnlGenData.Controls.Add(this.drtbGen);
      this.pnlGenData.Controls.Add(this.label2);
      this.pnlGenData.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlGenData.Location = new System.Drawing.Point(183, 24);
      this.pnlGenData.Name = "pnlGenData";
      this.pnlGenData.Padding = new System.Windows.Forms.Padding(2);
      this.pnlGenData.Size = new System.Drawing.Size(183, 445);
      this.pnlGenData.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.label2.Dock = System.Windows.Forms.DockStyle.Top;
      this.label2.Location = new System.Drawing.Point(2, 2);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(179, 29);
      this.label2.TabIndex = 1;
      this.label2.Text = "Generated data";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pnlFiltrData
      // 
      this.pnlFiltrData.Controls.Add(this.drtbFiltr);
      this.pnlFiltrData.Controls.Add(this.label3);
      this.pnlFiltrData.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlFiltrData.Location = new System.Drawing.Point(366, 24);
      this.pnlFiltrData.Name = "pnlFiltrData";
      this.pnlFiltrData.Padding = new System.Windows.Forms.Padding(2);
      this.pnlFiltrData.Size = new System.Drawing.Size(183, 445);
      this.pnlFiltrData.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.label3.Dock = System.Windows.Forms.DockStyle.Top;
      this.label3.Location = new System.Drawing.Point(2, 2);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(179, 29);
      this.label3.TabIndex = 1;
      this.label3.Text = "Filtered data";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrueData,
            this.mnuGenData,
            this.mnuFiltrData});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // mnuTrueData
      // 
      this.mnuTrueData.Checked = true;
      this.mnuTrueData.CheckState = System.Windows.Forms.CheckState.Checked;
      this.mnuTrueData.Name = "mnuTrueData";
      this.mnuTrueData.Size = new System.Drawing.Size(154, 22);
      this.mnuTrueData.Tag = "";
      this.mnuTrueData.Text = "True data";
      this.mnuTrueData.Click += new System.EventHandler(this.mnuItemClick);
      // 
      // mnuGenData
      // 
      this.mnuGenData.Checked = true;
      this.mnuGenData.CheckState = System.Windows.Forms.CheckState.Checked;
      this.mnuGenData.Name = "mnuGenData";
      this.mnuGenData.Size = new System.Drawing.Size(154, 22);
      this.mnuGenData.Tag = "";
      this.mnuGenData.Text = "Generated data";
      this.mnuGenData.Click += new System.EventHandler(this.mnuItemClick);
      // 
      // mnuFiltrData
      // 
      this.mnuFiltrData.Checked = true;
      this.mnuFiltrData.CheckState = System.Windows.Forms.CheckState.Checked;
      this.mnuFiltrData.Name = "mnuFiltrData";
      this.mnuFiltrData.Size = new System.Drawing.Size(154, 22);
      this.mnuFiltrData.Tag = "";
      this.mnuFiltrData.Text = "Filtered data";
      this.mnuFiltrData.Click += new System.EventHandler(this.mnuItemClick);
      // 
      // pnlWork
      // 
      this.pnlWork.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlWork.Location = new System.Drawing.Point(549, 24);
      this.pnlWork.MinimumSize = new System.Drawing.Size(1, 1);
      this.pnlWork.Name = "pnlWork";
      this.pnlWork.Size = new System.Drawing.Size(348, 445);
      this.pnlWork.TabIndex = 5;
      this.pnlWork.SizeChanged += new System.EventHandler(this.pnlWork_SizeChanged);
      // 
      // drtbGen
      // 
      this.drtbGen.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.drtbGen.Dock = System.Windows.Forms.DockStyle.Fill;
      this.drtbGen.Location = new System.Drawing.Point(2, 31);
      this.drtbGen.Name = "drtbGen";
      this.drtbGen.Size = new System.Drawing.Size(179, 412);
      this.drtbGen.TabIndex = 2;
      this.drtbGen.Text = "";
      // 
      // drtbFiltr
      // 
      this.drtbFiltr.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.drtbFiltr.Dock = System.Windows.Forms.DockStyle.Fill;
      this.drtbFiltr.Location = new System.Drawing.Point(2, 31);
      this.drtbFiltr.Name = "drtbFiltr";
      this.drtbFiltr.Size = new System.Drawing.Size(179, 412);
      this.drtbFiltr.TabIndex = 3;
      this.drtbFiltr.Text = "";
      // 
      // drtbTrue
      // 
      this.drtbTrue.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.drtbTrue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.drtbTrue.Location = new System.Drawing.Point(2, 31);
      this.drtbTrue.Name = "drtbTrue";
      this.drtbTrue.Size = new System.Drawing.Size(179, 412);
      this.drtbTrue.TabIndex = 3;
      this.drtbTrue.Text = "";
      // 
      // mmusForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(897, 469);
      this.Controls.Add(this.pnlWork);
      this.Controls.Add(this.pnlFiltrData);
      this.Controls.Add(this.pnlGenData);
      this.Controls.Add(this.pnlTrueData);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "mmusForm";
      this.ShowIcon = false;
      this.Text = "Potter Filter";
      this.pnlTrueData.ResumeLayout(false);
      this.pnlGenData.ResumeLayout(false);
      this.pnlFiltrData.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel pnlTrueData;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel pnlGenData;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel pnlFiltrData;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mnuTrueData;
    private System.Windows.Forms.ToolStripMenuItem mnuGenData;
    private System.Windows.Forms.ToolStripMenuItem mnuFiltrData;
    private System.Windows.Forms.FlowLayoutPanel pnlWork;
    private src.gui.DataRtb drtbTrue;
    private src.gui.DataRtb drtbGen;
    private src.gui.DataRtb drtbFiltr;
  }
}

