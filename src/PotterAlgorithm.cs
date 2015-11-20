using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterFilter.src {
  class PotterAlgorithm {
    Model model = null;

    PotterAlgorithm(Model mdl) {
      if (mdl != null && mdl.DataOK)
        model = mdl;
    }

    bool Work() {
      if (model == null)
        return false;


      return true;
    }
  }
}
