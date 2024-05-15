using System.Security.Claims;

namespace GraphBase{
    public class GraphSolver:Graph{
        public int MaxNodes = 100;
        public float EdgeProbability=((float)1)/3;
        public int MaxRandomLength = 100;
        public List<bool[,]> History;
        public bool RecordHistory;
        public List<string> HistoryExplanation;
        public int stat_comparisons
        {
            get; private set;
        }
        public int stat_assigns { get; private set; }
        public int stat_iterations { get; private set; }
        public int stat_basicComplexity { get; private set; }
        public int stat_edges { get
            {
                int toReturn = 0;
                for(int i=0;i<Size;i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (minTree[i, j] == true) toReturn++;
                    }
                }
                return toReturn;
            } }
        public float stat_solution_weight { get; private set; }
        public float stat_total_weight
        {
            get
            {
                float weight = 0;
                stat_solution_weight = 0;
                for(int i=0;i<Size; i++)
                {
                    for(int j = 0; j < Size; j++)
                    {
                        if (Connected(i, j)) weight += Matrix[i, j];
                        if (minTree[i,j]) stat_solution_weight += Matrix[i, j];
                    }
                }
                return weight;
            }
        }
        public int stat_vertices { get  { return Size; } }
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
        public void statsToZero()
        {
            stat_assigns = 0;
            stat_basicComplexity = 0;
            stat_iterations = 0;
        }
        public void Kruskal(){
            statsToZero();
            if (RecordHistory)
            {
                HistoryExplanation = new List<string>();
                HistoryExplanation.Add("Kruskal's algoritm finds the shortest edge that connects two dots in different connectivity groups");
                ClearBackbone();
                History = new List<bool[,]>();
                AddBackboneToHistory();
            }

            int TreeCount=ConnectivityBase();
            while (TreeCount != ConnectivityBackbone())
            {
                stat_iterations++;
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
                                stat_assigns += 3;
                            }
                            stat_comparisons++;
                        }
                        stat_comparisons++;
                        stat_basicComplexity++;
                    }
                    stat_basicComplexity++;
                }
                if(row<0||col<0){
                    throw new Exception("Prim method couldn't find minimum edge");
                }
                else{
                    minTree[row,col]=true;
                    minTree[col,row]=true;
                    stat_assigns += 2;
                }
                stat_comparisons++;
                if (RecordHistory)
                {
                    AddBackboneToHistory();
                    if (row >= 0)
                    {
                        HistoryExplanation.Add($"From{row} to {col}, length {Matrix[row, col]} - Shortest edge between different groups");
                    }
                    else
                    {
                        HistoryExplanation.Add("Finished!");
                    }
                }
            }
        }
        public void Prim()
        {
            statsToZero();
            ClearBackbone();
            if (RecordHistory)
            {
                HistoryExplanation = new List<string>();
                HistoryExplanation.Add("Prim's algorithm starts from the node and adds edges that are not connected to its group. The tree grows");
                History = new List<bool[,]>();
                AddBackboneToHistory();
            }
            for(int i=0;i<Size;i++){
                int CurrentConnectivity = ConnectivityBackbone();
                int StartConnectivity;
                if(i==nodes[i].color){
                    
                    do{
                        stat_iterations++;
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
                                            stat_assigns += 3;
                                        }
                                        stat_comparisons++;
                                    }
                                    stat_comparisons++;
                                }
                                stat_comparisons++;
                                stat_basicComplexity++;
                            }
                            
                        }
                        if(row>=0&&col>=0){
                            minTree[row,col]=true;
                            minTree[col,row]=true;
                            stat_assigns += 2;
                        }
                        stat_comparisons++;
                        CurrentConnectivity=ConnectivityBackbone();
                        if (RecordHistory){ 
                            AddBackboneToHistory();
                            if (row >= 0)
                            {
                                HistoryExplanation.Add($"New edge (length{Matrix[row, col]}) connected nodes {row + 1}-group {nodes[row].color + 1}; and {col + 1}-group {nodes[row].color + 1}");
                            }
                            else
                            {
                                HistoryExplanation.Add("Finished!");
                            }
                        }
                    } while(StartConnectivity!=CurrentConnectivity);
                }
            }
        }
        public void Boruvka()
        {
            statsToZero();
            ClearBackbone();
            string for_history="";
            if (RecordHistory)
            {
                History = new List<bool[,]>();
                HistoryExplanation = new List<string>();
                AddBackboneToHistory();
                HistoryExplanation.Add("For each group, Boruvka's algorithm finds smallest edge connecting it to other groups\n");
            }

            
            float[,] MinVertices=new float[Size,3];
            int count = 0;//delete this
            int GoalConnectivity=ConnectivityBase();
            ConnectivityBackbone();
            do{
                stat_iterations++;
                if(RecordHistory)for_history = $"Step {History.Count}:";
                for(int i=0;i<Size;i++){
                    MinVertices[i,0]=-1;
                    MinVertices[i,1]=-1;
                    MinVertices[i,2]=inf;
                    stat_assigns += 3;
                    stat_basicComplexity++;
                }
                for(int i=0;i<Size;i++){
                    for(int j=0;j<Size;j++){
                        if(Connected(i,j)&&nodes[i].color!=nodes[j].color){
                            if(Matrix[i,j]<MinVertices[i,2]){
                                MinVertices[nodes[i].color,2]=Matrix[i,j];
                                MinVertices[nodes[i].color,0]=i;
                                MinVertices[nodes[i].color,1]=j;
                                stat_assigns+=3;
                            }
                            if(Matrix[i,j]<MinVertices[j,2]){
                                MinVertices[nodes[j].color,2]=Matrix[i,j];
                                MinVertices[nodes[j].color,0]=j;
                                MinVertices[nodes[j].color,1]=i;
                                stat_assigns += 3;
                            }
                            stat_comparisons += 2;
                        }
                        stat_comparisons++;
                        stat_basicComplexity++;
                    }
                }
                for(int i=0;i<Size;i++){
                    if(MinVertices[i,0]>=0&&MinVertices[i,1]>=0){
                        int row = (int)MinVertices[i, 0];
                        int col = (int)MinVertices[i, 1];
                        minTree[row, col] = true;
                        minTree[col, row] = true;
                        if (RecordHistory) { for_history += $"New edge (length{Matrix[row, col]}) connected nodes {row + 1}-group {nodes[row].color + 1}; and {col + 1}-group {nodes[row].color + 1}\n"; }
                        stat_assigns += 4;
                    }
                    stat_comparisons++;
                    stat_basicComplexity++;
                }
                count++;
                if (RecordHistory) { 
                    HistoryExplanation.Add(for_history);
                    AddBackboneToHistory();
                }
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