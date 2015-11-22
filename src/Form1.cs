using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PotterFilter.src;
using PotterFilter.src.gui;

namespace PotterFilter {
  public partial class mmusForm : Form {
    public mmusForm() {
      InitializeComponent();
      spCntMain_Panel2_SizeChanged(this, new EventArgs());
      drtbX.DataBindings.Add(new Binding("Visible", mnuX, "Checked"));
      drtbYTrue.DataBindings.Add(new Binding("Visible", mnuYtrue, "Checked"));
      drtbYFilter.DataBindings.Add(new Binding("Visible", mnuYfilter, "Checked"));
      drtbYGen.DataBindings.Add(new Binding("Visible", mnuYgen, "Checked"));
    }
    void fillAll(Model mdl, PotterAlgorithm alg) {
      drtbYTrue.FillData(mdl.Y_True);
      plotMain.ClearGraphs();

      plotMain.AddGraph(new Graph(drtbYTrue.Verts, new Pen(Color.Green, 2.0f), "True"));
      drtbYGen.FillData(mdl.Y);
      plotMain.AddGraph(new Graph(drtbYGen.Verts, new Pen(Color.Red, 2.0f), "Generated"));
      drtbYFilter.FillData(alg.Yt);
      plotMain.AddGraph(new Graph(drtbYFilter.Verts, new Pen(Color.Blue, 2.0f), "Filtered"));
      drtbX.FillDataX(mdl.X);
      plotMain.Draw();
      addRisksX(plotMain);
      addRisksY(plotMain);
      plotMain.Draw();
    }
    private void mmus(bool uConst, double amplitude, double[] x0Expected_, double r, double q, double p, double b, bool x1) {
      try {
        Model model = new Model(uConst, amplitude, x0Expected_,r,q,p,b,x1);
        PotterAlgorithm potter = new PotterAlgorithm(model);
        if (!potter.Work()) {
          MessageBox.Show("Алгоритм не работает.");
          return;
        }
        fillAll(model, potter);
      }
      catch (Exception ex) {
        MessageBox.Show(ex.Message, "Error!");
      }
    }
    private void addRisksY(Plot p) {
      //p.AddRiskY(0.0, true);

      double valueMin = Math.Round(p.MinValueY,1);
      double valueMax = Math.Round(p.MaxValueY,1);

      int stepCount = 5;
      double delta = valueMax - valueMin;
      double step = delta/stepCount;
      for (int i = 0; i < stepCount; i++) {
        p.AddRiskY(valueMin + step * i, true);
      }

      p.AddRiskY(valueMin, true);
      p.AddRiskY(valueMax, true);
    }
    private void addRisksX(Plot p) {
      List<int> drawSX = (new int[] { 0, 5, 10, 15, 20, 24 }).ToList();
      for (int i = 0; i < Model.CountObs; i++) {
        if (!drawSX.Contains(i)) {
          p.AddRiskX(i, false);
          continue;
        }
        p.AddRiskX(i, true);
      }
    }
    private void generateToolStripMenuItem_Click(object sender, EventArgs e) {
      try {
        double a = Convert.ToDouble(tbxA.Text.Replace('.', ','));
        double x0X = Convert.ToDouble(tbxX0X.Text.Replace('.', ','));
        double x0y = Convert.ToDouble(tbxX0Y.Text.Replace('.', ','));
        double r = Convert.ToDouble(tbxR.Text.Replace('.', ','));
        double q = Convert.ToDouble(tbxQ.Text.Replace('.', ','));
        double p = Convert.ToDouble(tbxP.Text.Replace('.', ','));
        double b = Convert.ToDouble(tbxB.Text.Replace('.', ','));

        mmus(chbDistU.Checked, a, new double[] { x0X, x0y }, r, q, p, b, chbX1.Checked);
        plotMain.Refresh();
      }
      catch (Exception ) {
        MessageBox.Show("Incorrect data input!");
      }
    }
    private void spCntMain_Panel2_SizeChanged(object sender, EventArgs e) {
      plotMain.Refresh();
    }
    private void btnGen_Click(object sender, EventArgs e) {
      generateToolStripMenuItem_Click(sender, e);
    }
    private void mnuX_Click(object sender, EventArgs e) {
      ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
    }
  }
}
