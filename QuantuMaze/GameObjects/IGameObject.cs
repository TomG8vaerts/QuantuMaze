using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects
{
    internal interface IGameObject
    {
        public Hitbox Hitbox { get; set; }
        public void Draw(SpriteBatch spriteBatch);
    }
}
