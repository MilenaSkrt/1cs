using System;


namespace laba1
{
    class Programm
    {
        public static void Main(string[] args)
        {
            //создание трех различных списков
            DoublyLinkedList doublyLinked = new DoublyLinkedList();
            ChainList chainList = new ChainList();
            ArrayList arrayList = new ArrayList();

            Random random = new Random(); //создание рандома для генерации случайных чисел

            for (int i = 0; i < 10000; i++) //цикл с 10000 итераций
            {
                //генерация случайных операций,индексов и данных
                int operation = random.Next(1, 5); 
                int index = random.Next(50);
                int Data = random.Next(50);


                switch (operation) //осуществление операций в зависимости от случайной операции
                {

                    case 1: //добавление элементов
                        arrayList.Add(Data);
                        chainList.Add(Data);
                        doublyLinked.Add(Data);
                        break;

                    case 2: //удаление элементов
                        arrayList.Delete(index);
                        chainList.RemoveAt(index);
                        doublyLinked.RemoveAt(index);
                        break;

                    //case 3: 
                    //    arrayList.Insert(index, Data);
                    //    chainList.Insert(index, Data);
                    //    doublyLinked.Insert(index, Data);
                    //    break;

                    //case 4:

                    //    //arrayList.Clear();
                    //    //chainList.Clear();
                    //    //doublyLinked.Clear();
                    //    break;

                    case 5: //изменение элементов по индексу
                        arrayList[i] = Data;
                        chainList[i] = Data;
                        doublyLinked[i] = Data;
                        break;
                }

            }
            //вывод содержимого списков
            Console.WriteLine("ArrayList:");
            arrayList.Print();
            Console.WriteLine("ChainList:");
            chainList.Print();
            Console.WriteLine("DoublyLinkedList:");
            doublyLinked.Print();

            AreListsEqual(arrayList, chainList, doublyLinked); //проверка равенства списков

            void AreListsEqual(ArrayList arrayList, ChainList chainList, DoublyLinkedList doublyLinkedList) //метод для проверки равенства списков
            {
                bool areEqual = true; //изначально считаем списки равными

                if (arrayList.Count != chainList.Count || arrayList.Count != doublyLinkedList.Count) //если длины списков не совпадают, то списки не равны
                {
                    areEqual = false;
                }
                else
                {
                    for (int i = 0; i < arrayList.Count; i++) //проверка элементов списков на равенство
                    {
                        if (arrayList[i] != chainList[i] || arrayList[i] != doublyLinkedList[i])
                        {
                            areEqual = false;
                            break;
                        }
                    }
                }

                Console.WriteLine($"Count array = {arrayList.Count}");
                Console.WriteLine($"Count chain = {chainList.Count}");
                Console.WriteLine($"Равны ли списки?: {areEqual}"); //вывод результата проверки равенства списков
            }
        }
    }
}
