﻿using Microsoft.Xna.Framework;
using QuantuMaze.GameObjects;
using QuantuMaze.GameObjects.Enemies;
using QuantuMaze.Input;

namespace QuantuMaze.Movement
{
    internal class MovementManager
    {

        KeyboardReader input = new KeyboardReader();
        private Vector2 gravity = new Vector2(0, 3);
        private Vector2 jumpForce = new Vector2(0, 180);
        int w = 1920;
        int h = 1080;
        private Vector2 lastPosition = Vector2.Zero;
        private Vector2 playerPos = Vector2.Zero;
        public void Move(IMovable move, Vector2 firstPosition, IPlayerInfo player)
        {
            playerPos=player.Position;
            lastPosition = firstPosition;
            var direction = input.ReadInput();
            var distance = direction * move.Speed;
            if (move is Jumper || move is Stroller) distance = move.Speed;
            else if (move is Chaser) distance = Vector2.Zero;

            var nextPos = move.Position + distance + gravity;
            nextPos = OOBLimiter(distance, nextPos);
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
            if ((direction.Y < 0) && !move.Jumped) nextPos = Jump(move, nextPos);
            if (distance.X < 0) move.IsFacingLeft = true;
            else if (distance.X > 0) move.IsFacingLeft = false;
            return nextPos;
        }

        private Vector2 Jump(IMovable move, Vector2 nextPos)
        {
            if (move is Player || move is Jumper)
            {
                move.Jumped = true;
                nextPos = nextPos - jumpForce - gravity;
                if ( nextPos.Y < 0)
                {
                    nextPos = new Vector2(lastPosition.X, h - jumpForce.Y+move.Position.Y-40);
                }
            }
            else if (move is Chaser)
            {
                move.Jumped = true;
                move.Position=playerPos - gravity;
            }

            return nextPos;
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

    }
}