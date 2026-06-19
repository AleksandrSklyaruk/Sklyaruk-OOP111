namespace ModelTests
{
    /// <summary>
    /// Набор модульных тестов для класса Pyramid
    /// </summary>
    public class PyramidTests
    {

        /// <summary>
        /// Проверка инициализации свойства Name
        /// </summary>
        [Test]
        public void ConstructorValidParametersShouldSetName()
        {
            var pyramid = new Pyramid(3.0, 4.0, 5.0);

            Assert.That(pyramid.Name, Is.EqualTo("Пирамида"));
        }

        /// <summary>
        /// Проверяет, что конструктор корректно 
        /// сохраняет значение длины основания
        /// </summary>
        /// <param name="length">Длина основания</param>
        /// <param name="width">Ширина основания</param>
        /// <param name="height">Высота пирамиды</param>
        /// <param name="expectedLength">Ожидаемое значение длины</param>
        [TestCase(3.0, 4.0, 5.0, 3.0)]
        [TestCase(1.5, 2.5, 3.5, 1.5)]
        public void ConstructorValidParametersShouldAssignLength(
            double length, double width, 
            double height, double expectedLength)
        {
            var pyramid = new Pyramid(length, width, height);

            Assert.That(pyramid.Length, Is.EqualTo(expectedLength));
        }

        /// <summary>
        /// Проверяет, что конструктор выбрасывает ArgumentException
        /// при передаче некорректных параметров
        /// </summary>
        /// <param name="length">Длина основания</param>
        /// <param name="width">Ширина основания</param>
        /// <param name="height">Высота пирамиды</param>
        [TestCase(0, 4, 5)]
        [TestCase(3, -1, 5)]
        [TestCase(3, 4, double.NaN)]
        [TestCase(double.PositiveInfinity, 4, 5)]
        public void ConstructorInvalidParametersShouldThrowArgumentException(
            double length, double width, double height)
        {
            Assert.Throws<ArgumentException>(() => 
            new Pyramid(length, width, height));
        }

        /// <summary>
        /// Проверяет корректность расчёта объёма пирамиды по формуле 
        /// V = 1/3 × a × b × h
        /// </summary>
        /// <param name="length">Длина основания</param>
        /// <param name="width">Ширина основания</param>
        /// <param name="height">Высота пирамиды</param>
        /// <param name="expectedVolume">Ожидаемый объём</param>
        [TestCase(3.0, 4.0, 5.0, 20.0)]           
        [TestCase(6.0, 6.0, 6.0, 72.0)]             
        [TestCase(1.0, 1.0, 1.0, 0.333333333333333)] 
        public void CalculateVolumeValidParametersShouldReturnCorrectVolume(
            double length, double width, 
            double height, double expectedVolume)
        {
            var pyramid = new Pyramid(length, width, height);

            Assert.That(pyramid.CalculateVolume(), 
                Is.EqualTo(expectedVolume).Within(Settings.Tolerance));
        }

        /// <summary>
        /// Проверяет, что свойство Pyramid.Radius возвращает ноль,
        /// так как пирамида не переопределяет это свойство
        /// </summary>
        [Test]
        public void RadiusShouldReturnZero()
        {
            var pyramid = new Pyramid(3.0, 4.0, 5.0);

            Assert.That(pyramid.Radius, Is.EqualTo(0));
        }

        /// <summary>
        /// Проверяет, что свойство Pyramid.Parameters 
        /// возвращает строку в корректном формате
        /// </summary>
        /// <param name="length">Длина основания</param>
        /// <param name="width">Ширина основания</param>
        /// <param name="height">Высота пирамиды</param>
        [TestCase(3.0, 4.0, 5.0)]
        [TestCase(1.5, 2.5, 3.5)]
        public void ParametersValidParametersShouldReturnCorrectFormat(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);
            string expected = $"Длина = {length:F2}\n" +
                $"Ширина = {width:F2}\nВысота = {height:F2}";

            Assert.That(pyramid.Parameters, Is.EqualTo(expected));
        }

        /// <summary>
        /// Проверяет, что метод Pyramid.GetInfo 
        /// возвращает строку в корректном формате
        /// </summary>
        /// <param name="length">Длина основания</param>
        /// <param name="width">Ширина основания</param>
        /// <param name="height">Высота пирамиды</param>
        [TestCase(3.0, 4.0, 5.0)]
        public void GetInfoValidParametersShouldReturnCorrectFormat(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);
            double volume = pyramid.CalculateVolume();

            string expected = $"Длина = {length:F2}\n, " +
                $"Ширина = {width:F2}\n, Высота = {height:F2}\n" +
                $", Объём = {volume:F2}";

            Assert.That(pyramid.GetInfo(), Is.EqualTo(expected));
        }

        /// <summary>
        /// Проверяет, что при конвертации пирамиды в ShapeData
        /// свойство ShapeData.Radius равно нулю
        /// </summary>
        [Test]
        public void FromShapeRadiusShouldSerializeCorrectly()
        {
            var pyramid = new Pyramid(3, 3, 3);

            var data = ShapeData.FromShape(pyramid);

            Assert.That(data.Radius, Is.EqualTo(0));
        }
    }
}
