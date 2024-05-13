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
        public void GetGraphMatrix(NumericUpDown upDown)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
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
                        CopyMatrix = new float[number, number];
                    }
                    else
                    {
                        MessageBox.Show("File invalid! Graph size must be positive integer!");
                        number = 0;
                    }
                }
                else
                {
                    MessageBox.Show("File is empty or non-existent");
                }
                for (int i = 0; i < number && file != null; i++)
                {
                    string[] T = file.ReadLine().Split();
                    if (T.Length != number && !((T.Length == number + 1) && T[number] == ""))
                    {
                        throw new FileFormatException($"row {i + 1} argument number{T.Length}!={number} last member {T[number]} next line {file.ReadLine()}");
                    }
                    for (int j = 0; j < number; j++)
                    {
                        float f = 0;
                        if (float.TryParse(T[j], out f))
                        {
                            CopyMatrix[i, j] = f;
                        }
                        else
                        {
                            throw new FileFormatException("non-numerical detected");
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
                for (int i = 0; i < number && !file.EndOfStream; i++)
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

        internal void SaveImageGraph(Bitmap canvas)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.BMP|*.BMP| *.JPG|*.JPG| *.GIF|*.GIF| *.PNG|*.PNG";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                canvas.Save(path,ImageFormat.Png);
            }
        }
    }
}
