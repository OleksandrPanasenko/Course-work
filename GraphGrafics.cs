using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
namespace GraphBase{
    class GraphGrafics : GraphSolver
    {
        public int cornerX = 250;
        public int cornerY=100;
        public GraphGrafics(int size,Graphics g) : base(size)
        {
            this.g = g;
        }
        public GraphGrafics(float [,] matrix, Graphics g) : base(matrix)
        {
            this.g = g;
        }
        public GraphGrafics(Graphics g):base(0)
        {
            this.g = g;
        }
        public int radius = 10;
        public int Mode; //which radiobutton is tapped
        int selectedNode=-1;
        Color main = Color.Yellow;
        Color edge = Color.Brown;
        Color backbone = Color.Blue;
        Color SelectedRemoveNode = Color.Red;
        Color selectedMove = Color.Red;
        Color selectedAddEdge = Color.Magenta;
        Color background= Color.White;
        Brush VerticeTextBrush = new SolidBrush(Color.Black);
        Brush VerticeBrush=new SolidBrush(Color.Yellow);
        Graphics g;
        Font lengthFont = new Font("Arial", 8);
        public float DistanceBetweenPoints(int x1, int y1, int x2, int y2)
        {
            return (float)(Math.Sqrt(Math.Pow(x1 - x2, 2)+Math.Pow(y1-y2,2)));
        }
        public void DrawGraph()
        {
            g.Clear(background);
            Pen EdgePen = new Pen(edge, 2);
            Pen BackbonePen = new Pen(backbone, 3);
            for(int i = 0;i<Size;i++)
            {
                for(int j = 0;j<Size;j++)
                {
                    if ( i != j&& Connected(i, j))
                    {
                        int x1 = nodes[i].x;
                        int y1 = nodes[i].y;
                        int x2 = nodes[j].x;
                        int y2 = nodes[j].y;
                        if (minTree[i, j] == true)
                        {
                            g.DrawLine(BackbonePen, new Point(x1, y1), new Point(x2, y2));
                        }
                        else g.DrawLine(EdgePen,new Point(x1, y1), new Point(x2,y2));
                        g.DrawString($"{Matrix[i, j]}", lengthFont, VerticeTextBrush,new Point((int)(x1+x2)/2,(int)(y1+y2)/2));

                    }
                }

            }
            for(int i = 0; i < Size; i++)
            {
                int x= nodes[i].x;
                int y= nodes[i].y;
                Rectangle shape = new Rectangle(x - radius, y - radius, radius * 2, radius * 2);
                if (i != selectedNode||Mode<2)
                {
                    g.FillEllipse(VerticeBrush, shape);
                }
                else
                {
                    if(Mode == 2)
                    {
                        g.FillEllipse(new SolidBrush(SelectedRemoveNode), shape);
                    }
                    if (Mode == 3)
                    {
                        g.FillEllipse(new SolidBrush(selectedMove), shape);
                    }
                    if (Mode == 4)
                    {
                        g.FillEllipse(new SolidBrush(selectedAddEdge), shape);
                    }
                }
                g.DrawString($"{i+1}", lengthFont, VerticeTextBrush, new Point(x-lengthFont.Height / 2, y- lengthFont.Height / 2));
            }
        }
        public void NewDot(MouseEventArgs e) 
        {
            AddNode();
            nodes[Size - 1].x = e.X;
            nodes[Size - 1].y = e.Y;
            DrawGraph();

        }
        public void NewRandomDot(int left, int right, int up, int down)
        {
            int x;
            int y;
            int Obstacle;
            int CloseCount = 0;
            Random rand=new Random();
            do
            {
                x = left + rand.Next(right - left);
                y = up + rand.Next(down - up);
                Obstacle = ClosestPoint(x, y);
                CloseCount++;
            } while (Size!=0&&CloseCount<1000&& DistanceBetweenPoints(x, y, nodes[Obstacle].x, nodes[Obstacle].y) <= radius * 2);
            if(CloseCount>=1000)
            {
                MessageBox.Show("Failed to find a random spot to place node. Too overcrowded");
            }
            else
            {
                AddNode();
                nodes[Size - 1].x = x;
                nodes[Size - 1].y = y;
                DrawGraph();
            }
        }
        public void DeleteDot(MouseEventArgs e)
        {
            CheckAndSelectNode(e);
            if (selectedNode >= 0)
            {
                RemoveNode(selectedNode);
            }
            //ask for deletion
            DrawGraph();
        }
        public void CheckAndSelectNode(MouseEventArgs e)
        {
            int minNode=ClosestPoint(e.X, e.Y);
            if (DistanceBetweenPoints(e.X,e.Y,nodes[minNode].x,nodes[minNode].y) <= radius)
            {
                selectedNode = minNode;
                DrawGraph();
            }
            else
            {
                selectedNode = -1;
            }
        }
        private int ClosestPoint(int x,  int y)
        {
            float min = inf;
            int minNode = -1;
            for (int i = 0; i < Size; i++)
            {
                float distance = DistanceBetweenPoints(nodes[i].x, nodes[i].y, x,y);
                if (distance < min)
                {
                    min = distance;
                    minNode = i;
                }
            }
            return minNode;
        }
        public void StartMoving(MouseEventArgs e)
        {
            if (Mode == 3)
            {
                CheckAndSelectNode(e);
            }
        }
        public void EndMoving(MouseEventArgs e)
        {
            if (selectedNode >= 0)
            {
                nodes[selectedNode].x = e.X;
                nodes[selectedNode].y = e.Y;
                selectedNode = -1;
                DrawGraph();
            }
        }
        public void StartEdge(MouseEventArgs e)
        {
            if(Mode == 4) {
                CheckAndSelectNode(e);
            }
        }
        public void EndEdge(MouseEventArgs e)
        {
            if (Mode == 4) {
                if(selectedNode >= 0)
                {
                    int Start = selectedNode;
                    CheckAndSelectNode(e);
                    if (selectedNode >= 0 && selectedNode != Start)
                    {
                        AddEdge(Start, selectedNode, 10);// add window in there
                        DrawGraph();
                    }
                }
            }
        }


    }
}