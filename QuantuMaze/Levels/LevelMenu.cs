using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.Levels
{
    internal class LevelMenu:Component
    {
        private Rectangle menu;
        private Rectangle healthBar;
        private Rectangle collectionBar;
        public int GameClear { get; set; }
        public LevelMenu(IPlayerInfo player)
        {

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
