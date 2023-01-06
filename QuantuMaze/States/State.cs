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
    public interface State
    {
        public Game1 Game1 { get; set; }
        public GraphicsDevice Graphics { get; set; }
        public ContentManager Content { get; set; }
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
        public void QuitGameButton_Click(object sender, EventArgs e);
        public void StartGameButton_Click(object sender, EventArgs e);
    }
}
