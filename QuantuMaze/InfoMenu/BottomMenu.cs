using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.InfoMenu
{
    internal abstract class BottomMenu : Component
    {
        protected Rectangle menu;
        protected Texture2D texture;
        protected SpriteFont font;
        public BottomMenu(Texture2D texture, SpriteFont font)
        {
            this.font = font;
            this.texture = texture;
            menu = new Rectangle(0, 1040, 1920, 50);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
