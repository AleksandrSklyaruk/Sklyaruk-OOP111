namespace ModelTests
{
    /// <summary>
    /// Набор модульных тестов для класса Pyramid
    /// </summary>
    public class PyramidTests
    {

        [TestCase(3.0, 4.0, 5.0, 
            TestName = "Проверка инициализации свойства Name")]
        public void Constructor_ValidParameters_ShouldSetName(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);

            Assert.That(pyramid.Name, Is.EqualTo("Пирамида"));
        }

        [TestCase(3.0, 4.0, 5.0, 3.0, 
            TestName = "Проверка сохранения Length")]
        [TestCase(1.5, 2.5, 3.5, 1.5, 
            TestName = "Проверка сохранения Length с дробными значениями")]
        public void ConstructorValidParametersShouldAssignLength(
            double length, double width, 
            double height, double expectedLength)
        {
            var pyramid = new Pyramid(length, width, height);

            Assert.That(pyramid.Length, Is.EqualTo(expectedLength));
        }

        [TestCase(0, 4, 5, 
            TestName = "Проверка валидации: длина = 0")]
        [TestCase(3, -1, 5, 
            TestName = "Проверка валидации: отрицательная ширина")]
        [TestCase(3, 4, double.NaN, 
            TestName = "Проверка валидации: высота = NaN")]
        [TestCase(double.PositiveInfinity, 4, 5, 
            TestName = "Проверка валидации: длина = бесконечность")]
        public void ConstructorInvalidParametersShouldThrowArgumentException(
            double length, double width, double height)
        {
            Assert.Throws<ArgumentException>(() => 
            new Pyramid(length, width, height));
        }

        [TestCase(3.0, 4.0, 5.0, 20.0, 
            TestName = "Проверка объёма: 3×4×5=20")]
        [TestCase(6.0, 6.0, 6.0, 72.0, 
            TestName = "Проверка объёма: 6×6×6=72")]
        [TestCase(1.0, 1.0, 1.0, 0.333333333333333, 
            TestName = "Проверка объёма: 1×1×1=1/3")]
        public void CalculateVolumeValidParametersShouldReturnCorrectVolume(
            double length, double width, 
            double height, double expectedVolume)
        {
            var pyramid = new Pyramid(length, width, height);

            Assert.That(pyramid.CalculateVolume(), 
                Is.EqualTo(expectedVolume).Within(Settings.Tolerance));
        }

        [TestCase(3.0, 4.0, 5.0, 
            TestName = "Проверка свойства Radius (возвращает 0)")]
        public void Radius_ShouldReturnZero(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);

            Assert.That(pyramid.Radius, Is.EqualTo(0));
        }

        [TestCase(3.0, 4.0, 5.0, 
            TestName = "Проверка формата Parameters")]
        [TestCase(1.5, 2.5, 3.5, 
            TestName = "Проверка формата Parameters с дробными значениями")]
        public void ParametersValidParametersShouldReturnCorrectFormat(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);
            string expected = $"Длина = {length:F2}\n" +
                $"Ширина = {width:F2}\nВысота = {height:F2}";

            Assert.That(pyramid.Parameters, Is.EqualTo(expected));
        }

        [TestCase(3.0, 4.0, 5.0, 
            TestName = "Проверка формата GetInfo")]
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

        [TestCase(3.0, 3.0, 3.0, 
            TestName = "Проверка сериализации Radius (равен 0)")]
        public void FromShape_RadiusShouldSerializeCorrectly(
            double length, double width, double height)
        {
            var pyramid = new Pyramid(length, width, height);

            var data = ShapeData.FromShape(pyramid);

            Assert.That(data.Radius, Is.EqualTo(0));
        }
    }
}
