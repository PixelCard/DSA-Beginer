using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DanhSachLienKet
{
    internal class MyLinkedList
    {
        //Biến node dùng để trỏ phần tử đầu danh sách
        private IntNode Head;

        //Ta có 1 linked list khởi tạo ban đầu với 1 mảng rỗng với số list = 0
        public MyLinkedList()
        {
            Head = null;
        }

        //Ta khởi tạo 1 hàm đếm có bao nhiêu danh sách liên kết
        public int Count
        {
            get
            {
                int dem = 0;
                IntNode Current = Head;//Ban đầu ta khởi tạo cho 1 biến thay thế cho mảng head để ta duyệt từng vị trí phần tử trong mảng
                if (IsEmpty())
                {
                    Console.WriteLine("Mảng rỗng không thể đếm được số phần tử");
                    return 0;
                }
                while (Current != null)//Sau đó ta khởi tạo vòng lặp cho đến hết mảng
                {
                    Current = Current.Next;//với việc ta gắn biến current=current.next dùng để di chuyển qua các phần tử trong danh sách và nó giống như i++ trong danh sách mảng 1 chiều;
                    dem++;//với mỗi lần duyệt qua 1 phần tử trong liên kết ta sẽ tăng số đếm lên 1
                }
                return dem;
            }
        }

        //Phương thức dùng để kiếm tra hàm có rỗng hay không
        public bool IsEmpty()
        {
            return Head == null;    //Nếu mà nó rỗng sẽ trả về true 
        }

        //Thêm vào vị trí đầu tiên
        public void AddFirst(int x) // Ban đầu ta có 1 số đã nhập để chèn vào vị trí đầu tiên
        {
            IntNode temp = new IntNode(x); //Sau đó ta tạo 1 Node temp với có giá trị x next -> null
            if (IsEmpty()) //Nếu ban đầu node head ta không có mảng nào 
            {
                Head = temp;//ta sẽ khởi tạo biến head = temp
            }
            else //Còn nếu biến head đã có 1 phần tử trở lên trong danh sách
            {
                temp.Next = Head; //ta sẽ cho next trỏ vào vị trí của head
                Head = temp; //sau đó vị trí head sẽ đưa về biến temp
            }
        }

        //Thêm vào vị trí cuối cùng
        public void AddLast(int x)
        {
            //Với cách tạo biến tới câu lệnh if sẽ giống với cách ta đã tạo với phương thức add first
            IntNode temp = new IntNode(x);
            if (IsEmpty())
            {
                Head = temp;
            }

            //Còn ở câu lệnh ngược lại nếu head có phần tử trong danh sách thì ta làm như sau:
            else
            {
                IntNode Last = Head; //Bước 1 ta tạo 1 node Last copy danh sách các phần trong node head
                while (Last.Next != null) //sau đó ta duyệt tới nút kế cuối của danh sách head
                {
                    Last = Last.Next; //di chuyển đến nút kế cuối
                }
                Last.Next = temp; //sau đó ta cho con trỏ của nút kế cuối trỏ đến node temp
            }
        }


        //Chèn phần tử vào vị trí bất kì trong danh sách
        public void InsertAt(int pos, int x) //Ban đầu ta cần phải nhập vào vị trí và giá trị cần chèn 
        {
            IntNode NewNode = new IntNode(x); //Ta tạo 1 node mới với node này là node ta cần chèn

            if (pos <= 0 && pos > Count+1) //với lệnh if đầu tiên ta kiểm tra vị trí người dùng nhập vào có vượt ngoài vùng danh sách hay không
            {
                Console.WriteLine("Vị trí không hợp lệ");//có thì ta sẽ xuất ra màn hình câu thông báo sau đó kết thúc phương thức
                return;
            }
            if (pos == 1)//còn nếu người dùng nhập vị trí 0 là vị trí đầu tiên 
            {
                AddFirst(x);//Thì ta sẽ gọi ra phương thức thêm phần tử vào đầu
                return;
            }
            else if (pos == Count+1)//còn nếu người dùng nhập vào vị trí cuối cùng
            {
                AddLast(x);//thì ta sẽ sử dụng phương thức AddLast(x)
                return;
            }
            //Còn nếu vị trí ở bất kì
            else
            {

                //Thì ta sẽ tạo ra 1 node mới copy từ node head;
                IntNode current = Head;
                //duyệt từ vị trí node đầu tới ví trí trước vị trí cần chèn
                for (int i = 1; i < pos-1; i++)
                {
                    if (current == null)//Ta check xem thử danh sách current có phải copy 1 danh sách rỗng hay ko
                    {
                        Console.WriteLine("Mảng rỗng");//nếu có ta trả về thông báo và kết thúc hàm
                        return;
                    }
                    current = current.Next;//Còn không ta sẽ duyệt vị trí current tới trước vị trí pos đã nhập
                }

                if (current != null)
                {
                    NewNode.Next = current.Next;//sau đó ta cho thanh dây của newnode trỏ vào node ở vị trí pos + 1

                    current.Next = NewNode;//Sau khi trỏ tới thì thanh dây node của current pos-1 đã bị mất liên kết vậy thì lúc này ta sẽ liên kết nối nó tới newnode
                                           //vì newnode nó đã kết nối tới node ở vị trí pos + 1 mà vị trí current ở pos-1 thì newnode ở vị trí pos (middle giữa pos-1 và pos+1)
                }
            }
        }

        //Xóa ở vị trí đầu tiên
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Mảng rỗng không thể xóa");
                return;
            }
            Head = Head.Next;
            return;
        }


        //Xóa ở vị trí cuối cùng
        public void RemoveLast(){
            if (IsEmpty())
            {
                Console.WriteLine("Mảng rỗng không thể xóa");
                return;
            }
            IntNode truoc = null, sau = Head;
            while(sau.Next != null)
            {
                truoc = sau;
                sau= sau.Next;
            }
            if (truoc == null)
            {
                Head = null;
            }
            else
            {
                truoc.Next = null;
            }
        }


        //remove at middle 
        public void RemoveAtMiddle(int pos)
        {
            if(pos <=0 && pos > Count + 1)
            {
                Console.WriteLine("Bạn nhập không chính xác vị trí cần tìm");
                return;
            }
            IntNode truoc=null,sau=Head;   
            for(int i = 1; i < pos; i++)
            {
                truoc = sau;
                sau=sau.Next;
            }
            if(truoc == null)
            {
                Head = Head.Next;
            }
            else
            {
                truoc.Next = sau.Next;
            }
        }

        //Hàm xuất ra 1 linked list
        public void ShowList()
        {
                IntNode Current = Head;
                while (Current != null)
                {
                    Console.Write(Current.Data + "->");
                    Current = Current.Next;
                }
                Console.WriteLine("Null");
        }
    }
}
