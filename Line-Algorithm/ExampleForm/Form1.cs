using Line_Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleForm
{
    public partial class Form1 : Form
    {
        Graphics g = null;
        ILineAlgorithm al;
        Line_Algorithm.Point sp = null;
        Line_Algorithm.Point ep = null;

        IPolygon ip;
        List<Line_Algorithm.Point> polygon = null;
        public Form1()
        {
            InitializeComponent();
            g=this.CreateGraphics();
            polygon = new List<Line_Algorithm.Point>()
            {
                new Line_Algorithm.Point()
                {
                    X =20,
                    Y =20
                },
                new Line_Algorithm.Point()
                {
                    X =50,
                    Y =10
                },
                 new Line_Algorithm.Point()
                {
                    X =110,
                    Y =30
                },
                  new Line_Algorithm.Point()
                {
                    X =110,
                    Y =80
                },
                   new Line_Algorithm.Point()
                {
                    X =50,
                    Y =50
                },
                    new Line_Algorithm.Point()
                {
                    X =20,
                    Y =70
                },
            };
        }

        private void GetPointValue()
        {
            int startX =int.Parse(LineSXBox.Text);
            int startY =int.Parse(LineSYBox.Text);
            int endX =int.Parse(LineEXBox.Text);
            int endY = int.Parse(LineEYBox.Text);
            sp = new Line_Algorithm.Point()
            {
                RealX = startX,
                RealY = startY,
                X = startX,
                Y = startY
            };
            ep = new Line_Algorithm.Point()
            {
                RealX = endX,
                RealY = endY,
                X = endX,
                Y = endY
            };
        }
        private void DrawLine(Brush brush)
        {
            var ps = al.GetPoints(sp, ep);

            foreach (var p in ps)
            {
                g.FillRectangle(brush, p.X, p.Y, 2, 2);

            }
        }
        private void DrawPolygon(Brush brush)
        {
            var ps = ip.GetPoints(polygon);

            foreach (var p in ps)
            {
                g.FillRectangle(brush, p.X, p.Y, 2, 2);

            }
        }
        private void DDABtn_Click(object sender, EventArgs e)
        {

            g.Clear(Color.White);
            al = new DDA();

            GetPointValue();

            DrawLine(Brushes.Black);
        }

        private void CenterBtn_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            al = new Center();

            GetPointValue();

            DrawLine(Brushes.Blue);
        }

        private void BresenhamBtn_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            al = new Center();

            GetPointValue();

            DrawLine(Brushes.Red);
        }

        private void ImprScanBtn_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            ip = new ImprovedScan();


            DrawPolygon(Brushes.Blue);
        }

        private void ScanBtn_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            ip = new XScan();


            DrawPolygon(Brushes.Red);
        }
    }
}
