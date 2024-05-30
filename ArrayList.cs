using System;

namespace laba1
{
    public class ArrayList
    {
        private int[] buffer; //буффер для хранения эл-ов массива
        private int count; //текущее кол-во эл-ов в массиве
        private int capacity; //текущая емкость массива

        public ArrayList()
        {
            capacity = 5; //начальная емкость массива
            buffer = new int[capacity]; //выделение памяти для массива
            count = 0; //начальное кол-во эл-ов ноль
        }

        public void Add(int item) //добавление эл-ов в массив
        {
            if (count == buffer.Length) //если кол-во эл-ов равно текущей емкости массива, то
            {
                ResizeArray(); //увел емкость массива
            }
            buffer[count++] = item; //добавляем эл-ет в массив
        }

        public void ResizeArray() //метод для увеличения емкости массива вдвое
        {
            int newSize = buffer.Length * 2;
            int[] newArray = new int[newSize];
            Array.Copy(buffer, newArray, buffer.Length); //копирование эл-ов из старого массива
            buffer = newArray; //присваиваем буфферу ссылку на новый массив
        }

        public void Insert(int item, int index) //метод для вставки эл-та по указанному индексу
        {
            if (index < 0 || index > count) return; //если индекс некоректный то вызодим из метода

            if (count == buffer.Length) //если кол-во эл-ов = текущщей емкости массива
            {
                ResizeArray(); //увеличиваем емкость массива
            }

            for (int i = count; i > index; i--) //сдвигаем эл-ты для освобождения места под новый эл-ет
            {
                buffer[i] = buffer[i - 1];
            }

            buffer[index] = item; //вставляем новый эл-ет по указанному индексу
            count++; //увел кол-во эл-ов в массиве
        }

        public void Delete(int index) //удаление эл-та по указанному индексу
        {
            if (index < 0 || index >= count) return; //если индекс некорректный, то выходим из массива

            for (int i = index; i < count - 1; i++) //сдвигаем эл-ты массива для удаления указанного эл-та
            {
                buffer[i] = buffer[i + 1];
            }

            count--; //уменьшаем кол-во эл-ов в массиве
        }

        public void Clear() //полная очистка массива
        {
            buffer = new int[capacity]; //создаем новый массив с изначальной емкостью
            count = 0; // обнуляем кол-во эл-ов
        }

        public int Count //получение текущего кол-ва эл-ов в массиве
        {
            get { return count; }
        }

        public int this[int index] //индексатор для доступа к эл-ам массива
        {
            get
            {
                if (index < 0 || index >= count) // если индекс некоректный то возвращаем 0
                {
                    return 0;
                }
                return buffer[index]; //возвращаем эл-ет по уазанному индексу
            }

            set
            {
                if (index >= 0 && index < count) //если индекс корректный
                {
                    buffer[index] = value; //присваиваем эл-ту по индексу новое значение
                }
            }
        }

        public void Print() //вывод содержимого массива на экран
        {
            for (int i = 0; i < count; i++) //перебираем эл-ты массива
            {
                Console.Write(buffer[i] + " "); 
            }
            Console.WriteLine();
        }
    }
}
