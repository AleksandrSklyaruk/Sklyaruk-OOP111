using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Интерфейс для представления трёхмерных фигур
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Название фигуры
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Метод для расчёта объёма фигуры
        /// </summary>
        /// <returns>Объём фигуры</returns>
        double CalculateVolume();

        /// <summary>
        /// Метод для получения информации о фигуре
        /// </summary>
        /// <returns>Строковое описание фигуры</returns>
        string GetInfo();
    }

}
