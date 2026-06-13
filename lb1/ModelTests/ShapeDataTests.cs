using System;
using NUnit.Framework;
using Model;

namespace Model.Tests
{
    public class ShapeDataTests
    {
        #region Constructor and Properties

        [Test]
        public void Constructor_ShouldCreateInstance()
        {
            Assert.That(new ShapeData(), Is.Not.Null);
        }

        [TestCase("Шар")]
        [TestCase("Пирамида")]
        [TestCase("Параллелепипед")]
        public void ShapeType_ShouldSetAndGetValue(string type)
        {
            var data = new ShapeData { ShapeType = type };
            Assert.That(data.ShapeType, Is.EqualTo(type));
        }

        [TestCase(5.5)]
        [TestCase(0.0)]
        public void Length_ShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Length = value };
            Assert.That(data.Length, Is.EqualTo(value));
        }

        [TestCase(3.14)]
        public void Width_ShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Width = value };

            Assert.That(data.Width, Is.EqualTo(value));
        }

        [TestCase(10.0)]
        public void Height_ShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Height = value };
            Assert.That(data.Height, Is.EqualTo(value));
        }

        [TestCase(7.7)]
        public void Radius_ShouldSetAndGetValue(double value)
        {
            var data = new ShapeData { Radius = value };
            Assert.That(data.Radius, Is.EqualTo(value));
        }

        #endregion

        #region ShouldSerialize Methods

        [TestCase("Пирамида", true)]
        [TestCase("Параллелепипед", true)]
        [TestCase("Шар", false)]
        [TestCase("Куб", false)]
        public void ShouldSerializeLength_ReturnsCorrectValue(string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };
            Assert.That(data.ShouldSerializeLength(), Is.EqualTo(expected));
        }

        [TestCase("Пирамида", true)]
        [TestCase("Параллелепипед", true)]
        [TestCase("Шар", false)]
        [TestCase("Куб", false)]
        public void ShouldSerializeWidth_ReturnsCorrectValue(string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };
            Assert.That(data.ShouldSerializeWidth(), Is.EqualTo(expected));
        }

        [TestCase("Пирамида", true)]
        [TestCase("Параллелепипед", true)]
        [TestCase("Шар", false)]
        [TestCase("Куб", false)]
        public void ShouldSerializeHeight_ReturnsCorrectValue(string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };
            Assert.That(data.ShouldSerializeHeight(), Is.EqualTo(expected));
        }

        [TestCase("Шар", true)]
        [TestCase("Пирамида", false)]
        [TestCase("Параллелепипед", false)]
        [TestCase("Куб", false)]
        public void ShouldSerializeRadius_ReturnsCorrectValue(string shapeType, bool expected)
        {
            var data = new ShapeData { ShapeType = shapeType };
            Assert.That(data.ShouldSerializeRadius(), Is.EqualTo(expected));
        }

        #endregion

        #region FromShape Tests

        [Test]
        public void FromShape_NullShape_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ShapeData.FromShape(null));
        }

        // --- Sphere ---
        [Test]
        public void FromShape_Sphere_SetsCorrectShapeType()
        {
            var data = ShapeData.FromShape(new Sphere(5.0));
            Assert.That(data.ShapeType, Is.EqualTo("Шар"));
        }

        [Test]
        public void FromShape_Sphere_SetsCorrectRadius()
        {
            var data = ShapeData.FromShape(new Sphere(5.0));
            Assert.That(data.Radius, Is.EqualTo(5.0));
        }

        // --- Pyramid ---
        [Test]
        public void FromShape_Pyramid_SetsCorrectShapeType()
        {
            var data = ShapeData.FromShape(new Pyramid(3.0, 4.0, 5.0));
            Assert.That(data.ShapeType, Is.EqualTo("Пирамида"));
        }

        [Test]
        public void FromShape_Pyramid_SetsCorrectLength()
        {
            var data = ShapeData.FromShape(new Pyramid(3.0, 4.0, 5.0));
            Assert.That(data.Length, Is.EqualTo(3.0));
        }

        // --- Parallelepiped ---
        [Test]
        public void FromShape_Parallelepiped_SetsCorrectShapeType()
        {
            var data = ShapeData.FromShape(new Parallelepiped(2.0, 3.0, 4.0));
            Assert.That(data.ShapeType, Is.EqualTo("Параллелепипед"));
        }

        [Test]
        public void FromShape_Parallelepiped_SetsCorrectHeight()
        {
            var data = ShapeData.FromShape(new Parallelepiped(2.0, 3.0, 4.0));
            Assert.That(data.Height, Is.EqualTo(4.0));
        }

        // --- Покрытие базовых свойств ShapeBase (где они не переопределены) ---

        [Test]
        public void FromShape_Pyramid_RadiusIsZero() // Покрывает ShapeBase.get_Radius
        {
            var data = ShapeData.FromShape(new Pyramid(3.0, 4.0, 5.0));
            Assert.That(data.Radius, Is.EqualTo(0));
        }

        [Test]
        public void FromShape_Sphere_LengthIsZero() // Покрывает ShapeBase.get_Length
        {
            var data = ShapeData.FromShape(new Sphere(5.0));
            Assert.That(data.Length, Is.EqualTo(0));
        }

        #endregion

        #region ToShape Tests

        [Test]
        public void ToShape_SphereData_ReturnsSphereInstance()
        {
            var data = new ShapeData { ShapeType = "Шар", Radius = 5.0 };
            Assert.That(data.ToShape(), Is.InstanceOf<Sphere>());
        }

        [Test]
        public void ToShape_PyramidData_ReturnsPyramidInstance()
        {
            var data = new ShapeData { ShapeType = "Пирамида", Length = 3, Width = 4, Height = 5 };
            Assert.That(data.ToShape(), Is.InstanceOf<Pyramid>());
        }

        [Test]
        public void ToShape_ParallelepipedData_ReturnsParallelepipedInstance()
        {
            var data = new ShapeData { ShapeType = "Параллелепипед", Length = 2, Width = 3, Height = 4 };
            Assert.That(data.ToShape(), Is.InstanceOf<Parallelepiped>());
        }

        [Test]
        public void ToShape_SphereData_SetsCorrectRadius()
        {
            var shape = (Sphere)new ShapeData { ShapeType = "Шар", Radius = 5.0 }.ToShape();
            Assert.That(shape.Radius, Is.EqualTo(5.0));
        }

        [Test]
        public void ToShape_PyramidData_SetsCorrectLength()
        {
            var shape = (Pyramid)new ShapeData { ShapeType = "Пирамида", Length = 3, Width = 4, Height = 5 }.ToShape();
            Assert.That(shape.Length, Is.EqualTo(3.0));
        }

        [Test]
        public void ToShape_UnknownType_ThrowsInvalidOperationException()
        {
            var data = new ShapeData { ShapeType = "Куб" };
            Assert.Throws<InvalidOperationException>(() => data.ToShape());
        }

        #endregion
    }
}