using System.Security.Claims;

namespace GraphBase{
    class GraphSolver:Graph{
        public GraphSolver(int size) : base(size)
        {
            Matrix = new float[size, size];
            for(int i = 0;i < size; i++)
            {
                for (int j = 0;j < size; j++)
                {
                    Matrix[i, j] = inf;
                }
            }
        }
        public GraphSolver(float[,] matrix):base(matrix.GetLength(0)){
            if(matrix.GetLength(0)!=matrix.GetLength(1)){
                throw new ArgumentException("graph matrix must be square");
            }
            Matrix=matrix;
        }

        public int ConnectivityBackbone(){
            ClearConnectivity();
            int GroupNumber=0;
            for(int i=0;i<Size;i++){
                if(nodes[i].IsEmpty){
                    GroupNumber++;
                    SpreadPaintBackbone(i);
                }
            }
            return GroupNumber;
        }
        internal void SpreadPaintBackbone(int Number){
            if(nodes[Number].IsEmpty) nodes[Number].color=Number;
            for(int i=0;i<Size; i++){
                if(minTree[i,Number]&&nodes[i].IsEmpty){
                    nodes[i].color=nodes[Number].color;
                    SpreadPaintBackbone(i);
                }
            }
        }
        public void ClearBackbone(){
            for(int i=0;i<Size;i++){
                for(int j=0;j<Size;j++){
                    minTree[i,j]=false;
                }
            }
        }
        public void Kruskal(){
            int TreeCount=ConnectivityBase();
            ClearBackbone();
            while(TreeCount!=ConnectivityBackbone()){
                float MinVertice=inf;
                int row=-1;
                int col=-1;
                for(int i=0;i<Size;i++){
                    for(int j=0; j<Size;j++){
                        if(nodes[i].color!=nodes[j].color){
                            if (Matrix[i,j]<MinVertice){
                                MinVertice=Matrix[i,j];
                                row=i;
                                col=j;
                            }
                        }
                    }
                }
                if(row<0||col<0){
                    throw new Exception("Prim method couldn't find minimum edge");
                }
                else{
                    minTree[row,col]=true;
                    minTree[col,row]=true;
                }
                
            }
        }
        public void Prim(){
            ClearBackbone();
            for(int i=0;i<Size;i++){
                int CurrentConnectivity=ConnectivityBackbone();
                int StartConnectivity;
                if(i==nodes[i].color){
                    
                    do{
                        StartConnectivity=CurrentConnectivity;
                        float MinVertice=inf;
                        int row=-1;
                        int col=-1;
                        for(int m=0;m<Size;m++){
                            for(int n=0;n<Size;n++){
                                if(Connected(m,n)&&(nodes[m].color!=nodes[n].color)){
                                    if(nodes[m].color==i||nodes[n].color==i){
                                        if(Matrix[m,n]<MinVertice){
                                            row=m;
                                            col=n;
                                            MinVertice=Matrix[m,n];
                                        }
                                    }
                                }
                            }
                        }
                        if(row>=0&&col>=0){
                            minTree[row,col]=true;
                            minTree[col,row]=true;
                        }
                        CurrentConnectivity=ConnectivityBackbone();
                    }while(StartConnectivity!=CurrentConnectivity);
                }
            }
        }
        public void Boruvka(){
            float[,] MinVertices=new float[Size,3];
            
            int GoalConnectivity=ConnectivityBase();
            ConnectivityBackbone();
            do{
                for(int i=0;i<Size;i++){
                    MinVertices[i,0]=-1;
                    MinVertices[i,1]=-1;
                    MinVertices[i,2]=inf;
                }
                for(int i=0;i<Size;i++){
                    for(int j=0;j<Size;j++){
                        if(Connected(i,j)&&nodes[i].color!=nodes[j].color){
                            if(Matrix[i,j]<MinVertices[i,2]){
                                MinVertices[nodes[i].color,2]=Matrix[i,j];
                                MinVertices[nodes[i].color,0]=i;
                                MinVertices[nodes[i].color,1]=j;
                            }
                            if(Matrix[i,j]<MinVertices[j,2]){
                                MinVertices[nodes[j].color,2]=Matrix[i,j];
                                MinVertices[nodes[j].color,0]=j;
                                MinVertices[nodes[j].color,1]=i;
                            }
                        }
                    }
                }
                for(int i=0;i<Size;i++){
                    if(MinVertices[i,0]>=0&&MinVertices[i,1]>=0){
                        AddEdge((int)MinVertices[i,0],(int)MinVertices[i,1],MinVertices[i,2]);
                    }
                }
            }while(GoalConnectivity!=ConnectivityBackbone());
        }
    }
}