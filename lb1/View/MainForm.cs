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
using System.Xml.Serialization;

namespace View
{
    /// <summary>
    /// Главная форма приложения для управления трёхмерными фигурами
    /// </summary>
    public partial class MainForm : Form
    {
        //TODO: XML
        private List<IShape> _shapes;
        private string _currentFilePath = "";

        /// <summary>
        /// Инициализирует новый экземпляр класса
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _shapes = new List<IShape>();

            dataGridViewShapes.AutoGenerateColumns = false;
            dataGridViewShapes.ReadOnly = true;
            dataGridViewShapes.SelectionMode = 
                DataGridViewSelectionMode.FullRowSelect;
            dataGridViewShapes.AutoSizeColumnsMode = 
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewShapes.DefaultCellStyle.WrapMode = 
                DataGridViewTriState.True;
            dataGridViewShapes.RowTemplate.Height = 60;

            dataGridViewShapes.Columns.Clear();

            dataGridViewShapes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Название",
                DataPropertyName = "Name",
                Width = 150
            });

            dataGridViewShapes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Volume",
                HeaderText = "Объём",
                DataPropertyName = "Volume",
                Width = 150
            });

            dataGridViewShapes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Parameters",
                HeaderText = "Параметры",
                Width = 300
            });
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить фигуру"
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void btnAddShape_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddShapeForm())
            {
                DialogResult result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    IShape newShape = addForm.CreatedShape;

                    if (newShape != null)
                    {
                        _shapes.Add(newShape);

                        // Обновляем DataGridView
                        dataGridViewShapes.DataSource = null;
                        dataGridViewShapes.DataSource = _shapes;

                        // Заполняем колонку "Параметры" вручную
                        UpdateParametersColumn();

                        MessageBox.Show(
                            $"Фигура '{newShape.Name}' успешно добавлена!",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        //TODO: RSDN
        /// <summary>
        /// Обработчик нажатия кнопки "Удалить фигуру"
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
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

        //TODO: RSDN
        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_shapes.Count == 0)
            {
                MessageBox.Show(
                    "Список фигур пуст! Нечего сохранять.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = 
                    "Файлы фигур (*.shapes)|*.shapes|Все файлы (*.*)|*.*";
                saveDialog.Title = "Сохранить список фигур";
                saveDialog.FileName = "figures.shapes";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _currentFilePath = saveDialog.FileName;
                        SerializeShapes(_currentFilePath);

                        MessageBox.Show(
                            $"Данные успешно сохранены в файл:\n" +
                            $"{_currentFilePath}",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Ошибка при сохранении: {ex.Message}",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        //TODO: RSDN
        /// <summary>
        /// Обработчик нажатия кнопки "Загрузить"
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = 
                    "Файлы фигур (*.shapes)|*.shapes|Все файлы (*.*)|*.*";
                openDialog.Title = "Загрузить список фигур";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _currentFilePath = openDialog.FileName;
                        _shapes = DeserializeShapes(_currentFilePath);

                        dataGridViewShapes.DataSource = null;
                        dataGridViewShapes.DataSource = _shapes;

                        if (_shapes.Count > 0)
                        {
                            dataGridViewShapes.ColumnHeadersVisible = true;

                            MessageBox.Show(
                                $"Загружено фигур: " +
                                $"{_shapes.Count}\nФайл: {_currentFilePath}",
                                "Успех",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            dataGridViewShapes.ColumnHeadersVisible = false;

                            MessageBox.Show(
                                "Файл пуст или содержит некорректные данные.",
                                "Предупреждение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Ошибка при загрузке: {ex.Message}",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        _shapes = new List<IShape>();
                        dataGridViewShapes.DataSource = null;
                        dataGridViewShapes.DataSource = _shapes;
                    }
                }
            }
        }

        /// <summary>
        /// Сериализует список фигур в XML-файл
        /// </summary>
        /// <param name="filePath">Путь к файлу для сохранения</param>
        /// <exception cref="Exception">Выбрасывается при ошибке сериализации</exception>
        private void SerializeShapes(string filePath)
        {
            try
            {
                var serializer = new 
                    XmlSerializer(typeof(List<ShapeData>));

                List<ShapeData> shapeDataList = new 
                    List<ShapeData>();
                foreach (var shape in _shapes)
                {
                    shapeDataList.Add(ShapeData.FromShape(shape));
                }

                using (FileStream fs = new 
                    FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, shapeDataList);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка сериализации: " +
                    $"{ex.Message}", ex);
            }
        }

        /// <summary>
        /// Десериализует список фигур из XML-файла
        /// </summary>
        /// <param name="filePath">Путь к файлу для загрузки</param>
        /// <returns>Список загруженных фигур типа <see cref="IShape"/></returns>
        /// <exception cref="Exception">Выбрасывается при ошибке десериализации</exception>
        private List<IShape> DeserializeShapes(string filePath)
        {
            try
            {
                var serializer = new 
                    XmlSerializer(typeof(List<ShapeData>));

                List<ShapeData> shapeDataList;
                using (FileStream fs = 
                    new FileStream(filePath, FileMode.Open))
                {
                    shapeDataList = 
                        (List<ShapeData>)serializer.Deserialize(fs);
                }

                List<IShape> shapes = new List<IShape>();
                foreach (var data in shapeDataList)
                {
                    IShape shape = data.ToShape();
                    if (shape != null)
                    {
                        shapes.Add(shape);
                    }
                }

                return shapes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка десериализации: " +
                    $"{ex.Message}", ex);
            }
        }

        //TODO: remove
        /// <summary>
        /// Вспомогательный класс для сериализации фигур
        /// </summary>
        public class ShapeData
        {
            //TODO: XML
            public string ShapeType { get; set; }
            public double Param1 { get; set; } // Радиус или Длина
            public double Param2 { get; set; } // Ширина 
            public double Param3 { get; set; } // Высота

            public double Length { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
            public double Radius { get; set; }

            public ShapeData() { }

            public static ShapeData FromShape(IShape shape)
            {
                return new ShapeData
                {
                    ShapeType = shape.Name,
                    Length = shape.Length,
                    Width = shape.Width,
                    Height = shape.Height,
                    Radius = shape.Radius,
                };

            }

            /// <summary>
            /// Создаёт фигуру <see cref="IShape"/> из объекта <see cref="ShapeData"
            /// </summary>
            /// <returns>Фигура типа <see cref="IShape"/> или null, если тип неизвестен</returns>
            public IShape ToShape()
            {
                switch (ShapeType)
                {
                    //TODO: refactor
                    case "Sphere":
                        return new Sphere(Param1);
                    case "Pyramid":
                        return new Pyramid(Param1, Param2, Param3);
                    case "Parallelepiped":
                        return new Parallelepiped(Param1, Param2, Param3);
                    default:
                        return null;
                }
            }
        }

        //TODO: RSDN
        /// <summary>
        /// Обработчик нажатия кнопки "Поиск фигуры"
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void btnSearchShape_Click_1(object sender, EventArgs e)
        {
            using (var searchForm = new SearchForm(_shapes))
            {
                searchForm.ShowDialog();
            }
        }

        /// <summary>
        /// Обновляет колонку "Параметры" в DataGridView.
        /// </summary>
        private void UpdateParametersColumn()
        {
            for (int i = 0; i < dataGridViewShapes.Rows.Count; i++)
            {
                if (i < _shapes.Count)
                {
                    dataGridViewShapes.Rows[i].Cells["Parameters"].Value 
                        = _shapes[i].Parameters;
                }
            }
        }
    }
}