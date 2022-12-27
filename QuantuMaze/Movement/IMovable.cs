using Microsoft.Xna.Framework;
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
        public void Move();
    }
}
