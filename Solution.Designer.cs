namespace GraphBase
{
    partial class Solution
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
            saveFileDialog1 = new SaveFileDialog();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            pictureBox2 = new PictureBox();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 9);
            button1.Name = "button1";
            button1.Size = new Size(88, 75);
            button1.TabIndex = 0;
            button1.Text = "Save solution to file (text)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(110, 9);
            button2.Name = "button2";
            button2.Size = new Size(92, 75);
            button2.TabIndex = 1;
            button2.Text = "Save to file (full picture)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.ImeMode = ImeMode.Off;
            dataGridView1.Location = new Point(12, 117);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(761, 465);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button3
            // 
            button3.Location = new Point(208, 9);
            button3.Name = "button3";
            button3.Size = new Size(101, 75);
            button3.TabIndex = 3;
            button3.Text = "Save to file (connections only)";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(492, 13);
            button4.Name = "button4";
            button4.Size = new Size(126, 71);
            button4.TabIndex = 4;
            button4.Text = "Show step-by-step solution";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(624, 13);
            button5.Name = "button5";
            button5.Size = new Size(127, 71);
            button5.TabIndex = 5;
            button5.Text = "Complexity data";
            button5.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(779, 117);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(718, 465);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // button6
            // 
            button6.Location = new Point(339, 33);
            button6.Name = "button6";
            button6.Size = new Size(119, 30);
            button6.TabIndex = 8;
            button6.Text = "Close";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Solution
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1524, 605);
            Controls.Add(button6);
            Controls.Add(pictureBox2);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Solution";
            Text = "Solution";
            FormClosing += Solution_FormClosing;
            Load += Solution_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button4;
        private Button button5;
        private PictureBox pictureBox2;
        private Button button6;
    }
}