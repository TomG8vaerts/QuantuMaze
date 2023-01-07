using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.States
{
    internal class WinState : State
    {
        private Texture2D winTexture;
        private KeyboardState keyboardState;
        private KeyboardState lastkeyboardState;
        private Rectangle rectangle;
        private bool tryAgain = false;
        public WinState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content)
        {
            winTexture = content.Load<Texture2D>("GameOver/WinScreen");
            rectangle = new Rectangle(0, 0, 1920, 1080);
        }


        public override States ChangeState()
        {
            if (tryAgain)
            {
                tryAgain = false;
                return States.Menu;
            }
            else return States.Win;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(winTexture, rectangle, Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            lastkeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            if (lastkeyboardState.IsKeyDown(Keys.Space)&&keyboardState.IsKeyUp(Keys.Space))
            {
                tryAgain = true;
            }
        }
    }
}
