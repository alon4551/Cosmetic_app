using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Forms
{
    public partial class Signature : Form
    {
        private bool isMouseDrawing = false;
        public bool Sign=false;
        private List<Point> points = new List<Point>();
        public Bitmap signture = null;
        public Signature()
        {
            InitializeComponent();
            panel1.Paint += Panel1_Paint;
            panel1.MouseDown += Panel1_MouseDown;
            panel1.MouseMove += Panel1_MouseMove;
            panel1.MouseUp += Panel1_MouseUp;

            // Create and configure the "Clear" button
            Button clearButton = new Button();
            clearButton.Text = "Clear";
            clearButton.Location = new Point(10, 10);
            clearButton.Click += ClearButton_Click;

            // Add the "Clear" button to the form
            Controls.Add(clearButton);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the signature based on the captured points
            using (Pen pen = new Pen(Color.Black, 2))
            {
                for (int i = 1; i < points.Count; i++)
                {
                    e.Graphics.DrawLine(pen, points[i - 1], points[i]);
                }
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDrawing = true;
            points.Clear();
            points.Add(e.Location);
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDrawing)
            {
                points.Add(e.Location);
                panel1.Invalidate(); // Trigger the Paint event to redraw the signature
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDrawing = false;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            panel1.Invalidate(); // Trigger the Paint event to clear the signature
        }

        private void button1_Click(object sender, EventArgs e)
        {//saveing signture
            if (MessageBox.Show("האם זה חתימה מאושרת", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                signture = new Bitmap(panel1.Width, panel1.Height);
                panel1.DrawToBitmap(signture, new Rectangle(0, 0, panel1.Width, panel1.Height));
                Sign = true;
                this.Close();
            }

        }
        public Bitmap GetSignatureBitmap()
        {//reset drawing panel
            signture.MakeTransparent(Color.White);
            return signture;
        }
    }

}

