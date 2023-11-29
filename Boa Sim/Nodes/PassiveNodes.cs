using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Boa_Sim.Nodes
{
    internal abstract class Nodes
    {
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

                if (p.inout == IO.OUTPUT)
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


    class WireNode: Nodes
    {
        public PassiveNodeType NodeType = PassiveNodeType.WIRE;
        
        
 

        WireNode(int ID, string Name)
        {
            
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


    class Constant : Nodes
    {



        public PassiveNodeType NodeType = PassiveNodeType.CONSTANT;
        Constant(int Id, string Name)
        {
            this.Name = Name;
            this.Id = Id;
            this.maxInput = 0;
            
        }
        public void Action()
        {

        }


    }


    class Probe: Nodes
    {
        public PassiveNodeType NodeType = PassiveNodeType.PROBE;
        Probe(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;

        }

        public void Action()
        {

        }

    }



    class Splitter: Nodes
    {
        public PassiveNodeType NodeType = PassiveNodeType.SPLITTER;
        public List<WireNode> SplitterOut { get; set; }
        public List<WireNode> SplitterIn { get; set; }

        Splitter(int id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

    }

}
