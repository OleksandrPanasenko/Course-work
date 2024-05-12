using System.Drawing;
using System.Globalization;

namespace GraphBase
{
    public class Graph{
        internal List<Node> nodes;
        internal float inf=float.PositiveInfinity;
        public bool Connected(int from, int to){
            if(from>=Size||to>=Size){
                throw new ArgumentException("element out of range");
            }
            return !float.IsInfinity(Matrix[to,from]);
        }
        public float[,] Matrix;
        public bool[,] minTree;

        public int Size => nodes.Count;
        public Graph(int size){
            Matrix=new float[size,size];
            minTree=new bool[size,size];
            nodes=new List<Node>();
            for(int i=0; i<size;i++){
                for(int j=0; j<size; j++){
                    Matrix[i,j]=inf;
                    minTree[i,j]=false;
                }
                nodes.Add(new Node());
            }
            
        }
        public void AddEdge(int from, int to, float value){
            if(from>=0&&to>=0&&from<Size&&to<Size){
                Matrix[from, to]=value;
                Matrix[to,from]=value;
            }
        }
        public void AddNode(){
            nodes.Add(new Node());
            bool[,] NewMinTree=new bool[Size,Size];
            float[,] newMatrix=new float[Size,Size];
            for(int i=0;i<Size;i++){
                for(int j=0;j<Size;j++){
                    if(j==Size-1||i==Size-1){
                        NewMinTree[i,j]=false;
                        newMatrix[i,j]=inf;
                    }
                    else{
                        NewMinTree[i,j]=minTree[i,j];
                        newMatrix[i,j]=Matrix[i,j];
                    }
                }
            }
            minTree=NewMinTree;
            Matrix=newMatrix;
        }
        public void RemoveNode(int Number){
            if(Number>Size){
                throw new ArgumentOutOfRangeException($"{Number}","out of node range");
            }
            
            else{
                bool[,] NewMinTree=new bool[Size,Size];
                float[,] newMatrix=new float[Size,Size];
                int row=0;
                int col=0;
                for(int i=0;i<Size;i++){
                    if(i==Number) continue;
                    for(int j=0;j<Size;j++){
                        if(j==Number) continue;
                        NewMinTree[row,col]=minTree[i,j];
                        newMatrix[row,col]=Matrix[i,j];
                        col++;
                    }
                    col=0;
                    row++;
                }
                Matrix=newMatrix;
                minTree=NewMinTree;
                nodes.Remove(nodes.ElementAt(Number));
            }
        }
        private void SpreadPaintMatrix(int Number){
            if(nodes[Number].IsEmpty) nodes[Number].color=Number;
            for(int i=0;i<Size; i++){
                if(Connected(Number,i)&&nodes[i].IsEmpty){
                    nodes[i].color=nodes[Number].color;
                    SpreadPaintMatrix(i);
                }
            }
        }
        internal void ClearConnectivity(){
            foreach(Node node in nodes){
                node.color=Node.empty_node;
            }
        }
        public int ConnectivityBase(){
            ClearConnectivity();
            int GroupNumber=0;
            for(int i=0;i<Size;i++){
                if(nodes[i].IsEmpty){
                    GroupNumber++;
                    SpreadPaintMatrix(i);
                }
            }
            return GroupNumber;
        }        
    }
}