using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSachLienKet
{
    internal class IntNode
    {
       private int data;
       private IntNode next;


        //Constructor có tham số truyền vào
        public IntNode(int x)
        {
            this.Data = x;
            this.Next = null;
        }

        //Properties
        public int Data 
        { 
            get => data; 
            set => data = value; 
        }

        public IntNode Next 
        {   get => next; 
            set => next = value; 
        }
    }
}
