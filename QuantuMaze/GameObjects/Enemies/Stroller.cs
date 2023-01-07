using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuantuMaze.GameObjects.Enemies
{
    internal class Stroller : Enemy
    {

        public Stroller(Texture2D texture, IPlayerInfo player) : base( texture, player)
        {
        }
    }
}
