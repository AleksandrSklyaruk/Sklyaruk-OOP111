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

        [Description("Проверка создания экземпляра ShapeData через" +
            " конструктор по умолчанию")]
        [Test]
        public void ConstructorShouldCreateInstance()
        {
            Assert.That(new ShapeData(), Is.Not.Null);
        }

        [Description("Проверка корректности установки и получения " +
            "свойства ShapeType")]
        [TestCase("Шар")]
        [TestCase("Пирамида")]
        [TestCase("Параллелепипед")]
        public void ShapeTypeShouldSetAndGetValue(string type)
        {
            var data = new ShapeData { ShapeType = type };

            Assert.That(data.ShapeType, Is.EqualTo(type));
        }

        [Description("Проверка корректности установки и получения " +
            "свойства Length")]
        [TestCase(5.5)]
        [TestCase(0.0)]
        public void LengthShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Length = value };

            Assert.That(data.Length, Is.EqualTo(value));
        }

        [Description("Проверка корректности установки и получения" +
            " свойства Width")]
        [TestCase(3.14)]
        public void WidthShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Width = value };

            Assert.That(data.Width, Is.EqualTo(value));
        }

        [Description("Проверка корректности установки и получения " +
            "свойства Height")]
        [TestCase(10.0)]
        public void HeightShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Height = value };

            Assert.That(data.Height, Is.EqualTo(value));
        }

        [Description("Проверка корректности установки и получения " +
            "свойства Radius")]
        [TestCase(7.7)]
        public void RadiusShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Radius = value };

            Assert.That(data.Radius, Is.EqualTo(value));
        }

        #endregion

        #region ShouldSerialize Methods

        [Description("Проверка корректности работы метода " +
            "ShouldSerializeLength")]
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

        [Description("Проверка корректности работы метода " +
            "ShouldSerializeWidth")]
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

        [Description("Проверка корректности работы метода" +
            " ShouldSerializeHeight")]
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

        [Description("Проверка корректности работы метода" +
            " ShouldSerializeRadius")]
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

        [Description("Проверка выброса ArgumentNullException при" +
            " передаче null в FromShape")]
        [Test]
        public void FromShapeNullShapeThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            ShapeData.FromShape(null));
        }

        [Description("Проверка установки ShapeType при конвертации" +
            " шара в ShapeData")]
        [Test]
        public void FromShapeSphereSetsCorrectShapeType()
        {
            var data = ShapeData.FromShape(new Sphere(5.0));

            Assert.That(data.ShapeType, Is.EqualTo("Шар"));
        }

        [Description("Проверка установки Radius при конвертации" +
            " шара в ShapeData")]
        [Test]
        public void FromShapeSphereSetsCorrectRadius()
        {
            var data = ShapeData.FromShape(new Sphere(5.0));

            Assert.That(data.Radius, Is.EqualTo(5.0));
        }

        [Description("Проверка установки ShapeType при конвертации " +
            "пирамиды в ShapeData")]
        [Test]
        public void FromShapePyramidSetsCorrectShapeType()
        {
            var data = ShapeData.FromShape(new Pyramid(3.0, 4.0, 5.0));

            Assert.That(data.ShapeType, Is.EqualTo("Пирамида"));
        }

        [Description("Проверка установки Length при конвертации " +
            "пирамиды в ShapeData")]
        [Test]
        public void FromShapePyramidSetsCorrectLength()
        {
            var data = ShapeData.FromShape(new Pyramid(3.0, 4.0, 5.0));

            Assert.That(data.Length, Is.EqualTo(3.0));
        }

        [Description("Проверка установки ShapeType при конвертации " +
            "параллелепипеда в ShapeData")]
        [Test]
        public void FromShapeParallelepipedSetsCorrectShapeType()
        {
            var data = ShapeData.FromShape
                (new Parallelepiped(2.0, 3.0, 4.0));

            Assert.That(data.ShapeType, Is.EqualTo("Параллелепипед"));
        }

        [Description("Проверка установки Height при конвертации " +
            "параллелепипеда в ShapeData")]
        [Test]
        public void FromShapeParallelepipedSetsCorrectHeight()
        {
            var data = ShapeData.FromShape
                (new Parallelepiped(2.0, 3.0, 4.0));

            Assert.That(data.Height, Is.EqualTo(4.0));
        }

        [Description("Проверка, что при конвертации пирамиды в ShapeData " +
            "свойство Radius равно нулю")]
        [Test]
        public void FromShapePyramidRadiusIsZero()
        {
            var data = ShapeData.FromShape(new Pyramid(3.0, 4.0, 5.0));

            Assert.That(data.Radius, Is.EqualTo(0));
        }

        [Description("Проверка, что при конвертации шара в ShapeData " +
            "свойство Length равно нулю")]
        [Test]
        public void FromShapeSphereLengthIsZero()
        {
            var data = ShapeData.FromShape(new Sphere(5.0));

            Assert.That(data.Length, Is.EqualTo(0));
        }

        #endregion

        #region ToShape Tests

        [Description("Проверка, что метод ToShape возвращает экземпляр " +
            "Sphere для данных шара")]
        [Test]
        public void ToShapeSphereDataReturnsSphereInstance()
        {
            var data = new ShapeData { ShapeType = "Шар", Radius = 5.0 };

            Assert.That(data.ToShape(), Is.InstanceOf<Sphere>());
        }

        [Description("Проверка, что метод ToShape возвращает экземпляр " +
            "Pyramid для данных пирамиды")]
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

        [Description("Проверка, что метод ToShape возвращает экземпляр " +
            "Parallelepiped для данных параллелепипеда")]
        [Test]
        public void ToShapeSphereDataSetsCorrectRadius()
        {
            var shape = (Sphere)new ShapeData 
            { ShapeType = "Шар", Radius = 5.0 }.ToShape();

            Assert.That(shape.Radius, Is.EqualTo(5.0));
        }


        [Description("Проверка установки Radius при десериализации шара " +
            "из ShapeData")]
        [Test]
        public void ToShapePyramidDataSetsCorrectLength()
        {
            var shape = (Pyramid)new ShapeData 
            { ShapeType = "Пирамида", 
                Length = 3, Width = 4, Height = 5 }.ToShape();

            Assert.That(shape.Length, Is.EqualTo(3.0));
        }

        [Description("Проверка установки Length при десериализации " +
            "пирамиды из ShapeData")]
        [Test]
        public void ToShapeUnknownTypeThrowsInvalidOperationException()
        {
            var data = new ShapeData { ShapeType = "Куб" };
            Assert.Throws<InvalidOperationException>(() => data.ToShape());
        }

        #endregion
    }
}