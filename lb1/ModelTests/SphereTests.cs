namespace ModelTests
{
    /// <summary>
    /// Набор модульных тестов для класса Sphere
    /// </summary>
    public class SphereTests
    {
        [TestCase(5.0, 
            TestName = "Проверка инициализации свойства Name")]
        public void Constructor_ValidRadius_ShouldInitializeCorrectly
            (double radius)
        {
            var sphere = new Sphere(radius);

            Assert.That(sphere.Name, Is.EqualTo("Шар"));
        }

        [TestCase(0, 
            TestName = "Проверка валидации: радиус = 0")]
        [TestCase(-1.0, 
            TestName = "Проверка валидации: отрицательный радиус")]
        [TestCase(double.NaN, 
            TestName = "Проверка валидации: радиус = NaN")]
        [TestCase(double.PositiveInfinity, 
            TestName = "Проверка валидации: радиус = +∞")]
        [TestCase(double.NegativeInfinity, 
            TestName = "Проверка валидации: радиус = -∞")]
        public void ConstructorInvalidRadiusShouldThrowArgumentException
            (double invalidRadius)
        {
            Assert.Throws<ArgumentException>(() => 
            new Sphere(invalidRadius));
        }

        [TestCase(3.0, 113.09733552923255, 
            TestName = "Проверка объёма: r=3")]
        [TestCase(1.0, 4.1887902047863905, 
            TestName = "Проверка объёма: r=1")]
        public void CalculateVolume_ValidRadius_ReturnsCorrectVolume(
            double radius,
            double expectedVolume)
        {
            Sphere sphere = new Sphere(radius);

            double actualVolume = sphere.CalculateVolume();

            Assert.That( actualVolume, 
                Is.EqualTo(expectedVolume).Within(Settings.Tolerance));
        }

        [TestCase(5.0, 
            TestName = "Проверка формата строки GetInfo")]
        public void GetInfo_ValidRadius_ShouldReturnCorrectFormat
            (double radius)
        {
            var sphere = new Sphere(radius);
            var expectedVolume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
            var expectedInfo = $"Радиус = {radius:F2}, " +
                $"Объём = {expectedVolume:F2}";

            var actualInfo = sphere.GetInfo();

            Assert.That(actualInfo, Is.EqualTo(expectedInfo));
        }

        [TestCase(5.0, 
            TestName = "Проверка формата строки Parameters")]
        public void Parameters_ValidRadius_ShouldReturnCorrectFormat
            (double radius)
        {
            var sphere = new Sphere(radius);
            var expectedParameters = $"Радиус = {radius:F2}";

            var actualParameters = sphere.Parameters;

            Assert.That(actualParameters, Is.EqualTo(expectedParameters));
        }

        [TestCase(1.0, 
            TestName = "Проверка сохранения радиуса: r=1")]
        [TestCase(5.5, 
            TestName = "Проверка сохранения радиуса: r=5.5")]
        [TestCase(100.0, 
            TestName = "Проверка сохранения радиуса: r=100")]
        [TestCase(0.001, 
            TestName = "Проверка сохранения радиуса: r=0.001")]
        public void ConstructorValidRadiusShouldInitializeCorrectly
            (double radius)
        {
            Sphere sphere = new Sphere(radius);

            Assert.That(sphere.Radius, Is.EqualTo(radius));
        }

        [TestCase(3.0, 
            TestName = "Проверка сериализации Height (равен 0)")]
        public void FromShape_Height_ShouldSerializeCorrectly(double radius)
        {
            var sphere = new Sphere(radius);

            var data = ShapeData.FromShape(sphere);

            Assert.That(data.Height, Is.EqualTo(0));
        }

        [TestCase(3.0, 
            TestName = "Проверка сериализации Width (равен 0)")]
        public void FromShape_Width_ShouldSerializeCorrectly(double radius)
        {
            var sphere = new Sphere(radius);

            var data = ShapeData.FromShape(sphere);

            Assert.That(data.Width, Is.EqualTo(0));
        }
    }
}