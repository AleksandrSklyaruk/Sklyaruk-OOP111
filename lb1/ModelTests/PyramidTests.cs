namespace ModelTests
{
    public class PyramidTests
    {

        /// <summary>
        /// Проверка инициализации свойства Name (один Assert, обычный Test).
        /// </summary>
        [Test]
        public void Constructor_ValidParameters_ShouldSetName()
        {
            var pyramid = new Pyramid(3.0, 4.0, 5.0);

            Assert.That(pyramid.Name, Is.EqualTo("Пирамида"));
        }

        /// <summary>
        /// Проверка сохранения Length через TestCase (один Assert, много данных).
        /// </summary>
        [TestCase(3.0, 4.0, 5.0, 3.0)]
        [TestCase(1.5, 2.5, 3.5, 1.5)]
        public void Constructor_ValidParameters_ShouldAssignLength(
            double length, double width, double height, double expectedLength)
        {
            var pyramid = new Pyramid(length, width, height);

            Assert.That(pyramid.Length, Is.EqualTo(expectedLength));
        }

        /// <summary>
        /// Проверка валидации через TestCase (один Assert на выброс исключения).
        /// </summary>
        [TestCase(0, 4, 5)]
        [TestCase(3, -1, 5)]
        [TestCase(3, 4, double.NaN)]
        [TestCase(double.PositiveInfinity, 4, 5)]
        public void Constructor_InvalidParameters_ShouldThrowArgumentException(
            double length, double width, double height)
        {
            Assert.Throws<ArgumentException>(() => new Pyramid(length, width, height));
        }

        /// <summary>
        /// Расчёт объёма по формуле V = 1/3 * a * b * h.
        /// Идеальный кандидат для TestCase с одним Assert.
        /// </summary>
        [TestCase(3.0, 4.0, 5.0, 20.0)]             // 1/3 * 3 * 4 * 5 = 20
        [TestCase(6.0, 6.0, 6.0, 72.0)]             // 1/3 * 6 * 6 * 6 = 72
        [TestCase(1.0, 1.0, 1.0, 0.333333333333333)] // 1/3
        public void CalculateVolume_ValidParameters_ShouldReturnCorrectVolume(
            double length, double width, double height, double expectedVolume)
        {
            var pyramid = new Pyramid(length, width, height);

            Assert.That(pyramid.CalculateVolume(), Is.EqualTo(expectedVolume).Within(Settings.Tolerance));
        }

        /// <summary>
        /// Проверка базового свойства Radius (возвращает 0).
        /// </summary>
        [Test]
        public void Radius_ShouldReturnZero()
        {
            var pyramid = new Pyramid(3.0, 4.0, 5.0);

            Assert.That(pyramid.Radius, Is.EqualTo(0));
        }

        /// <summary>
        /// Форматирование строки Parameters через TestCase.
        /// </summary>
        [TestCase(3.0, 4.0, 5.0)]
        [TestCase(1.5, 2.5, 3.5)]
        public void Parameters_ValidParameters_ShouldReturnCorrectFormat(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);
            string expected = $"Длина = {length:F2}\nШирина = {width:F2}\nВысота = {height:F2}";

            Assert.That(pyramid.Parameters, Is.EqualTo(expected));
        }

        /// <summary>
        /// Форматирование строки GetInfo через TestCase.
        /// </summary>
        [TestCase(3.0, 4.0, 5.0)]
        public void GetInfo_ValidParameters_ShouldReturnCorrectFormat(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);
            double volume = pyramid.CalculateVolume();

            // ВАЖНО: Здесь учтена специфическая форматировка из вашего Pyramid.cs 
            // (запятые в начале новых строк после \n)
            string expected = $"Длина = {length:F2}\n" +
                              $", Ширина = {width:F2}\n" +
                              $", Высота = {height:F2}\n" +
                              $", Объём = {volume:F2}";

            Assert.That(pyramid.GetInfo(), Is.EqualTo(expected));
        }

        [Test]
        public void FromShape_RadiusShouldSerializeCorrectly()
        {
            // Arrange
            var pyramid = new Pyramid(3, 3, 3);

            // Act
            var data = ShapeData.FromShape(pyramid);

            // Assert
            Assert.That(data.Radius, Is.EqualTo(0));
        }
    }
}
