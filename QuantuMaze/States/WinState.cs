using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuantuMaze.InfoMenu;

namespace QuantuMaze.States
{
    internal class WinState : State
    {
        private Texture2D winTexture;
        private Texture2D menuTexture;
        private SpriteFont menuFont;
        private KeyboardState keyboardState;
        private KeyboardState lastkeyboardState;
        private Rectangle rectangle;
        private bool tryAgain = false;
        private StateMenu stateMenu;
        public WinState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content)
        {
            winTexture = content.Load<Texture2D>("GameOver/WinScreen");
            menuTexture = content.Load<Texture2D>("Message/Rectangle");
            menuFont = content.Load<SpriteFont>("Fonts/myFont");
            rectangle = new Rectangle(0, 0, 1920, 1080);
            stateMenu = new StateMenu(menuTexture, menuFont);
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
            stateMenu.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            lastkeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            if (keyboardState.GetPressedKeys().Length < 1)
            {
                if (lastkeyboardState.IsKeyDown(Keys.Enter) && keyboardState.IsKeyUp(Keys.Enter))
                {
                    tryAgain = true;
                }
            }
                
        }
    }
}
