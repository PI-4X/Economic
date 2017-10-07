using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_work_number_2
{
    class Program
    {
        public static List<Edge> Table;
        public static List<bool> CheckVertex;
        public static List<Vertex> Parametrs;
        public static Edge NUM;
        public static int last;
        static void Main(string[] args)
        {
            CheckVertex = new List<bool>(10) { false, false, false, false, false, false, false, false, false, false };
            Parametrs = new List<Vertex>();
            var helper = new FileHelper() { Path = "input.txt" };
            Table = helper.ReadAndGetDate();
            foreach(var item in Table)
            {
                Console.WriteLine(item.ToString());
            }
            int begin = SearchBegin();
            int end = SearchEnd();
            last = end;
            var fin = GetFinal(begin);
            Console.WriteLine($"{Environment.NewLine}Sorted data");
            fin.ForEach(item => Console.WriteLine(item.ToString()));
            
            Table = new List<Edge>(fin);
            
            if(CheckCyc(new Edge(-999, Table[0].VertexFrom.Number, 0)))
            {
                Console.WriteLine("Cycles found. Deleting cycles.");
                DelCyc();
                Console.WriteLine("After deleting cycles:");
                Table.ForEach(x => Console.WriteLine(x.ToString()));                  
            }
            else Console.WriteLine("Cycles not found");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Calculating parameters:");
            GetParametr();
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine("Free and full reserves:");
            GetRes();
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine("Critic ways:");
            GetCrit(new List<int>(), Parametrs[0].Number);
            Console.WriteLine($"Length: {Parametrs[Parametrs.Count() - 1].Tp}");
           
            Console.ReadLine();


        }


        public static int SearchBegin()
        {
            List<int> NumberList = new List<int>();
            bool flag = false;
            for (int i = 0; i < Table.Count(); i++)
            {
                
                for (int j = 0; j < NumberList.Count(); j++)
                {
                    if (Table[i].VertexFrom.Number == NumberList.ElementAt(j)) flag = true;
                }
                if (!flag) NumberList.Add(Table[i].VertexFrom.Number);
            }
            for (int i = 0; i < Table.Count(); i++)
            {
                for (int j = 0; j < NumberList.Count(); j++)
                {
                    if (Table[i].VertexTo.Number == NumberList.ElementAt(j)) NumberList.RemoveAt(j);
                }
            }
            if (NumberList.Count() == 1)
                return NumberList.ElementAt(0);
            int number;

            Console.WriteLine("More than one begining vertexes found");

            Console.WriteLine("Creating new fake vertex");
            flag = false;
            do
            {
                flag = false;
                Console.WriteLine("Enter number of vertex: ");
                number = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < Table.Count(); i++)
                {
                    if (Table[i].VertexFrom.Number == number || Table[i].VertexTo.Number == number) flag = true;
                }
                if (flag) Console.WriteLine("Vertex already exists");
            } while (flag);
            for (int i = 0; i < NumberList.Count(); i++)
            {
                Table.Add(new Edge(number, NumberList.ElementAt(i), 0));
            }
            return number;
        }
        public static int SearchEnd()
        {
            List<int> NumberList = new List<int>();
            bool flag = false;
            for (int i = 0; i < Table.Count(); i++)
            {
                
                for (int j = 0; j < NumberList.Count(); j++)
                {
                    if (Table[i].VertexTo.Number == NumberList[j]) flag = true;
                }
                if (!flag) NumberList.Add(Table[i].VertexTo.Number);
            }
            for (int i = 0; i < Table.Count(); i++)
            {
                for (int j = 0; j < NumberList.Count(); j++)
                {
                    if (Table[i].VertexFrom.Number == NumberList[j]) NumberList.RemoveAt(j);
                }
            }
            if (NumberList.Count() == 1)
                return NumberList[0];
            int number;


            Console.WriteLine("More than one ending vertexes found");

            Console.WriteLine("Create new fare vertex");

            flag = false;
            do
            {
                flag = false;
                Console.WriteLine("Enter number of vertex: ");
                number = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < Table.Count(); i++)
                {
                    if (Table[i].VertexFrom.Number == number || Table[i].VertexTo.Number == number) flag = true;
                }
                if (flag) Console.WriteLine("Vertex already exists");
            } while (flag);
            for (int i = 0; i < NumberList.Count(); i++)
            {
                Table.Add(new Edge(NumberList[i], number, 0));
            }
            return number;
        }
        public static List<Edge> GetFinal(int number)
        {
            List<Edge> Set = new List<Edge>();
            Queue<Edge> queue = new Queue<Edge>();
            for (int i = 0; i < Table.Count(); i++)
            {
                if (Table[i].VertexFrom.Number == number) { queue.Enqueue(Table[i]); Set.Add(Table[i]); Table.RemoveAt(i); i--; }
            }
            while (queue.Count > 0)
            {
                Edge temp = queue.Dequeue();
                for (int i = 0; i < Table.Count(); i++)
                {
                    if (temp.VertexTo.Number == Table[i].VertexFrom.Number) { queue.Enqueue(Table[i]); Set.Add(Table[i]); Table.RemoveAt(i); i--; }
                }
            }
            return Set;
        }
        public static bool CheckCyc(Edge edge)
        {
            if (edge.VertexFrom.Number == edge.VertexTo.Number) { return true; }
            for (int i = 0; i < Table.Count(); i++)
            {
                if (edge.VertexTo.Number == Table[i].VertexFrom.Number)
                {
                    if (CheckVertex[i] == true) { NUM = (Edge)edge.Clone(); return true; }
                    CheckVertex[i] = true;
                    if (CheckCyc(Table[i])) return true;
                }
            }
            if (edge.VertexFrom.Number != -999) CheckVertex[GetNum(edge)] = false;
            return false;
        }
        public static int GetNum(int number)
        {
            for (int i = 0; i < Parametrs.Count(); i++)
            {
                if (number == Parametrs[i].Number) return i;
            }
            return -999;
        }
        public static int GetNum(Edge edge)
        {
            for (int i = 0; i < Table.Count(); i++)
            {
                if (edge.VertexFrom.Number == Table[i].VertexFrom.Number && edge.VertexTo.Number == Table[i].VertexTo.Number) return i;
            }
            throw new Exception("Таблица пуста");
        }
        public static void GetParametr()
        {
            for (int i = 0; i < Table.Count(); i++)
            {
                int n = GetNum(Table[i].VertexFrom.Number);
                if (n == -999) Parametrs.Add(Table[i].VertexFrom);
            }
            Parametrs.Add(new Vertex(last));

            for (int i = 1; i < Parametrs.Count(); i++)
            {
                for (int j = 0; j < Table.Count(); j++)
                {
                    if (Table[j].VertexTo.Number == Parametrs[i].Number &&
                        Parametrs[i].Tr < Parametrs[GetNum(Table[j].VertexFrom.Number)].Tr + Table[j].Weight)
                        Parametrs[i].Tr = Parametrs[GetNum(Table[j].VertexFrom.Number)].Tr + Table[j].Weight;
                }
            }
            for (int i = 1; i < Parametrs.Count(); i++)
            {
                for (int j = 0; j < Table.Count(); j++)
                {
                    if (Table[j].VertexTo.Number == Parametrs[i].Number &&
                        Parametrs[i].Tr < Parametrs[GetNum(Table[j].VertexFrom.Number)].Tr + Table[j].Weight)
                        Parametrs[i].Tr = Parametrs[GetNum(Table[j].VertexFrom.Number)].Tr + Table[j].Weight;
                }
            }

            Parametrs[Parametrs.Count() - 1].Tp = Parametrs[Parametrs.Count() - 1].Tr;
            for (int i = Parametrs.Count() - 2; i >= 0; i--)
            {
                for (int j = 0; j < Table.Count(); j++)
                {
                    if (Table[j].VertexFrom.Number == Parametrs[i].Number &&
                        Parametrs[i].Tp > Parametrs[GetNum(Table[j].VertexTo.Number)].Tp - Table[j].Weight)
                    {
                        Parametrs[i].Tp = Parametrs[GetNum(Table[j].VertexTo.Number)].Tp - Table[j].Weight;
                    }
                }
            }
            for (int i = Parametrs.Count() - 2; i >= 0; i--)
            {
                for (int j = 0; j < Table.Count(); j++)
                {
                    if (Table[j].VertexFrom.Number == Parametrs[i].Number &&
                        Parametrs[i].Tp > Parametrs[GetNum(Table[j].VertexTo.Number)].Tp - Table[j].Weight)
                    {
                        Parametrs[i].Tp = Parametrs[GetNum(Table[j].VertexTo.Number)].Tp - Table[j].Weight;
                    }
                }
            }

            Console.WriteLine("i\tTp\tTn\tPi");

            for (int i = 0; i < Parametrs.Count(); i++)
            {
                Parametrs[i].R = Parametrs[i].Tp - Parametrs[i].Tr;
                Console.WriteLine($"{ Parametrs[i].Number}  \t  {Parametrs[i].Tr} \t  {Parametrs[i].Tp} \t {Parametrs[i].R}");
            }

        }
        public static void DelCyc()
        {
            for (int i = 0; i < Table.Count(); i++)
            {
                if (Table[i].VertexFrom.Number == Table[i].VertexTo.Number)
                {

                    Table.RemoveAt(i);
                }
            }
            for (int i = 0; i < CheckVertex.Count(); i++) CheckVertex[i] = false;
            
            while (CheckCyc(new Edge(-666, Table[0].VertexFrom.Number, 0)))
            {
                List<Edge> temp = new List<Edge>();
                for (int i = 0; i < CheckVertex.Count(); i++) CheckVertex[i] = false;
                
                temp.Add(NUM);
                Edge temp2 = NUM;
                bool flag = false;
                for (int j = 0; j < Table.Count() && !flag; j++)
                {
                    if (Table[j].VertexFrom.Number == temp2.VertexFrom.Number && Table[j].VertexTo.Number != temp2.VertexTo.Number)
                        flag = true;
                }

                while (temp2.VertexFrom.Number != NUM.VertexTo.Number && !flag)
                {
                    flag = false;
                    for (int i = 0; i < Table.Count() && !flag; i++)
                    {
                        if (Table[i].VertexTo.Number == temp2.VertexFrom.Number)
                        {
                            for (int j = 0; j < Table.Count() && !flag; j++)
                            {
                                if (Table[j].VertexFrom.Number == Table[i].VertexFrom.Number && Table[j].VertexTo.Number != Table[i].VertexTo.Number)
                                    flag = true;
                            }
                            //					if(temp2.i!=NUM.j&&!flag){
                            temp2 = Table[i];
                            temp.Add(temp2);//}
                        }
                    }
                }


                for (int i = 0; i < temp.Count(); i++)
                {
                    Table.RemoveAt(GetNum(temp[i]));
                }
            }
        }
        public static List<int> GetCrit(List<int> a, int n)
        {
            a.Add(n);
            if (n == Parametrs[GetNum(last)].Number)
            {
                for (int i = 0; i < a.Count(); i++) Console.Write($"{a[i]}  ");
                Console.WriteLine(Environment.NewLine);
            }
            for (int i = 0; i < Table.Count(); i++)
            {
                if (Table[i].VertexFrom.Number == n && Parametrs[GetNum(Table[i].VertexTo.Number)].R == 0)
                    GetCrit(a, Table[i].VertexTo.Number);
            }
            a.RemoveAt((a.Count() - 1));
            return a;
        }
        public static void GetRes()
        {

            Console.WriteLine("i;j\t\tPп\tPс\t");

            for (int i = 0; i < Table.Count(); i++)
            {
                int r = Parametrs[GetNum(Table[i].VertexTo.Number)].Tp -
                    Parametrs[GetNum(Table[i].VertexFrom.Number)].Tr - Table[i].Weight;
                int r2 = Parametrs[GetNum(Table[i].VertexTo.Number)].Tr -
                    Parametrs[GetNum(Table[i].VertexFrom.Number)].Tp - Table[i].Weight;
                Console.WriteLine($"{Table[i].ConsoleVertex()}\t{r}\t{r2} ");
            }
        }



    }
}
