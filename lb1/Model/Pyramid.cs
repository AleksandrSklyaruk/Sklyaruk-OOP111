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
    public class Pyramid : IShape3D
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
                if (value <= 0)
                {
                    throw new ArgumentException("Площадь основания должна быть положительным числом");
                }
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
        public string Name => "Пирамида";

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
        public double CalculateVolume()
        {
            return (1.0 / 3.0) * _baseArea * _height;
        }

        /// <summary>
        /// Получение информации о пирамиде
        /// </summary>
        /// <returns>Строковое описание пирамиды</returns>
        public string GetInfo()
        {
            return $"Пирамида: площадь основания = {_baseArea}, высота = {_height}, объём = {CalculateVolume():F2}";
        }
    }
}
