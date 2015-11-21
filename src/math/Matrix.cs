using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterFilter.src.math {
  public class Matrix {
    private double[,] matrix;
    public Matrix this[int index] {
      get {
        Matrix retVal = new Matrix(1, LenghtY());

        for (int i = 0; i < LenghtY(); i++)
          retVal[0, i] = matrix[index, i];

        return retVal;
      }
      set {
        for (int i = 0; i < value.LenghtY(); i++)
          matrix[index, i] = value[0, i];
      }
    }
    public double this[int i, int j] {
      get { return matrix[i, j]; }
      set { matrix[i, j] = value; }
    }
    public int LenghtX() { return matrix.GetLength(0); }
    public int LenghtY() { return matrix.GetLength(1); }
    public String DimsToString() {
      return "[" + LenghtX() + "," + LenghtY() + "]";
    }

    public Matrix(int size) {
      matrix = new double[size, size];
    }
    public Matrix(int sizeX, int sizeY) {
      matrix = new double[sizeX, sizeY];
    }
    public Matrix(int sizeX, double[] values) {
      matrix = new double[values.Count() / sizeX, sizeX];
      int i = 0, j = 0;
      foreach (double val in values) {
        matrix[i, j] = val;
        j++;
        if (j == sizeX) {
          i++;
          j = 0;
        }
      }
    }
    public double Determinant() {
      switch (matrix.GetLength(0)) {
        case 1: return matrix[0, 0];
        case 2: return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        case 3: return matrix[0, 0] * matrix[1, 1] * matrix[2, 2] + matrix[0, 1] * matrix[1, 2] * matrix[2, 0] + matrix[0, 2] * matrix[1, 0] * matrix[2, 1]
          - matrix[2, 0] * matrix[1, 1] * matrix[0, 2] - matrix[1, 0] * matrix[0, 1] * matrix[2, 2] - matrix[0, 0] * matrix[2, 1] * matrix[1, 2];
        default:
          return -1.0;
      }
    }

    public static Matrix Identity(int dim) {
      Matrix m = new Matrix(dim, dim);
      for (int i = 0; i < dim; i++)
        m[i, i] = 1.0;
      return m;
    }
    public Matrix Transpose() {
      Matrix transpose = new Matrix(LenghtY(), LenghtX());

      for (int i = 0; i < LenghtX(); i++)
        for (int j = 0; j < LenghtY(); j++)
          transpose[j, i] = this.matrix[i, j];

      return transpose;
    }
    public static Matrix Diagonal(double[] dValues) {
      Matrix matrix = new Matrix(dValues.Count());
      for (int i = 0; i < dValues.Count(); i++)
        matrix[i, i] = dValues[i];

      return matrix;
    }
    public static bool MultiDistr(double[] expctedValues, Matrix correlation, ref Matrix result) {
      Random rand = new Random();

      int count = result.LenghtX();
      int mq = result.LenghtY();

      Matrix A = new Matrix(mq, mq);
      Matrix N = new Matrix(count, mq);
      Matrix K = correlation;

      if (K.Determinant() <= 0.0) return false;

      for (int i = 0; i < mq; i++) {
        for (int j = 0; j <= i; j++) {
          double sumA = 0;
          double sumA2 = 0;
          for (int k = 0; k < j; k++) {
            sumA += A[i, k] * A[j, k];
            sumA2 += A[j, k] * A[j, k];
          }
          A[i, j] = (K[i, j] - sumA) / Math.Sqrt(K[j, j] - sumA2);
        }
      }

      for (int i = 0; i < count; i += 2) {
        for (int j = 0; j < mq; j++) {
          N[i, j] = rand.NextGaussianDouble();
          if (i + 1 < count) N[i + 1, j] = rand.NextGaussianDouble();
        }
      }
      for (int i = 0; i < count; i++) {
        for (int j = 0; j < mq; j++) {
          result[i, j] = expctedValues[j];
          for (int k = 0; k < mq; k++) {
            result[i, j] += A[j, k] * N[i, k];
          }
        }
      }
      return true;
    }
    public static bool MultiDistr(double[] expctedValues, double[] dispersion, Matrix correlation, ref Matrix result) {
      Random rand = new Random();

      int count = result.LenghtX();
      int mq = result.LenghtY();

      Matrix A = new Matrix(mq, mq);
      Matrix N = new Matrix(count, mq);
      Matrix K = new Matrix(mq, mq);

      for (int i = 0; i < mq; i++)
        for (int j = 0; j < mq; j++)
          K[i, j] = correlation[i, j] * Math.Sqrt(dispersion[i] * dispersion[j]);

      if (K.Determinant() <= 0.0) return false;

      for (int i = 0; i < mq; i++) {
        for (int j = 0; j <= i; j++) {
          double sumA = 0;
          double sumA2 = 0;
          for (int k = 0; k < j; k++) {
            sumA += A[i, k] * A[j, k];
            sumA2 += A[j, k] * A[j, k];
          }
          A[i, j] = (K[i, j] - sumA) / Math.Sqrt(K[j, j] - sumA2);
        }
      }

      for (int i = 0; i < count; i += 2) {
        for (int j = 0; j < mq; j++) {
          N[i, j] = rand.NextGaussianDouble();
          if (i + 1 < count) N[i + 1, j] = rand.NextGaussianDouble();
        }
      }

      for (int i = 0; i < count; i++) {
        for (int j = 0; j < mq; j++) {
          result[i, j] = expctedValues[j];
          for (int k = 0; k < mq; k++) {
            result[i, j] += A[j, k] * N[i, k];
          }
        }
      }
      return true;
    }

    static public Matrix operator *(Matrix m1, Matrix m2) {
      if (m1.LenghtY() != m2.LenghtX())
        throw new InvalidOperationException("Умножение матриц " + m1.DimsToString() + "*" + m2.DimsToString() + "!");
      Matrix retValue = new Matrix(m1.LenghtX(), m2.LenghtY());

      for (int i = 0; i < m1.LenghtX(); i++)
        for (int j = 0; j < m2.LenghtY(); j++)
          for (int k = 0; k < m1.LenghtY(); k++)
            retValue[i, j] += m1[i, k] * m2[k, j];

      return retValue;
    }
    static public Matrix operator *(double value, Matrix m1) {
      Matrix retValue = new Matrix(m1.LenghtX(), m1.LenghtY());

      for (int i = 0; i < m1.LenghtX(); i++)
        for (int j = 0; j < m1.LenghtY(); j++)
          retValue[i, j] = m1[i, j] * value;

      return retValue;
    }
    static public Matrix operator +(Matrix m1, Matrix m2) {
      if (m1.LenghtX() != m2.LenghtX() || m1.LenghtY() != m2.LenghtY())
        throw new InvalidOperationException("Сложение матриц " + m1.DimsToString() + "+" + m2.DimsToString() + "!");

      Matrix retValue = new Matrix(m1.LenghtX(), m1.LenghtY());

      for (int i = 0; i < m1.LenghtX(); i++)
        for (int j = 0; j < m1.LenghtY(); j++)
          retValue[i, j] = m1[i, j] + m2[i, j];

      return retValue;
    }
    static public Matrix operator -(Matrix m1, Matrix m2) {
      if (m1.LenghtX() != m2.LenghtX() || m1.LenghtY() != m2.LenghtY())
        throw new InvalidOperationException("Вычитание матриц " + m1.DimsToString() + "-" + m2.DimsToString() + "!");

      Matrix retValue = new Matrix(m1.LenghtX(), m1.LenghtY());

      for (int i = 0; i < m1.LenghtX(); i++)
        for (int j = 0; j < m1.LenghtY(); j++)
          retValue[i, j] = m1[i, j] - m2[i, j];

      return retValue;
    }
    public Matrix Decompose() {
      if (LenghtX() != LenghtY())
        throw new InvalidOperationException("Факторизация матрицы размерности " + DimsToString() + "!");

      Matrix ret = new Matrix(LenghtX(), LenghtY());
      for (int i = 0; i < LenghtX(); i++) {

        double temp;
        for (int j = 0; j < i; j++) {
          if (matrix[i, j] != matrix[j,i])
            throw new InvalidOperationException("Факторизация несимметричной матрицы!");
          temp = 0;
          for (int k = 0; k < j; k++) 
            temp += ret[i, k] * ret[j, k];

          ret[i, j] = (matrix[i, j] - temp) / ret[j, j];
        }

        //Находим значение диагонального элемента
        temp = matrix[i,i];
        for (int k = 0; k < i; k++)
          temp -= ret[i, k] * ret[i, k];

        ret[i, i] = Math.Sqrt(temp);
      }
    return ret;
    }
  }
}
