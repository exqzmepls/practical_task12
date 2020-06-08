using System;

namespace practical_task12
{
    public class Program
    {
        // Вывод меню
        static void PrintMenu(string[] menuItems, int choice, string info)
        {
            Console.Clear();
            Console.WriteLine(info);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == choice) Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        // Выбор пункта из меню
        static int MenuChoice(string[] menuItems, string info = "")
        {
            Console.CursorVisible = false;
            int choice = 0;
            while (true)
            {
                PrintMenu(menuItems, choice, info);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (choice == 0) choice = menuItems.Length;
                        choice--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (choice == menuItems.Length - 1) choice = -1;
                        choice++;
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return choice;
                }
            }
        }

        // Ввод целого числа
        public static int IntInput(int lBound = int.MinValue, int uBound = int.MaxValue, string info = "")
        {
            bool exit;
            int result;
            Console.Write(info);
            do
            {
                exit = int.TryParse(Console.ReadLine(), out result);
                if (!exit) Console.Write("Введено нецелое число! Повторите ввод: ");
                else if (result <= lBound || result >= uBound)
                {
                    exit = false;
                    Console.Write("Введено недопустимое значение! Повторите ввод: ");
                }
            } while (!exit);
            return result;
        }

        public static int[] RandomFilling(int size)
        {
            bool[] picked = new bool[size];
            int[] result = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size;)
            {
                int el = rnd.Next(size);
                if (!picked[el])
                {
                    picked[el] = true;
                    result[i++] = el;
                }
            }
            return result;
        }

        // Сортировка методом простого выбора
        public static void SelectionSort(int[] arr, out int comparisons, out int replaces)
        {
            // Сложность алгоритма О(N^2)
            comparisons = replaces = 0;
            int i, min, iMin, j, size = arr.Length;
            for (i = 0; i < size - 1; i++)
            {
                min = arr[i]; iMin = i;
                for (j = i + 1; j < size; j++)
                {
                    comparisons++;
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        iMin = j;
                    }
                }
                replaces++;
                arr[iMin] = arr[i];
                arr[i] = min;
            }
        }

        // Сортировка Шелла
        public static void ShellSort(int[] arr, out int comparisons, out int replaces)
        {
            comparisons = replaces = 0;
            int step, i, j, tmp, size = arr.Length;

            // Выбор шага
            // От выбора шага зависит сложность алгоритма
            // В данном алгоритме используется первоначально используемая Шеллом последовательность длин промежутков: d(1) = N/2, d(i) = d(i-1)/2, d(k) = 1
            // В худшем случае, сложность алгоритма составит О(N^2)
            for (step = size / 2; step > 0; step /= 2)
                // Перечисление элементов, которые сортируются на определённом шаге
                for (i = step; i < size; i++)
                    // Перестановка элементов внутри подсписка, пока i-тый не будет отсортирован
                    for (j = i - step; j >= 0; j -= step)
                    {
                        comparisons++;
                        if (arr[j] <= arr[j + step]) break;

                        replaces++;
                        tmp = arr[j];
                        arr[j] = arr[j + step];
                        arr[j + step] = tmp;
                    }
        }
        
        static void Main(string[] args)
        {
            // Пункты меню
            string[] MENU_ITEMS = { "Ввести размера массива", "Выйти из программы" };

            // Индекс пункта - выход из программы
            const int EXIT_CHOICE = 1;

            // Индекс пункта меню, который выбрал пользователь
            int userChoice;

            while (true)
            {
                // Пользователь выбирает действие (выйти или задать матрицу)
                userChoice = MenuChoice(MENU_ITEMS, "Программа для сравнения сортировки простым выбором и сортировки Шелла\nпо количеству пересылок и сравнений.\nВыберите действие:");
                if (userChoice == EXIT_CHOICE) break;
                Console.Clear();

                // Ввод размера массива
                int n = IntInput(lBound: 0, info: "Введите размер массива: ");

                int c, p;

                // Сортировка простым выбором упорядоченного по возрастанию массива
                int[] sortedArray1 = new int[n];
                for (int i = 0; i < n; i++) sortedArray1[i] = i;
                SelectionSort(sortedArray1, out c, out p);
                Console.WriteLine("Результат сортировки простым выбором для упорядоченного по возрастанию массива:");
                Console.WriteLine("Количесво сравнений = " + c);
                Console.WriteLine("Количесво пересылок = " + p);
                Console.WriteLine();

                // Сортировка Шелла упорядоченного по возрастанию массива
                int[] sortedArray2 = new int[n];
                for (int i = 0; i < n; i++) sortedArray2[i] = i;
                ShellSort(sortedArray2, out c, out p);
                Console.WriteLine("Результат сортировки Шелла для упорядоченного по возрастанию массива:");
                Console.WriteLine("Количесво сравнений = " + c);
                Console.WriteLine("Количесво пересылок = " + p);
                Console.WriteLine();

                // Сортировка простым выбором упорядоченного по убыванию массива
                int[] reverseSortedArray1 = new int[n];
                for (int i = 0; i < n; i++) reverseSortedArray1[i] = n - i;
                SelectionSort(reverseSortedArray1, out c, out p);
                Console.WriteLine("Результат сортировки простым выбором для упорядоченного по убыванию массива:");
                Console.WriteLine("Количесво сравнений = " + c);
                Console.WriteLine("Количесво пересылок = " + p);
                Console.WriteLine();

                // Сортировка Шелла упорядоченного по убыванию массива
                int[] reverseSortedArray2 = new int[n];
                for (int i = 0; i < n; i++) reverseSortedArray2[i] = n - i;
                ShellSort(reverseSortedArray2, out c, out p);
                Console.WriteLine("Результат сортировки Шелла для упорядоченного по убыванию массива:");
                Console.WriteLine("Количесво сравнений = " + c);
                Console.WriteLine("Количесво пересылок = " + p);
                Console.WriteLine();

                // Сортировка простым выбором неупорядоченного массива
                int[] unsortedArray1 = RandomFilling(n);
                SelectionSort(unsortedArray1, out c, out p);
                Console.WriteLine("Результат сортировки простым выбором для неупорядоченного массива:");
                Console.WriteLine("Количесво сравнений = " + c);
                Console.WriteLine("Количесво пересылок = " + p);
                Console.WriteLine();

                // Сортировка Шелла неупорядоченного массива
                int[] unsortedArray2 = RandomFilling(n);
                ShellSort(unsortedArray2, out c, out p);
                Console.WriteLine("Результат сортировки Шелла для неупорядоченного массива:");
                Console.WriteLine("Количесво сравнений = " + c);
                Console.WriteLine("Количесво пересылок = " + p);
                Console.WriteLine();

                Console.WriteLine("Нажмите Enter, чтобы вернуться в меню...");
                Console.ReadLine();
            }
        }
    }
}
