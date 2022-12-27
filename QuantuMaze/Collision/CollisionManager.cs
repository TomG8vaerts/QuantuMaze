using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace QuantuMaze.Collision
{
    internal class CollisionManager
    {
        static List<Hitbox> collisionBoxes = new List<Hitbox>();

        public static void AddCollisionBox(Hitbox box)
        {
            collisionBoxes.Add(box);
        }
        public static bool CheckCollisions(Rectangle rectangle, Vector2 position)
        {
            // This Collisiondetection requires that every *type* of hitbox does not have the same width and height as any other.
            var currentRectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            var nextRectangle = new Rectangle((int)position.X, (int)position.Y, rectangle.Width, rectangle.Height);
            foreach (Hitbox box in collisionBoxes)
            {
                if (box.Rectangle != currentRectangle)
                    if (box.Collidable)
                        if (currentRectangle.Intersects(box.Rectangle) || nextRectangle.Intersects(box.Rectangle)) return true;
            }
            return false;
        }

    }
}
