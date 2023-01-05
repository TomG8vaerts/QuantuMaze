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
using Microsoft.Xna.Framework.Input;

namespace QuantuMaze.States
{
    internal class GameOverState : State
    {
        private Texture2D gameOverTexture;
        private KeyboardState keyboardState;
        public GameOverState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content)
        {
            gameOverTexture = content.Load<Texture2D>("Background/Game");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(gameOverTexture, new Vector2(0, 0), Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            keyboardState=Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                game.ChangeState(new MenuState(game, graphics, content));
            }
        }
    }
}
