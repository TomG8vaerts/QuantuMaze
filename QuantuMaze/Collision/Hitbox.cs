using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuantuMaze.Collision
{
    internal class Hitbox
    {
        public Rectangle Rectangle { get; set; }
        public Texture2D Texture { get; set; }
        public Color BoxColor { get; set; }
        public bool Collidable { get; set; }
        public Vector2 Offset { get; set; }

        public Hitbox(Vector2 position, int width, int height, Color color, int offsetX = 0, int offsetY = 0)
        {
            Offset = new Vector2(offsetX, offsetY);
            Rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            BoxColor = color;
            CollisionManager.AddCollisionBox(this);
        }
        public void LoadContent(GraphicsDevice graphics)
        {
            Texture = new Texture2D(graphics, 1, 1);
            Texture.SetData(new[] { BoxColor });

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(Texture, new Vector2((int)position.X, (int)position.Y), Rectangle, BoxColor);
        }
        public void Update(Vector2 newPosition)
        {
            Rectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, Rectangle.Width, Rectangle.Height);

        }
    }
}
