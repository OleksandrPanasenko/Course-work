using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GraphBase
{
    public class FileGraph : GraphGrafics
    {
        public FileGraph(int size, Graphics g) : base(size, g)
        {
        }
        public FileGraph(Graphics g) : base(g)
        {

        }
        public FileGraph(float[,] matrix, Graphics g) : base(matrix, g)
        {

        }
        public void SaveGraphMatrix()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text file .txt|*.TXT";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                StreamWriter file = new StreamWriter(File.Create(path));
                string toFile = "";
                toFile += $"{Size}\n";
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (Connected(i, j))
                        {
                            toFile += $"{Matrix[i, j]} ";
                        }
                        else
                        {
                            toFile += $"{0} ";
                        }

                    }
                    toFile += "\n";
                }
                for (int i = 0; i < Size; i++)
                {
                    toFile += $"{i + 1} {nodes[i].x} {nodes[i].y}\n";
                }
                file.Write(toFile);
                file.Close();
                file.Dispose();
            }
        }
        
        public void SaveSolutionConnections()
        {
            float[,] buffer = Matrix;
            Matrix = new float[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (minTree[i, j] == true)
                    {
                        Matrix[i, j] = 1;
                    }
                    else
                    {
                        Matrix[i, j] = inf;
                    }
                }
            }
            SaveGraphMatrix();
            Matrix = buffer;
        }

        public void SaveSolutionText()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                StreamWriter file = new StreamWriter(File.Create(path));
                string toFile = "";
                toFile += $"{Size}\n";
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (minTree[i,j]==true)
                        {
                            toFile += $"{Matrix[i, j]} ";
                        }
                        else
                        {
                            toFile += $"{0} ";
                        }

                    }
                    toFile += "\n";
                }
                for (int i = 0; i < Size; i++)
                {
                    toFile += $"{i + 1} {nodes[i].x} {nodes[i].y}\n";
                }
                file.Write(toFile);
                file.Close();
                file.Dispose();
            }
        }
        private void GraphResizeFit()
        {
            int xMin, xMax, yMin, yMax;
            xMin = xMax = nodes[0].x;
            yMin = yMax = nodes[0].y;
            foreach(Node node in nodes)
            {
                if(node.x < xMin) xMin = node.x;
                if(node.y < yMin) yMin = node.y;
                if(node.x > xMax) xMax = node.x;
                if(node.y > yMax) yMax = node.y;
            }
            float xCoefficient=(canvas.Width - 2 * radius) /(xMax-xMin);
            float yCoefficient=(canvas.Height - 2 * radius) /(yMax-yMin);
            for (int i = 0;i < Size; i++)
            {
                nodes[i].x = (int)((nodes[i].x - xMin) * xCoefficient)+radius;
                nodes[i].y = (int)((nodes[i].y - yMin) * yCoefficient)+radius;
            }
        }
        public void GetGraphMatrix(NumericUpDown upDown)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "text files .txt|*.TXT";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                float[,] CopyMatrix = new float[0, 0];
                string path = openFileDialog.FileName;
                StreamReader file = new StreamReader(path);
                int number = 0;
                if (file != null)
                {
                    if (Int32.TryParse(file.ReadLine(), out number) && number > 0)
                    {
                        if (number > MaxNodes)
                        {
                            CopyMatrix = new float[MaxNodes, MaxNodes];
                            MessageBox.Show($"Matrix was cut to {MaxNodes} vertices due to being too large");
                        }
                        else
                        {
                            CopyMatrix = new float[number, number];
                        }                         
                    }
                    else
                    {
                        throw new FileFormatException("File invalid! Graph size must be positive integer!");
                    }
                }
                else
                {
                    throw new FileFormatException("File is empty or non-existent");
                }
                for (int i = 0; i < number && file != null; i++)
                {
                    string[] T = file.ReadLine().Split();
                    if (number <= MaxNodes)
                    {
                        if (T.Length <= number)
                        {
                            throw new FileFormatException($"row {i + 1} argument number{T.Length - 1}less than initially stated{number}");
                        }
                        for (int j = 0; j < number&&j<MaxNodes; j++)
                        {
                            float f = 0;
                            if (float.TryParse(T[j], out f))
                            {
                                CopyMatrix[i, j] = f;
                            }
                            else
                            {
                                throw new FileFormatException($"non-numerical detected at row {i + 1} column {j + 1}");
                            }
                        }
                    }
                }
                if (CheckForSymmetry(CopyMatrix) == false)
                {
                    throw new ArgumentException("matrix not symmetric");
                }
                else
                {
                    upDown.Value=number;
                    Matrix = CopyMatrix;
                }
                for (int i = 0; i < number &&i<MaxNodes&& !file.EndOfStream; i++)
                {
                    string[] T = file.ReadLine().Split();
                    int node, x, y;
                    node = x = y = -1;
                    if (T.Length == 3 && int.TryParse(T[0], out node) && int.TryParse(T[1], out x) && int.TryParse(T[2], out y))
                    {
                        if (node == i + 1)
                        {
                            nodes[i].x = x;
                            nodes[i].y = y;
                        }
                    }
                }
                GraphResizeFit();
                DrawGraph();
                file.Close();

            }
        }
        private bool CheckForSymmetry(float[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        if (matrix[i, j] != matrix[j, i])
                        {
                            return false;
                        }
                        if (matrix[i, j] == 0)
                        {
                            matrix[i, j] = matrix[j, i] = inf;
                        }
                    }
                }
            }
            return true;
        }
        internal void SaveHistoryText()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "text file .txt|*.TXT";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                StreamWriter file = new StreamWriter(File.Create(path));
                string toFile = "";
                for (int slide = 0; slide < HistoryExplanation.Count; slide++)
                {
                    toFile += $"Step {slide}\n";
                    toFile += HistoryExplanation.Count;
                    toFile += "\n\n";
                    file.Write(toFile);
                }
                file.Close();
                file.Dispose();
            }
        }
        internal void SaveImageGraph(Bitmap canvas)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.PNG|*.PNG| *.JPG|*.JPG| *.GIF|*.GIF| *.BMP|*.BMP";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                canvas.Save(path,ImageFormat.Png);
            }
        }
        internal void SaveSlideText(int Slide)
        {
            bool[,] buffer = minTree;
            minTree = History[Slide];
            SaveSolutionText();
            minTree = buffer;
        }
        internal void SaveHistoryFolder(Bitmap canvas)
        {
            FolderBrowserDialog sfd= new FolderBrowserDialog();
            sfd.ShowNewFolderButton = true;
            sfd.Description = "Choose an empty folder";
            sfd.ShowDialog();
            string directoryPath = sfd.SelectedPath;
            if (directoryPath != (string)null&&directoryPath!="")
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                else if (Directory.EnumerateFileSystemEntries(directoryPath).Any())
                {
                    MessageBox.Show($"Directory has {Directory.EnumerateFileSystemEntries(directoryPath).Count()} files already");
                    return;
                }
                for (int i = 0; i < History.Count; i++)
                {
                    DrawFromHistory(i);
                    canvas.Save(directoryPath + $"\\\\Slide{i}.png", ImageFormat.Png);
                }
            }
        }
    }
}
