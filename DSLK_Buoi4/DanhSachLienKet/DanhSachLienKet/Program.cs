using System.Runtime.InteropServices;

namespace DanhSachLienKet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList MList= new MyLinkedList();
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("-----------------MENU---------------\n"
                                   + "1.    Chèn phần tử vào đầu danh sách\n"
                                   + "2.    Chèn phần tử vào cuối danh sách\n"
                                   + "3.    Chèn phần tử vào giữa danh sách\n"
                                   + "4.    Xóa phần tử ở đầu\n"
                                   + "5.    Xóa phần tử ở cuối\n"
                                   + "6.    Xóa phần tử ở giữa\n"
                                   + "7.    Hiển thị ra màn hình các phần tử đã nhập vào danh sách liên kết\n"
                                   +"8.    Sap xep cac phan tu trong dslk\n"
                                   + "0. Thoat !\n"
                                   + "-------------------------------------\n"
                );
                Console.WriteLine("Nhap lua chon :");

                int lc;

                lc=int.Parse(Console.ReadLine());

                if (lc == 1)
                {
                    Console.Write("Nhập giá trị mà bạn muốn thêm vào đầu:");
                    int x;
                    x = int.Parse(Console.ReadLine());
                    MList.AddFirst(x);
                    Console.WriteLine("Bạn đã thêm giá trị {0} vào phần tử ở đầu danh sách thành công", x);
                }

                else if (lc == 2)
                {
                    Console.Write("Nhập giá trị mà bạn muốn thêm vào cuối:");
                    int x;
                    x = int.Parse(Console.ReadLine());
                    MList.AddLast(x);
                    Console.WriteLine("Bạn đã thêm giá trị {0} vào phần tử ở cuối danh sách thành công", x);
                }

                else if (lc == 3)
                {
                    Console.Write("Nhập vào giá trị mà bạn muốn chèn:");
                    int x, pos;
                    x = int.Parse(Console.ReadLine());
                    Console.Write("Nhập vào vị trí mà bạn muốn chèn:");
                    pos = int.Parse(Console.ReadLine());
                    MList.InsertAt(pos, x);
                    Console.WriteLine("Bạn đã chèn giá trị {0} với vị trí {1} danh sách thành công", x, pos);
                }

                else if (lc == 4)
                {
                    MList.RemoveFirst();
                    Console.WriteLine("Bạn đã xóa phần tử ở đầu thành công");
                }

                else if (lc == 5)
                {
                    MList.RemoveLast();
                    Console.WriteLine("Bạn đã xóa phần tử ở cuối thành công");
                }

                else if (lc == 6)
                {
                    int pos;
                    Console.Write("Nhập vào vị trí bạn muốn xóa:");
                    pos = int.Parse(Console.ReadLine());
                    MList.RemoveAtMiddle(pos);
                    Console.WriteLine("Bạn đã xóa đi giá trị ở vị trí {0}", pos);
                }
                else if (lc == 7)
                {
                    MList.ShowList();
                }

                else if (lc == 8)
                {
                    MList.sapxep_SelectionSort();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
