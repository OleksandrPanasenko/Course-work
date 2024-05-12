using System.Data;
using System.Drawing.Drawing2D;

namespace GraphBase
{
    public partial class Form1 : Form
    {
        GraphGrafics graph;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            graph = new GraphGrafics(g);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void numericUpDown1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton3.Checked)
            {
                graph.Mode = 3;
                graph.StartMoving(e);
            }
            else if (radioButton4.Checked)
            {
                graph.Mode = 4;
                graph.StartEdge(e);
            }

        }
        private void FillTable()
        {
            //MatrixOnForm.Rows.Clear();
            //MatrixOnForm.Columns.Clear();
            while (MatrixOnForm.Columns.Count != graph.Size)
            {
                int i = MatrixOnForm.Columns.Count;
                if (MatrixOnForm.Columns.Count < graph.Size)
                {
                    MatrixOnForm.Columns.Add($"Column {i + 1}", $"{i + 1}");
                    MatrixOnForm.Rows.Add();
                    MatrixOnForm.Rows[i].HeaderCell.Value = $"{i + 1}";
                }
                else
                {
                    MatrixOnForm.Columns.RemoveAt(i - 1);
                    MatrixOnForm.Rows.RemoveAt(i - 1);
                }
            }
            /*for (int i = 0; i < graph.Size; i++)
            {
                MatrixOnForm.Columns.Add($"Column {i + 1}", $"{i + 1}");
                MatrixOnForm.Rows.Add($"{i + 1}");
                MatrixOnForm.Rows[i].HeaderCell.Value = $"{i + 1}";
            }*/
            for (int row = 0; row < graph.Size; row++)
            {
                for (int column = 0; column < graph.Size; column++)
                {
                    if (graph.Connected(row, column))
                    {
                        MatrixOnForm[row, column].Value = graph.Matrix[row, column];
                    }
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked)
            {
                graph.Mode = 1;
                graph.NewDot(e);
                FillTable();
            }
            else if (radioButton2.Checked)
            {
                graph.Mode = 2;
                graph.DeleteDot(e);
                FillTable();
            }
            NodesNumber.Value = (graph.Size);

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton3.Checked)
            {
                graph.Mode = 3;
                graph.EndMoving(e);
            }
            else if (radioButton4.Checked)
            {
                graph.Mode = 4;
                graph.EndEdge(e);
                FillTable();
            }

        }

        private void NodesNumber_ValueChanged(object sender, EventArgs e)
        {
            g = CreateGraphics();
            if (NodesNumber.Value < graph.Size)
            {
                while (NodesNumber.Value < graph.Size)
                {
                    graph.RemoveNode(graph.Size - 1);
                }
                graph.DrawGraph();
            }
            else
            {
                while (NodesNumber.Value > graph.Size)
                {
                    graph.NewRandomDot(graph.cornerX, ClientSize.Width - graph.radius, graph.cornerY, ClientSize.Height - graph.radius);
                }
            }
            FillTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 0; i < graph.Size; i++)
            {
                str += $"{i}. Node-{graph.nodes[i].x};{graph.nodes[i].y}\n";
            }
            MessageBox.Show(str);
        }

        private void MatrixOnForm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            float f = 0;
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            string value;
            if (MatrixOnForm[col, row].Value == null)
            {
                value = "";
            }
            else value = MatrixOnForm[col, row].Value as string;
            if (value == "")
            {
                graph.AddEdge(row, col, graph.inf);
            }
            else
            {
                if (float.TryParse(value, out f))
                {
                    if (f > 0)
                    {
                        graph.AddEdge(row, col, f);
                        MatrixOnForm[row, col].Value = f;
                    }
                    else if (f == 0)
                    {
                        graph.AddEdge(row, col, graph.inf);
                        MatrixOnForm[col, row].Value = graph.inf;
                        MatrixOnForm[row, col].Value = graph.inf;
                    }
                    else
                    {
                        MessageBox.Show($"Cell({row};{col}): You tried to input negative number", "No negatives allowed!");
                        MatrixOnForm[col, row].Value = graph.Matrix[row, col];
                    }
                }
                else
                {
                    MessageBox.Show($"Cell({row};{col}): No number detected", "Only non-negative numbers allowed");
                    MatrixOnForm[col, row].Value = graph.Matrix[row, col];
                }
            }
            graph.DrawGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Prim":
                    {
                        graph.Prim();
                        break;
                    }
                case "Kruskal":
                    {
                        graph.Kruskal();
                        break;
                    }
                case "Boruvka":
                    {
                        graph.Boruvka();
                        break;
                    }
            }
            graph.DrawGraph();
        }
    }
}
