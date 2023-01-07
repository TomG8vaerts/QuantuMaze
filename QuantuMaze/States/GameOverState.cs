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
        private KeyboardState lastkeyboardState;
        private Rectangle rectangle;
        private bool tryAgain = false;
        public GameOverState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content)
        {
            gameOverTexture = content.Load<Texture2D>("GameOver/GameOverScreen");
            rectangle = new Rectangle(0, 0, 1920, 1080);
        }

        public override States ChangeState()
        {
            if (tryAgain)
            {
                tryAgain = false;
                return States.Menu;
            }
            else return States.GameOver;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(gameOverTexture, rectangle, Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            lastkeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            if (lastkeyboardState.IsKeyDown(Keys.Space) && keyboardState.IsKeyUp(Keys.Space))
            {
                tryAgain = true;
            }
        }
    }
}
