using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphBase
{
    public partial class Step_by_step : Form
    {
        public static int CurrentSlide;
        public static Graphics g;
        public static Step_by_step step_By_Step;
        public static Bitmap canvas;
        public int NumberSlides
        {
            get
            { return MinimumTree.graph.History.Count; }
        }
        public Step_by_step()
        {
            CurrentSlide = 0;
            InitializeComponent();
            step_By_Step = this;
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = MinimumTree.graph.g;
            pictureBox1.Image = canvas;
            MinimumTree.graph.canvas = pictureBox1;
            MinimumTree.graph.g = Graphics.FromImage(canvas); ;
            Solution.solution.Enabled = false;
            MinimumTree.graph.FillDotColors();
            label3.Text = MinimumTree.MainForm.comboBox.SelectedItem as string;
            label3.Text += "'s algorithm";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CurrentSlide > 0)
            {
                CurrentSlide--;
                label1.Text = $"Step: {CurrentSlide}";
                MinimumTree.graph.minTree = MinimumTree.graph.History[CurrentSlide];
                MinimumTree.graph.DrawFromHistory(CurrentSlide);
                TableFill();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentSlide < NumberSlides - 1)
            {
                CurrentSlide++;
                label1.Text = $"Step: {CurrentSlide}";
                MinimumTree.graph.minTree = MinimumTree.graph.History[CurrentSlide];
                MinimumTree.graph.DrawFromHistory(CurrentSlide);
                TableFill();
            }
        }

        private void Step_by_step_Load(object sender, EventArgs e)
        {
            MinimumTree.graph.DrawFromHistory(CurrentSlide);
            TableFill();
        }
        private void TableFill()
        {
            int i = dataGridView1.Rows.Count;
            while (i < MinimumTree.graph.Size)
            {
                dataGridView1.Columns.Add($"{i + 1}", $"{i + 1}");
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = $"{i + 1}";
                i++;
            }
            while (i < MinimumTree.graph.Size)
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
                if (i > 1)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                }
            }
            for (int k = 0; k < MinimumTree.graph.Size; k++)
            {
                for (int j = 0; j < MinimumTree.graph.Size; j++)
                {
                    dataGridView1[k, j].Value = MinimumTree.graph.minTree[k, j] ? 1 : "";
                }
            }
            dataGridView1.ClearSelection();
            dataGridView1.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Step_by_step_FormClosing(object sender, FormClosingEventArgs e)
        {
            Solution.solution.Enabled = true;
            MinimumTree.graph.g = g;
            MinimumTree.graph.canvas = Solution.solution.pictureBox;
            MinimumTree.graph.minTree = MinimumTree.graph.History[NumberSlides - 1];
        }


        private void SaveHistoryImageButton_Click(object sender, EventArgs e)
        {
            MinimumTree.graph.SaveHistoryFolder(canvas);
        }

        private void SaveHistoryTextButton_Click(object sender, EventArgs e)
        {
            MinimumTree.graph.SaveHistoryText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MinimumTree.graph.SaveSlideText(CurrentSlide);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MinimumTree.graph.SaveImageGraph(canvas);
        }
    }
}
