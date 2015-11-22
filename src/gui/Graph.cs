using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PotterFilter.src.gui {
  class Graph {
    public List<PointF> TruePoints;
    public PointF[] Points;
    Pen pen;
    public String Name { get { return name; } private set { } }
    String name;
    public bool NeedToDraw { get { return draw; } set { draw = value; } }
    bool draw = true;

    public double MinValueX { get { return xMin; } private set { } }
    public double MaxValueX { get { return xMax; } private set { } }
    public double MinValueY { get { return yMin; } private set { } }
    public double MaxValueY { get { return yMax; } private set { } } 

    double xMin = 0.0, xMax = 0.0;
    double deltaX = 0.0;
    double yMin = 0.0, yMax = 0.0;
    double deltaY = 0.0;

    public Graph(double[][] points_, Pen p, String name_) {
      name = name_;
      pen = p;
      TruePoints = new List<PointF>();

      foreach (double[] point in points_) {
        if (point[0] < xMin) xMin = point[0]; if (point[0] > xMax) xMax = point[0];
        if (point[1] < yMin) yMin = point[1]; if (point[1] > yMax) yMax = point[1];
        deltaX = xMax - xMin + 0.1;
        deltaY = yMax - yMin + 0.1;
        TruePoints.Add(new PointF((float)point[0], (float)point[1]));
      }
      Points = new PointF[TruePoints.Count];
    }
    public void Draw(Graphics gr){
      if(draw)
        gr.DrawLines(pen, Points);
    }
  }
}
