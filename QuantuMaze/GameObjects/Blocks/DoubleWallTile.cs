using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
using QuantuMaze.Collision;

namespace QuantuMaze.GameObjects.Blocks
{
    internal class DoubleWallTile : Tile
    {
        public Hitbox LeftWallHitbox { get; set; }
        public Hitbox RightWallHitbox { get; set; }

        public DoubleWallTile(int x, int y) : base(x, y)
        {
            RightWallHitbox = new Hitbox(new Vector2(x + 70, y), 10, 80);
            LeftWallHitbox = new Hitbox(new Vector2(x, y), 10, 80);
            RightWallHitbox.Collidable = true;
            LeftWallHitbox.Collidable = true;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tileTexture, Hitbox.Rectangle, animation.FindFrame(0).SourceRectangle, Color.White);
            spriteBatch.Draw(wallTexture, LeftWallHitbox.Rectangle, animation.FindFrame(1).SourceRectangle, Color.White);
            spriteBatch.Draw(wallTexture, RightWallHitbox.Rectangle, animation.FindFrame(1).SourceRectangle, Color.White);
        }
    }
}
