using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiseñoExperimentos;

namespace SortingTest
{
    [TestClass]
    public class SortingTest
    {

        private SortingAlgorithms algorithms;

        int[] esperado = { -23, -1, 0, 1, 1, 1, 2, 2, 3, 3, 5, 6, 52 };

        private int[] numerosPequeñosDesordenados = { -31, -32, -68, 99, -1, -9, 45, 87, 81, -12, 26, 99, -94, -82, 76, -51, 19,
                -64, -49, -53, -25, 52, -17, 69, -85, -30, 73, 26, 6, 57, -10, 68, -83, 54, -56, -40, 53, 50, 80, -68, -32, 59, -64, 18,
                87, 83, 32, 50, -30, -85, 21, -64, 63, -51, 9, 50, -60, 65, -75, 15, -39, 31, -5, 13, 6, -76, -11, -79, 22, -28, 9, 48, 82, 93,
                -36, 61, 80, -66, -25, -76, -63, -39, -19, 26, 92, 58, 80, -48, 11, -97, 58, 68, 84, -27, 67, 79, -46, 48, -55, 1 };
        private int[] numerosPequeñosInverso = {52, 6, 5, 3, 3, 2, 2, 1, 1, 1,0, -1, -23 };


        public void escenarioUno()
        {
            algorithms = new SortingAlgorithms();
        }

        [TestMethod]
        public void TestHeapSort1()
        {
            escenarioUno();
            algorithms.heapSort(numerosPequeñosDesordenados, 13);
            CollectionAssert.AreEqual(numerosPequeñosDesordenados, esperado);
        }

        [TestMethod]
        public void TestHeapSort2()
        {
            escenarioUno();
            algorithms.heapSort(numerosPequeñosInverso, 13);
            CollectionAssert.AreEqual(numerosPequeñosInverso, esperado);
        }

    }
}
