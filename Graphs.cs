using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AALab_2
{
    internal class Graph
    {
        protected bool[,] E;
        int V;
        public Graph(int n)
        {
            V = n; 
            E = new bool[n, n];
        }
        public void remV(int v)
        {
            bool[,] E2 = new bool[this.Vcount - 1, this.Vcount - 1];
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    E2[i, j] = E[i, j];
                }
                for (int j = v + 1; j < this.Vcount; j++)
                {
                    E2[i, j - 1] = E[i, j];
                }
            }
            for (int i = v + 1; i < this.Vcount; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    E2[i - 1, j] = E[i, j];
                }
                for (int j = v + 1; j < this.Vcount; j++)
                {
                    E2[i - 1, j - 1] = E[i, j];
                }
            }
            E = E2;
        }
        public void addV()
        {
            bool[,] E2 = new bool[this.Vcount + 1, this.Vcount + 1];
            for (int i = 0; i < this.Vcount; i++)
            {
                for (int j = 0; j < this.Vcount; j++)
                {
                    E2[i, j] = E[i, j];
                }
            }
            E = E2;
        }
        public bool[,] retunEdges
        {
            get { return E; }
        }

        public bool HasEdge(int a, int b)
        {
            return E[a, b];
        }

        public int Vcount
        {
            get { return V; }
        }
        
        public List<double> TablToList(bool[,] E1)
        {
            List<double> L = new List<double>();
            int l = (int)Math.Sqrt(E1.Length);
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (E1[i, j])
                    {
                        L.Add(Convert.ToDouble($"{i},{j}"));
                    }
                }
            }
            return L;
        }
        public bool[,] ListToTabl(List<double> L, int l)
        {
            bool[,] E1 = new bool[l,l];
            foreach (double d in L)
            {
                string[] s = d.ToString().Split(',');
                E1[Convert.ToInt32(s[0]), Convert.ToInt32(s[1])] = true;
            }
            return E1;
        }
    }
    
    class orGraph : Graph
    {
        //орієнтований граф
        public orGraph(int n) : base(n) {  }
        public void AddEdge(int a, int b)
        {
            E[a, b] = true;
        }
        public void DelEdge(int a, int b)
        {
            E[a, b] = false;
        }
        public void RandomGraph(int n, double p)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((r.NextDouble() < p) && (i != j))
                    {
                        AddEdge(i, j);
                    }
                }
            }
        }
        public void AddVert()
        {
            this.addV();
        }
        public void DelVert(int v)
        {
            this.remV(v);
        }
    }
    class unorGraph : Graph
    {
        //неорієнтований граф
        public unorGraph(int n) : base(n) { }
        public void AddEdge(int a, int b)
        {
            if (a < b)
            {
                a = a - b;
                b = a + b;
                a = b - a;
            }
            E[a, b] = true;
        }
        public void DelEdge(int a, int b)
        {
            if (a < b)
            {
                a = a - b;
                b = a + b;
                a = b - a;
            }
            E[a, b] = false;
        }
        public bool HasEdge(int a, int b)
        {
            if (a < b)
            {
                a = a - b;
                b = a + b;
                a = b - a;
            }
            return E[a, b];
        }
        public void RandomGraph(int n, double p)
        {
            Random r = new Random();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (r.NextDouble() < p) 
                        AddEdge(i, j);
                }
            }
        }
        public void AddVert()
        {
            this.addV();
        }
        public void DelVert(int v)
        {
            this.remV(v);
        }
    }
    class wGraph : unorGraph
    {
        //зважений неорієнтований граф
        int[,] W;
        public wGraph(int n) : base(n)
        {
            W = new int[n, n];
        }
        public void AddEdge(int a, int b, int w)
        {
            W[a, b] = w;
            base.AddEdge(a, b);
        }
        public void RandomGraph(int n, double p, int a, int b)
        {
            Random r = new Random();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (r.NextDouble() < p)
                    {
                        AddEdge(i, j);
                        W[i, j] = r.Next(a, b);
                    }
                }
            }
        }
        public void AddVert()
        {
            int[,] W2 = new int[this.Vcount + 1, this.Vcount + 1];
            for (int i = 0; i < this.Vcount; i++)
            {
                for (int j = 0; j < this.Vcount; j++)
                {
                    W2[i, j] = W[i, j];
                }
            }
            W = W2;
            this.addV();
        }
        public void DelVert(int v)
        {
            int[,] W2 = new int[this.Vcount - 1, this.Vcount - 1];
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    W2[i, j] = W[i, j];
                }
                for (int j = v + 1; j < this.Vcount; j++)
                {
                    W2[i, j - 1] = W[i, j];
                }
            }
            for (int i = v + 1; i < this.Vcount; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    W2[i - 1, j] = W[i, j];
                }
                for (int j = v + 1; j < this.Vcount; j++)
                {
                    W2[i - 1, j - 1] = W[i, j];
                }
            }
            this.remV(v);
        }
    }
    class worGraph : orGraph
    {
        //зважений орієнтований граф
        int[,] W;
        public worGraph(int n) : base(n)
        {
            W = new int[n, n];
        }
        public void AddEdge(int a, int b, int w)
        {
            W[a, b] = w;
            base.AddEdge(a, b);
        }
        public void RandomGraph(int n, double p, int a, int b)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((r.NextDouble() < p) && (i != j))
                    {
                        AddEdge(i, j);
                        W[i, j] = r.Next(a, b);
                    }       
                }
            }
        }
        public void AddVert()
        {
            int[,] W2 = new int[this.Vcount + 1, this.Vcount + 1];
            for (int i = 0; i < this.Vcount; i++)
            {
                for (int j = 0; j < this.Vcount; j++)
                {
                    W2[i, j] = W[i, j];
                }
            }
            W = W2;
            this.addV();
        }
        public void DelVert(int v)
        {
            int[,] W2 = new int[this.Vcount - 1, this.Vcount - 1];
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    W2[i, j] = W[i, j];
                }
                for (int j = v + 1; j < this.Vcount; j++)
                {
                    W2[i, j - 1] = W[i, j];
                }
            }
            for (int i = v + 1; i < this.Vcount; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    W2[i - 1, j] = W[i, j];
                }
                for (int j = v + 1; j < this.Vcount; j++)
                {
                    W2[i - 1, j - 1] = W[i, j];
                }
            }
            this.remV(v);
        }
    }
}
