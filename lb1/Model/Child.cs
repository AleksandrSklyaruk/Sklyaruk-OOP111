using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс, описывающий ребенка
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Минимальный возраст ребенка
        /// </summary>
        public const int MinAgeChild = 0;

        /// <summary>
        /// Максимальный возвраст ребенка
        /// </summary>
        public const int MaxAgeChild = 17;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="gender">Пол</param>
        /// <param name="age">Возраст</param>
        /// <param name="father">Отец</param>
        /// <param name="mother">Мать</param>
        /// <param name="school">Школа/Дет.сад</param>
        public Child(string name, string surname,
            Gender gender, int age, Adult father, Adult mother,
            string school) : base(name, surname, age, gender)
        {
            Father = father;
            Mother = mother;
            School = school;
        }

        /// <summary>
        /// Отец ребенка
        /// </summary>
        public Adult Father { get; set; }

        /// <summary>
        /// Мама ребенка
        /// </summary>
        public Adult Mother { get; set; }

        /// <summary>
        /// Школа
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// Метод возвращает строковое описание ребёнка
        /// </summary>
        public override string GetInfo()
        {
            string baseInfo = $" {Surname} {Name}\n Возраст: {Age}\n" +
                $" Пол: {(Gender == Gender.Male ? "мужской" : "женский")}\n";
            string fatherInfo = Father != null
                ? $" Отец: {Father.Surname} {Father.Name}\n"
                : " Отец: не указан\n";
            string motherInfo = Mother != null
                ? $" Мать: {Mother.Surname} {Mother.Name}\n"
                : " Мать: не указана\n";
            string schoolInfo = string.IsNullOrWhiteSpace(School)
                ? " Учебное заведение: не указано\n"
                : $" Учебное заведение: {School}\n";
            return $"{baseInfo}{fatherInfo}{motherInfo}{schoolInfo}";
        }

        /// <summary>
        /// Проверка возраста ребенка
        /// </summary>
        /// <param name="age">Возраст</param>
        /// <exception cref="Exception">Возраст должен соостветствовать 
        /// возрасту ребенка</exception>
        protected override void CheckAge(int age)
        {
            if ((age < MinAgeChild) || (age > MaxAgeChild))
            {
                throw new Exception($"Возраст ребенка должен быть" +
                    $" в пределах от {MinAgeChild} до {MaxAgeChild}");
            }
        }

        /// <summary>
        /// Специальны метод для ребёнка
        /// </summary>
        /// <returns></returns>
        public string GetGame()
        {
            string[] games = { "Red Alert 2", "Postal 2", 
                "Heroes III", "GTA 4", "Mafia" };
            var random = new Random();
            string game = games[random.Next(games.Length)];
            return $"Это ребёнок, и он любит играть в {game}";
        }
    }
}
