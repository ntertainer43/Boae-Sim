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
//using Boa_Sim.Nodes;
using Boa_Sim.UIHelper;

namespace Boa_Sim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //AndGate newANd = new AndGate(1, "1");
            //Port[] inputs = [new Port() { Buswidth = 1, ConnectionID = 0  },
            //                    new Port() { Buswidth = 3, ConnectionID = 2},
            //                    new Port() { Buswidth = 3, ConnectionID = 4 },
            //                    new Port() { Buswidth = 3, ConnectionID = 6}];

            //newANd.InputPorts = inputs;


            InitializeComponent();
        }

        private void drawLine(object sender, RoutedEventArgs e)
        {
            List<Shape> childshape = DrawNodes.DrawAndGate(new System.Windows.Point(150, 150));


            foreach (Shape shape in childshape)
            {
                newCV.Children.Add(shape);
            }
            

        }



    }
}