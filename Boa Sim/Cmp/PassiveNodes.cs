using System;
using System.Collections.Generic;
using System.Data;
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

    
        public string State { get; set; }

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




    }


    public class WireNode : Nodes
    {
        public NodeType ComponentType { get; }
        public List<Port> InputPorts;
        public List<Port> OutputPorts;
        public string wireValue;
        public int Buswidth;
        public int Inputs { get; set; }
        public int Outputs { get; set; }
        public int WireListIndex { get; set; }

        public WireNode(int stackindex)
        {
            this.ComponentType = NodeType.WIRE;

            Nodes.GlobalId++;
            this.Id = Nodes.GlobalId;
            this.Name = "Constant" + Nodes.GlobalId;
            this.Inputs = 0;
            this.Outputs = 0;
            this.InputPorts = new List<Port>();
            this.OutputPorts = new List<Port>();
            this.WireListIndex = stackindex;
            this.errorList = new string[0] { };
        }

        public void ConnectNode(Port newconnectionPort, int nodestackindex)
        {
            Port newport = new Port();
            if (newconnectionPort.inout == IO.OUTPUT)
            {
                newport.inout = IO.INPUT;
                newport.ConnectionID = nodestackindex;
                newport.Buswidth = newconnectionPort.Buswidth;
                this.Inputs++;
                newport.portId = this.Inputs;
                newport.BitValue = newconnectionPort.BitValue;
            }
            else if (newconnectionPort.inout == IO.INPUT)
            {
                newport.inout = IO.OUTPUT;
                newport.ConnectionID = nodestackindex;
                this.Outputs++;
                newport.portId = this.Outputs;
                newport.BitValue = this.wireValue;
                newport.Buswidth = this.Buswidth;

            }
            this.checkValidity();

        }

        public void DisconnectNode(Port oldconnectionPort)
        {


            if (oldconnectionPort.inout == IO.OUTPUT)
            {
                foreach (Port iport in this.InputPorts)
                {
                    if (iport.ConnectionID == oldconnectionPort.ParentID)
                    {

                        this.InputPorts.Remove(iport);
                    }
                }
            }
            else if (oldconnectionPort.inout == IO.INPUT)
            {
                foreach (Port iport in this.OutputPorts)
                {
                    if (iport.ConnectionID == oldconnectionPort.ParentID)
                    {

                        this.OutputPorts.Remove(iport);
                    }
                }
            }
            this.checkValidity();
        }


        //is called by each method before completion 

        public void checkValidity()
        {
            string bitvalue = InputPorts[0].BitValue;
            // for each section different types of validities are checked.
            if (InputPorts.Count > 1)
            {
                this.errorList.Append("Too many inputs to Wire");
            }

            foreach (Port iport in this.OutputPorts)
            {
                if (iport.BitValue != bitvalue)
                {
                    this.errorList.Append("Bitwidth mismatch");
                }
            }

        }


    }
}
