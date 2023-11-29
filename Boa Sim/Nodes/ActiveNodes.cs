using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boa_Sim.Nodes
{

    enum ActiveNodeType
    {
        ANDGATE, ORGATE, COMPERATOR, ADDER, MULTPLIER, DIV, MUX, DEMUX, DECODE,
        REGISTER, FLIPFLOP, NOTGATE, NORGATE, NANDGATE, XORGATE, BUFFER, NULL
    }

    public enum PassiveNodeType
    {
        WIRE, PROBE, CONSTANT, SPLITTER,NULL
    }

    public enum IO
    {
        INPUT, OUTPUT
    }

     struct Port
    {
        public int Buswidth;
        public int ConnectionID;
        public IO inout;
        public string BitValue;
        
      
    }



    internal abstract class ActiveNodes: Nodes
    {
        public virtual Port[] InputPorts { get; set; }
        public virtual Port[] OutputPorts{ get; set;}

    }


    class AndGate : ActiveNodes
    {
        public ActiveNodeType Nodetype = ActiveNodeType.ANDGATE;
        public override Port[] InputPorts
        {
            get
            {
                return InputPorts;
            }
            set
            {
                if (!InputEqual(InputPorts))
                {
                    this.errorList.Append("Input Ports Mismatch");
                }
                InputPorts = InputPorts;

            }
        }




        public AndGate(int Id = 1, string Name = "AndGate1")
        {
            this.Id = Id;
            this.Name = Name;
            this.InputPorts = [new Port() { Buswidth = 1, ConnectionID = 0},
                                new Port() { Buswidth = 1, ConnectionID = 0}  ];
            this.OutputPorts = [new Port() { Buswidth = 1, ConnectionID = 0 }];
           
            
        }

        public void Action()
        {
            // this part is called during every tick cycle or when manual action command is pressed.
            


        }
            
        



    }

}
