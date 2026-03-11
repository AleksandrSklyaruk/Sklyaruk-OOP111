using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class MainForm : Form
    {
        // 1. Сначала объявляем ПОЛЕ на уровне класса
        private List<IShape> _shapes;

        // 2. Потом конструктор
        public MainForm()
        {
            InitializeComponent();

            // 3. Инициализируем поле в конструкторе
            _shapes = new List<IShape>();
        }
    }
}
