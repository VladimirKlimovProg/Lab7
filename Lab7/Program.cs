using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Dialog
    {
        public static void PrintMenu1stLevel()
        {
            Console.WriteLine("1. Однонаправленный список");
            Console.WriteLine("2. Двунаправленный список");
            Console.WriteLine("3. Бинарное дерево");
            Console.WriteLine("4. Выход");
        }

        public static void PrintMenu2ndLevelSinglyLinkedList()
        {
            Console.WriteLine("1. Сформировать список");
            Console.WriteLine("2. Распечатать список");
            Console.WriteLine("3. Удалить из списка первый элемент с четным информационным полем");
            Console.WriteLine("4. Удалить список");
            Console.WriteLine("5. Назад");
        }

        public static void PrintMenu2ndLevelDoublyLinkedList()
        {
            Console.WriteLine("1. Сформировать список");
            Console.WriteLine("2. Распечатать список");
            Console.WriteLine("3. Добавить в список элемент с заданным номером");
            Console.WriteLine("4. Удалить список");
            Console.WriteLine("5. Назад");
        }

        public static void PrintMenu2ndLevelTree()
        {
            Console.WriteLine("1. Сформировать идеально сбалансированное дерево");
            Console.WriteLine("2. Распечатать дерево");
            Console.WriteLine("3. Найти минимальный элемент в дереве");
            Console.WriteLine("4. Преобразовать идеально сбалансированное дерево в дерево поиска");
            Console.WriteLine("5. Назад");
        }
        /// <summary>
        /// Ввод числа
        /// </summary>
        /// <param name="Text">Сообщение</param>
        /// <param name="sizes">Ограничение на ввод чисел</param>
        /// <returns>Число</returns>
        public static int InputNumber(string Text, params int[] sizes)
        {

            int number = 0;
            bool ok = false;
            do
            {
                Console.WriteLine(Text);
                bool success = Int32.TryParse(Console.ReadLine(), out number);
                if (success)
                {
                    if (sizes.Length == 0)
                    {
                        return number;
                    }
                    ok = number >= sizes[0] && number <= sizes[1];
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }

            } while (!ok);
            return number;
        }
    }

    class Program
    {
        /// <summary>
        /// Элемент однонаправленного списка
        /// </summary>
        class Point
        {
            public int data;//информационное поле
            public Point next;//адресное поле
            public Point()//конструктор без параметров
            {
                data = 0;
                next = null;
            }
            public Point(int d)//конструктор с параметрами
            {
                data = d;
                next = null;
            }
            public override string ToString()
            {
                return data + " ";
            }
        }

        /// <summary>
        /// Элемент двунаправленного списка
        /// </summary>
        class Point2
        {
            public int data;//информационное поле
            public Point2 next, pred;//адресное поле
            public Point2()//конструктор без параметров
            {
                data = 0;
                next = null;
                pred = null;
            }
            public Point2(int d)//конструктор с параметрами
            {
                data = d;
                next = null;
                pred = null;
            }
            public override string ToString()
            {
                return data + " ";
            }
        }

        /// <summary>
        /// Элемент бинарного дерева
        /// </summary>
        class PointTree
        {
            public int data;
            public PointTree left,//адрес левого поддерева 
                         right;//адрес правого поддерева
            public PointTree()
            {
                data = 0;
                left = null;
                right = null;
            }

            public PointTree(int d)
            {
                data = d;
                left = null;
                right = null;
            }

            public override string ToString()
            {
                return data + " ";
            }


        }

        /// <summary>
        /// Создание элемента однонаправленного списка
        /// </summary>
        /// <param name="d">Значение информационного поля</param>
        /// <returns>Элемент однонаправленного списка</returns>
        static Point MakePoint(int d)
        {
            Point p = new Point(d);
            return p;
        }

        /// <summary>
        /// Создание элемента двунаправленного списка
        /// </summary>
        /// <param name="d">Значение информационного поля</param>
        /// <returns>Элемент двунаправленного списка</returns>
        static Point2 MakePoint2(int d)
        {
            Point2 p = new Point2(d);
            return p;
        }

        /// <summary>
        /// Добавление в начало однонаправленного списка
        /// </summary>
        /// <param name="size">Количество элементов списка</param>
        /// <returns>Ссылка на начальный элемент списка</returns>
        static Point MakeSinglyList(int size)
        {
            Random rnd = new Random();
            int info = rnd.Next(0, 11);
            Console.WriteLine("Элемент {0} добавляется...", info);
            Point beg = MakePoint(info);//создаем первый элемент
            for (int i = 1; i < size; i++)
            {
                info = rnd.Next(0, 11);
                Console.WriteLine("Элемент {0} добавляется...", info);
                //создаем элемент и добавляем в начало списка
                Point p = MakePoint(info);
                p.next = beg;
                beg = p;
            }
            return beg;
        }

        /// <summary>
        /// Добавление в начало двунаправленного списка
        /// </summary>
        /// <param name="size">>Количество элементов списка</param>
        /// <returns>Ссылка на начальный элемент списка</returns>
        static Point2 MakeDoublyList(int size)
        {
            Random rnd = new Random();
            int info = rnd.Next(0, 11);
            Console.WriteLine("Элемент {0} добавляется...", info);
            Point2 beg = MakePoint2(info);//создаем первый элемент
            for (int i = 1; i < size; i++)
            {
                info = rnd.Next(0, 11);
                Console.WriteLine("Элемент {0} добавляется...", info);
                //создаем элемент и добавляем в начало списка
                Point2 p = MakePoint2(info);
                p.next = beg;
                beg.pred = p;
                beg = p;
            }
            return beg;
        }

        /// <summary>
        /// Добавление в конец однонаправленного списка
        /// </summary>
        /// <param name="size">Количество элементов списка</param>
        /// <returns>Ссылка на начальный элемент списка</returns>
        static Point MakeListToEnd(int size)
        {
            Random rnd = new Random();
            int info = rnd.Next(0, 11);
            Console.WriteLine("The element {0} is adding...", info);
            Point beg = MakePoint(info);//первый элемент
            Point r = beg;//переменная хранит адрес конца списка 
            for (int i = 1; i < size; i++)
            {
                info = rnd.Next(0, 11);
                Console.WriteLine("The element {0} is adding...", info);
                //создаем элемент и добавляем в конец списка
                Point p = MakePoint(info);
                r.next = p;
                r = p;
            }
            return beg;
        }

        /// <summary>
        /// Отображение однонаправленного списка
        /// </summary>
        /// <param name="beg">Ссылка на начальный элемент</param>
        static void ShowList(Point beg)
        {
            //проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Point p = beg;
            while (p != null)
            {
                Console.Write(p);
                p = p.next;//переход к следующему элементу
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Отображение двунаправленного списка
        /// </summary>
        /// <param name="beg">Ссылка на начальный элемент</param>
        static void ShowList(Point2 beg)
        {
            //проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Point2 p = beg;
            while (p != null)
            {
                Console.Write(p);
                p = p.next;//переход к следующему элементу
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Удаление элемента из однонаправленного списка
        /// </summary>
        /// <param name="beg">Ссылка на первый элемент</param>
        /// <param name="number">Номер элемента</param>
        /// <returns>Ссылка на первый элемент или null, если элементов нет</returns>
        static Point DelElement(Point beg, int number)
        {
            if (beg == null)//пустой список
            {
                return null;
            }
            if (number == 1)//удаляем первый элемент
            {
                beg = beg.next;
                return beg;
            }
            Point p = beg;
            //ищем элемент для удаления и встаем на предыдущий
            for (int i = 1; i < number - 1 && p != null; i++)
                p = p.next;
            if (p == null)//если элемент не найден
            {
                Console.WriteLine("Весь список удален");
                return beg;
            }
            //исключаем элемент из списка
            p.next = p.next.next;
            return beg;
        }

        /// <summary>
        /// Удаление элемента из двунаправленного списка
        /// </summary>
        /// <param name="beg">Ссылка на первый элемент</param>
        /// <param name="number">Номер элемента</param>
        /// <returns>Ссылка на первый элемент или null, если элементов нет</returns>ram>
        /// <returns></returns>
        static Point2 DelElement(Point2 beg, int number)
        {
            if (beg == null)//пустой список
            {
                return null;
            }
            if (number == 1)//удаляем первый элемент
            {
                beg = beg.next;
                return beg;
            }
            Point2 p = beg;
            //ищем элемент для удаления и встаем на предыдущий
            for (int i = 1; i < number - 1 && p != null; i++)
                p = p.next;
            if (p == null)//если элемент не найден
            {
                Console.WriteLine("Весь список удален");
                return beg;
            }
            //исключаем элемент из списка
            p.next = p.next.next;
            p.next.pred = null;
            return beg;
        }

        /// <summary>
        /// Поиск первого элемента с четным информационным полем
        /// </summary>
        /// <param name="beg">Ссылка на начало списка</param>
        /// <param name="size">Размер списка</param>
        /// <returns>Позиция элемента в списке или 0, если элемент не найден</returns>
        static int FindElement(Point beg, int size)
        {
            if (beg == null)//пустой список
            {
                Console.WriteLine("Список пуст");
                return 0;
            }
            Point p = beg;
            for (int i = 1; i < size && p != null; i++)
            {
                if (p.data % 2 == 0)
                {
                    return i;
                }
                else
                {
                    p = p.next;
                }
            }
            return 0;
        }

        /// <summary>
        /// Добавление элемента с заданным номером в двунаправленный список
        /// </summary>
        /// <param name="beg">Ссылка на начало списка</param>
        /// <param name="number">Номер элемента списка</param>
        /// <returns>Ссылка на первый элемент</returns>
        static Point2 AddPoint(Point2 beg, int number)
        {
            Random rnd = new Random();
            int info = rnd.Next(10, 100);
            Console.WriteLine("Элемент {0} добавляется...", info);
            Point2 NewPoint = MakePoint2(info); //создание нового элемента
            if (beg == null)//список пустой
            {
                beg = MakePoint2(rnd.Next(10, 100));
                return beg;
            }
            if (number == 1) //добавление в начало списка
            {
                NewPoint.next = beg;
                beg.pred = NewPoint;
                beg = NewPoint;
                return beg;
            }
            //вспом. переменная для прохода по списку
            Point2 p = beg;
            //идем по списку до нужного элемента
            for (int i = 1; i < number - 1 && p != null; i++)
                p = p.next;
            if (p == null)//элемент не найден
            {
                Console.WriteLine("Ошибка! Размер списка меньше номера элемента");
                return beg;
            }
            //добавляем новый элемент
            NewPoint.next = p.next;
            NewPoint.pred = p;
            p.next = NewPoint;
            Console.WriteLine("Элемент добавлен");
            return beg;

        }

        /// <summary>
        /// Количество элементов в двунаправленном списке
        /// </summary>
        /// <param name="beg">Ссылка на первый элемент</param>
        /// <returns>Количество элементов</returns>
        static int FindNumberOfElements(Point2 beg)
        {
            int numberOfElements = 0;
            if (beg == null)//пустой список
            {
                return 0;
            }
            Point2 p = beg;
            for (int i = 1; p != null; i++)
            {
                p = p.next;
                numberOfElements++;
            }
            return numberOfElements;
                
        }


        static void ShowTree (PointTree p, int l)
        {
            if (p != null)
            {
                ShowTree(p.left, l + 3);//переход к левому поддереву
                                        //формирование отступа
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.data);//печать узла
                ShowTree(p.right, l + 3);//переход к правому поддереву
            }

        }

        static PointTree IdealTree(int size, PointTree p)
        {
            PointTree r;
            int nl, nr;
            if (size == 0)
            {
                p = null;
                return p;
            }
            nl = size / 2;
            nr = size - nl - 1;
            int info = Dialog.InputNumber("Введите число от 1 до 10",1,10);
            r = new PointTree(info);
            r.left = IdealTree(nl, r.left);
            r.right = IdealTree(nr, r.right);
            return r;
        }

        /// <summary>
        /// Главное меню
        /// </summary>
        /// <param name="exit">Выход из меню</param>
        private static void MakeMenu(bool exit)
        {
            do
            {
                Dialog.PrintMenu1stLevel();
                int menuItemLevel1 = Dialog.InputNumber("Введите пункт меню", 1, 4);
                switch (menuItemLevel1)
                {

                    case 1: //Однонаправленый список
                        LinkedListSinglyMenu();
                        break;
                    case 2://Двунаправленный список
                        LinkedListDoublyMenu();
                        break;
                    case 3://Бинарное дерево
                        TreeMenu();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        break;
                }

            } while (!exit);
        }

        /// <summary>
        /// Подменю "Однонаправленный список"
        /// </summary>
        private static void LinkedListSinglyMenu()
        {
            int userAnswer;
            Point startOfList = null;
            do
            {
                Dialog.PrintMenu2ndLevelSinglyLinkedList();
                userAnswer = Dialog.InputNumber("Введите пункт меню", 1, 5);
                switch (userAnswer)
                {
                    case 1: //сформировать список
                        {
                            startOfList = MakeSinglyList(10);
                            Console.WriteLine("Список сформирован!");
                            break;
                        }
                    case 2: //распечатать список
                        {
                            ShowList(startOfList);
                            break;
                        }
                    case 3: //удалить первый элемент с четным информационным полем
                        {
                            int element = FindElement(startOfList, 10);
                            if (element == 0)
                            {
                                Console.WriteLine("Элемент не найден");
                            }
                            else
                            {
                                Console.WriteLine($"Элемент найден на позиции {element} и удален");
                                startOfList = DelElement(startOfList, element);
                            }
                            break;
                        }
                    case 4: //удалить весь список
                        {
                            for (int i = 1; i <= 10; i++)
                            {
                                startOfList = DelElement(startOfList, 1);
                            }
                            Console.WriteLine("Список удален");
                            break;
                        }
                    default:
                        break;
                }
            } while (userAnswer != 5);
        }

        /// <summary>
        /// Подменю "Двунаправленный список"
        /// </summary>
        private static void LinkedListDoublyMenu()
        {
            int userAnswer;
            Point2 startOfList = null;
            do
            {
                Dialog.PrintMenu2ndLevelDoublyLinkedList();
                userAnswer = Dialog.InputNumber("Введите пункт меню", 1, 5);
                switch (userAnswer)
                {
                    case 1: //сформировать двунаправленный список
                        {
                            startOfList = MakeDoublyList(10);
                            Console.WriteLine("Список сформирован!");
                            break;
                        }
                    case 2: //распечатать двунаправленный список
                        {
                            ShowList(startOfList);
                            break;
                        }
                    case 3: //добавить в список элемент с заданным номером
                        {
                            int number = Dialog.InputNumber("Введите номер элемента списка");
                            startOfList = AddPoint(startOfList, number);     
                            break;
                        }
                    case 4: //удалить весь список
                        {
                            int num = FindNumberOfElements(startOfList);
                            if (num == 0)
                            {
                                Console.WriteLine("Список пуст");
                            }
                            else
                            {
                                for (int i = 1; i <= num; i++)
                                {
                                    startOfList = DelElement(startOfList, 1);
                                }
                                Console.WriteLine("Список удален");
                            }
                            break;
                        }
                    default:
                        break;
                }
            } while (userAnswer != 5);
        }

        /// <summary>
        /// Подменю "Бинарное дерево"
        /// </summary>
        private static void TreeMenu()
        {
            int userAnswer;
            PointTree startOfTree = null;
            do
            {
                Dialog.PrintMenu2ndLevelTree();
                userAnswer = Dialog.InputNumber("Введите пункт меню", 1, 5);
                switch (userAnswer)
                {
                    case 1://сформировать идеально сбалансированное дерево
                        {
                            startOfTree = IdealTree(7, startOfTree);
                            break;
                        }
                    case 2://распечатать дерево
                        {
                            ShowTree(startOfTree, 1);
                            break;
                        }
                    case 3://найти минимальный элемент в дереве
                        {
                            break;
                        }
                    case 4://преобразовать идеально сбалансированное дерево в дерево поиска
                        {
                            break;
                        }
                    default:
                        break;
                }

            } while (userAnswer != 5);
        }

        static void Main(string[] args)
        {
            bool exit = false;
            MakeMenu(exit);
        }
    }
}
