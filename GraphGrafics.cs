using System.Security.Cryptography.X509Certificates;
namespace GraphBase{
    class GraphGrafics : GraphSolver
    {
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
        int radius = 10;
        Color main = Color.Yellow;
        Color edge = Color.Brown;
        Color backbone = Color.Blue;
        Color selected = Color.Red;
        Brush VerticeTextBrush = new SolidBrush(Color.Black);
        Brush VerticeBrush=new SolidBrush(Color.Yellow);
        Graphics g;
        Font lengthFont = new Font("Arial", 8);
        public void DrawGraph()
        {
            Pen EdgePen = new Pen(edge, 2);
            for(int i = 0;i<Size;i++)
            {
                for(int j = 0;j<Size;j++)
                {
                    if (Connected(i, j) && i != j)
                    {
                        int x1 = nodes[i].x;
                        int y1 = nodes[i].y;
                        int x2 = nodes[j].x;
                        int y2 = nodes[j].y;
                        g.DrawLine(EdgePen,new Point(x1, y1), new Point(x2,y2));
                        g.DrawString($"{Matrix[i, j]}", lengthFont, VerticeTextBrush,new Point((int)(x1+x2)/2,(int)(y1+y2)/2));

                    }
                }

            }
            for(int i = 0; i < Size; i++)
            {
                int x= nodes[i].x;
                int y= nodes[i].y;
                Rectangle shape = new Rectangle(x - radius, y - radius, radius * 2, radius * 2);
                g.FillEllipse(VerticeBrush, shape);
                g.DrawString($"{i}", lengthFont, VerticeTextBrush, new Point(x, y));
            }
        }

    }
}