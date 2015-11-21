using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotterFilter.src.math;

namespace PotterFilter.src {
  class PotterAlgorithm {
    public Matrix Yt { get { return _Yt; } private set { } }
    public Matrix Xt { get { return _Xt; } private set { } }
    public Matrix Xtt { get { return _Xtt; } private set { } }

    Model model = null;
    Matrix _Yt;
    Matrix _Xt, _Xtt;

    public PotterAlgorithm(Model mdl) {
      if (mdl != null && mdl.DataOK)
        model = mdl;
    }

    public bool Work() {
      if (model == null)
        return false;
      int n = Model.CountObs;

      _Yt = new Matrix(n, 1);
      _Xt = new Matrix(n, 2);
      _Xtt = new Matrix(n, 2);
      Matrix _Pkkt = new Matrix(2, 2);
      Matrix _Pkk1t = new Matrix(2, 2);
      Matrix _Pt = new Matrix(2, 2);
      Matrix _Skkt = new Matrix(2, 2);
      Matrix _Skk1t = new Matrix(2, 2);
      Matrix _Fk = new Matrix(2, 1);
      Matrix _Kk = new Matrix(2, 1);

      _Xtt[0] = model.X0;
      _Yt[0] = model.H * _Xtt[0];
      _Skkt = model.P0.Decompose();

      for (int i = 1; i < n; i++) {
        // экстраполяция
        _Xt[i] = model.Phi * _Xtt[i - 1] + model.Ksi * model.U[i];
        _Skk1t[i] = model.Phi * _Skkt[i];
        _Pkk1t[i] = _Skk1t[i] * _Skk1t[i].Transpose();
        // фильтрация
        _Fk[i] = _Skk1t[i] * model.H.Transpose();
        double alpha_k = Math.Sqrt((_Fk[i].Transpose() * _Fk[i] + model.Rk)[0, 0]);
        double gamma_k = 1 + Math.Sqrt(model.Rk[0, 0] * alpha_k);
        _Kk[i] = alpha_k * _Skk1t[i] * _Fk[i];
        _Xtt[i] = _Xt[i] + _Kk[i].Transpose() * (_Yt[i] - model.H * _Xt[i].Transpose());
        _Skkt[i] = _Skkt[i] * (Matrix.Identity(2) - alpha_k * gamma_k * _Fk[i] * _Fk[i].Transpose());
        _Pkkt[i] = _Skkt[i] * _Skkt[i].Transpose();
        _Yt[i] = model.H * _Xtt[i].Transpose();
      }
      return true;
    }
  }
}
