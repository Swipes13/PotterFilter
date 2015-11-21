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
      rtbTrueData.Text = "x1\tx2\ty" + Environment.NewLine;
      
      rtbGenData.Text = "x1\tx2\ty" + Environment.NewLine;
      int r = 4;
      for (int i = 0; i < Model.CountObs; i++) {
        rtbGenData.Text += Math.Round(mdl.X[i, 0], r).ToString().Replace(',', '.') + "\t";
        rtbGenData.Text += Math.Round(mdl.X[i, 1], r).ToString().Replace(',', '.') + "\t";
        rtbGenData.Text += Math.Round(mdl.Y[i, 0], r).ToString().Replace(',', '.') + Environment.NewLine;
          
      }
      rtbfiltrData.Text = "x1\tx2\ty" + Environment.NewLine;
      for (int i = 0; i < Model.CountObs; i++) {
        rtbfiltrData.Text += Math.Round(alg.Xtt[i, 0], r).ToString().Replace(',', '.') + "\t";
        rtbfiltrData.Text += Math.Round(alg.Xtt[i, 1], r).ToString().Replace(',', '.') + "\t";
        rtbfiltrData.Text += Math.Round(alg.Yt[i, 0], r).ToString().Replace(',', '.') + Environment.NewLine;
      }
    }

    private void mnuItemClick(object sender, EventArgs e) {
      ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
    }
  }
}
