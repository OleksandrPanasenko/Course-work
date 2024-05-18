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
    public partial class AskForLength : Form
    {
        public static int row;
        public static int column;
        public static AskForLength askForLength;
        public AskForLength()
        {
            askForLength = this;
            InitializeComponent();
            MinimumTree.MainForm.Enabled = false;
            if (float.IsInfinity(MinimumTree.graph.Matrix[row, column]))
            {
                button3.Enabled = false;
                label1.Text = $"Set a length for new edge between nodes ({row+1}) and ({column+1})";
            }
            else
            {
                button3.Enabled = true;
                label1.Text = $"Change edge between nodes ({row + 1}) and ({column+1})";
                textBox1.Text = $"{MinimumTree.graph.Matrix[row, column]}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssignLength();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MinimumTree.graph.AddEdge(row, column, MinimumTree.graph.inf);
            MinimumTree.MainForm.Enabled = true;
            this.Close();
            MinimumTree.graph.DrawGraph();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MinimumTree.MainForm.Enabled = true;
            this.Close();
            MinimumTree.graph.DrawGraph();
        }
        private void AssignLength()
        {
            float f;
            string str = textBox1.Text as string;
            if (float.TryParse(str, out f))
            {
                if (f > 0)
                {
                    if (f > Math.Pow(10, 30))
                    {
                        MessageBox.Show("Incomprehensibly low value. Vas set to infinity ('no edge')");
                    }
                    else
                    {
                        MinimumTree.graph.AddEdge(row, column, f);
                    }
                    MinimumTree.MainForm.Enabled = true;
                    this.Close();
                    MinimumTree.graph.DrawGraph();
                }
                else if (f == 0)
                {
                    if (str.Contains(",") || (str.Contains(".")||(str.Contains("-"))))
                    {
                        MessageBox.Show("Incomprehensibly low value. Vas set to 'no edge'");
                    }
                    MinimumTree.graph.AddEdge(row, column, MinimumTree.graph.inf);
                    MinimumTree.MainForm.Enabled = true;
                    this.Close();
                    MinimumTree.graph.DrawGraph();
                }
                else
                {
                    MessageBox.Show("Edge can't have negative length!");
                }
            }
            else
            {
                MessageBox.Show("Only non-negative numbers accepted!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AssignLength();
            }
        }

        private void AskForLength_FormClosing(object sender, FormClosingEventArgs e)
        {
            MinimumTree.MainForm.Enabled = true;
            MinimumTree.graph.DrawGraph();
        }
    }
}
