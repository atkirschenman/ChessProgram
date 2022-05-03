using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardLibrary
{
    public class ChessGame
    {
        public ChessPiece wKing = new ChessPiece("King", false, ChessPiece.ChessPieceEnum.KING);
        public ChessPiece wQueen = new ChessPiece("Queen", false, ChessPiece.ChessPieceEnum.QUEEN);
        public ChessPiece wKnight1 = new ChessPiece("Knight", false, ChessPiece.ChessPieceEnum.KNIGHT);
        public ChessPiece wKnight2 = new ChessPiece("Knight", false, ChessPiece.ChessPieceEnum.KNIGHT);
        public ChessPiece wBishop1 = new ChessPiece("Bishop", false, ChessPiece.ChessPieceEnum.BISHOP);
        public ChessPiece wBishop2 = new ChessPiece("Bishop", false, ChessPiece.ChessPieceEnum.BISHOP);
        public ChessPiece wRook1 = new ChessPiece("Rook", false, ChessPiece.ChessPieceEnum.ROOK);
        public ChessPiece wRook2 = new ChessPiece("Rook", false, ChessPiece.ChessPieceEnum.ROOK);
        public ChessPiece wPawn1 = new ChessPiece("Pawn", false, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece wPawn2 = new ChessPiece("Pawn", false, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece wPawn3 = new ChessPiece("Pawn", false, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece wPawn4 = new ChessPiece("Pawn", false, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece wPawn5 = new ChessPiece("Pawn", false, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece wPawn6 = new ChessPiece("Pawn", false, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece wPawn7 = new ChessPiece("Pawn", false, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece wPawn8 = new ChessPiece("Pawn", false, ChessPiece.ChessPieceEnum.PAWN);


        public ChessPiece bKing = new ChessPiece("King", true, ChessPiece.ChessPieceEnum.KING);
        public ChessPiece bQueen = new ChessPiece("Queen", true, ChessPiece.ChessPieceEnum.QUEEN);
        public ChessPiece bKnight1 = new ChessPiece("Knight", true, ChessPiece.ChessPieceEnum.KNIGHT);
        public ChessPiece bKnight2 = new ChessPiece("Knight", true, ChessPiece.ChessPieceEnum.KNIGHT);
        public ChessPiece bBishop1 = new ChessPiece("Bishop", true, ChessPiece.ChessPieceEnum.BISHOP);
        public ChessPiece bBishop2 = new ChessPiece("Bishop", true, ChessPiece.ChessPieceEnum.BISHOP);
        public ChessPiece bRook1 = new ChessPiece("Rook", true, ChessPiece.ChessPieceEnum.ROOK);
        public ChessPiece bRook2 = new ChessPiece("Rook", true, ChessPiece.ChessPieceEnum.ROOK);
        public ChessPiece bPawn1 = new ChessPiece("Pawn", true, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece bPawn2 = new ChessPiece("Pawn", true, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece bPawn3 = new ChessPiece("Pawn", true, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece bPawn4 = new ChessPiece("Pawn", true, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece bPawn5 = new ChessPiece("Pawn", true, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece bPawn6 = new ChessPiece("Pawn", true, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece bPawn7 = new ChessPiece("Pawn", true, ChessPiece.ChessPieceEnum.PAWN);
        public ChessPiece bPawn8 = new ChessPiece("Pawn", true, ChessPiece.ChessPieceEnum.PAWN);

        private ChessSquare[,] theGrid { get; set; }
       // public ChessGame(ChessSquare[,] chessBoardinit, int sizeint)
       // {
       //     theGrid = chessBoardinit;
       //     Size = sizeint;
       // }






        public ChessSquare[,] ClearBoard(ChessSquare[,] lGrid, int Size)
        {
            theGrid = lGrid;
            //clear the board
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                }
            }
            return theGrid;
        }

        public ChessSquare[,] MarkNextLegalMoves(ChessSquare currentCell, string ChessPiece, ChessSquare[,] lGrid, int Size)
        {
            theGrid = lGrid;
            //clear the board
            ClearBoard(theGrid, Size);
            int i2;
            //find all legal moves
            switch (ChessPiece)
            {
                case "Knight":
                    if (currentCell.RowNumber + 2 <= 7 && currentCell.ColumnNumber + 1 <= 7 &&
                        (!theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].CurrentlyOccupied
                        || theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].OccupiedPiece.Color!=
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (currentCell.RowNumber + 2 <= 7 && currentCell.ColumnNumber - 1 >= 0 &&( !theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].CurrentlyOccupied
                        || theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].OccupiedPiece.Color !=
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (currentCell.RowNumber - 2 >= 0 && currentCell.ColumnNumber + 1 <= 7 && (!theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].CurrentlyOccupied
                        || theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].OccupiedPiece.Color !=
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (currentCell.RowNumber - 2 >= 0 && currentCell.ColumnNumber - 1 >= 0 &&( !theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].CurrentlyOccupied
                        || theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].OccupiedPiece.Color !=
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (currentCell.RowNumber + 1 <= 7 && currentCell.ColumnNumber + 2 <= 7 &&( !theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].CurrentlyOccupied
                        || theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber +2].OccupiedPiece.Color !=
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;

                    if (currentCell.RowNumber + 1 <= 7 && currentCell.ColumnNumber - 2 >= 0 && (!theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].CurrentlyOccupied
                        || theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber -2].OccupiedPiece.Color !=
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;

                    if (currentCell.RowNumber - 1 >= 0 && currentCell.ColumnNumber + 2 <= 7 &&( !theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].CurrentlyOccupied
                        || theGrid[currentCell.RowNumber -1, currentCell.ColumnNumber + 2].OccupiedPiece.Color !=
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;

                    if (currentCell.RowNumber - 1 >= 0 && currentCell.ColumnNumber - 2 >= 0 && (!theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].CurrentlyOccupied
                        || theGrid[currentCell.RowNumber -1, currentCell.ColumnNumber -2].OccupiedPiece.Color !=
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;

                    break;
                case "King":
                    if (currentCell.RowNumber + 1 <= 7 && currentCell.ColumnNumber + 1 <= 7 &&
                        !theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].CurrentlyOccupied)
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (currentCell.RowNumber + 1 <= 7 && currentCell.ColumnNumber - 1 >= 0 && !theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].CurrentlyOccupied)
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (currentCell.RowNumber - 1 >= 0 && currentCell.ColumnNumber + 1 <= 7 && !theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].CurrentlyOccupied)
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (currentCell.RowNumber - 1 >= 0 && currentCell.ColumnNumber - 1 >= 0 && !theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].CurrentlyOccupied)
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (currentCell.ColumnNumber + 1 <= 7 && !theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].CurrentlyOccupied)
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (currentCell.ColumnNumber - 1 >= 0 && !theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].CurrentlyOccupied)
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (currentCell.RowNumber - 1 >= 0 && !theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].CurrentlyOccupied)
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;

                    if (currentCell.RowNumber + 1 <= 7 && !theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].CurrentlyOccupied)
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                    break;

                case "Rook":
                    for (int i = currentCell.RowNumber + 1; i <= 7; i++)
                    {
                        if (theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                        {
                            if(theGrid[i, currentCell.ColumnNumber].OccupiedPiece.Color!= theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                            
                        theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int i = currentCell.RowNumber - 1; i >= 0; i--)
                    {
                        if (theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                        {
                            if (theGrid[i, currentCell.ColumnNumber].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int i = currentCell.ColumnNumber + 1; i <= 7; i++)
                    {
                        if (theGrid[currentCell.RowNumber, i].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber, i].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber, i].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[currentCell.RowNumber, i].LegalNextMove = true;
                    }
                    for (int i = currentCell.ColumnNumber - 1; i >= 0; i--)
                    {
                        if (theGrid[currentCell.RowNumber, i].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber, i].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber, i].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                            theGrid[currentCell.RowNumber, i].LegalNextMove = true;
                    }

                    break;
                case "Bishop":
                    i2 = 1;
                    while (currentCell.RowNumber + i2 <= 7 && currentCell.ColumnNumber + i2 <= 7)
                    {
                        if (theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber + i2].CurrentlyOccupied)
                        {
                            if(theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber + i2].OccupiedPiece.Color!= theGrid[currentCell.RowNumber , currentCell.ColumnNumber ].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber + i2].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                          
                        theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber + i2].LegalNextMove = true;
                        i2++;
                    }
                    i2 = 1;
                    while (currentCell.RowNumber + i2 <= 7 && currentCell.ColumnNumber - i2 >= 0)
                    {
                        if (theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber - i2].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber - i2].OccupiedPiece.Color != theGrid[currentCell.RowNumber , currentCell.ColumnNumber ].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber - i2].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber - i2].LegalNextMove = true;
                        i2++;
                    }
                    i2 = 1;
                    while (currentCell.RowNumber - i2 >= 0 && currentCell.ColumnNumber + i2 <= 7)
                    {
                        if (theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber + i2].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber + i2].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber + i2].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber + i2].LegalNextMove = true;
                        i2++;
                    }
                    i2 = 1;
                    while (currentCell.RowNumber - i2 >= 0 && currentCell.ColumnNumber - i2 >= 0)
                    {
                        if (theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber - i2].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber - i2].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber - i2].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber - i2].LegalNextMove = true;
                        i2++;
                    }

                    break;
                case "Queen":
                    i2 = 1;
                    while (currentCell.RowNumber + i2 <= 7 && currentCell.ColumnNumber + i2 <= 7)
                    {
                        if (theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber + i2].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber + i2].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber + i2].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }

                        theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber + i2].LegalNextMove = true;
                        i2++;
                    }
                    i2 = 1;
                    while (currentCell.RowNumber + i2 <= 7 && currentCell.ColumnNumber - i2 >= 0)
                    {
                        if (theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber - i2].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber - i2].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber - i2].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[currentCell.RowNumber + i2, currentCell.ColumnNumber - i2].LegalNextMove = true;
                        i2++;
                    }
                    i2 = 1;
                    while (currentCell.RowNumber - i2 >= 0 && currentCell.ColumnNumber + i2 <= 7)
                    {
                        if (theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber + i2].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber + i2].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber + i2].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber + i2].LegalNextMove = true;
                        i2++;
                    }
                    i2 = 1;
                    while (currentCell.RowNumber - i2 >= 0 && currentCell.ColumnNumber - i2 >= 0)
                    {
                        if (theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber - i2].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber - i2].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber - i2].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[currentCell.RowNumber - i2, currentCell.ColumnNumber - i2].LegalNextMove = true;
                        i2++;
                    }

                    for (int i = currentCell.RowNumber + 1; i <= 7; i++)
                    {
                        if (theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                        {
                            if (theGrid[i, currentCell.ColumnNumber].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }

                        theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int i = currentCell.RowNumber - 1; i >= 0; i--)
                    {
                        if (theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                        {
                            if (theGrid[i, currentCell.ColumnNumber].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int i = currentCell.ColumnNumber + 1; i <= 7; i++)
                    {
                        if (theGrid[currentCell.RowNumber, i].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber, i].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber, i].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[currentCell.RowNumber, i].LegalNextMove = true;
                    }
                    for (int i = currentCell.ColumnNumber - 1; i >= 0; i--)
                    {
                        if (theGrid[currentCell.RowNumber, i].CurrentlyOccupied)
                        {
                            if (theGrid[currentCell.RowNumber, i].OccupiedPiece.Color != theGrid[currentCell.RowNumber, currentCell.ColumnNumber].OccupiedPiece.Color)
                            {
                                theGrid[currentCell.RowNumber, i].LegalNextMove = true;
                                break;
                            }
                            else
                                break;
                        }
                        theGrid[currentCell.RowNumber, i].LegalNextMove = true;
                    }
                    break;
                case "Pawn":
                    if (currentCell.OccupiedPiece.Color == true)
                    {
                        if (currentCell.ColumnNumber + 1 <= 7 && !theGrid[currentCell.ColumnNumber, currentCell.ColumnNumber + 1].CurrentlyOccupied)
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        if (currentCell.ColumnNumber == 1 && !theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 2].CurrentlyOccupied)
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 2].LegalNextMove = true;
                        if (currentCell.ColumnNumber + 1 <= 7 && theGrid[currentCell.RowNumber+1, currentCell.ColumnNumber + 1].CurrentlyOccupied && 
                            theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber+1].OccupiedPiece.Color != currentCell.OccupiedPiece.Color)
                            theGrid[currentCell.RowNumber+1, currentCell.ColumnNumber +1].LegalNextMove = true;
                        if (currentCell.ColumnNumber + 1 <= 7 && theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].CurrentlyOccupied &&
                            theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].OccupiedPiece.Color != currentCell.OccupiedPiece.Color)
                            theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }
                    else
                    {
                        if (currentCell.ColumnNumber - 1 >= 0 && !theGrid[currentCell.ColumnNumber, currentCell.ColumnNumber - 1].CurrentlyOccupied)
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        if (currentCell.ColumnNumber == 6 && !theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 2].CurrentlyOccupied)
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 2].LegalNextMove = true;
                        if (currentCell.ColumnNumber - 1 >= 0 && theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].CurrentlyOccupied &&
                            theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].OccupiedPiece.Color != currentCell.OccupiedPiece.Color)
                            theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        if (currentCell.ColumnNumber - 1 >= 0 && theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].CurrentlyOccupied &&
                            theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].OccupiedPiece.Color != currentCell.OccupiedPiece.Color)
                            theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }

                    break;
                default:
                    break;

                    
            }
            return theGrid;
        }



        public ChessSquare[,] SetupBoard(ChessSquare[,] lGrid, int Size)
        {
            ClearBoard(lGrid,Size);
            theGrid = lGrid;
            //clear the board
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].CurrentlyOccupied = false;
                    theGrid[i, j].OccupiedPiece = null;
                }
            }
            
            lGrid[0, 0].OccupiedPiece = bRook1;
            lGrid[0, 0].CurrentlyOccupied = true;
            lGrid[7, 0].OccupiedPiece = bRook2;
            lGrid[7, 0].CurrentlyOccupied = true;
            lGrid[1, 0].OccupiedPiece = bKnight1;
            lGrid[1, 0].CurrentlyOccupied = true;
            lGrid[6, 0].OccupiedPiece = bKnight2;
            lGrid[6, 0].CurrentlyOccupied = true;
            lGrid[2, 0].OccupiedPiece = bBishop1;
            lGrid[2, 0].CurrentlyOccupied = true;
            lGrid[5, 0].OccupiedPiece = bBishop2;
            lGrid[5, 0].CurrentlyOccupied = true;
            lGrid[3, 0].OccupiedPiece = bQueen;
            lGrid[3, 0].CurrentlyOccupied = true;
            lGrid[4, 0].OccupiedPiece = bKing;
            lGrid[4, 0].CurrentlyOccupied = true;

            lGrid[0, 7].OccupiedPiece = wRook1;
            lGrid[0, 7].CurrentlyOccupied = true;
            lGrid[7, 7].OccupiedPiece = wRook2;
            lGrid[7, 7].CurrentlyOccupied = true;
            lGrid[1, 7].OccupiedPiece = wKnight1;
            lGrid[1, 7].CurrentlyOccupied = true;
            lGrid[6, 7].OccupiedPiece = wKnight2;
            lGrid[6, 7].CurrentlyOccupied = true;
            lGrid[2, 7].OccupiedPiece = wBishop1;
            lGrid[2, 7].CurrentlyOccupied = true;
            lGrid[5, 7].OccupiedPiece = wBishop2;
            lGrid[5, 7].CurrentlyOccupied = true;
            lGrid[3, 7].OccupiedPiece = wQueen;
            lGrid[3, 7].CurrentlyOccupied = true;
            lGrid[4, 7].OccupiedPiece = wKing;
            lGrid[4, 7].CurrentlyOccupied = true;

            lGrid[0, 6].OccupiedPiece = wPawn1;
            lGrid[0, 6].CurrentlyOccupied = true;
            lGrid[7, 6].OccupiedPiece = wPawn2;
            lGrid[7, 6].CurrentlyOccupied = true;
            lGrid[1, 6].OccupiedPiece = wPawn3;
            lGrid[1, 6].CurrentlyOccupied = true;
            lGrid[6, 6].OccupiedPiece = wPawn4;
            lGrid[6, 6].CurrentlyOccupied = true;
            lGrid[2, 6].OccupiedPiece = wPawn5;
            lGrid[2, 6].CurrentlyOccupied = true;
            lGrid[5, 6].OccupiedPiece = wPawn6;
            lGrid[5, 6].CurrentlyOccupied = true;
            lGrid[3, 6].OccupiedPiece = wPawn7;
            lGrid[3, 6].CurrentlyOccupied = true;
            lGrid[4, 6].OccupiedPiece = wPawn8;
            lGrid[4, 6].CurrentlyOccupied = true;

            lGrid[0, 1].OccupiedPiece = bPawn1;
            lGrid[0, 1].CurrentlyOccupied = true;
            lGrid[7, 1].OccupiedPiece = bPawn2;
            lGrid[7, 1].CurrentlyOccupied = true;
            lGrid[1, 1].OccupiedPiece = bPawn3;
            lGrid[1, 1].CurrentlyOccupied = true;
            lGrid[6, 1].OccupiedPiece = bPawn4;
            lGrid[6, 1].CurrentlyOccupied = true;
            lGrid[2, 1].OccupiedPiece = bPawn5;
            lGrid[2, 1].CurrentlyOccupied = true;
            lGrid[5, 1].OccupiedPiece = bPawn6;
            lGrid[5, 1].CurrentlyOccupied = true;
            lGrid[3, 1].OccupiedPiece = bPawn7;
            lGrid[3, 1].CurrentlyOccupied = true;
            lGrid[4, 1].OccupiedPiece = bPawn8;
            lGrid[4, 1].CurrentlyOccupied = true;

            return lGrid;
        }

    }
}
