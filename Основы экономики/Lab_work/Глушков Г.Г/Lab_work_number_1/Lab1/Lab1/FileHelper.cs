using Lab1.EdgeFactory;
using Lab1.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public  class FileHelper
    {
        public string Path { get; set; }
        private AbstractFactoryEdge Factory;
        public List<Edge<IEdgeInfo<int>, int>> ReadAndGetDate()
        {
            Factory = new StandartEdgeFactory();
            List<Edge<IEdgeInfo<int>, int>> _edges = new List<Edge<IEdgeInfo<int>, int>>();
            using (StreamReader fs = new StreamReader(Path))
            {
                while (true)
                {
                    var temp = fs.ReadLine();
                    if (temp == null) break;
                    String[] words = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var _vertexFrom = Convert.ToInt32(words[0]);
                    var _vertexTo = Convert.ToInt32(words[1]);
                    var _weight = Convert.ToInt32(words[2]);
                    _edges.Add(Factory.CreateEdge(_vertexFrom, _vertexTo, _weight));
                }
            }
            return _edges;
        }
    }
}
