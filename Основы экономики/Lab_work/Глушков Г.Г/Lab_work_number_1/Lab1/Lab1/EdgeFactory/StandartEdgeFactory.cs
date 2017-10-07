using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.MasterEdge;
using Lab1.Interface;

namespace Lab1.EdgeFactory
{
    public class StandartEdgeFactory : AbstractFactoryEdge
    {
        public override Edge<IEdgeInfo<int>, int> CreateEdge(int _from, int _to, int _weight)
        {
            var vertexFrom = new EdgeValue(_from);
            var vertexTo = new EdgeValue(_to);
            return new Edge<IEdgeInfo<int>, int> { VertexFrom = vertexFrom, VertexTo = vertexTo, Weight = _weight };
        }
    }
}
