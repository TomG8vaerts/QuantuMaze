using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.Collision
{
    internal class Hitbox
    {
        private Texture2D texture;
        private Rectangle rectangle;

        public Hitbox(GraphicsDevice graphics,int width, int height)
        {
            rectangle = new Rectangle(1,1,width,height);
            this.texture = new Texture2D(graphics, width, height);
            this.texture.SetData(new[] { Color.White });
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,rectangle,Color.White);
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
