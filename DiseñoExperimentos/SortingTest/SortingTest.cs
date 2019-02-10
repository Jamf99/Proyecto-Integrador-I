using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiseñoExperimentos;

namespace SortingTest
{
    [TestClass]
    public class SortingTest
    {

        private SortingAlgorithms algorithms;

        int[] esperado = { -97, -94, -85, -85, -83, -82, -79, -76, -76, -75, -68, -68, -66, -64, -64, -64, -63, -60, -56, -55,
            -53, -51, -51, -49, -48, -46, -40, -39, -39, -36, -32, -32, -31, -30, -30, -28, -27, -25, -25, -19, -17, -12, -11,
            -10, -9, -5, -1, 1, 6, 6, 9, 9, 11, 13, 15, 18, 19, 21, 22, 26, 26, 26, 31, 32, 45, 48, 48, 50, 50, 50, 52, 53, 54,
            57, 58, 58, 59, 61, 63, 65, 67, 68, 68, 69, 73, 76, 79, 80, 80, 80, 81, 82, 83, 84, 87, 87, 92, 93, 99, 99};

        private int[] numerosPequeñosDesordenados = { -31, -32, -68, 99, -1, -9, 45, 87, 81, -12, 26, 99, -94, -82, 76, -51, 19,
                -64, -49, -53, -25, 52, -17, 69, -85, -30, 73, 26, 6, 57, -10, 68, -83, 54, -56, -40, 53, 50, 80, -68, -32, 59, -64, 18,
                87, 83, 32, 50, -30, -85, 21, -64, 63, -51, 9, 50, -60, 65, -75, 15, -39, 31, -5, 13, 6, -76, -11, -79, 22, -28, 9, 48, 82, 93,
                -36, 61, 80, -66, -25, -76, -63, -39, -19, 26, 92, 58, 80, -48, 11, -97, 58, 68, 84, -27, 67, 79, -46, 48, -55, 1 };

        private int[] numerosPequeñosInverso = { 99, 99, 93, 92, 87, 87, 84, 83, 82, 81, 80, 80, 80, 79, 76, 73, 69, 68, 68, 67, 65,
            63, 61, 59, 58, 58, 57, 54, 53, 52, 50, 50, 50, 48, 48, 45, 32, 31, 26, 26, 26, 22, 21, 19, 18, 15, 13, 11, 9, 9, 6, 6,
            1, -1, -5, -9, -10, -11, -12, -17, -19, -25, -25, -27, -28, -30, -30, -31, -32, -32, -36, -39, -39, -40, -46, -48, -49,
            -51, -51, -53, -55, -56, -60, -63, -64, -64, -64, -66, -68, -68, -75, -76, -76, -79, -82, -83, -85, -85, -94, -97 };


        public void escenarioUno()
        {
            algorithms = new SortingAlgorithms();
        }

        [TestMethod]
        public void TestHeapSort1()
        {
            escenarioUno();
            algorithms.heapSort(numerosPequeñosDesordenados, 100);
            CollectionAssert.AreEqual(numerosPequeñosDesordenados, esperado);
        }

        [TestMethod]
        public void TestHeapSort2()
        {
            escenarioUno();
            algorithms.heapSort(numerosPequeñosInverso, 100);
            CollectionAssert.AreEqual(numerosPequeñosInverso, esperado);
        }

    }
}
