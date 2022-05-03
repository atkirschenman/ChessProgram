using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardLibrary
{
    public class ChessPiece
    {
        public ChessPiece(string lname, bool lcolor, ChessPieceEnum lid)
        {
            Name = lname;
            Color = lcolor;
            ID = (UInt16)lid;
            inPlay = true;
        }
        public enum ChessPieceEnum : UInt16
        {
            PAWN,
            KNIGHT,
            BISHOP,
            ROOK,
            QUEEN,
            KING
        }

        public string Name { get; set; }
        public UInt16 ID { get; set; }
        public bool Color { get; set; }
        public bool inPlay { get; set; }



        
    }
}
