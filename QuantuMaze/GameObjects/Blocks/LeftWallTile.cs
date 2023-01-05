using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects.Blocks
{
    internal class LeftWallTile : Tile
    {
        public Hitbox WallHitbox { get; set; }
        public LeftWallTile(int x, int y) : base(x, y)
        {
            WallHitbox = new Hitbox(new Vector2(x, y),10, 80);
            WallHitbox.Collidable = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tileTexture, Hitbox.Rectangle, animation.FindFrame(0).SourceRectangle, Color.White);
            spriteBatch.Draw(wallTexture, WallHitbox.Rectangle, animation.FindFrame(1).SourceRectangle, Color.White);
        }
    }
}
