using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun.Gameplay
{
    /* Neighbors
     * 
     * Used to know what neighbor I'm trying to access in some parts of the code
     */
    public enum Neighbors
    { N = 0, NE, SE, S, SW, NW }

    /* BoardManager
     * 
     * The class is used to manage the board, play the movements, know if there
     * are pieces to be dead, undo movements, etc...
     */
    class BoardManager
    {
        const bool IN = true;
        const bool OUT = false;

        // Matrix that says if some cell is in the board
        readonly bool[,] cells = {{OUT,OUT,OUT,IN ,IN ,IN ,OUT,OUT,OUT},
                                      {OUT,IN ,IN ,IN ,IN ,IN ,IN ,IN ,OUT},
                                      {IN ,IN ,IN ,IN ,IN ,IN ,IN ,IN ,IN },
                                      {IN ,IN ,IN ,IN ,IN ,IN ,IN ,IN ,IN },
                                      {IN ,IN ,IN ,IN ,IN ,IN ,IN ,IN ,IN },
                                      {IN ,IN ,IN ,IN ,IN ,IN ,IN ,IN ,IN },
                                      {IN ,IN ,IN ,IN ,IN ,IN ,IN ,IN ,IN },
                                      {OUT,OUT,IN ,IN ,IN ,IN ,IN ,OUT,OUT},
                                      {OUT,OUT,OUT,OUT,IN ,OUT,OUT,OUT,OUT}};

        // Vectors used
        readonly int[] neighborsCol = { 0, 1, 1, 0, -1, -1 };
        readonly int[,] neighborsRow = {{ -1, -1, 0, 1, 0, 1 },
                                            { -1,  0, 1, 1, 1, 0 }};

        int turn = 0;
        bool IATurn = false;

        // The players pieces
        List<Piece> player1 = new List<Piece>(10);
        List<Piece> player2 = new List<Piece>(10);

        BoardManager()
        { /* DOES NOTHING */ }

        // Moves the pieces
        public bool MoveAndKill(Piece piece, Tuple<int, int> toPosition)
        {
            return true;
        }

        public bool Move(Piece piece, Tuple<int,int> toPosition)
        {


            return true;
        }

        private void Kill(Piece piece)
        {
            piece.status = turn;
        }

        public bool UndoMove()
        {
            return true;
        }

        public List<Tuple<int,int>> PossibleMoves(Piece piece)
        {
            List<Tuple<int, int>> result = new List<Tuple<int,int>>();

            foreach (int direction in Enum.GetValues(typeof(Neighbors)))
            {
                // TODO: AQUI TEM ALGUMA COISA POSSIVELMENTE MUITO ERRADA!! (ATRIBUIÇÃO POR VALOR OU REFERENCIA?)
                Tuple<int,int> aux = piece.position;

                aux = GetNeighbor(aux, direction);

                /*while (isOnBoard(GetNeighbor(aux, direction)) && !isOccupied(aux))
                {
                    return result;                    
                }*/
            }
            return result;
        }

        private bool isOccupied(Tuple<int, int> position)
        {
            bool isPositionFree = true;

            foreach (Piece piece in player1)
            {
                if (piece.position.Item1 == position.Item1 &&
                    piece.position.Item2 == position.Item2 &&
                    piece.status == 0)
                    isPositionFree = false;
            }

            foreach (Piece piece in player2)
            {
                if (piece.position.Item1 == position.Item1 &&
                    piece.position.Item2 == position.Item2 &&
                    piece.status == 0)
                    isPositionFree = false;
            }

            return isPositionFree;
        }

        public bool isOnBoard(Tuple<int,int> position)
        {
            if (position.Item1 < 0 ||
                position.Item1 >= 9 ||
                position.Item2 < 0 ||
                position.Item2 >= 9)
                return false;

            if (cells[position.Item1, position.Item2] == OUT)
                return false;

            return true;
        }

        public Tuple<int,int> GetNeighbor(Tuple<int,int> position, int index)
        {
            return new Tuple<int, int>(position.Item1 + neighborsCol[index], position.Item2 + neighborsRow[position.Item1 % 2, index]);
        }
    }
}

/*
    bool esta_no_tabuleiro(Position pos)
    {
        if (!((Math.Abs(pos.column - 4) & 1) == (pos.row & 1))) // verifica se a paridade da célula
            return false;                           // é igual à paridade da célula original

        if (pos.column > 8)
            return false;

        if (pos.row >= Math.Abs(pos.column - 4))	// 
            if (pos.row <= (-(Math.Abs(pos.column - 4) + 9)))
                return true;

        return false;
    }
*/