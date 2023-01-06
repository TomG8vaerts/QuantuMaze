using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Input;
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
        private Texture2D startButtonTexture;
        private Texture2D exitButtonTexture;
        public Game1 Game1 { get; set; }
        public GraphicsDevice Graphics { get; set; }
        public ContentManager Content { get; set; }
        public MenuState(Game1 game1, GraphicsDevice graphics, ContentManager content)
        {
            Graphics = graphics;
            Content = content;
            Game1 = game1;
            backgroundTexture = Content.Load<Texture2D>("BackGround/Menu");
            startButtonTexture = Content.Load<Texture2D>("Controls/StartButton");
            exitButtonTexture = Content.Load<Texture2D>("Controls/ExitButton");
            titleTexture = Content.Load<Texture2D>("Title/Title");
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

        public void StartGameButton_Click(object sender, EventArgs e)
        {
        }
        public void QuitGameButton_Click(object sender, EventArgs e)
        {
            Game1.Exit();
        }
        public void Draw(SpriteBatch spriteBatch)
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

        public void Update(GameTime gameTime)
        {
            foreach (var comp in components)
            {
                comp.Update(gameTime);
            }
        }
    }
}
