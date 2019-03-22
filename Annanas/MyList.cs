using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annanas
{
    class MyList <T> : IEnumerable<T>
    {

        Node<T> head;
        Node<T> tail;
        int cnt = 0;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if(cnt == 0)
            {
                head = tail;
            }
            else
            {
                tempNode.Next = tail;   
            }
            cnt++;
        }

        public void Remove(int n)
        {
            if(cnt == 0) throw new InvalidOperationException();
            Node<T> current = head;
            Node<T> previous = null;
            int temp_cnt = 0;
            while(temp_cnt != n)
            {
                previous = current;
                current = current.Next;
                temp_cnt++;
            }
            previous = current.Next;
            cnt--;
        }
        
        public T First
        {
            get
            {
                if(cnt == 0) throw new InvalidOperationException();
                return head.Data;
            }
        }

        public T Last
        {
            get
            {
                if (cnt == 0) throw new InvalidOperationException();
                return tail.Data;
            }
        }

        public int Length { get => cnt; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

    }
}
