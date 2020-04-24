using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplication
{
    class Program
    {
        static int ITERATIONS = 5;
        static int MAXDIM = 1000;
        static int STEP = 100;
        static Dictionary<string, MatProd> methods = new Dictionary<string, MatProd>();
        static void Main(string[] args)
        {
            methods.Add("Jagged", MatrixOperations.MatrixProductJagged);
            methods.Add("Jagged_Row", MatrixOperations.MatrixProductRow);
            methods.Add("Threads", MatrixOperations.MatrixProductThreads);
            methods.Add("Tasks", MatrixOperations.MatrixProductTasks);

            Deel1();
            Deel2Async();
            Deel3Async();
            Console.WriteLine("Druk pas op enter als alles is uitgeoverd");
            Console.ReadKey();
        }

        #region Threads_Tasks
        private static void Deel1()
        {
            string uitvoer = "result.csv";
            using(StreamWriter outfile = new StreamWriter(uitvoer))
            {
                outfile.Write("tijd;");
                foreach(string type in methods.Keys)
                {
                    outfile.Write(type + ";");
                }
                outfile.WriteLine();

                for(int dim = 100; dim<=MAXDIM; dim = dim + STEP)
                {
                    Console.WriteLine(dim + "x" +dim);
                    outfile.Write(dim + ";");
                    foreach(MatProd methodeProd in methods.Values)
                    {
                        double tijd = Simuleer(dim, methodeProd);
                        outfile.Write(tijd + ";");
                    }
                    outfile.WriteLine();
                }
            }
            Console.WriteLine("Bekijk informatie in " + uitvoer);
        }

        private static double Simuleer(int dim, MatProd methodeProd)
        {
            double[] tijden = new double[ITERATIONS];
            for(int i=0; i<ITERATIONS; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                int[,] a = MatrixOperations.CreateMatrix(dim);
                int[,] b = MatrixOperations.CreateMatrix(dim);
                int[][] c = methodeProd?.Invoke(a, b);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                tijden[i] = ts.TotalSeconds;
            }
            return tijden.Average();
        }

        #endregion

        #region Async_Involgorde
        private static void Deel2Async()
        {
            foreach(string type in methods.Keys)
            {
                Stopwatch stopWatch = new Stopwatch();
                Console.Write("\nGestart " + type + "\n");
                stopWatch.Start();
                VoerUit(type);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine(" in " + ts.TotalSeconds + " seconden");
            }
        }

        private static void VoerUit(string type)
        {
            List<Task<int[][]>> tasks = new List<Task<int[][]>>();
            //asynchroon opstarten van de matrixberekeningen.
            for(int dim=100;dim<=MAXDIM;dim = dim+ STEP)
            {
                int[,] a = MatrixOperations.CreateMatrix(dim);
                int[,] b = MatrixOperations.CreateMatrix(dim);
                Console.WriteLine("\tGestart: " + dim);
                tasks.Add(MatrixOperations.MatrixProductAsync(a, b, methods[type]));
            }
            foreach(Task<int[][]> t in tasks)
            {
                int[][] product = t.Result;
                Console.WriteLine("\tAfgewerkt: " + product.GetLength(0) + "x" + product[product.GetLength(0) - 1].GetLength(0));
            }
            Console.Write(tasks.Count + " taksks afgewerkt");
        }
        #endregion

        #region AsyncWillekeurigeVolgorde
        private static void Deel3Async()
        {
            foreach(string type in methods.Keys)
            {
                Stopwatch stopWatch = new Stopwatch();
                Console.Write("\nGestart " + type + "\n");
                stopWatch.Start();
                Task t = VoerUit2Async(type);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine(" in " + ts.TotalSeconds + " seconden !!! is foutief");
            }
        }

        private static async Task VoerUit2Async(string type)
        {
            int[] dimensies = { 1000, 500, 100, 800, 700, 300 }; // willkeurige volgorde

            List<Task<int[][]>> tasks = new List<Task<int[][]>>();
            for(int i = 0; i < dimensies.Length; i++)
            {
                int dim = dimensies[i];
                int[,] a = MatrixOperations.CreateMatrix(dim);
                int[,] b = MatrixOperations.CreateMatrix(dim);
                Console.WriteLine("\tGestart: " + dim);
                tasks.Add(MatrixOperations.MatrixProductAsync(a, b, methods[type]));
            }
            Console.WriteLine("aanal tasks= " + tasks.Count);
            while(tasks.Count > 0)
            {
                //eerste task die klaar is
                Task<int[][]> firstFinishedTask = await Task.WhenAny(tasks);
                int[][] product = firstFinishedTask.Result;
                Console.Write("\t"+type+" afgewerkt: "+product.GetLength(0) + "x" + product[product.GetLength(0) - 1].GetLength(0));

                //taak verwijderen
                tasks.Remove(firstFinishedTask);
                Console.WriteLine(" Resterende tasks= " + tasks.Count);
            }
        }
        #endregion
    }
}
