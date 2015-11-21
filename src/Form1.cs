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
    public mmusForm() {
      InitializeComponent();
    }
    public void mmus() {
      Model model = new Model();
      PotterAlgorithm potter = new PotterAlgorithm(model);
      if (!potter.Work()) {
        MessageBox.Show("Алгоритм не работает.");
      }
      return;
    }
  }
}
