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
using Microsoft.Msagl.Miscellaneous.RegularGrid;
using Color = Microsoft.Msagl.Drawing.Color;
using Node = Microsoft.Msagl.Drawing.Node;
using Point = System.Drawing.Point;
using Rectangle = Microsoft.Msagl.Core.Geometry.Rectangle;

namespace TTCNTT
{
    public partial class Form1 : Form
    {
        static int MAX_SIZE = 20;
        static int MAX_POSITION = 100;
        private Random rnd = new Random();
        private int soDinh;
        private int soCanh;
        private int start;
        private int end;
        double[,] distance = new double[MAX_SIZE, MAX_SIZE];
        List<entities.Point> lstPoint = new List<entities.Point>();
        private bool[] daxet = new bool[MAX_SIZE];
        private int[] truoc = new int[MAX_SIZE]; // luu hanh trinh
        private double[] d = new double[MAX_SIZE]; // luu khoang cach toi dinh thu i
        private int VOCUNG = Int32.MaxValue;
        private String path = "";
        private bool inputOK = false;
        public Form1()
        {
            InitializeComponent();
            //create a form 
            // System.Windows.Forms.Form form = new System.Windows.Forms.Form();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool inputData()
        {
            this.groupBoxResult.Controls.Clear();
            this.distance = new double[MAX_SIZE, MAX_SIZE];
            this.lstPoint = new List<entities.Point>();
            path = "";
            daxet = new bool[MAX_SIZE];
            d = new double[MAX_SIZE];
            d = new double[MAX_SIZE];
            if (txtSoDinh.Text.Equals("") || txtSoCanh.Text.Equals("")
                                          || txtStart.Text.Equals("") || txtEnd.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Có lỗi xảy ra");
                this.txtSoDinh.Focus();
                return false;
            }

            /*try
            {*/
                soDinh = Int32.Parse(this.txtSoDinh.Text);
                soCanh = Int32.Parse(this.txtSoCanh.Text);
                start = Int32.Parse(this.txtStart.Text) - 1;
                end = Int32.Parse(this.txtEnd.Text) - 1;

                int max = (soDinh * (soDinh - 1) / 2);


                if (soDinh > MAX_SIZE)
                {
                    MessageBox.Show("Số đỉnh tối đa là " + MAX_SIZE.ToString(),
                        "Có lỗi xảy ra");
                    this.txtSoDinh.Focus();
                    return false;
                }

                if (soCanh > max)
                {
                    MessageBox.Show("Với số đỉnh là " + soDinh.ToString() + " thì số cạnh tối đa là " + max.ToString(),
                        "Có lỗi xảy ra");
                    this.txtSoCanh.Focus();
                    return false;
                }

                if (start < 0 || start >= soDinh)
                {
                    MessageBox.Show("Điểm bắt đầu không hợp lệ", "Có lỗi xảy ra");
                    this.txtStart.Focus();
                    return false;
                }

                if (end < 0 || end >= soDinh)
                {
                    MessageBox.Show("Điểm kết thúc không hợp lệ", "Có lỗi xảy ra");
                    this.txtEnd.Focus();
                    return false;
                }

                this.inputOK = true;
                return true;
                /*}
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "Có lỗi xảy ra");
                    return;
                    throw;
                }*/
        }
        private void btnXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.inputData())
                {
                    this.InitData();
                    this.Dijkstra();
                    this.ShowGraph(true);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại", "Có lỗi xảy ra");
                this.inputOK = false;
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
                    int x = rnd.Next(-MAX_POSITION, MAX_POSITION);
                    int y = rnd.Next(-MAX_POSITION, MAX_POSITION);
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
                    s = rnd.Next(0, this.soDinh-1);
                    e = rnd.Next(0, this.soDinh-1);
                    if (s == e || this.distance[s, e] != this.VOCUNG || (s == this.start && e == this.end))
                    {
                        continue;
                    }

                    this.distance[s, e] = entities.Point.Distance(lstPoint[s], lstPoint[e]);
                    break;
                } while (true);

            }
        }

        void ShowGraph(bool showMes)
        {
            this.groupBoxResult.Controls.Clear();
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            graph.CreateGeometryGraph();
            int i = 1;
            foreach (var item in lstPoint)
            {
                Node node = new Node(i.ToString());
                node.Attr.Shape = Shape.Circle;
                graph.AddNode(node);
                i++;
            }

            graph.FindNode((this.start + 1).ToString()).Attr.FillColor = Color.Blue;
            graph.FindNode((this.end + 1).ToString()).Attr.FillColor = Color.Red;
           viewer.Pan(5,2);
            for (int j = 0; j < this.soDinh; j++)
            {
                for (int k = 0; k < this.soDinh; k++)
                {
                    if (this.distance[j, k] != this.VOCUNG && this.distance[j, k] != 0)
                    {
                        String tmp = "," + (j + 1).ToString() + "," + (k + 1).ToString() + ",";
                        double dis = Math.Round(this.distance[j, k], 2);
                        if (this.path.Contains(tmp))
                        {
                            if (this.checkBox.Checked)
                            {
                                graph.AddEdge((j + 1).ToString(), dis.ToString(), (k + 1).ToString()).Attr.Color = Color.Green;
                            }
                            else
                            {
                                graph.AddEdge((j + 1).ToString(), (k + 1).ToString()).Attr.Color = Color.Green;
                            }
                            // Microsoft.Msagl.Core.Layout.Node node = new Microsoft.Msagl.Core.Layout.Node(1, 2);

                        }
                        else
                        {
                            if (this.checkBox.Checked)
                            {
                                graph.AddEdge((j + 1).ToString(), dis.ToString(), (k + 1).ToString());
                            }
                            else
                            {
                                graph.AddEdge((j + 1).ToString(),  (k + 1).ToString());
                            }
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


/*

            Microsoft.Msagl.Core.Geometry.Point p1 = new Microsoft.Msagl.Core.Geometry.Point(-497.12352212078628, 1689.84931190121);
            Microsoft.Msagl.Core.Geometry.Point p2 = new Microsoft.Msagl.Core.Geometry.Point(198.64235142705752, 2139.4677380013277);
            Microsoft.Msagl.Core.Geometry.Point bl = new Microsoft.Msagl.Core.Geometry.Point(-5191.0147700187063, -4395.7850131819132);
            double gridSize = 553.23948409846571;

            GridTraversal grid = new GridTraversal(new Rectangle(bl, bl + new Microsoft.Msagl.Core.Geometry.Point(gridSize, gridSize)), 20);
            var tiles = grid.GetTilesIntersectedByLineSeg(p1, p2);
            */
            

            //bind the graph to the viewer 
            viewer.Graph = graph;
           // viewer.Click += new EventHandler(Group_Click);
          //  viewer.MouseClick += new MouseEventHandler(Group_Click);
            this.groupBoxResult.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxResult.Controls.Add(viewer);
            this.groupBoxResult.ResumeLayout();

            if (showMes)
            {
                if (this.daxet[this.end])
                {
                    MessageBox.Show("Độ dài đường đi ngắn nhất " + (Math.Round(d[this.end], 2)).ToString(), "Thành công");
                    this.txtLoTrinh.Text = this.path;
                    this.txtDoDai.Text = (Math.Round(d[this.end], 2)).ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm được đường đi ngắn nhất", "Có lỗi xảy ra");
                    this.txtLoTrinh.Text = "";
                    this.txtDoDai.Text = "";
                }
            }
            
            
        }

        private void Group_Click(object sender, EventArgs e)
        {
            GViewer viewer = sender as GViewer;
            if (viewer.SelectedObject is Node)
            {
                Node node = viewer.SelectedObject as Node;
                //...do works here
            }
        }

        void Dijkstra()
        {
            int u = this.start;
            double minp;
            //khởi tạo nhãn tạm thời cho các đỉnh.
            for (int v = 0; v < this.soDinh; v++)
            {
                d[v] = this.distance[this.start, v];
                truoc[v] = this.start;
                daxet[v] = false;
            }

            truoc[this.start] = 0;
            d[this.start] = 0;
            daxet[this.start] = true;
            //bươc lặp
            int loop = this.soDinh;
            while (loop-- > 0)
            {
                minp = this.VOCUNG;
                //tìm đỉnh u sao cho d[u] là nhỏ nhất
                for (int v = 0; v < this.soDinh; v++)
                {
                    if ((!daxet[v]) && (minp > d[v]))
                    {
                        u = v;
                        minp = d[v];
                    }
                }

                daxet[u] = true; // u la dinh co nhan tam thoi nho nhat
                if (!daxet[this.end])
                {
                    //gán nhãn lại cho các đỉnh.
                    for (int v = 0; v < this.soDinh; v++)
                    {
                        if ((!daxet[v]) && (d[u] + this.distance[u, v] < d[v]))
                        {
                            d[v] = d[u] + this.distance[u, v];
                            truoc[v] = u;
                        }
                    }
                }

                if (daxet[this.end])
                {
                    break;
                }
            }

            int i = truoc[this.end];
            path = (this.end+1) + ",";
            while (i != this.start)
            {
                this.path = (i + 1) + "," + path;
                i = truoc[i];
            }

            this.path = "," + (this.start + 1) + "," + path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.groupBoxResult.Controls.Clear();
            this.distance = new double[MAX_SIZE, MAX_SIZE];
            this.lstPoint = new List<entities.Point>();
            path = "";
            daxet = new bool[MAX_SIZE];
            d = new double[MAX_SIZE];
            d = new double[MAX_SIZE];
            if (txtSoDinh.Text.Equals("") || txtSoCanh.Text.Equals("")
                                          || txtStart.Text.Equals("") || txtEnd.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Có lỗi xảy ra");
                this.txtSoDinh.Focus();
                return;
            }

            try
            {
                soDinh = Int32.Parse(this.txtSoDinh.Text);
                soCanh = Int32.Parse(this.txtSoCanh.Text);
                start = Int32.Parse(this.txtStart.Text) - 1;
                end = Int32.Parse(this.txtEnd.Text) - 1;

                int max = (soDinh * (soDinh - 1) / 2);


                if (soDinh > MAX_SIZE)
                {
                    MessageBox.Show("Số đỉnh tối đa là " + MAX_SIZE.ToString(),
                        "Có lỗi xảy ra");
                    this.txtSoDinh.Focus();
                    return;
                }

                if (soCanh > max)
                {
                    MessageBox.Show("Với số đỉnh là " + soDinh.ToString() + " thì số cạnh tối đa là " + max.ToString(),
                        "Có lỗi xảy ra");
                    this.txtSoCanh.Focus();
                    return;
                }

                if (start < 0 || start >= soDinh)
                {
                    MessageBox.Show("Điểm bắt đầu không hợp lệ", "Có lỗi xảy ra");
                    this.txtStart.Focus();
                    return;
                }

                if (end < 0 || end >= soDinh)
                {
                    MessageBox.Show("Điểm kết thúc không hợp lệ", "Có lỗi xảy ra");
                    this.txtEnd.Focus();
                    return;
                }

                this.InitData();
                // this.Dijkstra();
                this.ShowGraph(true);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Có lỗi xảy ra");
                return;
                throw;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(this.inputOK)
                this.ShowGraph(false);
        }
    }


}
