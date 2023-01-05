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
            Color = Color.Aquamarine;
            WallHitbox = new Hitbox(new Vector2(x, y),10, 80,Color);
            WallHitbox.Collidable = true;
            //CollisionManager.AddCollisionBox(WallHitbox);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Hitbox.Rectangle, Hitbox.Rectangle, Color);
            spriteBatch.Draw(Texture, WallHitbox.Rectangle, WallHitbox.Rectangle, Color);
        }
    }
}
