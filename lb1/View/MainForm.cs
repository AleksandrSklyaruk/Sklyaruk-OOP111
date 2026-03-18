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

            // ✅ Настройка DataGridView
            dataGridViewShapes.AutoGenerateColumns = true;
            dataGridViewShapes.ReadOnly = true;
            dataGridViewShapes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        private void btnRemoveShape_Click(object sender, EventArgs e)
        {
            if (dataGridViewShapes.CurrentRow != null)
            {
                int selectedIndex = dataGridViewShapes.CurrentRow.Index;
                if (selectedIndex >= 0 && selectedIndex < _shapes.Count)
                {
                    _shapes.RemoveAt(selectedIndex);
                    dataGridViewShapes.DataSource = null;
                    dataGridViewShapes.DataSource = _shapes;

                    MessageBox.Show("Фигура удалена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите фигуру для удаления!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRemoveShape_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewShapes.CurrentRow != null)
            {
                int idx = dataGridViewShapes.CurrentRow.Index;
                if (idx >= 0 && idx < _shapes.Count)
                {
                    _shapes.RemoveAt(idx);
                    dataGridViewShapes.DataSource = null;
                    dataGridViewShapes.DataSource = _shapes;
                    MessageBox.Show("Удалено!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите фигуру!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
