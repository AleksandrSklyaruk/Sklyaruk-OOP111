using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс, представляющий шар
    /// </summary>
    public class Sphere : ShapeBase
    {
        //TODO: XML
        private double _radius;

        /// <summary>
        /// Конструктор шара
        /// </summary>
        /// <param name="radius">Радиус шара</param>
        public Sphere(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Радиус шара
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
        /// Расчёт объёма шара: V = 4/3 × π × r³
        /// </summary>
        /// <returns>Объём шара</returns>
        public override double CalculateVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(_radius, 3);
        }

        /// <summary>
        /// Получение информации о шаре
        /// </summary>
        /// <returns>Строковое описание шара</returns>
        public override string GetInfo()
        {
            return $"Объём шара = {CalculateVolume():F2}\n";
        }
    }
}
