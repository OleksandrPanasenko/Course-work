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
    public partial class Manual : UserControl
    {
        public Manual()
        {
            InitializeComponent();
        }

        private void Manual_Load(object sender, EventArgs e)
        {
            textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Text = "This app allows you to make a weighted graph and find its minimum spanning tree (or forest).\r\n\r\n" +
                "1. Add vertice\r\n" +
                "1.1 To add an vertice, click on \"New Point\" radio button, and click on the point you wish to place your point.\r\n" +
                "1.2 Alternatively, you can change the number in \"Vertices\" box. Additional dots are added randomly\r\n" +
                "\r\n" +
                "2. Delete vertice\r\n" +
                "2.1 To delete vertice, click on \"Delete\" radiobutton and click on vertice you want to remove\r\n" +
                "2.2 Alternatively, you can decrease number in \"Vertices\" box either by typing new value or using arrows. The latest placed points would disappear\r\n" +
                "\r\n" +
                "3. Move point\r\n" +
                "To move vertice, select \"move point\" radiobutton, press on the vertice in the field, and move mouse to the new point HOLDING THE BUTTON.\r\n" +
                "Release when movement is finished, the point would appear in new place.\r\n" +
                "\r\n" +
                "4. Manage connections\r\n" +
                "4.1 To add, change value of, or delete edge between two points, click \"Connections\" radio button, tap on the first vertice, move cursor while holding, release over destinated point\r\n" +
                "The form would appear to ask for weight of edge. Write a number and press \"Change\" button.\r\n" +
                "0 or \"Delete\" to remove edge\r\n" +
                "4.2 Alternatively, you can find a cell in \"Matrix\" table on intersection of row and column with numbers of vertices. You can set edge directly in the table, 0 or empty cell for no connection\r\n" +
                "\r\n" +
                "5. Generating random graph\r\nAfter you have added vertices on the screen, you can press \"Random Graph\" to generate random edges between vertices\r\n" +
                "\r\n" +
                "6. Saving your graph\r\n" +
                "6.1 - Save in text:\r\nsave a graph as a matrix and vertice coordinates, choose the folder where you would like to save\r\n" +
                "6.2 - Save as image:\r\nsave a picture of graph to location you choose and with format you choose\r\n" +
                "\r\n" +
                "7. Retrieve from file:\r\n" +
                "7.1 - after clicking on \"Get from file\" you would be asked to choose a file. Choose a file you saved in the previous session with your program\r\n" +
                "7.2 - you can make file yourself: first line is number of nodes, then - symmetrical connectivity matrix (new line - new row, values separated by spaces)\r\n" +
                "if file doesn't have coordinates, it would put the dots in random places, preserving connectivity\r\n" +
                "\r\n" +
                "8. Finding minimum spanning tree\r\n" +
                "First, make sure you have (or made) the graph you want to work with \r\n" +
                "Choose from togglebox \"Method\" desired method of solving. Then, click button \"Calculate!\"\r\n" +
                "8.1 - You would see the result as lines of different color. \r\n" +
                "8.2 Now, using buttons you could save the image, or save the minimum tree in the text file\r\n" +
                "8.3 You could see the statistics of the solution by clicking \"Complexity data\"\r\n" +
                "\r\n" +
                "9. See step-by-step solution\r\n" +
                "While seeing solution, click \"show step-by-step\" button. \r\n" +
                "9.1 To get through steps, click arrows \"<=\" and \"=>\" to move to the previus and next steps\r\n" +
                "9.2 At any point, you could save current step or entiry history\r\n" +
                "9.3 To save full solution as pictures, you would be asked to choose an EMPTY folder.";
            this.Show();
        }
    }
}
