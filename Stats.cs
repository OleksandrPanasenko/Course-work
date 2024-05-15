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
    public partial class Stats : Form
    {
        public static Stats statsForm;
        public Stats()
        {
            string end = Environment.NewLine;
            InitializeComponent();
            string ToBox = "";
            ToBox += $"Total iterations: {Form1.graph.stat_iterations}{end}{end}";
            ToBox += $"Nodes: {Form1.graph.stat_vertices}{end}";
            ToBox += $"Edges: {Form1.graph.stat_edges}{end}{end}";
            ToBox += $"Total graph weight: {Form1.graph.stat_total_weight} {end}";
            ToBox += $"Minimum tree weight: {Form1.graph.stat_solution_weight} {end}{end}";
            ToBox += $"Complexity: {Form1.graph.stat_basicComplexity}{end}";
            ToBox += $"Comparisons: {Form1.graph.stat_comparisons} {end}";
            ToBox += $"Var settings: {Form1.graph.stat_assigns}";
            this.textBox1.Text = ToBox;
            statsForm = this;
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            Solution.solution.Enabled = false;


        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Stats_FormClosing(object sender, FormClosingEventArgs e)
        {
            Solution.solution.Enabled = true;
        }
    }
}
