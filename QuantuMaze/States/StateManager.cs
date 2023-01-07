using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.States
{
    public enum States
    {
        Menu,
        Game,
        GameOver,
        Win
    }
    public class StateManager
    {
        private States currentState;
        private State menuState;
        private State gameOverState;
        private State winState;
        private State gameState;
        private Game1 game1;
        private GraphicsDevice graphics;
        private ContentManager content;
        public StateManager(Game1 game1,GraphicsDevice graphics, ContentManager content)
        {
            this.game1 = game1;
            this.graphics = graphics;
            this.content = content;
            currentState = States.Menu;
            menuState = new MenuState(game1,graphics,content);
            gameState = new GameState(game1, graphics, content);
            gameOverState = new GameOverState(game1, graphics, content);
            winState = new WinState(game1, graphics, content);

        }
        public void Update(GameTime gameTime)
        {
            if (currentState==States.Menu)
            {
                menuState.Update(gameTime);
            }
            else if (currentState == States.Game)
            {
                gameState.Update(gameTime);
            }
            else if (currentState == States.GameOver)
            {
                gameOverState.Update(gameTime);
            }
            else if (currentState == States.Win)
            {
                winState.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentState == States.Menu)
            {
                menuState.Draw(spriteBatch);
            }
            else if (currentState == States.Game)
            {
                gameState.Draw(spriteBatch);
            }
            else if (currentState == States.GameOver)
            {
                gameOverState.Draw(spriteBatch);
            }
            else if (currentState == States.Win)
            {
                winState.Draw(spriteBatch);
            }
            ChangeState();
        }
        public void ChangeState()
        {
            if (currentState == States.Menu)
            {
                currentState = menuState.ChangeState();
            }
            else if (currentState == States.Game)
            {
                currentState = gameState.ChangeState();
            }
            else if (currentState == States.GameOver)
            {
                currentState = gameOverState.ChangeState();
                if (currentState!=States.GameOver)
                {
                    CollisionManager.ClearAll();
                    menuState = new MenuState(game1,graphics,content);
                    gameState = new GameState(game1,graphics,content);

                }
            }
            else if (currentState == States.Win)
            {
                currentState = winState.ChangeState();
            }
        }
    }
}
