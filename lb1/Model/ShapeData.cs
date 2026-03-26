using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Класс для сериализации/десериализации фигур в XML
    /// </summary>
    public class ShapeData
    {
        /// <summary>
        /// Тип фигуры (название).
        /// </summary>
        public string ShapeType { get; set; }

        /// <summary>
        /// Длина фигуры (для параллелепипеда и пирамиды).
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Ширина фигуры (для параллелепипеда и пирамиды).
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Высота фигуры (для параллелепипеда и пирамиды).
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Радиус фигуры (для шара).
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ShapeData"/>.
        /// Требуется для сериализации XML.
        /// </summary>
        public ShapeData() { }

        /// <summary>
        /// Создаёт объект <see cref="ShapeData"/> 
        /// из фигуры <see cref="IShape"/>.
        /// </summary>
        /// <param name="shape">Фигура для преобразования.</param>
        /// <returns>Объект <see cref="ShapeData"/>
        /// с данными фигуры.</returns>
        /// <exception cref="ArgumentNullException">
        /// Выбрасывается если shape равен null.</exception>
        public static ShapeData FromShape(IShape shape)
        {
            if (shape == null)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            return new ShapeData
            {
                ShapeType = shape.Name,
                Length = shape.Length,
                Width = shape.Width,
                Height = shape.Height,
                Radius = shape.Radius,
            };
        }

        /// <summary>
        /// Создаёт фигуру <see cref="IShape"/>
        /// из объекта <see cref="ShapeData"/>.
        /// </summary>
        /// <returns>Фигура типа <see cref="IShape"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается при неизвестном типе фигуры.</exception>
        public IShape ToShape()
        {
            return ShapeType switch
            {
                "Шар" => new Sphere(Radius),
                "Пирамида" => new Pyramid(Length, Width, Height),
                "Параллелепипед" => new Parallelepiped
                (Length, Width, Height),
                _ => throw new InvalidOperationException
                ($"Неизвестный тип фигуры: {ShapeType}")
            };
        }
    }
}
