using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Вспомогательный класс для настройки DataGridView
    /// </summary>
    public static class DataGridViewHelper
    {
        /// <summary>
        /// Настраивает стандартные колонки для отображения фигур
        /// </summary>
        public static void SetupShapeColumns(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Название",
                DataPropertyName = "Name",
                Width = 150
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Volume",
                HeaderText = "Объём",
                DataPropertyName = "Volume",
                Width = 150
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Parameters",
                HeaderText = "Параметры",
                Width = 300
            });

            dataGridView.DefaultCellStyle.WrapMode = 
                DataGridViewTriState.True;
            dataGridView.RowTemplate.Height = 50;
            dataGridView.AutoSizeColumnsMode = 
                DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
