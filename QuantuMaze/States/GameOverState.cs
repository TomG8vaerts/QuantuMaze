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
        public Game1 Game1 { get; set; }
        public GraphicsDevice Graphics { get; set; }
        public ContentManager Content { get; set; }
        public GameOverState(Game1 game1, GraphicsDevice graphics, ContentManager content)
        {
            gameOverTexture = content.Load<Texture2D>("Background/Game");
            Graphics = graphics;
            Content = content;
            Game1 = game1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(gameOverTexture, new Vector2(0, 0), Color.White);
            spriteBatch.End();
        }

        public void QuitGameButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void StartGameButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            keyboardState=Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                game1.ChangeState(new MenuState(game, graphics, content));
            }
        }
    }
}
