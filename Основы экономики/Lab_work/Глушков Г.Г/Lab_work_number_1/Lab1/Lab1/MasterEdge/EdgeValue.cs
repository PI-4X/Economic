using Lab1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.MasterEdge
{
    
    public class EdgeValue : IEdgeInfo<int>
    {
        protected int VertexValue;
        public EdgeValue(int _value)
        {
            VertexValue = _value;
        }
        public int GetVertexValue()
        {
            return VertexValue;
        }

    }
}
