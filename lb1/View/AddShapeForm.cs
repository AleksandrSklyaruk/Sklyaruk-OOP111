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
        //TODO: XML +
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private Random _random = new Random();

        //TODO: XML +
        /// <summary>
        /// Созданная фигура, передаётся в главную форму
        /// </summary>
        public IShape CreatedShape { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса
        /// </summary>
        public AddShapeForm()
        {
            InitializeComponent();

            groupBoxSphere.Visible = false;
            groupBoxPyramid.Visible = false;
            groupBoxParallelepiped.Visible = false;

#if !DEBUG
                buttonRandomData.Visible = false;
#endif

            AttachKeyPressHandler(textRadius);
            AttachKeyPressHandler(textPyramidLength);
            AttachKeyPressHandler(textPyramidWidth);
            AttachKeyPressHandler(textPyramidHeight);
            AttachKeyPressHandler(textParallelepipedLength);
            AttachKeyPressHandler(textParallelepipedWidth);
            AttachKeyPressHandler(txtParallelepipedHeight);
        }

        //TODO: RSDN +
        /// <summary>
        /// Обработчик события изменения состояния RadioButton 
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSphere.Visible = radioBattonSphere.Checked;
            groupBoxPyramid.Visible = radioBattonPyramid.Checked;
            groupBoxParallelepiped.Visible = radioBattonParallelepiped.Checked;
        }

        //TODO: RSDN +
        /// <summary>
        /// Обработчик нажатия кнопки "ОК".
        /// и закрывает форму с результатом <see cref="DialogResult.OK"/>.
        /// </summary>
        /// <param name="sender">Источник события (кнопка butOk).</param>
        /// <param name="e">Аргументы события <see cref="EventArgs"/>.</param>
        private void ButttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!radioBattonSphere.Checked && !radioBattonPyramid.Checked &&
                    !radioBattonParallelepiped.Checked)
                {
                    MessageBox.Show("Пожалуйста, выберите тип фигуры!",
                        "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                if (radioBattonSphere.Checked)
                {
                    if (string.IsNullOrWhiteSpace(textRadius.Text))
                    {
                        MessageBox.Show("Заполните радиус шара!",
                            "Ошибка ввода", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        textRadius.Focus();
                        return;
                    }
                    double radius = double.Parse(textRadius.Text);
                    CreatedShape = new Sphere(radius);
                }
                else if (radioBattonPyramid.Checked)
                {
                    if (string.IsNullOrWhiteSpace(textPyramidLength.Text) ||
                        string.IsNullOrWhiteSpace(textPyramidWidth.Text) ||
                        string.IsNullOrWhiteSpace(textPyramidHeight.Text))
                    {
                        MessageBox.Show("Заполните все поля пирамиды!",
                            "Ошибка ввода", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    double length = double.Parse(textPyramidLength.Text);
                    double width = double.Parse(textPyramidWidth.Text);
                    double height = double.Parse(textPyramidHeight.Text);
                    CreatedShape = new Pyramid(length, width, height);
                }
                else if (radioBattonParallelepiped.Checked)
                {
                    if (string.IsNullOrWhiteSpace(textParallelepipedLength.Text) ||
                        string.IsNullOrWhiteSpace(textParallelepipedWidth.Text) ||
                        string.IsNullOrWhiteSpace(txtParallelepipedHeight.Text))
                    {
                        MessageBox.Show("Заполните все поля параллелепипеда!",
                            "Ошибка ввода", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    double length = double.Parse(textParallelepipedLength.Text);
                    double width = double.Parse(textParallelepipedWidth.Text);
                    double height = double.Parse(txtParallelepipedHeight.Text);
                    CreatedShape = new Parallelepiped(length, width, height);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные " +
                    "числовые значения!\n" + "Используйте точку для " +
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

        //TODO: RSDN +
        /// <summary>
        /// Обработчик нажатия кнопки "Отмена".
        /// Закрывает форму с результатом <see cref="DialogResult.Cancel"/> без создания фигуры.
        /// </summary>
        /// <param name="sender">Источник события (кнопка buyyonCancel).</param>
        /// <param name="e">Аргументы события <see cref="EventArgs"/>.</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //TODO: duplication +
        //TODO: RSDN +
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
        /// <param name="e">Аргументы события <see cref="KeyPressEventArgs"/>.</param>
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && ((sender as TextBox)?.Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        //TODO: RSDN +
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
                    double radius = _random.NextDouble() * 99 + 1;
                    textRadius.Text = radius.ToString("F2");
                }
                else if (radioBattonPyramid.Checked)
                {
                    double length = _random.NextDouble() * 99 + 1;
                    double width = _random.NextDouble() * 99 + 1;
                    double height = _random.NextDouble() * 99 + 1;

                    textPyramidLength.Text = length.ToString("F2");
                    textPyramidWidth.Text = width.ToString("F2");
                    textPyramidHeight.Text = height.ToString("F2");
                }
                else if (radioBattonParallelepiped.Checked)
                {
                    double length = _random.NextDouble() * 99 + 1;
                    double width = _random.NextDouble() * 99 + 1;
                    double height = _random.NextDouble() * 99 + 1;

                    textParallelepipedLength.Text = length.ToString("F2");
                    textParallelepipedWidth.Text = width.ToString("F2");
                    txtParallelepipedHeight.Text = height.ToString("F2");
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

        private void Radius_Click(object sender, EventArgs e)
        {

        }
    }
}