using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
using QuantuMaze.Collision;
using QuantuMaze.Movement;

namespace QuantuMaze.GameObjects.Enemies
{
    internal class Chaser : Enemy
    {
        public Chaser(Texture2D texture, IPlayerInfo player) : base(texture, player)
        {
            Speed = new Vector2(0, 0);
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(23, 38, 14, 20)));
            animation.AddFrame(new AnimationFrame(new Rectangle(23, 38, 14, 20)));
        }
        public override void CollisionBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos)
        {
            CollisionManager.StandardBehavior(move, nextPos, lastPos);
        }

        public override Vector2 Jump(IMovable move, Vector2 nextPos)
        {
            move.Jumped = true;
            nextPos = new Vector2(Player.Hitbox.Rectangle.X, Player.Hitbox.Rectangle.Y);
            return nextPos;
        }
    }
}
