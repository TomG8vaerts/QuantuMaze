using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
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
        public Wall(int x,int y) : base(x,y,10,80)
        {
            Passable = false;
            Hitbox.Collidable = true;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(wallTexture, Hitbox.Rectangle, animation.FindFrame(1).SourceRectangle,Color.White);
        }
    }
}
