using Microsoft.Xna.Framework;
using QuantuMaze.GameObjects;
using QuantuMaze.GameObjects.Enemies;
using QuantuMaze.Movement;
using System.Collections.Generic;

namespace QuantuMaze.Collision
{
    internal static class CollisionManager
    {
        static List<Hitbox> collisionBoxes = new List<Hitbox>();
        static List<Hitbox> enemyHitboxes = new List<Hitbox>();
        static List<Collectible> collectibles = new List<Collectible>();
        public static void AddCollisionBox(Hitbox box)
        {
            collisionBoxes.Add(box);
        }
        public static void AddEnemyHitbox(Hitbox box)
        {
            enemyHitboxes.Add(box);
        }
        public static void AddCollectible(Collectible collectible)
        {
            collectibles.Add(collectible);
        }
        public static bool CheckCollisions(Rectangle rectangle, Vector2 position)
        {
            // This Collisiondetection requires that every *type* of hitbox does not have the same width and height as any other.
            var currentRectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            var nextRectangle = new Rectangle((int)position.X, (int)position.Y, rectangle.Width, rectangle.Height);
            foreach (Hitbox box in collisionBoxes)
            {
                if (box.Rectangle != currentRectangle && !box.Passable)
                    if (box.Collidable)
                        if (currentRectangle.Intersects(box.Rectangle) || nextRectangle.Intersects(box.Rectangle)) return true;
            }
            return false;

        }
        private static void StandardBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos)
        {
            if (!CheckCollisions(move.Hitbox.Rectangle, nextPos))
            {
                move.Position = nextPos;
            }
            else if (!CheckCollisions(move.Hitbox.Rectangle, move.Position))
            {
                move.Position = new Vector2(nextPos.X, move.Position.Y);
                if (CheckCollisions(move.Hitbox.Rectangle, move.Position))
                {
                    move.Position = new Vector2(lastPos.X, nextPos.Y);
                    if (CheckCollisions(move.Hitbox.Rectangle, move.Position))
                    {
                        move.Position = lastPos;
                    }
                }
            }
        }
        public static void PlayerBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos)
        {
            StandardBehavior(move, nextPos, lastPos);
            CollectibleCheck(move);
            GroundCheck(move, lastPos);
        }

        private static void CollectibleCheck(IMovable move)
        {
            var currentRectangle = new Rectangle((int)move.Position.X, (int)move.Position.Y, move.Hitbox.Rectangle.Width, move.Hitbox.Rectangle.Height);
            foreach (Collectible orb in collectibles)
            {
                if (currentRectangle.Intersects(orb.Hitbox.Rectangle) && orb.Collected == 0)
                {
                    orb.Collected = 1;
                }
            }
        }

        private static bool CheckPlayerCollision(IMovable move, IPlayerInfo player)
        {
            foreach (Hitbox box in enemyHitboxes)
            {
                if (player.Hitbox.Rectangle.Intersects(box.Rectangle)) return true;
            }
            return false;
        }

        private static void GroundCheck(IMovable move, Vector2 lastPos)
        {
            if (lastPos.Y == move.Position.Y && move.Jumped == true)
            {
                move.Jumped = false;
            }
        }

        public static void EnemyBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos, IPlayerInfo player)
        {
            StandardBehavior(move, nextPos, lastPos);
            GroundCheck(move, lastPos);
            if (CheckCollisions(move.Hitbox.Rectangle, new Vector2(nextPos.X, move.Position.Y)))
            {
                if (move is Stroller || move is Jumper)
                {
                    move.Speed *= -1;
                }
            }
            if (CheckPlayerCollision(move, player))
            {
                player.CurrentHealth--;
            }
        }
        public static void ClearAll()
        {
            collisionBoxes.Clear();
            enemyHitboxes.Clear();
            collectibles.Clear();
        }
    }
}
