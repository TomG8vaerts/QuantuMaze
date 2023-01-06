using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.States
{
    enum states
    {
        MenuState,
        GameState,
        GameOverState,
        WinState

    }
    public class StateManager:State
    {
        private states currentState;
        private State menu;
        private State game;
        private State gameOver;
        private State win;
        public Game1 Game1 { get; set; }
        public GraphicsDevice Graphics { get; set; }
        public ContentManager Content { get; set; }
        public StateManager(Game1 game1,GraphicsDevice graphics, ContentManager content)
        {
            currentState = states.MenuState;
            Graphics = graphics;
            Content = content; 
            Game1 = game1;
            menu=new MenuState(Game1, Graphics, Content);
            game=new GameState(Game1, Graphics, Content);
            gameOver=new GameOverState(Game1, Graphics, Content);
            win = new WinState(Game1,Graphics,Content);
        }
        public void Update(GameTime gameTime)
        {
            if (currentState==states.MenuState)
            {
                menu.Update(gameTime);
            }
            else if (currentState == states.GameState)
            {
                game.Update(gameTime);
                if(game.)
            }
            else if (currentState == states.GameOverState)
            {
                gameOver.Update(gameTime);
            }
            else if (currentState == states.WinState)
            {
                win.Update(gameTime);
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentState == states.MenuState)
            {
                menu.Draw(spriteBatch);
            }
            else if (currentState == states.GameState)
            {
                game.Draw(spriteBatch);
            }
            else if (currentState == states.GameOverState)
            {
                gameOver.Draw(spriteBatch);
            }
            else if (currentState == states.WinState)
            {
                win.Draw(spriteBatch);
            }
        }

        public void QuitGameButton_Click(object sender, EventArgs e)
        {
            if (currentState == states.MenuState)
            {
                menu.QuitGameButton_Click(sender, e);
            }
            else if (currentState == states.GameState)
            {
                throw new NotImplementedException();

            }
            else if (currentState == states.GameOverState)
            {
                throw new NotImplementedException();

            }
            else if (currentState == states.WinState)
            {
                throw new NotImplementedException();

            }
        }

        public void StartGameButton_Click(object sender, EventArgs e)
        {
            if (currentState == states.MenuState)
            {
                menu.StartGameButton_Click(sender, e);
                currentState = states.GameState;
            }
            else if (currentState == states.GameState)
            {
                throw new NotImplementedException();

            }
            else if (currentState == states.GameOverState)
            {
                throw new NotImplementedException();

            }
            else if (currentState == states.WinState)
            {
                throw new NotImplementedException();

            }
        }
    }
}
