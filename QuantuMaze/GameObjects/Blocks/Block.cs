using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects.Blocks
{
    internal abstract class Block : IGameObject
    {
        public Hitbox Hitbox { get; set; }
        public Texture2D Texture { get; set; }
        public Color Color { get; set; } = Color.Transparent;
        public bool Passable { get; set; }


        public Block(int x, int y, int width, int height)
        {
            
            Hitbox = new Hitbox(new Vector2(x, y), width, height, Color);
            Hitbox.Collidable = true;
            //CollisionManager.AddCollisionBox(Hitbox);
        }
        public void LoadContent(GraphicsDevice graphics)
        {
            Hitbox.LoadContent(graphics); 
            Texture = new Texture2D(graphics, 1, 1);
            Texture.SetData(new[] { Color });
        }
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
