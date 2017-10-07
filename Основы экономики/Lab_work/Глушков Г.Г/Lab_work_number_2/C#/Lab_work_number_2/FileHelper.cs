using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_work_number_2
{
    public class FileHelper
    {
        public string Path { get; set; }
        public List<Edge> ReadAndGetDate()
        {
            List<Edge> _edges = new List<Edge>();
            using (StreamReader fs = new StreamReader(Path))
            {
                while (true)
                {
                    var temp = fs.ReadLine();
                    if (temp == null) break;
                    var data = (IEnumerable<string>)temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if(data.Count() == 3)
                    {
                        _edges.Add(new Edge(data));
                    }
                   
                }
            }
            return _edges;
        }
    }
}
