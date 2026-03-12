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

        public IShape CreatedShape { get; private set; }

        public AddShapeForm()
        {
            InitializeComponent();
            // Скрываем все группы с параметрами изначально
            groupBoxSphere.Visible = false;
            groupBoxPyramid.Visible = false;
            groupBoxParallelepiped.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

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
                // Проверка на пустые поля
                if (string.IsNullOrWhiteSpace(txtRadius.Text) ||
                    string.IsNullOrWhiteSpace(txtPyramidLength.Text) ||
                    string.IsNullOrWhiteSpace(txtPyramidWidth.Text) ||
                    string.IsNullOrWhiteSpace(txtPyramidHeight.Text) ||
                    string.IsNullOrWhiteSpace(txtParallelepipedLength.Text) ||
                    string.IsNullOrWhiteSpace(txtParallelepipedWidth.Text) ||
                    string.IsNullOrWhiteSpace(txtParallelepipedHeight.Text))
                {
                    MessageBox.Show(
                        "Пожалуйста, заполните все поля!",
                        "Ошибка ввода",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Определяем, какая фигура выбрана, и создаём объект
                if (rbSphere.Checked)
                {
                    double radius = double.Parse(txtRadiu.Text);
                    CreatedShape = new Sphere(radius);
                }
                else if (rbPyramid.Checked)
                {
                    double length = double.Parse(txtPyramidLength.Text);
                    double width = double.Parse(txtPyramidWidth.Text);
                    double height = double.Parse(txtPyramidHeight.Text);
                    CreatedShape = new Pyramid(length, width, height);
                }
                else if (rbParallelepiped.Checked)
                {
                    double length = double.Parse(txtParallelepipedLength.Text);
                    double width = double.Parse(txtParallelepipedWidth.Text);
                    double height = double.Parse(txtParallelepipedHeight.Text);
                    CreatedShape = new Parallelepiped(length, width, height);
                }
                else
                {
                    MessageBox.Show(
                        "Пожалуйста, выберите тип фигуры!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Пожалуйста, введите корректные числовые значения!\n" +
                    "Используйте точку для разделения целой и дробной части.",
                    "Ошибка формата",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                // Ловим исключения валидации из бизнес-логики (Model)
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}