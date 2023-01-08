using Microsoft.Xna.Framework;
using QuantuMaze.GameObjects;
using QuantuMaze.GameObjects.Enemies;
using QuantuMaze.Input;

namespace QuantuMaze.Movement
{
    internal class MovementManager
    {
        KeyboardReader input = new KeyboardReader();
        private Vector2 gravity = new Vector2(0, 3);
        int w = 1920;
        int h = 1080;
        private Vector2 lastPosition = Vector2.Zero;
        private bool isEnemyMove;
        public MovementManager(bool IsEnemyMove)
        {
            this.isEnemyMove = IsEnemyMove;
        }
        public void Move(IMovable move, Vector2 firstPosition)
        {
            lastPosition = firstPosition;
            var direction = input.ReadInput();
            if(isEnemyMove)direction=new Vector2(1,0);
            var distance = direction * move.Speed;
            var nextPos = move.Position + distance + gravity;
            nextPos = KeyboardInput(move, direction, distance, nextPos);
            if (((nextPos.X < (w - move.Hitbox.Rectangle.Width) && nextPos.X > 0) && (nextPos.Y < h - move.Hitbox.Rectangle.Height && nextPos.Y > 0)))
            {
                move.CollisionBehavior(move, nextPos, lastPosition);
            }
            lastPosition = move.Position;
        }

        private Vector2 KeyboardInput(IMovable move, Vector2 direction, Vector2 distance, Vector2 nextPos)
        {
            if (direction.X == 0&&move is Player) move.IsMoving = false;
            else move.IsMoving = true;
            if ((direction.Y < 0) && !move.Jumped) nextPos = move.Jump(move, nextPos)-gravity;
            if (distance.X < 0) move.IsFacingLeft = true;
            else if (distance.X > 0) move.IsFacingLeft = false;
            return nextPos;
        }
    }
}