using System.Security.Claims;

namespace GraphBase{
    public class GraphSolver:Graph{
        public float EdgeProbability=((float)1)/3;
        public int MaxRandomLength = 100;
        public List<bool[,]> History;
        public bool RecordHistory;
        private void AddBackboneToHistory()
        {
            bool[,] copy = new bool[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j=0;j< Size; j++)
                {
                    copy[i,j] = minTree[i,j];
                }
            }
            History.Add(copy);
        }
        private bool RandomConnect()
        {
            Random rand=new Random();
            return (rand.NextDouble() < EdgeProbability) ;
        }
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
            if (RecordHistory)
            {
                History = new List<bool[,]>();
                AddBackboneToHistory();
            }

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
                if (RecordHistory) AddBackboneToHistory();
            }
        }
        public void Prim()
        {
            if (RecordHistory)
            {
                History = new List<bool[,]>();
                AddBackboneToHistory();
            }

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
                        if (RecordHistory) AddBackboneToHistory();
                    } while(StartConnectivity!=CurrentConnectivity);
                }
            }
        }
        public void Boruvka()
        {
            if (RecordHistory)
            {
                History = new List<bool[,]>();
                AddBackboneToHistory();
            }

            ClearBackbone();
            float[,] MinVertices=new float[Size,3];
            int count = 0;//delete this
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
                        minTree[(int)MinVertices[i, 0], (int)MinVertices[i, 1]] = true;
                        minTree[(int)MinVertices[i, 1], (int)MinVertices[i, 0]] = true;
                    }
                }
                count++;
                if (RecordHistory) AddBackboneToHistory();
            }while(count<1000&&GoalConnectivity<ConnectivityBackbone());
            if (count == 1000)
            {
                MessageBox.Show($"Too much calculations: base has {ConnectivityBase()} and backbone {ConnectivityBackbone()} groups");
            }
        }
        public void RandomGraph()
        {
            Random random = new Random();
            for(int i = 1; i < Size; i++) {
                for(int j=0;j<=i; j++)
                {
                    if (i != j && RandomConnect())
                    {
                        AddEdge(i, j, random.Next(MaxRandomLength) + 1);
                    }
                    else AddEdge(i, j, inf);
                }
            }
        }
    }
}