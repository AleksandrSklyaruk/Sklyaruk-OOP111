using System;
using NUnit.Framework;
using Model;

namespace ModelTests
{
    /// <summary>
    /// Набор модульных тестов для класса ShapeData
    /// </summary>
    public class ShapeDataTests
    {
        #region Constructor and Properties

        /// <summary>
        /// Проверяет, что конструктор по умолчанию 
        /// создаёт экземпляр класса
        /// </summary>
        [Test]
        public void ConstructorShouldCreateInstance()
        {
            Assert.That(new ShapeData(), Is.Not.Null);
        }

        /// <summary>
        /// Проверяет корректность установки и получения 
        /// свойства ShapeData.ShapeType
        /// </summary>
        /// <param name="type">Тип фигуры</param>
        [TestCase("Шар")]
        [TestCase("Пирамида")]
        [TestCase("Параллелепипед")]
        public void ShapeTypeShouldSetAndGetValue(string type)
        {
            var data = new ShapeData { ShapeType = type };

            Assert.That(data.ShapeType, Is.EqualTo(type));
        }

        /// <summary>
        /// Проверяет корректность установки и получения 
        /// свойства ShapeData.Length
        /// </summary>
        /// <param name="value">Значение длины</param>
        [TestCase(5.5)]
        [TestCase(0.0)]
        public void LengthShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Length = value };

