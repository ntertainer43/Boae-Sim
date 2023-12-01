using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Boa_Sim.Cmp
{
    public class Nodes
    {
        public static int GlobalId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string BitVale { get; set; }
        public int BusWidth { get; set; }
        public int maxInput = 1;
        public Point anchorPoint {get; set; }  
       
        
       // public virtual Port[] Connections { get; set; }
        public  Port[] Connections
        {
            get
            {
                return Connections;
            }
            set
            {
                if (!CheckMaxInput(Connections))
                {
                    errorList.Append("Too many signal driving the Node");
                }
                Connections = Connections;
            }

        }


        public string[] errorList;
        
        public bool signalValid;

        public bool InputEqual(Port[] portList)
        {
            for (int i = 0; i < portList.Length - 1; i++)
            {
                for (int j = i + 1; j < portList.Length; j++)
                {
                    if (portList[i].Buswidth != portList[j].Buswidth)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CheckMaxInput(Port[] conList)
        {
            int count = 0;
            foreach (Port p in conList)
            {

                if (p.inout == IO.INPUT)
                {
                    count++;
                    if (count > maxInput)
                    {
                        return false;
                    }
                    this.BitVale = p.BitValue;
                }
            }
            return true;


        }


    }


    public class WireNode: Nodes
    {
        public PassiveNodeType NodeType = PassiveNodeType.WIRE;
        
        
 

        public WireNode()
        {
            Nodes.GlobalId++;
            this.Id = Nodes.GlobalId;
            this.Name = "Constant" + Nodes.GlobalId;
            this.errorList = new string[0] { };
        }

        public void Action()
        {
            if (errorList.Length == 0)
            {
                signalValid = true;

            }
            else {
                signalValid = false;
            }
        }


        

    }


    public class Constant : Nodes
    {



        public PassiveNodeType NodeType = PassiveNodeType.CONSTANT;
        Constant()
        {
            Nodes.GlobalId++;
            this.Id = Nodes.GlobalId;
            this.Name = "Constant" + Nodes.GlobalId;
            this.maxInput = 0;
            this.errorList = new string[0] { };

        }
        public void Action()
        {

        }


    }


    public class Probe: Nodes
    {
        public PassiveNodeType NodeType = PassiveNodeType.PROBE;
        Probe(int Id, string Name)
        {
            Nodes.GlobalId++;
            this.Id = Nodes.GlobalId;
            this.Name = "Constant" + Nodes.GlobalId;
            this.errorList = new string[0] { };

        }

        public void Action()
        {

        }

    }



    public class Splitter: Nodes
    {
        public PassiveNodeType NodeType = PassiveNodeType.SPLITTER;
        public List<WireNode> SplitterOut { get; set; }
        public List<WireNode> SplitterIn { get; set; }

        Splitter(int id, string Name)
        {
            this.Id = id;
            this.Name = Name;
            this.errorList = new string[0] { };
        }

    }

}
