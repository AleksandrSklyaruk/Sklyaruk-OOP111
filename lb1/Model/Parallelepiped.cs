using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Parallelepiped
    {
        /// <summary>
        /// Класс, представляющий параллелепипед
        /// </summary>
        public class Parallelepiped : IShape3D
        {
            private double _length;
            private double _width;
            private double _height;

            /// <summary>
            /// Длина параллелепипеда
            /// </summary>
            public double Length
            {
                get { return _length; }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Длина должна быть положительным числом");
                    }
                    _length = value;
                }
            }

            /// <summary>
            /// Ширина параллелепипеда
            /// </summary>
            public double Width
            {
                get { return _width; }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Ширина должна быть положительным числом");
                    }
                    _width = value;
                }
            }

            /// <summary>
            /// Высота параллелепипеда
            /// </summary>
            public double Height
            {
                get { return _height; }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Высота должна быть положительным числом");
                    }
                    _height = value;
                }
            }

            /// <summary>
            /// Название фигуры
            /// </summary>
            public string Name => "Параллелепипед";

            /// <summary>
            /// Конструктор параллелепипеда
            /// </summary>
            /// <param name="length">Длина</param>
            /// <param name="width">Ширина</param>
            /// <param name="height">Высота</param>
            public Parallelepiped(double length, double width, double height)
            {
                Length = length;
                Width = width;
                Height = height;
            }

            /// <summary>
            /// Расчёт объёма параллелепипеда: V = a × b × c
            /// </summary>
            /// <returns>Объём параллелепипеда</returns>
            public double CalculateVolume()
            {
                return _length * _width * _height;
            }

            /// <summary>
            /// Получение информации о параллелепипеде
            /// </summary>
            /// <returns>Строковое описание параллелепипеда</returns>
            public string GetInfo()
            {
                return $"Параллелепипед: длина = {_length}, ширина = {_width}, высота = {_height}, объём = {CalculateVolume():F2}";
            }
        }
    }
}
