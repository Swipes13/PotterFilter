using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterFilter.src.math {
  public class Matrix2D {
    private double[,] matrix;
    public double this[int i,int j] {
      get { return matrix[i, j]; }
      set { matrix[i, j] = value; }
    }
    public int LenghtX() { return matrix.GetLength(0); }
    public int LenghtY() { return matrix.GetLength(1); }

    public Matrix2D(int size) {
      matrix = new double[size, size];
    }
    public Matrix2D(int sizeX, int sizeY) {
      matrix = new double[sizeX, sizeY];
    }
    public Matrix2D(int sizeX, double[] values) {
      matrix = new double[values.Count() / sizeX, sizeX];
      int i = 0, j = 0;
      foreach(double val in values){
        matrix[i, j] = val;
        j++;
        if (j == sizeX) {
          i++;
          j = 0;
        }
      }
    }
    public double Determinant(){
      switch(matrix.GetLength(0)){
        case 1: return matrix[0,0];
        case 2: return matrix[0,0] * matrix[1,1] - matrix[0,1] * matrix[1,0];
        case 3: return matrix[0,0] * matrix[1,1] * matrix[2,2] + matrix[0,1] * matrix[1,2] * matrix[2,0] + matrix[0,2] * matrix[1,0] * matrix[2,1] 
          - matrix[2,0] * matrix[1,1] * matrix[0,2] - matrix[1,0] * matrix[0,1] * matrix[2,2] - matrix[0,0] * matrix[2,1] * matrix[1,2];
        default :
          return -1.0;
      }
    }
    
    public static Matrix2D Diagonal(double[] dValues) {
      Matrix2D matrix = new Matrix2D(dValues.Count());
      for (int i = 0; i < dValues.Count(); i++) 
        matrix[i, i] = dValues[i];

      return matrix;
    }
    public static bool MultiDistr(double[] expctedValues, Matrix2D correlation, ref Matrix2D result) {
      Random rand = new Random();

      int count = result.LenghtX();
      int mq = result.LenghtY();

      Matrix2D A = new Matrix2D(mq, mq);
      Matrix2D N = new Matrix2D(count, mq);
      Matrix2D K = correlation;

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
      //преобразование матрицы случайных чисел, распределенных по нормальному закону с параметрами 0, 1 к матрице с конечными параметрами
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

    public static bool MultiDistr(double[] expctedValues, double[] dispersion, Matrix2D correlation, ref Matrix2D result) {
      Random rand = new Random();

      int count = result.LenghtX();
      int mq = result.LenghtY();

      Matrix2D A = new Matrix2D(mq, mq);
      Matrix2D N = new Matrix2D(count, mq);
      Matrix2D K = new Matrix2D(mq, mq);

      //Преобразование корреляционной матрицы в ковариационную
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
      //преобразование матрицы случайных чисел, распределенных по нормальному закону с параметрами 0, 1 к матрице с конечными параметрами
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
  }
}
