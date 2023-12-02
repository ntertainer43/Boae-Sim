using Boa_Sim.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Boa_Sim.VisualNode
{
    internal class NodeUI
    {

    }

    public class AndUI
    {
        public Image nodeImage { get; set; }
        public Path body { get; set; }

        public  TextBox nodeText { get; set; }
        public  List<Path> Outpoints { get; set; }
        public List<Path> Inpoints { get; set; }
        public Point  anchorpoint { get; set; }
        public AndGate andg;

        public AndUI(Point apoint)
        {
            this.andg = new AndGate(false);
            this.nodeImage = new Image();

            this.nodeText = new TextBox();
            this.nodeText.Text = "And";
            this.Outpoints = new List<Path>();
            this.Inpoints = new List<Path>();
            this.anchorpoint = apoint;
            this.body = new Path();

            createPortsUI();
            DrawNode();
        }

        private void createPortsUI()
        {
            int startpoint = 10;
            int count = 10;
            foreach (Port iport in this.andg.InputPorts)
            {
                count += 10;
                Rect newrect = new Rect();
                
                newrect.Width = 10;
                newrect.Height = 10;
                newrect.X = anchorpoint.X -10;
                newrect.Y = anchorpoint.Y + count ;
                EllipseGeometry  egeo = new EllipseGeometry(newrect);
                
                Path ipath = new Path();
                ipath.Stroke = Brushes.Black;
                ipath.StrokeThickness = 2;
                // the ports need custom event to make them glow and snap on mouse click.
                this.Inpoints.Add(ipath);

            }

            count = 10;
            foreach (Port iport in this.andg.OutputPorts)
            {
                count += 10;
                Rect newrect = new Rect();

                newrect.Width = 30;
                newrect.Height = 30;
                newrect.X = anchorpoint.X + 90;
                newrect.Y = anchorpoint.Y +20 + count ;
                EllipseGeometry egeo = new EllipseGeometry(newrect);

                Path ipath = new Path();
                ipath.Stroke = Brushes.Black;
                ipath.StrokeThickness = 2;

                this.Outpoints.Add(ipath);
            }

        }

        public void DrawNode()
        {
            Rect newrect = new Rect();
            newrect.Width = 80;
            newrect.Height = 80;
            newrect.X = anchorpoint.X;
            newrect.Y = anchorpoint.Y;

            RectangleGeometry recgeo = new RectangleGeometry();
            recgeo.Rect = newrect;
            
            this.body.Stroke = Brushes.Black;
            this.body.StrokeThickness = 2;
            this.body.Data = recgeo;




        }


        
    }
}
