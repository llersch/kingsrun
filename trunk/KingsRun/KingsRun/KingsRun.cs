using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace KingsRun
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class KingsRun : Microsoft.Xna.Framework.Game
    {
        #region Fields

        static public bool AIturn = false;
       
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ScreenManager screenManager;
        
        #endregion

        public KingsRun()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            screenManager = new ScreenManager(this);

            this.IsMouseVisible = true;

            Components.Add(screenManager);
            screenManager.AddScreen(new GameplayScreen(), null);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);

            // The real drawing happens inside the screen manager component.
            base.Draw(gameTime);
        }
    }
}
