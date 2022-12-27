using Microsoft.Xna.Framework;
using QuantuMaze.Collision;
using QuantuMaze.GameObjects;
using QuantuMaze.Input;

namespace QuantuMaze.Movement
{
    internal class MovementManager
    {

        KeyboardReader input = new KeyboardReader();
        private bool hasJumped = false;
        private Vector2 gravity = new Vector2(0, 3);
        private Vector2 velocity = new Vector2(0, 0);
        private Vector2 jumpForce = new Vector2(0, 40);
        int w = 800;
        int h = 480;
        private Vector2 lastPosition = Vector2.Zero;
        public void Move(IMovable move, Vector2 firstPosition)
        {
            lastPosition = firstPosition;
            var direction = input.ReadInput();
            var distance = direction * move.Speed;
            if (move is Enemy)
            {
                distance = move.Speed;
            }
            var nextPos = move.Position + distance + gravity;
            nextPos = OOBLimiter(distance, nextPos);

            if ((direction.Y < 0) && !hasJumped && !(move is Enemy))
            {
                hasJumped = true;
                nextPos = nextPos - jumpForce - gravity;
            }
            if (((nextPos.X < (w - move.Hitbox.Rectangle.Width) && nextPos.X > 0) && (nextPos.Y < h - move.Hitbox.Rectangle.Height && nextPos.Y > 0)))
            {
                //if (move.IsEnemy)
                //{
                //    move.Position = nextPos;
                //}
                //else
                //{

                if (!CollisionManager.CheckCollisions(move.Hitbox.Rectangle, nextPos))
                {
                    move.Position = nextPos;
                }
                else
                {
                    if (move is Enemy)
                    {
                        move.Speed *= -1;
                        move.Position = lastPosition;
                    }
                    else
                    {
                        if (!CollisionManager.CheckCollisions(move.Hitbox.Rectangle,lastPosition))
                        {
                            move.Position = new Vector2(nextPos.X, move.Position.Y);
                            if (CollisionManager.CheckCollisions(move.Hitbox.Rectangle,move.Position))
                            {
                                move.Position = new Vector2(lastPosition.X, nextPos.Y);
                                if (CollisionManager.CheckCollisions(move.Hitbox.Rectangle, move.Position))
                                {
                                    move.Position = lastPosition;
                                }
                            }
                        }
                        if (lastPosition.Y==move.Position.Y)
                        {
                            hasJumped=false;
                        }
                    }

                }
                //}
            }
            else
            {
                if (lastPosition != Vector2.Zero && hasJumped == false)
                {
                    move.Position = new Vector2(400, 400);
                }
            }
            lastPosition = move.Position;
        }

        private Vector2 OOBLimiter(Vector2 distance, Vector2 nextPos)
        {
            if (nextPos.Y >= h - 20)
            {
                nextPos -= gravity;
            }
            if (nextPos.Y <= 0)
            {
                nextPos += gravity;
            }
            if (nextPos.X >= w - 20)
            {
                nextPos.X -= distance.X;
            }
            if (nextPos.X <= 0)
            {
                nextPos.X -= distance.X;
            }

            return nextPos;
        }

        public void Jump()
        {

        }
    }
}
/// enemy 
/// jump delay