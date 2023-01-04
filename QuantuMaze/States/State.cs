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
    public abstract class State
    {
        protected ContentManager content;
        protected GraphicsDevice graphics;
        protected Game1 game;
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
        public State(Game1 game, GraphicsDevice graphics,ContentManager content)
        {
            this.game = game;
            this.graphics = graphics;
            this.content = content;
        }
    }
}
