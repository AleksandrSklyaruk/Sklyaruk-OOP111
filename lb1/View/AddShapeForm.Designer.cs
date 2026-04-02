namespace View
{
    partial class AddShapeForm
    {

        /// <summary>
        /// Контейнер компонентов
        /// </summary>
        private System.ComponentModel.
            IContainer components = null;

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
            components = new System.ComponentModel.Container();
            groupBoxShapeType = new GroupBox();
            radioBattonParallelepiped = new RadioButton();
            radioBattonPyramid = new RadioButton();
            radioBattonSphere = new RadioButton();
            Radius = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            buttonOk = new Button();
            buttonCancel = new Button();
            groupBoxSphere = new GroupBox();
            textRadius = new TextBox();
            groupBoxPyramid = new GroupBox();
            textPyramidHeight = new TextBox();
            textPyramidWidth = new TextBox();
            textPyramidLength = new TextBox();
            groupBoxParallelepiped = new GroupBox();
            txtParallelepipedHeight = new TextBox();
            textParallelepipedWidth = new TextBox();
            textParallelepipedLength = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            groupBoxShapeType.SuspendLayout();
            groupBoxSphere.SuspendLayout();
            groupBoxPyramid.SuspendLayout();
            groupBoxParallelepiped.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxShapeType
            // 
            groupBoxShapeType.Controls.Add(radioBattonParallelepiped);
            groupBoxShapeType.Controls.Add(radioBattonPyramid);
            groupBoxShapeType.Controls.Add(radioBattonSphere);
            groupBoxShapeType.Location = new Point(12, 12);
            groupBoxShapeType.Name = "groupBoxShapeType";
            groupBoxShapeType.Size = new Size(133, 120);
            groupBoxShapeType.TabIndex = 0;
            groupBoxShapeType.TabStop = false;
            // 
            // radioBattonParallelepiped
            // 
            radioBattonParallelepiped.AutoSize = true;
            radioBattonParallelepiped.Location = new Point(6, 79);
            radioBattonParallelepiped.Name = "radioBattonParallelepiped";
            radioBattonParallelepiped.Size = new Size(119, 19);
            radioBattonParallelepiped.TabIndex = 2;
            radioBattonParallelepiped.TabStop = true;
            radioBattonParallelepiped.Text = "Параллелепипед";
            radioBattonParallelepiped.UseVisualStyleBackColor = true;
            radioBattonParallelepiped.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // radioBattonPyramid
            // 
            radioBattonPyramid.AutoSize = true;
            radioBattonPyramid.Location = new Point(6, 51);
            radioBattonPyramid.Name = "radioBattonPyramid";
            radioBattonPyramid.Size = new Size(82, 19);
            radioBattonPyramid.TabIndex = 1;
            radioBattonPyramid.TabStop = true;
            radioBattonPyramid.Text = "Пирамида";
            radioBattonPyramid.UseVisualStyleBackColor = true;
            radioBattonPyramid.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // radioBattonSphere
            // 
            radioBattonSphere.AutoSize = true;
            radioBattonSphere.Location = new Point(6, 23);
            radioBattonSphere.Name = "radioBattonSphere";
            radioBattonSphere.Size = new Size(49, 19);
            radioBattonSphere.TabIndex = 0;
            radioBattonSphere.TabStop = true;
            radioBattonSphere.Text = "Шар";
            radioBattonSphere.UseVisualStyleBackColor = true;
            radioBattonSphere.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // Radius
            // 
            Radius.AutoSize = true;
            Radius.Location = new Point(6, 25);
            Radius.Name = "Radius";
            Radius.Size = new Size(45, 15);
            Radius.TabIndex = 3;
            Radius.Text = "Радиус";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 6;
            label1.Text = "Длина основания";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 56);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 7;
            label2.Text = "Ширина основания";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 85);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 8;
            label3.Text = "Высота ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 83);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 14;
            label4.Text = "Высота ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 55);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 13;
            label5.Text = "Ширина";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 26);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 12;
            label6.Text = "Длина";
            // 
            // buttonOk
            // 
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(12, 167);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 18;
            buttonOk.Text = "ОК";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += ButttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(320, 167);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.RightToLeft = RightToLeft.Yes;
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 19;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // groupBoxSphere
            // 
            groupBoxSphere.Controls.Add(textRadius);
            groupBoxSphere.Controls.Add(Radius);
            groupBoxSphere.Location = new Point(151, 12);
            groupBoxSphere.Name = "groupBoxSphere";
            groupBoxSphere.Size = new Size(244, 120);
            groupBoxSphere.TabIndex = 20;
            groupBoxSphere.TabStop = false;
            // 
            // textRadius
            // 
            textRadius.Location = new Point(69, 22);
            textRadius.Name = "textRadius";
            textRadius.Size = new Size(100, 23);
            textRadius.TabIndex = 24;
            // 
            // groupBoxPyramid
            // 
            groupBoxPyramid.Controls.Add(textPyramidHeight);
            groupBoxPyramid.Controls.Add(label3);
            groupBoxPyramid.Controls.Add(textPyramidWidth);
            groupBoxPyramid.Controls.Add(label2);
            groupBoxPyramid.Controls.Add(textPyramidLength);
            groupBoxPyramid.Controls.Add(label1);
            groupBoxPyramid.Location = new Point(151, 12);
            groupBoxPyramid.Name = "groupBoxPyramid";
            groupBoxPyramid.Size = new Size(244, 120);
            groupBoxPyramid.TabIndex = 21;
            groupBoxPyramid.TabStop = false;
            // 
            // textPyramidHeight
            // 
            textPyramidHeight.Location = new Point(135, 82);
            textPyramidHeight.Name = "textPyramidHeight";
            textPyramidHeight.Size = new Size(100, 23);
            textPyramidHeight.TabIndex = 29;
            // 
            // textPyramidWidth
            // 
            textPyramidWidth.Location = new Point(135, 53);
            textPyramidWidth.Name = "textPyramidWidth";
            textPyramidWidth.Size = new Size(100, 23);
            textPyramidWidth.TabIndex = 28;
            // 
            // textPyramidLength
            // 
            textPyramidLength.Location = new Point(135, 24);
            textPyramidLength.Name = "textPyramidLength";
            textPyramidLength.Size = new Size(100, 23);
            textPyramidLength.TabIndex = 27;
            // 
            // groupBoxParallelepiped
            // 
            groupBoxParallelepiped.Controls.Add(txtParallelepipedHeight);
            groupBoxParallelepiped.Controls.Add(label6);
            groupBoxParallelepiped.Controls.Add(textParallelepipedWidth);
            groupBoxParallelepiped.Controls.Add(textParallelepipedLength);
            groupBoxParallelepiped.Controls.Add(label5);
            groupBoxParallelepiped.Controls.Add(label4);
            groupBoxParallelepiped.Location = new Point(151, 12);
            groupBoxParallelepiped.Name = "groupBoxParallelepiped";
            groupBoxParallelepiped.Size = new Size(244, 120);
            groupBoxParallelepiped.TabIndex = 22;
            groupBoxParallelepiped.TabStop = false;
            // 
            // txtParallelepipedHeight
            // 
            txtParallelepipedHeight.Location = new Point(69, 80);
            txtParallelepipedHeight.Name = "txtParallelepipedHeight";
            txtParallelepipedHeight.Size = new Size(100, 23);
            txtParallelepipedHeight.TabIndex = 35;
            // 
            // textParallelepipedWidth
            // 
            textParallelepipedWidth.Location = new Point(69, 51);
            textParallelepipedWidth.Name = "textParallelepipedWidth";
            textParallelepipedWidth.Size = new Size(100, 23);
            textParallelepipedWidth.TabIndex = 34;
            // 
            // textParallelepipedLength
            // 
            textParallelepipedLength.Location = new Point(69, 22);
            textParallelepipedLength.Name = "textParallelepipedLength";
            textParallelepipedLength.Size = new Size(100, 23);
            textParallelepipedLength.TabIndex = 33;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // AddShapeForm
            // 
            AcceptButton = buttonOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(403, 199);
            Controls.Add(groupBoxPyramid);
            Controls.Add(groupBoxParallelepiped);
            Controls.Add(groupBoxSphere);
            Controls.Add(buttonCancel);
            Controls.Add(groupBoxShapeType);
            Controls.Add(buttonOk);
            MaximizeBox = false;
            Name = "AddShapeForm";
            Text = "Добавить фигуру";
            groupBoxShapeType.ResumeLayout(false);
            groupBoxShapeType.PerformLayout();
            groupBoxSphere.ResumeLayout(false);
            groupBoxSphere.PerformLayout();
            groupBoxPyramid.ResumeLayout(false);
            groupBoxPyramid.PerformLayout();
            groupBoxParallelepiped.ResumeLayout(false);
            groupBoxParallelepiped.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxShapeType;
        private RadioButton radioBattonParallelepiped;
        private RadioButton radioBattonPyramid;
        private RadioButton radioBattonSphere;
        private Label Radius;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button buttonCancel;
        private Button buttonOk;
        private GroupBox groupBoxSphere;
        private GroupBox groupBoxPyramid;
        private GroupBox groupBoxParallelepiped;
        private MaskedTextBox txtRadiu;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textRadius;
        private TextBox textPyramidLength;
        private TextBox textPyramidWidth;
        private TextBox textPyramidHeight;
        private TextBox textParallelepipedLength;
        private TextBox textParallelepipedWidth;
        private TextBox txtParallelepipedHeight;
    }
}