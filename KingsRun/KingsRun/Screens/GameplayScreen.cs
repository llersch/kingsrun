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
        Texture2D blackking;
        Texture2D blackpeon;
        Texture2D whiteking;
        Texture2D whitepeon;

        //Nossas Classes
        BoardManager boardManager;
        InterfaceManager interfaceManager;
        //

        bool IAturn;

        #endregion

        public GameplayScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            //Nossas Classes
            boardManager = new BoardManager();
            interfaceManager = new InterfaceManager(47, 10, 10, boardManager);
            //
        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            backgroundTexture = content.Load<Texture2D>("tabuleiro");
            blackking = content.Load<Texture2D>("blackking");
            blackpeon = content.Load<Texture2D>("blackpeon");
            whiteking = content.Load<Texture2D>("whiteking");
            whitepeon = content.Load<Texture2D>("whitepeon");
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
                spriteBatch.Draw(whitepeon, interfaceManager.PieceRect(boardManager.Player1[i]), Color.White);
                spriteBatch.Draw(blackpeon, interfaceManager.PieceRect(boardManager.Player2[i]), Color.White);
            }
            spriteBatch.Draw(whiteking, interfaceManager.PieceRect(boardManager.Player1[9]), Color.White);
            spriteBatch.Draw(blackking, interfaceManager.PieceRect(boardManager.Player2[9]), Color.White);

            spriteBatch.End();
        }

        //Handle inputs for this screen
        public override void HandleInput(InputState input)
        {
            if (input.IsNewMousePress())
            {
                Position click = interfaceManager.ScreenToBoard(input.CurrentMouseState.X, input.CurrentMouseState.Y);
                string message = click.X +" , " + click.Y;

                MessageBoxScreen coord = new MessageBoxScreen(message);
                ScreenManager.AddScreen(coord, base.ControllingPlayer);
            }      
        }

        #endregion
    }
}
