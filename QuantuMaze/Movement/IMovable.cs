using Microsoft.Xna.Framework;
using QuantuMaze.Animate;
using QuantuMaze.Collision;
using QuantuMaze.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.Movement
{
    internal interface IMovable:IGameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public bool Jumped { get; set; }
        public bool IsFacingLeft { get; set; }
        public bool IsMoving { get; set; }
        public void Move();
        public Vector2 Jump(IMovable move, Vector2 nextPos);
        public void CollisionBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos);
    }
}
