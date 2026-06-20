namespace ModelTests
{
    /// <summary>
    /// Набор модульных тестов для класса Pyramid
    /// </summary>
    public class PyramidTests
    {

        [Description("Проверка инициализации имени пирамиды")]
        [Test]
        public void ConstructorValidParametersShouldSetName()
        {
            var pyramid = new Pyramid(3.0, 4.0, 5.0);

            Assert.That(pyramid.Name, Is.EqualTo("Пирамида"));
        }

        [Description("Проверка сохранения длины " +
            "основания пирамиды")]
        [TestCase(3.0, 4.0, 5.0, 3.0)]
        [TestCase(1.5, 2.5, 3.5, 1.5)]
        public void ConstructorValidParametersShouldAssignLength(
            double length, double width, 
            double height, double expectedLength)
        {
            var pyramid = new Pyramid(length, width, height);

            Assert.That(pyramid.Length, Is.EqualTo(expectedLength));
        }

        [Description("Проверка выброса исключения при" +
            " некорректных параметрах пирамиды")]
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

        [Description("Проверка корректности расчёта " +
            "объёма пирамиды")]
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

        [Description("Проверка, что свойство Radius" +
            " пирамиды возвращает ноль")]
        [Test]
        public void RadiusShouldReturnZero()
        {
            var pyramid = new Pyramid(3.0, 4.0, 5.0);

            Assert.That(pyramid.Radius, Is.EqualTo(0));
        }

        [Description("Проверка формата строки, возвращаемой " +
            "свойством Parameters пирамиды")]
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

        [Description("Проверка формата строки, возвращаемой " +
            "методом GetInfo пирамиды")]
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

        [Description("Проверка, что при сериализации пирамиды" +
            " свойство Radius равно нулю")]
        [Test]
        public void FromShapeRadiusShouldSerializeCorrectly()
        {
            var pyramid = new Pyramid(3, 3, 3);

            var data = ShapeData.FromShape(pyramid);

            Assert.That(data.Radius, Is.EqualTo(0));
        }
    }
}
