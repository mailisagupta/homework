using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    /// <summary>
    /// Gupta, Mailisa , mailisa
    /// </summary>
    public class DoubleLinkedListGeneric<T> : IEnumerable<T> where T: class
    {
        NodeGeneric<T> head;
        NodeGeneric<T> tail;

        public int Count
        {
            get
            {
                if (head is null) return 0;
                else
                {
                    int result = 1;
                    NodeGeneric<T> current = head;
                    while (current != tail)
                    {
                        result++;
                        current = current.refnext;
                    }
                    return result;
                }
            }
        }

        public void Add(T newData)
        {
            NodeGeneric<T> newNode = new NodeGeneric<T>();
            newNode.data = newData;
            if (head is null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.refprevious = tail;
                tail.refnext = newNode;
                tail = newNode;
            }

        }

        public void Remove(T Data)
        {
            NodeGeneric<T> current = head;
            NodeGeneric<T> previous = null;
            while (current is not null)
            {
                if (current.data.Equals(Data))
                {
                    if (previous is null) head = head.refnext;
                    else previous.refnext = current.refnext;
                    if (current == tail) tail = previous;
                    break;
                }
                previous = current;
                current = current.refnext;
            }

        }

        public NodeGeneric<T> InReverse()
        {
            NodeGeneric<T> ptr1 = head;
            NodeGeneric<T> ptr2 = ptr1.refnext;
            ptr1.refnext = null;
            ptr1.refprevious = ptr2;
            while (ptr2 is not null)
            {
                ptr2.refprevious = ptr2.refnext;
                ptr2.refnext = ptr1;
                ptr1 = ptr2;
                ptr2 = ptr2.refprevious;
            }
            head = ptr1;
            return head;

        }


        public T this[int index] // indexer to make this look like an array
        {
            get
            {
                if (index >= 0 && index <= Count)
                {
                    NodeGeneric<T> a = GoToNodeAt(index);
                    return a.data;
                }

                return default;
            }
            set
            {
                if (index >= 0 && index <= Count)
                {
                    NodeGeneric<T> nodeToSet = GoToNodeAt(index);
                    nodeToSet.data = value;
                }
            }
        }

        private NodeGeneric<T> GoToNodeAt(int index)
        {
            if (index >= 0 && index <= Count)
            {
                int currentIndex = 0;
                NodeGeneric<T> current = head;
                while (currentIndex != index)
                {
                    current = current?.refnext;
                    currentIndex++;
                }
                return current;
            }
            return null;
        }

        public override string ToString()
        {
            NodeGeneric<T> current = head;
            StringBuilder result = new();
            while (current is not null)
            {
                result.Append(current.data);
                if (current is not null) result.Append(' ');
                current = current.refnext;
            }
            return result.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            NodeGeneric<T> current = head;
            while (current is not null)
            {
                yield return current.data;
                current = current.refnext;
            }
           
        }

        //public IEnumerable GetEnumeratorReverse()
        //{
        //    NodeGeneric<T> current = tail;
        //    while (current is not null)
        //    {
        //        yield return current.data;
        //        current = current.refprevious;
        //    }

        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
