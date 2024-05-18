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
            ToBox += $"Total iterations: {MinimumTree.graph.stat_iterations}{end}{end}";
            ToBox += $"Nodes: {MinimumTree.graph.stat_vertices}{end}";
            ToBox += $"Edges: {MinimumTree.graph.stat_edges}{end}{end}";
            ToBox += $"Total graph weight: {MinimumTree.graph.stat_total_weight} {end}";
            ToBox += $"Minimum tree weight: {MinimumTree.graph.stat_solution_weight} {end}{end}";
            ToBox += $"Complexity: {MinimumTree.graph.stat_basicComplexity}{end}";
            ToBox += $"Comparisons: {MinimumTree.graph.stat_comparisons} {end}";
            ToBox += $"Var settings: {MinimumTree.graph.stat_assigns}";
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
