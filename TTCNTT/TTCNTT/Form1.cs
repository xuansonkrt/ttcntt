using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl.Core.Geometry;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Color = Microsoft.Msagl.Drawing.Color;
using Node = Microsoft.Msagl.Drawing.Node;
using Point = System.Drawing.Point;

namespace TTCNTT
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private int soDinh;
        private int soCanh;
        private int start;
        private int end;
        double[,] distance = new double[30,30];
        List<entities.Point> lstPoint = new List<entities.Point>();
        private bool[] chuaxet = new bool[30];
        private int[] truoc = new int[30];  // luu hanh trinh
        private double[] d = new double[30]; // luu khoang cach toi dinh thu i
        private int VOCUNG = Int32.MaxValue;
        private String path = "";
        public Form1()
        {
            InitializeComponent();
            //create a form 
           // System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            this.groupBoxResult.Controls.Clear();
            this.distance = new double[30, 30];
            this.lstPoint = new List<entities.Point>();
            path = "";
            chuaxet = new bool[30];
            d = new double[30];
            d = new double[30];
            if (txtSoDinh.Text.Equals("") || txtSoCanh.Text.Equals("")
                || txtStart.Text.Equals("") || txtEnd.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "ERROR");
                return;
            }

            try
            {
                soDinh = Int32.Parse(this.txtSoDinh.Text);
                soCanh = Int32.Parse(this.txtSoCanh.Text);
                start = Int32.Parse(this.txtStart.Text)-1;
                end = Int32.Parse(this.txtEnd.Text)-1;

                int max = (soDinh * (soDinh - 1) / 2);
                if (soCanh > max)
                {
                    MessageBox.Show("Với số đỉnh là " +soDinh.ToString() + " thì số cạnh tối đa là " + max.ToString(), "ERROR");
                    return;
                }
                this.InitData();
                this.Dijkstra();
                this.ShowGraph();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                return;
                throw;
            }
        }


        bool isContain(entities.Point point)
        {
            foreach (var item in lstPoint)
            {
                if (item.x == point.x && item.y == point.y)
                {
                    return true;
                }
            }
            return false;
        }

        void InitData()
        {
            for (int i = 0; i < this.soDinh; i++)
            {
                do
                {
                    int x = rnd.Next(-100, 100);
                    int y = rnd.Next(-100, 100);
                    entities.Point point = new entities.Point {x = x, y = y};
                    if (!isContain(point))
                    {
                        lstPoint.Add(point);
                        break;
                    }
                } while (true);
            }

            for (int i = 0; i < this.soDinh; i++)
            {
                for (int j = 0; j < this.soDinh; j++)
                {
                    this.distance[i, j] = this.VOCUNG;
                }
                this.distance[i, i] = 0;
            }

            for (int i = 0; i < this.soCanh; i++)
            {
                int s;
                int e;
                do
                {
                    s = rnd.Next(0, this.soDinh);
                    e = rnd.Next(0, this.soDinh);
                    if (s == e || this.distance[s, e] != this.VOCUNG || (s == this.start && e == this.end))
                    {
                        continue;
                    }

                    this.distance[s, e] = entities.Point.Distance(lstPoint[s], lstPoint[e]);
                    break;
                } while (true);

            }
        }

        void ShowGraph()
        {
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            graph.CreateGeometryGraph();

            //create the graph content 
            // graph.AddEdge("A", "B");
            int i = 1;
            foreach (var item in lstPoint)
            {
                Node node = new Node(i.ToString());
                node.Attr.Shape = Shape.Circle;
                graph.AddNode(node);
                i++;
            }

            graph.FindNode((this.start+1).ToString()).Attr.FillColor = Color.Blue;
            graph.FindNode((this.end+1).ToString()).Attr.FillColor = Color.Red;

            for (int j = 0; j < this.soDinh; j++)
            {
                for (int k = 0; k < this.soDinh; k++)
                {
                    if (this.distance[j, k] != this.VOCUNG && this.distance[j, k] != 0)
                    {
                        String tmp = "," + (j + 1).ToString()+","+ (k + 1).ToString() + ",";
                        if (this.path.Contains(tmp))
                        {
                            graph.AddEdge((j + 1).ToString(), (k + 1).ToString()).Attr.Color = Color.Green;
                        }
                        else
                        {
                            graph.AddEdge((j + 1).ToString(), (k + 1).ToString());
                        }
                        
                    }
                }
            }

            /*graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            Edge edge = new Edge("14","sonnx","15");

            graph.AddEdge("14", "sonnx", "15");
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;*/


            //bind the graph to the viewer 
            viewer.Graph = graph;
            this.groupBoxResult.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxResult.Controls.Add(viewer);
            this.groupBoxResult.ResumeLayout();

            MessageBox.Show("Độ dài ngắn nhất " + (d[this.end]).ToString(), "Thành công");
        }

        void Dijkstra()
        {
            int u = this.start;
            double minp;
            //khởi tạo nhãn tạm thời cho các đỉnh.
            for (int v = 0; v <= this.soDinh; v++)
            {
                d[v] = this.distance[this.start,v];
                truoc[v] = this.start;
                chuaxet[v] = false;
            }
            truoc[this.start] = 0;
            d[this.start] = 0;
            chuaxet[this.start] = true;
            //bươc lặp
            while (!chuaxet[this.end])
            {
                minp = this.VOCUNG;
                //tìm đỉnh u sao cho d[u] là nhỏ nhất
                for (int v = 0; v < this.soDinh; v++)
                {
                    if ((!chuaxet[v]) && (minp > d[v]))
                    {
                        u = v;
                        minp = d[v];
                    }
                }
                chuaxet[u] = true;// u la dinh co nhan tam thoi nho nhat
                if (!chuaxet[this.end])
                {
                    //gán nhãn lại cho các đỉnh.
                    for (int v = 0; v < this.soDinh; v++)
                    {
                        if ((!chuaxet[v]) && (d[u] + this.distance[u,v] < d[v]))
                        {
                            d[v] = d[u] + this.distance[u,v];
                            truoc[v] = u;
                        }
                    }
                }
            }

            int i = truoc[this.end];
            while (i != this.start)
            {
                this.path = (i+1) + "," + path;
                i = truoc[i];
            }

            this.path = "," + (this.start+1) + "," + path;
        }
    }

}
