using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.States
{
    internal class WinState : State
    {
        public Game1 Game1 { get; set; }
        public GraphicsDevice Graphics { get; set; }
        public ContentManager Content { get; set; }
        public WinState(Game1 game1,GraphicsDevice graphics,ContentManager content)
        {
            Graphics = graphics;
            Content = content;
            Game1 = game1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void QuitGameButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void StartGameButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
