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
using PotterFilter.src.graphic;

namespace PotterFilter {
  public partial class mmusForm : Form {
    Model model = null;
    PotterAlgorithm potter = null;
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
        model = new Model();
        potter = new PotterAlgorithm(model);
        if (!potter.Work()) {
          MessageBox.Show("Алгоритм не работает.");
          return;
        }
      }
      catch (Exception ex) {
        MessageBox.Show(ex.Message,"Error!");
      }

      fillRtbLog(model, potter);
    }

    void fillRtbLog(Model mdl, PotterAlgorithm alg) {
      int r = 4;
      int pbxHeight = 200;
      Plot p1 = new Plot(new System.Drawing.Size(pnlWork.Size.Width, pbxHeight));
      pnlWork.Controls.Add(p1);

      rtbTrueData.Text = "x1\tx2\ty" + Environment.NewLine;
      List<double[]> pTrueVerts = new List<double[]>();
      for (int i = 0; i < Model.CountObs; i++) {
        rtbGenData.Text += Math.Round(mdl.X[i, 0], r).ToString().Replace(',', '.') + "\t";
        rtbGenData.Text += Math.Round(mdl.X[i, 1], r).ToString().Replace(',', '.') + "\t";
        rtbGenData.Text += Math.Round(mdl.Y_True[i, 0], r).ToString().Replace(',', '.') + Environment.NewLine;
        pTrueVerts.Add(new double[] { i, mdl.Y_True[i, 0] });
      }
      p1.AddPoints(pTrueVerts.OrderBy(x => x[0]).ToArray(), new Pen(Color.Green, 1.8f));

      rtbGenData.Text = "x1\tx2\ty" + Environment.NewLine;
      List<double[]> p1Verts = new List<double[]>();
      for (int i = 0; i < Model.CountObs; i++) {
        rtbGenData.Text += Math.Round(mdl.X[i, 0], r).ToString().Replace(',', '.') + "\t";
        rtbGenData.Text += Math.Round(mdl.X[i, 1], r).ToString().Replace(',', '.') + "\t";
        rtbGenData.Text += Math.Round(mdl.Y[i, 0], r).ToString().Replace(',', '.') + Environment.NewLine;
        p1Verts.Add(new double[] { i, mdl.Y[i, 0] });
      }
      p1.AddPoints(p1Verts.OrderBy(x => x[0]).ToArray(),new Pen(Color.Red,1.8f));

      rtbfiltrData.Text = "x1\tx2\ty" + Environment.NewLine;
      List<double[]> p2Verts = new List<double[]>();
      for (int i = 0; i < Model.CountObs; i++) {
        rtbfiltrData.Text += Math.Round(alg.Xtt[i, 0], r).ToString().Replace(',', '.') + "\t";
        rtbfiltrData.Text += Math.Round(alg.Xtt[i, 1], r).ToString().Replace(',', '.') + "\t";
        rtbfiltrData.Text += Math.Round(alg.Yt[i, 0], r).ToString().Replace(',', '.') + Environment.NewLine;
        p2Verts.Add(new double[] { i, alg.Yt[i, 0] });
      }
      p1.AddPoints(p2Verts.OrderBy(x => x[0]).ToArray(), new Pen(Color.Blue, 1.8f));




      p1.Draw();
    }

    private void mnuItemClick(object sender, EventArgs e) {
      ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
    }

    private void pnlWork_SizeChanged(object sender, EventArgs e) {
      foreach (Plot p in pnlWork.Controls)
        p.ReSize(new Size(pnlWork.Size.Width,p.Size.Height));
    }
  }
}
