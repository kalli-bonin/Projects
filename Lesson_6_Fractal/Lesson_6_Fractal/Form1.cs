using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_6_Fractal
{
    public partial class Form1 : Form
    {
        Point[] hexagon = new Point[8];

        public Form1()
        {
            InitializeComponent();
        }

        
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int n;

                Point centre;

                centre = new Point();

                centre.X = 300;
                centre.Y = 300;

                n = Convert.ToInt32(txtIterations.Text);

                Pen first = new Pen(Color.FromArgb(113, 178, 128), 1);
                Pen second = new Pen(Color.FromArgb(89, 153, 119), 1);
                Pen third = new Pen(Color.FromArgb(66, 128, 111), 1);
                Pen fourth = new Pen(Color.FromArgb(42, 103, 102), 1);
                Pen fifth = new Pen(Color.FromArgb(19, 78, 94), 1);
                Pen sixth = new Pen(Color.FromArgb(184, 216, 191), 1);


                Graphics g = Graphics.FromHwnd(pbFractal.Handle);
                g.Clear(Color.Black);
                Generate_CentreHexagon(n, g, 170, centre, fifth, 2.3);
                Generate_CentreHexagon(n, g, 140, centre, fourth, 2.3);
                Generate_CentreHexagon(n, g, 115, centre, third, 2.6);
                Generate_CentreHexagon(n, g, 80, centre, second, 2.65);
                Generate_CentreHexagon(n, g, 57, centre, first, 3);
                Generate_CentreHexagon(n, g, 40, centre, sixth, 3.5);
            }
            catch
            {
                MessageBox.Show("ERROR: Invalid input.");
            }

        }

        public void Generate_CentreHexagon(int n, Graphics g, int radius, Point origin, Pen myHexagon, double factor)
        {
            if (n == 0)
                return;

            else
            {
                Point p1, p2, p3, p4, p5, p6, p7, p8;

                p1 = new Point();
                p2 = new Point();
                p3 = new Point();
                p4 = new Point();
                p5 = new Point();
                p6 = new Point();
                p7 = new Point();
                p8 = new Point();

                p1.X = origin.X - radius;
                p1.Y = origin.Y;

                p2.X = origin.X - Convert.ToInt32(Math.Sqrt((radius * radius) / 2));
                p2.Y = origin.Y - Convert.ToInt32(Math.Sqrt((radius * radius) / 2));

                p3.X = origin.X;
                p3.Y = origin.Y - radius;

                p4.X = origin.X + Convert.ToInt32(Math.Sqrt((radius * radius) / 2));
                p4.Y = origin.Y - Convert.ToInt32(Math.Sqrt((radius * radius) / 2));

                p5.X = origin.X + radius;
                p5.Y = origin.Y;

                p6.X = origin.X + Convert.ToInt32(Math.Sqrt((radius * radius) / 2));
                p6.Y = origin.Y + Convert.ToInt32(Math.Sqrt((radius * radius) / 2));

                p7.X = origin.X;
                p7.Y = origin.Y + radius;

                p8.X = origin.X - Convert.ToInt32(Math.Sqrt((radius * radius) / 2));
                p8.Y = origin.Y + Convert.ToInt32(Math.Sqrt((radius * radius / 2)));

                Point[] hexagon = new Point[8];

                hexagon[0] = p1;
                hexagon[1] = p2;
                hexagon[2] = p3;
                hexagon[3] = p4;
                hexagon[4] = p5;
                hexagon[5] = p6;
                hexagon[6] = p7;
                hexagon[7] = p8;

                g.DrawPolygon(myHexagon, hexagon);

                radius = Convert.ToInt32(radius / factor);

                Generate_CentreHexagon(n - 1, g, radius, hexagon[0], myHexagon, factor);
                Generate_CentreHexagon(n - 1, g, radius, hexagon[1], myHexagon, factor);
                Generate_CentreHexagon(n - 1, g, radius, hexagon[2], myHexagon, factor);
                Generate_CentreHexagon(n - 1, g, radius, hexagon[3], myHexagon, factor);
                Generate_CentreHexagon(n - 1, g, radius, hexagon[4], myHexagon, factor);
                Generate_CentreHexagon(n - 1, g, radius, hexagon[5], myHexagon, factor);
                Generate_CentreHexagon(n - 1, g, radius, hexagon[6], myHexagon, factor);
                Generate_CentreHexagon(n - 1, g, radius, hexagon[7], myHexagon, factor);
            }
        }
       
    }
}
