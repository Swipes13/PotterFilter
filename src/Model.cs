using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotterFilter.src.math;

namespace PotterFilter.src {
  class Model {
    public const int CountObs = 25;

    public bool DataOK { get { return _initialized; } private set { _initialized = value; } }
    public Matrix P0 { get { return _P0; } private set { } }
    public Matrix X0 { get { return _X[0]; } private set { } }
    public Matrix H { get { return _H; } private set { } }
    public Matrix Phi { get { return _Phi; } private set { } }
    public Matrix Ksi { get { return _Ksi; } private set { } }
    public Matrix U { get { return _U_Control; } private set { } }
    public Matrix Rk { get { return _Rk; } private set { } }

    public Matrix X { get { return _X; } private set { } }
    public Matrix Y { get { return _Y_Observe; } private set { } }
    public Matrix Y_True { get { return _Y_True; } private set { } }

    bool _initialized = false;
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
    Matrix _X, _V_Noize, _Y_Observe, _Y_True, _U_Control, _W_Disturb;

    double[] nullExpected = new double[] { 0.0, 0.0 };
    double[] amplitudeA;
    double[] x0Expected;

    public Model(bool uConst, double amplitude, double[] x0Expected_, double r, double q, double p, double b, bool x1) {
      if(!x1) _H = new Matrix(2, new double[] { 0.0, 1.0 });
      x0Expected = new double[] { x0Expected_[0], x0Expected_[1] };
      amplitudeA = new double[] { amplitude };
      _X = new Matrix(CountObs, 2);
      _Y_True = new Matrix(CountObs, 1);
      _V_Noize = new Matrix(CountObs, 1);
      _Y_Observe = new Matrix(CountObs, 1);
      _U_Control = new Matrix(CountObs, 1);
      _W_Disturb = new Matrix(CountObs, 2);

      _Rk = Matrix.Diagonal(new double[] { r });
      _Qk = Matrix.Diagonal(new double[] { q, q });
      _P0 = Matrix.Diagonal(new double[] { p, p });
      _Bk = Matrix.Diagonal(new double[] { b });

      if (generateData(uConst))
        _initialized = true;
    }
    private bool generateData(bool uConst) {
      Matrix x0 = new Matrix(1, 2);
      if (!uConst)
        for (int i = 0; i < CountObs; i++)
          _U_Control[i, 0] = amplitudeA[0];
      else
        if (Matrix.MultiDistr(amplitudeA, _Bk, ref _U_Control) == false) return false;

      if (Matrix.MultiDistr(x0Expected, _P0, ref x0) == false) return false;

      if (Matrix.MultiDistr(nullExpected, _Rk, ref _V_Noize) == false) return false;
      if (Matrix.MultiDistr(nullExpected, _Qk, ref _W_Disturb) == false) return false;

      _X[0] = x0;
      _Y_Observe[0] = _H * _X[0].Transpose() +_V_Noize[0];

      for (int i = 1; i < CountObs; i++) {
        _X[i] = (_Phi * _X[i - 1].Transpose() + _Ksi * _U_Control[i] + _Г * _W_Disturb[i].Transpose()).Transpose();
        _Y_Observe[i] = _H * _X[i].Transpose() + _V_Noize[i];
        _Y_True[i] = _H * _X[i].Transpose();
      }

      return true;
    }

  }
}
