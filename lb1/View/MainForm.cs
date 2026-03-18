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
    public partial class MainForm : Form
    {
        private List<IShape> _shapes;
        private string _currentFilePath = "";

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

        private void btnSearchShape_Click(object sender, EventArgs e)
        {
            using (var searchForm = new SearchForm(_shapes))
            {
                searchForm.ShowDialog();
            }
        }

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
                saveDialog.Filter = "Файлы фигур (*.shapes)|*.shapes|Все файлы (*.*)|*.*";
                saveDialog.Title = "Сохранить список фигур";
                saveDialog.FileName = "figures.shapes";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _currentFilePath = saveDialog.FileName;
                        SerializeShapes(_currentFilePath);

                        MessageBox.Show(
                            $"Данные успешно сохранены в файл:\n{_currentFilePath}",
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Файлы фигур (*.shapes)|*.shapes|Все файлы (*.*)|*.*";
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
                                $"Загружено фигур: {_shapes.Count}\nФайл: {_currentFilePath}",
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

        private void SerializeShapes(string filePath)
        {
            try
            {
                // Создаём сериализатор для списка ShapeData (вспомогательный класс)
                var serializer = new XmlSerializer(typeof(List<ShapeData>));

                // Преобразуем IShape в ShapeData для сериализации
                List<ShapeData> shapeDataList = new List<ShapeData>();
                foreach (var shape in _shapes)
                {
                    shapeDataList.Add(ShapeData.FromShape(shape));
                }

                // Сериализуем в файл
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, shapeDataList);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка сериализации: {ex.Message}", ex);
            }
        }

        // ✅ Метод десериализации (загрузка из XML)
        private List<IShape> DeserializeShapes(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<ShapeData>));

                List<ShapeData> shapeDataList;
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    shapeDataList = (List<ShapeData>)serializer.Deserialize(fs);
                }

                // Преобразуем ShapeData обратно в IShape
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
                throw new Exception($"Ошибка десериализации: {ex.Message}", ex);
            }
        }

        // ✅ Вспомогательный класс для сериализации
        // Нужен потому что интерфейс IShape нельзя сериализовать напрямую
        public class ShapeData
        {
            public string ShapeType { get; set; }  // "Sphere", "Pyramid", "Parallelepiped"
            public double Param1 { get; set; }     // Радиус или Длина
            public double Param2 { get; set; }     // Ширина (для пирамиды и параллелепипеда)
            public double Param3 { get; set; }     // Высота

            // Конструктор по умолчанию (требуется для сериализации)
            public ShapeData() { }

            // Создаём ShapeData из IShape
            public static ShapeData FromShape(IShape shape)
            {
                ShapeData data = new ShapeData();

                if (shape is Sphere sphere)
                {
                    data.ShapeType = "Sphere";
                    data.Param1 = sphere.Radius;
                }
                else if (shape is Pyramid pyramid)
                {
                    data.ShapeType = "Pyramid";
                    data.Param1 = pyramid.Length;
                    data.Param2 = pyramid.Width;
                    data.Param3 = pyramid.Height;
                }
                else if (shape is Parallelepiped parallelepiped)
                {
                    data.ShapeType = "Parallelepiped";
                    data.Param1 = parallelepiped.Length;
                    data.Param2 = parallelepiped.Width;
                    data.Param3 = parallelepiped.Height;
                }

                return data;
            }

            // Создаём IShape из ShapeData
            public IShape ToShape()
            {
                switch (ShapeType)
                {
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

        private void btnSearchShape_Click_1(object sender, EventArgs e)
        {
            using (var searchForm = new SearchForm(_shapes))
            {
                searchForm.ShowDialog();
            }
        }
    }
}
