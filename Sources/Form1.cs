using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public bool leftButtonMouse = false;
        public int deltaX, deltaY;
        public Graphics GRAP;
        public Pen p;
        public Color col = Color.CornflowerBlue;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            GRAP = panel2.CreateGraphics();
            p = new Pen(col, trackBar1.Value);

            p.StartCap = p.EndCap = LineCap.Round;
            GRAP.SmoothingMode = SmoothingMode.HighQuality;
            GRAP.InterpolationMode = InterpolationMode.High;
            GRAP.PixelOffsetMode = PixelOffsetMode.HighQuality;

            leftButtonMouse = true;
            deltaX = e.X;
            deltaY = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            leftButtonMouse = false;
            GRAP.Dispose();
            p.Dispose();
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftButtonMouse)
            {
                GRAP.DrawLine(p, new Point(deltaX, deltaY), e.Location);
                deltaX = e.X;
                deltaY = e.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            leftButtonMouse = true;
            deltaX = e.X;
            deltaY = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            leftButtonMouse = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog.Color = col;
            if (colorDialog.ShowDialog() == DialogResult.OK)
                col = colorDialog.Color;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString() + " px";
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.BackColor = new Color();            
            panel2.BackColor = Color.White;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftButtonMouse)
            {
                // Get the difference between the two points
                int getX = deltaX - e.Location.X;
                int getY = deltaY - e.Location.Y;

                // Set the new point
                int setX = Location.X - getX;
                int setY = Location.Y - getY;

                Location = new Point(setX, setY);
            }
        }
    }
}