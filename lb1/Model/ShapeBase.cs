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

        // ✅ Свойства для привязки к DataGridView
        /// <summary>
        /// Название фигуры (для DataGridView)
        /// </summary>
        public string ShapeName => Name;

        /// <summary>
        /// Объём фигуры (для DataGridView)
        /// </summary>
        public double Volume => CalculateVolume();

        /// <summary>
        /// Информация о фигуре (для DataGridView)
        /// </summary>
        public string Info => GetInfo();

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
                    $" должно быть положительным числом.");
            }
        }
    }
}
