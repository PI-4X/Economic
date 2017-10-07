using Lab1.EdgeFactory;
using Lab1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class MasterVertex
    {
       public static Nullable<int> MergePoint(string which, List<int> EdgeSet , ref List<Edge<IEdgeInfo<int>, int>> shiftSet)
        {
            AbstractFactoryEdge Factory = new StandartEdgeFactory();           
            
            if (EdgeSet.Count > 1)
            {
                Console.WriteLine($"{which} вершина не одна, создать фиктивную или выйти?(Y n)");
                if (Console.ReadLine() == "n")
                    return null;
                else
                {
                    Console.WriteLine("Введите ее метку: ");
                    var answer = Console.ReadLine();
                    var label = Convert.ToInt32(answer != null ? answer : "-1");
                    var fictEnd = EdgeSet.Select(x => Factory.CreateEdge(x, label, 0));
                    var fictStart = EdgeSet.Select(x => Factory.CreateEdge(label, x, 0));

                    if (which == "Конечная")
                        shiftSet.AddRange(fictEnd);
                    else
                        shiftSet.AddRange(fictStart);
                    return label;
                }              
            }
            return EdgeSet.ElementAt(0);
        }

    }
}
