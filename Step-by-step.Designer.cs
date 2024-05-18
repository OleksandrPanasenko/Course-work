
namespace GraphBase
{
    partial class Step_by_step
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            CloseButton = new Button();
            SaveSlideTextButton = new Button();
            SaveHistoryTextButton = new Button();
            button6 = new Button();
            SaveHistoryImageButton = new Button();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(24, 20);
            button1.Name = "button1";
            button1.Size = new Size(63, 48);
            button1.TabIndex = 0;
            button1.Text = "<=";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(115, 22);
            button2.Name = "button2";
            button2.Size = new Size(64, 48);
            button2.TabIndex = 1;
            button2.Text = "=>";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 88);
            label1.Name = "label1";
            label1.Size = new Size(18, 20);
            label1.TabIndex = 3;
            label1.Text = "#";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(439, 9);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 4;
            label2.Text = "Save in file";
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(196, 16);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(76, 57);
            CloseButton.TabIndex = 5;
            CloseButton.Text = "close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += button3_Click;
            // 
            // SaveSlideTextButton
            // 
            SaveSlideTextButton.Location = new Point(389, 47);
            SaveSlideTextButton.Name = "SaveSlideTextButton";
            SaveSlideTextButton.Size = new Size(89, 72);
            SaveSlideTextButton.TabIndex = 6;
            SaveSlideTextButton.Text = "Current position (text)";
            SaveSlideTextButton.UseVisualStyleBackColor = true;
            SaveSlideTextButton.Click += button4_Click;
            // 
            // SaveHistoryTextButton
            // 
            SaveHistoryTextButton.Location = new Point(484, 47);
            SaveHistoryTextButton.Name = "SaveHistoryTextButton";
            SaveHistoryTextButton.Size = new Size(91, 72);
            SaveHistoryTextButton.TabIndex = 7;
            SaveHistoryTextButton.Text = "Whole solution (text)";
            SaveHistoryTextButton.Click += SaveHistoryTextButton_Click;
            // 
            // button6
            // 
            button6.Location = new Point(389, 125);
            button6.Name = "button6";
            button6.Size = new Size(89, 75);
            button6.TabIndex = 8;
            button6.Text = "Current (image)";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // SaveHistoryImageButton
            // 
            SaveHistoryImageButton.Location = new Point(484, 125);
            SaveHistoryImageButton.Name = "SaveHistoryImageButton";
            SaveHistoryImageButton.Size = new Size(91, 75);
            SaveHistoryImageButton.TabIndex = 9;
            SaveHistoryImageButton.Text = "All solution (image)";
            SaveHistoryImageButton.UseVisualStyleBackColor = true;
            SaveHistoryImageButton.Click += SaveHistoryImageButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(721, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(704, 663);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 206);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(693, 469);
            dataGridView1.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(24, 135);
            label3.Name = "label3";
            label3.Size = new Size(124, 41);
            label3.TabIndex = 12;
            label3.Text = "Method";
            // 
            // Step_by_step
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 688);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Controls.Add(SaveHistoryImageButton);
            Controls.Add(button6);
            Controls.Add(SaveHistoryTextButton);
            Controls.Add(SaveSlideTextButton);
            Controls.Add(CloseButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Step_by_step";
            Text = "Step_by_step";
            FormClosing += Step_by_step_FormClosing;
            Load += Step_by_step_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void SaveHistoryButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Button CloseButton;
        private Button SaveSlideTextButton;
        private Button SaveHistoryTextButton;
        private Button button6;
        private Button SaveHistoryImageButton;
        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Label label3;
    }
}