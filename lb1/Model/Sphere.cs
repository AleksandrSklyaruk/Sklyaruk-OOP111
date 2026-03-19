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
        private readonly double _radius;

        /// <summary>
        /// Конструктор шара.
        /// </summary>
        /// <param name="radius">Радиус шара.</param>
        public Sphere(double radius)
        {
            ValidatePositiveNumber(radius, nameof(radius));
            _radius = radius;
        }

        /// <summary>
        /// Название фигуры.
        /// </summary>
        public override string Name => "Шар";

        /// <summary>
        /// Расчёт объёма шара: V = 4/3 × π × r³.
        /// </summary>
        /// <returns>Объём шара.</returns>
        public override double CalculateVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(_radius, 3);
        }

        /// <summary>
        /// Получение информации о шаре.
        /// </summary>
        /// <returns>Строковое описание шара.</returns>
        public override string GetInfo()
        {
            return $"Радиус = {_radius:F2}, " +
                $"Объём = {CalculateVolume():F2}";
        }

        /// <summary>
        /// Параметры шара.
        /// </summary>
        public override string Parameters => 
            $"Радиус = {_radius:F2}";

        /// <summary>
        /// Радиус шара.
        /// </summary>
        public override double Radius => _radius;
    }
}
