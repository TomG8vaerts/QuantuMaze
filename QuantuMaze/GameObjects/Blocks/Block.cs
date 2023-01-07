using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
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
        public Texture2D wallTexture { get; set; }
        public Texture2D tileTexture { get; set; }
        public bool Passable { get; set; }
        internal Animation animation;


        public Block(int x, int y, int width, int height)
        {
            Hitbox = new Hitbox(new Vector2(x, y), width, height);
            Hitbox.Collidable = true;
            Passable = false;
            animation = new Animation();
            //tile 
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 80, 10)));
            //wall
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 10, 80)));
        }
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
