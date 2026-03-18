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
    public partial class AddShapeForm : Form
    {

        private Random _random = new Random();
        public IShape CreatedShape { get; private set; }

        public AddShapeForm()
        {
            InitializeComponent();
            // Скрываем все группы с параметрами изначально
            groupBoxSphere.Visible = false;
            groupBoxPyramid.Visible = false;
            groupBoxParallelepiped.Visible = false;

            // ✅ УСЛОВНАЯ КОМПИЛЯЦИЯ (Пункт 11)
            // В Release-версии кнопка будет скрыта
            #if !DEBUG
                btnRandomData.Visible = false;
            #endif
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSphere.Visible = rbSphere.Checked;
            groupBoxPyramid.Visible = rbPyramid.Checked;
            groupBoxParallelepiped.Visible = rbParallelepiped.Checked;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AddShapeForm_Load(object sender, EventArgs e)
        {

        }

        private void butOk_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка: выбрана ли фигура
                if (!rbSphere.Checked && !rbPyramid.Checked && !rbParallelepiped.Checked)
                {
                    MessageBox.Show("Пожалуйста, выберите тип фигуры!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rbSphere.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtRadius.Text))
                    {
                        MessageBox.Show("Заполните радиус шара!", "Ошибка ввода",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRadius.Focus();
                        return;
                    }
                    double radius = double.Parse(txtRadius.Text); // ✅ ИСПРАВЛЕНО: txtRadius
                    CreatedShape = new Sphere(radius);
                }
                else if (rbPyramid.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtPyramidLength.Text) ||
                        string.IsNullOrWhiteSpace(txtPyramidWidth.Text) ||
                        string.IsNullOrWhiteSpace(txtPyramidHeight.Text))
                    {
                        MessageBox.Show("Заполните все поля пирамиды!", "Ошибка ввода",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show("Заполните все поля параллелепипеда!", "Ошибка ввода",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Пожалуйста, введите корректные числовые значения!\n" +
                    "Используйте точку для разделения целой и дробной части.",
                    "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddShapeForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtRadius_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры, точку и backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Разрешаем только одну точку
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        private void txtPyramidLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры, точку и backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Разрешаем только одну точку
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        private void txtPyramidWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры, точку и backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Разрешаем только одну точку
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        private void txtPyramidHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры, точку и backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Разрешаем только одну точку
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        private void txtParallelepipedLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры, точку и backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Разрешаем только одну точку
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        private void txtParallelepipedWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры, точку и backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Разрешаем только одну точку
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        private void txtParallelepipedHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры, точку и backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Разрешаем только одну точку
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') >= 0))
            {
                e.Handled = true;
            }
        }

        private void btnRandomData_Click(object sender, EventArgs e)
        {
            try
            {
                // Генерируем случайные данные в зависимости от выбранной фигуры
                if (rbSphere.Checked)
                {
                    // Шар: радиус от 1 до 100
                    double radius = _random.NextDouble() * 99 + 1; // 1.0 - 100.0
                    txtRadius.Text = radius.ToString("F2");
                }
                else if (rbPyramid.Checked)
                {
                    // Пирамида: длина, ширина, высота от 1 до 50
                    double length = _random.NextDouble() * 49 + 1; // 1.0 - 50.0
                    double width = _random.NextDouble() * 49 + 1;
                    double height = _random.NextDouble() * 49 + 1;

                    txtPyramidLength.Text = length.ToString("F2");
                    txtPyramidWidth.Text = width.ToString("F2");
                    txtPyramidHeight.Text = height.ToString("F2");
                }
                else if (rbParallelepiped.Checked)
                {
                    // Параллелепипед: длина, ширина, высота от 1 до 50
                    double length = _random.NextDouble() * 49 + 1; // 1.0 - 50.0
                    double width = _random.NextDouble() * 49 + 1;
                    double height = _random.NextDouble() * 49 + 1;

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