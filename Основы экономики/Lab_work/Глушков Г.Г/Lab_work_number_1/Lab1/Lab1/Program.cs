using Lab1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHelper fh = new FileHelper() { Path = @"Test1.txt" };
            var data = fh.ReadAndGetDate();
            List<int> fromSet = new List<int>();
            List<int> toSet = new List<int>();
            fromSet.AddRange(data.Select(x => x.VertexFrom.GetVertexValue()));
            toSet.AddRange(data.Select(x => x.VertexTo.GetVertexValue()));
            var filterFromSet = fromSet.Except(toSet).ToList();
            var filterToSet = toSet.Except(fromSet).ToList();

            //Начальная и конечная
            var startPoint = MasterVertex.MergePoint("Начальная", filterFromSet,ref data);
            var endPoint = MasterVertex.MergePoint("Конечная", filterToSet, ref data);

            //Ответ будет здесь
            var endList = new List<Edge<IEdgeInfo<int>, int>>();


            var currentPoints = new LinkedList<int>();
            if(startPoint!=null)
                currentPoints.AddFirst((int)startPoint);
            var usedPoints = new HashSet<int>();
            while(data.Count > 0)
            {
                var item = currentPoints.ElementAt(0);
                currentPoints.RemoveFirst();
                usedPoints.Add(item);
                
                if(data.Count(x => x.VertexTo.GetVertexValue() == item) >0)
                {
                    currentPoints.AddLast(item);
                    continue;
                }
                var _DATA = data.Where(x => x.VertexFrom.GetVertexValue() == item).ToList();
                foreach(var _item in _DATA)
                {
                    endList.Add(_item); 
                    var except = usedPoints.Count(x => x == _item.VertexTo.GetVertexValue());
                    if (except == 0)
                        currentPoints.AddLast(_item.VertexTo.GetVertexValue());
                    data.Remove(_item);
                }

            }
            Console.WriteLine($"Начальная вершина - {startPoint}");
            Console.WriteLine($"Конечная вершина - {endPoint}");
            foreach (var item in endList)
            {
                Console.WriteLine($"{item.VertexFrom.GetVertexValue()} {item.VertexTo.GetVertexValue()}");
            }

            Console.ReadLine();
        }   

    }
}
