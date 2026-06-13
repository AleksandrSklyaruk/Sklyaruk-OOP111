namespace Model.Tests
{
    /// <summary>
    /// Набор модульных тестов для класса Parallelepiped.
    /// Обеспечивает 100% покрытие кода (строк и ветвей).
    /// </summary>
    public class ParallelepipedTests
    {
        // Допустимая погрешность для чисел с плавающей точкой
        private const double Tolerance = 1e-6;

        [Test]
        public void Constructor_ValidParameters_ShouldInitializeCorrectly()
        {
            // Arrange
            double length = 2.0;
            double width = 3.0;
            double height = 4.0;

            // Act
            var parallelepiped = new Parallelepiped(length, width, height);

            // Assert
            Assert.That(parallelepiped, Is.Not.Null);
            Assert.That(parallelepiped.Name, Is.EqualTo("Параллелепипед"));
            Assert.That(parallelepiped.Length, Is.EqualTo(length));
            Assert.That(parallelepiped.Width, Is.EqualTo(width));
            Assert.That(parallelepiped.Height, Is.EqualTo(height));
        }

        /// <summary>
        /// Проверка валидации данных (наследуется от ShapeBase).
        /// Должно выбрасываться ArgumentException для некорректных значений.
        /// </summary>
        [TestCase(0, 3, 4)]
        [TestCase(2, -1, 4)]
        [TestCase(2, 3, double.NaN)]
        [TestCase(double.PositiveInfinity, 3, 4)]
        public void Constructor_InvalidParameters_ShouldThrowArgumentException(
            double length, double width, double height)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Parallelepiped(length, width, height));
        }

        [Test]
        public void Parameters_ShouldReturnCorrectFormat()
        {
            // Arrange
            double length = 2.5;
            double width = 3.5;
            double height = 4.5;
            var parallelepiped = new Parallelepiped(length, width, height);

            string expected = $"Длина = {length:F2}\n" +
                              $"Ширина = {width:F2}\n" +
                              $"Высота = {height:F2}";

            // Act
            string actual = parallelepiped.Parameters;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// ВАЖНО: Этот тест покрывает виртуальное свойство Radius из базового класса ShapeBase!
        /// Так как параллелепипед не переопределяет Radius, вызывается базовый геттер (=> 0).
        /// </summary>
        [Test]
        public void Radius_ShouldReturnZero()
        {
            // Arrange
            var parallelepiped = new Parallelepiped(2.0, 3.0, 4.0);

            // Act & Assert
            Assert.That(parallelepiped.Radius, Is.EqualTo(0));
        }

        /// <summary>
        /// Расчёт объёма по формуле V = a * b * c.
        /// Идеальный кандидат для TestCase с одним Assert.
        /// </summary>
        [TestCase(2.0, 3.0, 4.0, 24.0)]
        [TestCase(1.0, 1.0, 1.0, 1.0)]
        [TestCase(5.5, 2.0, 3.0, 33.0)]
        public void CalculateVolume_ValidParameters_ShouldReturnCorrectVolume(
            double length, double width, double height, double expectedVolume)
        {
            // Arrange
            var parallelepiped = new Parallelepiped(length, width, height);

            // Act
            double actualVolume = parallelepiped.CalculateVolume();

            // Assert
            Assert.That(actualVolume, Is.EqualTo(expectedVolume).Within(Tolerance));
        }

        [Test]
        public void GetInfo_ShouldReturnCorrectFormat()
        {
            // Arrange
            double length = 2.0;
            double width = 3.0;
            double height = 4.0;
            var parallelepiped = new Parallelepiped(length, width, height);
            double volume = parallelepiped.CalculateVolume();

            // Ожидаемый формат строки (с запятыми и пробелами, как в коде)
            string expected = $"Длина = {length:F2}, " +
                              $"Ширина = {width:F2}, " +
                              $"Высота = {height:F2}, " +
                              $"Объём = {volume:F2}";

            // Act
            string actualInfo = parallelepiped.GetInfo();

            // Assert
            Assert.That(actualInfo, Is.EqualTo(expected));
        }
    }
}