namespace View
{
    partial class MainForm
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
            groupBox1 = new GroupBox();
            dataGridViewShapes = new DataGridView();
            btnAddShape = new Button();
            btnRemoveShape = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShapes).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewShapes);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 369);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBoxShapes";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // dataGridViewShapes
            // 
            dataGridViewShapes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShapes.Location = new Point(6, 23);
            dataGridViewShapes.Name = "dataGridViewShapes";
            dataGridViewShapes.Size = new Size(764, 340);
            dataGridViewShapes.TabIndex = 0;
            dataGridViewShapes.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnAddShape
            // 
            btnAddShape.DialogResult = DialogResult.OK;
            btnAddShape.Location = new Point(43, 399);
            btnAddShape.Name = "btnAddShape";
            btnAddShape.Size = new Size(141, 23);
            btnAddShape.TabIndex = 1;
            btnAddShape.Text = "Добавить фигуру";
            btnAddShape.UseVisualStyleBackColor = true;
            btnAddShape.Click += btnAddShape_Click;
            // 
            // btnRemoveShape
            // 
            btnRemoveShape.Location = new Point(600, 399);
            btnRemoveShape.Name = "btnRemoveShape";
            btnRemoveShape.Size = new Size(129, 23);
            btnRemoveShape.TabIndex = 2;
            btnRemoveShape.Text = "Удалить  фигуру";
            btnRemoveShape.UseVisualStyleBackColor = true;
            btnRemoveShape.Click += btnRemoveShape_Click_1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemoveShape);
            Controls.Add(btnAddShape);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "Form2";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewShapes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridViewShapes;
        private Button btnAddShape;
        private Button btnRemoveShape;
    }
}