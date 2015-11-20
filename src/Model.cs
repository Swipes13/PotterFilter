using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotterFilter.src.math;
using System.Windows.Forms;

namespace PotterFilter.src {
  class Model {
    public bool DataOK { get { return _initialized; } private set { _initialized = value; } }
    bool _initialized = false;

    const int countObs = 25;
    Matrix _H = new Matrix(2, new double[] { 1.0, 0.0 });
    Matrix _Г = new Matrix(2, new double[] {
      0.0008682425818, 0.03790917931,
      -0.9477294827, 0.2283233184   
    });
    Matrix _Ksi = new Matrix(1, new double[] { 0.02170606454, -23.69323707 });
    Matrix _Phi = new Matrix(2, new double[] {
      0.01232548830, 0.0008682425818,
      -0.02170606454, 0.05227051732  });

    Matrix _Rk, _Qk, _P0, _Bk;

    Matrix _X = new Matrix(countObs, 2);
    Matrix _V_Noize = new Matrix(countObs, 1);
    Matrix _Y_Observe = new Matrix(countObs, 1);
    Matrix _U_Control = new Matrix(countObs, 1);
    Matrix _W_Disturb = new Matrix(countObs, /*???? 1 ???*/ 2);

    double[] amplitudeA = new double[] { 0.0 };
    double[] nullExpected = new double[] { 0.0, 0.0 };
    double[] x0Expected = new double[] { 0.0, 0.0 };

    public Model() {
      double rkD = 0.001, qkD = 0.001, p0D = 0.001, bkD = 0.001;
      _Rk = Matrix.Diagonal(new double[] { rkD });
      _Qk = Matrix.Diagonal(new double[] { qkD, qkD });
      _P0 = Matrix.Diagonal(new double[] { p0D, p0D });
      _Bk = Matrix.Diagonal(new double[] { bkD });

      try {
        if (generateData())
          _initialized = true;
      }
      catch(Exception ex){
        MessageBox.Show(ex.Message,"Error!");
      }
    }
    private bool generateData() {
      Matrix x0 = new Matrix(1, 2);
      if (Matrix.MultiDistr(amplitudeA, _Bk, ref _U_Control) == false) return false;
      if (Matrix.MultiDistr(x0Expected, _P0, ref x0) == false) return false;

      if (Matrix.MultiDistr(nullExpected, _Rk, ref _V_Noize) == false) return false;
      if (Matrix.MultiDistr(nullExpected, _Qk, ref _W_Disturb) == false) return false;

      _X[0] = x0;
      _Y_Observe[0] = _H * _X[0].Transpose() +_V_Noize[0];

      for (int i = 1; i < countObs; i++) {
        _X[i] = (_Phi * _X[i - 1].Transpose() + _Ksi * _U_Control[i] + _Г * _W_Disturb[i].Transpose()).Transpose();
        _Y_Observe[i] = _H * _X[i].Transpose() + _V_Noize[i];
      }

      return true;
    }

  }
}
