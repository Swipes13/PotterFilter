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

      fillRTBs(model, potter);
    }

    void fillRTBs(Model mdl, PotterAlgorithm alg) {
      int pbxHeight = 200;
      Plot p1 = new Plot(new System.Drawing.Size(pnlWork.Size.Width, pbxHeight));
      pnlWork.Controls.Add(p1);

      drtbTrue.FillData(mdl.X, mdl.Y_True);
      p1.AddPoints(drtbTrue.Verts, new Pen(Color.Green, 1.8f));
      drtbGen.FillData(mdl.X, mdl.Y);
      p1.AddPoints(drtbGen.Verts, new Pen(Color.Red, 1.8f));
      drtbFiltr.FillData(alg.Xtt, alg.Yt);
      p1.AddPoints(drtbFiltr.Verts, new Pen(Color.Blue, 1.8f));
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
