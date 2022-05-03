using ChessBoardLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChessProject
{
    partial class Form1 : Form
    {
        private bool ChessShowToggle=false;
        private ChessSquare oldSquare;
        static ChessBoard myBoard = new ChessBoard(8);
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        public Form1()
        {
            InitializeComponent();
            populateGrid();

        }

        private void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            //make the panel a perfect square just in case
            
            panel1.Height = panel1.Width;

            for (int i = 0; i <myBoard.Size; i++)
            {
                for(int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    btnGrid[i,j].Height = buttonSize;
                    btnGrid[i,j].Width = buttonSize;
                    //add a click event to each button.
                    btnGrid[i, j].Click += Grid_Button_Click;
                    panel1.Controls.Add(btnGrid[i,j]);
                    btnGrid[i, j].Location = new Point( (i * buttonSize), j * buttonSize);
                    btnGrid[i, j].Text = i + "|" + j;
                    btnGrid[i, j].Tag = new Point(i, j);
                }
            }

        }



        private void UpdateTheGrid()
        {
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    if (myBoard.theGrid[i, j].LegalNextMove == true)
                    {
                        //btnGrid[i, j].Text = "Legal";
                        btnGrid[i, j].BackColor = System.Drawing.Color.Green;
                    }
                    else if (myBoard.theGrid[i, j].CurrentlyOccupied == true)
                    {
                        btnGrid[i, j].Text = myBoard.theGrid[i, j].OccupiedPiece.Name;

                    }
                    else
                    {
                        btnGrid[i, j].Text = i + "|" + j;
                        btnGrid[i, j].BackColor = System.Drawing.Color.Empty;
                    }

                }
            }
        }
    
        private void Grid_Button_Click(object sender, EventArgs e)
        {

            //get the row/col number of the button clicked
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            //if oldcell=newcell || newcell.occupied=1
            //    clear
            //else if newcell=legalmove
            //    move to that cell
            //btnGrid[i, j].BackColor = System.Drawing.Color.DarkGray;
            
            int x = location.X;
            int y = location.Y;

            ChessSquare currentCell = myBoard.theGrid[x,y];
            if(currentCell.CurrentlyOccupied && !ChessShowToggle)
            {
                oldSquare = currentCell;
                myBoard.MarkNextLegalMoves(currentCell, currentCell.OccupiedPiece.Name);
                ChessShowToggle = true;
            }
            else if (currentCell.CurrentlyOccupied && ChessShowToggle)
            {
                if (currentCell.RowNumber == oldSquare.RowNumber && currentCell.ColumnNumber==oldSquare.ColumnNumber)
                {
                    ChessShowToggle = false;
                    myBoard.CleartheBoard();
                }
                else
                {
                    if (currentCell.LegalNextMove)
                    {
                        ChessShowToggle = false;
                        myBoard.theGrid[oldSquare.RowNumber, oldSquare.ColumnNumber].CurrentlyOccupied = false;
                        myBoard.theGrid[x, y].OccupiedPiece = myBoard.theGrid[oldSquare.RowNumber, oldSquare.ColumnNumber].OccupiedPiece;
                        myBoard.theGrid[oldSquare.RowNumber, oldSquare.ColumnNumber].OccupiedPiece = null;
                        myBoard.CleartheBoard();
                    }
                    else
                    {
                        ChessShowToggle = false;
                        myBoard.CleartheBoard();
                        oldSquare = currentCell;
                        myBoard.MarkNextLegalMoves(currentCell, currentCell.OccupiedPiece.Name);
                        ChessShowToggle = true;
                    }

                }
            }
                    
            else if(!currentCell.CurrentlyOccupied && currentCell.LegalNextMove)
            {
                myBoard.theGrid[x, y].CurrentlyOccupied = true;
                myBoard.theGrid[oldSquare.RowNumber, oldSquare.ColumnNumber].CurrentlyOccupied = false;
                myBoard.theGrid[x, y].OccupiedPiece = myBoard.theGrid[oldSquare.RowNumber, oldSquare.ColumnNumber].OccupiedPiece;
                myBoard.theGrid[oldSquare.RowNumber, oldSquare.ColumnNumber].OccupiedPiece = null;
                myBoard.CleartheBoard();
            }

            //update the text on each button
            for(int i = 0; i < myBoard.Size; i++)
            {
                for(int j = 0; j < myBoard.Size; j++)
                {
                    if (myBoard.theGrid[i,j].LegalNextMove ==true)
                    {
                        //btnGrid[i, j].Text = "Legal";
                        btnGrid[i, j].BackColor = System.Drawing.Color.Green;
                    }
                    else if (myBoard.theGrid[i,j].CurrentlyOccupied ==true)
                    { 
                        btnGrid[i,j].Text = myBoard.theGrid[i, j].OccupiedPiece.Name;
                        if (myBoard.theGrid[i, j].OccupiedPiece.Color==false)
                        {
                            btnGrid[i, j].BackColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            btnGrid[i, j].BackColor = System.Drawing.Color.Gray;
                        }      
                    }
                    else
                    {
                        btnGrid[i, j].Text = i + "|" + j;
                        btnGrid[i, j].BackColor = System.Drawing.Color.DarkGray;
                    }
                        
                } 
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            //Reset chess game/start new game
            myBoard.SetupBoard();
            UpdateTheGrid();

        }
    }
}
