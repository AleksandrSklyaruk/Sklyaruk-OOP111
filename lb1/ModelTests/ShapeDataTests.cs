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

        [TestCase(TestName = "Проверка создания экземпляра ShapeData")]
        public void Constructor_ShouldCreateInstance()
        {
            Assert.That(new ShapeData(), Is.Not.Null);
        }

        [TestCase("Шар", TestName = "Проверка установки и получения ShapeType: Шар")]
        [TestCase("Пирамида", TestName = "Проверка установки и получения ShapeType: Пирамида")]
        [TestCase("Параллелепипед", TestName = "Проверка установки и получения ShapeType: Параллелепипед")]
        public void ShapeTypeShouldSetAndGetValue(string type)
        {
            var data = new ShapeData { ShapeType = type };

            Assert.That(data.ShapeType, Is.EqualTo(type));
        }

        [TestCase(5.5, TestName = "Проверка установки и получения Length: 5.5")]
        [TestCase(0.0, TestName = "Проверка установки и получения Length: 0.0")]
        public void LengthShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Length = value };

            Assert.That(data.Length, Is.EqualTo(value));
        }

        [TestCase(3.14, TestName = "Проверка установки и получения Width: 3.14")]
        public void WidthShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Width = value };

            Assert.That(data.Width, Is.EqualTo(value));
        }

        [TestCase(10.0, TestName = "Проверка установки и получения Height: 10.0")]
        public void HeightShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Height = value };

            Assert.That(data.Height, Is.EqualTo(value));
        }

        [TestCase(7.7, TestName = "Проверка установки и получения Radius: 7.7")]
        public void RadiusShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Radius = value };

            Assert.That(data.Radius, Is.EqualTo(value));
        }

        #endregion

        #region ShouldSerialize Methods

        [TestCase("Пирамида", true, TestName = "ShouldSerializeLength: Пирамида = true")]
        [TestCase("Параллелепипед", true, TestName = "ShouldSerializeLength: Параллелепипед = true")]
        [TestCase("Шар", false, TestName = "ShouldSerializeLength: Шар = false")]
        [TestCase("Куб", false, TestName = "ShouldSerializeLength: Куб = false")]
        public void ShouldSerializeLengthReturnsCorrectValue
            (string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };

            Assert.That(data.ShouldSerializeLength(), 
                Is.EqualTo(expected));
        }

        [TestCase("Пирамида", true, TestName = "ShouldSerializeWidth: Пирамида = true")]
        [TestCase("Параллелепипед", true, TestName = "ShouldSerializeWidth: Параллелепипед = true")]
        [TestCase("Шар", false, TestName = "ShouldSerializeWidth: Шар = false")]
        [TestCase("Куб", false, TestName = "ShouldSerializeWidth: Куб = false")]
        public void ShouldSerializeWidthReturnsCorrectValue
            (string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };

            Assert.That(data.ShouldSerializeWidth(), 
                Is.EqualTo(expected));
        }

        [TestCase("Пирамида", true, TestName = "ShouldSerializeHeight: Пирамида = true")]
        [TestCase("Параллелепипед", true, TestName = "ShouldSerializeHeight: Параллелепипед = true")]
        [TestCase("Шар", false, TestName = "ShouldSerializeHeight: Шар = false")]
        [TestCase("Куб", false, TestName = "ShouldSerializeHeight: Куб = false")]
        public void ShouldSerializeHeightReturnsCorrectValue
            (string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };

            Assert.That(data.ShouldSerializeHeight(), 
                Is.EqualTo(expected));
        }

        [TestCase("Шар", true, TestName = "ShouldSerializeRadius: Шар = true")]
        [TestCase("Пирамида", false, TestName = "ShouldSerializeRadius: Пирамида = false")]
        [TestCase("Параллелепипед", false, TestName = "ShouldSerializeRadius: Параллелепипед = false")]
        [TestCase("Куб", false, TestName = "ShouldSerializeRadius: Куб = false")]
        public void ShouldSerializeRadiusReturnsCorrectValue
            (string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };

            Assert.That(data.ShouldSerializeRadius(), 
                Is.EqualTo(expected));
        }

        #endregion

        #region FromShape Tests

        [TestCase(TestName = "FromShape: null должен выбросить ArgumentNullException")]
        public void FromShape_NullShape_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ShapeData.FromShape(null));
        }

        [TestCase(5.0, TestName = "FromShape(Шар): установка ShapeType")]
        public void FromShape_Sphere_SetsCorrectShapeType(double radius)
        {
            var sphere = new Sphere(radius);

            var data = ShapeData.FromShape(sphere);

            Assert.That(data.ShapeType, Is.EqualTo("Шар"));
        }

        [TestCase(5.0, TestName = "FromShape(Шар): установка Radius")]
        public void FromShape_Sphere_SetsCorrectRadius(double radius)
        {
            var sphere = new Sphere(radius);

            var data = ShapeData.FromShape(sphere);

            Assert.That(data.Radius, Is.EqualTo(radius));
        }

        [TestCase(3.0, 4.0, 5.0, TestName = "FromShape(Пирамида): установка ShapeType")]
        public void FromShape_Pyramid_SetsCorrectShapeType(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);

            var data = ShapeData.FromShape(pyramid);

            Assert.That(data.ShapeType, Is.EqualTo("Пирамида"));
        }

        [TestCase(3.0, 4.0, 5.0, TestName = "FromShape(Пирамида): установка Length")]
        public void FromShape_Pyramid_SetsCorrectLength(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);

            var data = ShapeData.FromShape(pyramid);

            Assert.That(data.Length, Is.EqualTo(length));
        }

        [TestCase(2.0, 3.0, 4.0, TestName = "FromShape(Параллелепипед): установка ShapeType")]
        public void FromShape_Parallelepiped_SetsCorrectShapeType(
            double length, double width, double height)
        {
            var parallelepiped = new Parallelepiped(length, width, height);

            var data = ShapeData.FromShape(parallelepiped);

            Assert.That(data.ShapeType, Is.EqualTo("Параллелепипед"));
        }

        [TestCase(2.0, 3.0, 4.0, TestName = "FromShape(Параллелепипед): установка Height")]
        public void FromShape_Parallelepiped_SetsCorrectHeight(
            double length, double width, double height)
        {
            var parallelepiped = new Parallelepiped(length, width, height);

            var data = ShapeData.FromShape(parallelepiped);

            Assert.That(data.Height, Is.EqualTo(height));
        }

        [TestCase(3.0, 4.0, 5.0, TestName = "FromShape(Пирамида): Radius = 0")]
        public void FromShape_Pyramid_RadiusIsZero(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);

            var data = ShapeData.FromShape(pyramid);

            Assert.That(data.Radius, Is.EqualTo(0));
        }

        [TestCase(5.0, TestName = "FromShape(Шар): Length = 0")]
        public void FromShape_Sphere_LengthIsZero(double radius)
        {
            var sphere = new Sphere(radius);

            var data = ShapeData.FromShape(sphere);

            Assert.That(data.Length, Is.EqualTo(0));
        }

        #endregion

        #region ToShape Tests

        [TestCase(5.0, TestName = "ToShape(Шар): возврат экземпляра Sphere")]
        public void ToShape_SphereData_ReturnsSphereInstance(double radius)
        {
            var data = new ShapeData { ShapeType = "Шар", Radius = radius };

            var shape = data.ToShape();

            Assert.That(shape, Is.InstanceOf<Sphere>());
        }

        [TestCase(3.0, 4.0, 5.0, TestName = "ToShape(Пирамида): возврат экземпляра Pyramid")]
        public void ToShape_PyramidData_ReturnsPyramidInstance(
            double length, double width, double height)
        {
            var data = new ShapeData
            {
                ShapeType = "Пирамида",
                Length = length,
                Width = width,
                Height = height
            };

            var shape = data.ToShape();

            Assert.That(shape, Is.InstanceOf<Pyramid>());
        }

        [TestCase(2.0, 3.0, 4.0, TestName = "ToShape(Параллелепипед): возврат экземпляра Parallelepiped")]
        public void ToShape_ParallelepipedData_ReturnsParallelepipedInstance(
            double length, double width, double height)
        {
            var data = new ShapeData
            {
                ShapeType = "Параллелепипед",
                Length = length,
                Width = width,
                Height = height
            };

            var shape = data.ToShape();

            Assert.That(shape, Is.InstanceOf<Parallelepiped>());
        }

        [TestCase(5.0, TestName = "ToShape(Шар): установка Radius")]
        public void ToShape_SphereData_SetsCorrectRadius(double radius)
        {
            var data = new ShapeData { ShapeType = "Шар", Radius = radius };

            var shape = (Sphere)data.ToShape();

            Assert.That(shape.Radius, Is.EqualTo(radius));
        }


        [TestCase(3.0, 4.0, 5.0, TestName = "ToShape(Пирамида): установка Length")]
        public void ToShape_PyramidData_SetsCorrectLength(
            double length, double width, double height)
        {
            var data = new ShapeData
            {
                ShapeType = "Пирамида",
                Length = length,
                Width = width,
                Height = height
            };

            var shape = (Pyramid)data.ToShape();

            Assert.That(shape.Length, Is.EqualTo(length));
        }

        [TestCase(TestName = "ToShape(неизвестный тип): выброс InvalidOperationException")]
        public void ToShape_UnknownType_ShouldThrowInvalidOperationException()
        {
            var data = new ShapeData { ShapeType = "Куб" };

            Assert.Throws<InvalidOperationException>(() => data.ToShape());
        }

        #endregion
    }
}