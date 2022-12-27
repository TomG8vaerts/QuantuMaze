using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
using QuantuMaze.Collision;
using QuantuMaze.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects
{
    internal class Enemy : IMovable
    {
        private Texture2D texture;
        private Animation animation;
        private Vector2 position;
        private Vector2 speed;
        private MovementManager movementManager;
        private Hitbox hitbox;

        public Enemy(Texture2D texture)
        {
            this.texture = texture;
            Position = new Vector2(300, 10);
            Speed = new Vector2(1, 0);
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle((int)position.X, (int)position.Y, 20, 20)));
            movementManager = new MovementManager();
            Hitbox = new Hitbox(position,22, 22, Color.Black);
            CollisionManager.AddCollisionBox(Hitbox);
        }

        public Vector2 Position { get => position; set => position=value; }
        public Vector2 Speed { get => speed; set => speed=value; }
        public Hitbox Hitbox { get => hitbox; set => hitbox=value; }

        public void LoadContent(GraphicsDevice graphics)
        {
            Hitbox.LoadContent(graphics);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Hitbox.Draw(spriteBatch, Position);
            spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
            Hitbox.Update(Position);
        }

        public void Move()
        {
            movementManager.Move(this,Position);
        }
    }
}