            Assert.That(data.Length, Is.EqualTo(value));
        }

        /// <summary>
        /// Проверяет корректность установки и получения 
        /// свойства ShapeData.Width
        /// </summary>
        /// <param name="value">Значение ширины</param>
        [TestCase(3.14)]
        public void WidthShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Width = value };

            Assert.That(data.Width, Is.EqualTo(value));
        }

        /// <summary>
        /// Проверяет корректность установки и получения 
        /// свойства ShapeData.Height
        /// </summary>
        /// <param name="value">Значение высоты</param>
        [TestCase(10.0)]
        public void HeightShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Height = value };

            Assert.That(data.Height, Is.EqualTo(value));
        }

        /// <summary>
        /// Проверяет корректность установки и получения 
        /// свойства ShapeData.Radius
        /// </summary>
        /// <param name="value">Значение радиуса</param>
        [TestCase(7.7)]
        public void RadiusShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Radius = value };

            Assert.That(data.Radius, Is.EqualTo(value));
        }

        #endregion

        #region ShouldSerialize Methods

        /// <summary>
        /// Проверяет корректность работы 
        /// метода ShapeData.ShouldSerializeLength
        /// </summary>
        /// <param name="shapeType">Тип фигуры</param>
        /// <param name="expected">Ожидаемое значение</param>
        [TestCase("Пирамида", true)]
        [TestCase("Параллелепипед", true)]
        [TestCase("Шар", false)]
        [TestCase("Куб", false)]
        public void ShouldSerializeLengthReturnsCorrectValue
            (string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };

            Assert.That(data.ShouldSerializeLength(), 
                Is.EqualTo(expected));
        }

        /// <summary>
        /// Проверяет корректность работы 
        /// метода ShapeData.ShouldSerializeWidth
        /// </summary>
        /// <param name="shapeType">Тип фигуры</param>
        /// <param name="expected">Ожидаемое значение</param>
        [TestCase("Пирамида", true)]
        [TestCase("Параллелепипед", true)]
        [TestCase("Шар", false)]
        [TestCase("Куб", false)]
        public void ShouldSerializeWidthReturnsCorrectValue
            (string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };

            Assert.That(data.ShouldSerializeWidth(), 
                Is.EqualTo(expected));
        }

        /// <summary>
        /// Проверяет корректность работы 
        /// метода ShapeData.ShouldSerializeHeight
        /// </summary>
        /// <param name="shapeType">Тип фигуры</param>
        /// <param name="expected">Ожидаемое значение</param>
        [TestCase("Пирамида", true)]
        [TestCase("Параллелепипед", true)]
        [TestCase("Шар", false)]
        [TestCase("Куб", false)]
        public void ShouldSerializeHeightReturnsCorrectValue
            (string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };

            Assert.That(data.ShouldSerializeHeight(), 
                Is.EqualTo(expected));
        }

        /// <summary>
        /// Проверяет корректность работы 
        /// метода ShapeData.ShouldSerializeRadius
        /// </summary>
        /// <param name="shapeType">Тип фигуры</param>
        /// <param name="expected">Ожидаемое значение</param>
        [TestCase("Шар", true)]
        [TestCase("Пирамида", false)]
        [TestCase("Параллелепипед", false)]
        [TestCase("Куб", false)]
        public void ShouldSerializeRadiusReturnsCorrectValue
            (string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };

            Assert.That(data.ShouldSerializeRadius(), 
                Is.EqualTo(expected));
        }

        #endregion

        #region FromShape Tests

        /// <summary>
        /// Проверяет, что метод ShapeData.FromShape выбрасывает 
        /// ArgumentNullException при передаче null
        /// </summary>
        [Test]
        public void FromShapeNullShapeThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            ShapeData.FromShape(null));
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.FromShape корректно 
        /// устанавливает свойство ShapeData.ShapeType для шара
        /// </summary>
        [Test]
        public void FromShapeSphereSetsCorrectShapeType()
        {
            var data = ShapeData.FromShape(new Sphere(5.0));

            Assert.That(data.ShapeType, Is.EqualTo("Шар"));
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.FromShape корректно 
        /// устанавливает свойство ShapeData.Radius для шара
        /// </summary>
        [Test]
        public void FromShapeSphereSetsCorrectRadius()
        {
            var data = ShapeData.FromShape(new Sphere(5.0));

            Assert.That(data.Radius, Is.EqualTo(5.0));
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.FromShape корректно 
        /// устанавливает свойство ShapeData.ShapeType для пирамиды
        /// </summary>
        [Test]
        public void FromShapePyramidSetsCorrectShapeType()
        {
            var data = ShapeData.FromShape(new Pyramid(3.0, 4.0, 5.0));

            Assert.That(data.ShapeType, Is.EqualTo("Пирамида"));
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.FromShape корректно 
        /// устанавливает свойство ShapeData.Length для пирамиды
        /// </summary>
        [Test]
        public void FromShapePyramidSetsCorrectLength()
        {
            var data = ShapeData.FromShape(new Pyramid(3.0, 4.0, 5.0));

            Assert.That(data.Length, Is.EqualTo(3.0));
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.FromShape корректно 
        /// устанавливает свойство ShapeData.ShapeType для параллелепипеда
        /// </summary>
        [Test]
        public void FromShapeParallelepipedSetsCorrectShapeType()
        {
            var data = ShapeData.FromShape
                (new Parallelepiped(2.0, 3.0, 4.0));

            Assert.That(data.ShapeType, Is.EqualTo("Параллелепипед"));
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.FromShape корректно 
        /// устанавливает свойство ShapeData.Height для параллелепипеда
        /// </summary>
        [Test]
        public void FromShapeParallelepipedSetsCorrectHeight()
        {
            var data = ShapeData.FromShape
                (new Parallelepiped(2.0, 3.0, 4.0));

            Assert.That(data.Height, Is.EqualTo(4.0));
        }

        /// <summary>
        /// Проверяет, что при конвертации пирамиды в ShapeData
        /// свойство ShapeData.Radius равно нулю
        /// </summary>
        [Test]
        public void FromShapePyramidRadiusIsZero()
        {
            var data = ShapeData.FromShape(new Pyramid(3.0, 4.0, 5.0));

            Assert.That(data.Radius, Is.EqualTo(0));
        }

        /// <summary>
        /// Проверяет, что при конвертации шара в ShapeData 
        /// свойство ShapeData.Length равно нулю
        /// </summary>
        [Test]
        public void FromShapeSphereLengthIsZero()
        {
            var data = ShapeData.FromShape(new Sphere(5.0));

            Assert.That(data.Length, Is.EqualTo(0));
        }

        #endregion

        #region ToShape Tests

        /// <summary>
        /// Проверяет, что метод ShapeData.ToShape
        /// возвращает экземпляр Sphere
        /// для данных шара.
        /// </summary>
        [Test]
        public void ToShapeSphereDataReturnsSphereInstance()
        {
            var data = new ShapeData { ShapeType = "Шар", Radius = 5.0 };

            Assert.That(data.ToShape(), Is.InstanceOf<Sphere>());
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.ToShape 
        /// возвращает экземпляр Pyramid для данных пирамиды
        /// </summary>
        [Test]
        public void ToShapePyramidDataReturnsPyramidInstance()
        {
            var data = new ShapeData 
            { ShapeType = "Пирамида", Length = 3, Width = 4, Height = 5 };

            Assert.That(data.ToShape(), Is.InstanceOf<Pyramid>());
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.ToShape возвращает 
        /// экземпляр Parallelepiped для данных параллелепипеда
        /// </summary>
        [Test]
        public void ToShapeParallelepipedDataReturnsParallelepipedInstance()
        {
            var data = new ShapeData 
            { ShapeType = "Параллелепипед", 
                Length = 2, Width = 3, Height = 4 };

            Assert.That(data.ToShape(), Is.InstanceOf<Parallelepiped>());
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.ToShape корректно 
        /// устанавливает свойство Sphere.Radius для шара
        /// </summary>
        [Test]
        public void ToShapeSphereDataSetsCorrectRadius()
        {
            var shape = (Sphere)new ShapeData 
            { ShapeType = "Шар", Radius = 5.0 }.ToShape();

            Assert.That(shape.Radius, Is.EqualTo(5.0));
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.ToShape корректно 
        /// устанавливает свойство Pyramid.Length для пирамиды
        /// </summary>
        [Test]
        public void ToShapePyramidDataSetsCorrectLength()
        {
            var shape = (Pyramid)new ShapeData 
            { ShapeType = "Пирамида", 
                Length = 3, Width = 4, Height = 5 }.ToShape();

            Assert.That(shape.Length, Is.EqualTo(3.0));
        }

        /// <summary>
        /// Проверяет, что метод ShapeData.ToShape выбрасывает 
        /// InvalidOperationException для неизвестного типа фигуры
        /// </summary>
        [Test]
        public void ToShapeUnknownTypeThrowsInvalidOperationException()
        {
            var data = new ShapeData { ShapeType = "Куб" };
            Assert.Throws<InvalidOperationException>(() => data.ToShape());
        }

        #endregion
    }
}