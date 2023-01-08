using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects.Blocks
{
    internal class RightWallTile:Tile
    {
        public Hitbox WallHitbox { get; set; }
        public RightWallTile(int x, int y) : base(x, y)
        {
            WallHitbox = new Hitbox(new Vector2(x+70, y), 10, 80);
            WallHitbox.Collidable = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(wallTexture, WallHitbox.Rectangle, animation.FindFrame(1).SourceRectangle, Color.White);
        }
    }
}
