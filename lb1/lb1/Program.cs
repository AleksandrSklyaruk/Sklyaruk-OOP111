using Model;
using System;
using System.Reflection;

namespace  ConsoleLeader
{
    /// <summary>
    /// Класс программы
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Главное
        /// </summary>
        static void Main()
        {

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
                          return;
                      default:
                          Console.WriteLine("\nНеверный выбор. Попробуйте снова.\n");
                          continue;
                  }

                  if (newShape != null)
                  {
                      Console.WriteLine($"{newShape.GetInfo()}");
                  }
            }
        }

        /// <summary>
        /// Создание сферы с вводом данных с клавиатуры
        /// </summary>
        private static Sphere CreateSphereFromInput()
        {
            double radius = ReadPositiveDouble("Введите радиус шара: ");
            return new Sphere(radius);
        }

        /// <summary>
        /// Создание пирамиды с вводом данных с клавиатуры
        /// </summary>
        private static Pyramid CreatePyramidFromInput()
        {
            double length = ReadPositiveDouble("Введите длину основания пирамиды: ");
            double width = ReadPositiveDouble("Введите ширину основания пирамиды: ");
            double height = ReadPositiveDouble("Введите высоту пирамиды: ");
            return new Pyramid(length, width, height);
        }

        /// <summary>
        /// Создание параллелепипеда с вводом данных с клавиатуры
        /// </summary>
        private static Parallelepiped CreateParallelepipedFromInput()
        {
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
                        Console.WriteLine("Значение должно быть положительным числом." +
                            " Попробуйте снова.");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат числа. Попробуйте снова.");
                }
            }

            return result;
        }
    }
}