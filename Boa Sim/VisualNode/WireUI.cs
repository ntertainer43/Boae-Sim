using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Boa_Sim.Cmp;



public enum LineType
{
    VERTICAL, HORIZONTAL, POINTLINE
}
public struct WireHelper
{
    public Line line1;
    public Line line2;
    public LineType linetype { get; set; }

    public WireHelper(Line line1, Line line2, LineType ltype)
    {
        this.line1 = line1;
        this.line2 = line2;
        this.linetype = ltype;
    }

}


namespace Boa_Sim.VisualNode
{
    class WireUI
    {
        public WireNode basewire { get; set; }
        public List<WireHelper> helpers = new List<WireHelper>();
        public int sceneListIndex { get; set; }
        public WireUI() 
        { 
            this.basewire = new WireNode();
            this.helpers = new List<WireHelper>();
             
        // things to do 
        //1. create a wire node and assign the value if necessary.

    }

        public WireHelper drawWire(Canvas mainscene, WireHelper oldwires,Point startPoint, MouseEventArgs e  )
        {
            
            // this section does the work of drawing wires and now it seems it needs to be kept in the UI Drawer folder
            mainscene.Children.Remove(oldwires.line1);
            mainscene.Children.Remove(oldwires.line2);

            //Control newctr = sender as Control;


            Line wireline1 = new Line();
            Line wireline2 = new Line();
            WireHelper tempwires = new WireHelper();

            //drawing orthogonal lines parameters
            double tempx = Math.Abs(startPoint.X - e.GetPosition(mainscene).X);
            double tempy = Math.Abs(startPoint.Y - e.GetPosition(mainscene).Y);

            wireline1.X1 = startPoint.X;
            wireline1.Y1 = startPoint.Y;

            if (tempx < 30 && tempy < 30)
            {

                wireline1.X2 = wireline1.X1;
                wireline1.Y2 = e.GetPosition(mainscene).Y;
                wireline2.X2 = e.GetPosition(mainscene).X;
                wireline2.Y2 = wireline1.Y2;
                wireline2.X1 = wireline1.X2;
                wireline2.Y1 = wireline1.Y2;
                tempwires = new WireHelper(wireline1, wireline2, LineType.POINTLINE);

            }
            else if (tempx > tempy && tempx > 30)
            {
                switch (tempwires.linetype)
                {

                    case LineType.VERTICAL:
                        wireline1.X2 = wireline1.X1;
                        wireline1.Y2 = e.GetPosition(mainscene).Y;
                        wireline2.X2 = e.GetPosition(mainscene).X;
                        wireline2.Y2 = wireline1.Y2;
                        wireline2.X1 = wireline1.X2;
                        wireline2.Y1 = wireline1.Y2;
                        tempwires = new WireHelper(wireline1, wireline2, LineType.VERTICAL);

                        break;
                    default:
                        wireline1.X2 = e.GetPosition(mainscene).X;
                        wireline1.Y2 = wireline1.Y1;
                        wireline2.X2 = wireline1.X2;
                        wireline2.Y2 = e.GetPosition(mainscene).Y;
                        wireline2.X1 = wireline1.X2;
                        wireline2.Y1 = wireline1.Y2;
                        tempwires = new WireHelper(wireline1, wireline2, LineType.HORIZONTAL);
                        break;

                }
            }
            else
            {
                switch (tempwires.linetype)
                {

                    case LineType.HORIZONTAL:
                        wireline1.X2 = e.GetPosition(mainscene).X;
                        wireline1.Y2 = wireline1.Y1;
                        wireline2.X2 = wireline1.X2;
                        wireline2.Y2 = e.GetPosition(mainscene).Y;
                        wireline2.X1 = wireline1.X2;
                        wireline2.Y1 = wireline1.Y2;
                        tempwires = new WireHelper(wireline1, wireline2, LineType.HORIZONTAL);
                        break;

                    default:
                        wireline1.X2 = wireline1.X1;
                        wireline1.Y2 = e.GetPosition(mainscene).Y;
                        wireline2.X2 = e.GetPosition(mainscene).X;
                        wireline2.Y2 = wireline1.Y2;
                        wireline2.X1 = wireline1.X2;
                        wireline2.Y1 = wireline1.Y2;
                        tempwires = new WireHelper(wireline1, wireline2, LineType.VERTICAL);

                        break;
                }

            }


            wireline1.Stroke = Brushes.Black;
            wireline1.StrokeThickness = 2;
            wireline2.Stroke = Brushes.Black;
            wireline2.StrokeThickness = 2;

            
            //tempwires = new WireHelper(wireline1, wireline2, LineType.HORIZONTAL);
            this.helpers.Add(tempwires);
            mainscene.Children.Add(wireline1);
            mainscene.Children.Add(wireline2);
            // this.incompletewire = true;

            return tempwires;
            }

        public void ConnectNode(NodeUI nodeconnection)
        {
            //will trigger the event when wire drawing function is started in a node instance in the scene.
        }

        public void Trigger()
        {

        }

        public void Error()
        {
            //makes the line glow in brown color when the error list value is greater than 1;
        }
    }


     
    }

