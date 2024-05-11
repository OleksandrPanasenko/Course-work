using System.Security.Cryptography.X509Certificates;

namespace GraphBase
{
    class Node{
        internal static int empty_node=-1;
        internal bool IsEmpty{
            get{return color==empty_node;}
        }
        internal int color;
        internal int x;
        internal int y;
        public Node(int x, int y){
            this.x = x;
            this.y = y;
            color=empty_node;
        }
        public Node(){
            color=empty_node;
        }
    }
}