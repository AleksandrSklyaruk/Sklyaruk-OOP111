using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс, представляющий параллелепипед
    /// </summary>
    public class Parallelepiped : ShapeBase
    {
        private double _length;
        private double _width;
        private double _height;

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
        /// Длина параллелепипеда
        /// </summary>
        public double Length
        {
            get { return _length; }
            set
            {
                ValidatePositiveNumber(value, nameof(Length));
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
                ValidatePositiveNumber(value, nameof(Width));
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
                ValidatePositiveNumber(value, nameof(Height));
                _height = value;
            }
        }

        /// <summary>
        /// Название фигуры
        /// </summary>
        public override string Name => "Параллелепипед";

        /// <summary>
        /// Расчёт объёма параллелепипеда: V = a × b × c
        /// </summary>
        /// <returns>Объём параллелепипеда</returns>
        public override double CalculateVolume()
        {
            return _length * _width * _height;
        }

        /// <summary>
        /// Получение информации о параллелепипеде
        /// </summary>
        /// <returns>Строковое описание параллелепипеда</returns>
        public override string GetInfo()
        {
            return $" Фигур: параллелепипед\n" +
                $" Длина = {_length}\n" +
                $" Ширина = {_width}\n" +
                $" Высота = {_height}\n" +
                $" Объём = {CalculateVolume():F2}\n";
        }
    }
}
