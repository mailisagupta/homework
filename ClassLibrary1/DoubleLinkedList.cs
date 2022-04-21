using System.Text;

namespace ClassLibrary1
{
    /// <summary>
/// Gupta, Mailisa , mailisa
/// </summary>
    public class DoubleLinkedList 
    {
        Node head;
        Node tail;

        public int Count
        {
            get
            {
                if (head is null) return 0;
                else
                {
                    int result = 1;
                    Node current = head;
                    while (current != tail)
                    {
                        result++;
                        current = current.refnext;
                    }
                    return result;
                }
            }
        }

        public void Add(int newData)
        {
            Node newNode = new Node ();
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

        public void Remove(int Data)
        {
            Node current = head;
            Node previous = null;
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

        public Node InReverse()
        {
            Node ptr1 = head;
            Node ptr2 = ptr1.refnext;
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


        public int? this[int index] // indexer to make this look like an array
        {
            get
            {
                if (index >= 0 && index <= Count)
                {
                    Node a = GoToNodeAt(index);
                    return a.data;
                }

                return null;
            }
            set
            {
                if (index >= 0 && index <= Count)
                {
                    Node nodeToSet = GoToNodeAt(index);
                    nodeToSet.data = value;
                }
            }
        }

        private Node GoToNodeAt(int index)
        {
            if (index >= 0 && index <= Count)
            {
                int currentIndex = 0;
                Node current = head;
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
            Node current = head;
            StringBuilder result = new();
            while (current is not null)
            {
                result.Append(current.data);
                if (current is not null) result.Append(' ');
                current = current.refnext;
            }
            return result.ToString();
        }





    }
}
