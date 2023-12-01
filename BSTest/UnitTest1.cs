using System.Linq.Expressions;
using Boa_Sim.Cmp;
using System.Drawing;

namespace BSTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        

        [Test]
        public void Test1()
        {
            //Boa_Sim.Cmp.NodeManager nodeManager = new Boa_Sim.Cmp.NodeManager();
            //nodeManager.CreateActiveNode(ActiveNodeType.ANDREDUCE, 2, "newandgate");
            //nodeManager.CreateActiveNode(ActiveNodeType.ANDREDUCE, 2, "secondandgate");

            int a = 10;
            Assert.Pass();
        }


        [Test]
        public void Test2()
        {
            Boa_Sim.Cmp.NodeManager nodeManager = new Boa_Sim.Cmp.NodeManager();
            nodeManager.CreatePassiveNode(PassiveNodeType.WIRE, new Point(4, 5));
            nodeManager.CreateActiveNode(ActiveNodeType.ANDREDUCE, new Point(80, 50));

            OperationValue opval = new OperationValue();
            opval.newName = "Hello AndGate";
            nodeManager.Update(1, "PASSIVE", NodeOperations.NAME, opval);
            int a = 10;
            Assert.Pass();
        }
    }
}