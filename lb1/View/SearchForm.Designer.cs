namespace View
{
    partial class SearchForm
    {
        /// <summary>
        /// Контейнер компонентов
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освобождает ресурсы, используемые формой
        /// </summary>
        /// <param name="disposing">
        /// true, если вызван управляемый ресурс</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Требуемый метод для поддержки конструктора
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxSearchCriteria = new GroupBox();
            textBoxSearchValue = new TextBox();
            labelSearchValue = new Label();
            comboBoxSearchField = new ComboBox();
            labelSearchField = new Label();
            buttonSearch = new Button();
            buttonClose = new Button();
            groupBoxResults = new GroupBox();
            dataGridViewResults = new DataGridView();
            groupBoxSearchCriteria.SuspendLayout();
            groupBoxResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // groupBoxSearchCriteria
            // 
            groupBoxSearchCriteria.Controls.Add(textBoxSearchValue);
            groupBoxSearchCriteria.Controls.Add(labelSearchValue);
            groupBoxSearchCriteria.Controls.Add(comboBoxSearchField);
            groupBoxSearchCriteria.Controls.Add(labelSearchField);
            groupBoxSearchCriteria.Location = new Point(12, 12);
            groupBoxSearchCriteria.Name = "groupBoxSearchCriteria";
            groupBoxSearchCriteria.Size = new Size(770, 98);
            groupBoxSearchCriteria.TabIndex = 0;
            groupBoxSearchCriteria.TabStop = false;
            groupBoxSearchCriteria.Text = "Критерии поиска";
            // 
            // textBoxSearchValue
            // 
            textBoxSearchValue.Location = new Point(183, 49);
            textBoxSearchValue.Name = "textBoxSearchValue";
            textBoxSearchValue.Size = new Size(130, 23);
            textBoxSearchValue.TabIndex = 4;
            // 
            // labelSearchValue
            // 
            labelSearchValue.AutoSize = true;
            labelSearchValue.Location = new Point(183, 31);
            labelSearchValue.Name = "labelSearchValue";
            labelSearchValue.Size = new Size(114, 15);
            labelSearchValue.TabIndex = 3;
            labelSearchValue.Text = "Искомое значение:";
            labelSearchValue.TextAlign = ContentAlignment.TopRight;
            // 
            // comboBoxSearchField
            // 
            comboBoxSearchField.FormattingEnabled = true;
            comboBoxSearchField.Items.AddRange(new object[] { "Название фигуры", "Объём", "Информация" });
            comboBoxSearchField.Location = new Point(6, 49);
            comboBoxSearchField.Name = "comboBoxSearchField";
            comboBoxSearchField.Size = new Size(136, 23);
            comboBoxSearchField.TabIndex = 2;
            // 
            // labelSearchField
            // 
            labelSearchField.AutoSize = true;
            labelSearchField.Location = new Point(23, 31);
            labelSearchField.Name = "labelSearchField";
            labelSearchField.Size = new Size(100, 15);
            labelSearchField.TabIndex = 1;
            labelSearchField.Text = "Поле для поиска";
            labelSearchField.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(28, 401);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "Найти";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += ButtonSearch_Click;
            // 
            // buttonClose
            // 
            buttonClose.DialogResult = DialogResult.Cancel;
            buttonClose.Location = new Point(671, 401);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 6;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += ButtonClose_Click;
            // 
            // groupBoxResults
            // 
            groupBoxResults.Controls.Add(dataGridViewResults);
            groupBoxResults.Location = new Point(12, 130);
            groupBoxResults.Name = "groupBoxResults";
            groupBoxResults.Size = new Size(776, 248);
            groupBoxResults.TabIndex = 5;
            groupBoxResults.TabStop = false;
            groupBoxResults.Text = "Результаты поиска";
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(6, 22);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.Size = new Size(764, 209);
            dataGridViewResults.TabIndex = 0;
            // 
            // SearchForm
            // 
            AcceptButton = buttonSearch;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonClose;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxResults);
            Controls.Add(buttonClose);
            Controls.Add(groupBoxSearchCriteria);
            Controls.Add(buttonSearch);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SearchForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Поиск фигур";
            groupBoxSearchCriteria.ResumeLayout(false);
            groupBoxSearchCriteria.PerformLayout();
            groupBoxResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxSearchCriteria;
        private Label labelSearchField;
        private ComboBox comboBoxSearchField;
        private Label labelSearchValue;
        private Button buttonSearch;
        private Button buttonClose;
        private GroupBox groupBoxResults;
        private DataGridView dataGridViewResults;
        private TextBox textBoxSearchValue;
    }
}