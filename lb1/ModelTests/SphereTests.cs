namespace ModelTests
{

    public class SphereTests
    {
        [Category("Name Sphere")]
        // Обычный тест (аналог [Fact] в xUnit)
        [Test]
        public void Constructor_ValidRadius_ShouldInitializeCorrectly()
        {
            Sphere sphere = new Sphere(5.0);
            Assert.AreEqual("Шар", sphere.Name);
        }

        [Category("Validation Sphere")]
        // Параметризованный тест (аналог [Theory] в xUnit)
        // Тест запустится 4 раза с разными значениями
        [TestCase(0)]
        [TestCase(-1.0)]
        [TestCase(double.NaN)]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity)]
        public void Constructor_InvalidRadius_ShouldThrowArgumentException(double invalidRadius)
        {
            Assert.Throws<ArgumentException>(() => new Sphere(invalidRadius));
        }

        // Arrange - input
        [TestCase(3.0, 113.09733552923255)]
        [TestCase(1.0, 4.1887902047863905)]
        public void CalculateVolume_ValidRadius_ReturnsCorrectVolume(
                    double radius,
                    double expectedVolume)
        {
            Sphere sphere = new Sphere(radius);
            double actualVolume = sphere.CalculateVolume();

            Assert.That(
                actualVolume,
                Is.EqualTo(expectedVolume).Within(Settings.Tolerance));
        }

        [Category("GetInfo")]
        [Test]
        public void GetInfoReturnsCorrectFormat()
        {
            // Arrange
            double radius = 5.0;
            Sphere sphere = new Sphere(radius);
            // Если у вас есть вспомогательный метод, можно использовать его:
            // Sphere sphere = CreateDefaultSphere();

            // Act
            string actualInfo = sphere.GetInfo();

            // Assert
            double expectedVolume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
            string expectedInfo = $"Радиус = {radius:F2}, " +
                $"Объём = {expectedVolume:F2}";

            Assert.That(actualInfo, Is.EqualTo(expectedInfo));
        }

        [Category("Radius Format")]
        [Test]
        public void GetInfoReturnsCorrectParameters()
        {
            // Arrange
            double radius = 5.0;
            Sphere sphere = new Sphere(radius);
            // Если у вас есть вспомогательный метод, можно использовать его:
            // Sphere sphere = CreateDefaultSphere();

            // Act
            string actualInfo = sphere.Parameters;

            // Assert
            double expectedVolume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
            string expectedInfo = $"Радиус = {radius:F2}";

            Assert.That(actualInfo, Is.EqualTo(expectedInfo));
        }

        [Category("Radius")]
        [TestCase(1.0)]
        [TestCase(5.5)]
        [TestCase(100.0)]
        [TestCase(0.001)]
        public void Constructor_ValidRadius_ShouldInitializeCorrectly(double radius)
        {
            // Act
            Sphere sphere = new Sphere(radius);

            // Assert
            Assert.That(sphere.Radius, Is.EqualTo(radius));
        }

        [Test]
        public void FromShape_Height_ShouldSerializeCorrectly()
        {
            // Arrange
            var sphere = new Sphere(3);

            // Act
            var data = ShapeData.FromShape(sphere);

            // Assert
            Assert.That(data.Height, Is.EqualTo(0));
        }

        [Test]
        public void FromShape_Width_ShouldSerializeCorrectly()
        {
            // Arrange
            var sphere = new Sphere(3);

            // Act
            var data = ShapeData.FromShape(sphere);

            // Assert
            Assert.That(data.Width, Is.EqualTo(0));
        }
    }
}