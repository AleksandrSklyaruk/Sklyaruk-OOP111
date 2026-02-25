using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс, представляющий сферу
    /// </summary>
    public class Sphere : IShape3D
    {
        private double _radius;

        /// <summary>
        /// Радиус сферы
        /// </summary>
        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Радиус должен быть положительным числом");
                }
                _radius = value;
            }
        }

        /// <summary>
        /// Название фигуры
        /// </summary>
        public string Name => "Шар";

        /// <summary>
        /// Конструктор сферы
        /// </summary>
        /// <param name="radius">Радиус сферы</param>
        public Sphere(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Расчёт объёма сферы: V = 4/3 × π × r³
        /// </summary>
        /// <returns>Объём сферы</returns>
        public double CalculateVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(_radius, 3);
        }

        /// <summary>
        /// Получение информации о сфере
        /// </summary>
        /// <returns>Строковое описание сферы</returns>
        public string GetInfo()
        {
            return $"Шар: радиус = {_radius}, объём = {CalculateVolume():F2}";
        }
    }
}
