using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Collision;
using QuantuMaze.Movement;

namespace QuantuMaze.GameObjects.Enemies
{
    internal class Stroller : Enemy
    {
        public Stroller(Texture2D texture, IPlayerInfo player) : base(texture, player)
        {
            Speed = new Vector2(1, 0);
        }
        public override void CollisionBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos)
        {
            base.CollisionBehavior(move, nextPos, lastPos);
            if (CollisionManager.CheckCollisions(move.Hitbox.Rectangle, new Vector2(nextPos.X, move.Position.Y)))
            {
                move.Speed *= -1;
            }
        }

        public override Vector2 Jump(IMovable move, Vector2 nextPos)
        {
            return nextPos;
        }
    }
}
