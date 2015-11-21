using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace PotterFilter.src.graphic {
  class Plot : PictureBox {
    Graphics graphic = null;
    Pen pen = new Pen(Color.Red, 1.0f);
    
    double xMin = 0.0, xMax = 0.0;
    double deltaX = 0.0;
    double yMin = 0.0, yMax = 0.0;
    double deltaY = 0.0;
    List<PointF> points;
    PointF[] pointsDraw;

    public Plot(Size size) {
      Size = size;
      Image = new Bitmap(Size.Width, Size.Height);
      points = new List<PointF>();
      graphic = Graphics.FromImage(Image);
      graphic.FillRectangle(new SolidBrush(Color.White), 0, 0, Width, Height);
    }
    public void Draw() {
      graphic.DrawLines(pen, pointsDraw);
    }
    public void ReSize(Size size) {
      Size = size;
      Image = new Bitmap(Size.Width, Size.Height);
      graphic = Graphics.FromImage(Image);
      graphic.FillRectangle(new SolidBrush(Color.White), 0, 0, Width, Height);
      reCalcPoints();
      Draw();
    }

    public void AddPoint(double[] point) {
      if (point[0] < xMin) xMin = point[0]; if (point[0] > xMax) xMax = point[0];
      if (point[1] < yMin) yMin = point[1]; if (point[1] > yMax) yMax = point[1];
      deltaX = xMax - xMin + 0.1; 
      deltaY = yMax - yMin + 0.1;
      points.Add(new PointF((float)point[0], (float)point[1]));

      reCalcPoints();
    }
    public void AddPoints(double[][] points_) {
      foreach (double[] point in points_) {
        if (point[0] < xMin) xMin = point[0]; if (point[0] > xMax) xMax = point[0];
        if (point[1] < yMin) yMin = point[1]; if (point[1] > yMax) yMax = point[1];
        deltaX = xMax - xMin + 0.1;
        deltaY = yMax - yMin + 0.1;
        points.Add(new PointF((float)point[0], (float)point[1]));
      }
      reCalcPoints();
    }
    private PointF transformCoord(PointF coord) {
      PointF ret = new PointF();
      double scalarX = (coord.X - xMin) / deltaX;
      double scalarY = (coord.Y - yMin) / deltaY;
      scalarY = 1.0 - scalarY;

      ret.X = ((float)scalarX * Width);
      ret.Y = ((float)scalarY * Height);
      return ret;
    }
    private void reCalcPoints() {
      pointsDraw = new PointF[points.Count];
      for (int i = 0; i < points.Count; i++)
        pointsDraw[i] = transformCoord(points[i]);
    }
  }
}
