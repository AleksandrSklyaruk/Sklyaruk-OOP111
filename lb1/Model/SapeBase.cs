using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Абстрактный базовый класс для трёхмерных фигур.
    /// Реализует общую логику валидации данных.
    /// </summary>
    public abstract class ShapeBase : IShape
    {
        /// <summary>
        /// Название фигуры
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Метод для расчёта объёма фигуры
        /// </summary>
        /// <returns>Объём фигуры</returns>
        public abstract double CalculateVolume();

        /// <summary>
        /// Метод для получения информации о фигуре
        /// </summary>
        /// <returns>Строковое описание фигуры</returns>
        public abstract string GetInfo();

        /// <summary>
        /// Метод валидации положительного числа
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="parameterName">Имя параметра для сообщения об ошибке</param>
        protected void ValidatePositiveNumber
            (double value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    $"Значение параметра '{parameterName}'" +
                    $" должно быть положительным числом. " +
                    $"Получено: {value}", parameterName);
            }

            // Проверка на бесконечность и NaN (Not a Number)
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException(
                    $"Значение параметра '{parameterName}' " +
                    $"не может быть NaN или бесконечностью.",
                    parameterName);
            }
        }
    }
}
