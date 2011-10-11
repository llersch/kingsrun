using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun.Gameplay
{
    //Used to know what neighbor I'm trying to access in some parts of the code
        public enum Neighbors
    { N = 0, NE, SE, S, SW, NW }

    /* The class is used to manage the board, play the movements, know if there
      are pieces to be dead, undo movements, etc... */
    class BoardManager
    {
        # region Const Fields

        const bool IN = true;
        const bool OUT = false;

        // Matrix that says if some cell is in the board
        readonly bool[,] boardCells = {{OUT,OUT,OUT,IN ,IN ,IN ,OUT,OUT,OUT},
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

        #endregion

        #region Fields

        List<Piece> player1 = new List<Piece>(10);
        List<Piece> player2 = new List<Piece>(10);

        #endregion

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
            //piece.Status = turn;
        }

        public bool UndoMove()
        {
            return true;
        }

        //REVER TODA ESTA MERDA!
        /*public List<Tuple<byte,byte>> PossibleMoves(Piece piece)
        {
            List<Tuple<int, int>> result = new List<Tuple<int,int>>();

            foreach (int direction in Enum.GetValues(typeof(Neighbors)))
            {
                // TODO: AQUI TEM ALGUMA COISA POSSIVELMENTE MUITO ERRADA!! (ATRIBUIÇÃO POR VALOR OU REFERENCIA?)
                Tuple<byte,byte> aux = piece.Position;

                aux = GetNeighbor(aux, direction);

                while (isOnBoard(GetNeighbor(aux, direction)) && !isOccupied(aux))
                {
                    return result;                    
                }
            }
        }*/

        private bool isOccupied(Tuple<int, int> position)
        {
            bool occupied = false;

            foreach (Piece piece in player1)
            {
                if (piece.X == position.Item1 &&
                    piece.Y == position.Item2 &&
                    piece.Status == 0)
                    occupied = true;
            }

            foreach (Piece piece in player2)
            {
                if (piece.X == position.Item1 &&
                    piece.Y == position.Item2 &&
                    piece.Status == 0)
                    occupied = true;
            }

            return occupied;
        }

        public bool isOnBoard(Piece a_piece)
        {
            if (a_piece.X < 0 || a_piece.X >= 9 || a_piece.Y < 0 || a_piece.Y >= 9)
            {
                return false;
            }

            if (boardCells[a_piece.X, a_piece.Y] == OUT)
            {
                return false;
            }

            return true;
        }

        public Tuple<int, int> GetNeighbor(Piece a_piece, Neighbors a_neighbor)
        {
            return new Tuple<int, int>(a_piece.X + neighborsCol[(int)a_neighbor], a_piece.Y + neighborsRow[a_piece.X % 2, (int)a_neighbor]);
        }
    }
}

/* ISSO AQUI PODE SER UTIL NO FUTURO!!! SÓ QUE AO CONTRÁRIO!
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