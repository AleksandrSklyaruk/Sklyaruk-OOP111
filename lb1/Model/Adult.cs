using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model 
{
    //TODO: XML +
    /// <summary>
    /// Информация о человеке
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Серия паспорта
        /// </summary>
        private int _passportSeria;

        /// <summary>
        /// Номер паспорта
        /// </summary>
        private int _passportNumber;

        /// <summary>
        /// Семейное положение
        /// </summary>
        private MaritalStatus _maritalStatus;
        
        /// <summary>
        /// Место работы
        /// </summary>
        private string _workPlace;

        /// <summary>
        /// Партнёр
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Минимальная серия паспорта
        /// </summary>
        public const int MinPassportSeria = 1000;

        /// <summary>
        /// Максимальная серия паспорта
        /// </summary>
        public const int MaxPassportSeria = 9999;
        
        /// <summary>
        /// Минимальный номер паспорта
        /// </summary>
        public const int MinPassportNumber = 100000;

        /// <summary>
        /// Максимальный номер паспорта
        /// </summary>
        public const int MaxPassportNumber = 999999;

        /// <summary>
        /// Минимальный возраст взрослого человека
        /// </summary>
        public const int MinAgeAdult = 18;

        /// <summary>
        /// Максимальный возраст взрослого человека
        /// </summary>
        public const int MaxAgeAdult = 123;

        /// <summary>
        /// Конструктор класса с параметрами
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="passportSeria">Серия паспорта</param>
        /// <param name="passportNumber">Номер паспорта</param>
        /// <param name="maritalStatus">Семейное положение</param>
        /// <param name="workPlace">Место работы</param>
        /// <param name="partner">Партнёр</param>
        public Adult(string name, string surname, int age, Gender gender,
            int passportSeria, int passportNumber, MaritalStatus maritalStatus,
            string workPlace, Adult partner = null) :
            base(name, surname, age, gender)
        {
            PassportSeria = passportSeria;
            PassportNumber = passportNumber;
            MaritalStatus = maritalStatus;
            WorkPlace = workPlace;
            Partner = partner;
        }

        //TODO: remove  +

        /// <summary>
        /// Свойство позволяет получить или установить серию паспорта
        /// </summary>
        public int PassportSeria
        {
            get { return _passportSeria; }
            set
            {
                _passportSeria = ValidatePassportField
                (value, MinPassportSeria, MaxPassportSeria, "Серия паспорта");
            }
        }

        /// <summary>
        /// Свойство позволяет получить или установить номер паспорта
        /// </summary>
        public int PassportNumber
        {
            get { return _passportNumber; }
            set
            {
                _passportNumber = ValidatePassportField
                (value, MinPassportNumber, MaxPassportNumber, "Номер паспорта");
            }
        }

        //TODO: autoproperty +
        /// <summary>
        /// Свойство позволяет получить или установить семейное положение 
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        //TODO: autoproperty +
        /// <summary>
        /// Свойство позволяет получить или установить партнёра 
        /// </summary>
        public Adult Partner { get; set; }

        //TODO: autoproperty +
        /// <summary>
        /// Ввод места работы
        /// </summary>
        public string WorkPlace { get; set; }

        /// <summary>
        /// Метод возвращает строковое описание взрослого человека
        /// </summary>
        public override string GetInfo()
        {
            string baseInfo = $" {Surname} {Name}\n Возраст: {Age}\n" +
                $" Пол: {(Gender == Gender.Male ? "мужской" : "женский")}\n";
            string passportInfo = $" Паспорт: серия {PassportSeria} " +
                $"номер {PassportNumber}\n";
            string maritalInfo;
            if (MaritalStatus == MaritalStatus.Married && Partner != null)
            {
                maritalInfo = $" Состоит в браке с: " +
                    $"{Partner.Surname} {Partner.Name}\n";
            }
            else
            {
                maritalInfo = " Не состоит в браке\n";
            }
            string workInfo = string.IsNullOrWhiteSpace(WorkPlace)
                ? " Место работы: безработный(ая)"
                : $" Место работы: {WorkPlace}";
            return $"{baseInfo}{passportInfo}{maritalInfo}{workInfo}";
        }

        /// <summary>
        /// Проверка человека на взрослость
        /// </summary>
        /// <param name="age">Возраст человека</param>
        /// <exception cref="Exception">Возраст должен быть 
        /// в определнном диапозоне</exception>
        protected override void CheckAge(int age)
        {
            if ((age < MinAgeAdult) || (age > MaxAgeAdult))
            {
                throw new Exception($"Возраст взрослого человека " +
                    $"от {MinAgeAdult} до {MaxAgeAdult}");
            }
        }

        /// <summary>
        /// Специальны метод для взрослого человека
        /// </summary>
        /// <returns></returns>
        public string GetCar()
        {
            string[] cars = { "Lada", "Moskvich", "UAZ", "Volga", "Aurus" };
            var random = new Random();
            string car = cars[random.Next(cars.Length)];
            return $"Это взрослый человек, и он ездит на {car}";
        }

        /// <summary>
        /// Проверяет и устанавливает значение паспортного поля (серия или номер)
        /// </summary>
        /// <param name="value">Значение для проверки</param>
        /// <param name="min">Минимальное допустимое значение</param>
        /// <param name="max">Максимальное допустимое значение</param>
        /// <param name="fieldName">Название поля</param>
        /// <returns>Корректное значение</returns>
        /// <exception cref="Exception"></exception>
        private static int ValidatePassportField(int value, int min, int max, string fieldName)
        {
            if (string.IsNullOrEmpty(Convert.ToString(value)))
                throw new Exception($"Введите {fieldName}!");

            if (value < min || value > max)
                throw new Exception($"{fieldName} должен быть в диапазоне от {min} до {max}");

            return value;
        }
    }

}
