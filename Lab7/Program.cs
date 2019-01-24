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
            Console.WriteLine("3. Обработать список");
            Console.WriteLine("4. Удалить список");
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
        /// Создание элемента списка
        /// </summary>
        /// <param name="d">Значение информационного поля</param>
        /// <returns>Элемент списка</returns>
        static Point MakePoint(int d)
        {
            Point p = new Point(d);
            return p;
        }

        /// <summary>
        /// Добавление в начало однонаправленного списка
        /// </summary>
        /// <param name="size">Количество элементов списка</param>
        /// <returns>Ссылка на начальный элемент списка</returns>
        static Point MakeList(int size)
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
        /// Отображение списка
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
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="beg">Ссылка на первый элемент</param>
        /// <param name="number">Номер элемента</param>
        /// <returns>Ссылка на первый элемент или null, если элементов нет</returns>
        static Point DelElement(Point beg, int number)
        {
            if (beg == null)//пустой список
            {
                Console.WriteLine("Error! The List is empty");
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
                Console.WriteLine("Error! The size of List less than Number");
                return beg;
            }
            //исключаем элемент из списка
            p.next = p.next.next;
            return beg;
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

                    case 1: // Однонаправленый список
                        LinkedListSinglyMenu();
                        break;
                    case 2:
                        
                        break;
                    case 3:

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
                            startOfList = MakeList(10);
                            Console.WriteLine("Список сформирован!");
                            break;
                        }
                    case 2: //распечатать список
                        {
                            ShowList(startOfList);
                            break;
                        }
                    case 3: //обработать список
                        {
                            break;
                        }
                    case 4: //удалить список
                        {
                            break;
                        }
                    case 5:
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
