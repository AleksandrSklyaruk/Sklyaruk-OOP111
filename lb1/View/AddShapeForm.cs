using Model;
using View.Helper;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Форма для добавления новой трёхмерной фигуры.
    /// </summary>
    public partial class AddShapeForm : Form
    {
        /// <summary>
        /// Формат отображения чисел.
        /// </summary>
        private const string NumberFormat = "F2";

        /// <summary>
        /// Минимальное значение для генерации случайных данных.
        /// </summary>
        private const double MinRandom = 1.0;

        /// <summary>
        /// Максимальное значение для генерации случайных данных.
        /// </summary>
        private const double MaxRandom = 100.0;

        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Созданная фигура, передаётся в главную форму.
        /// </summary>
        public IShape CreatedShape { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public AddShapeForm()
        {
            InitializeComponent();

            groupBoxSphere.Visible = false;
            groupBoxPyramid.Visible = false;
            groupBoxParallelepiped.Visible = false;

#if DEBUG
            CreateDebugButton();
#endif

            AttachKeyPressHandlers(
                textRadius,
                textPyramidLength,
                textPyramidWidth,
                textPyramidHeight,
                textParallelepipedLength,
                textParallelepipedWidth,
                txtParallelepipedHeight);
        }

#if DEBUG
        /// <summary>
        /// Создаёт и добавляет отладочную кнопку 
        /// "Заполнить случайными данными".
        /// </summary>
        private void CreateDebugButton()
        {
            Button buttonRandomData = new Button();

            buttonRandomData.Location = new Point(12, 138);
            buttonRandomData.Name = "buttonRandomData";
            buttonRandomData.Size = new Size(383, 23);
            buttonRandomData.TabIndex = 23;
            buttonRandomData.Text = "Заполнить случайными данными";
            buttonRandomData.UseVisualStyleBackColor = true;
            buttonRandomData.Click += ButtonRandomData_Click;

            Controls.Add(buttonRandomData);
        }
#endif

        /// <summary>
        /// Обработчик события изменения состояния RadioButton.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSphere.Visible = radioBattonSphere.Checked;
            groupBoxPyramid.Visible = radioBattonPyramid.Checked;
            groupBoxParallelepiped.Visible =
                radioBattonParallelepiped.Checked;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "ОК".
        /// Создаёт фигуру и закрывает форму с результатом
        /// <see cref="DialogResult.OK"/>.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ButttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsShapeTypeSelected())
                {
                    MessageBox.Show(
                        "Пожалуйста, выберите тип фигуры!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (radioBattonSphere.Checked)
                {
                    CreatedShape = CreateSphere();
                }
                else if (radioBattonPyramid.Checked)
                {
                    CreatedShape = CreatePyramid();
                }
                else if (radioBattonParallelepiped.Checked)
                {
                    CreatedShape = CreateParallelepiped();
                }

                if (CreatedShape == null)
                {
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Пожалуйста, введите корректные числовые значения!\n" +
                    "Используйте запятую для разделения " +
                    "целой и дробной части.",
                    "Ошибка формата",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка валидации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Произошла непредвиденная ошибка: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена".
        /// Закрывает форму с результатом 
        /// <see cref="DialogResult.Cancel"/> без создания фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Проверяет, выбран ли тип фигуры.
        /// </summary>
        /// <returns>
        /// Возвращает true, если выбран один из типов фигуры;
        /// иначе false.
        /// </returns>
        private bool IsShapeTypeSelected()
        {
            return radioBattonSphere.Checked ||
                radioBattonPyramid.Checked ||
                radioBattonParallelepiped.Checked;
        }

        /// <summary>
        /// Создаёт объект шара на основе данных формы.
        /// </summary>
        /// <returns>Созданный шар.</returns>
        private IShape CreateSphere()
        {
            if (Validator.AreTextBoxesFilled(
                "Заполните радиус шара!",
                textRadius))
            {
                return new Sphere(
                    ParseNumber(textRadius.Text));
            }

            return null;
        }

        /// <summary>
        /// Создаёт объект пирамиды на основе данных формы.
        /// </summary>
        /// <returns>Созданная пирамида.</returns>
        private IShape CreatePyramid()
        {
            if (Validator.AreTextBoxesFilled(
                "Заполните все поля пирамиды!",
                textPyramidLength,
                textPyramidWidth,
                textPyramidHeight))
            {
                return new Pyramid(
                    ParseNumber(textPyramidLength.Text),
                    ParseNumber(textPyramidWidth.Text),
                    ParseNumber(textPyramidHeight.Text));
            }

            return null;
        }

        /// <summary>
        /// Создаёт объект параллелепипеда на основе данных формы.
        /// </summary>
        /// <returns>Созданный параллелепипед.</returns>
        private IShape CreateParallelepiped()
        {
            if (Validator.AreTextBoxesFilled(
                "Заполните все поля параллелепипеда!",
                textParallelepipedLength,
                textParallelepipedWidth,
                txtParallelepipedHeight))
            {
                return new Parallelepiped(
                    ParseNumber(textParallelepipedLength.Text),
                    ParseNumber(textParallelepipedWidth.Text),
                    ParseNumber(txtParallelepipedHeight.Text));
            }

            return null;
        }

        /// <summary>
        /// Привязывает универсальный обработчик KeyPress
        /// к нескольким TextBox.
        /// </summary>
        /// <param name="textBoxes">Поля для привязки обработчика.</param>
        private void AttachKeyPressHandlers(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                AttachKeyPressHandler(textBox);
            }
        }

        /// <summary>
        /// Привязывает универсальный обработчик KeyPress к TextBox.
        /// </summary>
        /// <param name="textBox">TextBox для привязки.</param>
        private void AttachKeyPressHandler(TextBox textBox)
        {
            if (textBox != null)
            {
                textBox.KeyPress += NumericTextBox_KeyPress;
            }
        }

        /// <summary>
        /// Универсальный обработчик KeyPress для ввода положительных чисел.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void NumericTextBox_KeyPress
            (object sender, KeyPressEventArgs e)
        {
            const char decimalSeparator = ',';

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != decimalSeparator)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == decimalSeparator &&
                ((sender as TextBox)?.Text.IndexOf(decimalSeparator) >= 0))
            {
                e.Handled = true;
            }
        }

#if DEBUG
        /// <summary>
        /// Обработчик нажатия кнопки "Случайные данные".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ButtonRandomData_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioBattonSphere.Checked)
                {
                    FillTextBoxesWithRandomNumbers(textRadius);
                }
                else if (radioBattonPyramid.Checked)
                {
                    FillTextBoxesWithRandomNumbers(
                        textPyramidLength,
                        textPyramidWidth,
                        textPyramidHeight);
                }
                else if (radioBattonParallelepiped.Checked)
                {
                    FillTextBoxesWithRandomNumbers(
                        textParallelepipedLength,
                        textParallelepipedWidth,
                        txtParallelepipedHeight);
                }
                else
                {
                    MessageBox.Show(
                        "Сначала выберите тип фигуры!",
                        "Предупреждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при генерации случайных данных: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Заполняет переданные TextBox случайными числами.
        /// </summary>
        /// <param name="textBoxes">Поля для заполнения.</param>
        private void FillTextBoxesWithRandomNumbers(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox != null)
                {
                    textBox.Text = GenerateRandomNumber();
                }
            }
        }

        /// <summary>
        /// Генерирует случайное число в заданном диапазоне.
        /// </summary>
        /// <returns>Отформатированная строка со случайным числом.</returns>
        private string GenerateRandomNumber()
        {
            double value = _random.NextDouble() *
                (MaxRandom - MinRandom) + MinRandom;

            return value.ToString(NumberFormat);
        }
#endif

        /// <summary>
        /// Преобразует строку в double, заменяя запятую на точку.
        /// </summary>
        /// <param name="text">Строка с числовым значением.</param>
        /// <returns>Значение типа double.</returns>
        private double ParseNumber(string text)
        {
            string normalized = text.Replace(',', '.');

            return double.Parse(
                normalized,
                CultureInfo.InvariantCulture);
        }
    }
}