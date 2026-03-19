using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс, представляющий пирамиду.
    /// </summary>
    public class Pyramid : ShapeBase
    {
        private readonly double _length;
        private readonly double _width;
        private readonly double _height;

        /// <summary>
        /// Конструктор пирамиды.
        /// </summary>
        /// <param name="length">Длина основания.</param>
        /// <param name="width">Ширина основания.</param>
        /// <param name="height">Высота пирамиды.</param>
        public Pyramid(double length, double width, double height)
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
        public override string Name => "Пирамида";

        /// <summary>
        /// Расчёт объёма пирамиды: V = 1/3 × a × b × h.
        /// </summary>
        /// <returns>Объём пирамиды.</returns>
        public override double CalculateVolume()
        {
            return (1.0 / 3.0) * _length * _width * _height;
        }

        /// <summary>
        /// Получение информации о пирамиде.
        /// </summary>
        /// <returns>Строковое описание пирамиды.</returns>
        public override string GetInfo()
        {
            return $"Длина = {_length:F2}\n" +
                $", Ширина = {_width:F2}\n" +
                $", Высота = {_height:F2}\n" +
                $", Объём = {CalculateVolume():F2}";
        }

        /// <summary>
        /// Параметры пирамиды.
        /// </summary>
        public override string Parameters =>
            $"Длина = {_length:F2}\n" +
            $"Ширина = {_width:F2}\n" +
            $"Высота = {_height:F2}";

        /// <summary>
        /// Длина основания пирамиды.
        /// </summary>
        public override double Length => _length;

        /// <summary>
        /// Ширина основания пирамиды.
        /// </summary>
        public override double Width => _width;

        /// <summary>
        /// Высота пирамиды.
        /// </summary>
        public override double Height => _height;
    }
}
