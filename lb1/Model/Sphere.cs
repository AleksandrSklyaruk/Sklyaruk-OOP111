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
    public class Sphere : ShapeBase
    {
        private double _radius;

        /// <summary>
        /// Конструктор сферы
        /// </summary>
        /// <param name="radius">Радиус сферы</param>
        public Sphere(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Радиус сферы
        /// </summary>
        public double Radius
        {
            get { return _radius; }
            set
            {
                ValidatePositiveNumber(value, nameof(Radius));
                _radius = value;
            }
        }

        /// <summary>
        /// Название фигуры
        /// </summary>
        public override string Name => "Шар";

        /// <summary>
        /// Расчёт объёма сферы: V = 4/3 × π × r³
        /// </summary>
        /// <returns>Объём сферы</returns>
        public override double CalculateVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(_radius, 3);
        }

        /// <summary>
        /// Получение информации о сфере
        /// </summary>
        /// <returns>Строковое описание сферы</returns>
        public override string GetInfo()
        {
            return $"Объём шара = {CalculateVolume():F2}\n";
        }
    }
}
