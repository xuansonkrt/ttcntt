using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;

namespace TTCNTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //create a form 
           // System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "A");
            graph.AddEdge("B", "C");

            graph.AddEdge("1", "6");
            graph.AddEdge("2", "5");
            graph.AddEdge("3", "2");
            graph.AddEdge("4", "1");
            graph.AddEdge("5", "2");
            graph.AddEdge("6", "2");
            graph.AddEdge("7", "4");
            graph.AddEdge("8", "10");
            graph.AddEdge("9", "9");
            graph.AddEdge("10", "6");
            graph.AddEdge("1", "5");
            graph.AddEdge("2", "3");
            graph.AddEdge("3", "6");
            graph.AddEdge("4", "7");
            Node node = new Node("111");
            node.Attr.Shape = Shape.Circle;
            graph.AddNode(node);
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            Edge edge = new Edge("14","sonnx","15");
            
            graph.AddEdge("14", "sonnx", "15");
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            this.groupBoxResult.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            
            // this.Controls.Add(viewer);
            this.groupBoxResult.Controls.Add(viewer);
            this.groupBoxResult.ResumeLayout();
            //show the form 
           // this.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
