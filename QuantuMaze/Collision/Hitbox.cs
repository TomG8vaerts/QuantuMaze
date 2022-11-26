using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects;
using QuantuMaze.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.Collision
{
    internal class Hitbox
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private Color boxColor;
        public Rectangle Rectangle { get { return rectangle; } set { value = rectangle; } }
        public Texture2D Texture { get { return texture; } set { value = texture; } }
        public Color BoxColor { get { return boxColor; } set { boxColor = value; } }

        public Hitbox(int width, int height,Color color,Vector2 position, Vector2 speed)
        {
            this.rectangle = new Rectangle((int)position.X,(int)position.Y,width,height);
            boxColor = color;
        }
        public void LoadContent(GraphicsDevice graphics)
        {
            this.texture = new Texture2D(graphics, 1, 1);
            this.texture.SetData(new[] { boxColor });

        }
        public void Draw(SpriteBatch spriteBatch,Vector2 position)
        {
            spriteBatch.Draw(texture,position,rectangle,boxColor);
        }
    }
}
