using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class MainForm : Form
    {
        private List<IShape> _shapes;

        public MainForm()
        {
            InitializeComponent();

            _shapes = new List<IShape>();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddShape_Click(object sender, EventArgs e)
        {
            // Создаём форму добавления фигуры
            using (var addForm = new AddShapeForm())
            {
                // Открываем форму как диалоговое окно
                DialogResult result = addForm.ShowDialog();

                // Если пользователь нажал OK
                if (result == DialogResult.OK)
                {
                    // Получаем созданную фигуру из свойства CreatedShape
                    IShape newShape = addForm.CreatedShape;

                    // Добавляем фигуру в список
                    if (newShape != null)
                    {
                        _shapes.Add(newShape);

                        // Обновляем DataGridView
                        dataGridViewShapes.DataSource = null;
                        dataGridViewShapes.DataSource = _shapes;

                        // Показываем сообщение об успехе
                        MessageBox.Show(
                            $"Фигура '{newShape.Name}' успешно добавлена!",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
