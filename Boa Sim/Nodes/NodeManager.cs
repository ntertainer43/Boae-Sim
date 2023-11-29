using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boa_Sim.Nodes
{


    internal class NodeManager
    {
        // This class is responsible for instansiating and managing all the different nodes and keep them alligned/
        // Do things like rearranging ,etc
        public List<ActiveNodes> ActiveNodes;
        public List<Nodes> PassiveNodes;

        public NodeManager()
        {

        }

        public static void CreateActiveNode(ActiveNodeType ant,int id, string Name = "") 
        {

        }

        public static void UpdateNode()
        {

        }


    }


    class CircuitGroup
    {
        // class for handling group of Nodes tied together properly.
    }
}
