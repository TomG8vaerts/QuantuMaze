using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.States
{
    public class StateManager
    {
        private State currentState;
        private State nextState;
        public StateManager(Game1 game1,GraphicsDevice graphics, ContentManager content)
        {
            currentState = new MenuState(game1,graphics,content);
        }
        public void Update(GameTime gameTime)
        {
            if (nextState != null)
            {
                currentState = nextState;
                nextState = null;
            }
            currentState.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch);
        }
        public void ChangeState(State state)
        {
            nextState = state;
        }
    }
}
