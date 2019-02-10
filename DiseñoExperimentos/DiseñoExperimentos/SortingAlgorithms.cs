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
        public static void heapSort(int[] arr, int n)
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
        
        public const int RUN = 32;
        public static void insertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (arr[j] > temp && j >= left)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        public static void merge(int[] arr, int l, int m, int r)
        {
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];
            for (int x = 0; x < len1; x++)
                left[x] = arr[l + x];
            for (int x = 0; x < len2; x++)
                right[x] = arr[m + 1 + x];
            int i = 0;
            int j = 0;
            int k = l;
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }

        public void timSort(int[] arr, int n)
        {
            for (int i = 0; i < n; i += RUN)
                insertionSort(arr, i, Math.Min((i + 31), (n - 1)));
            for (int size = RUN; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));
                    merge(arr, left, mid, right);
                }
            }
        }

        static void Main(string[] args)
        {
            //leer(1);
            //heapSort(datos, 10000);
            //for(int i = 0; i < datos.Length; i++)
            //{
            //    Console.Write(datos[i] + " ");
            //}
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
                if(tipo == 0)
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
                    datos = new int[100000];
                    sr = new StreamReader("..\\..\\datosGrandeDesordenados.txt");
                }
                else if (tipo == 3)
                {
                    datos = new int[100000];
                    sr = new StreamReader("..\\..\\datosGrandesInverso.txt");
                }
                int c = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lines = line.Split(' ');
                    int r = 0;
                    while(c < lines.Length)
                    {
                        datos[c] = Int32.Parse(lines[r]);
                        r++;
                        c++;
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

        public void leerEsperado(int tipoEsperado)
        {
            String line;
            try
            {
                StreamReader sr = null;
                if (tipoEsperado == 0)
                {
                    datos = new int[10000];
                    sr = new StreamReader("..\\..\\datosGrandesOrdenados.txt");
                }
                else if (tipoEsperado == 1)
                {
                    datos = new int[100000];
                    sr = new StreamReader("..\\..\\datosGrandesOrdenados.txt");
                }

                int c = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lines = line.Split(' ');
                    int r = 0;
                    while (c < lines.Length)
                    {
                        esperado[c] = Int32.Parse(lines[r]);
                        r++;
                        c++;
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
