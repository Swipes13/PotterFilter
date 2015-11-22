using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace PotterFilter.src.gui {
  struct Risk {
    static float width = 2.0f;
    static float valueStep = 2.0f;

    public Risk(PointF val, PointF transP, bool vertical, bool drawString) {
      if (!vertical)
        value = Math.Round(val.Y, 2);
      else
        value = Math.Round(val.X, 2);
      realValuePoint = val;

      transformPoint = transP;
      a = new PointF();
      b = new PointF();
      valuePoint = new PointF();
      NeedString = drawString;
      font = SystemFonts.DefaultFont;
      brush = SystemBrushes.HotTrack;
      Vertical = vertical;

      RecalcPoints();
    }
    public double value;
    public PointF transformPoint;
    public PointF realValuePoint;
    public PointF a;
    public PointF b;
    public PointF valuePoint;
    Font font;
    Brush brush;
    public bool NeedString;
    public bool Vertical;
    public void RecalcPoints() {
      if (!Vertical) {
        a.X = transformPoint.X - Risk.width;
        a.Y = transformPoint.Y;
        b.X = transformPoint.X + Risk.width;
        b.Y = transformPoint.Y;

        valuePoint.X = transformPoint.X - Risk.width - valueStep*12;
        valuePoint.Y = transformPoint.Y - valueStep * 3;
      }
      else {
        a.X = transformPoint.X;
        a.Y = transformPoint.Y - Risk.width;
        b.X = transformPoint.X;
        b.Y = transformPoint.Y + Risk.width;

        valuePoint.X = transformPoint.X - valueStep*2.5f;
        valuePoint.Y = transformPoint.Y + Risk.width + valueStep;
      }
    }
    public void Draw(Graphics gr, Pen pen) {
      gr.DrawLine(pen, a, b);
      if (NeedString)
        gr.DrawString(value.ToString(), font, brush, valuePoint);
    }
  }
}
