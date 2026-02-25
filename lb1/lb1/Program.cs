using Model;
using System;
using System.Reflection;

namespace lb3
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Попытка создать сферу с отрицательным радиусом
                Sphere invalidSphere = new Sphere(-5.0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка валидации: {ex.Message}");
                // Вывод: Ошибка валидации: Значение параметра 'Radius' должно быть положительным числом. Получено: -5
            }

            try
            {
                // Попытка создать параллелепипед с нулевой шириной
                Parallelepiped invalidBox = new Parallelepiped(10.0, 0.0, 5.0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка валидации: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}