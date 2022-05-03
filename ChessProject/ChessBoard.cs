using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardLibrary
{
    public class ChessBoard
    {
        //size of the board (default 8x8)
        public int Size { get; set; }
        public ChessSquare[,] theGrid   { get; set; }
        public ChessGame myChessGame = new ChessGame();
        public ChessBoard(int s)
        {
            //initial board size
            Size = s;
            theGrid = new ChessSquare[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new ChessSquare(i, j);
                }
            }
        }

        public void SetupBoard()
        {
            theGrid = myChessGame.SetupBoard(theGrid, Size);
        }

        //determine legal next moves
        public void MarkNextLegalMoves(ChessSquare currentCell, string ChessPiece)
        {
           theGrid = myChessGame.MarkNextLegalMoves(currentCell, ChessPiece, theGrid, Size);
        }

        public void CleartheBoard()
        {
           theGrid = myChessGame.ClearBoard(theGrid,Size);
        }
        
    }
}
