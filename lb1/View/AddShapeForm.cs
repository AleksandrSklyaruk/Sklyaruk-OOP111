using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Форма для добавления новой трёхмерной фигуры
    /// </summary>
    public partial class AddShapeForm : Form
    {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private Random _random = new Random();

        /// <summary>
        /// Созданная фигура, передаётся в главную форму
        /// </summary>
        public IShape CreatedShape { get; private set; }

        /// <summary>
        /// Формат отображения чисел
        /// </summary>
        private const string NumberFormat = "F2";

        /// <summary>
        /// Минимальное значение для генерации случайных данных
        /// </summary>
        private const double MinRandom = 1.0;

        /// <summary>
        /// Максимальное значение для генерации случайных данных
        /// </summary>
        private const double MaxRandom = 100.0;

        /// <summary>
        /// Инициализирует новый экземпляр класса
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

            AttachKeyPressHandler(textRadius);
            AttachKeyPressHandler(textPyramidLength);
            AttachKeyPressHandler(textPyramidWidth);
            AttachKeyPressHandler(textPyramidHeight);
            AttachKeyPressHandler(textParallelepipedLength);
            AttachKeyPressHandler(textParallelepipedWidth);
            AttachKeyPressHandler(txtParallelepipedHeight);
        }

#if DEBUG
        /// <summary>
        /// Создаёт и добавляет отладочную кнопку "Заполнить случайными данными"
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

            this.Controls.Add(buttonRandomData);
        }
#endif

        /// <summary>
        /// Обработчик события изменения состояния RadioButton 
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSphere.Visible = radioBattonSphere.Checked;
            groupBoxPyramid.Visible = radioBattonPyramid.Checked;
            groupBoxParallelepiped.Visible =
                radioBattonParallelepiped.Checked;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "ОК".
        /// и закрывает форму с результатом <see cref="DialogResult.OK"/>.
        /// </summary>
        /// <param name="sender">Источник события (кнопка butOk).</param>
        /// <param name="e">Аргументы события 
        /// <see cref="EventArgs"/>.</param>
        private void ButttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!radioBattonSphere.Checked &&
                    !radioBattonPyramid.Checked &&
                    !radioBattonParallelepiped.Checked)
                {
                    MessageBox.Show("Пожалуйста, выберите тип фигуры!",
                        "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                if (radioBattonSphere.Checked)
                {
                    if (!AreTextBoxesFilled(textRadius))
                    {
                        MessageBox.Show("Заполните радиус шара!",
                            "Ошибка ввода", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        textRadius.Focus();
                        return;
                    }
                    CreatedShape = new Sphere(ParseNumber(textRadius.Text));
                }
                else if (radioBattonPyramid.Checked)
                {
                    if (!AreTextBoxesFilled(textPyramidLength,
                        textPyramidWidth, textPyramidHeight))
                    {
                        MessageBox.Show("Заполните все поля пирамиды!",
                            "Ошибка ввода", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    CreatedShape = new Pyramid(
                        ParseNumber(textPyramidLength.Text),
                        ParseNumber(textPyramidWidth.Text),
                        ParseNumber(textPyramidHeight.Text));
                }
                else if (radioBattonParallelepiped.Checked)
                {
                    if (!AreTextBoxesFilled(textParallelepipedLength,
                        textParallelepipedWidth,
                        txtParallelepipedHeight))
                    {
                        MessageBox.Show("Заполните все поля параллелепипеда!",
                            "Ошибка ввода", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    CreatedShape = new Parallelepiped(
                        ParseNumber(textParallelepipedLength.Text),
                        ParseNumber(textParallelepipedWidth.Text),
                        ParseNumber(txtParallelepipedHeight.Text));
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные " +
                    "числовые значения!\n" + "Используйте запятую для " +
                    "разделения целой и дробной части.", "Ошибка формата",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: " +
                    $"{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена".
        /// Закрывает форму с результатом 
        /// <see cref="DialogResult.Cancel"/> без создания фигуры.
        /// </summary>
        /// <param name="sender">Источник события (кнопка buyyonCancel).</param>
        /// <param name="e">Аргументы события <see cref="EventArgs"/>.</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
        /// <param name="sender">Источник события (TextBox).</param>
        /// <param name="e">Аргументы события 
        /// <see cref="KeyPressEventArgs"/>.</param>
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //TODO: RSDN +
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

        /// <summary>
        /// Обработчик нажатия кнопки "Случайные данные" (отладочная функция).
        /// </summary>
        /// <param name="sender">Источник события (кнопка buttonRandomData).</param>
        /// <param name="e">Аргументы события <see cref="EventArgs"/>.</param>
        private void ButtonRandomData_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioBattonSphere.Checked)
                {
                    textRadius.Text = GenerateRandomNumber();
                }
                else if (radioBattonPyramid.Checked)
                {
                    textPyramidLength.Text = GenerateRandomNumber();
                    textPyramidWidth.Text = GenerateRandomNumber();
                    textPyramidHeight.Text = GenerateRandomNumber();
                }
                else if (radioBattonParallelepiped.Checked)
                {
                    textParallelepipedLength.Text = GenerateRandomNumber();
                    textParallelepipedWidth.Text = GenerateRandomNumber();
                    txtParallelepipedHeight.Text = GenerateRandomNumber();
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
        /// Генерирует случайное число в заданном диапазоне
        /// </summary>
        /// <returns>Отформатированная строка со случайным числом.</returns>
        private string GenerateRandomNumber()
        {
            double value = _random.NextDouble() *
                (MaxRandom - MinRandom) + MinRandom;
            return value.ToString(NumberFormat);
        }

        /// <summary>
        /// Преобразует строку в double, заменяя запятую на точку.
        /// </summary>
        /// <param name="text">Строка с числовым значением.</param>
        /// <returns>Значение типа double.</returns>
        private double ParseNumber(string text)
        {
            string normalized = text.Replace(',', '.');

            //TODO: RSDN +
            return double.Parse(normalized,
                System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Проверяет, что все TextBox заполнены.
        /// </summary>
        private bool AreTextBoxesFilled(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void textParallelepipedLength_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}