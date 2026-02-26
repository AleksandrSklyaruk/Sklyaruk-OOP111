using Model;
using System;
using System.Reflection;

namespace  ConsoleLeader
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<IShape> userShapes = new List<IShape>();
            bool continueCreating = true;

            while (continueCreating)
            {
                Console.WriteLine("Выберите тип фигуры:");
                Console.WriteLine("1. Шар");
                Console.WriteLine("2. Пирамида");
                Console.WriteLine("3. Параллелепипед");
                Console.WriteLine("0. Завершить создание фигур");
                Console.Write("\nВаш выбор: ");

                string choice = Console.ReadLine();
                IShape newShape = null;

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
                            Console.WriteLine("\nНеверный выбор. Попробуйте снова.\n");
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
                    Console.WriteLine($"\n Ошибка при создании фигуры: {ex.Message}\n");
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

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
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
            double result = 0;
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