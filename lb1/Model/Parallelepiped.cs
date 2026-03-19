using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс, представляющий параллелепипед.
    /// </summary>
    public class Parallelepiped : ShapeBase
    {
        private readonly double _length;
        private readonly double _width;
        private readonly double _height;

        /// <summary>
        /// Конструктор параллелепипеда.
        /// </summary>
        /// <param name="length">Длина.</param>
        /// <param name="width">Ширина.</param>
        /// <param name="height">Высота.</param>
        public Parallelepiped
            (double length, double width, double height)
        {
            ValidatePositiveNumber(length, nameof(length));
            ValidatePositiveNumber(width, nameof(width));
            ValidatePositiveNumber(height, nameof(height));
            _length = length;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Название фигуры.
        /// </summary>
        public override string Name => "Параллелепипед";

        /// <summary>
        /// Расчёт объёма параллелепипеда: V = a × b × c.
        /// </summary>
        /// <returns>Объём параллелепипеда.</returns>
        public override double CalculateVolume()
        {
            return _length * _width * _height;
        }

        /// <summary>
        /// Получение информации о параллелепипеде.
        /// </summary>
        /// <returns>Строковое описание параллелепипеда.</returns>
        public override string GetInfo()
        {
            return $"Длина = {_length:F2}, " +
                $"Ширина = {_width:F2}, " +
                $"Высота = {_height:F2}, " +
                $"Объём = {CalculateVolume():F2}";
        }

        /// <summary>
        /// Параметры параллелепипеда.
        /// </summary>
        public override string Parameters =>
            $"Длина = {_length:F2}\n" +
            $"Ширина = {_width:F2}\n" +
            $"Высота = {_height:F2}";

        /// <summary>
        /// Длина параллелепипеда.
        /// </summary>
        public override double Length => _length;

        /// <summary>
        /// Ширина параллелепипеда.
        /// </summary>
        public override double Width => _width;

        /// <summary>
        /// Высота параллелепипеда.
        /// </summary>
        public override double Height => _height;
    }
}
