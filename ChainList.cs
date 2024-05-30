using System;

namespace laba1
{
    public class ChainList
    {
        public Node head;

        public void Add(int data) //метод для добавления элемента в список
        {
            Node newNode = new Node(data);

            if (head == null) //если список пустой
            {
                head = newNode;
                Node.count++;
                return;
            }

            Node current = head;

            while (current.Next != null) //поиск конца списка
            {
                current = current.Next;
            }

            current.Next = newNode;
            Node.count++;
        }

        public Node Find(int index) //метод для поиска эл-ов по индексу
        {
            if (index < 0 || index >= Node.count)
            {
                return null;
            }

            int currentIndex = 0;
            Node current = head;

            while (current != null) //поиск эл-та по индексу
            {
                if (currentIndex == index)
                {
                    return current;
                }
                current = current.Next;
                currentIndex++;
            }

            return null;
        }

        public void RemoveAt(int index) //метод для цдаления эл-та по индексу
        {
            if (index < 0 || index >= Node.count) return;

            if (index == 0)
            {
                head = head.Next;
                Node.count--;
                return;
            }

            int currentIndex = 0;
            Node current = head;

            while (current != null) //удаление элемента по индексу
            {
                if (currentIndex + 1 == index)
                {
                    current.Next = current.Next.Next;
                    Node.count--;
                    return;
                }
                currentIndex++;
                current = current.Next;
            }
        }

        public void Insert(int data, int index) //метод вставки эл-та по индексу
        {
            if (index < 0 || index > Node.count) return;

            Node newNode = new Node(data);

            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
                Node.count++;
                return;
            }

            Node current = head;
            int currentIndex = 0;

            while (current != null) //вставка эл-та по индексу
            {
                if (currentIndex + 1 == index)
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    Node.count++;
                    return;
                }
                currentIndex++;
                current = current.Next;
            }
        }

        public int this[int index] //индексатор для доступа к эл-ам списка
        {
            get
            {
                if (index < 0 || index >= Node.count) return 0;

                Node node = Find(index);
                return node.Data;
            }
            set
            {
                if (index >= 0 && index < Node.count)
                {
                    Node node = Find(index);
                    if (node != null)
                        node.Data = value;
                }
            }
        }

        public void Print() //печать эл-ов списка
        {
            Node current = head;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void Clear() //метод очистки списка
        {
            head = null;
            Node.count = 0;
        }

        public int Count
        {
            get { return Node.count; }
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public static int count = 0;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }
}
