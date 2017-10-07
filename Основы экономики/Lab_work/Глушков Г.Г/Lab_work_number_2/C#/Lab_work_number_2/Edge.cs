using Lab_work_number_2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_work_number_2
{
    public class Edge : IComparer<Edge>, ICloneable
    {
        public Vertex VertexFrom { get; set; }
        public Vertex VertexTo { get; set; }
        public int Weight { get; set; }
        public Edge(IEnumerable<string> _data)
        {
            var data = _data.ToList();
            var _vertexFrom = Convert.ToInt32(data[0]);
            var _vertexTo = Convert.ToInt32(data[1]);
            var _weight = Convert.ToInt32(data[2]);
            VertexFrom = new Vertex(_vertexFrom);
            VertexTo = new Vertex(_vertexTo);
            Weight = _weight;
        }
        public Edge(int _from, int _to, int _weight)
        {
            VertexFrom = new Vertex(_from);
            VertexTo = new Vertex(_to);
            Weight = _weight;
        }
        public Edge(Vertex _from, Vertex _to, int _weight)
        {
            VertexFrom = _from;
            VertexTo = _to;
            Weight = _weight;
        }
        public override string ToString()
        {
            return $"From {VertexFrom.GetNumber} To {VertexTo.GetNumber} Weight {Weight}";
        }
        public string ConsoleVertex()
        {
            return $"From {VertexFrom.GetNumber} To {VertexTo.GetNumber}";
        }
       

        public int Compare(Edge x, Edge y)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            var _from = (Vertex)VertexFrom.Clone();
            var _to = (Vertex)VertexTo.Clone();
            int _weight = Weight;
            return new Edge(_from, _to, _weight);
        }
    }
    

}
