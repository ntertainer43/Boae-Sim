using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Boa_Sim.Cmp
{

    public enum ActiveNodeType
    {
        ANDREDUCE, ORREDUCE, COMPERATOR, ADDER, MULTPLIER, DIV, MUX, DEMUX, DECODE,
        REGISTER, FLIPFLOP, NOTGATE, NORREDUCE, NANDREDUCE, XORREDUCE, BUFFER, NULL, BITSELECTOR,
        SHIFTER,SHIFTREGISTER,BITWISEAND, BITWISEOR, BITWISEXOR,BITWISENAND, BITWISENOR
    }

    public enum PassiveNodeType
    {
        WIRE, PROBE, CONSTANT, SPLITTER, NULL, PIN
    }

    public enum IO
    {
        INPUT, OUTPUT
    }

     public struct Port
    {
        public int portId;
        public int Buswidth;
        public int ConnectionID;
        public IO inout;
        public string BitValue;
        public bool isActiveNode;
      
    }



    public class ActiveNodes: Nodes
    {
        public virtual Port[] InputPorts { get; set; }
        public virtual Port[] OutputPorts{ get; set;}

    }


    public class AndGate : ActiveNodes
    {
        public ActiveNodeType Nodetype = ActiveNodeType.ANDREDUCE;
        public override Port[] InputPorts { get; set; }
        //{
        //    get
        //    {
        //        return InputPorts;
        //    }
        //    set
        //    {
        //        if (!InputEqual(InputPorts))
        //        {
        //            this.errorList.Append("Input Ports Mismatch");
        //        }
        //        InputPorts = InputPorts;

        //    }
        //}
        bool bitwise;


 

        public AndGate(bool bitwise = false)
        {
            
            Nodes.GlobalId++;
            this.Id = Nodes.GlobalId;
            this.Name = Name;
            this.InputPorts = [new Port(), new Port()];
            this.OutputPorts = [new Port()];
            //this.InputPorts = [new Port() { Buswidth = 1, ConnectionID = 0 },
            //    new Port() { Buswidth = 1, ConnectionID = 0 }];
            //this.OutputPorts = [new Port() { Buswidth = 1, ConnectionID = 0 }];
            this.bitwise = bitwise;
           
            
        }

        public void Action()
        {
            // this part is called during every tick cycle or when manual action command is pressed.
            


        }
            
        



    }

}
