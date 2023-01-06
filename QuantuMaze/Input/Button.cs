using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuantuMaze.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.Input
{
    internal class Button : Component
    {
        private MouseState mouseState;
        private MouseState lastMouseState;
        private bool isHovering;
        private Texture2D texture;

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }
        public Button(Texture2D texture)
        {
            this.texture = texture;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (isHovering) color = Color.Gray;
            spriteBatch.Draw(texture, Rectangle, color);
        }

        public override void Update(GameTime gameTime)
        {
            lastMouseState = mouseState;
            mouseState = Mouse.GetState();
            var mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
            isHovering = false;
            if (mouseRectangle.Intersects(Rectangle))
            {
                isHovering = true;
                if (mouseState.LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
