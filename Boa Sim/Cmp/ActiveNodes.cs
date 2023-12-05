using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Boa_Sim.Cmp
{

    public enum NodeType
    {
        ANDREDUCE, ORREDUCE, COMPERATOR, ADDER, MULTPLIER, DIV, MUX, DEMUX, DECODE,
        REGISTER, FLIPFLOP, NOTGATE, NORREDUCE, NANDREDUCE, XORREDUCE, BUFFER, NULL, BITSELECTOR,
        SHIFTER,SHIFTREGISTER,BITWISEAND, BITWISEOR, BITWISEXOR,BITWISENAND, BITWISENOR, WIRE, PROBE, CONSTANT, SPLITTER, PIN
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
        public bool connected;
        public int ParentID;
      
    }


    public class Act
    {
        public Act()
        {
            Nodes newnode = new Nodes();
            
        }
    }



    public class AndGate : Nodes
    {
        public NodeType Nodetype = NodeType.ANDREDUCE;

        bool bitwise;
        public List<Port> InputPorts;
        public List<Port> OutputPorts;
        public int Outputs { get; }
        public int Inputs {
            get {  return this.Inputs; } 
            set{

            }       
 

        public AndGate(bool bitwise = false)
        {
            
            Nodes.GlobalId++;
            this.Id = Nodes.GlobalId;
            this.Name = "And" + this.Id;
            this.InputPorts = [new Port(), new Port()];
            this.OutputPorts = [new Port()];
  
            
        }

        public void Action()
        {
            // this part is called during every tick cycle or when manual action command is pressed.
            
        }
            
        



    }






}
