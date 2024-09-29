using System;
using System.Net.Http.Headers;
using System.Security.AccessControl;

namespace LinearSearch_Buoi2
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
                    for(int j = i+1; j < array.Length; j++)
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

            public int LinearSearch(int Tim)
            {
                for(int i = 0;i<array.Length;i++)
                {
                    if(array[i] == Tim)
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
                    else {
                        return m;
                    }
                }
                return -1;
            }
        }
        public static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static void TestTimTuanTu()
        {
            int k;
            Console.Write("Nhập K giá trị ngẫu nhiên:");
            k = int.Parse(Console.ReadLine());
            IntArray objA = new IntArray(k);
            Console.WriteLine("Các phần tử trong mảng A được cấp phát ngẫu nhiên:");
            objA.Xuat();
            int x;
            Console.Write("Nhập giá trị X cần tìm:");
            x = int.Parse(Console.ReadLine());
            int kq_LinearSearch = objA.LinearSearch(x);
            if (kq_LinearSearch == -1)
            {
                Console.WriteLine("->Không tồn tại giá trị {0} trong mảng!", x);
            }
            else
            {
                Console.WriteLine("->Giá trị {0} tại vị trí trong mảng là: {1}!", x, kq_LinearSearch);
            }
        }
        //Test phương pháp tìm nhị phân
        public static void TestTimNhiPhan()
        {
            int n;
            Console.Write("Nhập N giá trị ngẫu nhiên tăng dần:");
            n = int.Parse(Console.ReadLine());
            IntArray objB = new IntArray(n);
            objB.SapXepThuTu();
            Console.Write("Nhập vào giá trị x cần tìm cho thuật toán binary search:");
            int x=int.Parse(Console.ReadLine());
            int kq_BinarySearch=objB.BinarySearch(x);
            if (kq_BinarySearch == -1)
            {
                Console.WriteLine("->Không tồn tại giá trị {0} trong mảng!", x);
            }
            else
            {
                Console.WriteLine("->Giá trị {0} tại vị trí trong mảng là: {1}!", x, kq_BinarySearch);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            ////Yêu cầu 1:

            Console.WriteLine("Test 1:");
            //TestConstructor1()
            IntArray obj = new IntArray(20);
            Console.WriteLine("Gia tri mang phat sinh:");
            obj.Xuat();

            Console.WriteLine("Test 2:");
            //TestConstructor2()
            int[] a = { 4, 7, 9, 10, 20, 8, 3, 17, 10, 6 };
            IntArray obj2 = new IntArray(a);
            Console.WriteLine("Gia tri mang: ");
            obj2.Xuat();

            Console.WriteLine("Test 3:");
            //TestConstructor3()
            IntArray obj3 = new IntArray();
            obj3.Nhap();
            Console.WriteLine("Gia tri mang: ");
            obj3.Xuat();
            IntArray obj4 = new IntArray(obj3);

            ////Hết yêu cầu 1


            //Yêu cầu 2:
            //TestTimTuanTu();
            //TestTimNhiPhan();
            //Hết Yêu cầu 2
        }
    }
}
