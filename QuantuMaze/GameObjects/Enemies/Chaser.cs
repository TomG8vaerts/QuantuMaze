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
        public Chaser(Texture2D texture,Player player) : base(texture,player)
        {
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 39, 14, 20)));
            animation.AddFrame(new AnimationFrame(new Rectangle(23, 40, 14, 20)));
            animation.AddFrame(new AnimationFrame(new Rectangle(44, 40, 14, 20)));
            animation.AddFrame(new AnimationFrame(new Rectangle(23, 40, 14, 20)));
        }
    }
}
