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
    /// Форма для поиска фигур по различным критериям.
    /// </summary>
    public partial class SearchForm : Form
    {
        //TODO: XML
        private List<IShape> _allShapes;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="SearchForm"/>.
        /// </summary>
        /// <param name="shapes">Список фигур для поиска.</param>
        public SearchForm(List<IShape> shapes)
        {
            InitializeComponent();
            _allShapes = shapes;
            SetupDataGridView();
            SetupSearchFields();
        }

        /// <summary>
        /// Конструктор по умолчанию для дизайнера.
        /// </summary>
        public SearchForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Настраивает DataGridView для отображения результатов поиска.
        /// Колонки аналогичны главной форме.
        /// </summary>
        private void SetupDataGridView()
        {
            dataGridViewResults.Columns.Clear();

            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Название",
                Width = 150
            });

            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Volume",
                HeaderText = "Объём",
                Width = 150
            });

            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Parameters",
                HeaderText = "Параметры",
                Width = 300
            });

            dataGridViewResults.DefaultCellStyle.WrapMode = 
                DataGridViewTriState.True;
            dataGridViewResults.RowTemplate.Height = 60;
            dataGridViewResults.AutoSizeColumnsMode = 
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Настраивает поля для поиска в ComboBox.
        /// </summary>
        private void SetupSearchFields()
        {
            comboBoxSearchField.Items.Clear();
            comboBoxSearchField.Items.Add("Название фигуры");
            comboBoxSearchField.Items.Add("Объём");
            comboBoxSearchField.Items.Add("Длина");
            comboBoxSearchField.Items.Add("Ширина");
            comboBoxSearchField.Items.Add("Высота");
            comboBoxSearchField.Items.Add("Радиус");
            comboBoxSearchField.SelectedIndex = 0;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Найти".
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearchValue.Text.Trim().ToLower();
            int selectedField = comboBoxSearchField.SelectedIndex;

            dataGridViewResults.Rows.Clear();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show(
                    "Введите значение для поиска!",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            List<IShape> foundShapes = new List<IShape>();

            switch (selectedField)
            {
                //TODO: {}
                case 0:
                    foundShapes = _allShapes.FindAll(s =>
                        s.Name.ToLower().Contains(searchText));
                    break;
                //TODO: duplication
                case 1:
                    if (double.TryParse
                        (searchText, out double volumeValue))
                    {
                        foundShapes = _allShapes.FindAll(s =>
                            Math.Abs
                            (s.CalculateVolume() - volumeValue) < 0.01);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Введите корректное числовое " +
                            "значение для поиска по объёму!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case 2:
                    if (double.TryParse(searchText, out double lengthValue))
                    {
                        foundShapes = _allShapes.FindAll(s =>
                            Math.Abs(s.Length - lengthValue) < 0.01);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Введите корректное числовое " +
                            "значение для поиска по длине!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case 3:
                    if (double.TryParse(searchText, out double widthValue))
                    {
                        foundShapes = _allShapes.FindAll(s =>
                            Math.Abs(s.Width - widthValue) < 0.01);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Введите корректное числовое " +
                            "значение для поиска по ширине!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case 4:
                    if (double.TryParse(searchText, out double heightValue))
                    {
                        foundShapes = _allShapes.FindAll(s =>
                            Math.Abs(s.Height - heightValue) < 0.01);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Введите корректное числовое " +
                            "значение для поиска по высоте!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case 5:
                    if (double.TryParse(searchText, out double radiusValue))
                    {
                        foundShapes = _allShapes.FindAll(s =>
                            Math.Abs(s.Radius - radiusValue) < 0.01);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Введите корректное числовое " +
                            "значение для поиска по радиусу!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    break;
            }

            if (foundShapes.Count == 0)
            {
                MessageBox.Show(
                    "По вашему запросу ничего не найдено.",
                    "Результаты поиска",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                foreach (var shape in foundShapes)
                {
                    dataGridViewResults.Rows.Add(
                        shape.Name,
                        shape.CalculateVolume().ToString("F2"),
                        shape.Parameters);
                }

                MessageBox.Show(
                    $"Найдено фигур: {foundShapes.Count}",
                    "Результаты поиска",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        //TODO: RSDN
        /// <summary>
        /// Обработчик нажатия кнопки "Закрыть".
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
