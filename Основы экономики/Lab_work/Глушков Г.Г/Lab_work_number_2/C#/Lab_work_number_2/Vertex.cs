using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_work_number_2
{
    public class Vertex : ICloneable
    {
        public int  Number { get; set; }
        public int  Tr { get; set; }
        public int  Tp { get; set; }
        public int  R { get; set; }
        public Vertex()
        {

        }
        public Vertex(int _number)
        {
            Number = _number;
            Tr = 0;
            Tp = 999;
            R = 0;
        }
        
        public int GetNumber => Number;
        public override string ToString()
        {
            return $"Number - {Number}, Tr - {Tr}, Tp - {Tp}, R - {R}";
        }
        
        public object Clone()
        {
            return new Vertex() { Number = this.Number, Tr = this.Tr, Tp = this.Tp, R = this.R };
        }
    }
}
