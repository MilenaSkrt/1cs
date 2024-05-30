using System;

namespace laba1
{
    public class IndexList
    {
        public struct Element
        {
            public DoublyLinkedList.Node node { get; set; }  
            public int index { get; set; }
            public Element(DoublyLinkedList.Node node, int index) //конструктор структуры
            {
                this.node = node;
                this.index = index;
            }
        }

        private int count;
        private int capacity;
        Element[] buffer = null; //массив buffer типа Element, инициализированнй как null

        public IndexList()
        {
            capacity = 5;
            count = 0;
            buffer = new Element[capacity];
        }

        private void ResizeArray() //метод для изменения размера массива buffer
        {
            Array.Resize(ref buffer, capacity * 2);
        }

        public void Append(DoublyLinkedList.Node data, int index) //метод для добавления элемента 
        {
            if (index >= count) { ResizeArray(); }
            buffer[count++] = new Element(data, index);
        }

        public void Delete(int index) //метод для удаления элемента
        {
            if (index < 0 || index >= count) { throw new IndexOutOfRangeException(); }
            for (int i = index; i < count - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }
            count--;
        }
        public void Clear() //метод для очстки элементов
        {
            buffer = null;
            capacity = 5;
            count = 0;
        }

        public int Count { get { return count; } } //свойство Count, возвращающее значение count

       /* public int Find(int pos) //метод для поиска индекса
        {
            if (pos == 0) return pos;
            for (int i = 1; i < count; i++)
            {
                if (buffer[i].index == pos)
                {
                    return i;
                }
            }
            throw new IndexOutOfRangeException("trouble in find");
        }*/
        public int FindClosest(int targetIndex)
        {
            if (count == 0)
            {
                throw new IndexOutOfRangeException("Список пуст.");
            }

            int closestIndex = -1;
            int smallestDifference = int.MaxValue;

            for (int i = 0; i < count; i++)
            {
                int currentDifference = Math.Abs(buffer[i].index - targetIndex);

                if (currentDifference < smallestDifference)
                {
                    smallestDifference = currentDifference;
                    closestIndex = i;
                }
            }

            if (closestIndex == -1)
            {
                throw new Exception("Не удалось найти ближайший индекс.");
            }

            return closestIndex;
        }

        //if (index == 0) { return 0; }
        //else
        //{
        //    int left = 0;
        //    int right = count - 1;

        //    while (left <= right)
        //    {
        //        int mid = left + (right - left) / 2;
        //        if (buffer[mid].index == index) { return mid; }
        //        else if (buffer[mid].index < index) { left = mid + 1; }
        //        else { right = mid - 1; }
        //    }

        //}
        //throw new IndexOutOfRangeException();


        public DoublyLinkedList.Node this[int index] //индексатор для доступа к элементам по индексу
        {
            get
            {
                if (index < 0 || index >= count) { throw new IndexOutOfRangeException(); }
                else { return buffer[index].node; }
            }

            set
            {
                if (index < 0 || index >= count) { throw new IndexOutOfRangeException(); }
                else { buffer[index].node = value; }
            }
        }
        public int GetIndex(int index) //метод для получения индекса элемента по индексу
        {
            return buffer[index].index;
        }
        public DoublyLinkedList.Node GetNode(int index) //метод для получения узла по индексу
        {
            return buffer[FindClosest(index)].node;
        }
        public void SetNode(DoublyLinkedList.Node node, int index) //метод для установки узла по индексу
        {
            buffer[FindClosest(index)].node = node;
            buffer[FindClosest(index)].index = index;
        }
    }
}
