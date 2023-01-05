using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.Input
{
    internal class KeyboardReader : IInputReader
    {
        bool jumped = false;
        bool respawned = false;
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            var direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Space)&&jumped==false)
            {
                jumped=true;
                direction.Y -= 1;
            }
            if (!state.IsKeyDown(Keys.Space)&&jumped==true)
            {
                jumped = false;
            }
            if (state.IsKeyDown(Keys.R) && respawned == false)
            {
                respawned = true;
                direction.Y += 1;
            }
            if (!state.IsKeyDown(Keys.R) && respawned == true)
            {
                respawned = false;
            }

            return direction;
        }
    }
}
