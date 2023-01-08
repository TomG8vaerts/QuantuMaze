using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Collision;
using QuantuMaze.Movement;

namespace QuantuMaze.GameObjects.Enemies
{
    internal class Jumper : Enemy
    {
        public Vector2 JumpForce { get; set; }
        public Jumper(Texture2D texture, IPlayerInfo player) : base(texture, player)
        {
            Speed = new Vector2(1, 0);
            JumpForce = new Vector2(0, 180);
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
            move.Jumped = true;
            nextPos = nextPos - JumpForce;
            if (nextPos.Y < 0)
            {
                nextPos = new Vector2(move.Position.X, 1080 - JumpForce.Y + move.Position.Y - 40);
            }
            return nextPos;
        }
    }
}
