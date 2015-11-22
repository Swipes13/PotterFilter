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
      int pnlSize = 150;
      pnlTrueData.DataBindings.Add(new Binding("Visible", mnuTrueData, "Checked"));
      pnlGenData.DataBindings.Add(new Binding("Visible", mnuGenData, "Checked"));
      pnlFiltrData.DataBindings.Add(new Binding("Visible", mnuFiltrData, "Checked"));
      pnlFiltrData.DataBindings.Add(new Binding("Size", pnlGenData, "Size"));
      pnlGenData.DataBindings.Add(new Binding("Size", pnlTrueData, "Size"));
      pnlTrueData.Size = new System.Drawing.Size(pnlSize, pnlTrueData.Size.Height);
      mmus();
    }
    public void mmus() {
      try {
        Model model = new Model();
        PotterAlgorithm potter = new PotterAlgorithm(model);
        if (!potter.Work()) {
          MessageBox.Show("Алгоритм не работает.");
          return;
        }
        fillRTBs(model, potter);
      }
      catch (Exception ex) {
        MessageBox.Show(ex.Message,"Error!");
      }

    }

    void fillRTBs(Model mdl, PotterAlgorithm alg) {
      int pbxHeight = 300;
      Plot p1 = new Plot(new System.Drawing.Size(pnlWork.Size.Width - 25, pbxHeight));
      pnlWork.Controls.Add(p1);

      drtbTrue.FillData(mdl.X, mdl.Y_True);
      p1.AddGraph(new Graph(drtbTrue.Verts, new Pen(Color.Green, 2.0f),"True"));
      drtbGen.FillData(mdl.X, mdl.Y);
      p1.AddGraph(new Graph(drtbGen.Verts, new Pen(Color.Red, 2.0f), "Generated"));
      drtbFiltr.FillData(alg.Xtt, alg.Yt);
      p1.AddGraph(new Graph(drtbFiltr.Verts, new Pen(Color.Blue, 2.0f), "Filtered"));

      addRisksX(p1);
      addRisksY(p1);

      p1.Draw();
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
    private void mnuItemClick(object sender, EventArgs e) {
      ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
    }

    private void pnlWork_SizeChanged(object sender, EventArgs e) {
      foreach (Plot p in pnlWork.Controls)
        p.ReSize(new Size(pnlWork.Size.Width - 25,p.Size.Height));
    }

    private void generateToolStripMenuItem_Click(object sender, EventArgs e) {
      mmus();
    }
  }
}
