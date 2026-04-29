namespace View
{
    partial class MainForm
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
            groupBox1 = new GroupBox();
            dataGridViewShapes = new DataGridView();
            buttonAddShape = new Button();
            buttonRemoveShape = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            buttonSearchShape = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShapes).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(dataGridViewShapes);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(782, 327);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // dataGridViewShapes
            // 
            dataGridViewShapes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShapes.Location = new Point(6, 22);
            dataGridViewShapes.Name = "dataGridViewShapes";
            dataGridViewShapes.Size = new Size(764, 297);
            dataGridViewShapes.TabIndex = 0;
            // 
            // buttonAddShape
            // 
            buttonAddShape.BackgroundImageLayout = ImageLayout.None;
            buttonAddShape.DialogResult = DialogResult.OK;
            buttonAddShape.ForeColor = SystemColors.ActiveCaptionText;
            buttonAddShape.Location = new Point(18, 345);
            buttonAddShape.Name = "buttonAddShape";
            buttonAddShape.Size = new Size(141, 23);
            buttonAddShape.TabIndex = 1;
            buttonAddShape.Text = "Добавить фигуру";
            buttonAddShape.UseVisualStyleBackColor = true;
            buttonAddShape.Click += ButtonAddShape_Click;
            // 
            // buttonRemoveShape
            // 
            buttonRemoveShape.BackColor = Color.FromArgb(224, 224, 224);
            buttonRemoveShape.Location = new Point(18, 374);
            buttonRemoveShape.Name = "buttonRemoveShape";
            buttonRemoveShape.Size = new Size(141, 23);
            buttonRemoveShape.TabIndex = 2;
            buttonRemoveShape.Text = "Удалить  фигуру";
            buttonRemoveShape.UseVisualStyleBackColor = false;
            buttonRemoveShape.Click += ButtonRemoveShape_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(641, 345);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(141, 23);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(641, 374);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(141, 23);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Загрузить";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += ButtonLoad_Click;
            // 
            // buttonSearchShape
            // 
            buttonSearchShape.Location = new Point(165, 345);
            buttonSearchShape.Name = "buttonSearchShape";
            buttonSearchShape.Size = new Size(141, 23);
            buttonSearchShape.TabIndex = 5;
            buttonSearchShape.Text = "Поиск фигуры";
            buttonSearchShape.UseVisualStyleBackColor = true;
            buttonSearchShape.Click += ButtonSearchShape_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 401);
            Controls.Add(buttonSearchShape);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(buttonRemoveShape);
            Controls.Add(buttonAddShape);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Главня страница";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewShapes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridViewShapes;
        private Button buttonAddShape;
        private Button buttonRemoveShape;
        private Button buttonSave;
        private Button buttonLoad;
        private Button buttonSearchShape;

    }
}