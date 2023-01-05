using Microsoft.Xna.Framework;
using QuantuMaze.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects
{
    internal interface IPlayerInfo
    {
        public Vector2 Position { get; set; }
        public Hitbox Hitbox { get; set; }
        public int Health { get; set; }
        public void TakeDamage();
    }
}
