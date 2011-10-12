using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun
{
    class AI
    {
        const int MINVALUE = -10000;
        private Piece bestPiece;
        private Position bestMove;
        private int deep = 5;
        private BoardManager board;

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


            this.next(this.board.Player2, this.board.Player1);
            this.board.MoveAndKill(this.bestPiece, this.bestMove);
        }


        private int next(List<Piece> myPieces, List<Piece> opPieces)
        //retorna a melhor pontuacao possivel com o tabuleiro apresentado
        {

            int bestPieceScore = MINVALUE; //Melhor pontuacao possivel de se realizar

            foreach (Piece piece in myPieces)
            {
//                Position bestPosition; //Melhor posicao para se jogar a peca "piece"
                int bestMoveScore = bestPieceScore; //Melhor pontuacao com a peca "Piece"

                List<Position> possibleMoves = board.PossibleMoves(piece);

                foreach (Position move in possibleMoves)
                {
                    int moveScore;
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

    }
}
