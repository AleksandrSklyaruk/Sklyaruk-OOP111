namespace View
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxSearchCriteria = new GroupBox();
            textBoxSearchValue = new TextBox();
            labelSearchValue = new Label();
            comboBoxSearchField = new ComboBox();
            labelSearchField = new Label();
            btnSearch = new Button();
            btnClose = new Button();
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
            textBoxSearchValue.Location = new Point(173, 49);
            textBoxSearchValue.Name = "textBoxSearchValue";
            textBoxSearchValue.Size = new Size(114, 23);
            textBoxSearchValue.TabIndex = 4;
            // 
            // labelSearchValue
            // 
            labelSearchValue.AutoSize = true;
            labelSearchValue.Location = new Point(173, 31);
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
            comboBoxSearchField.Size = new Size(121, 23);
            comboBoxSearchField.TabIndex = 2;
            // 
            // labelSearchField
            // 
            labelSearchField.AutoSize = true;
            labelSearchField.Location = new Point(16, 31);
            labelSearchField.Name = "labelSearchField";
            labelSearchField.Size = new Size(100, 15);
            labelSearchField.TabIndex = 1;
            labelSearchField.Text = "Поле для поиска";
            labelSearchField.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(28, 401);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Найти";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(671, 401);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 6;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
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
            AcceptButton = btnSearch;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxResults);
            Controls.Add(btnClose);
            Controls.Add(groupBoxSearchCriteria);
            Controls.Add(btnSearch);
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
        private TextBox textBoxSearchValue;
        private Label labelSearchValue;
        private Button btnSearch;
        private Button btnClose;
        private GroupBox groupBoxResults;
        private DataGridView dataGridViewResults;
    }
}