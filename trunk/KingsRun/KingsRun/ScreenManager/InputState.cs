#region File Description
//-----------------------------------------------------------------------------
// InputState.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameStateManagement
{
    /* Helper for reading input from keyboard and gamepad. This class tracks both
     the current and previous state of both input devices, and implements query
     methods for high level input actions such as "move up through the menu"
     or "pause the game". */
    public class InputState
    {
        private KeyboardState CurrentKeyboardState = new KeyboardState();
        private KeyboardState LastKeyboardState = new KeyboardState();


        // Reads the latest state of the keyboard and gamepad.
        public void Update()
        {
            LastKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
        }


        /* Helper for checking if a key was newly pressed during this update. The
         controllingPlayer parameter specifies which player to read input for.
         If this is null, it will accept input from any player. When a keypress
         is detected, the output playerIndex reports which player pressed it.*/
        public bool IsNewKeyPress(Keys key)
        {
            return (CurrentKeyboardState.IsKeyDown(key) &&
                    LastKeyboardState.IsKeyUp(key));
        }


        /* Checks for a "menu select" input action.
         The controllingPlayer parameter specifies which player to read input for.
         If this is null, it will accept input from any player. When the action
         is detected, the output playerIndex reports which player pressed it. */
        public bool IsMenuSelect()
        {
            return IsNewKeyPress(Keys.Space) ||
                   IsNewKeyPress(Keys.Enter);
        }


        /* Checks for a "menu cancel" input action.
         The controllingPlayer parameter specifies which player to read input for.
         If this is null, it will accept input from any player. When the action
         is detected, the output playerIndex reports which player pressed it. */
        public bool IsMenuCancel()
        {
            return IsNewKeyPress(Keys.Escape);
        }


        /* Checks for a "menu up" input action.
         The controllingPlayer parameter specifies which player to read
         input for. If this is null, it will accept input from any player. */
        public bool IsMenuUp()
        {
            return IsNewKeyPress(Keys.Up);
        }


        /* Checks for a "menu down" input action.
         The controllingPlayer parameter specifies which player to read
         input for. If this is null, it will accept input from any player. */
        public bool IsMenuDown()
        {
            return IsNewKeyPress(Keys.Down);
        }


        /* Checks for a "pause the game" input action.
         The controllingPlayer parameter specifies which player to read
         input for. If this is null, it will accept input from any player. */
        public bool IsPauseGame()
        {
            return IsNewKeyPress(Keys.Escape);
        }


    }
}
