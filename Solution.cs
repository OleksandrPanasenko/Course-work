using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GraphBase
{
    public partial class Solution : Form
    {
        public static Graphics g;
        public static Solution solution;
        public static Bitmap canvas;
        public PictureBox pictureBox
        {
            get { return pictureBox2; }
        }
        public Solution()
        {
            InitializeComponent();
            solution = this;
            canvas = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g = Form1.graph.g;
            pictureBox2.Image = canvas;
            Form1.graph.canvas = pictureBox2;
            Form1.graph.g = Graphics.FromImage(canvas); ;
            Form1.MainForm.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Solution_Load(object sender, EventArgs e)
        {
            Form1.graph.DrawGraph();
            TableFill();
        }
        private void TableFill()
        {
            int i = dataGridView1.Rows.Count;
            while (i < Form1.graph.Size)
            {
                dataGridView1.Columns.Add($"{i + 1}", $"{i + 1}");
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = $"{i + 1}";
                i++;
            }
            while (i < Form1.graph.Size)
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
                if (i > 1)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                }
            }
            for (int k = 0; k < Form1.graph.Size; k++)
            {
                for (int j = 0; j < Form1.graph.Size; j++)
                {
                    dataGridView1[k, j].Value = Form1.graph.minTree[k, j] ? 1 : "";
                }
            }
            dataGridView1.ClearSelection();
            dataGridView1.ReadOnly = true;
        }

        private void Solution_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.graph.g = g;
            Form1.graph.canvas = Form1.MainForm.pictureBox;
            Form1.MainForm.Enabled = true;
            Form1.graph.ClearBackbone();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.graph.SaveSolutionText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.graph.SaveSolutionConnections();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.graph.SaveImageGraph(canvas);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.graph.RecordHistory = true;
            switch (Form1.MainForm.comboBox.SelectedItem)
            {
                case "Prim":
                    {
                        Form1.graph.Prim();
                        break;
                    }
                case "Kruskal":
                    {
                        Form1.graph.Kruskal();
                        break;
                    }
                case "Boruvka":
                    {
                        Form1.graph.Boruvka();
                        break;
                    }
            }
            new Step_by_step();
            Step_by_step.step_By_Step.Show();
        }
    }
}
