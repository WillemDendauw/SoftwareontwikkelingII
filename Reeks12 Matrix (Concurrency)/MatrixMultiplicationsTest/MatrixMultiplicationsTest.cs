using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixMultiplication;
using System.Threading.Tasks;

namespace MatrixMultiplicationsTest
{
    [TestClass]
    public class MatrixMultiplicationsTest
    {
        [TestMethod]
        public void TestMultiplication()
        {
            int[,] aMatrix = new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } };
            int[,] bMatrix = new int[,] { { 7, 8, 9 }, { 10, 11, 12 } };
            int[,] prodMatrix = new int[,] { { 47, 52, 57 }, { 64, 71, 78 }, { 81, 90, 99 } };
            int[,] cMatrix = MatrixOperations.MatrixProduct(aMatrix, bMatrix);
            Assert.IsTrue(MatrixOperations.AreEqual(prodMatrix, cMatrix));
        }

        [TestMethod]
        public void TestMultiplicationJagged()
        {
            int[,] aMatrix = new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } };
            int[,] bMatrix = new int[,] { { 7, 8, 9 }, { 10, 11, 12 } };
            int[,] prodMatrix = new int[,] { { 47, 52, 57 }, { 64, 71, 78 }, { 81, 90, 99 } };
            int[][] cMatrix = MatrixOperations.MatrixProductJagged(aMatrix, bMatrix);
            Assert.IsTrue(MatrixOperations.AreEqual(prodMatrix, cMatrix));
        }

        [TestMethod]
        public void TestMultiplicationThreads()
        {
            int[,] aMatrix = new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } };
            int[,] bMatrix = new int[,] { { 7, 8, 9 }, { 10, 11, 12 } };
            int[][] prodMatrix = new int[][] { 
                new int[]{ 47, 52, 57 }, 
                new int[]{ 64, 71, 78 },
                new int[]{ 81, 90, 99 }
            };
            int[][] cMatrix = MatrixOperations.MatrixProductThreads(aMatrix, bMatrix);
            Assert.IsTrue(MatrixOperations.AreEqual(prodMatrix, cMatrix));
        }

        [TestMethod]
        public void TestMultiplicationTasks()
        {
            int[,] aMatrix = new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } };
            int[,] bMatrix = new int[,] { { 7, 8, 9 }, { 10, 11, 12 } };
            int[][] prodMatrix = new int[][] {
                new int[] { 47, 52, 57 },
                new int[] { 64, 71, 78 },
                new int[] { 81, 90, 99 }
            };
            Assert.IsTrue(MatrixOperations.AreEqual(prodMatrix, MatrixOperations.MatrixProductTasks(aMatrix, bMatrix)));
        }

        [TestMethod]
        public void TestMultiplicationAsync()
        {
            int[,] aMatrix = new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } };
            int[,] bMatrix = new int[,] { { 7, 8, 9 }, { 10, 11, 12 } };
            int[][] prodMatrix = new int[][] {
                new int[] { 47, 52, 57 },
                new int[] { 64, 71, 78 },
                new int[] { 81, 90, 99 }
            };
            Task<int[][]> prodTask = MatrixOperations.MatrixProductAsync(aMatrix, bMatrix, MatrixOperations.MatrixProductRow);
            Assert.IsTrue(MatrixOperations.AreEqual(prodMatrix, prodTask.Result));
        }

        [TestMethod]
        public void TestAll()
        {
            int[,] aMatrix = MatrixOperations.CreateMatrix(30);
            int[,] bMatrix = MatrixOperations.CreateMatrix(30);

            int[][] prod1 = MatrixOperations.MatrixProductRow(aMatrix, bMatrix);
            int[][] prod2 = MatrixOperations.MatrixProductThreads(aMatrix, bMatrix);
            int[][] prod3 = MatrixOperations.MatrixProductThreads(aMatrix, bMatrix);
            Task<int[][]> prod4 = MatrixOperations.MatrixProductAsync(aMatrix, bMatrix, MatrixOperations.MatrixProductRow);

            Assert.IsTrue(MatrixOperations.AreEqual(prod2, prod1));
            Assert.IsTrue(MatrixOperations.AreEqual(prod3, prod1));
            Assert.IsTrue(MatrixOperations.AreEqual(prod2, prod3));
            Assert.IsTrue(MatrixOperations.AreEqual(prod1, prod4.Result));
        }
    }
}
