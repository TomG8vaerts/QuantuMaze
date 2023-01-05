using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects.Enemies;
using QuantuMaze.GameObjects;
using QuantuMaze.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace QuantuMaze.States
{
    internal class GameState : State
    {
        private LevelManager levelManager;
        private Texture2D backgroundTexture;
        public GameState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content)
        {
            backgroundTexture = content.Load<Texture2D>("BackGround/Game");
            levelManager = new LevelManager(content);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            levelManager.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            levelManager.Update(gameTime);
        }
    }
}
