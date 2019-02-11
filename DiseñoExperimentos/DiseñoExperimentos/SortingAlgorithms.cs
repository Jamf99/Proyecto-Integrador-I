using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiseñoExperimentos
{
    public class SortingAlgorithms
    {
        public void heapSort(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
        }
        static void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            }
        }

        public void IntroSort(int[] data)
        {
            int partitionSize = Partition(ref data, 0, data.Length - 1);

            if (partitionSize < 16)
            {
                InsertionSort(ref data);
            }
            else if (partitionSize > (2 * Math.Log(data.Length)))
            {
                HeapSort(ref data);
            }
            else
            {
                QuickSortRecursive(ref data, 0, data.Length - 1);
            }
        }

        private static void InsertionSort(ref int[] data)
        {
            for (int i = 1; i < data.Length; ++i)
            {
                int j = i;

                while ((j > 0))
                {
                    if (data[j - 1] > data[j])
                    {
                        data[j - 1] ^= data[j];
                        data[j] ^= data[j - 1];
                        data[j - 1] ^= data[j];

                        --j;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void HeapSort(ref int[] data)
        {
            int heapSize = data.Length;

            for (int p = (heapSize - 1) / 2; p >= 0; --p)
                MaxHeapify(ref data, heapSize, p);

            for (int i = data.Length - 1; i > 0; --i)
            {
                int temp = data[i];
                data[i] = data[0];
                data[0] = temp;

                --heapSize;
                MaxHeapify(ref data, heapSize, 0);
            }
        }

        private static void MaxHeapify(ref int[] data, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && data[left] > data[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && data[right] > data[largest])
                largest = right;

            if (largest != index)
            {
                int temp = data[index];
                data[index] = data[largest];
                data[largest] = temp;

                MaxHeapify(ref data, heapSize, largest);
            }
        }

        private static void QuickSortRecursive(ref int[] data, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(ref data, left, right);
                QuickSortRecursive(ref data, left, q - 1);
                QuickSortRecursive(ref data, q + 1, right);
            }
        }

        private static int Partition(ref int[] data, int left, int right)
        {
            int pivot = data[right];
            int temp;
            int i = left;

            for (int j = left; j < right; ++j)
            {
                if (data[j] <= pivot)
                {
                    temp = data[j];
                    data[j] = data[i];
                    data[i] = temp;
                    i++;
                }
            }

            data[right] = data[i];
            data[i] = pivot;

            return i;
        }


        static void Main(string[] args)
        {
            //leer(3);
            //leerEsperado(1); 
            //Trim
            //try
            //{
            
            //    StreamWriter sr = new StreamWriter("..\\..\\pruebaInverso.txt");
            //    for(int i = 0; i < esperado.Length; i++)
            //    {
            //        sr.Write(esperado[i] + " ");
            //    }
               
            //}catch(Exception e) 
            //    {
            //        Console.WriteLine(e);
            //    } 
        }

        private int[] datos;
        private int[] esperado;

        public int[] Datos { get => datos; set => datos = value; }
        public int[] Esperado { get => esperado; set => esperado = value; }

        public void leer(int tipo)
        {
            String line;
            try
            {
                StreamReader sr = null;
                if (tipo == 0)
                {
                    datos = new int[10000];
                    sr = new StreamReader("..\\..\\datosMedianosDesordenados.txt");
                }
                else if (tipo == 1)
                {
                    datos = new int[10000];
                    sr = new StreamReader("..\\..\\datosMedianosInverso.txt");
                }
                else if (tipo == 2)
                {
                    datos = new int[1000000];
                    sr = new StreamReader("..\\..\\datosGrandesDesordenados.txt");
                }
                else if (tipo == 3)
                {
                    datos = new int[1000000];
                    sr = new StreamReader("..\\..\\datosGrandesInverso.txt");
                }

                if (tipo == 0 || tipo == 1)
                {
                    int c = 0;
                    int j = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        j = 0;
                        string[] lines = line.Split(' ');
                        int r = 0;
                        while (j < lines.Length)
                        {
                            datos[c] = Int32.Parse(lines[r]);
                            r++;
                            c++;
                            j++;
                        }
                    }
                }
                else if (tipo == 2 || tipo == 3)
                {
                    int c = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lines = line.Split(' ');
                        for (int i = 0; i < lines.Length; i++)
                        {
                             datos[i] = Int32.Parse(lines[i]);
                            c++;
                        }
                    }
                    Console.WriteLine(c);
                }
               
                sr.Close();
                Thread.Sleep(4000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void leerEsperado(int tipoEsperado)
        {
            String line;
            try
            {
                StreamReader sr = null;
                if (tipoEsperado == 0)
                {
                    esperado = new int[10000];
                    sr = new StreamReader("..\\..\\datosMedianosOrdenados.txt");
                    int c = 0;
                    int j = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        j = 0;
                        string[] lines = line.Split(' ');
                        int r = 0;
                        while (j < lines.Length)
                        {
                            esperado[c] = Int32.Parse(lines[r]);
                            r++;
                            c++;
                            j++;
                        }
                    }
                }
                else if (tipoEsperado == 1)
                {
                    esperado = new int[1000000];
                    sr = new StreamReader("..\\..\\datosGrandesOrdenados.txt");
                    int errores = 0;
                    int c = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lines = line.Split(' ');
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (Int32.TryParse(lines[i], out c))
                            {
                                esperado[i] = Int32.Parse(lines[i]);
                                c++;
                            }
                            else
                            {
                                errores++;
                            }
                        }
                    }
                }

                sr.Close();
                //Console.ReadLine();
                Thread.Sleep(4000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
