using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс, представляющий пирамиду
    /// </summary>
    public class Pyramid : ShapeBase
    {
        //TODO: XML
        private double _length;
        //TODO: XML
        private double _width;
        //TODO: XML
        private double _height;

        /// <summary>
        /// Конструктор пирамиды
        /// </summary>
        /// <param name="baseArea">Площадь основания</param>
        /// <param name="height">Высота пирамиды</param>
        public Pyramid(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Длина основания пирамиды
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
        /// Ширина основания пирамиды
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
        /// Высота пирамиды
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
        public override string Name => "Пирамида";

        /// <summary>
        /// Расчёт объёма пирамиды: V = 1/3 × S_осн × h
        /// </summary>
        /// <returns>Объём пирамиды</returns>
        public override double CalculateVolume()
        {
            return (1.0 / 3.0) * _length * _width * _height;
        }

        /// <summary>
        /// Получение информации о пирамиде
        /// </summary>
        /// <returns>Строковое описание пирамиды</returns>
        public override string GetInfo()
        {
            return $"Объём = {CalculateVolume():F2}\n";
        }
    }
}
