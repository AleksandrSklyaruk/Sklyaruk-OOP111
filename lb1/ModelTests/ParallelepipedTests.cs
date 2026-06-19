namespace ModelTests
{
    /// <summary>
    /// Набор модульных тестов для класса Parallelepiped
    /// </summary>
    public class ParallelepipedTests
    {
        /// <summary>
        /// Проверяет, что конструктор корректно инициализирует 
        /// все свойства параллелепипеда
        /// </summary>
        [Test]
        public void ConstructorValidParametersShouldInitializeCorrectly()
        {
            double length = 2.0;
            double width = 3.0;
            double height = 4.0;

            var parallelepiped = new Parallelepiped(length, width, height);

            Assert.That(parallelepiped, Is.Not.Null);
            Assert.That(parallelepiped.Name, Is.EqualTo("Параллелепипед"));
            Assert.That(parallelepiped.Length, Is.EqualTo(length));
            Assert.That(parallelepiped.Width, Is.EqualTo(width));
            Assert.That(parallelepiped.Height, Is.EqualTo(height));
        }

        /// <summary>
        /// Проверяет, что конструктор выбрасывает ArgumentException
        /// при передаче некорректных параметров
        /// </summary>
        /// <param name="length">Длина</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        [TestCase(0, 3, 4)]
        [TestCase(2, -1, 4)]
        [TestCase(2, 3, double.NaN)]
        [TestCase(double.PositiveInfinity, 3, 4)]
        public void ConstructorInvalidParametersShouldThrowArgumentException(
            double length, double width, double height)
        {
            Assert.Throws<ArgumentException>(() => 
            new Parallelepiped(length, width, height));
        }

        /// <summary>
        /// Проверяет, что свойство Parallelepiped.Parameters 
        /// возвращает строку в корректном формате
        /// </summary>
        [Test]
        public void ParametersShouldReturnCorrectFormat()
        {
            double length = 2.5;
            double width = 3.5;
            double height = 4.5;
            var parallelepiped = new Parallelepiped(length, width, height);

            string expected = $"Длина = {length:F2}\n" +
                $"Ширина = {width:F2}\nВысота = {height:F2}";

            string actual = parallelepiped.Parameters;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Проверяет, что свойство Parallelepiped.Radius возвращает ноль,
        /// так как параллелепипед не переопределяет это свойство
        /// </summary>
        [Test]
        public void RadiusShouldReturnZero()
        {
            var parallelepiped = new Parallelepiped(2.0, 3.0, 4.0);

            Assert.That(parallelepiped.Radius, Is.EqualTo(0));
        }

        /// <summary>
        /// Проверяет корректность расчёта объёма параллелепипеда 
        /// по формуле V = a × b × c
        /// </summary>
        /// <param name="length">Длина</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        /// <param name="expectedVolume">Ожидаемый объём</param>
        [TestCase(2.0, 3.0, 4.0, 24.0)]
        [TestCase(1.0, 1.0, 1.0, 1.0)]
        [TestCase(5.5, 2.0, 3.0, 33.0)]
        public void CalculateVolumeValidParametersShouldReturnCorrectVolume(
            double length, double width, 
            double height, double expectedVolume)
        {
            var parallelepiped = new Parallelepiped(length, width, height);

            double actualVolume = parallelepiped.CalculateVolume();

            Assert.That(actualVolume, Is.EqualTo(expectedVolume).
                Within(Settings.Tolerance));
        }

        /// <summary>
        /// Проверяет, что метод Parallelepiped.GetInfo 
        /// возвращает строку в корректном формате.
        /// </summary>
        [Test]
        public void GetInfoShouldReturnCorrectFormat()
        {
            double length = 2.0;
            double width = 3.0;
            double height = 4.0;
            var parallelepiped = new Parallelepiped(length, width, height);
            double volume = parallelepiped.CalculateVolume();

            string expected = $"Длина = {length:F2}, Ширина = {width:F2}, " +
                $"Высота = {height:F2}, Объём = {volume:F2}";

            string actualInfo = parallelepiped.GetInfo();

            Assert.That(actualInfo, Is.EqualTo(expected));
        }
    }
}