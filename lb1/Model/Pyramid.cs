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
        private double _baseArea;
        private double _height;

        /// <summary>
        /// Площадь основания пирамиды
        /// </summary>
        public double BaseArea
        {
            get { return _baseArea; }
            set
            {
                ValidatePositiveNumber(value, nameof(BaseArea));
                _baseArea = value;
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
        /// Конструктор пирамиды
        /// </summary>
        /// <param name="baseArea">Площадь основания</param>
        /// <param name="height">Высота пирамиды</param>
        public Pyramid(double baseArea, double height)
        {
            BaseArea = baseArea;
            Height = height;
        }

        /// <summary>
        /// Расчёт объёма пирамиды: V = 1/3 × S_осн × h
        /// </summary>
        /// <returns>Объём пирамиды</returns>
        public override double CalculateVolume()
        {
            return (1.0 / 3.0) * _baseArea * _height;
        }

        /// <summary>
        /// Получение информации о пирамиде
        /// </summary>
        /// <returns>Строковое описание пирамиды</returns>
        public override string GetInfo()
        {
            return $"Пирамида: площадь основания = {_baseArea}, высота = {_height}, объём = {CalculateVolume():F2}";
        }
    }
}
