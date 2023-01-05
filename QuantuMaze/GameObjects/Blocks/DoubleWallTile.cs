using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Collision;

namespace QuantuMaze.GameObjects.Blocks
{
    internal class DoubleWallTile : Tile
    {
        public Hitbox LeftWallHitbox { get; set; }
        public Hitbox RightWallHitbox { get; set; }
        public DoubleWallTile(int x, int y) : base(x, y)
        {
            Color = Color.Magenta;
            RightWallHitbox = new Hitbox(new Vector2(x + 70, y), 10, 80, Color);
            LeftWallHitbox = new Hitbox(new Vector2(x, y), 10, 80, Color);
            RightWallHitbox.Collidable = true;
            LeftWallHitbox.Collidable = true;
            //CollisionManager.AddCollisionBox(LeftWallHitbox);
            //CollisionManager.AddCollisionBox(RightWallHitbox);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Hitbox.Rectangle, Hitbox.Rectangle, Color);
            spriteBatch.Draw(Texture, LeftWallHitbox.Rectangle, LeftWallHitbox.Rectangle, Color);
            spriteBatch.Draw(Texture, RightWallHitbox.Rectangle, RightWallHitbox.Rectangle, Color);
        }
    }
}
