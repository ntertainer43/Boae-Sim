using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Boa_Sim.UIHelper
{






    internal class DrawNodes
    {
        public static List<Shape> DrawAndGate(System.Windows.Point NodePosition)
        {
            List<Line> lines = new List<Line>();
            List<Shape> shapes = new List<Shape>();

            for (int i = 0; i < 4; i++)
            {
                Line iline = new Line();
                iline.Stroke = System.Windows.Media.Brushes.Black;
                iline.StrokeThickness = 1;
                lines.Add(iline);
            }

  
            
            lines[1].X1 = NodePosition.X;//the downward line
            lines[1].Y1 = NodePosition.Y;
            lines[1].X2 = NodePosition.X;
            lines[1].Y2 = NodePosition.Y+20;
            
            lines[2].X1 = NodePosition.X + 20;//output connection Line
            lines[2].Y1 = NodePosition.X + 10;
            lines[2].X2 = NodePosition.X + 30;
            lines[2].Y2 = NodePosition.Y + 10;

            lines[3].X1 = NodePosition.X;
            lines[3].Y1 = NodePosition.Y + 5;
            lines[3].X2 = NodePosition.X - 10;
            lines[3].Y2 = NodePosition.Y + 5;

            lines[3].X1 = NodePosition.X;
            lines[3].Y1 = NodePosition.Y + 15;
            lines[3].X2 = NodePosition.X - 10;
            lines[3].Y2 = NodePosition.Y + 15;

            //Path semicircle = new Path();
            //semicircle.Stroke = System.Windows.Media.Brushes.Black;

            ////semicircle.Data = System.Windows.Media.PathGeometry(PathFigure());
            //System.Windows.Size circlesize = new System.Windows.Size();
            //circlesize.Width = 20;
            //circlesize.Height = 20;


            //ArcSegment halfcircle = new ArcSegment(new System.Windows.Point(NodePosition.X, NodePosition.Y),circlesize,50,true,SweepDirection.Clockwise, true) );
            



            //PathFigure pathFigure = new PathFigure(new System.Windows.Point(NodePosition.X, NodePosition.Y), halfcircle, false);
            
            //PathGeometry newpath = new PathGeometry();
            Ellipse halfcirc = new Ellipse();
            halfcirc.Width = 20;
            halfcirc.Height = 20;
            halfcirc.Stroke = Brushes.Black;
            halfcirc.StrokeThickness = 2;


            shapes.AddRange(lines);
            shapes.Add(halfcirc);
            

          


            return shapes;
        }
    }


   


}
