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
        const int MAXVALUE = 10000;
        
        /* Pesos da funcao de avaliacao */
        const int PESO_PECA_INIMIGA = 2;
        const int PESO_PECA_AMIGA = 3;
        const int PESO_REI_AMIGO = 100;
        const int PESO_REI_INIMIGO = 100;

        #endregion

        #region Private Fields

        private Piece bestPiece; //Melhor peca a ser movimentada
        private Position bestMove; // Melhor movimento a ser realizado pela peca acima
        private int maxdeep = 2; // Profundidade de avaliacao
        private int deep = 2; // Profundidade de avaliacao
        private BoardManager board; // Tabuleiro do jogo
        

        #endregion

        #region Public Methods
        
        public AI(BoardManager aBoard, int aDeep)
        //construtor da classe
        {
            this.board = aBoard;
            this.deep = aDeep;
            this.maxdeep = aDeep;
        }


        public void play()
        //realiza a jogada da IA
        {
            this.bestPiece = null;
            this.bestMove = null;


            this.next(this.board.Player2, this.board.Player1,MINVALUE,MAXVALUE); //Determina a melhor peca/jogada a ser realizada
            this.board.MoveAndKill(this.bestPiece, this.bestMove); //Realiza o movimento
        }

        #endregion

        #region Private Methods

        private int next(List<Piece> myPieces, List<Piece> opPieces, int alpha, int beta)
        //retorna a melhor pontuacao possivel com o tabuleiro apresentado
        {

            foreach (Piece piece in myPieces)
            {

                if (piece.Status == 0)
                //Se a peca estiver viva, ele tenta realizar um movimento
                {
                    List<Position> possibleMoves = board.PossibleMoves(piece);

                    if (possibleMoves.Count != 0)
                    //Se a peca possuir algum movimento valido, tenta realizar o movimento
                    {
                        foreach (Position move in possibleMoves)
                        {
                            int moveScore; //Armazena o melhor score possivel de se obter, movendo a peca "piece" na posicao "move";
                            this.board.MoveAndKill(piece, move);

                            if (this.deep == 1)
                            {
                                moveScore = this.evaluate(myPieces, opPieces);

                            }
                            else
                            {
                                this.deep--;
                                moveScore = this.next(opPieces, myPieces,-beta,-alpha);
                                this.deep++;
                            }
                            
                            this.board.UndoMove();

                            if (moveScore > alpha)
                            {
                                if (moveScore >= beta)
                                {
                                    return (MINVALUE);
                                }

                                alpha = moveScore;
                                
                                if (this.deep == this.maxdeep)
                                {
                                    this.bestMove = move;
                                    this.bestPiece = piece; //determina a peca que gera mais pontos
                                } //determina o movimento que gera mais pontos
                            }
                            
                        }

                    }
                }

            }
            return (-alpha);

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
                    score = score - PESO_PECA_AMIGA;
                    //score = score - 3;
            }

            // verifica se o rei amigo não está ameaçado
            if (myPieces[9].Status > 0)
                score = score - PESO_REI_AMIGO;

            foreach (Piece piece in opPieces)
            {
                if (piece.Status > 0)
                    score = score + PESO_PECA_INIMIGA;
                    //score = score + 2;
            }

            // verifica se o rei inimigo pode ser vencido
            if (opPieces[9].Status > 0)
                score = score + PESO_REI_INIMIGO;
            //
            return (score);
        }

        #endregion
    }
}
