using Lab1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Edge<T,U> where T : IEdgeInfo<U>
    {
        public T VertexFrom { get; set; }
        public T VertexTo { get; set; }
        public int Weight { get; set; }
        public override string ToString()
        {
            return $"{VertexFrom.GetVertexValue()} {VertexTo.GetVertexValue()} {Weight}";
        }
    }
    

}
