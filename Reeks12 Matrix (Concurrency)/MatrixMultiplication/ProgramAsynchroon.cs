using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplication
{

    class ProgramAsynchoon
    {

        static Dictionary<string, MatProd> methods = new Dictionary<string, MatProd>(); //methode die Jagged Array teruggeeft

        //hoofdprogramma is asynchroon - zal wachten op volledige uitvoering
        static async Task Main(string[] args)
        {
            methods.Add("Jagged", MatrixOperations.MatrixProductJagged);
            methods.Add("Jagged_Row", MatrixOperations.MatrixProductRow);
            methods.Add("Threads", MatrixOperations.MatrixProductThreads);
            methods.Add("Tasks", MatrixOperations.MatrixProductTasks);
            //await Deel4AsyncSequentialVoid(); //wacht tot de methode volledig is uitgevoerd
            int[][][][] results = await Deel4AsyncSequentialMetResults();
            Console.WriteLine();
            Console.ReadKey();
        }

        private static async Task Deel4AsyncSequentialVoid()
        {
            foreach (string type in methods.Keys)
            {
                Stopwatch stopWatch = new Stopwatch();
                Console.Write("Gestart " + type + "\n");
                stopWatch.Start();
                int aantal = await VoerUit(type); //wacht tot de methode volledig is uitgevoerd
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine(aantal + " tasks in " + ts.TotalSeconds + " seconden");
            }
        }

        private static async Task<int> VoerUit(string type)
        {
            int[] dimensies = { 1000, 500, 100, 800, 700, 300 }; //willekeurige volgorde

            List<Task<int[][]>> tasks = new List<Task<int[][]>>();
            //asynchroon opstarten van de matrixberekeningen.
            for (int i = 0; i < dimensies.Length; i++)
            {
                int dim = dimensies[i];
                int[,] a = MatrixOperations.CreateMatrix(dim);
                int[,] b = MatrixOperations.CreateMatrix(dim);
                Console.WriteLine("\t" + type + ": gestart: " + dim);
                tasks.Add(MatrixOperations.MatrixProductAsync(a, b, methods[type]));
            }
            int aantal = tasks.Count;
            while (tasks.Count > 0)
            {
                // When any await the first task to finish and returns it.
                Task<int[][]> finishedTask = await Task.WhenAny(tasks);

                // We can now await the completed task without waiting as we know it has already finished.
                int[][] product = await finishedTask;
                Console.WriteLine("\t" + type + ": Afgewerkt:" + product.GetLength(0) + "x" + product[0].GetLength(0));
                // Remove the finished task from the list so that you don't process it more than once.
                tasks.Remove(finishedTask);
            }
            return aantal;
        }


        private static async Task<int[][][][]> Deel4AsyncSequentialMetResults()
        {
            int[][][][] tasks = new int[methods.Keys.Count()][][][];
            int i = 0;
            foreach (string type in methods.Keys)
            {
                Stopwatch stopWatch = new Stopwatch();
                Console.Write("Gestart " + type + "\n");
                stopWatch.Start();
                var t = await VoerUitMetReturn(type);
                tasks[i] = t;
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine(" in " + ts.TotalSeconds + " seconden");
                i++;
            }
            return tasks;
        }
        private static async Task<int[][][]> VoerUitMetReturn(string type)
        {
            int[] dimensies = { 1000, 500, 100, 800, 700, 300 }; //willekeurige volgorde

            List<Task<int[][]>> tasks = new List<Task<int[][]>>();
            //asynchroon opstarten van de matrixberekeningen.
            for (int i = 0; i < dimensies.Length; i++)
            {
                int dim = dimensies[i];
                int[,] a = MatrixOperations.CreateMatrix(dim);
                int[,] b = MatrixOperations.CreateMatrix(dim);
                Console.WriteLine("\t" + type + ": gestart: " + dim);
                tasks.Add(MatrixOperations.MatrixProductAsync(a, b, methods[type]));
            }
            int aantal = tasks.Count;
            while (tasks.Count > 0)
            {
                // When any await the first task to finish and returns it.
                Task<int[][]> finishedTask = await Task.WhenAny(tasks);

                // We can now await the completed task without waiting as we know it has already finished.
                int[][] product = await finishedTask;
                Console.WriteLine("\t" + type + ": Afgewerkt:" + product.GetLength(0) + "x" + product[0].GetLength(0));
                // Remove the finished task from the list so that you don't process it more than once.
                tasks.Remove(finishedTask);
            }
            var allTasks = await Task.WhenAll(tasks);
            return allTasks;
        }

    }
}
