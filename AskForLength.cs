﻿using System;
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
            Form1.MainForm.Enabled = false;
            if (float.IsInfinity(Form1.graph.Matrix[row, column]))
            {
                button3.Enabled = false;
                label1.Text = $"Write a length for new edge between nodes ({row}) and ({column})";
            }
            else
            {
                button3.Enabled = true;
                label1.Text = $"Change edge between nodes ({row}) and ({column})";
                textBox1.Text = $"{Form1.graph.Matrix[row, column]}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssignLength();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.graph.AddEdge(row, column, Form1.graph.inf);
            Form1.MainForm.Enabled = true;
            this.Close();
            Form1.graph.DrawGraph();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.MainForm.Enabled = true;
            this.Close();
            Form1.graph.DrawGraph();
        }
        private void AssignLength()
        {
            float f;
            string str = textBox1.Text as string;
            if (float.TryParse(str, out f))
            {
                if (f > 0)
                {
                    Form1.graph.AddEdge(row, column, f);
                    Form1.MainForm.Enabled = true;
                    this.Close();
                    Form1.graph.DrawGraph();
                }
                else if (f == 0)
                {
                    Form1.graph.AddEdge(row, column, Form1.graph.inf);
                    Form1.MainForm.Enabled = true;
                    this.Close();
                    Form1.graph.DrawGraph();
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
            Form1.MainForm.Enabled = true;
            Form1.graph.DrawGraph();
        }
    }
}
