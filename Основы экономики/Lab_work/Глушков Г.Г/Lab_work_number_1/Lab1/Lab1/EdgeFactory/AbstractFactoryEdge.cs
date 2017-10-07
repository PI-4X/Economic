using Lab1.Interface;
using Lab1.MasterEdge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.EdgeFactory
{
    public abstract class AbstractFactoryEdge
    {
        public abstract Edge<IEdgeInfo<int>, int> CreateEdge(int _from, int  _to, int _weight);
    }
}
