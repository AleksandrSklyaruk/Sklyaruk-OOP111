using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Абстрактный базовый класс для трёхмерных фигур
    /// </summary>
    public abstract class ShapeBase : IShape
    {
        /// <summary>
        /// Название фигуры.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Метод для расчёта объёма фигуры.
        /// </summary>
        /// <returns>Объём фигуры.</returns>
        public abstract double CalculateVolume();

        /// <summary>
        /// Метод для получения информации о фигуре.
        /// </summary>
        /// <returns>Строковое описание фигуры.</returns>
        public abstract string GetInfo();

        /// <summary>
        /// Строковое представление параметров фигуры.
        /// </summary>
        public abstract string Parameters { get; }

        /// <summary>
        /// Длина фигуры (по умолчанию 0).
        /// </summary>
        public virtual double Length => 0;

        /// <summary>
        /// Ширина фигуры (по умолчанию 0).
        /// </summary>
        public virtual double Width => 0;

        /// <summary>
        /// Высота фигуры (по умолчанию 0).
        /// </summary>
        public virtual double Height => 0;

        /// <summary>
        /// Радиус фигуры (по умолчанию 0).
        /// </summary>
        public virtual double Radius => 0;

        /// <summary>
        /// Объём фигуры (для привязки к DataGridView).
        /// </summary>
        public double Volume => CalculateVolume();

        /// <summary>
        /// Метод валидации положительного числа.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="parameterName">
        /// Имя параметра для сообщения об ошибке.</param>
        protected void ValidatePositiveNumber
            (double value, string parameterName)
        {
            if (double.IsNaN(value) || double.IsInfinity(value) || value <= 0)
            {
                throw new ArgumentException(
                    $"Значение параметра '{parameterName}' " +
                    $"должно быть положительным числом.");
            }
        }
    }
}
