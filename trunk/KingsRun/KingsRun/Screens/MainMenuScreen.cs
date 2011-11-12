#region File Description
//-----------------------------------------------------------------------------
// MainMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace KingsRun
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class MainMenuScreen : MenuScreen
    {
        #region Fields

        static string[] colors = {"White", "Black"};
        static int currentColor = 0;
        static int depth = 1;

        MenuEntry playGameMenuEntry;
        MenuEntry colorMenuEntry;
        MenuEntry depthMenuEntry;
        MenuEntry exitMenuEntry;

        ContentManager content;
        Texture2D backgroundTexture;

        #endregion

        #region Initialization

        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen()
            : base("King's Run")
        {
            // Create our menu entries.
            playGameMenuEntry = new MenuEntry(string.Empty);
            colorMenuEntry = new MenuEntry(string.Empty);
            depthMenuEntry = new MenuEntry(string.Empty);
            exitMenuEntry = new MenuEntry(string.Empty);

            SetMenuEntryText();

            // Hook up menu event handlers.
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            colorMenuEntry.Selected += ColorMenuEntrySelected;
            depthMenuEntry.Selected += DepthMenuEntrySelected;
            exitMenuEntry.Selected += ExitMenuEntrySelected;

            // Add entries to the menu.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(colorMenuEntry);
            MenuEntries.Add(depthMenuEntry);
            MenuEntries.Add(exitMenuEntry);

        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            backgroundTexture = content.Load<Texture2D>("chess_piece");
        }

        public override void UnloadContent()
        {
            content.Unload();
        }

        #endregion

        void SetMenuEntryText()
        {

            playGameMenuEntry.Text = "Play Game";
            colorMenuEntry.Text = "Color: " + colors[currentColor];
            depthMenuEntry.Text = "Depth: " + depth;
            exitMenuEntry.Text = "Exit";
        }

        #region Handle Input


        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new GameplayScreen(Convert.ToBoolean(currentColor) ,depth), e.PlayerIndex);
            //ScreenManager.RemoveScreen(this);
        }

        void ColorMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            currentColor = (currentColor + 1) % colors.Length;
            SetMenuEntryText();
        }

        void DepthMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            depth = (depth % 5) + 1;
            SetMenuEntryText();
        }

        void ExitMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }


        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            const string message = "Are you sure you want to exit this sample?";

            MessageBoxScreen confirmExitMessageBox = new MessageBoxScreen(message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
        }


        /// <summary>
        /// Event handler for when the user selects ok on the "are you sure
        /// you want to exit" message box.
        /// </summary>
        void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }


        #endregion

        public override void  Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            Viewport viewport = ScreenManager.GraphicsDevice.Viewport;

            //Creates the rectangle
            Rectangle fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);

            //Draw the rectangle
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, fullscreen, Color.White);
            spriteBatch.End();

            ScreenManager.FadeBackBufferToBlack(TransitionAlpha * 2 / 3);

            base.Draw(gameTime);
        }
    }
}
