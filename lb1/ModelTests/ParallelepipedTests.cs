using System.Xml.Linq;
using NUnit.Framework;

namespace ModelTests
{
    /// <summary>
    /// Набор модульных тестов для класса Parallelepiped
    /// </summary>
    public class ParallelepipedTests
    {
        [TestCase(2.0, 3.0, 4.0, 
            TestName = "Проверка инициализации свойств параллелепипеда")]
        public void Constructor_ValidParameters_ShouldInitializeCorrectly(
            double length, double width, double height)
        {
            var parallelepiped = new Parallelepiped(length, width, height);

            Assert.That(parallelepiped, Is.Not.Null);
            Assert.That(parallelepiped.Name, Is.EqualTo("Параллелепипед"));
            Assert.That(parallelepiped.Length, Is.EqualTo(length));
            Assert.That(parallelepiped.Width, Is.EqualTo(width));
            Assert.That(parallelepiped.Height, Is.EqualTo(height));
        }

        [TestCase(0, 3, 4, 
            TestName = "Проверка валидации: длина = 0")]
        [TestCase(2, -1, 4, 
            TestName = "Проверка валидации: отрицательная ширина")]
        [TestCase(2, 3, double.NaN, 
            TestName = "Проверка валидации: высота = NaN")]
        [TestCase(double.PositiveInfinity, 3, 4, 
            TestName = "Проверка валидации: длина = бесконечность")]
        public void ConstructorInvalidParametersShouldThrowArgumentException(
            double length, double width, double height)
        {
            Assert.Throws<ArgumentException>(() => 
            new Parallelepiped(length, width, height));
        }

        [TestCase(2.5, 3.5, 4.5, 
            TestName = "Проверка формата строки Parameters")]
        public void Parameters_ShouldReturnCorrectFormat(
            double length, double width, double height)
        {
            var parallelepiped = new Parallelepiped(length, width, height);

            string expected = $"Длина = {length:F2}\n" +
                $"Ширина = {width:F2}\nВысота = {height:F2}";

            string actual = parallelepiped.Parameters;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(2.0, 3.0, 4.0, 
            TestName = "Проверка свойства Radius (возвращает 0)")]
        public void Radius_ShouldReturnZero(
            double length, double width, double height)
        {
            var parallelepiped = new Parallelepiped(length, width, height);

            Assert.That(parallelepiped.Radius, Is.EqualTo(0));
        }

        [TestCase(2.0, 3.0, 4.0, 24.0, 
            TestName = "Проверка корректности расчёта объёма: 2×3×4=24")]
        [TestCase(1.0, 1.0, 1.0, 1.0, 
            TestName = "Проверка корректности расчёта объёма: 1×1×1=1")]
        [TestCase(5.5, 2.0, 3.0, 33.0, 
            TestName = "Проверка корректности расчёта объёма: 5.5×2×3=33")]
        public void CalculateVolumeValidParametersShouldReturnCorrectVolume(
            double length, double width, 
            double height, double expectedVolume)
        {
            var parallelepiped = new Parallelepiped(length, width, height);

            double actualVolume = parallelepiped.CalculateVolume();

            Assert.That(actualVolume, Is.EqualTo(expectedVolume).
                Within(Settings.Tolerance));
        }

        [TestCase(2.0, 3.0, 4.0, 
            TestName = "Проверка формата строки GetInfo")]
        public void GetInfo_ShouldReturnCorrectFormat(
            double length, double width, double height)
        {
            var parallelepiped = new Parallelepiped(length, width, height);
            double volume = parallelepiped.CalculateVolume();

            string expected = $"Длина = {length:F2}, Ширина = {width:F2}, " +
                $"Высота = {height:F2}, Объём = {volume:F2}";

            string actualInfo = parallelepiped.GetInfo();

            Assert.That(actualInfo, Is.EqualTo(expected));
        }
    }
}