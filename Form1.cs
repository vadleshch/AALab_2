using System.ComponentModel;

namespace AALab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        unorGraph g1;
        orGraph g2;
        wGraph g3;
        worGraph g4;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        void writeg(Graph g)
        {
            string s = "";
            for (int i = 0; i < g.Vcount; i++)
            {
                for (int j = 0; j < g.Vcount; j++)
                {
                    if (g.HasEdge(i, j))
                    {
                        s = s + "1 ";
                    }
                    else
                    {
                        s = s + "0 ";
                    }
                }
                listBox1.Items.Add(s);
                s = "";
            }
        }
        void drawGraph(Graph g)
        {
            int h = pictureBox1.Height;
            int w = pictureBox1.Width;
            Bitmap bitmap = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bitmap);
            int n = g.Vcount;
            int dw = w / (g.Vcount + 1);
            for (int i = 0; i < g.Vcount; i++)
            {
                gr.DrawEllipse(Pens.Red, dw * (i + 1) - 5, h / 2 - 5, 25, 25);
                gr.DrawString($"{i + 1}", new Font("Times", 10), Brushes.Black, dw * (i + 1), h / 2);
            }
            Point[] points;
            for (int i = 0; i < g.Vcount; i++)
            {
                for (int j = i; j < g.Vcount; j++)
                {
                    if (g.HasEdge(i, j))
                    {
                        points = GetUnderPoints(10, dw * (Math.Min(i, j) + 1), h / 2, dw * (Math.Max(i, j) - Math.Min(i, j)));
                        for (int k = 0; k < points.Length - 1; k++)
                        {
                            gr.DrawLine(Pens.Blue, points[k].X + 5, points[k].Y + 20, points[k + 1].X + 5, points[k + 1].Y + 20);
                        }
                    }
                }
            }
            for (int i = 0; i < g.Vcount; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (g.HasEdge(i, j))
                    {
                        points = GetPoints(10, dw * (Math.Min(i, j) + 1), h / 2, dw * (Math.Max(i, j) - Math.Min(i, j)));
                        for (int k = 0; k < points.Length - 1; k++)
                        {
                            gr.DrawLine(Pens.Red, points[k].X + 5, points[k].Y - 5, points[k + 1].X + 5, points[k + 1].Y - 5);
                        }
                    }
                }
            }
            pictureBox1.Image = bitmap;
        }

        Point[] GetPoints(int n, int w, int h, int dw)
        {
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                points[i] = new Point(w + dw * i / (n - 1), h - (int)(50 * Math.Sin(Math.PI * i / (n - 1))));
            }
            return points;
        }
        Point[] GetUnderPoints(int n, int w, int h, int dw)
        {
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                points[i] = new Point(w + dw * i / (n - 1), h + (int)(50 * Math.Sin(Math.PI * i / (n - 1))));
            }
            return points;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string s = comboBox1.Text;
            int n = Convert.ToInt32(textBox1.Text);
            double p = Convert.ToDouble(textBox2.Text);
            int a = 0, b = 5;
            switch (s)
            {
                case "граф":
                    g1 = new unorGraph(n);
                        g1.RandomGraph(n, p);
                        writeg(g1);
                        drawGraph(g1);
                    
                    break;
                case "орграф":
                    g2 = new orGraph(n);
                    g2.RandomGraph(n, p);
                        writeg(g2);
                        drawGraph(g2);
                    
                    break;
                case "зважений граф":
                    g3 = new wGraph(n);
                    g3.RandomGraph(n, p, a, b);
                        writeg(g3);
                        drawGraph(g3);
                    
                    break;
                case "зважений орграф":
                    g4 = new worGraph(n);
                    g4.RandomGraph(n, p, a, b);
                        writeg(g4);
                        drawGraph(g4);

                    break;
            }
        }
    }
}
