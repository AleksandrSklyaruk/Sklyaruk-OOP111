using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleLoader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Лабораторная работа №3. Вариант 2 ===");
            Console.WriteLine("Трёхмерные фигуры: Шар, Пирамида, Параллелепипед\n");

            // Демонстрация работы через интерфейс IShape3D
            DemonstrateInterfaceUsage();

            // Демонстрация полиморфизма
            DemonstratePolymorphism();

            // Демонстрация валидации данных
            DemonstrateValidation();

            // Интерактивный режим
            RunInteractiveMode();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// Демонстрация работы с интерфейсом IShape3D
        /// </summary>
        private static void DemonstrateInterfaceUsage()
        {
            Console.WriteLine("=== 1. Демонстрация работы с интерфейсом IShape3D ===\n");

            // Создаём переменную-ссылку на интерфейс
            IShape3D shape;

            // Присваиваем экземпляр Sphere
            shape = new Sphere(5.0);
            Console.WriteLine($"Фигура: {shape.Name}");
            Console.WriteLine($"Информация: {shape.GetInfo()}");
            Console.WriteLine($"Объём: {shape.CalculateVolume():F2}\n");

            // Присваиваем экземпляр Pyramid
            shape = new Pyramid(25.0, 10.0);
            Console.WriteLine($"Фигура: {shape.Name}");
            Console.WriteLine($"Информация: {shape.GetInfo()}");
            Console.WriteLine($"Объём: {shape.CalculateVolume():F2}\n");

            // Присваиваем экземпляр Parallelepiped
            shape = new Parallelepiped(4.0, 5.0, 6.0);
            Console.WriteLine($"Фигура: {shape.Name}");
            Console.WriteLine($"Информация: {shape.GetInfo()}");
            Console.WriteLine($"Объём: {shape.CalculateVolume():F2}\n");

            PressAnyKey();
        }

        /// <summary>
        /// Демонстрация полиморфизма - работа со списком фигур
        /// </summary>
        private static void DemonstratePolymorphism()
        {
            Console.WriteLine("=== 2. Демонстрация полиморфизма (список фигур) ===\n");

            // Создаём список интерфейсов
            List<IShape3D> shapes = new List<IShape3D>();

            // Добавляем разные фигуры
            shapes.Add(new Sphere(3.0));
            shapes.Add(new Pyramid(15.0, 8.0));
            shapes.Add(new Parallelepiped(2.0, 3.0, 4.0));
            shapes.Add(new Sphere(7.5));
            shapes.Add(new Parallelepiped(5.0, 5.0, 5.0));

            Console.WriteLine($"Всего фигур в списке: {shapes.Count}\n");

            // Демонстрируем полиморфное поведение
            int index = 1;
            foreach (var shape in shapes)
            {
                Console.WriteLine($"Фигура #{index}:");
                Console.WriteLine($"  Тип: {shape.Name}");
                Console.WriteLine($"  Объём: {shape.CalculateVolume():F2}");
                Console.WriteLine($"  Описание: {shape.GetInfo()}");
                Console.WriteLine();
                index++;
            }

            PressAnyKey();
        }

        /// <summary>
        /// Демонстрация валидации данных через исключения
        /// </summary>
        private static void DemonstrateValidation()
        {
            Console.WriteLine("=== 3. Демонстрация валидации данных ===\n");

            // Тест 1: Отрицательный радиус
            Console.WriteLine("Тест 1: Попытка создать сферу с отрицательным радиусом (-5.0)");
            try
            {
                Sphere invalidSphere = new Sphere(-5.0);
                Console.WriteLine("ERROR: Исключение не было выброшено!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✓ Корректно поймано исключение:");
                Console.WriteLine($"  {ex.Message}\n");
            }

            // Тест 2: Нулевая высота пирамиды
            Console.WriteLine("Тест 2: Попытка создать пирамиду с нулевой высотой (0.0)");
            try
            {
                Pyramid invalidPyramid = new Pyramid(10.0, 0.0);
                Console.WriteLine("ERROR: Исключение не было выброшено!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✓ Корректно поймано исключение:");
                Console.WriteLine($"  {ex.Message}\n");
            }

            // Тест 3: Отрицательная длина параллелепипеда
            Console.WriteLine("Тест 3: Попытка создать параллелепипед с отрицательной длиной (-3.0)");
            try
            {
                Parallelepiped invalidBox = new Parallelepiped(-3.0, 5.0, 4.0);
                Console.WriteLine("ERROR: Исключение не было выброшено!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✓ Корректно поймано исключение:");
                Console.WriteLine($"  {ex.Message}\n");
            }

            // Тест 4: NaN значение
            Console.WriteLine("Тест 4: Попытка создать сферу с радиусом NaN");
            try
            {
                Sphere nanSphere = new Sphere(double.NaN);
                Console.WriteLine("ERROR: Исключение не было выброшено!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✓ Корректно поймано исключение:");
                Console.WriteLine($"  {ex.Message}\n");
            }

            PressAnyKey();
        }

        /// <summary>
        /// Интерактивный режим создания фигур
        /// </summary>
        private static void RunInteractiveMode()
        {
            Console.WriteLine("=== 4. Интерактивный режим создания фигур ===\n");

            List<IShape3D> userShapes = new List<IShape3D>();
            bool continueCreating = true;

            while (continueCreating)
            {
                Console.WriteLine("Выберите тип фигуры:");
                Console.WriteLine("1. Шар (Sphere)");
                Console.WriteLine("2. Пирамида (Pyramid)");
                Console.WriteLine("3. Параллелепипед (Parallelepiped)");
                Console.WriteLine("0. Завершить создание фигур");
                Console.Write("\nВаш выбор: ");

                string choice = Console.ReadLine();
                IShape3D newShape = null;

                try
                {
                    switch (choice)
                    {
                        case "1":
                            newShape = CreateSphereFromInput();
                            break;
                        case "2":
                            newShape = CreatePyramidFromInput();
                            break;
                        case "3":
                            newShape = CreateParallelepipedFromInput();
                            break;
                        case "0":
                            continueCreating = false;
                            Console.WriteLine("\nЗавершение создания фигур.");
                            break;
                        default:
                            Console.WriteLine("\n❌ Неверный выбор. Попробуйте снова.\n");
                            continue;
                    }

                    if (newShape != null)
                    {
                        userShapes.Add(newShape);
                        Console.WriteLine($"\n✓ Фигура успешно создана!");
                        Console.WriteLine($"  {newShape.GetInfo()}\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n❌ Ошибка при создании фигуры: {ex.Message}\n");
                }
            }

            // Вывод всех созданных фигур
            if (userShapes.Count > 0)
            {
                Console.WriteLine("\n=== Все созданные фигуры ===");
                int number = 1;
                double totalVolume = 0;

                foreach (var shape in userShapes)
                {
                    Console.WriteLine($"\nФигура #{number}: {shape.Name}");
                    Console.WriteLine($"  {shape.GetInfo()}");
                    totalVolume += shape.CalculateVolume();
                    number++;
                }

                Console.WriteLine($"\n=== Итого ===");
                Console.WriteLine($"Всего фигур: {userShapes.Count}");
                Console.WriteLine($"Суммарный объём: {totalVolume:F2}");
            }
        }

        /// <summary>
        /// Создание сферы с вводом данных с клавиатуры
        /// </summary>
        private static Sphere CreateSphereFromInput()
        {
            Console.WriteLine("\n--- Создание сферы ---");
            double radius = ReadPositiveDouble("Введите радиус сферы: ");
            return new Sphere(radius);
        }

        /// <summary>
        /// Создание пирамиды с вводом данных с клавиатуры
        /// </summary>
        private static Pyramid CreatePyramidFromInput()
        {
            Console.WriteLine("\n--- Создание пирамиды ---");
            double baseArea = ReadPositiveDouble("Введите площадь основания: ");
            double height = ReadPositiveDouble("Введите высоту пирамиды: ");
            return new Pyramid(baseArea, height);
        }

        /// <summary>
        /// Создание параллелепипеда с вводом данных с клавиатуры
        /// </summary>
        private static Parallelepiped CreateParallelepipedFromInput()
        {
            Console.WriteLine("\n--- Создание параллелепипеда ---");
            double length = ReadPositiveDouble("Введите длину: ");
            double width = ReadPositiveDouble("Введите ширину: ");
            double height = ReadPositiveDouble("Введите высоту: ");
            return new Parallelepiped(length, width, height);
        }

        /// <summary>
        /// Чтение положительного числа с клавиатуры
        /// </summary>
        private static double ReadPositiveDouble(string prompt)
        {
            double result;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (double.TryParse(input, out result))
                {
                    if (result <= 0)
                    {
                        Console.WriteLine("❌ Значение должно быть положительным числом (> 0). Попробуйте снова.");
                    }
                    else if (double.IsNaN(result) || double.IsInfinity(result))
                    {
                        Console.WriteLine("❌ Значение не может быть NaN или бесконечностью. Попробуйте снова.");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("❌ Неверный формат числа. Попробуйте снова.");
                }
            }

            return result;
        }

        /// <summary>
        /// Ожидание нажатия любой клавиши
        /// </summary>
        private static void PressAnyKey()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
