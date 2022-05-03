using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessBoardLibrary
{
    public class ChessSquare
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool CurrentlyOccupied { get; set;}
        public bool LegalNextMove { get; set; }

        public ChessPiece OccupiedPiece { get; set; }
        public ChessSquare(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }
    }
}
