using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.InfoMenu
{
    internal class StateMenu : BottomMenu
    {
        public StateMenu(Texture2D texture, SpriteFont font) : base(texture, font)
        {
            menu = new Rectangle(850,850,120,60);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Press Enter to try again.", new Vector2(menu.X, menu.Y), Color.Coral);
        }
    }
}
