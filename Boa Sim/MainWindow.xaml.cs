using Boa_Sim.Cmp;
using Boa_Sim.VisualNode;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Shapes;

//using Boa_Sim.Nodes;

namespace Boa_Sim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



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


    public partial class MainWindow : Window
    {
        NodeManager currentManager { get; set; }
        bool drawwire { get; set; }
        bool drawing { get;set; }
        bool incompletewire { get; set; }   
        Point startPoint { get; set; }
        Line currentLine { get; set; }
        WireHelper tempwires { get; set; }
        Point wireCorner { get; set; }

        ActiveNodeType pressedNode { get; set; }
        bool nodeactive { get; set; }

        public MainWindow()
        {

            //newANd.InputPorts = inputs;
            this.currentManager = new NodeManager();
            this.tempwires = new WireHelper();
            this.drawing = false;

            InitializeComponent();
        }

        private void wireactive(object sender, RoutedEventArgs e)
        {
            this.drawwire = true;
            Consoletb.Text += "Drawing Wire \n";
            //Window1 newwind = new Window1();    
            //newwind.Show();

        }

      
        

        private void mousecapture(object sender, MouseEventArgs e)
        {
            Consoletb.Text += "ENter the canvas \n";
        }

        private void wirecomplete(object sender, MouseButtonEventArgs e)
        {
            Consoletb.Text += "Completed placing the wire \n";
        }

     

        private void scenemousedown(object sender, MouseButtonEventArgs e)
        {
            if (this.drawing)
            {
                this.incompletewire = false;
                this.drawwire = false;
                this.drawing = false;
            }
     
            if (this.drawwire)
            {
                this.drawing = true;
                //Control newctr = sender as Control;
                this.startPoint = new Point(e.GetPosition(sceneCanv).X, e.GetPosition(sceneCanv).Y +10);
                Consoletb.Text += "Line position is " + this.startPoint.X + " " + this.startPoint.Y + "\n"; 
            }
            
        }



        private void consolemouse(object sender, MouseButtonEventArgs e)
        {
            Consoletb.Text = "Clicking in console";
        }

        private void positionelement(object sender, MouseEventArgs e)
        {
            Path drawbody = new Path();
            List<Path> inputport = new List<Path>();
            List<Path> outputport = new List<Path>();

            if (this.nodeactive)
            {
                switch (this.pressedNode)
                {
                    case ActiveNodeType.ANDREDUCE:
                        AndUI drawAnd = new AndUI(e.GetPosition(sceneCanv));
                        drawbody = drawAnd.body;
                        Consoletb.Text = Convert.ToString( drawbody.Stroke);
                        inputport = drawAnd.Inpoints;
                        outputport = drawAnd.Outpoints;
                        int a = 0;

                        break;
                    case ActiveNodeType.ORREDUCE:
                        break;
                    case ActiveNodeType.COMPERATOR:
                        break;
                    case ActiveNodeType.ADDER:
                        break;
                    case ActiveNodeType.MULTPLIER:
                        break;
                    case ActiveNodeType.DIV:
                        break;
                    case ActiveNodeType.MUX:
                        break;
                    case ActiveNodeType.DEMUX:
                        break;
                    case ActiveNodeType.DECODE:
                        break;
                    case ActiveNodeType.REGISTER:
                        break;
                    case ActiveNodeType.FLIPFLOP:
                        break;
                    case ActiveNodeType.NOTGATE:
                        break;
                    case ActiveNodeType.NORREDUCE:
                        break;
                    case ActiveNodeType.NANDREDUCE:
                        break;
                    case ActiveNodeType.XORREDUCE:
                        break;
                    case ActiveNodeType.BUFFER:
                        break;
                    case ActiveNodeType.NULL:
                        break;
                    case ActiveNodeType.BITSELECTOR:
                        break;
                    case ActiveNodeType.SHIFTER:
                        break;
                    case ActiveNodeType.SHIFTREGISTER:
                        break;
                    case ActiveNodeType.BITWISEAND:
                        break;
                    case ActiveNodeType.BITWISEOR:
                        break;
                    case ActiveNodeType.BITWISEXOR:
                        break;
                    case ActiveNodeType.BITWISENAND:
                        break;
                    case ActiveNodeType.BITWISENOR:
                        break;
                    default:
                        break;
                }

                sceneCanv.Children.Add(drawbody);
                foreach (Path inpath in inputport)
                {
                    sceneCanv.Children.Add(inpath);
                }
                foreach (Path outpath in outputport)
                {
                    sceneCanv.Children.Add(outpath);
                }

            }



            //positioning for wire
            if (this.drawing == true)
            {
               
                sceneCanv.Children.Remove(this.tempwires.line1);
                sceneCanv.Children.Remove(this.tempwires.line2);
                
                //Control newctr = sender as Control;


                Line wireline1 = new Line();
                Line wireline2 = new Line();


                //drawing orthogonal lines parameters
                double tempx = Math.Abs( this.startPoint.X - e.GetPosition(sceneCanv).X);
                double tempy = Math.Abs( this.startPoint.Y - e.GetPosition(sceneCanv).Y);

                wireline1.X1 = this.startPoint.X;
                wireline1.Y1 = this.startPoint.Y;

                if(tempx <30 && tempy < 30)
                {
                                            
                        wireline1.X2 = wireline1.X1;
                        wireline1.Y2 = e.GetPosition(sceneCanv).Y;
                        wireline2.X2 = e.GetPosition(sceneCanv).X;
                        wireline2.Y2 = wireline1.Y2;
                        wireline2.X1 = wireline1.X2;
                        wireline2.Y1 = wireline1.Y2;
                        this.tempwires = new WireHelper(wireline1, wireline2, LineType.POINTLINE);
                   
                }
                else if (tempx> tempy && tempx > 30)
                {
                    switch (this.tempwires.linetype)
                    {
 
                        case LineType.VERTICAL:
                            wireline1.X2 = wireline1.X1;
                            wireline1.Y2 = e.GetPosition(sceneCanv).Y;
                            wireline2.X2 = e.GetPosition(sceneCanv).X;
                            wireline2.Y2 = wireline1.Y2;
                            wireline2.X1 = wireline1.X2;
                            wireline2.Y1 = wireline1.Y2;
                            this.tempwires = new WireHelper(wireline1, wireline2, LineType.VERTICAL);

                            break;
                        default:
                            wireline1.X2 = e.GetPosition(sceneCanv).X;
                            wireline1.Y2 = wireline1.Y1;
                            wireline2.X2 = wireline1.X2;
                            wireline2.Y2 = e.GetPosition(sceneCanv).Y;
                            wireline2.X1 = wireline1.X2;
                            wireline2.Y1 = wireline1.Y2;
                            this.tempwires = new WireHelper(wireline1, wireline2, LineType.HORIZONTAL);
                            break;
                            
                    }
                }
                else
                {
                    switch (this.tempwires.linetype)
                    {
                   
                        case LineType.HORIZONTAL:
                            wireline1.X2 = e.GetPosition(sceneCanv).X;
                            wireline1.Y2 = wireline1.Y1;
                            wireline2.X2 = wireline1.X2;
                            wireline2.Y2 = e.GetPosition(sceneCanv).Y;
                            wireline2.X1 = wireline1.X2;
                            wireline2.Y1 = wireline1.Y2;
                            this.tempwires = new WireHelper(wireline1, wireline2, LineType.HORIZONTAL);
                            break;

                        default:
                            wireline1.X2 = wireline1.X1;
                            wireline1.Y2 = e.GetPosition(sceneCanv).Y;
                            wireline2.X2 = e.GetPosition(sceneCanv).X;
                            wireline2.Y2 = wireline1.Y2;
                            wireline2.X1 = wireline1.X2;
                            wireline2.Y1 = wireline1.Y2;
                            this.tempwires = new WireHelper(wireline1, wireline2, LineType.VERTICAL);

                            break;
                    }

                }
                

                wireline1.Stroke = Brushes.Black;
                wireline1.StrokeThickness = 2;
                wireline2.Stroke = Brushes.Black;
                wireline2.StrokeThickness = 2;

                this.currentLine = wireline1;
                //this.tempwires = new WireHelper(wireline1, wireline2, LineType.HORIZONTAL);
                
                sceneCanv.Children.Add(wireline1);
                sceneCanv.Children.Add(wireline2);
               // this.incompletewire = true;
            }
        }

        private void createnode(object sender, RoutedEventArgs e)
        {
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
            
            this.nodeactive = true;
            this.pressedNode = ActiveNodeType.ANDREDUCE;
            

        }
    }
}