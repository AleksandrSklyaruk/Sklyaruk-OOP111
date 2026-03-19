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

        private Random _random = new Random();

        public IShape CreatedShape { get; set; }

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
                btnRandomData.Visible = false;
#endif
        }

        /// <summary>
        /// Обработчик события изменения состояния RadioButton 
        /// для выбора типа фигуры
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSphere.Visible = rbSphere.Checked;
            groupBoxPyramid.Visible = rbPyramid.Checked;
            groupBoxParallelepiped.Visible = rbParallelepiped.Checked;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "ОК".
        /// Выполняет валидацию введённых данных, создаёт объект выбранной фигуры
        /// и закрывает форму с результатом <see cref="DialogResult.OK"/>.
        /// </summary>
        /// <param name="sender">Источник события (кнопка butOk).</param>
        /// <param name="e">Аргументы события <see cref="EventArgs"/>.</param>
        private void butOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!rbSphere.Checked && !rbPyramid.Checked && 
                    !rbParallelepiped.Checked)
                {
                    MessageBox.Show("Пожалуйста, выберите тип фигуры!", 
                        "Ошибка", MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    return;
                }
                if (rbSphere.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtRadius.Text))
                    {
                        MessageBox.Show("Заполните радиус шара!", 
                            "Ошибка ввода", MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                        txtRadius.Focus();
                        return;
                    }
                    double radius = double.Parse(txtRadius.Text);
                    CreatedShape = new Sphere(radius);
                }
                else if (rbPyramid.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtPyramidLength.Text) ||
                        string.IsNullOrWhiteSpace(txtPyramidWidth.Text) ||
                        string.IsNullOrWhiteSpace(txtPyramidHeight.Text))
                    {
                        MessageBox.Show("Заполните все поля пирамиды!", 
                            "Ошибка ввода", MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                        return;
                    }
                    double length = double.Parse(txtPyramidLength.Text);
                    double width = double.Parse(txtPyramidWidth.Text);
                    double height = double.Parse(txtPyramidHeight.Text);
                    CreatedShape = new Pyramid(length, width, height);
                }
                else if (rbParallelepiped.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtParallelepipedLength.Text) ||
                        string.IsNullOrWhiteSpace(txtParallelepipedWidth.Text) ||
                        string.IsNullOrWhiteSpace(txtParallelepipedHeight.Text))
                    {
                        MessageBox.Show("Заполните все поля параллелепипеда!", 
                            "Ошибка ввода", MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                        return;
                    }
                    double length = double.Parse(txtParallelepipedLength.Text);
                    double width = double.Parse(txtParallelepipedWidth.Text);
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

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена".
        /// Закрывает форму с результатом <see cref="DialogResult.Cancel"/> без создания фигуры.
        /// </summary>
        /// <param name="sender">Источник события (кнопка btnCancel).</param>
        /// <param name="e">Аргументы события <see cref="EventArgs"/>.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Обработчик события KeyPress для поля ввода радиуса шара.
        /// Разрешает ввод только цифр, точки и управляющих символов (Backspace).
        /// Запрещает ввод более одной точки в числе.
        /// </summary>
        /// <param name="sender">Источник события (TextBox).</param>
        /// <param name="e">Аргументы события <see cref="KeyPressEventArgs"/>.</param>
        private void txtRadius_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработчик события KeyPress для поля ввода длины пирамиды.
        /// Разрешает ввод только цифр, точки и управляющих символов (Backspace).
        /// Запрещает ввод более одной точки в числе.
        /// </summary>
        /// <param name="sender">Источник события (TextBox).</param>
        /// <param name="e">Аргументы события <see cref="KeyPressEventArgs"/>.</param>
        private void txtPyramidLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработчик события KeyPress для поля ввода ширины пирамиды.
        /// Разрешает ввод только цифр, точки и управляющих символов (Backspace).
        /// Запрещает ввод более одной точки в числе.
        /// </summary>
        /// <param name="sender">Источник события (TextBox).</param>
        /// <param name="e">Аргументы события <see cref="KeyPressEventArgs"/>.</param>
        private void txtPyramidWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработчик события KeyPress для поля ввода высоты пирамиды.
        /// Разрешает ввод только цифр, точки и управляющих символов (Backspace).
        /// Запрещает ввод более одной точки в числе.
        /// </summary>
        /// <param name="sender">Источник события (TextBox).</param>
        /// <param name="e">Аргументы события <see cref="KeyPressEventArgs"/>.</param>
        private void txtPyramidHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработчик события KeyPress для поля ввода длины параллелепипеда.
        /// Разрешает ввод только цифр, точки и управляющих символов (Backspace).
        /// Запрещает ввод более одной точки в числе.
        /// </summary>
        /// <param name="sender">Источник события (TextBox).</param>
        /// <param name="e">Аргументы события <see cref="KeyPressEventArgs"/>.</param>
        private void txtParallelepipedLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработчик события KeyPress для поля ввода ширины параллелепипеда.
        /// Разрешает ввод только цифр, точки и управляющих символов (Backspace).
        /// Запрещает ввод более одной точки в числе.
        /// </summary>
        /// <param name="sender">Источник события (TextBox).</param>
        /// <param name="e">Аргументы события <see cref="KeyPressEventArgs"/>.</param>
        private void txtParallelepipedWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработчик события KeyPress для поля ввода высоты параллелепипеда.
        /// Разрешает ввод только цифр, точки и управляющих символов (Backspace).
        /// Запрещает ввод более одной точки в числе.
        /// </summary>
        /// <param name="sender">Источник события (TextBox).</param>
        /// <param name="e">Аргументы события <see cref="KeyPressEventArgs"/>.</param>
        private void txtParallelepipedHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Случайные данные" (отладочная функция).
        /// Заполняет поля формы случайными корректными значениями для выбранного типа фигуры.
        /// Кнопка видима только в режиме отладки (Debug) благодаря условной компиляции.
        /// </summary>
        /// <param name="sender">Источник события (кнопка btnRandomData).</param>
        /// <param name="e">Аргументы события <see cref="EventArgs"/>.</param>
        private void btnRandomData_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbSphere.Checked)
                {
                    double radius = _random.NextDouble() * 99 + 1;
                    txtRadius.Text = radius.ToString("F2");
                }
                else if (rbPyramid.Checked)
                {
                    double length = _random.NextDouble() * 99 + 1;
                    double width = _random.NextDouble() * 99 + 1;
                    double height = _random.NextDouble() * 99 + 1;

                    txtPyramidLength.Text = length.ToString("F2");
                    txtPyramidWidth.Text = width.ToString("F2");
                    txtPyramidHeight.Text = height.ToString("F2");
                }
                else if (rbParallelepiped.Checked)
                {
                    double length = _random.NextDouble() * 99 + 1;
                    double width = _random.NextDouble() * 99 + 1;
                    double height = _random.NextDouble() * 99 + 1;

                    txtParallelepipedLength.Text = length.ToString("F2");
                    txtParallelepipedWidth.Text = width.ToString("F2");
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
    }
}