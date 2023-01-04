using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Controls;
using QuantuMaze.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.States
{
    internal class MenuState : State
    {
        private List<Component> components;
        private Texture2D backgroundTexture;
        private Texture2D titleTexture;
        public MenuState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content)
        {

            backgroundTexture = content.Load<Texture2D>("BackGround/Menu");//staat in folder als 01.png door probleem met content.mgcb
            var startButtonTexture = content.Load<Texture2D>("Controls/StartButton");
            var exitButtonTexture = content.Load<Texture2D>("Controls/ExitButton");
            titleTexture = content.Load<Texture2D>("Title/Title");
            var buttonFont = content.Load<SpriteFont>("Fonts/File");
            var startGameButton = new Button(startButtonTexture)
            {
                Position = new Vector2(590, 270)
            };
            startGameButton.Click += StartGameButton_Click;
            var quitGameButton = new Button(exitButtonTexture)
            {
                Position = new Vector2(590, 540)
            };
            quitGameButton.Click += QuitGameButton_Click;
            components = new List<Component>()
            {
                startGameButton,quitGameButton
            };
        }
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            game.StateManager.ChangeState(new GameState(game, graphics, content));
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            game.Exit();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(titleTexture, new Vector2(205, 30), Color.White);

            foreach (var comp in components)
            {
                comp.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var comp in components)
            {
                comp.Update(gameTime);
            }
        }
    }
}
