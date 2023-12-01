using System;
using System.Collections.Generic;

using System.Windows;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boa_Sim.Cmp
{
    public enum NodeOperations
    {
        NAME, BUSWIDTH, BITVALUE, INPUTPORT, OUTPUTPORT, CONNECT, DISCONNECT, DELETE
    }

    public struct OperationValue
    {
        
        public string newName;
        public string newBitvalue;
        public List<Port> inputPorts;
        public List<Port> outputPorts;
        public Point anchorPoint;
        public int connectionId;
        public int portId;
        public bool connecting;

    }


    
    public class NodeManager
    {
        // This class is responsible for instansiating and managing all the different nodes and keep them alligned/
        // Do things like rearranging ,etc
        public List<ActiveNodes> ActiveNodeList;
        public List<Nodes> PassiveNodes;

        public List<string> ErrorList;

        public NodeManager()
        {
            this.ActiveNodeList = new List<ActiveNodes>();
            this.PassiveNodes = new List<Nodes>();
        }

        public void CreateActiveNode(ActiveNodeType ant, Point globalPoint) 
        {
            switch (ant)
            {
               
                case ActiveNodeType.ANDREDUCE:
                    AndGate newand = new AndGate(false);
                    this.ActiveNodeList.Add(newand);
                    break;
                case ActiveNodeType.ORREDUCE:

                    break;
                case ActiveNodeType.COMPERATOR:
                    break;
                case ActiveNodeType.ADDER:
                    break;
                case ActiveNodeType.MULTPLIER:
                    break;
                case ActiveNodeType.DIV:
                    break;
                case ActiveNodeType.MUX:
                    break;
                case ActiveNodeType.DEMUX:
                    break;
                case ActiveNodeType.DECODE:
                    break;
                case ActiveNodeType.REGISTER:
                    break;
                case ActiveNodeType.FLIPFLOP:
                    break;
                case ActiveNodeType.NOTGATE:
                    break;
                case ActiveNodeType.NORREDUCE:
                    break;
                case ActiveNodeType.NANDREDUCE:
                    break;
                case ActiveNodeType.XORREDUCE:
                    break;
                case ActiveNodeType.BUFFER:
                    break;
                case ActiveNodeType.NULL:
                    break;
                case ActiveNodeType.BITSELECTOR:
                    break;
                case ActiveNodeType.SHIFTER:
                    break;
                case ActiveNodeType.SHIFTREGISTER:
                    break;
                case ActiveNodeType.BITWISEAND:
                    break;
                case ActiveNodeType.BITWISEOR:
                    break;
                case ActiveNodeType.BITWISEXOR:
                    break;
                case ActiveNodeType.BITWISENAND:
                    break;
                case ActiveNodeType.BITWISENOR:
                    break;
                default:
                    break;

                    
                
            }
            
        }

        public void CreatePassiveNode(PassiveNodeType pnt, Point globalPoint)
        {
            
            switch (pnt)
            {
                case PassiveNodeType.WIRE:
                    WireNode newwire = new WireNode();
                    this.PassiveNodes.Add(newwire);
                    break;
                case PassiveNodeType.PROBE:
                    break;
                case PassiveNodeType.CONSTANT:
                    break;
                case PassiveNodeType.SPLITTER:
                    break;
                case PassiveNodeType.NULL:
                    break;
                case PassiveNodeType.PIN:
                    break;
                default:
                    break;
            }
        }
        public void Update(int NodeId, string nodetype, NodeOperations op, OperationValue opVal)
        {
            Nodes firstNode = new Nodes();
            Nodes secondNode = new Nodes();

            bool nodefound = false;
            if (nodetype == "ACTIVE")
            {
                foreach (Nodes inode in this.ActiveNodeList)
                {
                    if (NodeId == inode.Id)
                    {
                        firstNode = inode;
                        nodefound = true;
                        break;
                    }
                    else if (opVal.connectionId == inode.Id)
                    {
                        secondNode = inode;
                        break;
                    }
                }
            }
            else
            {
                foreach (Nodes inode in this.PassiveNodes)
                {
                    if (NodeId == inode.Id)
                    {
                        firstNode = inode;
                        nodefound = true;
                        break;
                    }
                }
            }

                   
            if (nodefound)
            {
                switch (op)
                {
                    case NodeOperations.NAME:
                        EditName(firstNode, opVal.newName);
                        break;
                    case NodeOperations.BUSWIDTH:
                        break;
                    case NodeOperations.BITVALUE:
                        break;
                    case NodeOperations.INPUTPORT:
                        break;
                    case NodeOperations.OUTPUTPORT:
                        break;
                    case NodeOperations.CONNECT:
                        ConnectNode(firstNode, secondNode, opVal.portId, opVal.connectionId);
                        break;
                    case NodeOperations.DELETE:
                        break;
                    case NodeOperations.DISCONNECT:
                        break;
                    
                    default:
                        break;
                }
            }
            else
            {
                // Raise Exception that the searched node is not avaliable in the list.
            }
            




        }

        public void EditName(Nodes editNode, string newname) 
        {
            editNode.Name = newname;
        }

        public void EditInputPort(Nodes editNode, List<Port> portlist) 
        {
            // a bit complicated due to the nature of ports so wil
            // this will not be sufficient.
        }
        public void EditOutputPort(Nodes editNode, List<Port> portlist)
        {
            // a bit complicated due to the nature of ports so wil
            // this will not be sufficient.
        }

        public void EditValue(Nodes editNode, string newvalue)
        {
            editNode.BitVale = newvalue;
        }

        public void ConnectNode(Nodes firstNode, Nodes secondNode, int firstportId, int secondPortId  )
        {
            Port firstPort = new Port();
            Port secondPort = new Port();
            bool port1found = false;
            bool port2found = false;
            int count1 = 0;
            int count2 = 0;

            foreach (Port iport in firstNode.Connections)
            {
                if (firstportId == iport.portId)
                {
                    
                    firstPort = iport;
                    port1found = true;
                    break;
                } 
                count1++;
            }
            foreach (Port iport in secondNode.Connections)
            {
           
                if (secondPortId == iport.portId)
                {
                    secondPort = iport;
                    port2found = true;
                    break;
                }
                count2++;

            }

            if(!port1found || !port2found)
            {
                return;
            }


            

        }


        
        public void EditBusWidth(Nodes editNode,  int busWidth)
        {

        }

    }


    class CircuitGroup
    {
        // class for handling group of Nodes tied together properly.
    }
}
