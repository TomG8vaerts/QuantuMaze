using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects;
using QuantuMaze.Movement;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.Collision
{
    internal class Hitbox
    {
        public Rectangle Rectangle { get; set; }
        public Texture2D Texture { get; set; }
        public Color BoxColor { get; set; }
        public bool Collidable { get; set; }

        public Hitbox(Vector2 position, int width, int height,Color color)
        {
            Rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            BoxColor = color;
        }
        public void LoadContent(GraphicsDevice graphics)
        {
            Texture = new Texture2D(graphics, 1, 1);
            Texture.SetData(new[] { BoxColor });

        }
        public void Draw(SpriteBatch spriteBatch,Vector2 position)
        {
            spriteBatch.Draw(Texture,position,Rectangle,BoxColor);
        }
        public void Update(Vector2 newPosition)
        {
            Rectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, Rectangle.Width, Rectangle.Height);

        }
    }
}
