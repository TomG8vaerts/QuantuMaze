using Microsoft.Xna.Framework.Graphics;
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
        }
    }
}
