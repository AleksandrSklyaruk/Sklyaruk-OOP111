namespace View
{
    partial class AddShapeForm
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
            components = new System.ComponentModel.Container();
            groupBoxShapeType = new GroupBox();
            rbParallelepiped = new RadioButton();
            rbPyramid = new RadioButton();
            rbSphere = new RadioButton();
            Radius = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            butOk = new Button();
            btnCancel = new Button();
            groupBoxSphere = new GroupBox();
            txtRadius = new TextBox();
            groupBoxPyramid = new GroupBox();
            txtPyramidHeight = new TextBox();
            txtPyramidWidth = new TextBox();
            txtPyramidLength = new TextBox();
            groupBoxParallelepiped = new GroupBox();
            txtParallelepipedHeight = new TextBox();
            txtParallelepipedWidth = new TextBox();
            txtParallelepipedLength = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            groupBoxShapeType.SuspendLayout();
            groupBoxSphere.SuspendLayout();
            groupBoxPyramid.SuspendLayout();
            groupBoxParallelepiped.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxShapeType
            // 
            groupBoxShapeType.Controls.Add(rbParallelepiped);
            groupBoxShapeType.Controls.Add(rbPyramid);
            groupBoxShapeType.Controls.Add(rbSphere);
            groupBoxShapeType.Location = new Point(12, 12);
            groupBoxShapeType.Name = "groupBoxShapeType";
            groupBoxShapeType.Size = new Size(173, 224);
            groupBoxShapeType.TabIndex = 0;
            groupBoxShapeType.TabStop = false;
            groupBoxShapeType.Text = "Тип фигуры";
            groupBoxShapeType.Enter += groupBox1_Enter;
            // 
            // rbParallelepiped
            // 
            rbParallelepiped.AutoSize = true;
            rbParallelepiped.Location = new Point(25, 144);
            rbParallelepiped.Name = "rbParallelepiped";
            rbParallelepiped.Size = new Size(119, 19);
            rbParallelepiped.TabIndex = 2;
            rbParallelepiped.TabStop = true;
            rbParallelepiped.Text = "Параллелепипед";
            rbParallelepiped.UseVisualStyleBackColor = true;
            // 
            // rbPyramid
            // 
            rbPyramid.AutoSize = true;
            rbPyramid.Location = new Point(25, 98);
            rbPyramid.Name = "rbPyramid";
            rbPyramid.Size = new Size(82, 19);
            rbPyramid.TabIndex = 1;
            rbPyramid.TabStop = true;
            rbPyramid.Text = "Пирамида";
            rbPyramid.UseVisualStyleBackColor = true;
            rbPyramid.CheckedChanged += rbPyramid_CheckedChanged;
            // 
            // rbSphere
            // 
            rbSphere.AutoSize = true;
            rbSphere.Location = new Point(25, 52);
            rbSphere.Name = "rbSphere";
            rbSphere.Size = new Size(49, 19);
            rbSphere.TabIndex = 0;
            rbSphere.TabStop = true;
            rbSphere.Text = "Шар";
            rbSphere.UseVisualStyleBackColor = true;
            rbSphere.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // Radius
            // 
            Radius.AutoSize = true;
            Radius.Location = new Point(49, 34);
            Radius.Name = "Radius";
            Radius.Size = new Size(45, 15);
            Radius.TabIndex = 3;
            Radius.Text = "Радиус";
            Radius.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 34);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 6;
            label1.Text = "Длина основания";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 91);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 7;
            label2.Text = "Ширина основания";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 145);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 8;
            label3.Text = "Высота ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 145);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 14;
            label4.Text = "Высота ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 91);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 13;
            label5.Text = "Ширина";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 33);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 12;
            label6.Text = "Длина";
            label6.Click += label6_Click;
            // 
            // butOk
            // 
            butOk.DialogResult = DialogResult.OK;
            butOk.Location = new Point(62, 385);
            butOk.Name = "butOk";
            butOk.Size = new Size(75, 23);
            butOk.TabIndex = 18;
            butOk.Text = "ОК";
            butOk.UseVisualStyleBackColor = true;
            butOk.Click += butOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(640, 394);
            btnCancel.Name = "btnCancel";
            btnCancel.RightToLeft = RightToLeft.Yes;
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // groupBoxSphere
            // 
            groupBoxSphere.Controls.Add(txtRadius);
            groupBoxSphere.Controls.Add(Radius);
            groupBoxSphere.Location = new Point(212, 12);
            groupBoxSphere.Name = "groupBoxSphere";
            groupBoxSphere.Size = new Size(150, 224);
            groupBoxSphere.TabIndex = 20;
            groupBoxSphere.TabStop = false;
            groupBoxSphere.Text = "Параметры шара";
            // 
            // txtRadius
            // 
            txtRadius.Location = new Point(22, 55);
            txtRadius.Name = "txtRadius";
            txtRadius.Size = new Size(100, 23);
            txtRadius.TabIndex = 24;
            txtRadius.KeyPress += txtRadius_KeyPress;
            // 
            // groupBoxPyramid
            // 
            groupBoxPyramid.Controls.Add(txtPyramidHeight);
            groupBoxPyramid.Controls.Add(label3);
            groupBoxPyramid.Controls.Add(txtPyramidWidth);
            groupBoxPyramid.Controls.Add(label2);
            groupBoxPyramid.Controls.Add(txtPyramidLength);
            groupBoxPyramid.Controls.Add(label1);
            groupBoxPyramid.Location = new Point(381, 12);
            groupBoxPyramid.Name = "groupBoxPyramid";
            groupBoxPyramid.Size = new Size(140, 224);
            groupBoxPyramid.TabIndex = 21;
            groupBoxPyramid.TabStop = false;
            groupBoxPyramid.Text = "Параметры пирамиды";
            // 
            // txtPyramidHeight
            // 
            txtPyramidHeight.Location = new Point(16, 161);
            txtPyramidHeight.Name = "txtPyramidHeight";
            txtPyramidHeight.Size = new Size(100, 23);
            txtPyramidHeight.TabIndex = 29;
            txtPyramidHeight.KeyPress += txtPyramidHeight_KeyPress;
            // 
            // txtPyramidWidth
            // 
            txtPyramidWidth.Location = new Point(16, 107);
            txtPyramidWidth.Name = "txtPyramidWidth";
            txtPyramidWidth.Size = new Size(100, 23);
            txtPyramidWidth.TabIndex = 28;
            txtPyramidWidth.KeyPress += txtPyramidWidth_KeyPress;
            // 
            // txtPyramidLength
            // 
            txtPyramidLength.Location = new Point(16, 55);
            txtPyramidLength.Name = "txtPyramidLength";
            txtPyramidLength.Size = new Size(100, 23);
            txtPyramidLength.TabIndex = 27;
            txtPyramidLength.KeyPress += txtPyramidLength_KeyPress;
            // 
            // groupBoxParallelepiped
            // 
            groupBoxParallelepiped.Controls.Add(txtParallelepipedHeight);
            groupBoxParallelepiped.Controls.Add(label6);
            groupBoxParallelepiped.Controls.Add(txtParallelepipedWidth);
            groupBoxParallelepiped.Controls.Add(txtParallelepipedLength);
            groupBoxParallelepiped.Controls.Add(label5);
            groupBoxParallelepiped.Controls.Add(label4);
            groupBoxParallelepiped.Location = new Point(543, 12);
            groupBoxParallelepiped.Name = "groupBoxParallelepiped";
            groupBoxParallelepiped.Size = new Size(151, 224);
            groupBoxParallelepiped.TabIndex = 22;
            groupBoxParallelepiped.TabStop = false;
            groupBoxParallelepiped.Text = "Параметры параллелепипеда";
            // 
            // txtParallelepipedHeight
            // 
            txtParallelepipedHeight.Location = new Point(7, 161);
            txtParallelepipedHeight.Name = "txtParallelepipedHeight";
            txtParallelepipedHeight.Size = new Size(100, 23);
            txtParallelepipedHeight.TabIndex = 35;
            txtParallelepipedHeight.KeyPress += txtParallelepipedHeight_KeyPress;
            // 
            // txtParallelepipedWidth
            // 
            txtParallelepipedWidth.Location = new Point(6, 107);
            txtParallelepipedWidth.Name = "txtParallelepipedWidth";
            txtParallelepipedWidth.Size = new Size(100, 23);
            txtParallelepipedWidth.TabIndex = 34;
            txtParallelepipedWidth.KeyPress += txtParallelepipedWidth_KeyPress;
            // 
            // txtParallelepipedLength
            // 
            txtParallelepipedLength.Location = new Point(6, 53);
            txtParallelepipedLength.Name = "txtParallelepipedLength";
            txtParallelepipedLength.Size = new Size(100, 23);
            txtParallelepipedLength.TabIndex = 33;
            txtParallelepipedLength.KeyPress += txtParallelepipedLength_KeyPress;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // AddShapeForm
            // 
            AcceptButton = butOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxParallelepiped);
            Controls.Add(groupBoxPyramid);
            Controls.Add(groupBoxSphere);
            Controls.Add(btnCancel);
            Controls.Add(groupBoxShapeType);
            Controls.Add(butOk);
            Name = "AddShapeForm";
            Text = "AddShapeForm";
            Load += AddShapeForm_Load;
            KeyPress += AddShapeForm_KeyPress;
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
        private RadioButton rbParallelepiped;
        private RadioButton rbPyramid;
        private RadioButton rbSphere;
        private Label Radius;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnCancel;
        private Button butOk;
        private GroupBox groupBoxSphere;
        private GroupBox groupBoxPyramid;
        private GroupBox groupBoxParallelepiped;
        private MaskedTextBox txtRadiu;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtRadius;
        private TextBox txtPyramidLength;
        private TextBox txtPyramidWidth;
        private TextBox txtPyramidHeight;
        private TextBox txtParallelepipedLength;
        private TextBox txtParallelepipedWidth;
        private TextBox txtParallelepipedHeight;
    }
}