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

namespace QuantuMaze.GameObjects.Enemies
{
    internal abstract class Enemy : IMovable,IAnimated
    {
        private Texture2D texture;
        private Animation animation;
        private MovementManager movementManager;

        public Enemy(Texture2D texture)
        {
            this.texture = texture;
            Position = new Vector2(10, 10);
            Speed = new Vector2(1, 0);
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle((int)Position.X, (int)Position.Y, 20, 20)));
            movementManager = new MovementManager();
            Hitbox = new Hitbox(Position, 22, 22, Color.Black);
            //CollisionManager.AddCollisionBox(Hitbox);
        }

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Hitbox Hitbox { get; set; }
        public bool Jumped { get; set; }

        public void LoadContent(GraphicsDevice graphics)
        {
            Hitbox.LoadContent(graphics);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Hitbox.Draw(spriteBatch, Position);
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
            Hitbox.Update(Position);
        }
        public void Update(GameTime gameTime,Player player)
        {
            Move(player);
            animation.Update(gameTime);
            Hitbox.Update(Position);
        }
        public void Move(Player player=null)
        {
            movementManager.Move(this, Position,player);
        }

        public void CollisionBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos)
        {
            CollisionManager.EnemyBehavior(move, nextPos, lastPos);

        }
    }
}
