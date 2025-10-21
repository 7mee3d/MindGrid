using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class MindGrid : Form
    {
        public MindGrid()
        {
            InitializeComponent();
        }

        private void DrawLinesTicTacToeGrid(PaintEventArgs eventPaint )
        {
            Color White = Color.White;

            Pen pen = new Pen(White);
            pen.Width = 9;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round; 
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //LineOneVirtical 

            Point point1VIR1 = new Point(890, 115);
            Point point2VIR1 = new Point(890, 700);

            eventPaint.Graphics.DrawLine(pen, point1VIR1, point2VIR1);

            //LineTwoVirtical 

            Point point1VIR2 = new Point(1115, 115);
            Point point2VIR2 = new Point(1115, 700);

            eventPaint.Graphics.DrawLine(pen, point1VIR2, point2VIR2);


            //LineOneHorizantal 

            Point point1Hori1 = new Point(700, 310);
            Point point2HORI1 = new Point(1300, 310);

            eventPaint.Graphics.DrawLine(pen, point1Hori1, point2HORI1);

            //LineTwoHorizantal 

            Point point1Hori2 = new Point(700, 520);
            Point point2HORI2 = new Point(1300, 520);

            eventPaint.Graphics.DrawLine(pen, point1Hori2, point2HORI2);
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void MindGrid_Paint(object sender, PaintEventArgs e)
        {
            DrawLinesTicTacToeGrid(e); 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
