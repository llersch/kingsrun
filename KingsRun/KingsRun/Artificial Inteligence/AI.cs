using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
namespace KingsRun
{
    class AI
    {
        const int MINVALUE = -10000;
        private Piece bestPiece;
        private Tuple<byte, byte> bestMove;
        private int deep = 5;
        private BoardManager board;
        


        public void play(BoardManager board)
        //realiza a jogada da IA
        {
            List<Piece> myPieces, opPieces;
            int score = MINVALUE;

            this.board = board;

            myPieces = board.getPlayer2();
            opPieces = board.getPlayer1();

            score = next(myPieces, opPieces);
            this.board.MoveAndKill(this.bestPiece, this.bestMove);

        }

        private int evaluate(List<Piece> myPieces, List<Piece> opPieces)
            //Para cada peca perdida, perde 3 pontos;
            //Para cada peca capturada, ganha 2 pontos;
            //E recomendado trocar esses valores por variaveis
        {
            int score = 0;
            foreach (Piece piece in myPieces)
            {
                if(piece.getStatus()>0)
                    score = score - 3;
            }

            foreach (Piece piece in opPieces)
            {
                if(piece.getStatus()>0)
                    score = score + 2;
            }

            return (score);
        }
        
        private int next(List<Piece> myPieces,List<Piece> opPieces)
        //retorna a melhor pontuacao possivel
        {

	        int value = MINVALUE; //Melhor pontuacao possivel de se realizar

	        foreach(Piece piece in myPieces)
	        {
                Tuple<byte,byte> bestPosition; //Melhor posicao para se jogar a peca "piece"
                int bestMove = value; //Melhor pontuacao com a peca "Piece"
		        
                List<Tuple<byte,byte>> possibleMoves = board.PossibleMoves(piece);

                foreach (Tuple<byte, byte> move in possibleMoves)
		        {
			        int moveScore;
			        this.board.MoveAndKill(piece,move);

			        if (deep==0)
			        {
				        moveScore = this.evaluate(myPieces,opPieces);
			        }
			        else
			        {
				        deep--;
				        moveScore = this.next(opPieces,myPieces);
				        deep++;
			        }

			        if(moveScore>=bestMove)
                    {
				        bestMove=moveScore;
                        this.bestMove = move.clone(); //determina o movimento que gera mais pontos
                    }

			        this.board.UndoMove();
		        }

			    //destroy possibleMoves

			    if(bestMove >= value)
		        {
			        value = bestMove;
                    this.bestPiece = piece.clone(); //determina a peca que gera mais pontos
		        }
	
	        }
	        return(-value);

        }

    
    }
}
*/