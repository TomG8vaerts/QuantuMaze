using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuantuMaze.Collision
{
    internal class Hitbox
    {
        public Rectangle Rectangle { get; set; }
        public bool Collidable { get; set; }
        public bool Passable { get; set; } = false;
        public Vector2 Offset { get; set; }

        public Hitbox(Vector2 position, int width, int height, int offsetX = 0, int offsetY = 0)
        {
            Offset = new Vector2(offsetX, offsetY);
            Rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            CollisionManager.AddCollisionBox(this);
        }
        public void Update(Vector2 newPosition)
        {
            Rectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, Rectangle.Width, Rectangle.Height);

        }
    }
}
