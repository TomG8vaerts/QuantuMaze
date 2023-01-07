using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects.Enemies
{
    internal class Jumper : Enemy
    {

        public Jumper( Texture2D texture,IPlayerInfo player) : base(texture,player)
        {
        }
    }
}
