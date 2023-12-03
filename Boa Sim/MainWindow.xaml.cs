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






    public partial class MainWindow : Window
    {
        NodeManager currentManager { get; set; }
        bool drawWire { get; set; }
        bool drawing { get;set; }
        bool drawNode { get; set; }
        Point startPoint { get; set; }
        Line currentLine { get; set; }
        WireHelper tempwires { get; set; }
        NodeHelper tempnodes { get; set; }
        Point wireCorner { get; set; }

        ActiveNodeType pressedNode { get; set; }
        

        public MainWindow()
        {

            //newANd.InputPorts = inputs;
            this.currentManager = new NodeManager();
            this.tempwires = new WireHelper();
            this.tempnodes = new NodeHelper();
            this.drawing = false;

            InitializeComponent();
        }

        private void wireactive(object sender, RoutedEventArgs e)
        {
            this.drawWire = true;
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
                this.drawNode = false;
                this.drawWire = false;
                this.drawing = false;

                //also create the required eventhandling for the controls drawn while placing them or maybe before




                this.tempwires = new WireHelper();
                this.tempnodes = new NodeHelper();
            }
     
            if (this.drawWire || this.drawNode)
            {
                this.drawing = true;
                //Control newctr = sender as Control;
                this.startPoint = new Point(e.GetPosition(sceneCanv).X, e.GetPosition(sceneCanv).Y);
                Consoletb.Text += "Line position is " + this.startPoint.X + " " + this.startPoint.Y + "\n"; 
            }

            
        }



        private void consolemouse(object sender, MouseButtonEventArgs e)
        {
            Consoletb.Text = "Clicking in console";
        }

        private void positionelement(object sender, MouseEventArgs e)
        {


          


            //positioning for wire
            if (this.drawing == true)
            {

                if (this.drawNode)
                { 

                    NodeUI scenenode = new NodeUI(this.pressedNode);
                    this.tempnodes = scenenode.DrawNode(sceneCanv, this.tempnodes, this.startPoint, e);
                    

                }





                if (this.drawWire)
                {
                    // this creates orthogonal wires until middle mousebutton is pressed.
                    WireUI scenewire = new WireUI();
                    this.tempwires = scenewire.drawWire(sceneCanv, this.tempwires, this.startPoint, e);
                }
                
                

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
            
            this.drawNode = true;
            this.pressedNode = ActiveNodeType.ANDREDUCE;
            

        }
    }
}