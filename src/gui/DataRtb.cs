using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotterFilter.src.gui {
  public class DataRtb : RichTextBox {
    public int Rounder = 3;
    public String name;

    private List<double[]> verts = new List<double[]>();
    public double[][] Verts;

    public DataRtb() { }
    public void FillDataX(math.Matrix X) {
      var r = Rounder;
      Text = this.Name + Environment.NewLine;
      for (int i = 0; i < X.LenghtX(); i++) {
        Text += Math.Round(X[i, 0], r).ToString().Replace(',', '.') + "\t";
        Text += Math.Round(X[i, 1], r).ToString().Replace(',', '.') + Environment.NewLine;
      }
    }
    public void FillData(math.Matrix Y) {
      verts.Clear();
      var r = Rounder;
      Text = this.Name + Environment.NewLine;
      for (int i = 0; i < Y.LenghtX(); i++) {
        Text += Math.Round(Y[i, 0], r).ToString().Replace(',', '.') + Environment.NewLine;
        verts.Add(new double[] { i, Y[i, 0] });
      }
      Verts = verts.OrderBy(x => x[0]).ToArray();
    }
    public void FillData(math.Matrix X,math.Matrix Y) {
      verts.Clear();
      var r = Rounder;
      Text = this.Name + Environment.NewLine;
      for (int i = 0; i < Y.LenghtX(); i++) {
        Text += Math.Round(Y[i, 0], r).ToString().Replace(',', '.') + Environment.NewLine;
        verts.Add(new double[] { X[i,0], Y[i, 0] });
      }
      Verts = verts.OrderBy(x => x[0]).ToArray();
    }
  }
}
