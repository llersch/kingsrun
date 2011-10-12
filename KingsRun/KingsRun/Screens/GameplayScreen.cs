using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KingsRun
{
    class GameplayScreen : GameScreen
    {
        #region Fields

        ContentManager content;
        Texture2D backgroundTexture;
        Texture2D IApeon;
        Texture2D IAking;
        Texture2D playerPeon;
        Texture2D playerKing;

        //Nossas Classes
        BoardManager boardManager;
        InterfaceManager interfaceManager;
        AI ia;
        //

        bool IAturn=false;

        #endregion

        public GameplayScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            //Nossas Classes
            boardManager = new BoardManager();
            interfaceManager = new InterfaceManager(47, 10, 10, boardManager);
            ia = new AI(boardManager,2); 
            //
        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            backgroundTexture = content.Load<Texture2D>("tabuleiro");

            if (IAturn) //se IA começa jogando
            {
                IApeon = content.Load<Texture2D>("whitepeon");
                IAking = content.Load<Texture2D>("whiteking");
                playerPeon = content.Load<Texture2D>("blackpeon");
                playerKing = content.Load<Texture2D>("blackking");
            }
            else //se player começa jogando
            {
                IApeon = content.Load<Texture2D>("blackpeon");
                IAking = content.Load<Texture2D>("blackking");
                playerPeon = content.Load<Texture2D>("whitepeon");
                playerKing = content.Load<Texture2D>("whiteking");
            }
        }


        /// <summary>
        /// Unloads graphics content for this screen.
        /// </summary>
        public override void UnloadContent()
        {
            content.Unload();
        }

        #region Update and Draw


        /// <summary>
        /// Updates the background screen. Unlike most screens, this should not
        /// transition off even if it has been covered by another screen: it is
        /// supposed to be covered, after all! This overload forces the
        /// coveredByOtherScreen parameter to false in order to stop the base
        /// Update method wanting to transition off.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                               bool coveredByOtherScreen)
        {
            if (boardManager.Player1[9].Status != 0) //rei do jogador morreu
            {
                ScreenManager.Game.Exit();
            }
            else if (boardManager.Player2[9].Status != 0) //rei da IA morreu
            {
                ScreenManager.Game.Exit();
            }

            else if (IAturn)
            {
                ia.play();
                IAturn = false;
            }
            base.Update(gameTime, otherScreenHasFocus, false);
        }



        /// <summary>
        /// Draws the background screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            Viewport viewport = ScreenManager.GraphicsDevice.Viewport;
            Rectangle fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);
            byte fade = TransitionAlpha;

            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, fullscreen,
                             new Color(fade, fade, fade));
            
            //itera pelo Player1, mas desenha para os dois pq tem o mesmo tamanho
            for (int i = 0; i < boardManager.Player1.Count - 1; i++)
            {
                if(boardManager.Player1[i].Status == 0)
                    spriteBatch.Draw(playerPeon, interfaceManager.PieceRect(boardManager.Player1[i]), Color.White);

                if (boardManager.Player2[i].Status == 0)
                    spriteBatch.Draw(IApeon, interfaceManager.PieceRect(boardManager.Player2[i]), Color.White);
            }
            
            spriteBatch.Draw(playerKing, interfaceManager.PieceRect(boardManager.Player1[9]), Color.White);
            spriteBatch.Draw(IAking, interfaceManager.PieceRect(boardManager.Player2[9]), Color.White);

            //Se existir uma peça selecionada, desenha ela em amarelo
            if (interfaceManager.Selected != null)
            {
                if (interfaceManager.Selected.Equals(boardManager.Player1[9]))
                    spriteBatch.Draw(playerKing, interfaceManager.PieceRect(interfaceManager.Selected), Color.Yellow);
                else
                    spriteBatch.Draw(playerPeon, interfaceManager.PieceRect(interfaceManager.Selected), Color.Yellow);
            }

            spriteBatch.End();
        }

        //Handle inputs for this screen
        public override void HandleInput(InputState input)
        {
            if (input.IsNewMousePress() && !IAturn)
            {
                Position click = interfaceManager.ScreenToBoard(input.CurrentMouseState.X, input.CurrentMouseState.Y);
                Piece test;
                test = boardManager.isOccupied(click);
                if (test != null) //se clicou em uma casa com uma peça
                {
                    if(boardManager.Player1.Contains(test)) //se essa peça é do player1 (humano)
                    {
                        interfaceManager.Selected = test; //a peça é selecionada
                        interfaceManager.SelPossibleMvs = boardManager.PossibleMoves(interfaceManager.Selected); //calcula os movimentos possiveis
                    }
                }
                else if (interfaceManager.Selected != null) //se existe uma peça selecionada
                {
                    if (interfaceManager.SelPossibleMvs.Contains(click)) //se a casa onde clicou é um movimento possível
                    {
                        boardManager.MoveAndKill(interfaceManager.Selected, click);
                        IAturn = true;

                        interfaceManager.Selected = null;
                        interfaceManager.SelPossibleMvs.Clear();
                    }
                }

                //MessageBoxScreen coord = new MessageBoxScreen(click.X + " , " + click.Y);
                //ScreenManager.AddScreen(coord, base.ControllingPlayer);
            }      
        }

        #endregion
    }
}
