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
        /// <summary>
        /// Список всех фигур для поиска
        /// </summary>
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
        /// Конструктор по умолчанию для дизайнера
        /// </summary>
        public SearchForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Настраивает DataGridView для отображения результатов поиска
        /// Колонки аналогичны главной форме
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
            dataGridViewResults.RowTemplate.Height = 50;
            dataGridViewResults.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Настраивает поля для поиска в ComboBox
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
        /// Обработчик нажатия кнопки "Найти"
        /// </summary>
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string searchText;
            searchText = textBoxSearchValue.Text.Trim().ToLower();
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
                case 1:
                    foundShapes = SearchByNumericValue
                        (s => s.CalculateVolume(), searchText, "объёму");
                    break;

                case 2:
                    foundShapes = SearchByNumericValue
                        (s => s.Length, searchText, "длине");
                    break;

                case 3:
                    foundShapes = SearchByNumericValue
                        (s => s.Width, searchText, "ширине");
                    break;

                case 4:
                    foundShapes = SearchByNumericValue
                        (s => s.Height, searchText, "высоте");
                    break;

                case 5:
                    foundShapes = SearchByNumericValue
                        (s => s.Radius, searchText, "радиусу");
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
                        //TODO: duplication
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

        /// <summary>
        /// Выполняет поиск по числовому полю с погрешностью
        /// </summary>
        /// <param name="getValue"
        /// >Делегат (Func) для получения значения из фигуры</param>
        /// <param name="searchText">Искомое значение</param>
        /// <param name="fieldName">Название поля для сообщения об ошибке</param>
        /// <returns>Список найденных фигур или пустой список при ошибке</returns>
        private List<IShape> SearchByNumericValue(
            Func<IShape, double> getValue,
            string searchText,
            string fieldName)
        {
            if (double.TryParse(searchText, out double searchValue))
            {
                return _allShapes.FindAll(s =>
                    Math.Abs(getValue(s) - searchValue) < 0.01);
            }

            MessageBox.Show(
                $"Введите корректное числовое значение " +
                $"для поиска по {fieldName}!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return new List<IShape>();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Закрыть".
        /// </summary>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
