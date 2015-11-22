using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace PotterFilter.src.gui {
  class Plot : PictureBox {
    Pen riskPen = Pens.Black;
    double whiteX = 2.5;
    double whiteY = 0.2;
    Graphics graphic = null;
    List<Pen> pens = new List<Pen>();

    public double MinValueX { get { return xMin; } private set { } }
    public double MaxValueX { get { return xMax; } private set { } }
    public double MinValueY { get { return yMin; } private set { } }
    public double MaxValueY { get { return yMax; } private set { } } 

    double xMin = 0.0, xMax = 0.0;
    double deltaX = 0.0;
    double yMin = 0.0, yMax = 0.0;
    double deltaY = 0.0;
    List<List<PointF>> points;
    private System.ComponentModel.IContainer components;
    private ToolStripMenuItem toolStripMenuItem1;
    private ContextMenuStrip ctxMnuMain;
    List<PointF[]> pointsDraw;
    List<Risk> risksX = new List<Risk>();
    List<Risk> risksY= new List<Risk>();

    public Plot(Size size) {
      InitializeComponent();
      Size = size;
      Image = new Bitmap(Size.Width, Size.Height);
      points = new List<List<PointF>>();
      pointsDraw = new List<PointF[]>();
      graphic = Graphics.FromImage(Image);
      graphic.FillRectangle(new SolidBrush(Color.White), 0, 0, Width, Height);
      ctxMnuMain.Items[0].Click += PlotCtxData_Click;
    }
    public void AddRiskX(double value, bool drawS) {
      var point = new PointF((float)value, -0.1f);
      risksX.Add(new Risk(point, transformCoord(point), true, drawS));
    }
    public void AddRiskY(double value, bool drawS) {
      var point = new PointF(-.5f, (float)value);
      risksY.Add(new Risk(point, transformCoord(point), false, drawS));
    }
    void PlotCtxData_Click(object sender, EventArgs e) {
    }
    public void Draw() {
      for (int i = 0; i < pointsDraw.Count; i++ )
        graphic.DrawLines(pens[i], pointsDraw[i]);
      foreach (Risk r in risksX) 
        r.Draw(graphic, riskPen);
      foreach (Risk r in risksY)
        r.Draw(graphic, riskPen);
    }
    public void ReSize(Size size) {
      Size = size;
      Image = new Bitmap(Size.Width, Size.Height);
      graphic = Graphics.FromImage(Image);
      graphic.FillRectangle(new SolidBrush(Color.White), 0, 0, Width, Height);
      reCalcPoints();
      reCalcRisks();
      Draw();
    }
    public void AddPoints(double[][] points_, Pen pen) {
      points.Add(new List<PointF>());
      pens.Add(pen);
      foreach (double[] point in points_) {
        if (point[0] < xMin) xMin = point[0]; if (point[0] > xMax) xMax = point[0];
        if (point[1] < yMin) yMin = point[1]; if (point[1] > yMax) yMax = point[1];
        deltaX = xMax - xMin + 0.1;
        deltaY = yMax - yMin + 0.1;
        points.Last().Add(new PointF((float)point[0], (float)point[1]));
      }
      reCalcPoints();
    }
    private PointF transformCoord(PointF coord) {
      PointF ret = new PointF();
      var a = deltaX + whiteX*2.0;
      var b = deltaY + whiteY*2.0;
      double scalarX = (coord.X - xMin + whiteX) / a;
      double scalarY = (coord.Y - yMin + whiteY) / b;
      scalarY = 1.0 - scalarY;

      ret.X = ((float)scalarX * Width);
      ret.Y = ((float)scalarY * Height);
      return ret;
    }
    private void reCalcPoints() {
      pointsDraw.Clear();
      for (int i = 0; i < points.Count; i++) {
        pointsDraw.Add(new PointF[points[i].Count]);
        for (int j = 0; j < points[i].Count; j++)
          pointsDraw[i][j] = transformCoord(points[i][j]);
      }
      
    }
    private void reCalcRisks() {
      for (int i = 0; i < risksX.Count; i++) {
        var temp = risksX[i];
        temp.transformPoint = transformCoord(risksX[i].realValuePoint);
        temp.transformPoint.Y = Height - ((float)whiteY) * 100;
        temp.RecalcPoints();
        risksX[i] = temp;
      }
      for (int i = 0; i < risksY.Count; i++) {
        var temp = risksY[i];
        temp.transformPoint = transformCoord(risksY[i].realValuePoint);
        temp.transformPoint.X = ((float)whiteX)*10;
        temp.RecalcPoints();
        risksY[i] = temp;
      }
    }
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ctxMnuMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
      this.toolStripMenuItem1.Text = "Данные...";
      // 
      // ctxMnuMain
      // 
      this.ctxMnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
      this.ctxMnuMain.Name = "ctxMnuMain";
      this.ctxMnuMain.Size = new System.Drawing.Size(127, 26);
      this.ctxMnuMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }
    protected override void OnMouseClick(MouseEventArgs e) {
      if(e.Button == System.Windows.Forms.MouseButtons.Right)
        ctxMnuMain.Show(this,e.Location);
    }
  }
}
