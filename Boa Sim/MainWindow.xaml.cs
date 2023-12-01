using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Boa_Sim.Cmp;

//using Boa_Sim.Nodes;
using Boa_Sim.UIHelper;

namespace Boa_Sim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        NodeManager currentManager { get; set; }
        bool drawingwire { get; set; }
        Point drawPoint { get; set; }
        Line currentLine {  get; set; }
        List<Line> wireList { get; set; }

        public MainWindow()
        {
            //AndGate newANd = new AndGate(1, "1");
            //Port[] inputs = [new Port() { Buswidth = 1, ConnectionID = 0  },
            //                    new Port() { Buswidth = 3, ConnectionID = 2},
            //                    new Port() { Buswidth = 3, ConnectionID = 4 },
            //                    new Port() { Buswidth = 3, ConnectionID = 6}];

            //newANd.InputPorts = inputs;
            this.currentManager= new NodeManager();
            this.wireList = new List<Line>();


            InitializeComponent();
        }

        private void createandgate(object sender, RoutedEventArgs e)
        {


            Image myImage = new Image();
            myImage.Width = 200;
            

            // Create source
            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@"D:\sharing\Boa Sim\Boa Sim\static\img\andgate.png");
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            //set image source
            myImage.Source = myBitmapImage;



           

            mycv.Children.Add(myImage);
            
        }

        private void poscapture(object sender, MouseEventArgs e)
        {
            Image sender1 = e.Source as  Image;
            
            Point relativepos = e.GetPosition(sender1);
            int a = 10; 

            mouselabel.Content = "From the andgate"  ;
        }

        private void mclick(object sender, MouseButtonEventArgs e)
        {
            mouselabel.Content = "The mouse has been clicked";
            Image sender1 =e.Source as Image;
            Point relativepos = e.GetPosition(sender1);
            Point port1 = new Point(10, 32);
            Point port2 = new Point(10, 78);
            Point outport1 = new Point(210, 55);
            List<Point> ports = [ port1, port2, outport1 ];

            foreach (Point ipoint in ports)
            {
                double tempx = Math.Abs(ipoint.X - relativepos.X);
                double  tempy    = Math.Abs(ipoint.Y - relativepos.Y);
                
                if( tempx < 10 && tempy < 10)
                {
                    currentManager.CreatePassiveNode(PassiveNodeType.WIRE, ipoint );
                    drawingwire = true;
                    this.drawPoint = e.GetPosition(mycv);

                    mouselabel.Content = this.drawPoint.X  +"   " + this.drawPoint.Y;
                    drawWire();
                    break;

                }
            }

        }


        public void drawWire()
        {

        }

        private void canvasmove(object sender, MouseEventArgs e)
        {
            Canvas sender1 = e.Source as Canvas;
            mouselabel.Content = this.drawingwire;
            if (drawingwire)
            {
                if (this.currentLine != null)
                {
                    mycv.Children.Remove(currentLine);
                }
                Line newline = new Line();
                newline.X1 = this.drawPoint.X;
                newline.Y1 = this.drawPoint.Y;
                newline.X2 = e.GetPosition(mycv).X;
                newline.Y2 = e.GetPosition(mycv).Y;
                newline.Stroke = Brushes.Black;
                newline.StrokeThickness = 1;
                currentLine = newline;
                mycv.Children.Add(newline);
               // mouselabel.Content = "From canvas";


            }
        }

        private void wirestop(object sender, MouseButtonEventArgs e)
        {
            this.drawingwire = false;
        }
    }
}