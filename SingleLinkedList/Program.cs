using System;

namespace SingleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MySingleLinkedList<int> linkedList = new MySingleLinkedList<int>();
            // Test1:顺序插入4个节点
            linkedList.Add(0);
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            Console.WriteLine("The nodes in the linkedList:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");

            // Test2.1:在索引为0(即第1个节点)的位置插入单个节点
            linkedList.Insert(0, 10);
            Console.WriteLine("After insert 10 in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test2.2:在索引为2(即第3个节点)的位置插入单个节点
            linkedList.Insert(2, 20);
            Console.WriteLine("After insert 20 in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test2.3:在索引为5（即最后一个节点）的位置插入单个节点
            linkedList.Insert(5, 30);
            Console.WriteLine("After insert 30 in index of 5:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");

            // Test3.1:移除索引为5（即最后一个节点）的节点
            linkedList.RemoveAt(5);
            Console.WriteLine("After remove an node in index of 5:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test3.2:移除索引为0（即第一个节点）的节点
            linkedList.RemoveAt(0);
            Console.WriteLine("After remove an node in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test3.3:移除索引为2（即第三个节点）的节点
            linkedList.RemoveAt(2);
            Console.WriteLine("After remove an node in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");
            Console.ReadLine();
        }
    }

    public class Node<T>
    {
        public T Item { get; set; }

        public Node<T> Next { get; set; }
        public Node()
        {

        }
        public Node(T item)
        {
            this.Item = item;
        }
    }


    public class MySingleLinkedList<T>
    {
        private int count;//当前链表节点个数
        private Node<T> head;//当前链表的头节点

        //当前链表节点个数
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.GetNodeByIndex(index).Item;
            }
            set
            {
                this.GetNodeByIndex(index).Item = value;
            }
        }

        public MySingleLinkedList()
        {
            this.count = 0;
            this.head = null;
        }

        //根据索引获取节点
        private Node<T> GetNodeByIndex(int index)
        {
            if(index <0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            Node<T> tempNode = this.head;
            for(int i =0;i<index;i++)
            {
                tempNode = tempNode.Next;
            }
            return tempNode;
        }

        //在尾节点后插入新节点
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if(this.head==null)
            {
                //如果链表当前为空则置为头节点
                this.head = newNode;
            }
            else
            {
                Node<T> prevNode = this.GetNodeByIndex(this.count - 1);
                prevNode.Next = newNode;
            }

            this.count++;
        }
        int aaa;

        //在指定位置插入新节点
        public void Insert(int index, T value)
        {
            Node<T> tempNode = null;
            if(index <0 || index>this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            else if(index == 0)
            {
                if(this.head == null)
                {
                    tempNode = new Node<T>(value);
                    this.head = tempNode;
                }
                else
                {
                    tempNode = new Node<T>(value);
                    tempNode.Next = this.head;
                    this.head = tempNode;
                }
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                tempNode = new Node<T>(value);
                tempNode.Next = prevNode.Next;
                prevNode.Next = tempNode;
            }

            this.count++;
        }

        //移除指定位置的节点
        public void RemoveAt(int index)
        {
            if(index == 0)
            {
                this.head = this.head.Next;
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                if(prevNode.Next ==null)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }

                Node<T> deleteNode = prevNode.Next;
                prevNode.Next = deleteNode.Next;

                deleteNode = null;
            }

            this.count--;
        }
    }

}
