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
      this.rtbLog = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // rtbLog
      // 
      this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.rtbLog.Dock = System.Windows.Forms.DockStyle.Left;
      this.rtbLog.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.rtbLog.Location = new System.Drawing.Point(0, 0);
      this.rtbLog.Name = "rtbLog";
      this.rtbLog.Size = new System.Drawing.Size(263, 469);
      this.rtbLog.TabIndex = 0;
      this.rtbLog.Text = "";
      // 
      // mmusForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(789, 469);
      this.Controls.Add(this.rtbLog);
      this.Name = "mmusForm";
      this.ShowIcon = false;
      this.Text = "Potter Filter";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RichTextBox rtbLog;
  }
}

