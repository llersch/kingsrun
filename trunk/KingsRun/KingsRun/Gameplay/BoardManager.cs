using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun
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

        int turn = 0;

        List<Piece> player1 = new List<Piece>(10);
        List<Piece> player2 = new List<Piece>(10);

        Stack<Movement> moves = new Stack<Movement>();

        #endregion

        #region Properties

        public List<Piece> Player1
        {
            get { return player1; }
        }

        public List<Piece> Player2
        {
            get { return player2; }
        }

        #endregion

        #region Public Methods

        public BoardManager()
        {
            //jogador de baixo
            player1.Add(new Piece(0, 6));
            player1.Add(new Piece(1, 6));
            player1.Add(new Piece(2, 7));
            player1.Add(new Piece(3, 7));
            player1.Add(new Piece(4, 7));
            player1.Add(new Piece(5, 7));
            player1.Add(new Piece(6, 7));
            player1.Add(new Piece(7, 6));
            player1.Add(new Piece(8, 6));
            player1.Add(new Piece(4, 8)); //rei

            //jogador de cima
            player2.Add(new Piece(0, 2));
            player2.Add(new Piece(1, 1));
            player2.Add(new Piece(2, 1));
            player2.Add(new Piece(3, 0));
            player2.Add(new Piece(4, 1));
            player2.Add(new Piece(5, 0));
            player2.Add(new Piece(6, 1));
            player2.Add(new Piece(7, 1));
            player2.Add(new Piece(8, 2));
            player2.Add(new Piece(4, 0)); //rei
        }

        // Método recebe uma _piece e a _toPosition de destino.
        public void MoveAndKill(Piece _piece, Position _toPosition)
        {
            this.Move(_piece, _toPosition);
            Piece enemy;
            foreach (Neighbors n in Enum.GetValues(typeof(Neighbors)))
            {
                enemy = this.isEnemyAt(_piece, this.GetNeighbor(_piece.Position, n));
                if (enemy != null)
                {
                    if(this.mustDie(enemy))
                    {
                        this.Kill(enemy);
                    } 
                }
            }
            turn++;
        }

        public void UndoMove()
        {
            if (turn > 0)
            {
                turn--;

                Movement aMovement = moves.Pop();
                aMovement.Piece.Position.X = aMovement.SPosition.X;
                aMovement.Piece.Position.Y = aMovement.SPosition.Y;

                foreach (Piece piece in player1)
                {
                    if (piece.Status == turn)
                        piece.Status = 0;
                }

                foreach (Piece piece in player2)
                {
                    if (piece.Status == turn)
                        piece.Status = 0;
                }
            }
        }

        //Retorna lista de posições para as quais _piece poderá mover.
        public List<Position> PossibleMoves(Piece _piece)
        {
            List<Position> result = new List<Position>();
            Position current;

            foreach (Neighbors n in Enum.GetValues(typeof(Neighbors)))
            {
                current = this.GetNeighbor(_piece.Position, n);
                while (this.isOnBoard(current) && !this.isOccupied(current))
                {
                    result.Add(current);
                    current = this.GetNeighbor(current, n);
                }

            }
            return result;
        }

        //Verifica se uma determinada posição está ocupada.
        public bool isOccupied(Position _position)
        {
            // Talvez mudar pro metodo Compare
            foreach (Piece piece in player1)
            {
                if (piece.Position.X == _position.X &&
                    piece.Position.Y == _position.Y &&
                    piece.Status == 0)
                    return true;
            }

            foreach (Piece piece in player2)
            {
                if (piece.Position.X == _position.X &&
                    piece.Position.Y == _position.Y &&
                    piece.Status == 0)
                    return true;
            }

            return false;
        }

        //Verifica se uma determinada posição está no tabuleiro.
        public bool isOnBoard(Position _position)
        {
            if (_position.X < 0 || _position.X >= 9 || _position.Y < 0 || _position.Y >= 9)
            {
                return false;
            }

            if (boardCells[_position.X, _position.Y] == OUT)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Private Methods

        private void Move(Piece _piece, Position _toPosition)
        {
            Movement mv = new Movement(_piece);
            moves.Push(mv);

            _piece.Position.X = _toPosition.X;
            _piece.Position.Y = _toPosition.Y;
        }

        private void Kill(Piece _piece)
        {
            _piece.Status = turn;
        }

        //Verifica se existe um inimigo de _piece em _position, retornando um ponteiro para o inimigo.
        private Piece isEnemyAt(Piece _piece, Position _position)
        {
            if (player1.Contains(_piece))
            {
                foreach (Piece p in player2)
                {
                    if (p.Position.Equals(_position))
                        return p;
                }

            }
            else
            {
                foreach (Piece p in player1)
                {
                    if (p.Position.Equals(_position))
                        return p;
                }
            }
            return null;
        }

        //Verifica se a _piece deve morrer.
        private bool mustDie(Piece _piece)
        {
            int num_enemies = 0;
            foreach (Neighbors n in Enum.GetValues(typeof(Neighbors)))
            {
                if (this.isEnemyAt(_piece, this.GetNeighbor(_piece.Position, n)) != null)
                {
                    num_enemies++;
                    if (num_enemies >= 2)
                        return true;
                }
            }
            return false;
        }

        //Retorna a posição da casa vizinha de _position.
        private Position GetNeighbor(Position _position, Neighbors _neighbor)
        {
            return new Position(_position.X + neighborsCol[(int)_neighbor], _position.Y + neighborsRow[_position.X % 2, (int)_neighbor]);
        }

        #endregion
    }
}