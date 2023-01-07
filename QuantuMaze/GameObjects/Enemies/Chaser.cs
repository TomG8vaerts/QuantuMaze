using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects.Enemies
{
    internal class Chaser : Enemy
    {
        public Chaser(Texture2D texture,IPlayerInfo player) : base(texture,player)
        {
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(23, 40, 14, 20)));
        }
    }
}
