using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects.Blocks
{
    internal class Wall : Block
    {
        public Wall(int x,int y) : base(x,y,5,40)
        {
            Color = Color.Goldenrod;
            Passable = false;
            Hitbox.Collidable = true;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Hitbox.Rectangle,Hitbox.Rectangle, Color);
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
