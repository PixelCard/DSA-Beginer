using System;
using System.Net.Http.Headers;
using System.Security.AccessControl;

namespace Sortting
{
    internal class Program
    {
        public class IntArray
        {
            private int[] array;

            public int[] Array
            {
                set
                {
                    array = value;
                }
                get
                {
                    return array;
                }
            }
            public IntArray()
            {
                array = new int[0];
            }

            public IntArray(int K)
            {
                Random random = new Random();
                array = new int[K];
                for (int i = 0; i < array.Length; i++)
                {
                    this.array[i] = random.Next(1, 201);
                }
            }
            public void SapXepThuTu()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            swap(ref array[i], ref array[j]);
                        }
                    }
                }
            }
            public IntArray(int[] array)
            {
                this.array = array;
            }

            public IntArray(IntArray obj)
            {
                this.array = obj.array;
            }

            //Nhập xuất
            public bool KiemTraKt(int K)
            {
                if (K == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public void Nhap()
            {
                bool checkMang = KiemTraKt(array.Length);
                int n;
                if (checkMang)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write("A[{0}]:", i);
                        Array[i] = int.Parse(Console.ReadLine());
                    }
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Nhap vao so phan tu cho mang:");
                        n = int.Parse(Console.ReadLine());
                    } while (n < 0);
                    this.array = new int[n];
                    Nhap();
                }
            }
            public void Xuat()
            {
                Console.WriteLine("Các phần tử của mảng là:");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write("i:" + i + "-------" + "a[" + i + "]" + "--------" + array[i] + " ");
                    Console.WriteLine();
                }
            }

            //-----------------------------------------------------------------------Finding------------------------------------------------
            public int LinearSearch(int Tim)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == Tim)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public int BinarySearch(int Tim2)
            {
                int left = 0, right = array.Length;
                while (left < right)
                {
                    int m = (left + right) / 2;
                    if (array[m] < Tim2)
                    {
                        left = m + 1;
                    }
                    else if (array[m] > Tim2)
                    {
                        right = m - 1;
                    }
                    else
                    {
                        return m;
                    }
                }
                return -1;
            }
            //-----------------------------------------------------------------------End Finding----------------------------------------------------


            //-----------------------------------------------------------------------Sắp xếp--------------------------------------------------------
            public void InterchangeSort()
            {
                int n=array.Length;
                for(int i = 0; i < n; i++)
                {
                    for(int j=i+1; j < n; j++)
                    {
                        if(array[i] > array[j])
                        {
                            swap(ref array[j] , ref array[i]);
                        }
                    }
                }
            }

            public void BubbleSort()
            {
                int n=array.Length; 
                for(int i=0;i < n-1; i++)
                {
                    for(int j=0;j < n - i - 1; j++)
                    {
                        if (array[j] > array[j+1])
                        {
                            swap(ref array[j] , ref array[j+1]);
                        }
                    }
                }
            }

            public void SelectionSort()
            {
                int n = array.Length;
                for(int i=0;i < n-1; i++)
                {
                    int min = i;
                    for(int j=i+1;j< n; j++)
                    {
                        if (array[min] > array[j])
                        {
                            min = j;
                        }
                    }
                    swap(ref array[i], ref array[min]);
                }
            }

            public void InsertionSort()
            {
                int i, key, j;
                for(i = 1; i < array.Length; i++)
                {
                    key = array[i];
                    j = i - 1;
                    while(j >=0 && array[j] > key)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j+1] = key;
                }
            }

            public void QuickSort(int low,int right)
            {
                if (low < right)
                {
                    int Partion = partion(low, right);

                    QuickSort(low, Partion - 1);

                    QuickSort(Partion + 1, right);
                }
            }

            public int partion(int low,int high)
            {
                int pivot = array[high];
                int i = low - 1;
                for(int j = low; j < high; j++)
                {
                    if(array[j] <= pivot)
                    {
                        i++;
                        swap(ref array[i], ref array[j]);
                    }
                }
                swap(ref array[i + 1], ref array[high]);

                return i + 1;
            }
            //-----------------------------------------------------------------------End Sắp xếp--------------------------------------------------
        }
        public static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void TestInterchangeSort(IntArray obj)
        {
            //Copy ojb sang objTam để sắp xếp
            IntArray objTam = new IntArray(obj);
            Console.WriteLine("\n>>Mang ban dau:");
            objTam.Xuat();
            objTam.InterchangeSort();
            Console.WriteLine("\n>>Interchange Sort:");
            objTam.Xuat();
        }
        static void TestInsertionSort(IntArray obj)
        {
            //Copy ojb sang objTam để sắp xếp
            IntArray objTam = new IntArray(obj);
            Console.WriteLine("\n>>Mang ban dau:");
            objTam.Xuat();
            objTam.InsertionSort();
            Console.WriteLine("\n>>Insertion Sort:");
            objTam.Xuat();
        }


        static void TestQuickSort(IntArray obj)
        {
            //Copy ojb sang objTam để sắp xếp
            IntArray objTam = new IntArray(obj);
            Console.WriteLine("\n>>Mang ban dau:");
            objTam.Xuat();
            objTam.QuickSort(0,obj.Array.Length-1);
            Console.WriteLine("\n>> QuickSort:");
            objTam.Xuat();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Nhap vao kich thuoc mang:");
            int n=int.Parse(Console.ReadLine());
            IntArray IA = new IntArray(n);
            TestInsertionSort(IA);
            TestQuickSort(IA);
        }
    }
}
