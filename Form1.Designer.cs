﻿namespace GraphBase
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            dataGridView2 = new DataGridView();
            radioButton4 = new RadioButton();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(540, 15);
            button2.Name = "button2";
            button2.Size = new Size(90, 66);
            button2.TabIndex = 7;
            button2.Text = "Step by step";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(656, 17);
            button3.Name = "button3";
            button3.Size = new Size(80, 64);
            button3.TabIndex = 8;
            button3.Text = "Save in file";
            button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 245);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(153, 67);
            dataGridView1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 220);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 11;
            label1.Text = "Matrix";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 44);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 12;
            label2.Text = "Method";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(6, 338);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(157, 72);
            dataGridView2.TabIndex = 13;
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
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(84, 188);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(79, 27);
            numericUpDown1.TabIndex = 15;
            numericUpDown1.MouseDown += numericUpDown1_MouseDown;
            numericUpDown1.MouseUp += numericUpDown1_MouseUp;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(radioButton4);
            Controls.Add(dataGridView2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView2;
        private RadioButton radioButton4;
        private NumericUpDown numericUpDown1;
        private Label label3;
    }
}