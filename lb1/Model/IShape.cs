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

        /// <summary>
        /// Длина фигуры (0, если не применимо).
        /// </summary>
        double Length { get; }

        /// <summary>
        /// Ширина фигуры (0, если не применимо).
        /// </summary>
        double Width { get; }

        /// <summary>
        /// Высота фигуры (0, если не применимо).
        /// </summary>
        double Height { get; }

        /// <summary>
        /// Радиус фигуры (0, если не применимо).
        /// </summary>
        double Radius { get; }

        /// <summary>
        /// Строковое представление параметров фигуры.
        /// Для шара: "Радиус = значение"
        /// Для пирамиды/параллелепипеда: "Длина = значение\n
        /// Ширина = значение\n
        /// Высота = значение"
        /// </summary>
        string Parameters { get; }

        double Volume => CalculateVolume();
    }

}
