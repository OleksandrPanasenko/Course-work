namespace GraphBase
{
    partial class MinimumTree
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            contextMenuStrip1 = new ContextMenuStrip(components);
            comboBox1 = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            MatrixOnForm = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            radioButton4 = new RadioButton();
            NodesNumber = new NumericUpDown();
            label3 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            saveFileDialog1 = new SaveFileDialog();
            button4 = new Button();
            button5 = new Button();
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            HelpButton = new Button();
            ((System.ComponentModel.ISupportInitialize)MatrixOnForm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NodesNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(6, 112);
            button1.Name = "button1";
            button1.Size = new Size(134, 70);
            button1.TabIndex = 0;
            button1.Text = "Calculate!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(13, 17);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(97, 24);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "New Point";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(116, 17);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(74, 24);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "Delete";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(196, 17);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(106, 24);
            radioButton3.TabIndex = 3;
            radioButton3.TabStop = true;
            radioButton3.Text = "Move point";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "(no mode)";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Prim", "Kruskal", "Boruvka" });
            comboBox1.Location = new Point(6, 78);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(97, 28);
            comboBox1.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(709, 12);
            button2.Name = "button2";
            button2.Size = new Size(90, 71);
            button2.TabIndex = 7;
            button2.Text = "Get from file";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(612, 12);
            button3.Name = "button3";
            button3.Size = new Size(91, 71);
            button3.TabIndex = 8;
            button3.Text = "Save matrix in file";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // MatrixOnForm
            // 
            MatrixOnForm.AllowUserToAddRows = false;
            MatrixOnForm.AllowUserToDeleteRows = false;
            MatrixOnForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            MatrixOnForm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MatrixOnForm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MatrixOnForm.Location = new Point(6, 244);
            MatrixOnForm.Name = "MatrixOnForm";
            MatrixOnForm.RowHeadersWidth = 51;
            MatrixOnForm.RowTemplate.Height = 29;
            MatrixOnForm.Size = new Size(184, 166);
            MatrixOnForm.TabIndex = 10;
            MatrixOnForm.CellEndEdit += MatrixOnForm_CellEndEdit;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 220);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 11;
            label1.Text = "Matrix";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 55);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 12;
            label2.Text = "Method";
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(308, 17);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(111, 24);
            radioButton4.TabIndex = 14;
            radioButton4.TabStop = true;
            radioButton4.Text = "Connections";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // NodesNumber
            // 
            NodesNumber.Location = new Point(79, 183);
            NodesNumber.Name = "NodesNumber";
            NodesNumber.Size = new Size(79, 27);
            NodesNumber.TabIndex = 15;
            NodesNumber.ValueChanged += NodesNumber_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 185);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 16;
            label3.Text = "Vertices";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileOk += saveFileDialog1_FileOk;
            // 
            // button4
            // 
            button4.Location = new Point(425, 12);
            button4.Name = "button4";
            button4.Size = new Size(93, 71);
            button4.TabIndex = 17;
            button4.Text = "Random Graph";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(524, 12);
            button5.Name = "button5";
            button5.Size = new Size(82, 71);
            button5.TabIndex = 18;
            button5.Text = "Save picture";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(187, 78);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(612, 369);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // HelpButton
            // 
            HelpButton.BackColor = SystemColors.Info;
            HelpButton.Location = new Point(116, 52);
            HelpButton.Name = "HelpButton";
            HelpButton.Size = new Size(41, 37);
            HelpButton.TabIndex = 20;
            HelpButton.Text = "?";
            HelpButton.UseVisualStyleBackColor = false;
            HelpButton.Click += HelpButton_Click;
            // 
            // MinimumTree
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(813, 457);
            Controls.Add(HelpButton);
            Controls.Add(pictureBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label3);
            Controls.Add(NodesNumber);
            Controls.Add(radioButton4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MatrixOnForm);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button1);
            Name = "MinimumTree";
            Text = "Minimum Tree";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)MatrixOnForm).EndInit();
            ((System.ComponentModel.ISupportInitialize)NodesNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox comboBox1;
        private Button button2;
        private Button button3;
        private DataGridView MatrixOnForm;
        private Label label1;
        private Label label2;
        private RadioButton radioButton4;
        private NumericUpDown NodesNumber;
        private Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private SaveFileDialog saveFileDialog1;
        private Button button4;
        private Button button5;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private Button HelpButton;
    }
}
