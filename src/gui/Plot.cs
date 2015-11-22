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

    public double MinValueX { get { return xMin; } private set { } }
    public double MaxValueX { get { return xMax; } private set { } }
    public double MinValueY { get { return yMin; } private set { } }
    public double MaxValueY { get { return yMax; } private set { } } 

    double xMin = 0.0, xMax = 0.0;
    double deltaX = 0.0;
    double yMin = 0.0, yMax = 0.0;
    double deltaY = 0.0;
    private System.ComponentModel.IContainer components;
    private ContextMenuStrip ctxMnuMain;
    List<Graph> graphs;
    List<Risk> risksX = new List<Risk>();
    List<Risk> risksY= new List<Risk>();

    public Plot(Size size) {
      InitializeComponent();
      Size = size;
      Image = new Bitmap(Size.Width, Size.Height);
      graphs = new List<Graph>();
      graphic = Graphics.FromImage(Image);
      graphic.FillRectangle(new SolidBrush(Color.White), 0, 0, Width, Height);
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
      foreach (Graph g in graphs)
        g.Draw(graphic);
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
    public void AddGraph(Graph graph) {
      graphs.Add(graph);
      if (graph.MinValueX < xMin) { xMin = graph.MinValueX; deltaX = xMax - xMin; }
      if (graph.MaxValueX > xMax) { xMax = graph.MaxValueX; deltaX = xMax - xMin; }
      if (graph.MinValueY < yMin) { yMin = graph.MinValueY; deltaY = yMax - yMin; }
      if (graph.MaxValueY > yMax) { yMax = graph.MaxValueY; deltaY = yMax - yMin; }
      ToolStripMenuItem itm = new ToolStripMenuItem();
      itm.Text = graph.Name;
      itm.Checked = true;
      itm.Click += itm_Click;
      ctxMnuMain.Items.Add(itm);
      reCalcPoints();
    }

    void itm_Click(object sender, EventArgs e) {
      ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
      for (int i = 0; i < graphs.Count; i++) {
        if (graphs[i].Name == ((ToolStripMenuItem)sender).Text) {
          graphs[i].NeedToDraw = ((ToolStripMenuItem)sender).Checked;
          break;
        }
      }
      graphic.FillRectangle(new SolidBrush(Color.White), 0, 0, Width, Height);
      Draw();
      Refresh();
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
      for (int i = 0; i < graphs.Count; i++) 
        for (int p = 0; p < graphs[i].TruePoints.Count; p++) 
          graphs[i].Points[p] = transformCoord(graphs[i].TruePoints[p]);
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
      this.ctxMnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // ctxMnuMain
      // 
      this.ctxMnuMain.Name = "ctxMnuMain";
      this.ctxMnuMain.Size = new System.Drawing.Size(127, 26);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }
    protected override void OnMouseClick(MouseEventArgs e) {
      if(e.Button == System.Windows.Forms.MouseButtons.Right)
        ctxMnuMain.Show(this,e.Location);
    }
  }
}
