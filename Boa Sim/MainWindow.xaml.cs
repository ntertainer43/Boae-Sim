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
        
        bool drawWire { get; set; }
        bool drawing { get;set; }
        bool drawNode { get; set; }
        Point startPoint { get; set; }
        Line currentLine { get; set; }
        WireHelper tempwires { get; set; }
        NodeHelper tempnodes { get; set; }
        Point wireCorner { get; set; }

        NodeType pressedNode { get; set; }
        NodeUI sceneNode { get; set; }
        WireUI sceneWire { get; set; }
        List<NodeUI> scenenodes { get; set; }
        List<WireUI> scenewires { get; set; }

        public MainWindow()
        {

            //newANd.InputPorts = inputs;
           // this.currentManager = new NodeManager();
            this.tempwires = new WireHelper();
            this.tempnodes = new NodeHelper();
            this.drawing = false;
            this.scenenodes = new List<NodeUI>();
            this.scenewires = new List<WireUI>();

            InitializeComponent();
        }

        private void wireactive(object sender, RoutedEventArgs e)
        {
            this.drawWire = true;
            Consoletb.Text += "Drawing Wire \n";
            //Window1 newwind = new Window1();    
            //newwind.Show();

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


                //instansiating new tempnodes to prevent deleting of previous ones.
                if (this.drawWire)
                {
                    this.sceneWire.sceneListIndex = this.scenewires.Count + 1;
                    this.scenewires.Add(this.sceneWire);
                }
                if (this.drawNode)
                {
                    this.sceneNode.sceneListIndex = this.scenenodes.Count + 1;
                    this.scenenodes.Add(this.sceneNode);
                }


                
                

                //if performace to be gained replace it with scenenodes and scenewire wirehelper and nodehelper
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


        private void positionelement(object sender, MouseEventArgs e)
        {
            
            //positioning for wire
            if (this.drawing == true)
            {
                Consoletb.Text += "Now Drawing Wire from Port";
                if (this.drawNode == true)
                { 
                    this.sceneNode = new NodeUI(this.pressedNode);
                    this.tempnodes = this.sceneNode.DrawNode(sceneCanv, this.tempnodes, this.startPoint, e);
                    foreach (Path iport in this.sceneNode.helper.InPorts)
                    {
                        iport.MouseDown += clickonPort;
                    }
                    foreach (Path iport in this.sceneNode.helper.OutPorts)
                    {
                        iport.MouseDown += clickonPort;
                    }
                    this.sceneNode.helper.body.MouseDown += scenemousedown;
                    
                    

                }

                if (this.drawWire == true)
                {
                    // this creates orthogonal wires until middle mousebutton is pressed.
                    this.sceneWire = new WireUI();


                    this.tempwires = this.sceneWire.drawWire(sceneCanv, this.tempwires, this.startPoint, e);
                    this.sceneWire.helpers[this.sceneWire.helpers.Count -1].line1.MouseDown += scenemousedown;
                    this.sceneWire.helpers[this.sceneWire.helpers.Count -1].line2.MouseDown += scenemousedown;
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
            this.pressedNode = NodeType.ANDREDUCE;
            

        }

        private void clickonPort(object sender, MouseEventArgs e)
        {
            
            Path portpath = sender as Path;
            string[] Portidentifiers = portpath.Uid.Split(" ");


            NodeUI toconnectnode = this.scenenodes[Convert.ToInt32(Portidentifiers[0])]; // UID is divided as scene NOde list index;  

            if (this.drawWire == true && drawing == true)
            {
                toconnectnode.ConnectWire(this.sceneWire, )



                
            }
            else
            {
                this.drawWire = true;
            }

            

            
            
            


            //some code for connecting wire to the port first thing is to find the node to which this port belongs.




               
          
                
            
        }

    }
}