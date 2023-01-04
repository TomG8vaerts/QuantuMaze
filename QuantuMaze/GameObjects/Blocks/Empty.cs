using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects.Blocks
{
    internal class Empty : Block
    {
        public Empty(int x, int y) : base(x, y, 0, 0)
        {
            Passable = true;
            Hitbox.Collidable = false;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Hitbox.Rectangle, Hitbox.Rectangle, Color.Transparent);
        }
    }
}
