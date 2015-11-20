using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotterFilter.src.math;

namespace PotterFilter.src {
  class Model {
    const int countObs = 25;

    Matrix2D _Rk, _Qk, _P0, _Bk;
    Matrix2D nu = new Matrix2D(1, 2);
    Matrix2D omega = new Matrix2D(1, 2);
    Matrix2D x0 = new Matrix2D(1, 2);

    Matrix2D _X = new Matrix2D(countObs, 2);
    Matrix2D _V_Noize = new Matrix2D(1, countObs);
    Matrix2D _Y_Observe = new Matrix2D(1, countObs);
    Matrix2D _U_Control = new Matrix2D(1, countObs);

    double[] nullExpected = new double[]{ 0.0, 0.0};
    double[] x0Expected = new double[] { 0.0, 0.0 };

    public Model() {
      double rkD = 0.001, qkD = 0.001, p0D = 0.001, bkD = 0.001;
      _Rk = Matrix2D.Diagonal(new double[] { rkD, rkD });
      _Qk = Matrix2D.Diagonal(new double[] { qkD, qkD });
      _P0 = Matrix2D.Diagonal(new double[] { p0D, p0D });
      _Bk = Matrix2D.Diagonal(new double[] { bkD, bkD });

      GenerateData();
    }
    bool GenerateData() {
      if (Matrix2D.MultiDistr(nullExpected, _Rk, ref nu) == false) return false;
      if (Matrix2D.MultiDistr(nullExpected, _Qk, ref omega) == false) return false;
      if (Matrix2D.MultiDistr(x0Expected, _P0, ref x0) == false) return false;

      return true;
    }

  }
}
