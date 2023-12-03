using Boa_Sim.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Boa_Sim.VisualNode
{

    public struct NodeHelper
    {
        public Path body;
        public List<Path> InPorts;
        public List<Path> OutPorts;

        public NodeHelper()
        {
            this.body = new Path();
            this.InPorts = new List<Path>();
            this.OutPorts = new List<Path>();
        }


    }


    internal class NodeUI
    {
       public Nodes basenode { get; set; }
        public NodeUI(ActiveNodeType nodeType ) 
        { 
        
        
        }

        public NodeUI(PassiveNodeType nodeType ) 
        {
        }

        public NodeHelper DrawNode(Canvas mainscene, NodeHelper oldnodes, Point startPoint, MouseEventArgs e)
        {
            NodeHelper tempnode = new NodeHelper();
            List<Path> inportList = new List<Path>();
            List<Path> outportList = new List<Path>();
            
            mainscene.Children.Remove(oldnodes.body);
            foreach (Path iport in oldnodes.InPorts)
            {
                mainscene.Children.Remove(iport);
            }
            foreach (Path iport in oldnodes.OutPorts)
            {
                mainscene.Children.Remove(iport);
            }


            //creating the body
            Rect body = new Rect();
            body.Size = new Size(40, 60);
            body.X = e.GetPosition(mainscene).X;
            body.Y = e.GetPosition(mainscene).Y;    

            RectangleGeometry bodygeo = new RectangleGeometry();
            bodygeo.Rect = body;
            Path bodypath = new Path();
            bodypath.Stroke = Brushes.Black;
            bodypath.StrokeThickness = 2;
            bodypath.Data= bodygeo;
            mainscene.Children.Add(bodypath);


            //creating the input ports change the 3 & 10 with a passed variable that represents the number of input ports
            for (int i = 1; i < 3; i++)
            {
                Rect iport = new Rect();
                iport.Size = new Size(5, 5);
                iport.X = body.X - 10;
                iport.Y = body.Y + 10 *i;

                RectangleGeometry iportgeo = new RectangleGeometry();  
                iportgeo.Rect = iport;
                Path iportPath = new Path();
                iportPath.Stroke = Brushes.Black;
                iportPath.StrokeThickness = 2; iportPath.Data = iportgeo;
                iportPath.Data = iportgeo;
                inportList.Add(iportPath);
                mainscene.Children.Add(iportPath);
            }

            //creating the output ports
            for (int i = 1; i < 2; i++)
            {
                Rect iport = new Rect();
                iport.Size = new Size(5, 5);
                iport.X = body.X + 50;          // this changes from input ports and output ports
                iport.Y = body.Y + 30 * i;

                RectangleGeometry iportgeo = new RectangleGeometry();
                iportgeo.Rect = iport;
                Path iportPath = new Path();
                iportPath.Stroke = Brushes.Black;
                iportPath.StrokeThickness = 2;
                iportPath.Data = iportgeo;
                iportPath.Data = iportgeo;
                
                outportList.Add(iportPath);
                mainscene.Children.Add(iportPath);
            }



            //Rect newrect = new Rect();
            //newrect.Size = new Size(250, 100);
            //newrect.X = 80;
            //newrect.Y = 100;

            //RectangleGeometry recgeo  = new RectangleGeometry();    
            //recgeo.Rect = newrect;
            //Path newpath = new Path();
            //newpath.Stroke = Brushes.Black;
            //newpath.StrokeThickness = 2;
            //newpath.Data = recgeo;
            //sceneCanv.Children.Add(newpath);

            tempnode.body = bodypath;
            tempnode.OutPorts = outportList;
            tempnode.InPorts = inportList;

            return tempnode;
        }

        public void ConnectWire()
        {

        }


        public void LinkEvents(object sender, MouseEventArgs e)
        {

        }



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
