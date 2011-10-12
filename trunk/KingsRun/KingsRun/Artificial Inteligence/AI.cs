using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun
{
    class AI
    {
        #region Const Fields


        const int MINVALUE = -10000;


        #endregion

        #region Private Fields



        private Piece bestPiece; //Melhor peca a ser movimentada
        private Position bestMove; // Melhor movimento a ser realizado pela peca acima
        private int deep = 5; // Profundidade de avaliacao
        private BoardManager board; // Tabuleiro do jogo



        #endregion

        #region Public Methods
        
        
        
        public AI(BoardManager aBoard)
        //construtor da classe
        {
            this.board = aBoard;
        }



        public void play()
        //realiza a jogada da IA
        {
            this.bestPiece = null;
            this.bestMove = null;


            this.next(this.board.Player2, this.board.Player1); //Determina a melhor peca/jogada a ser realizada
            this.board.MoveAndKill(this.bestPiece, this.bestMove); //Realiza o movimento
        }



        #endregion

        #region Private Methods



        private int next(List<Piece> myPieces, List<Piece> opPieces)
        //retorna a melhor pontuacao possivel com o tabuleiro apresentado
        {

            int bestPieceScore = MINVALUE; //Melhor pontuacao possivel de se realizar

            foreach (Piece piece in myPieces)
            {
//                Position bestPosition; //Melhor posicao para se jogar a peca "piece"
                int bestMoveScore = bestPieceScore; //Melhor pontuacao atual

                List<Position> possibleMoves = board.PossibleMoves(piece);

                foreach (Position move in possibleMoves)
                {
                    int moveScore; //Armazena o melhor score possivel de se obter, movendo a peca "piece" na posicao "move";
                    this.board.MoveAndKill(piece, move);

                    if (deep == 0)
                    {
                        moveScore = this.evaluate(myPieces, opPieces);
                    }
                    else
                    {
                        deep--;
                        moveScore = this.next(opPieces, myPieces);
                        deep++;
                    }

                    if (moveScore >= bestMoveScore)
                    {
                        bestMoveScore = moveScore;
                        this.bestMove = move; //determina o movimento que gera mais pontos
                    }

                    this.board.UndoMove();
                }

                //destroy possibleMoves

                if (bestMoveScore >= bestPieceScore)
                {
                    bestPieceScore = bestMoveScore;
                    this.bestPiece = piece; //determina a peca que gera mais pontos
                }

            }
            return (-bestPieceScore);

        }


        private int evaluate(List<Piece> myPieces, List<Piece> opPieces)
        //Para cada peca perdida, perde 3 pontos;
        //Para cada peca capturada, ganha 2 pontos;
        //E recomendado trocar esses valores por variaveis
        {
            int score = 0;
            foreach (Piece piece in myPieces)
            {
                if (piece.Status > 0)
                    score = score - 3;
            }

            foreach (Piece piece in opPieces)
            {
                if (piece.Status > 0)
                    score = score + 2;
            }

            return (score);
        }



        #endregion
    }
}
