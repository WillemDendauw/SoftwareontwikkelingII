using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MatrixMultiplication
{
    public delegate int[][] MatProd(int[,] a, int[,] b);
    public class MatrixOperations
    {
        /******************* THREADS **********************************/
        public static int[][] MatrixProductThreads(int[,] aMatrix, int[,] bMatrix)
        {
            if(aMatrix.GetLength(1) != bMatrix.GetLength(0))
            {
                throw new Exception("Invalid Dimensions");
            }

            int n = aMatrix.GetLength(0);
            int[][] abMatrix = new int[n][];

            Thread[] threads = new Thread[n];

            for(int row = 0; row < n; row++)
            {
                int rownr = row;
                threads[rownr] = new Thread(() =>
                    abMatrix[rownr] = CalculateRow(aMatrix, bMatrix, rownr)
                    );
                threads[rownr].Start();
            }
            for(int row = 0; row < n; row++)
            {
                threads[row].Join();
            }
            return abMatrix;
        }

        /*********************** TASKS *********************************/

        public static int[][] MatrixProductTasks(int[,] aMatrix, int[,] bMatrix)
        {
            if (aMatrix.GetLength(1) != bMatrix.GetLength(0))
            {
                throw new Exception("Invalid Dimensionsj");
            }

            int n = aMatrix.GetLength(0);
            int[][] abMatrix = new int[n][];

            Task<int[]>[] tasks = new Task<int[]>[n];

            for(int row =0; row < n; row++)
            {
                int rownr = row;
                tasks[rownr] = new Task<int[]>(() =>
                   CalculateRow(aMatrix, bMatrix, rownr)
                    );
                tasks[rownr].Start();
            }
            for(int row =0; row < n; row++)
            {
                tasks[row].Wait();
                abMatrix[row] = tasks[row].Result;
            }
            return abMatrix;
        }

        /******************** ASYNCHROON ****************************/

        public static async Task<int[][]> MatrixProductAsync(int[,] aMatrix, int[,] bMatrix, MatProd methodProd)
        {
            int[][] product = await Task.Run(() => methodProd?.Invoke(aMatrix, bMatrix));
            return product;
        }

        /*********************** Eerste Deel *************************/

        public static int[][] MatrixProductJagged(int[,] aMatrix, int[,] bMatrix)
        {
            if(aMatrix.GetLength(1) != bMatrix.GetLength(0))
            {
                throw new Exception("Invalid Dimensions");
            }
            int n = aMatrix.GetLength(0);
            int m = aMatrix.GetLength(1);
            int p = bMatrix.GetLength(1);
            int[][] abMatrix = new int[n][];

            for(int row =0; row <n; row++)
            {
                abMatrix[row] = new int[p];
                for(int col = 0; col < p; col++)
                {
                    for(int inner = 0; inner < m; inner++)
                    {
                        abMatrix[row][col] += aMatrix[row, inner] * bMatrix[inner, col];
                    }
                }
            }
            return abMatrix;
        }

        //Berekenen 1 rij
        public static int[] CalculateRow(int[,] aMatrix, int[,] bMatrix, int row)
        {
            int m = aMatrix.GetLength(1);
            int p = bMatrix.GetLength(1);
            int[] rij = new int[p];
            for (int col = 0; col < p; col++)
            {
                for(int inner=0; inner < m; inner++)
                {
                    rij[col] += aMatrix[row, inner] * bMatrix[inner, col];
                }
            }
            return rij;
        }

        public static int[][] MatrixProductRow(int[,] aMatrix, int[,] bMatrix)
        {
            if(aMatrix.GetLength(1) != bMatrix.GetLength(0))
            {
                throw new Exception("Invalid Dimensions");
            }
            int n = aMatrix.GetLength(0);
            int[][] abMatrix = new int[n][];

            for(int row = 0; row < n; row++)
            {
                abMatrix[row] = CalculateRow(aMatrix, bMatrix, row);
            }
            return abMatrix;
        }

        public static int[,] CreateMatrix(int dim)
        {
            int[,] m = new int[dim, dim];
            Random r = new Random();
            for(int i = 0; i < dim; i++)
            {
                for(int j=0; j < dim; j++)
                {
                    m[i, j] = r.Next() % 100;
                }
            }
            return m;
        }

        //gegeven methode
        public static int[,] MatrixProduct(int[,] aMatrix, int[,] bMatrix)
        {
            if (aMatrix.GetLength(1) != bMatrix.GetLength(0))
            {
                throw new Exception("Invalid dimensions");
            }
            int n = aMatrix.GetLength(0);
            int m = aMatrix.GetLength(1);
            int p = bMatrix.GetLength(1);

            int[,] abMatrix = new int[n, p];

            for(int row =0;row <n; row++)
            {
                for(int col = 0; col < p; col++)
                {
                    for(int inner =0; inner < m; inner++)
                    {
                        abMatrix[row, col] += aMatrix[row, inner] * bMatrix[inner, col];
                    }
                }
            }
            return abMatrix;
        }

        static public void Show(int[,] mat)
        {
            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j =0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static public void Show(int[][] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat[i].GetLength(0); j++)
                {
                    Console.Write(mat[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static public bool AreEqual(int[,] a, int[,] b)
        {
            bool ok = (a.GetLength(0) == b.GetLength(0)) && (a.GetLength(1) == b.GetLength(1));
            if (ok)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); i++)
                    {
                        if (a[i,j] != b[i,j])
                        {
                            ok = false;
                        }
                    }
                }
            }
            return ok;
        }

        static public bool AreEqual(int[][] a, int[][] b)
        {
            bool ok = (a.GetLength(0) == b.GetLength(0)) && (a[0].GetLength(0) == b[0].GetLength(0));
            if (ok)
            {
                for(int i = 0; i < a.GetLength(0); i++)
                {
                    for(int j=0; j<a[i].GetLength(0); i++)
                    {
                        if(a[i][j] != b[i][j])
                        {
                            ok = false;
                        }
                    }
                }
            }
            return ok;
        }

        static public bool AreEqual(int[,] a, int[][] b)
        {
            bool ok = (a.GetLength(0) == b.GetLength(0)) && (a.GetLength(1) == b[0].GetLength(0));
            if (ok)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] != b[i][j]) ok = false;
                    }
                }
            }
            return ok;
        }
    }
}
