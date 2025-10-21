using MindGrid.Properties;
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

        //Enumrations 
        enum enTurnPlayers
        {
            ekPLAYER_ONE = 1,
            ekPLAYER_TWO = 2
        }

        enum enWinnerGame
        {
            ekPLAYER_ONE = 1 , 
            ekPALYER_TWO = 2 , 
            ekDRAW = 3 , 
            ekIN_PROSSES = 4 
        }

        private string howTurnToGame(enTurnPlayers whatPlayer)
        {
            if (whatPlayer == enTurnPlayers.ekPLAYER_ONE) {

               labelHowTurnNow.ForeColor = Color.FromArgb(255, 140, 250); 
                return "Player1";
            }
            else
            {
                labelHowTurnNow.ForeColor = Color.FromArgb(212, 255, 114);
                return "Player2";
            }

        }
        


        //Constant Game
        private const ushort _NUMBER_ROW_ARRAY = 3;
        private const ushort _NUMBER_COLUMN_ARRAY = 3;

        //Private Variable 
        private ushort countGame = 0;         
        private PictureBox[,] arrayPictureBoxMindGrid = new PictureBox[_NUMBER_ROW_ARRAY, _NUMBER_COLUMN_ARRAY];
        private enTurnPlayers startFirstGame = enTurnPlayers.ekPLAYER_ONE;


        private void InitialSettingMindGrid()
        {
            startFirstGame = enTurnPlayers.ekPLAYER_ONE;
            labelWhoWinnerGame.ForeColor = Color.White;
            labelWhoWinnerGame.Text = "In Process";
            ResetPictureBoxControl();
            labelHowTurnNow.Text = howTurnToGame(startFirstGame);
            InitializationArrayPictureBoxies();
            countGame = 0;
     
        }
    
        private void InitializationArrayPictureBoxies()
        {

            arrayPictureBoxMindGrid[0, 0] = pictureBox1;
            arrayPictureBoxMindGrid[0, 1] = pictureBox2;
            arrayPictureBoxMindGrid[0, 2] = pictureBox3;
            arrayPictureBoxMindGrid[1, 0] = pictureBox4;
            arrayPictureBoxMindGrid[1, 1] = pictureBox5;
            arrayPictureBoxMindGrid[1, 2] = pictureBox6;
            arrayPictureBoxMindGrid[2, 0] = pictureBox7;
            arrayPictureBoxMindGrid[2, 1] = pictureBox8;
            arrayPictureBoxMindGrid[2, 2] = pictureBox9;

        }
      
        private enWinnerGame WhoWinnerGame()
        {
            for (int counter = 0; counter < _NUMBER_ROW_ARRAY; counter++)
            {
                //Row
                if (
                       (arrayPictureBoxMindGrid[counter, 0].Tag == "X" && arrayPictureBoxMindGrid[counter, 1].Tag == "X" && arrayPictureBoxMindGrid[counter, 2].Tag == "X") ||
                        (arrayPictureBoxMindGrid[0, counter].Tag == "X" && arrayPictureBoxMindGrid[1, counter].Tag == "X" && arrayPictureBoxMindGrid[2, counter].Tag == "X")
                    ) return enWinnerGame.ekPLAYER_ONE;

                //Column
                if (
                      (arrayPictureBoxMindGrid[counter, 0].Tag == "O" && arrayPictureBoxMindGrid[counter, 1].Tag == "O" && arrayPictureBoxMindGrid[counter, 2].Tag == "O") ||
                       (arrayPictureBoxMindGrid[0, counter].Tag == "O" && arrayPictureBoxMindGrid[1, counter].Tag == "O" && arrayPictureBoxMindGrid[2, counter].Tag == "O")
                   ) return enWinnerGame.ekPALYER_TWO;
            }

            //Diagonal
            if ((arrayPictureBoxMindGrid[0, 2].Tag == "X" && arrayPictureBoxMindGrid[1, 1].Tag == "X" && arrayPictureBoxMindGrid[2, 0].Tag == "X") ||
                (arrayPictureBoxMindGrid[0, 0].Tag == "X" && arrayPictureBoxMindGrid[1, 1].Tag == "X" && arrayPictureBoxMindGrid[2, 2].Tag == "X")
                ) return enWinnerGame.ekPLAYER_ONE;

            if ((arrayPictureBoxMindGrid[0, 2].Tag == "O" && arrayPictureBoxMindGrid[1, 1].Tag == "O" && arrayPictureBoxMindGrid[2, 0].Tag == "O") ||
             (arrayPictureBoxMindGrid[0, 0].Tag == "O" && arrayPictureBoxMindGrid[1, 1].Tag == "O" && arrayPictureBoxMindGrid[2, 2].Tag == "O")
                 ) return enWinnerGame.ekPALYER_TWO;



            return enWinnerGame.ekIN_PROSSES;
        }

        private string WhoWinnerInGame(enWinnerGame whowinner)
        {
            if (whowinner == enWinnerGame.ekPLAYER_ONE) return "Player1";
            else if (whowinner == enWinnerGame.ekPALYER_TWO) return "Player2";
            else if (countGame == 9) return "Draw";

            return "In Process";
        }

        private void changeImagesPictureBoxAndTurnGame (ref PictureBox PB , ushort row , ushort column/* , PictureBox[,] arrayPictureBoxies */ )
        {

            if (startFirstGame == enTurnPlayers.ekPLAYER_ONE)
            {
                PB.Image = Resources.X_Image_Tic_Tac_Toe;
                PB.Tag = "X";
                startFirstGame = enTurnPlayers.ekPLAYER_TWO;
                labelHowTurnNow.Text = howTurnToGame(startFirstGame);
            }
            else
            {
                PB.Image = Resources.O_Image_Tic_Tac_Toe;
                PB.Tag = "O";
                startFirstGame = enTurnPlayers.ekPLAYER_ONE;
                labelHowTurnNow.Text = howTurnToGame(startFirstGame);
            }

            countGame++;
            PB.Enabled = false;
            labelWhoWinnerGame.Text =  WhoWinnerInGame(WhoWinnerGame());
            ShowMessageBoxAfterWinner(labelWhoWinnerGame.Text);
        }

        private void ResetPictureBoxControl()
        {
            foreach (Control outterControl in this.Controls )
            {
                if (outterControl is PictureBox PB)
                {
                        PB.Image = Resources.NOT_Image;
                        PB.Tag = "";
                        PB.Enabled = true;

                }
            }
        }
     
        private void ShowMessageBoxAfterWinner (string wordWinner)
        {
            if (wordWinner == "Player1")
            {
                labelWhoWinnerGame.ForeColor = Color.FromArgb(255, 140, 250);
                MessageBox.Show
                    ($"The Winner this Round Game [ {wordWinner} ] "
                    , "Who Winner Game"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }

            if (wordWinner == "Player2")
            {
                labelWhoWinnerGame.ForeColor = Color.FromArgb(212, 255, 114);
                MessageBox.Show
                    ($"The Winner this Round Game [ {wordWinner} ] "
                    , "Who Winner Game"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }


            if (countGame == 9 && wordWinner == "Draw")
            {
                labelWhoWinnerGame.ForeColor = Color.FromArgb(155, 213, 255);
                MessageBox.Show
                    ($"No The Winner [ Draw ] this Round Game"
                    , "Who Winner Game"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }

        }
 
        public MindGrid()
        {
            InitializeComponent();
            InitialSettingMindGrid();
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

        private void MindGrid_Paint(object sender, PaintEventArgs e)
        {
            DrawLinesTicTacToeGrid(e); 
        }


        // Events Picture
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            changeImagesPictureBoxAndTurnGame(ref pictureBox2, 0, 1 /*arrayPictureBoxMindGrid*/);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            changeImagesPictureBoxAndTurnGame(ref pictureBox5, 1, 1 /*arrayPictureBoxMindGrid*/);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            changeImagesPictureBoxAndTurnGame(ref pictureBox6, 1, 2 /*arrayPictureBoxMindGrid*/);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            changeImagesPictureBoxAndTurnGame(ref pictureBox4, 1, 0 /*arrayPictureBoxMindGrid*/);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            changeImagesPictureBoxAndTurnGame(ref pictureBox3, 0, 2 /*arrayPictureBoxMindGrid*/);

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            changeImagesPictureBoxAndTurnGame(ref pictureBox8, 2,1  /*arrayPictureBoxMindGrid*/);

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            changeImagesPictureBoxAndTurnGame(ref pictureBox7, 2, 0 /*arrayPictureBoxMindGrid*/);

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            changeImagesPictureBoxAndTurnGame(ref pictureBox9, 2, 2  /*arrayPictureBoxMindGrid*/);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            changeImagesPictureBoxAndTurnGame(ref pictureBox1, 0, 0 /*arrayPictureBoxMindGrid*/); 
        }

        //Start Section Control Buttons 
        private void GButtonExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GButtonRestartGame_Click(object sender, EventArgs e)
        {
            InitialSettingMindGrid();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelTimeNow.Text = DateTime.Now.ToString();
        }
    }
}
