namespace ModelTests
{
    /// <summary>
    /// Набор модульных тестов для класса Sphere
    /// </summary>
    public class SphereTests
    {
        [Description("Проверка инициализации имени шара")]
        [Category("Name Sphere")]
        [Test]
        public void ConstructorValidRadiusShouldInitializeCorrectly()
        {
            Sphere sphere = new Sphere(5.0);

            Assert.AreEqual("Шар", sphere.Name);
        }

        [Description("Проверка выброса исключения при некорректном радиусе")]
        [Category("Validation Sphere")]
        [TestCase(0)]
        [TestCase(-1.0)]
        [TestCase(double.NaN)]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity)]
        public void ConstructorInvalidRadiusShouldThrowArgumentException
            (double invalidRadius)
        {
            Assert.Throws<ArgumentException>(() => new Sphere(invalidRadius));
        }

        [Description("Проверка корректности расчёта объёма шара")]
        [TestCase(3.0, 113.09733552923255)]
        [TestCase(1.0, 4.1887902047863905)]
        public void CalculateVolume_ValidRadius_ReturnsCorrectVolume(
            double radius,
            double expectedVolume)
        {
            Sphere sphere = new Sphere(radius);

            double actualVolume = sphere.CalculateVolume();

            Assert.That( actualVolume, 
                Is.EqualTo(expectedVolume).Within(Settings.Tolerance));
        }

        [Description("Проверка формата строки, возвращаемой методом GetInfo")]
        [Category("GetInfo")]
        [Test]
        public void GetInfoReturnsCorrectFormat()
        {
            double radius = 5.0;
            Sphere sphere = new Sphere(radius);

            string actualInfo = sphere.GetInfo();

            double expectedVolume = (4.0 / 3.0) * Math.PI * 
                Math.Pow(radius, 3);
            string expectedInfo = $"Радиус = {radius:F2}, " +
                $"Объём = {expectedVolume:F2}";

            Assert.That(actualInfo, Is.EqualTo(expectedInfo));
        }

        [Description("Проверка формата строки, возвращаемой свойством Parameters")]
        [Category("Parameters")]
        [Test]
        public void GetInfoReturnsCorrectParameters()
        {
            double radius = 5.0;
            Sphere sphere = new Sphere(radius);

            string actualInfo = sphere.Parameters;

            double expectedVolume = (4.0 / 3.0) * Math.PI * 
                Math.Pow(radius, 3);
            string expectedInfo = $"Радиус = {radius:F2}";

            Assert.That(actualInfo, Is.EqualTo(expectedInfo));
        }

        [Description("Проверка корректности сохранения радиуса" +
            " в свойстве Radius")]
        [Category("Radius")]
        [TestCase(1.0)]
        [TestCase(5.5)]
        [TestCase(100.0)]
        [TestCase(0.001)]
        public void ConstructorValidRadiusShouldInitializeCorrectly
            (double radius)
        {
            Sphere sphere = new Sphere(radius);

            Assert.That(sphere.Radius, Is.EqualTo(radius));
        }

        [Description("Проверка, что при сериализации шара свойство" +
            " Height равно нулю")]
        [Test]
        public void FromShapeHeightShouldSerializeCorrectly()
        {
            var sphere = new Sphere(3);

            var data = ShapeData.FromShape(sphere);

            Assert.That(data.Height, Is.EqualTo(0));
        }

        [Description("Проверка, что при сериализации шара свойство" +
            " Width равно нулю")]
        [Test]
        public void FromShapeWidthShouldSerializeCorrectly()
        {
            var sphere = new Sphere(3);

            var data = ShapeData.FromShape(sphere);

            Assert.That(data.Width, Is.EqualTo(0));
        }
    }
}