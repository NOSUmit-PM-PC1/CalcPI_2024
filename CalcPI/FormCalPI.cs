using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcPI
{
    public partial class FormCalPI : Form
    {
        Graphics g;
        int countCirclePoints = 0, countSquarePoints = 0;
        int xCenterCircle = 250, yCenterCircle = 250, rCircle = 150;
        Random rnd = new Random();
        double proximalyValuePI = 0;

        public FormCalPI()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void buttonGeneratePoints_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                int x = rnd.Next(100, 400);
                int y = rnd.Next(100, 400);
                countPointsInCircleAndSquare(x, y);
            }
        }

        void countPointsInCircleAndSquare(int x, int y)
        {
            // нарисовала точку
            g.FillEllipse(Brushes.Red, x, y, 2, 2);
            // считаем количество точек в квадрате
            if (x > 100 && x < 400 && y > 100 && y < 400)
            {
                countSquarePoints++;
                labelCountSquarePoints.Text = countSquarePoints.ToString();
            }
            // считаем количество в круге
            double distance = Math.Sqrt((xCenterCircle - x) * (xCenterCircle - x) + (yCenterCircle - y) * (yCenterCircle - y));
            if (distance < rCircle)
            {
                countCirclePoints++;
                labelCountCirclePoints.Text = countCirclePoints.ToString();
            }
            proximalyValuePI = 4.0 * (float)countCirclePoints / countSquarePoints;
            labelValuePI.Text = proximalyValuePI.ToString();

        }

        private void FormCalPI_MouseDown(object sender, MouseEventArgs e)
        {
            // нарисовала круг и квадрат
            g.DrawRectangle(Pens.Blue, 100, 100, 300, 300);
            g.DrawEllipse(Pens.Green, 100, 100, 300, 300);
            countPointsInCircleAndSquare(e.X, e.Y);
        }
    }
}
